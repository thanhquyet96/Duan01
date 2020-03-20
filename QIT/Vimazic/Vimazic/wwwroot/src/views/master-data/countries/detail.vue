<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thông tin quốc gia</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Mã quốc gia:"
                                              label-for="codeCountry"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              :label-class="editing? 'required' : ''">
                                    <b-form-input type="text" id="codeCountry"
                                                  v-if="editing"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.country.code.$model"
                                                  :state="$v.country.code.$dirty? !$v.country.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã quốc gia
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ country.code }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Tên quốc gia:"
                                              label-for="name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              :label-class="editing? 'required' : ''">
                                    <b-form-input type="text" id="name"
                                                  v-if="editing"
                                                  aria-describedby="nameCountryFeedback"
                                                  v-model="$v.country.name.$model"
                                                  :state="$v.country.name.$dirty? !$v.country.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameCountryFeedback">
                                        Vui lòng nhập tên quốc gia
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ country.name }}</label>
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
                                    <b-form-textarea v-if="editing"
                                                     placeholder="Nhập mô tả..."
                                                     v-model="$v.country.description.$model">
                                    </b-form-textarea>
                                    <label class="col-form-label" v-if="!editing">{{ country.description }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="primary" @click="edit" v-if="!editing && authorize(['ManageCountry'])">Sửa</b-button>
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
        name: 'CountryDetail',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                country: {},
                editing: false
            }
        },
        computed: {
            countryId() {
                return this.$route.params.countryId;
            },
        },
        validations: {
            country: {
                code: { required },
                name: { required },
                description: {}
            }
        },
        created() {
            this.loadCountryDetail();
        },
        methods: {
            loadCountryDetail() {
                var vm = this;
                return this.$services.get(`master-data/countries/${this.countryId}`).done(country => {
                    vm.country = country;
                });
            },
            edit() {
                this.editing = true;
            },
            back() {
                this.$router.push({ path: '/master-data/countries' });
            },
            cancel() {
                var vm = this;
                this.loadCountryDetail().done(() => vm.editing = false);
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.put(`master-data/countries/${this.countryId}`, this.country).done(() => {
                        vm.$toastr.s('Cập nhật quốc gia thành công');
                        vm.cancel();
                    });
                }
            },
        }
    }
</script>
<style scoped>
</style>
