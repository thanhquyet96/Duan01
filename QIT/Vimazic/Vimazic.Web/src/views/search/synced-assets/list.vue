<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Tìm kiếm tài sản đơn vị</strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nhóm tài sản"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <!--<b-form-input type="text" id="input-name" v-model="searchForm.str" placeholder="Nhập tên hoặc mã ..."></b-form-input>-->
                                    <select2 :value="searchForm.assetTypeId" :options="listAssetTypes"
                                            style="width:100%"
                                             placeholder="--- Chọn nhóm tài sản ---"></select2>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Mã tài sản"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" v-model="searchForm.assetId" placeholder="Nhập tên hoặc mã ..."></b-form-input>
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
                                    <b-form-input type="text" v-model="searchForm.assetName" placeholder="Nhập tên hoặc mã ..."></b-form-input>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Bộ phận sử dụng"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" v-model="searchForm.unitId" placeholder="Nhập tên hoặc mã ..."></b-form-input>
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
                                    <b-form-input type="date" v-model="searchForm.startDate" placeholder=""></b-form-input>
                                    <!--<b-form-datepicker v-model="searchForm.startDate" class="mb-2"></b-form-datepicker>-->
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Ngày sử dụng - đến ngày"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="date" v-model="searchForm.endDate" placeholder=""></b-form-input>
                                    <!--<b-form-datepicker v-model="searchForm.endDate" class="mb-2"></b-form-datepicker>
    <b-calendar v-model="searchForm.endDate" @context="onContext" locale="en-US"></b-calendar>-->
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
                            dataUrl="master-data/countries"
                            gridName="Danh sách quốc gia"
                            ref="countriesTable">
                      
                        <template v-slot:cell(_actions)="row">
                            <b-button-group>
                                <b-button v-if="authorize(['ViewCountry'])" size="sm" :to="{ path: `/search/synced-assets/detail/${row.item.id}` }" title="xem">
                                    <i class="fa fa-eye" aria-hidden="true"></i>
                                </b-button>
                                <b-button v-if="authorize(['ManageCountry'])" size="sm" @click.stop="remove(row.item, row.index, $event.target)" class="mr-1" title="xóa">
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
                    str: null,
                    assetTypeId: null,
                    startDate: null,
                    endDate: null,
                    assetId: null,
                    assetName: null,
                    unitId:null,

                },
                listAssetTypes: [],
                gridOptions: {
                    fields: [
                        { key: 'code', label: 'Mã tài sản', sortable: true, sortDirection: 'asc' },
                        { key: 'name', label: 'Tên tài sản', sortable: true, sortDirection: 'asc' },
                        { key: 'name1', label: 'Tên nhóm tài sản', sortable: true, sortDirection: 'asc' },
                        { key: 'description', label: 'Ngày sử dụng', sortable: false },
                        { key: 'description1', label: 'Bộ phận sử dụng', sortable: false },
                    ],
                    sortBy: 'code',
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
                this.$refs.countriesTable.refresh();
            },
            loadAssetTypes() {
                var vm = this;
                return this.$services.get(`master-data/asset-types`).done(data => {
                    vm.listAssetTypes = data;
                });
            },
            remove(item, index, button) {
                var vm = this;
                if (confirm('Bạn có chắc chắn muốn xóa quốc gia này?')) {
                    this.$services.delete(`master-data/countries/${item.id}`).done(() => {
                        vm.$toastr.s('Xóa quốc gia thành công');
                        vm.search();
                    });
                }
            },
            deletes() {
                var vm = this;
                var selectedRows = this.$refs.countriesTable.selectedRows;
                if (selectedRows.length > 0) {
                    if (confirm('Bạn có chắc chắn muốn xóa các quốc gia này?')) {
                        var data = selectedRows.map(x => x.id).join(',');
                        this.$services.delete(`master-data/countries?ids=${data}`).done(() => {
                            vm.$toastr.s('Xóa các quốc gia thành công');
                            vm.search();
                        });
                    }
                }
                else {
                    vm.$toastr.e('Vui lòng chọn quốc gia cần xóa');
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
