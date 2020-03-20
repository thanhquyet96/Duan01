<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>
                            Tài khoản đơn vị đồng bộ dữ liệu
                        </strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Tài khoản:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-name" v-model="searchForm.str" placeholder="Nhập tài khoản hoặc email ..."></b-form-input>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
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
                            dataUrl="sync-users"
                            gridName="Danh sách tài khoản"
                            ref="syncUserTable">
                        <template v-slot:actions v-if="authorize(['ManageSyncUser'])">
                            <router-link to="/system/sync-users/create" tag="button" class="btn btn-primary" size="md">
                                Thêm mới
                            </router-link>
                            <b-button size="md" @click.stop="deletes" variant="primary">
                                Xóa
                            </b-button>
                        </template>
                        <template v-slot:cell(_actions)="row">
                            <b-button-group>
                                <b-button v-if="authorize(['ViewSyncUser'])" size="sm" :to="{ path: `/system/sync-users/detail/${row.item.id}` }" title="xem">
                                    <i class="fa fa-eye" aria-hidden="true"></i>
                                </b-button>
                                <b-button v-if="authorize(['ManageSyncUser'])" size="sm" @click.stop="remove(row.item, row.index, $event.target)" class="mr-1" title="xóa">
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
    import { mapState } from 'vuex'
    import { authorizationMixin } from '@/shared/mixins'

    export default {
        name: 'ListSyncUser',
        mixins: [authorizationMixin],
        data() {
            return {
                searchForm: {
                    str: null
                },
                gridOptions: {
                    fields: [
                        { key: 'userName', label: 'Tên tài khoản', sortable: true, sortDirection: 'asc' },
                        { key: 'unitName', label: 'Đơn vị', sortable: false },
                        { key: 'activeName', label: 'Đang hoạt động', sortable: false }
                    ],
                    sortBy: 'userName',
                },
                statuses: [
                    { id: 1, text: 'active' },
                    { id: 0, text: 'inactive' }
                ],
            }
        },
        computed: {

        },
        created() {
        },
        methods: {
            search() {
                this.$refs.syncUserTable.refresh();
            },
            remove(item, index, button) {
                var vm = this;
                if (confirm('Bạn có chắc chắn muốn xóa tài khoản này?')) {
                    this.$services.delete(`sync-users/${item.id}`).done(() => {
                        vm.$toastr.s('Xóa tài khoản thành công');
                        vm.search();
                    });
                }
            },
            deletes() {
                var vm = this;
                var selectedRows = this.$refs.syncUserTable.selectedRows;
                if (selectedRows.length > 0) {
                    if (confirm('Bạn có chắc chắn muốn xóa các tài khoản này?')) {
                        var data = selectedRows.map(x => x.id).join(',');
                        this.$services.delete(`sync-users/${data}`).done(() => {
                            vm.$toastr.s('Xóa các tài khoản thành công');
                            vm.search();
                        });
                    }
                }
                else {
                    vm.$toastr.e('Vui lòng chọn tài khoản cần xóa');
                }
            }
        }
    }
</script>
<style scoped>

    .w30 {
        width: 30px;
    }
</style>
