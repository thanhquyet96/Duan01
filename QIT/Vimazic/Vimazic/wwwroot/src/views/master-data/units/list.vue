<template>
    <b-col class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Danh sách đơn vị</strong>
                    </div>
                    <b-row>
                        <b-col md="5">
                        </b-col>
                        <b-col md="7" v-if="authorize(['ManageUnit'])">
                            <div class="pull-right">
                                <b-button tag="button" class="mr5" variant="primary" size="md" :to="{ path: `/master-data/units/create` }" title="xem">
                                    <i class="fa fa-plus" aria-hidden="true"></i>
                                    Thêm mới
                                </b-button>
                                <b-button size="md" tag="button" variant="primary"
                                          :disabled="!unitSelected"
                                          :to="{ path: `/master-data/units/edit/${unitSelected}` }" title="sửa" class="mr5">
                                    <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                    Sửa
                                </b-button>
                                <b-button size="md" variant="primary" @click.stop="remove(unitSelected)" :disabled="!unitSelected">
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
                                <unit-tree v-model="unitSelected" ref="unitTree" :always-open="true" :max-height="390"></unit-tree>
                            </b-col>
                            <b-col md="7" class="border" style="min-height:425px">
                                <b-form-group>
                                    <label class="col-form-label font-weight-bold">Thông tin đơn vị</label>
                                    <b-row>
                                        <b-col md="6">
                                            <b-form-group label="Mã đơn vị:"
                                                          label-for="code"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.code }}</label>
                                            </b-form-group>
                                        </b-col>

                                        <b-col md="6">
                                            <b-form-group label="Tên đơn vị:"
                                                          label-for="name"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.name }}</label>

                                            </b-form-group>
                                        </b-col>
                                    </b-row>
                                    <b-row>
                                        <b-col md="6">
                                            <b-form-group label="Địa bàn:"
                                                          label-for="location"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.regionName }}</label>

                                            </b-form-group>
                                        </b-col>
                                        <b-col md="6">
                                            <b-form-group label="Địa chỉ:"
                                                          label-for="address"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.address }}</label>

                                            </b-form-group>
                                        </b-col>
                                    </b-row>
                                    <b-row>
                                        <b-col md="6">
                                            <b-form-group label="Số điện thoại:"
                                                          label-for="phone"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.phoneNumber }}</label>

                                            </b-form-group>
                                        </b-col>
                                        <b-col md="6">
                                            <b-form-group label="Fax:"
                                                          label-for="fax"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.fax }}</label>

                                            </b-form-group>
                                        </b-col>
                                    </b-row>
                                    <b-row>
                                        <b-col md="6">
                                            <b-form-group label="Phân loại đơn vị:"
                                                          label-for="typeunit"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.unitTypeName }}</label>

                                            </b-form-group>
                                        </b-col>
                                        <b-col md="6">
                                            <b-form-group label="Chế độ hoạch toán:"
                                                          label-for="accountingregime"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.accountingStandardName }}</label>
                                            </b-form-group>
                                        </b-col>
                                    </b-row>
                                    <b-row>
                                        <b-col md="6">
                                            <b-form-group label="Cấp đơn vị:"
                                                          label-for="unitLevel"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.unitLevelName }}</label>
                                            </b-form-group>
                                        </b-col>
                                        <b-col md="6">
                                            <b-form-group label="Trực thuộc:"
                                                          label-for="under"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{ unit.parentUnitName == null ? "Không" : unit.parentUnitName}}</label>
                                            </b-form-group>
                                        </b-col>
                                    </b-row>
                                    <b-row>
                                        <b-col md="6">
                                            <!--Mã đơn vị ngân sách-->
                                            <b-form-group label="Mã định danh:"
                                                          label-for="under"
                                                          :label-cols="5"
                                                          label-align-md="right"
                                                          title="Mã đơn vị ngân sách"
                                                          :horizontal="true">
                                                <label class="col-form-label">{{unit.nationalBudgetCode}}</label>
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
    import { mapState, mapGetters, mapActions } from 'vuex'
    import { authorizationMixin } from '@/shared/mixins'

    import store from '@/store/index'
    export default {
        name: 'ListUnit',
        mixins: [authorizationMixin],
        data() {
            return {
                unitSelected: null,
                unit: {},
            }
        },
        computed: {
            //...mapState({
            //    units: (state, getters) => getters.unitTree,
            //    privileges: (state, getters) => state.identity.privileges
            //}),
        },
        watch: {
            unitSelected() {
                return this.loadUnitDetail();
            }
        },
        created() {
            this.unitSelected = window.UnitSelected || null;
        },
        methods: {
            loadUnitDetail() {
                var vm = this;
                return this.$services.get(`master-data/units/${this.unitSelected}`).done(unit => {
                    vm.unit = unit;
                });
            },
            cancel() {
                this.$router.push({ path: '/master-data/units/list' });
            },
            remove(id) {
                var vm = this;
                if (id) {
                    if (confirm('Bạn có chắc chắn muốn xóa đơn vị này?')) {
                        this.$services.delete(`master-data/units/${id}`).done(() => {
                            vm.$toastr.s('Xóa đơn vị thành công !');
                            this.unitSelected = null;
                            store.dispatch('loadUnits').done(() => {
                                this.cancel();
                            });
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
