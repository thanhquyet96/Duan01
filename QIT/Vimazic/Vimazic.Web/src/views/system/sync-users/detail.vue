<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thông tin tài khoản đơn vị đồng bộ dữ liệu</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Trực thuộc:"
                                              label-for="unit"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <label class="col-form-label">{{ syncuser.unitName }}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Tên tài khoản:"
                                              label-for="userName"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              :label-class="editing? 'required' : ''">
                                    <!--<b-form-input type="text" id="userName" v-if="editing"
                                                  aria-describedby="userNameFeedback"
                                                  v-model="$v.syncuser.userName.$model"
                                                  :state="$v.syncuser.userName.$dirty? !$v.syncuser.userName.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="userNameFeedback">
                                        Vui lòng nhập tên đăng nhập
                                    </b-form-invalid-feedback>-->
                                    <label class="col-form-label">{{ syncuser.userName }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <!--<b-col md="6">
                                <b-form-group label="Tên người dùng:"
                                              label-for="userName"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              :label-class="editing? 'required' : ''">
                                    <b-form-input type="text" id="code" v-if="editing"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.syncuser.userName.$model"
                                                  :state="$v.syncuser.userName.$dirty? !$v.syncuser.userName.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập tên người dùng
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ syncuser.userName }}</label>

                                </b-form-group>
                            </b-col>-->
                            <!--<b-col md="6">
                                <b-form-group label="Email:"
                                              label-for="email"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-input type="text" id="email" v-if="editing"
                                                  v-model="syncuser.email">
                                    </b-form-input>
                                    <label class="col-form-label" v-if="!editing">{{ syncuser.email }}</label>

                                </b-form-group>
                            </b-col>-->
                        </b-row>
                        <b-row v-if="editing && isAdmin">
                            <b-col md="6">
                                <b-form-group label="Mật khẩu mới:"
                                              label-for="password"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-input type="password" id="password"
                                                  aria-describedby="passwordFeedback"
                                                  v-model="$v.syncuser.newPassword.$model"
                                                  @input="$v.syncuser.newPassword.$touch"
                                                  :state="$v.syncuser.newPassword.$dirty? !$v.syncuser.newPassword.$error : null">
                                    </b-form-input>
                                    <!--<b-form-invalid-feedback v-if="!$v.syncuser.passwordHash.required">
                                        Vùi lòng nhập mật khẩu
                                    </b-form-invalid-feedback>-->
                                    <b-form-invalid-feedback v-if="!$v.syncuser.newPassword.minLength">
                                        Mật khẩu phải có ít nhất 8 ký tự
                                    </b-form-invalid-feedback>
                                    <b-form-invalid-feedback v-if="$v.syncuser.newPassword.minLength && !$v.syncuser.newPassword.passwordPattern">
                                        Mật khẩu phải chứa chữ hoa, chữ thường, số và ký tự đặc biệt
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">********</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nhập lại mật khẩu:"
                                              label-for="passwordConfirmation"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="password" id="passwordConfirmation" v-if="editing"
                                                  aria-describedby="passwordConfirmationFeedback"
                                                  v-model="$v.syncuser.passwordConfirmation.$model"
                                                  @input="$v.syncuser.passwordConfirmation.$touch"
                                                  :state="$v.syncuser.passwordConfirmation.$dirty? !$v.syncuser.passwordConfirmation.$error : null">
                                    </b-form-input>
                                    <!--<b-form-invalid-feedback v-if="!$v.syncuser.passwordConfirmation.required">
                                        Vui lòng nhập lại mật khẩu
                                    </b-form-invalid-feedback>-->
                                    <b-form-invalid-feedback v-if="!$v.syncuser.passwordConfirmation.sameAsPassword">
                                        Mật khẩu không khớp
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <!--<b-col md="6">
                                <b-form-group label="Số điện thoại:"
                                              label-for="phoneNumber"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="">
                                    <b-form-input type="tel" id="fullName" maxlength="20" v-if="editing"
                                                  v-model="syncuser.phoneNumber">
                                    </b-form-input>
                                    <label class="col-form-label" v-if="!editing">{{ syncuser.phoneNumber }}</label>

                                </b-form-group>
                            </b-col>-->
                            <b-col md="6">
                                <b-form-group label="Đang hoạt động:" inline
                                              id="status"
                                              label-for="isActive"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-checkbox id="isActive" v-if="editing" style="margin-top:5px;"
                                                     v-model="syncuser.isActive">
                                    </b-form-checkbox>
                                    <label class="col-form-label" v-if="!editing">{{ syncuser.isActive ? "Có" :"Không" }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <div class="text-center">
                            <b-button type="button" variant="primary" @click="edit" v-if="!editing && authorize(['ManageSyncUser'])">Sửa</b-button>
                            <b-button type="button" variant="secondary" @click="back" v-if="!editing">Quay lại</b-button>
                            <b-button type="submit" variant="primary" v-if="editing">Ghi lại</b-button>
                            <b-button type="button" variant="secondary" @click="cancel" v-if="editing">Hủy</b-button>
                        </div>
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
    const passwordPattern = helpers.regex('passwordPattern', /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$/)

    export default {
        name: 'SyncUserDetail',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                syncuser: {},
                editing: false
            }
        },
        computed: {
            syncuserId() {
                return this.$route.params.syncuserId;
            },
            ...mapState({
                units: (state, getters) => getters.unitTree,
                isAdmin:(state, getters) => state.identity.username === 'admin'
            })
        },
        validations: {
            syncuser: {
                //unitId: { required },
                newPassword: { minLength: minLength(8), passwordPattern },
                passwordConfirmation: { sameAsPassword: sameAs('newPassword') },
            }
        },
        created() {
            this.loadSyncUserDetail();
        },
        methods: {
            loadSyncUserDetail() {
                var vm = this;
                return this.$services.get(`sync-users/${this.syncuserId}`).done(syncuser => {
                    vm.syncuser = syncuser;
                });
            },
            edit() {
                this.editing = true;
            },
            back() {
                this.$router.push({ path: '/system/sync-users' });
            },
            cancel() {
                var vm = this;
                this.loadSyncUserDetail().done(() => vm.editing = false);
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.put(`sync-users/${this.syncuserId}`, this.syncuser).done(() => {
                        vm.$toastr.s('Cập nhật tài khoản thành công');
                        vm.cancel();
                    });
                }
            },
        }
    }
</script>
<style scoped>
</style>
