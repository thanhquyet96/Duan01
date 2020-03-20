<template>
    <div class="app flex-row align-items-center">
        <div class="container">
            <b-row class="justify-content-center">
                <b-col md="6" sm="8">
                    <b-card no-body class="mx-4">
                        <b-card-body class="p-4">
                            <h1>Register</h1>
                            <!--<p class="text-muted">Create your account</p>-->
                            <b-input-group class="mb-3">
                                <b-input-group-prepend>
                                    <b-input-group-text>@</b-input-group-text>
                                </b-input-group-prepend>
                                <b-form-input type="text"
                                              class="form-control"
                                              placeholder="Email"
                                              v-model="$v.form.Email.$model"
                                              :state="$v.form.Email.$dirty ? !$v.form.Email.$error : null"></b-form-input>
                                <b-form-invalid-feedback>
                                    Email is required
                                </b-form-invalid-feedback>
                            </b-input-group>
                            <b-input-group class="mb-3">
                                <b-input-group-prepend>
                                    <b-input-group-text><i class="icon-lock"></i></b-input-group-text>
                                </b-input-group-prepend>
                                <b-form-input type="password"
                                              class="form-control"
                                              placeholder="Password"
                                              v-model="$v.form.Password.$model"
                                              :state="$v.form.Password.$dirty ? !$v.form.Password.$error : null"></b-form-input>
                                <b-form-invalid-feedback v-if="!$v.form.Password.required">
                                    Password is required
                                </b-form-invalid-feedback>
                                <b-form-invalid-feedback v-if="!$v.form.Password.minLength">
                                    Password must be at least 6 characters
                                </b-form-invalid-feedback>
                                <b-form-invalid-feedback v-if="$v.form.Password.minLength && !$v.form.Password.passwordPattern">
                                    Password must contains Uppercase, Lowercase, Number and Speacial Characters
                                </b-form-invalid-feedback>
                            </b-input-group>
                            <b-input-group class="mb-4">
                                <b-input-group-prepend>
                                    <b-input-group-text><i class="icon-lock"></i></b-input-group-text>
                                </b-input-group-prepend>
                                <b-form-input type="password"
                                              class="form-control"
                                              placeholder="Repeat password"
                                              v-model="$v.form.ConfirmPassword.$model"
                                              :state="$v.form.ConfirmPassword.$dirty ? !$v.form.ConfirmPassword.$error : null"></b-form-input>
                                <b-form-invalid-feedback v-if="!$v.form.ConfirmPassword.required">
                                    Please retype password
                                </b-form-invalid-feedback>
                                <b-form-invalid-feedback v-if="$v.form.ConfirmPassword.required && !$v.form.ConfirmPassword.sameAsPassword">
                                    Password confirmation does not match Password
                                </b-form-invalid-feedback>
                                <b-form-invalid-feedback v-if="errorMsg" style="display: block">
                                    {{errorMsg}}
                                </b-form-invalid-feedback>
                            </b-input-group>
                            <b-button variant="success" block @click="register" :disabled="$v.form.invalid">Register</b-button>
                        </b-card-body>
                        <!--<b-card-footer class="p-4">
                            <b-row>
                                <b-col cols="6">
                                    <b-button block class="btn btn-facebook"><span>facebook</span></b-button>
                                </b-col>
                                <b-col cols="6">
                                    <b-button block class="btn btn-twitter" type="button"><span>twitter</span></b-button>
                                </b-col>
                            </b-row>
                        </b-card-footer>-->
                    </b-card>
                </b-col>
            </b-row>
        </div>
    </div>
</template>
<script>
    import { validationMixin } from 'vuelidate'
    import { required, sameAs, minLength, helpers } from 'vuelidate/lib/validators'
    const passwordPattern = helpers.regex('passwordPattern', /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$/)

    export default {
        name: 'Registration',
        mixins: [validationMixin],
        data() {
            return {
                form: {
                    Email: '',
                    Password: '',
                    ConfirmPassword: ''
                },
                errorMsg: null
            }
        },
        validations: {
            form: {
                Email: {
                    required
                },
                Password: {
                    required,
                    minLength: minLength(6),
                    //passwordPattern
                },
                ConfirmPassword: {
                    required,
                    sameAsPassword: sameAs('Password')
                }
            }
        },
        methods: {
            register() {
                var vm = this;
                this.$services.post('/Account/Register', vm.form)
                    .done(call => {
                        vm.$toastr.s('Register successfully.');
                        vm.$router.push({ path: '/login' });
                    }).fail(
                        function (errors) {
                            if (errors.responseJSON && errors.responseJSON.error_description) {
                                vm.errorMsg = errors.responseJSON.error_description;
                            } else {
                                vm.errorMsg = errors.statusText;
                            }
                        }
                    );
            }
        }
    }
</script>
