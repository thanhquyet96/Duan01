<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thông tin phân loại đơn vị</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Mã phân loại đơn vị:"
                                              label-for="code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              :label-class="editing? 'required' : ''">
                                    <b-form-input type="text" id="code" v-if="editing"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.unitType.code.$model"
                                                  :state="$v.unitType.code.$dirty? !$v.unitType.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã phân loại đơn vị
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ unitType.code }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Tên phân loại đơn vị:"
                                              label-for="name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              :label-class="editing? 'required' : ''">
                                    <b-form-input type="text" id="name" v-if="editing"
                                                  aria-describedby="nameFeedback"
                                                  v-model="$v.unitType.name.$model"
                                                  :state="$v.unitType.name.$dirty? !$v.unitType.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameFeedback">
                                        Vui lòng nhập tên phân loại đơn vị
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ unitType.name }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="primary" @click="edit" v-if="!editing && authorize(['ManageUnitType'])">Sửa</b-button>
                                    <b-button type="button" variant="secondary" @click="back" v-if="!editing">Quay lại</b-button>
                                    <b-button type="submit" variant="primary" v-if="editing">Ghi lại</b-button>
                                    <b-button type="button" variant="secondary" @click="cancel" v-if="editing">Hủy</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-form>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>
<script>
    import { mapState } from 'vuex'
    import { validationMixin } from 'vuelidate'
    import { required } from 'vuelidate/lib/validators'
    import { authorizationMixin } from '@/shared/mixins'

    export default {
        name: 'UnitTypeDetail',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                unitType: {},
                editing: false
            }
        },
        computed: {
            unitTypeId() {
                return this.$route.params.unitTypeId;
            },
        },
        validations: {
            unitType: {
                code: { required },
                name: { required }
            }
        },
        created() {
            this.loadUnitTypeDetail();
        },
        methods: {
            loadUnitTypeDetail() {
                var vm = this;
                return this.$services.get(`master-data/unit-types/${this.unitTypeId}`).done(unitType => {
                    vm.unitType = unitType;
                });
            },
            edit() {
                this.editing = true;
            },
            back() {
                this.$router.push({ path: '/master-data/unit-types' });
            },
            cancel() {
                var vm = this;
                this.loadUnitTypeDetail().done(() => vm.editing = false);
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.put(`master-data/unit-types/${this.unitTypeId}`, this.unitType).done(() => {
                        vm.$toastr.s('Cập nhật loại đơn vị thành công');
                        vm.cancel();
                    });
                }
            }
        }
    }
</script>
<style scoped>
</style>
