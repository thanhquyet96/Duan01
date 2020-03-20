<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thêm mới quốc gia</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Mã quốc gia:"
                                              label-for="code"
                                              :label-cols="4"
                                              label-align-md="right"
                                              :horizontal="true"
                                              label-class="required">
                                    <b-form-input type="text" id="code"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.country.code.$model"
                                                  :state="$v.country.code.$dirty? !$v.country.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã quốc gia
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Tên quốc gia:"
                                              label-for="name"
                                              :label-cols="4"
                                              label-align-md="right"
                                              :horizontal="true"
                                              label-class="required">
                                    <b-form-input type="text" id="name"
                                                  aria-describedby="namecountryFeedback"
                                                  v-model="$v.country.name.$model"
                                                  :state="$v.country.name.$dirty? !$v.country.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="namecountryFeedback">
                                        Vui lòng nhập tên quốc gia
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Mô tả:"
                                              label-for="name"
                                              :label-cols="4"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-textarea placeholder="Nhập mô tả..."
                                                     v-model="$v.country.description.$model">
                                    </b-form-textarea>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="submit" v-if="authorize(['ManageCountry'])" variant="primary"><i class="fa fa-floppy-o"></i> Ghi lại</b-button>
                                    <b-button type="button" variant="secondary" @click="cancel"><i class="fa fa-ban"></i> Hủy</b-button>
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
    import { setTimeout } from 'core-js'
    const passwordPattern = helpers.regex('passwordPattern', /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$/)

    export default {
        name: 'CreateCountry',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                country: {
                    code: null,
                    name: null,
                    description: null,
                },
                editing: false
            }
        },
        computed: {
        },
        validations: {
            country: {
                code: { required },
                name: { required },
                description: {}
            }
        },
        created() {
        },
        methods: {
            cancel() {
                this.$router.push({ path: '/master-data/countries/list' });
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.post('master-data/countries', this.country).done((id) => {
                        vm.$toastr.s('Tạo mới quốc gia thành công');
                        vm.$router.push({ path: '/master-data/countries/list' });
                    });
                }
            },
        }
    }
</script>
<style scoped>
</style>
