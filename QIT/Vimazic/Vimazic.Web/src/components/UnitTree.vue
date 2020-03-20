<template>
    <treeselect id="unit" v-if="units.length > 0"
                placeholder="--- Chọn đơn vị ---"
                v-model="unitId"
                :load-options="loadUnits"
                :auto-load-root-options="true"
                :async="true"
                :default-options="rootUnits"
                :always-open="alwaysOpen"
                :max-height="maxHeight"
                :default-expand-level="1"
                :cacheOptions="false"
                ref="treeUnit" />
</template>
<script>
    import { mapState } from 'vuex'
    import { LOAD_CHILDREN_OPTIONS, ASYNC_SEARCH } from '@riophae/vue-treeselect'
    var timer;

    export default {
        name: 'UnitTree',
        props: {
            value: {},
            alwaysOpen: {
                default: false
            },
            maxHeight: {
                type: Number,
                default: 300
            }
        },
        data() {
            return {
                unitId: null,
                isLoaded: false
            }
        },
        computed: {
            ...mapState({
                units: (state) => state.common.units,
                rootUnits(state, getters) {
                    var root = getters.unitTree.map(x => {
                        return {
                            id: x.id,
                            code: x.code,
                            label: x.label,
                            unitTypeId: x.unitTypeId,
                            children: x.children.map(y => {
                                return {
                                    id: y.id,
                                    code: y.code,
                                    label: y.label,
                                    unitTypeId: y.unitTypeId,
                                    children: y.hasChildren ? null : undefined
                                };
                            })
                        };
                    });

                    return root;
                }
            })

        },
        mounted: function () {
            if (this.value) {
                this.selectUnit(this.value);
            }
        },
        methods: {
            loadUnits({ action, parentNode, searchQuery, callback, instanceId }) {
                if (action === LOAD_CHILDREN_OPTIONS) {
                    parentNode.children = this.getUnitChildren(parentNode.id);
                    this.$refs.treeUnit.initialize();
                    callback();
                } else if (action === ASYNC_SEARCH) {
                    if (isNaN(parseInt(searchQuery))) {
                        callback(null, this.getUnitsByName(searchQuery));
                    } else {
                        callback(null, this.getUnitsById(searchQuery));
                        //this.unitId = searchQuery;
                        var vm = this;

                        var node = vm.$refs.treeUnit.getNode(searchQuery);
                        if (node) {
                            vm.$refs.treeUnit.select(node);
                            vm.$refs.treeUnit.resetSearchQuery();
                            //vm.$refs.treeUnit.trigger.searchQuery = node.label;
                        }
                    }
                }
            },
            getUnitChildren(parentId) {
                var children = [];
                for (var i = 0; i < this.units.length; i++) {
                    if (parentId == this.units[i].parentId) {
                        var child = {
                            id: this.units[i].id,
                            code: this.units[i].code,
                            label: this.units[i].name,
                            unitTypeId: this.units[i].unitTypeId
                        };
                        if (this.units[i].hasChildren) {
                            child.children = null;
                        }
                        children.push(child);
                    }
                }
                return children;
            },
            getUnitsByName(searchQuery) {
                if (searchQuery && searchQuery.length > 3) {
                    var match = [];
                    var traverseNodes = [];
                    for (var i = 0; i < this.units.length; i++) {
                        while (traverseNodes.length > 0 && traverseNodes[traverseNodes.length - 1].id != this.units[i].parentId) {
                            traverseNodes.pop();
                        }
                        traverseNodes.push(this.units[i]);

                        //if (fuzzysearch(searchQuery.latinize(), this.units[i].name.latinize())) {
                        if (this.units[i].name.latinize().toLowerCase().trim().indexOf(searchQuery.latinize().toLowerCase().trim()) != -1) {
                            match = match.concat(traverseNodes.filter(x => match.indexOf(x) == -1));
                        }
                        if (!this.units[i].hasChildren) {
                            traverseNodes.pop();
                        }
                    }

                    var units = match.map(x => {
                        return {
                            id: x.id,
                            code: x.code,
                            label: x.name,
                            unitTypeId: x.unitTypeId,
                            isDefaultExpanded: x.hasChildren,
                            parentId: x.parentId,
                        };
                    });
                    return this.buildUnitTree(units, this.$store.state.identity.unitId);
                } else {
                    return [];
                }
            },
            getUnitsById(id) {
                var match = [];
                var traverseNodes = [];
                for (var i = 0; i < this.units.length; i++) {
                    while (traverseNodes.length > 0 && traverseNodes[traverseNodes.length - 1].id != this.units[i].parentId) {
                        traverseNodes.pop();
                    }
                    traverseNodes.push(this.units[i]);

                    if (this.units[i].id == id) {
                        match = match.concat(traverseNodes.filter(x => match.indexOf(x) == -1));
                        break;
                    }
                    if (!this.units[i].hasChildren) {
                        traverseNodes.pop();
                    }
                }

                var units = match.map(x => {
                    return {
                        id: x.id,
                        code: x.code,
                        label: x.name,
                        unitTypeId: x.unitTypeId,
                        isDefaultExpanded: x.hasChildren,
                        parentId: x.parentId,
                    };
                });

                return this.buildUnitTree(units, this.$store.state.identity.unitId);
            },
            buildUnitTree(allUnits, root) {
                var tree = [];

                var parents = [];

                for (var i = 0; i < allUnits.length; i++) {
                    var currentNode = allUnits[i];
                    if (currentNode.id == root) {
                        parents.push(currentNode);
                        tree.push(currentNode);
                        continue;
                    }

                    while (parents.length > 0) {
                        var parentNode = parents[parents.length - 1];
                        if (currentNode.parentId == parentNode.id) {
                            if (!parentNode.children) parentNode.children = [];
                            parentNode.children.push(currentNode);
                            parents.push(currentNode);
                            break;
                        }
                        parents.pop();
                    }
                }

                return tree;
            },
            selectUnit(id) {
                var vm = this;
                if (timer) {
                    clearTimeout(timer);
                }
                if (this.$refs.treeUnit) {
                    this.$refs.treeUnit.trigger.searchQuery = id;
                } else {
                    timer = setTimeout(function () {
                        vm.selectUnit(id);
                    }, 500);
                }
            }
        },
        watch: {
            unitId() {
                this.$emit('input', this.unitId);
            },
            rootUnits(root) {
                if (root.length > 0 && !this.isLoaded) {
                    this.isLoaded = true;
                    if (this.value) {
                        var vm = this;
                        setTimeout(function () {
                            vm.selectUnit(vm.value);
                        }, 500);
                    }
                }
            },
            value(id) {
                if (id != this.unitId) {
                    this.selectUnit(id);
                }
            }
        }
    }
</script>

