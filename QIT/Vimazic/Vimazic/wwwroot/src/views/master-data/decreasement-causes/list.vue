<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Tìm kiếm chung</strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Mã lí do giảm:"
                                              label-for="input-code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input id="input-code"
                                                  v-model="searchForm.code"
                                                  type="text">
                                    </b-form-input>
                                </b-form-group>
                            </b-col>
                            <b-col md="6" offset="3">
                                <b-form-group label="Tên lí do giảm:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input id="input-name"
                                                  v-model="searchForm.name"
                                                  type="text">
                                    </b-form-input>
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
                    <b-grid :searchForm="searchForm"
                            :gridOptions="gridOptions"
                            selectable
                            dataUrl="master-data/decreasement-causes"
                            gridName="Danh sách lý do giảm"
                            ref="decreasementCauseTable">
                        <template v-slot:actions v-if="authorize(['ManageUnitType'])">
                            <router-link to="/master-data/decreasement-causes/create" tag="button" class="btn btn-primary" size="md">
                                Thêm mới
                            </router-link>
                            <b-button size="md" @click.stop="deletes" variant="primary">
                                Xóa
                            </b-button>
                        </template>
                        <template v-slot:cell(_actions)="row">
                            <b-button-group>
                                <template v-if="authorize(['ViewUnitType'])">
                                    <b-button size="sm" :to="{ path: `/master-data/decreasement-causes/detail/${row.item.id}`}" title="xem">
                                        <i class="fa fa-eye" aria-hidden="true"></i>
                                    </b-button>
                                </template>
                                <b-button v-if="authorize(['ManageUnitType'])" size="sm" @click.stop="remove(row.item, row.index, $event.target)" class="mr-1" title="xóa">
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
        name: 'ListIncreasementCause',
        mixins: [authorizationMixin],
        data() {
            return {
                searchForm: {
                    name: null,
                    code: null
                },
                gridOptions: {
                    fields: [
                        { key: 'name', label: 'Mã lí do giảm', sortable: true, sortDirection: 'asc' },
                        { key: 'code', label: 'Tên lí do giảm', sortable: true },
                        { key: 'assetTypeName', label: 'Áp dụng', sortable: true }
                    ],
                    sortBy: 'name'
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
                this.$refs.decreasementCauseTable.refresh();
            },
            remove(item, index, button) {
                var vm = this;

                if (confirm('Bạn có chắc chắn muốn xóa lí do giảm này?')) {
                    this.$services.delete(`master-data/decreasement-causes/${item.id}`).done(() => {
                        vm.$toastr.s('Xóa lí do giảm thành công');
                        vm.search();
                    });
                }
            },
            deletes() {
                var vm = this;
                var selectedRows = this.$refs.decreasementCauseTable.selectedRows;
                if (selectedRows.length > 0) {
                    if (confirm('Bạn có chắc chắn muốn xóa các lí do giảm này?')) {
                        var data = selectedRows.map(x => x.id).join(',');
                        this.$services.delete(`master-data/decreasement-causes?ids=${data}`).done(() => {
                            vm.$toastr.s('Xóa lí do giảm thành công');
                            vm.search();
                        });
                    }
                }
                else {
                    vm.$toastr.e('Vui lòng chọn lí do giảm cần xóa');
                }
            }
        }
    }
</script>
<style scoped>
</style>
