<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thêm mới tài khoản đơn vị đồng bộ dữ liệu</strong>
                    </div>
                    <b-form @submit.prevent="save" v-if="authorize(['ManageSyncUser'])">
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Trực thuộc:"
                                              label-for="unit"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="text" style="display: none"
                                                  aria-describedby="unitFeedback"
                                                  v-model="$v.syncUser.unitId.$model"
                                                  :state="$v.syncUser.unitId.$error ? false : null"></b-form-input>
                                    <unit-tree v-model="$v.syncUser.unitId.$model" ref="unitTree"
                                               aria-describedby="unitFeedback"
                                               :state="$v.syncUser.unitId.$dirty? !$v.syncUser.unitId.$error : null"></unit-tree>
                                    <b-form-invalid-feedback id="unitFeedback">
                                        Vui lòng chọn đơn vị
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Tên tài khoản:"
                                              label-for="userName"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="text" id="userName"
                                                  aria-describedby="userNameFeedback"
                                                  v-model="$v.syncUser.userName.$model"
                                                  :state="$v.syncUser.userName.$dirty? !$v.syncUser.userName.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="userNameFeedback">
                                        Vui lòng nhập tên tài khoản
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <!--<b-col md="6">
                                <b-form-group label="Số điện thoại"
                                              label-for="phoneNumber"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="">
                                    <b-form-input type="tel" id="fullName" maxlength="20"
                                                  v-model="syncUser.phoneNumber">
                                    </b-form-input>
                                </b-form-group>
                            </b-col>-->
                            <!--<b-col md="6">
                                <b-form-group label="Tên người dùng"
                                              label-for="userName"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-class="required">
                                    <b-form-input type="text" id="code"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.syncUser.userName.$model"
                                                  :state="$v.syncUser.userName.$dirty? !$v.syncUser.userName.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập tên người dùng
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>-->
                            <!--<b-col md="6">
                                <b-form-group label="Email"
                                              label-for="email"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-input type="text" id="email"
                                                  v-model="syncUser.email">
                                    </b-form-input>
                                </b-form-group>
                            </b-col>-->
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Mật khẩu:"
                                              label-for="password"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="password" id="password"
                                                  aria-describedby="passwordFeedback"
                                                  v-model="$v.syncUser.passwordHash.$model"
                                                  @input="$v.syncUser.passwordHash.$touch"
                                                  :state="$v.syncUser.passwordHash.$dirty? !$v.syncUser.passwordHash.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback v-if="!$v.syncUser.passwordHash.required">
                                        Vùi lòng nhập mật khẩu
                                    </b-form-invalid-feedback>
                                    <b-form-invalid-feedback v-if="!$v.syncUser.passwordHash.minLength">
                                        Mật khẩu phải có ít nhất 8 ký tự
                                    </b-form-invalid-feedback>
                                    <b-form-invalid-feedback v-if="$v.syncUser.passwordHash.minLength && !$v.syncUser.passwordHash.passwordPattern">
                                        Mật khẩu phải chứa chữ hoa, chữ thường, số và ký tự đặc biệt
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nhập lại mật khẩu:"
                                              label-for="passwordConfirmation"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="password" id="passwordConfirmation"
                                                  aria-describedby="passwordConfirmationFeedback"
                                                  v-model="$v.syncUser.passwordConfirmation.$model"
                                                  @input="$v.syncUser.passwordConfirmation.$touch"
                                                  :state="$v.syncUser.passwordConfirmation.$dirty? !$v.syncUser.passwordConfirmation.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback v-if="!$v.syncUser.passwordConfirmation.required">
                                        Vui lòng nhập lại mật khẩu
                                    </b-form-invalid-feedback>
                                    <b-form-invalid-feedback v-if="$v.syncUser.passwordConfirmation.required && !$v.syncUser.passwordConfirmation.sameAsPassword">
                                        Mật khẩu không khớp
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>

                            <b-col md="6">
                                <b-form-group label="Đang hoạt động:"
                                              id="status"
                                              label-for="isActive"
                                              :label-cols="3"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-checkbox id="isActive"
                                                     class="mgt-10"
                                                     v-model="syncUser.isActive">
                                        <!--Trạng thái-->
                                    </b-form-checkbox>
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
    import { mapState } from 'vuex'
    import { validationMixin } from 'vuelidate'
    import { authorizationMixin } from '@/shared/mixins'
    import { required, sameAs, minLength, helpers } from 'vuelidate/lib/validators'
    const passwordPattern = helpers.regex('passwordPattern', /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$/)

    export default {
        name: 'CreateCountry',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                syncUser: {
                    userName: null,
                    name: null,
                    passwordHash: null,
                    unitId: null,
                    passwordConfirmation: null,
                    phoneNumber: null,
                    isActive: false
                },
                editing: false
            }
        },
        computed: {
            ...mapState({
                units: (state, getters) => getters.unitTree,
                privileges: (state, getters) => state.identity.privileges
            })
        },
        validations: {
            syncUser: {
                userName: { required },
                unitId: { required },
                passwordHash: { required, minLength: minLength(8), passwordPattern },
                passwordConfirmation: { required, sameAsPassword: sameAs('passwordHash') },
            }
        },
        created() {
        },
        methods: {
            cancel() {
                this.$router.push({ path: '/system/sync-users/list' });
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.post('sync-users', this.syncUser).done((id) => {
                        vm.$toastr.s('Tạo mới tài khoản thành công');
                        vm.$router.push({ path: '/system/sync-users/list' });
                    });
                }
            },
        }
    }
</script>
<style scoped>
    .mgt-10 {
        margin-top: 8px;
    }
</style>
