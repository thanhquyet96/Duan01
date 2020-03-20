<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thông tin nguồn hình thành tài sản</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="Mã nguồn hình thành tài sản: "
                                              label-for="input-code"
                                              :label-cols="5"
                                              :horizontal="true"
                                              :label-class="editing? 'required' : ''"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-code"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.assetSource.code.$model"
                                                  v-if="editing"
                                                  :state="$v.assetSource.code.$dirty? !$v.assetSource.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ assetSource.code }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="Tên nguồn hình thành tài sản: "
                                              label-for="input-name"
                                              :label-cols="5"
                                              :horizontal="true"
                                              :label-class="editing? 'required' : ''"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-name"
                                                  aria-describedby="nameFeedback"
                                                  v-model="$v.assetSource.name.$model"
                                                  v-if="editing"
                                                  :state="$v.assetSource.name.$dirty? !$v.assetSource.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameFeedback">
                                        Vui lòng nhập tên
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ assetSource.name }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="" :label-cols="5">
                                    <b-button type="button" variant="primary" @click="edit" v-if="!editing">Sửa</b-button>
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

    export default {
        name: 'AssetSourceDetail',
        mixins: [validationMixin],
        data() {
            return {
                assetSource: {},
                editing: false
            }
        },
        computed: {
            assetSourceId() {
                return this.$route.params.assetSourceId;
            },
            ...mapState({
                units: (state, getters) => getters.unitTree,
                privileges: (state, getters) => state.identity.privileges
            })
        },
        validations: {
            assetSource: {
                code: { required },
                name: { required }
            }
        },
        created() {
            this.loadIncreasementCauseDetail();
        },
        methods: {
            authorize(requiredPrivileges) {
                return intersect(this.privileges, requiredPrivileges).length > 0;
            },
            loadIncreasementCauseDetail() {
                var vm = this;
                return this.$services.get(`master-data/asset-sources/${this.assetSourceId}`).done(assetSource => {
                    vm.assetSource = assetSource;
                });
            },
            edit() {
                this.editing = true;
            },
            back() {
                this.$router.push({ path: '/master-data/asset-sources' });
            },
            cancel() {
                var vm = this;
                this.loadIncreasementCauseDetail().done(() => vm.editing = false);
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.put(`master-data/asset-sources/${this.assetSourceId}`, this.assetSource).done(() => {
                        vm.$toastr.s('Cập nhật nguồn hình thành tài sản thành công');
                        vm.cancel();
                    });
                }
            }
        }
    }
</script>
<style scoped>
</style>
