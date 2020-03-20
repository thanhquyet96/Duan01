<template>
    <b-col class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Danh sách nhóm tài sản</strong>
                    </div>
                    <b-row>
                        <b-col md="5">
                        </b-col>
                        <b-col md="7">
                            <div class="pull-right">
                                <b-button tag="button" class="mr5" variant="primary" size="md" :to="{ path: `/master-data/asset-types/create` }">
                                    <i class="fa fa-plus" aria-hidden="true"></i>
                                    Thêm mới
                                </b-button>
                                <b-button size="md" tag="button" variant="primary"
                                          :disabled="!assetTypeSelected"
                                          :to="{ path: `/master-data/asset-types/edit/${assetTypeSelected}` }" title="sửa" class="mr5">
                                    <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                    Sửa
                                </b-button>
                                <b-button size="md" variant="primary" @click.stop="remove(assetTypeSelected)" :disabled="!assetTypeSelected">
                                    <i class="fa fa-trash-o" aria-hidden="true"></i>
                                    Xóa
                                </b-button>
                            </div>
                        </b-col>
                    </b-row>
                    <br />
                    <b-form style="min-height: 425px; max-height: 800px">
                        <b-row>
                            <b-col md="5">
                                <treeselect ref="assetTypeTree"
                                            v-model="assetTypeSelected"
                                            :branchNodesFirst="true"
                                            :defaultExpandLevel="1"
                                            :always-open="true"
                                            :append-to-body="true"
                                            :max-height="390"
                                            placeholder="Nhập tên nhóm tài sản"
                                            :options="assetTypes" />
                            </b-col>
                            <b-col md="7" class="border" style="min-height:425px">
                                <b-form-group>
                                    <label class="col-form-label font-weight-bold">Thông tin nhóm tài sản</label>
                                    <b-row>
                                        <b-col md="6">
                                            <b-form-group label="Mã nhóm tài sản:"
                                                          label-for="code"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ assetType.code }}</label>
                                            </b-form-group>
                                        </b-col>
                                        <b-col md="6">
                                            <b-form-group label="Tên nhóm tài sản:"
                                                          label-for="name"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ assetType.name }}</label>
                                            </b-form-group>
                                        </b-col>
                                    </b-row>
                                    <b-row>
                                        <b-col md="6">
                                            <b-form-group label="Tên nhóm tài sản cha:"
                                                          label-for="parentname"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ assetType.parentName }}</label>
                                            </b-form-group>
                                        </b-col>
                                        <b-col md="6">
                                            <b-form-group label="Mô tả:"
                                                          label-for="description"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ assetType.description }}</label>
                                            </b-form-group>
                                        </b-col>
                                    </b-row>
                                    <b-row>
                                        <b-col md="6">
                                            <b-form-group label="Ngày bắt đầu:"
                                                          label-for="startdate"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ assetType.startDate }}</label>
                                            </b-form-group>
                                        </b-col>
                                        <b-col md="6">
                                            <b-form-group label="Ngày kết thúc:"
                                                          label-for="enddate"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ assetType.endDate }}</label>
                                            </b-form-group>
                                        </b-col>
                                    </b-row>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-form>
                </b-card>
            </b-col>
        </b-row>
    </b-col>
</template>
<script>
    import { mapState, mapActions } from 'vuex'
    import store from '@/store/index'
    export default {
        name: 'ListAssetType',
        data() {
            return {
                assetTypeSelected: null,
                assetType: {}
            }
        },
        computed: {
            ...mapState({
                units: (state, getters) => getters.unitTree,
                privileges: (state, getters) => state.identity.privileges,
                assetTypes: (state, getters) => getters.assetTypeTree
            }),
        },
        watch: {
            assetTypeSelected() {
                return this.loadAssetTypeDetail();
            }
        },
        created() {

        },
        methods: {
            loadAssetTypeDetail() {
                var vm = this;
                return this.$services.get(`master-data/asset-type-details/${this.assetTypeSelected}`).done(assetType => {
                    vm.assetType = assetType;
                });
            },
            remove(id) {
                var vm = this;
                if (id) {
                    if (confirm('Bạn có chắc chắn muốn xóa nhóm tài sản này?')) {
                        this.$services.delete(`master-data/asset-types/${id}`).done((response) => {
                            if (response) {
                                vm.$toastr.s('Xóa nhóm tài sản thành công !');
                                this.assetTypeSelected = null;
                                store.dispatch('loadAssetTypes');
                            }
                            else {
                                vm.$toastr.e('Xóa nhóm tài sản không thành công,nhóm tài sản chứa nhóm tài sản con vui lòng xóa nhóm tài sản con trước!');
                            }

                        });
                    }
                }
                else {
                    vm.$toastr.e('Vui lòng chọn đơn vị cần xóa');
                }
            },
        }
    }
</script>
<!--scoped-->
<style scoped>

    .mr5 {
        margin-right: 5px;
    }

    .mt15 {
        margin-top: 15px;
    }

    .border {
        border-radius: 5px;
    }
</style>
