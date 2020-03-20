<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thêm mới đơn vị</strong>
                    </div>
                    <b-form @submit.prevent="save" v-if="authorize(['ManageUnit'])">
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Trực thuộc:"
                                              label-for="under"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true"
                                              label-class="required">
                                    <b-form-input type="text" style="display: none"
                                                  aria-describedby="parentIdFeedback"
                                                  v-model="$v.unit.parentId.$model"
                                                  :state="$v.unit.parentId.$error ? false : null"></b-form-input>
                                    <unit-tree v-model="$v.unit.parentId.$model" ref="unitTree"
                                               aria-describedby="parentIdFeedback"
                                               :state="$v.unit.parentId.$dirty? !$v.unit.parentId.$error : null"></unit-tree>
                                    <b-form-invalid-feedback id="parentIdFeedback">
                                        Vui lòng chọn đơn vị
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Mã đơn vị:"
                                              label-for="code"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="text" id="code"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.unit.code.$model"
                                                  :state="($v.unit.code.$dirty? !$v.unit.code.$error : null) && ($v.codeUnique.$dirty? !$v.codeUnique.$error : null)">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback" v-if="$v.unit.code.$error">
                                        Vui lòng nhập mã đơn vị
                                    </b-form-invalid-feedback>
                                    <b-form-invalid-feedback id="existingCodeFeedback" v-if="$v.codeUnique.$error">
                                        Mã đơn vị đã tồn tại
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Tên đơn vị:"
                                              label-for="name"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="text" id="name"
                                                  aria-describedby="nameFeedback"
                                                  v-model="$v.unit.name.$model"
                                                  :state="($v.unit.name.$dirty? !$v.unit.name.$error : null)">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameFeedback" v-if="$v.unit.name.$error">
                                        Vui lòng nhập tên đơn vị
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Phân loại đơn vị:"
                                              label-for="typeunit"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <div v-if="listUnitType.length > 0">
                                        <b-form-input type="text" style="display: none"
                                                      aria-describedby="unitTypeFeedback"
                                                      v-model="$v.unit.unitTypeId.$model"
                                                      :state="$v.unit.unitTypeId.$error ? false : null"></b-form-input>
                                        <select2 style="width: 100% !important;" class="col-md-9" placeholder="--- Chọn loại đơn vị ---"
                                                 id="typeunit"
                                                 aria-describedby="unitTypeFeedback"
                                                 v-model="$v.unit.unitTypeId.$model"
                                                 allowClear="true"
                                                 :state="$v.unit.unitTypeId.$dirty? !$v.unit.unitTypeId.$error : null"
                                                 v-bind:options="listUnitType" v-bind:value="$v.unit.unitTypeId.$model"></select2>
                                    </div>
                                    <b-form-invalid-feedback id="unitTypeFeedback">
                                        Vui lòng chọn loại hình đơn vị
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Cấp đơn vị:"
                                              label-for="unitLevel"
                                              :label-cols="3"
                                              label-align-md="right"
                                              label-class="required"
                                              :horizontal="true">
                                    <b-form-input type="text" style="display: none"
                                                  aria-describedby="unitLevelFeedback"
                                                  v-model="$v.unit.unitLevelId.$model"
                                                  :state="$v.unit.unitLevelId.$error ? false : null"></b-form-input>
                                    <select2 style="width: 100% !important;" class="col-md-9" placeholder="--- Chọn cấp đơn vị ---"
                                             v-if="unitLevels.length > 0"
                                             v-model="unit.unitLevelId"
                                             v-bind:options="unitLevels"
                                             allowClear="true"></select2>
                                    <b-form-invalid-feedback id="unitLevelFeedback">
                                        Vui lòng chọn cấp đơn vị
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Chế độ hoạch toán:"
                                              label-for="accountingregime"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <select2 style="width: 100% !important;" class="col-md-9" placeholder="--- Chọn hoạch toán ---"
                                             allowClear="true"
                                             v-model="unit.accountingStandard"
                                             v-bind:options="listAccountingStandard"></select2>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Địa bàn:"
                                              label-for="region"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="text" style="display: none"
                                                  aria-describedby="regionFeedback"
                                                  v-model="$v.unit.provinceId.$model"
                                                  :state="$v.unit.provinceId.$error ? false : null"></b-form-input>
                                    <select2 style="width: 100%;" v-if="listProvinces.length > 0"
                                             placeholder="--- Chọn tỉnh/thành phố ---"
                                             id="region"
                                             aria-describedby="regionFeedback"
                                             v-model="$v.unit.provinceId.$model"
                                             allowClear="true"
                                             :state="$v.unit.provinceId.$dirty? !$v.unit.provinceId.$error : null"
                                             v-bind:options="listProvinces"></select2>
                                    <div style="margin:10px 0 10px 0;">
                                        <select2 style="width:100%;" placeholder="--- Chọn quận/huyện ---"
                                                 v-model="unit.districtId"
                                                 allowClear="true"
                                                 v-bind:options="listDistricts"></select2>
                                    </div>
                                    <select2 style="width:100%" placeholder="--- Chọn xã/phường ---"
                                             v-model="unit.wardId"
                                             allowClear="true"
                                             v-bind:options="listWards"></select2>
                                    <b-form-invalid-feedback id="regionFeedback">
                                        Vui lòng chọn địa bàn
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Địa chỉ:"
                                              label-for="address"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-textarea id="textarea"
                                                     v-model="unit.address"
                                                     placeholder="Nhập địa chỉ..."
                                                     rows="5"
                                                     max-rows="5"></b-form-textarea>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Số điện thoại:"
                                              label-for="phone"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-input type="text" id="phone"
                                                  v-model="unit.phoneNumber">
                                    </b-form-input>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Fax:"
                                              label-for="fax"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-input type="text" id="fax"
                                                  v-model="unit.fax">
                                    </b-form-input>
                                </b-form-group>
                            </b-col>
                        </b-row>

                        <div class="text-center">
                            <b-button type="submit" variant="primary">Ghi lại</b-button>
                            <b-button type="button" variant="secondary" @click="cancel">Hủy</b-button>
                        </div>
                    </b-form>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>
<script>
    import { mapState, mapActions } from 'vuex'
    import { validationMixin } from 'vuelidate'
    import { authorizationMixin } from '@/shared/mixins'
    import { required, sameAs, minLength, helpers } from 'vuelidate/lib/validators'
    const passwordPattern = helpers.regex('passwordPattern', /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$/)
    import store from '@/store/index'

    export default {
        name: 'CreateUnit',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                codeUnique: 'ok',
                unit: {
                    code: null,
                    name: null,
                    address: null,
                    phoneNumber: null,
                    fax: null,
                    unitTypeId: null,
                    accountingStandard: null,
                    parentId: null,
                    parentName: null,
                    provinceId: null,
                    districtId: null,
                    wardId: null,
                    unitLevelId: null,
                },
                listAccountingStandard: [
                    { text: 'Tài sản chỉ tính hao mòn', id: 1 },
                    { text: 'Tài sản chỉ tính khấu hao', id: 2 },
                    { text: 'Cả hai', id: 3 },
                ],
                editing: false,
                listProvinces: [],
                listDistricts: [],
                listWards: [],
                listUnitType: [],
                //itemUnit: {},
            }
        },
        computed: {
            //...mapActions(['loadUnitLevel']),
            ...mapState({
                unitLevels: (state, getters) => state.common.unitLevels,
            }),


        },
        validations: {
            unit: {
                code: { required },
                name: { required },
                provinceId: { required },
                unitTypeId: { required },
                parentId: { required },
                unitLevelId: { required },
            },
            codeUnique: { required }
        },
        watch: {
            'unit.provinceId'(newVal) {
                this.loadDistricts();
            },
            'unit.districtId'(newVal) {
                this.loadWards();
            },
            'unit.wardId'(newVal) {
            },
            'unit.parentId'(newVal) {
                return this.unit.code = store.getters.getUnitById(newVal).code;
            },
            'unit.code'(newVal) {
                this.checkExitCode();
            },
        },
        created() {
            this.loadListUnitType();
            this.loadProvinces();
        },
        methods: {
            cancel() {
                this.$router.push({ path: '/master-data/units/list' });
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.post('master-data/units', this.unit).done((id) => {
                        window.UnitSelected = id;
                        vm.$toastr.s('Tạo mới đơn vị thành công');
                        store.dispatch('loadUnits').done(() => {
                            this.cancel();
                        });
                    });
                }
            },
            loadProvinces() {
                var vm = this;
                this.$services.get(`lookup/regions/${'undefined'}/${'undefined'}/list`, null).done((data) => {
                    vm.listProvinces = data;
                    vm.provinceFlag = true;
                });
            },
            loadDistricts() {
                var vm = this;
                if (this.unit.provinceId) {
                    this.$services.get(`lookup/regions/${this.unit.provinceId}/${'undefined'}/list`, null).done((data) => {
                        vm.listDistricts = data;
                        vm.districtFlag = true;
                    });
                } else {
                    this.listDistricts = [];
                }
            },
            loadWards() {
                if (this.unit.districtId) {
                    var vm = this;
                    this.$services.get(`lookup/regions/${this.unit.provinceId}/${this.unit.districtId}/list`, null).done((data) => {
                        vm.listWards = data;
                        vm.wardFlag = true;
                    });
                } else {
                    this.listWards = [];
                }
            },
            loadListUnitType() {
                var vm = this;
                this.$services.get('lookup/unit-types', null).done((data) => {
                    vm.listUnitType = data;
                });
            },
            checkExitCode() {
                if (this.unit.code != null || this.unit.code != "") {
                    var vm = this;
                    var unit = store.getters.checkExitingCode(undefined,this.unit.code);
                    if (unit) {
                        this.codeUnique = "";
                    }
                    else {
                        this.codeUnique = "required";
                    }
                }
            },
        }
    }
</script>
<style scoped>
    .mr-10 {
        margin-right: 10px;
    }

    .mt-10 {
        margin-top: 10px;
    }

    .no-mg {
        margin-left: 0px !important;
        margin-right: 0px !important;
    }
</style>
