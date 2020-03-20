<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Báo cáo</strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Đơn vị:"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <unit-tree v-model="searchForm.unitId"></unit-tree>
                                </b-form-group>
                            </b-col>
                            <!--<b-col md="6">
                                <b-form-group label="Nhóm tài sản:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <treeselect v-model="searchForm.assetCategoryId"
                                                placeholder="--- Chọn nhóm tài sản ---"
                                                :options="listAssetTypes" />
                                </b-form-group>
                            </b-col>-->
                            <!--<b-col md="6">
                                <b-form-group label="Mã tài sản:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" v-model="searchForm.code" placeholder="Nhập mã ..."></b-form-input>
                                </b-form-group>
                            </b-col>-->
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Loại báo cáo:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" v-model="searchForm.reportType" placeholder="Nhập tên ..."></b-form-input>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Tên báo cáo:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" v-model="searchForm.reportName" placeholder="Nhập tên bộ phận sử dụng ..."></b-form-input>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Ngày nộp - từ ngày:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <date-picker v-model="searchForm.startDate" placeholder="--- Chọn ---" style="width:100%"></date-picker>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Ngày nộp - đến ngày:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <date-picker v-model="searchForm.endDate" style="width:100%" placeholder="--- Chọn ---"></date-picker>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="submit" variant="primary">Tìm kiếm</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-form>
                    <b-grid :searchForm="searchForm"
                            :gridOptions="gridOptions"
                            selectable
                            dataUrl="manage-data/reports"
                            gridName="Danh sách báo cáo"
                            ref="reportsTable">
                        <template v-slot:actions>
                            <b-button size="md" @click.stop="removeSelected" variant="primary">
                                Xóa
                            </b-button>
                        </template>
                        <template v-slot:cell(_actions)="row">
                            <b-button-group>
                                <b-button v-if="authorize(['ViewAsset'])" size="sm" :to="{ path: `/manage-data/assets/detail/${row.item.id}` }" title="xem">
                                    <i class="fa fa-eye" aria-hidden="true"></i>
                                </b-button>
                                <b-button v-if="authorize(['ManageAsset'])" size="sm" @click.stop="remove(row.item, row.index, $event.target)" class="mr-1" title="xóa">
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
        name: 'ListSyncedAssets',
        mixins: [authorizationMixin],
        data() {
            return {
                searchForm: {
                    reportName: null,
                    reportType: null,
                    unitId: null,
                    startDate: null,
                    endDate: null,
                },
                gridOptions: {
                    fields: [
                        { key: 'unitName', label: 'Tên đơn vị', sortable: true, sortDirection: 'asc' },
                        { key: 'name', label: 'Tên báo cáo', sortable: true, sortDirection: 'asc' },
                        { key: 'reportTypeName', label: 'Loại báo cáo', sortable: true, sortDirection: 'asc' },
                        { key: 'unitName', label: 'Từ ngày', sortable: true },
                        { key: 'dateOfUse', label: 'Đến ngày', sortable: true },
                    ],
                    sortBy: 'id',
                },
            }
        },
        computed: {
            
        },
        created() {
        },
        methods: {
            search() {
                this.$refs.reportsTable.refresh();
            },
            remove(item, index, button) {
                var vm = this;
                if (confirm('Bạn có chắc chắn muốn xóa báo cáo này?')) {
                    this.$services.delete(`manage-data/reports/${item.id}`).done(() => {
                        vm.$toastr.s('Xóa báo cáo thành công');
                        vm.search();
                    });
                }
            },
            removeSelected() {
                var vm = this;
                var selectedRows = this.$refs.reportsTable.selectedRows;
                if (selectedRows.length > 0) {
                    if (confirm('Bạn có chắc chắn muốn xóa các báo cáo này?')) {
                        var data = selectedRows.map(x => x.id).join(',');
                        this.$services.delete(`manage-data/reports?ids=${data}`).done(() => {
                            vm.$toastr.s('Xóa các báo cáo thành công');
                            vm.search();
                        });
                    }
                }
                else {
                    vm.$toastr.e('Vui lòng chọn báo cáo cần xóa');
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
