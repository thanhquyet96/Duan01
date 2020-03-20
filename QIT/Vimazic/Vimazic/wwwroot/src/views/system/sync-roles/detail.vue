<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thông tin nhóm tài khoản đồng bộ dữ liệu</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="8" offset="2">
                                <b-form-group label="Trực thuộc:"
                                              :label-cols="4"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <unit-tree v-model="syncRole.unitId" ref="unitTree" v-if="editing"></unit-tree>
                                    <label class="col-form-label" v-if="!editing">{{ syncRole.unitName }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="8" offset="2">
                                <b-form-group label="Tên nhóm tài khoản đồng bộ dữ liệu:"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              :label-class="editing? 'required' : ''">
                                    <b-form-input type="text" id="name" v-if="editing"
                                                  v-model="$v.syncRole.name.$model"
                                                  :state="$v.syncRole.name.$dirty? !$v.syncRole.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback>
                                        Vui lòng nhập tên nhóm tài khoản đồng bộ dữ liệu
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ syncRole.name }}</label>
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
                                    <b-form-textarea id="description" v-model="syncRole.description" v-if="editing"></b-form-textarea>
                                    <label class="col-form-label" v-if="!editing">{{ syncRole.description }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="8" offset="2">
                                <b-form-group :label-cols="4">
                                    <b-button type="button" variant="primary" @click="edit" v-if="!editing && authorize(['ManageSyncRole'])">Sửa</b-button>
                                    <b-button type="button" variant="secondary" @click="back" v-if="!editing">Quay lại</b-button>
                                    <b-button type="submit" variant="primary" v-if="editing"> Ghi lại</b-button>
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
    import { validationMixin } from 'vuelidate'
    import { authorizationMixin } from '@/shared/mixins'
    import { required } from 'vuelidate/lib/validators'

    export default {
        name: 'SyncRoleDetail',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                syncRole: {
                },
                editing: false
            }
        },
        computed: {
            syncRoleId() {
                return this.$route.params.syncRoleId;
            },
        },
        validations: {
            syncRole: {
                name: { required }
            }
        },
        created() {
            this.loadSyncRoleDetail();
        },
        methods: {
            loadSyncRoleDetail() {
                var vm = this;
                return this.$services.get(`sync-roles/${this.syncRoleId}`).done(syncRole => {
                    vm.syncRole = syncRole;
                });
            },
            edit() {
                this.editing = true;
            },
            back() {
                this.$router.push({ path: '/system/sync-roles' });
            },
            cancel() {
                var vm = this;
                this.loadSyncRoleDetail().done(() => vm.editing = false);
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.put(`sync-roles/${this.syncRoleId}`, this.syncRole).done(() => {
                        vm.$toastr.s('Cập nhật nhóm tài khoản đồng bộ dữ liệu thành công');
                        vm.cancel();
                    });
                }
            }
        }
    }
</script>
<style scoped>
</style>
