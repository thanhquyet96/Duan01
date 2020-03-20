<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thêm mới nhóm tài sản</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Tên nhóm tài sản cha:"
                                              label-for="input-parentname"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <treeselect id="input-parentname"
                                                ref="assetTypeTree"
                                                v-model="assetType.parentId"
                                                :branchNodesFirst="true"
                                                :defaultExpandLevel="1"
                                                :always-open="false"
                                                :append-to-body="true"
                                                :max-height="390"
                                                placeholder="Nhập tên nhóm tài sản"
                                                :options="assetTypes" />
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Mã nhóm tài sản:"
                                              label-for="input-code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-class="required"
                                              label-align-md="right">
                                    <b-form-input type="text"
                                                  aria-describedby="codeFeedback"
                                                  id="input-code"
                                                  v-model="$v.assetType.code.$model"
                                                  :state="$v.assetType.code.$dirty? !$v.assetType.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Tên nhóm tài sản:"
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-class="required"
                                              label-align-md="right">
                                    <b-form-input type="text"
                                                  aria-describedby="nameFeedback"
                                                  id="input-name"
                                                  v-model="$v.assetType.name.$model"
                                                  :state="$v.assetType.name.$dirty? !$v.assetType.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameFeedback">
                                        Vui lòng nhập tên
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Mô tả:"
                                              label-for="textarea-description"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-textarea id="textarea-description"
                                                     v-model="assetType.description"
                                                     placeholder="Nhập mô tả..."
                                                     rows="1"
                                                     max-rows="6">
                                    </b-form-textarea>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Ngày bắt đầu:"
                                              label-for="input-startdate"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="date" style="display: none"
                                                  id="input-startdate"
                                                  v-model="assetType.startDate">
                                    </b-form-input>
                                    <date-picker v-model="assetType.startDate" style="width: 300px"></date-picker>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Ngày kết thúc:"
                                              label-for="input-enddate"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <b-form-input type="date" style="display: none"
                                                  id="input-enddate"
                                                  v-model="assetType.endDate">
                                    </b-form-input>
                                    <date-picker v-model="assetType.endDate" style="width: 300px"></date-picker>
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
    import { mapState, Store } from 'vuex'
    import { validationMixin } from 'vuelidate'
    import { required, sameAs, minLength, helpers } from 'vuelidate/lib/validators'
    import store from '@/store/index'

    export default {
        name: 'CreateAssetType',
        mixins: [validationMixin],
        data() {
            return {
                assetType: {
                    parentId: null,
                    name: null,
                    code: null,
                    description: null,
                    startDate: null,
                    endDate: null
                },
                editing: false
            }
        },
        computed: {
            ...mapState({
                assetTypes: (state, getters) => getters.assetTypeTree
            })
        },
        validations: {
            assetType: {
                name: { required },
                code: { required }
            }
        },
        created() {

        },
        methods: {
            cancel() {
                this.$router.push({ path: '/master-data/asset-types/list' });
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.post('master-data/asset-types', this.assetType).done((id) => {
                        vm.$toastr.s('Tạo mới nhóm tài sản thành công');
                        this.cancel();
                        store.dispatch('loadAssetTypes');
                    });
                }
            }
        }
    }
</script>
<style scoped>
</style>
