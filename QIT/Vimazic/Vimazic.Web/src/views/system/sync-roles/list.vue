<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Nhóm tài khoản đồng bộ dữ liệu</strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row>
                            <b-col md="8" offset="2">
                                <b-form-group label="Nhóm tài khoản đồng bộ dữ liệu:"
                                              label-for="name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" id="name"
                                                  placeholder="Nhập tên nhóm tài khoản đồng bộ dữ liệu ..."
                                                  v-model="searchForm.filterText">
                                    </b-form-input>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="8" offset="2">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="submit" variant="primary">Tìm kiếm</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-form>
                    <br />
                    <b-grid :searchForm="searchForm"
                            :gridOptions="gridOptions"
                            selectable
                            dataUrl="sync-roles"
                            gridName="Danh sách nhóm tài khoản đồng bộ dữ liệu"
                            ref="syncRoleTable">
                        <template v-slot:actions v-if="authorize(['ManageSyncRole'])">
                            <router-link to="/system/sync-roles/create" tag="button" class="btn btn-primary" size="md">
                                Thêm mới
                            </router-link>
                            <b-button size="md" @click.stop="removeSelected" variant="danger">
                                Xóa
                            </b-button>
                        </template>
                        <template v-slot:cell(_actions)="row">
                            <b-button-group>
                                <b-button size="sm" :to="{ path: `/system/sync-roles/detail/${row.item.id}` }" title="xem" v-if="authorize(['ViewSyncRole'])">
                                    <i class="fa fa-eye" aria-hidden="true"></i>
                                </b-button>
                                <b-button size="sm" :to="{ path: `/system/sync-roles/privileges/${row.item.id}` }" title="phân quyền" v-if="authorize(['ManageSyncRole'])">
                                    <i class="fa fa-cogs" aria-hidden="true"></i>
                                </b-button>
                                <b-button size="sm" @click.stop="remove(row.item, row.index, $event.target)" class="mr-1" title="xóa" v-if="authorize(['ManageSyncRole'])">
                                    <i class="fa fa-trash-o" aria-hidden="true"></i>
                                </b-button>
                            </b-button-group>
                        </template>
                    </b-grid>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>
<script>
    import { authorizationMixin } from '@/shared/mixins'

    export default {
        name: 'ListSyncRole',
        mixins: [authorizationMixin],
        data() {
            return {
                searchForm: {
                    filterText: null
                },
                gridOptions: {
                    fields: [
                        { key: 'name', label: 'Tên', sortable: true, sortDirection: 'asc' },
                        { key: 'unitName', label: 'Đơn vị', sortable: true, sortDirection: 'asc' },
                        { key: 'description', label: 'Mô tả', sortable: false },
                    ],
                    sortBy: 'name',
                },
            }
        },
        created() {
        },
        methods: {
            search() {
                this.$refs.syncRoleTable.refresh();
            },
            remove(item, index, button) {
                var vm = this;
                if (confirm('Bạn có chắc chắn muốn xóa nhóm tài khoản đồng bộ dữ liệu này?')) {
                    this.$services.delete(`sync-roles/${item.id}`).done(() => {
                        vm.$toastr.s('Xóa nhóm đồng bộ dữ liệu thành công');
                        vm.search();
                    });
                }
            },
            removeSelected() {
                var vm = this;
                var selectedRows = this.$refs.syncRoleTable.selectedRows;
                if (selectedRows.length > 0) {
                    if (confirm('Bạn có chắc chắn muốn xóa các nhóm tài khoản đồng bộ dữ liệu này?')) {
                        var data = selectedRows.map(x => x.id).join(',');
                        this.$services.delete(`sync-roles?ids=${data}`).done(() => {
                            vm.$toastr.s('Xóa nhóm đồng bộ dữ liệu thành công');
                            vm.search();
                        });
                    }
                }
                else {
                    vm.$toastr.e('Vui lòng chọn nhóm tài khoản đồng bộ dữ liệu cần xóa');
                }
            }
        }
    }
</script>
<style scoped>
</style>
