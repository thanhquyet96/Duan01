<template>
    <div class="app flex-row align-items-center">
        <div class="container">
            <b-row class="justify-content-center">
                <b-col md="8">
                    <b-card-group>
                        <b-card no-body class="p-4">
                            <b-card-body>
                                <b-form @submit.prevent="login">
                                    <h1>Login</h1>
                                    <p class="text-muted">Sign In to your account</p>
                                    <b-input-group class="mb-3">
                                        <b-input-group-prepend><b-input-group-text><i class="icon-user"></i></b-input-group-text></b-input-group-prepend>
                                        <b-form-input type="text" class="form-control" placeholder="Username" v-model="$v.username.$model" :state="$v.username.$dirty ? !$v.username.$error : null"></b-form-input>
                                        <b-form-invalid-feedback>
                                           Please enter username
                                        </b-form-invalid-feedback>
                                    </b-input-group>
                                    <b-input-group class="mb-4">
                                        <b-input-group-prepend><b-input-group-text><i class="icon-lock"></i></b-input-group-text></b-input-group-prepend>
                                        <b-form-input type="password" class="form-control" placeholder="Password" v-model="$v.password.$model" :state="$v.password.$dirty ? !$v.password.$error : null"></b-form-input>
                                        <b-form-invalid-feedback>
                                            Please enter password
                                        </b-form-invalid-feedback>
                                        <b-form-invalid-feedback v-if="errorMsg" style="display: block">
                                            {{errorMsg}}
                                        </b-form-invalid-feedback>
                                    </b-input-group>
                                    <b-row>
                                        <b-col cols="6">
                                            <b-button variant="primary" class="px-4" type="submit">Login</b-button>
                                        </b-col>
                                        <b-col cols="6" class="text-right">
                                            <b-button variant="link" class="px-0">Forgot password?</b-button>
                                        </b-col>
                                    </b-row>
                                </b-form>
                            </b-card-body>
                        </b-card>
                        <b-card no-body class="text-white bg-primary py-5 d-md-down-none" style="width:44%">
                            <b-card-body class="text-center">
                                <div>
                                    <h2>Sign up</h2>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                                    <b-button variant="primary" class="active mt-3" :to="{ path: '/register' }">Register Now!</b-button>
                                </div>
                            </b-card-body>
                        </b-card>
                    </b-card-group>
                </b-col>
            </b-row>
        </div>
    </div>
</template>
<script>
    import { validationMixin } from 'vuelidate'
    import { required } from 'vuelidate/lib/validators'

    export default {
        name: 'Login',
        mixins: [validationMixin],
        data() {
            return {
                username: null,
                password: null,
                errorMsg: null,
            };
        },
        validations: {
            username: {
                required
            },
            password: {
                required,
            }
        },
        methods: {
            login() {
                var vm = this;
                this.errorMsg = null;
                this.$store.dispatch("authenticate", { username: this.username, password: this.password })
                    .done(() => vm.$router.push({ path: '/' }))
                    .fail(
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
