<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Tài sản</strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nhóm tài sản"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <treeselect v-model="searchForm.assetCategoryId"
                                                placeholder="--- Chọn nhóm tài sản ---"
                                                :options="listAssetTypes" />
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Mã tài sản"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" v-model="searchForm.syncSourceId" placeholder="Nhập mã ..."></b-form-input>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Tên tài sản"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" v-model="searchForm.name" placeholder="Nhập tên ..."></b-form-input>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Bộ phận sử dụng"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" v-model="searchForm.unitName" placeholder="Nhập tên bộ phận sử dụng ..."></b-form-input>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Ngày sử dụng - từ ngày"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <date-picker v-model="searchForm.startDate" placeholder="--- Chọn ---" style="width:100%"></date-picker>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Ngày sử dụng - đến ngày"
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
                            dataUrl="manage-data/assets"
                            gridName="Danh sách tài sản"
                            ref="assetsTable">
                        <template v-slot:actions>
                            <b-button size="md" @click.stop="removeSelected" variant="primary">
                                Xóa
                            </b-button>
                        </template>
                        <template v-slot:cell(_actions)="row">
                            <b-button-group>
                                <b-button v-if="authorize(['ViewAsset'])" size="sm" :to="{ path: `/manage/assets/detail/${row.item.id}` }" title="xem">
                                    <i class="fa fa-eye" aria-hidden="true"></i>
                                </b-button>
                                <b-button v-if="authorize(['ManageAsset'])" size="sm" @click.stop="remove(row.item, row.index, $event.target)" class="mr-1" title="xóa">
                                    <i class="fa fa-trash-o" aria-hidden="true"></i>
                                </b-button>
                                <b-button v-if="authorize(['ManageAsset'])" size="sm" @click.stop="mutation(row.item, row.index, $event.target)" class="mr-1" title="biến động">
                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>
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
                    syncSourceId: null,
                    name: null,
                    assetTypeId: null,
                    assetCategoryId:null,
                    dateOfUse: null,
                    expiryDate: null,
                },
                gridOptions: {
                    fields: [
                        { key: 'code', label: 'Mã tài sản', sortable: true, sortDirection: 'asc' },
                        { key: 'name', label: 'Tên tài sản', sortable: true, sortDirection: 'asc' },
                        { key: 'assetTypeName', label: 'Tên nhóm tài sản', sortable: true, sortDirection: 'asc' },
                        { key: 'unitName', label: 'Bộ phận sử dụng', sortable: false },
                        { key: 'dateOfUse', label: 'Ngày sử dụng', sortable: true },
                        { key: 'expiryDate', label: 'Ngày hết hạn sử dụng', sortable: true },
                    ],
                    sortBy: 'code',
                },
            }
        },
        computed: {
            ...mapState({
                listAssetTypes: (state, getters) => getters.assetTypeTree
            }),
        },
        created() {
        },
        methods: {
            search() {
                this.$refs.assetsTable.refresh();
            },
            mutation() {

            },
            remove(item, index, button) {
                var vm = this;
                if (confirm('Bạn có chắc chắn muốn xóa tài sản này?')) {
                    this.$services.delete(`manage-data/assets/${item.id}`).done(() => {
                        vm.$toastr.s('Xóa tài sản thành công');
                        vm.search();
                    });
                }
            },
            removeSelected() {
                var vm = this;
                var selectedRows = this.$refs.assetsTable.selectedRows;
                if (selectedRows.length > 0) {
                    if (confirm('Bạn có chắc chắn muốn xóa các tài sản này?')) {
                        var data = selectedRows.map(x => x.id).join(',');
                        this.$services.delete(`manage-data/assets?ids=${data}`).done(() => {
                            vm.$toastr.s('Xóa các tài sản thành công');
                            vm.search();
                        });
                    }
                }
                else {
                    vm.$toastr.e('Vui lòng chọn tài sản cần xóa');
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
