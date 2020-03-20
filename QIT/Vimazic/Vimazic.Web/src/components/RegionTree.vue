<template>
    <treeselect id="region" v-if="regions.length > 0"
                placeholder="--- Chọn địa bàn ---"
                v-model="regionId"
                :load-options="loadRegions"
                :auto-load-root-options="true"
                :async="true"
                :default-options="rootRegions"
                :always-open="alwaysOpen"
                :max-height="maxHeight"
                ref="treeRegion" />
</template>
<script>
    import { mapState } from 'vuex'
    import { LOAD_CHILDREN_OPTIONS, ASYNC_SEARCH } from '@riophae/vue-treeselect'
    export default {
        name: 'RegionTree',
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
                regionId: null,
                isLoaded: false
            }
        },
        computed: {
            ...mapState({
                regions: (state) => state.common.regions,
                rootRegions(state, getters) {
                    var root = getters.regionTree.map(x => {
                        return {
                            id: x.id,
                            code: x.code,
                            label: x.label,
                            children: x.children === undefined ? null : x.children.map(y => {
                                return {
                                    id: y.id,
                                    code: y.code,
                                    label: y.label,
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

        },
        methods: {
            loadRegions({ action, parentNode, searchQuery, callback, instanceId }) {
                if (action === LOAD_CHILDREN_OPTIONS) {
                    parentNode.children = this.getRegionChildren(parentNode.id);
                    this.$refs.treeRegion.initialize();
                    callback();
                } else if (action === ASYNC_SEARCH) {
                    if (isNaN(parseInt(searchQuery))) {
                        callback(null, this.getRegionsByName(searchQuery));
                    } else {
                        callback(null, this.getRegionsById(searchQuery));
                        //this.regionId = searchQuery;
                        var vm = this;

                        var node = vm.$refs.treeRegion.getNode(searchQuery);
                        if (node) {
                            vm.$refs.treeRegion.select(node);
                            vm.$refs.treeRegion.resetSearchQuery();
                            //vm.$refs.treeRegion.trigger.searchQuery = node.label;
                        }
                    }
                }
            },
            getRegionChildren(parentId) {
                var children = [];
                for (var i = 0; i < this.regions.length; i++) {
                    if (parentId == this.regions[i].parentId) {
                        var child = {
                            id: this.regions[i].id,
                            code: this.regions[i].code,
                            label: this.regions[i].name,
                        };
                        if (this.regions[i].hasChildren) {
                            child.children = null;
                        }
                        children.push(child);
                    }
                }
                return children;
            },
            getRegionsByName(searchQuery) {
                if (searchQuery && searchQuery.length > 3) {
                    var match = [];
                    var traverseNodes = [];
                    for (var i = 0; i < this.regions.length; i++) {
                        while (traverseNodes.length > 0 && traverseNodes[traverseNodes.length - 1].id != this.regions[i].parentId) {
                            traverseNodes.pop();
                        }
                        traverseNodes.push(this.regions[i]);

                        //if (fuzzysearch(searchQuery.latinize(), this.regions[i].name.latinize())) {
                        if (this.regions[i].name.latinize().toLowerCase().trim().indexOf(searchQuery.latinize().toLowerCase().trim()) != -1) {
                            match = match.concat(traverseNodes.filter(x => match.indexOf(x) == -1));
                        }
                        if (!this.regions[i].hasChildren) {
                            traverseNodes.pop();
                        }
                    }

                    var regions = match.map(x => {
                        return {
                            id: x.id,
                            code: x.code,
                            label: x.name,
                            isDefaultExpanded: x.hasChildren,
                            parentId: x.parentId,
                        };
                    });
                    return this.buildRegionTree(regions);
                } else {
                    return [];
                }
            },
            getRegionsById(id) {
                var match = [];
                var traverseNodes = [];
                for (var i = 0; i < this.regions.length; i++) {
                    while (traverseNodes.length > 0 && traverseNodes[traverseNodes.length - 1].id != this.regions[i].parentId) {
                        traverseNodes.pop();
                    }
                    traverseNodes.push(this.regions[i]);

                    if (this.regions[i].id == id) {
                        match = match.concat(traverseNodes.filter(x => match.indexOf(x) == -1));
                        break;
                    }
                    if (!this.regions[i].hasChildren) {
                        traverseNodes.pop();
                    }
                }

                var regions = match.map(x => {
                    return {
                        id: x.id,
                        code: x.code,
                        label: x.name,
                        isDefaultExpanded: x.hasChildren,
                        parentId: x.parentId,
                    };
                });

                return this.buildRegionTree(regions);
            },
            buildRegionTree(allRegions) {
                var tree = [];

                var parents = [];

                for (var i = 0; i < allRegions.length; i++) {
                    var currentNode = allRegions[i];
                    if (!currentNode.parentId) {
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
            selectRegion(id) {
                this.$refs.treeRegion.trigger.searchQuery = id;
            }
        },
        watch: {
            regionId() {
                this.$emit('input', this.regionId);
            },
            rootRegions(root) {
                if (root.length > 0) {
                    var vm = this;
                    if (!this.isLoaded) {
                        this.isLoaded = true;
                        if (this.value) {
                            setTimeout(function () {
                                vm.selectRegion(vm.value);
                            }, 500);
                        }
                    } else {
                        setTimeout(function () {
                            vm.$refs.treeRegion.handleRemoteSearch();
                        }, 500);
                    }
                }
            }
        }
    }
</script>

