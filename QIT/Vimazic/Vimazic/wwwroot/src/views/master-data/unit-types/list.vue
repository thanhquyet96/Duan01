<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Phân loại đơn vị</strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Phân loại đơn vị:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-name" v-model="searchForm.str" placeholder="Nhập tên hoặc mã ..."></b-form-input>
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
                            dataUrl="master-data/unit-types"
                            gridName="Danh sách phân loại đơn vị"
                            ref="unitTypeTable">
                        <template v-slot:actions v-if="authorize(['ManageUnitType'])">
                            <router-link to="/master-data/unit-types/create" tag="button" class="btn btn-primary" size="md">
                                Thêm mới
                            </router-link>
                            <b-button size="md" @click.stop="deletes" variant="primary">
                                Xóa
                            </b-button>
                        </template>
                        <template v-slot:cell(_actions)="row">
                            <b-button-group>
                                <template v-if="authorize(['ViewUnitType'])">
                                    <b-button size="sm" :to="{ path: `/master-data/unit-types/detail/${row.item.id}`}" title="xem">
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
        name: 'ListUnitType',
        mixins: [authorizationMixin],
        data() {
            return {
                searchForm: {
                    str: null
                },
                gridOptions: {
                    fields: [

                        { key: 'code', label: 'Mã loại', sortable: true, sortDirection: 'asc' },
                        { key: 'name', label: 'Tên loại đơn vị', sortable: true },
                    ],
                    sortBy: 'code'
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
                this.$refs.unitTypeTable.refresh();
            },
            remove(item, index, button) {
                var vm = this;

                if (confirm('Bạn có chắc chắn muốn xóa loại đơn vị này?')) {
                    this.$services.delete(`master-data/unit-types/${item.id}`).done(() => {
                        vm.$toastr.s('Xóa loại đơn vị thành công');
                        vm.search();
                    });
                }
            },
            deletes() {
                var vm = this;
                var selectedRows = this.$refs.unitTypeTable.selectedRows;
                if (selectedRows.length > 0) {
                    if (confirm('Bạn có chắc chắn muốn xóa các loại đơn vị này?')) {
                        var data = selectedRows.map(x => x.id).join(',');
                        this.$services.delete(`master-data/unit-types?ids=${data}`).done(() => {
                            vm.$toastr.s('Xóa loại đơn vị thành công');
                            vm.search();
                        });
                    }
                }
                else {
                    vm.$toastr.e('Vui lòng chọn loại đơn vị cần xóa');
                }
            }
        }
    }
</script>
<style scoped>
</style>
