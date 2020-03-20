<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Danh mục quốc gia</strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Quốc gia:"
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
                            dataUrl="master-data/countries"
                            gridName="Danh sách quốc gia"
                            ref="countriesTable">
                        <template v-slot:actions v-if="authorize(['ManageCountry'])">
                            <router-link to="/master-data/countries/create" tag="button" class="btn btn-primary" size="md">
                                Thêm mới
                            </router-link>
                            <b-button size="md" @click.stop="deletes" variant="danger">
                                Xóa
                            </b-button>
                        </template>
                        <template v-slot:cell(_actions)="row">
                            <b-button-group>
                                <b-button v-if="authorize(['ViewCountry'])" size="sm" :to="{ path: `/master-data/countries/detail/${row.item.id}` }" title="xem">
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
        name: 'ListCountry',
        mixins: [authorizationMixin],
        data() {
            return {
                searchForm: {
                    str: null,
                },
                gridOptions: {
                    fields: [
                        { key: 'code', label: 'Mã quốc gia', sortable: true, sortDirection: 'asc' },
                        { key: 'name', label: 'Tên quốc gia', sortable: true, sortDirection: 'asc' },
                        { key: 'description', label: 'Mô tả', sortable: false },
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
