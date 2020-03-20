<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thêm mới nhóm tài khoản đồng bộ dữ liệu</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="8" offset="2">
                                <b-form-group label="Trực thuộc:"
                                              :label-cols="4"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <unit-tree v-model="syncRole.unitId" ref="unitTree"></unit-tree>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="8" offset="2">
                                <b-form-group label="Tên nhóm tài khoản đồng bộ dữ liệu:"
                                              label-for="name"
                                              label-align-md="right"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-class="required">
                                    <b-form-input type="text" id="name"
                                                  v-model="$v.syncRole.name.$model"
                                                  :state="$v.syncRole.name.$dirty? !$v.syncRole.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback>
                                        Vui lòng nhập tên nhóm tài khoản đồng bộ dữ liệu
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="8" offset="2">
                                <b-form-group label="Mô tả:"
                                              label-for="description"
                                              :label-cols="4"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-textarea id="description" v-model="syncRole.description"></b-form-textarea>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="8" offset="2">
                                <b-form-group :label-cols="4"
                                              :horizontal="true">
                                    <b-button v-if="authorize(['ManageSyncRole'])" type="submit" variant="primary">Ghi lại</b-button>
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
    import { validationMixin } from 'vuelidate'
    import { authorizationMixin } from '@/shared/mixins'
    import { required } from 'vuelidate/lib/validators'

    export default {
        name: 'CreateSyncRole',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                syncRole: {
                    name: null,
                    description: null,
                    unitId:null
                }
            }
        },
        validations: {
            syncRole: {
                name: { required }
            }
        },
        created() {

        },
        methods: {
            cancel() {
                this.$router.push({ path: '/system/sync-roles/list' });
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.post('sync-roles', this.syncRole).done((id) => {
                        vm.$toastr.s('Tạo mới nhóm tài khoản đồng bộ thành công');
                        vm.$router.push({ path: '/system/sync-roles/list' });
                    });
                }
            }
        }
    }
</script>
<style scoped>
</style>
