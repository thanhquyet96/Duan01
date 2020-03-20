<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Phân quyền người dùng</strong>
                    </div>
                    <b-form @submit.prevent="save" style="min-height: 500px">
                        <b-row>
                            <b-col md="4">
                                <b-form-group label="Danh sách chuyên mục"
                                              label-for="module">
                                    <treeselect id="module"
                                                ref="moduleTree"
                                                v-model="moduleId"
                                                :normalizer="normalizer"
                                                :branchNodesFirst="true"
                                                :defaultExpandLevel="0"
                                                :always-open="true"
                                                :append-to-body="true"
                                                :max-height="430"
                                                placeholder="--- Chọn ---"
                                                :options="allModules" />
                                </b-form-group>
                            </b-col>
                            <b-col md="8">
                                <b-form-group :label="'Chuyên mục ' + selectedModule.name.toLowerCase()" v-if="selectedModule"
                                              label-for="privileges">
                                    <b-form-checkbox-group id="privileges" v-model="userPrivileges" class="checkbox-group">
                                        <template v-if="selectedModule.children && selectedModule.children.length > 0">
                                            <template v-for="module in selectedModule.children">
                                                <span style="font-weight: bold;">{{ module.name }}</span>
                                                <hr />
                                                <b-form-checkbox v-for="privilege in getModulePrivileges(module)" :key="privilege.id" :value="privilege.id" class="col-md-6">{{ privilege.text }}</b-form-checkbox>
                                                <br />
                                                <br />
                                            </template>
                                        </template>
                                        <template v-else>
                                            <b-form-checkbox v-for="privilege in getModulePrivileges(selectedModule)" :key="privilege.id" :value="privilege.id" class="col-md-6">{{ privilege.text }}</b-form-checkbox>
                                        </template>
                                    </b-form-checkbox-group>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="8" offset="4">
                                <b-button type="submit" variant="primary"> Ghi lại</b-button>
                                <b-button type="button" variant="secondary" @click="cancel">Hủy</b-button>
                            </b-col>
                        </b-row>
                    </b-form>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>
<script>
    import nav from '@/_nav'
    import { mapState } from 'vuex'

    export default {
        name: 'UserPrivileges',
        data() {
            return {
                userPrivileges: [],
                moduleId: null,
                normalizer(node) {
                    return {
                        id: node.code,
                        label: node.name,
                        children: node.children,
                    }
                },
            }
        },
        computed: {
            selectedModule() {
                if (!this.moduleId) return null;

                function findModule(modules, moduleId) {
                    for (var i = 0; i < modules.length; i++) {
                        if (modules[i].code == moduleId) {
                            return modules[i];
                        } else if (modules[i].children && modules[i].children.length > 0) {
                            var nested = findModule(modules[i].children, moduleId);
                            if (nested) {
                                return nested;
                            }
                        }
                    }

                    return null;
                }
                var module = findModule(this.allModules, this.moduleId);

                return module;
            },
            allModules() {
                return nav.items.slice(1).filter(x => x.code);
            },
            ...mapState({
                allPrivileges: (state, getters) => state.common.privileges
            }),
        },
        created() {
            var vm = this;

            this.$services.get(`users/${this.$route.params.userId}/privileges`).done((privileges) => {
                vm.userPrivileges = privileges;
            });
        },
        methods: {
            getModulePrivileges(module) {
                var requiresPrivileges = module.requiresPrivileges || [];

                return this.allPrivileges.filter(x => requiresPrivileges.indexOf(x.id) != -1);
            },
            save() {
                var vm = this;

                this.$services.put(`users/${this.$route.params.userId}/privileges`, { privileges: this.userPrivileges }).done(() => {
                    vm.$toastr.s('Phân quyền người dùng thành công.');
                    vm.cancel();
                });
            },
            cancel() {
                this.$router.push({ path: '/system/users/list' });
            },
        }
    }
</script>
<style scoped>
</style>
