<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thêm mới mục đích sử dụng</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="Mã mục đích sử dụng: "
                                              label-for="input-code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-class="required"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-code"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.assetUsagePurpose.code.$model"
                                                  :state="$v.assetUsagePurpose.code.$dirty? !$v.assetUsagePurpose.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="Tên mục đích sử dụng: "
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-class="required"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-name"
                                                  aria-describedby="nameFeedback"
                                                  v-model="$v.assetUsagePurpose.name.$model"
                                                  :state="$v.assetUsagePurpose.name.$dirty? !$v.assetUsagePurpose.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameFeedback">
                                        Vui lòng nhập tên
                                    </b-form-invalid-feedback>
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
                                                :branchNodesFirst="true"
                                                :defaultExpandLevel="1"
                                                :always-open="false"
                                                :append-to-body="true"
                                                :max-height="390"
                                                placeholder="Nhập tên nhóm tài sản"
                                                :options="assetTypes" />
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="7" offset="2">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="submit" variant="primary">Ghi lại</b-button>
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
    import { mapState } from 'vuex'
    import { validationMixin } from 'vuelidate'
    import { required } from 'vuelidate/lib/validators'

    export default {
        name: 'CreateAssetUsagePurpose',
        mixins: [validationMixin],
        data() {
            return {
                assetUsagePurpose: {
                    name: null,
                    code: null
                },
                editing: false
            }
        },
        computed: {
            ...mapState({
                units: (state, getters) => getters.unitTree,
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

        },
        methods: {
            cancel() {
                this.$router.push({ path: '/master-data/asset-usage-purposes/list' });
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.post('master-data/asset-usage-purposes', this.assetUsagePurpose).done((id) => {
                        vm.$toastr.s('Tạo mới mục đích sử dụng thành công');
                        vm.$router.push({ path: '/master-data/asset-usage-purposes/list' });
                    });
                }
            }
        }
    }
</script>
<style scoped>
</style>
