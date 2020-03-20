import Services from '@/utils/services'

const state = {
    isInitialized: false,
    privileges: [],
    units: [],
    assetTypes: [],
    unitLevels: [],
    regions: [],
    assetCategories: [],
    sidebarShow: 'responsive',
    sidebarMinimize: false
}

const getters = {
    setting: state => property => {
        return state.appSettings[property];
    },
    unitTree: (state, getters, rootState) => {
        var isAuthenticated = rootState.identity.isAuthenticated;
        if (isAuthenticated) {
            var units = state.units.map(x => {
                return {
                    id: x.id,
                    code: x.code,
                    label: x.name,
                    unitTypeId: x.unitTypeId,
                    hasChildren: x.hasChildren,
                    parentId: x.parentId,
                };
            });

            return BuildUnitTree(units, rootState.identity.unitId);
        } else {
            return [];
        }
    },
    assetTypeTree: (state, getters, rootState) => {
        var isAuthenticated = rootState.identity.isAuthenticated;
        if (isAuthenticated) {
            var assetTypes = state.assetTypes.map(x => {
                return {
                    id: x.id,
                    code: x.code,
                    label: x.name,
                    parentId: x.parentId
                };
            });
            return BuildAssetTypeTree(assetTypes);
        } else {
            return [];
        }
    },
    regionTree: (state, getters, rootState) => {
        var isAuthenticated = rootState.identity.isAuthenticated;
        if (isAuthenticated) {
            var regions = state.regions.map(x => {
                return {
                    id: x.id,
                    code: x.code,
                    label: x.name,
                    hasChildren: x.hasChildren,
                    parentId: x.parentId,
                };
            });
            return BuildAssetTypeTree(regions);
        } else {
            return [];
        }
    },
    getUnitById: (state) => (id) => {
        return state.units.find(unit => unit.id === id)
    },
    checkExitingCode: (state) => (id, code) => {
        var item = state.units.find(unit => unit.id == id && unit.code == code);
        if (item != null) return false;
        return state.units.find(unit => unit.code == code);
    },
    ListAssetCategory: (state) => {
        return state.assetCategories;
    }
}

const actions = {
    loadPrivileges(context) {
        return Services.get('lookup/privileges').done((data) => {
            context.commit('setPrivileges', data);
        });
    },
    loadUnits(context) {
        return Services.get('lookup/units').done((data) => {
            context.commit('setUnits', data);
        });
    },
    loadAssetTypes(context) {
        return Services.get('lookup/asset-types').done((data) => {
            context.commit('setAssetTypes', data);
        });
    },
    loadUnitLevel(context) {
        return Services.get('lookup/unit-levels').done((data) => {
            context.commit('setUnitLevel', data);
        });
    },
    loadRegions(context) {
        return Services.get('lookup/regions').done((data) => {
            context.commit('setRegions', data);
        });
    },
    loadAssetCategory(context) {
        var data = {
            // tài sản công - đất
            NpaLand: 21,
            // tài sản công - nhà
            NpaHouse: 22,
            // tài sản công - xe
            NpaVehicle: 23,
            /// tài sản công - khác
            NpaOther: 24,
            /// tài sản toàn dân - đất
            OaLand: 25,
            /// tài sản toàn dân - nhà
            OaHouse: 26,
            /// tài sản toàn dân - xe
            OaVehicle: 27,
            /// tài sản toàn dân - trên 500M
            OaAbove500M: 28,
            /// tài sản toàn dân - dưới 500M
            OaBelow500M: 29
        };
        return context.commit('setAssetCategory', data);
    },
    initializeSettings(context) {
        if (!context.state.isInitialized) {
            context.dispatch('loadUnits');
            context.dispatch('loadPrivileges');
            context.dispatch('loadAssetTypes');
            context.dispatch('loadUnitLevel');
            context.dispatch('loadRegions');
            context.dispatch('loadAssetCategory');
            context.commit('initialize');
        }
    }
}

// mutations
const mutations = {
    initialize(state) {
        state.isInitialized = true;
    },
    setPrivileges(state, privileges) {
        state.privileges = privileges;
    },
    setUnits(state, data) {
        state.units = data;
    },
    setAssetTypes(state, data) {
        state.assetTypes = data;
    },
    setUnitLevel(state, data) {
        state.unitLevels = data;
    },
    setRegions(state, data) {
        state.regions = data;
    },
    toggleSidebarDesktop(state) {
        const sidebarOpened = [true, 'responsive'].includes(state.sidebarShow)
        state.sidebarShow = sidebarOpened ? false : 'responsive'
    },
    toggleSidebarMobile(state) {
        const sidebarClosed = [false, 'responsive'].includes(state.sidebarShow)
        state.sidebarShow = sidebarClosed ? true : 'responsive'
    },
    set(state, [variable, value]) {
        state[variable] = value
    },
    setAssetCategory(state, data) {
        state.assetCategories = data;
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}


function BuildUnitTree(allUnits, root) {
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
}
function BuildAssetTypeTree(allAssetTypes) {
    var tree = [];
    var parents = [];
    for (var i = 0; i < allAssetTypes.length; i++) {
        var currentNode = allAssetTypes[i];
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
}
