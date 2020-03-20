<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thêm mới phân loại đơn vị</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Mã phân loại đơn vị"
                                              label-for="code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="text" id="code"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.unittype.code.$model"
                                                  :state="$v.unittype.code.$dirty? !$v.unittype.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã phân loại đơn vị
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Tên phân loại đơn vị"
                                              label-for="name"
                                              :label-cols="4"
                                              label-align-md="right"
                                              label-class="required"
                                              :horizontal="true">
                                    <b-form-input type="text" id="name"
                                                  aria-describedby="nameFeedback"
                                                  v-model="$v.unittype.name.$model"
                                                  :state="$v.unittype.name.$dirty? !$v.unittype.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameFeedback">
                                        Vui lòng nhập tên phân loại đơn vị
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button v-if="authorize(['ManageUnitType'])" type="submit" variant="primary">Ghi lại</b-button>
                                    <b-button type="button" variant="secondary" @click="cancel">Hủy</b-button>
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
    import { authorizationMixin } from '@/shared/mixins'
    import { required, sameAs, minLength, helpers } from 'vuelidate/lib/validators'

    export default {
        name: 'CreateGroupCategory',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                unittype: {
                    code: null,
                    name: null
                },
                editing: false
            }
        },
        computed: {
            unitTypeId() {
                return this.$route.params.unitTypeId;
            },
        },
        validations: {
            unittype: {
                code: { required },
                name: { required }
            }
        },
        created() {
        },
        methods: {
            cancel() {
                this.$router.push({ path: '/master-data/unit-types/list' });
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.post('master-data/unit-types', this.unittype).done((id) => {
                        vm.$toastr.s('Tạo mới phân loại đơn vị thành công');
                        vm.$router.push({ path: '/master-data/unit-types/list' });
                    });
                }
            }
        }
    }
</script>
<style scoped>
</style>
