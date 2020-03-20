<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thông tin mục đích sử dụng</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="Mã mục đích sử dụng: "
                                              label-for="input-code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              :label-class="editing? 'required' : ''"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-code"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.assetUsagePurpose.code.$model"
                                                  v-if="editing"
                                                  :state="$v.assetUsagePurpose.code.$dirty? !$v.assetUsagePurpose.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ assetUsagePurpose.code }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="Tên mục đích sử dụng: "
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              :label-class="editing? 'required' : ''"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-name"
                                                  aria-describedby="nameFeedback"
                                                  v-model="$v.assetUsagePurpose.name.$model"
                                                  v-if="editing"
                                                  :state="$v.assetUsagePurpose.name.$dirty? !$v.assetUsagePurpose.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameFeedback">
                                        Vui lòng nhập tên
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ assetUsagePurpose.name }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="Áp dụng: "
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <treeselect v-model="assetUsagePurpose.assetTypeId"
                                                v-if="editing"
                                                :branchNodesFirst="true"
                                                :defaultExpandLevel="1"
                                                :always-open="false"
                                                :append-to-body="true"
                                                :max-height="390"
                                                placeholder="Nhập tên nhóm tài sản"
                                                :options="assetTypes" />
                                    <label class="col-form-label" v-if="!editing">{{ assetUsagePurpose.assetTypeName }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="" :label-cols="4">
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
        name: 'AssetUsagePurposeDetail',
        mixins: [validationMixin],
        data() {
            return {
                assetUsagePurpose: {},
                editing: false
            }
        },
        computed: {
            assetUsagePurposeId() {
                return this.$route.params.assetUsagePurposeId;
            },
            ...mapState({
                units: (state, getters) => getters.unitTree,
                privileges: (state, getters) => state.identity.privileges,
                assetTypes: (state, getters) => getters.assetTypeTree
            })
        },
        validations: {
            assetUsagePurpose: {
                code: { required },
                name: { required }
            }
        },
        created() {
            this.loadAssetUsagePurposeDetail();
        },
        methods: {
            authorize(requiredPrivileges) {
                return intersect(this.privileges, requiredPrivileges).length > 0;
            },
            loadAssetUsagePurposeDetail() {
                var vm = this;
                return this.$services.get(`master-data/asset-usage-purposes/${this.assetUsagePurposeId}`).done(assetUsagePurpose => {
                    vm.assetUsagePurpose = assetUsagePurpose;
                });
            },
            edit() {
                this.editing = true;
            },
            back() {
                this.$router.push({ path: '/master-data/asset-usage-purposes' });
            },
            cancel() {
                var vm = this;
                this.loadAssetUsagePurposeDetail().done(() => vm.editing = false);
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.put(`master-data/asset-usage-purposes/${this.assetUsagePurposeId}`, this.assetUsagePurpose).done(() => {
                        vm.$toastr.s('Cập nhật mục đích sử dụng thành công');
                        vm.cancel();
                    });
                }
            }
        }
    }
</script>
<style scoped>
</style>
