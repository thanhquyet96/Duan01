<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Danh mục địa bàn</strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Địa bàn:"
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
                            dataUrl="master-data/regions"
                            gridName=""
                            ref="regionTable">
                        <template v-slot:gridName>
                            <b-row class="container">
                                <h2 v-if="breadCrumbRegions.length == 0">Danh sách địa bàn</h2>
                                <h2 v-if="breadCrumbRegions.length > 0" class="breadcrumb-sub"><a href="javascript:void(0)" @click="breadCrumbClick()">Danh sách địa bàn</a> </h2>
                                <ol class="breadcrumb" id="breadcrumb-custom">
                                    <li class="breadcrumb-item" v-for="(item,index) in breadCrumbRegions">
                                        <a href="javascript:void(0)" @click="breadCrumbClick(item,index)"
                                           class="open active"
                                           v-if="index != breadCrumbRegions.length - 1">
                                            {{item.name}}
                                        </a>
                                        <span v-if="index == breadCrumbRegions.length - 1" class="open active">
                                            {{item.name}}
                                        </span>
                                    </li>
                                </ol>
                            </b-row>
                        </template>
                        <template v-slot:actions v-if="authorize(['ManageRegion'])">
                            <router-link to="/master-data/regions/create" tag="button" class="btn btn-primary" size="md">
                                Thêm mới
                            </router-link>
                            <b-button size="md" @click.stop="deletes" variant="primary">
                                Xóa
                            </b-button>
                        </template>
                        <template v-slot:cell(_actions)="row">
                            <b-button-group>
                                <b-button size="sm" v-if="authorize(['ViewRegion'])" :to="{ path: `/master-data/regions/detail/${row.item.id}` }" title="xem">
                                    <i class="fa fa-eye" aria-hidden="true"></i>
                                </b-button>
                                <b-button size="sm"
                                          v-if="authorize(['ManageRegion'])"
                                          :disabled="checkLoadChildren != 2"
                                          @click.stop="remove(row.item, row.index, $event.target)" class="mr-1" title="xóa">
                                    <i class="fa fa-trash-o" aria-hidden="true"></i>
                                </b-button>
                                <b-button size="sm" v-if="checkLoadChildren == 0" @click.stop="detailchildren(row.item,checkLoadChildren)" title="xem địa bàn">
                                    <i class="fa fa-play" aria-hidden="true"></i>
                                </b-button>
                                <b-button size="sm" v-if="checkLoadChildren == 1" @click.stop="detailchildren(row.item,checkLoadChildren)" title="xem địa bàn">
                                    <i class="fa fa-play" aria-hidden="true"></i>
                                </b-button>
                                <b-button size="sm" v-if="checkLoadChildren == 2" @click.stop="detailchildren(row.item,checkLoadChildren)" title="xem địa bàn">
                                    <i class="fa fa-play fa-rotate-180" aria-hidden="true"></i>
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
        name: 'ListRegion',
        mixins: [authorizationMixin],
        data() {
            return {
                searchForm: {
                    str: null,
                    isLoad: null,
                    parentId: null
                },
                checkLoadChildren: 0,
                gridOptions: {
                    fields: [
                        { key: 'code', label: 'Mã địa bàn', sortable: true, sortDirection: 'asc' },
                        { key: 'name', label: 'Tên địa bàn', sortable: true, sortDirection: 'asc' },
                    ],
                    sortBy: 'code',
                },
                breadCrumbRegions: []
            }
        },
        computed: {
        },
        created() {
        },
        methods: {
            search() {
                this.gridOptions.page = 1;
                this.$refs.regionTable.refresh();
            },
            detailchildren(item, a) {
                switch (a) {
                    case 0: {
                        this.searchForm.isLoad = true;
                        this.searchForm.parentId = item.id;
                        this.checkLoadChildren++;
                        var objSearch = {
                            name: item.name,
                            isLoad: true,
                            parentId: `${item.id}`,
                            checkLoadChildren: this.checkLoadChildren
                        };
                        this.breadCrumbRegions.push(objSearch);
                        break;
                    }
                    case 1: {
                        this.checkLoadChildren++;
                        this.searchForm.isLoad = false;
                        this.searchForm.parentId = item.id;
                        var objSearch = {
                            name: item.name,
                            isLoad: false,
                            parentId: `${item.id}`,
                            checkLoadChildren: this.checkLoadChildren
                        };
                        this.breadCrumbRegions.push(objSearch);
                        break;
                    }
                    case 2: {
                        this.checkLoadChildren = 0;
                        this.searchForm.isLoad = null;
                        this.searchForm.parentId = null;
                        var objSearch = {
                            name: item.name,
                            isLoad: null,
                            parentId: null,
                            checkLoadChildren: this.checkLoadChildren
                        };
                        this.breadCrumbRegions.push(objSearch);
                        this.breadCrumbRegions = [];
                        break;
                    }
                }
                this.$refs.regionTable.refresh();
            },
            remove(item, index, button) {
                var vm = this;
                if (confirm('Bạn có chắc chắn muốn xóa địa bàn này?')) {
                    this.$services.delete(`master-data/regions/${item.id}`).done((data) => {
                        if (data) {
                            vm.$toastr.s('Xóa địa bàn thành công');
                        }
                        else {
                            vm.$toastr.e('Xóa địa bàn không thành công, do có dữ liệu phụ thuộc !');
                        }
                        vm.search();
                    });
                }
            },
            deletes() {
                var vm = this;
                var selectedRows = this.$refs.regionTable.selectedRows;
                if (selectedRows.length > 0) {
                    if (confirm('Bạn có chắc chắn muốn xóa các địa bàn này?')) {
                        var data = selectedRows.map(x => x.id).join(',');
                        this.$services.delete(`master-data/regions?ids=${data}`).done((data) => {
                            if (data) {
                                vm.$toastr.s('Xóa các địa bàn thành công');
                            }
                            else {
                                vm.$toastr.e('Xóa địa bàn không thành công, do có dữ liệu phụ thuộc !');
                            }
                            vm.search();
                        });
                    }
                }
                else {
                    vm.$toastr.e('Vui lòng chọn địa bàn cần xóa');
                }
            },
            breadCrumbClick(item, index) {
                if (item) {
                    this.searchForm.isLoad = item.isLoad;
                    this.searchForm.parentId = item.parentId;
                    this.checkLoadChildren = item.checkLoadChildren;
                    debugger;
                    var length = this.breadCrumbRegions.length - 1;
                    if (index < length) {
                        this.breadCrumbRegions.splice(index + 1, length - index);
                    }
                    this.$refs.regionTable.refresh();
                }
                else {
                    this.checkLoadChildren = 0;
                    this.searchForm.isLoad = null;
                    this.searchForm.parentId = null;
                    this.$refs.regionTable.refresh();
                    this.breadCrumbRegions = [];
                }
            }
        }
    }
</script>
<style scoped>

    #breadcrumb-custom {
        border-bottom: none !important;
        line-height: 9px;
        font-size: 18px;
        margin-bottom: 0px;
        padding-left: 0.5rem;
    }

    #breadcrumb-custom .breadcrumb-item + .breadcrumb-item::before {
            display: inline-block;
            padding-right: 0.5rem;
            color: #73818f;
            content: ">>";
    }    

    .breadcrumb-sub::after {
        display: inline-block;
        padding-left: 0.5rem;
        color: #73818f;
        content: ">>";
    }
</style>
