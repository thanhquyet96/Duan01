<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thêm mới lí do tăng</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Mã lí do tăng: "
                                              label-for="input-code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-class="required"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-code"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.increasementcause.code.$model"
                                                  :state="$v.increasementcause.code.$dirty? !$v.increasementcause.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Tên lí do tăng: "
                                              label-for="input-name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-class="required"
                                              label-align-md="right">
                                    <b-form-input type="text" id="input-name"
                                                  aria-describedby="nameFeedback"
                                                  v-model="$v.increasementcause.name.$model"
                                                  :state="$v.increasementcause.name.$dirty? !$v.increasementcause.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameFeedback">
                                        Vui lòng nhập tên
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Áp dụng: "
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <treeselect v-model="increasementcause.assetTypeId"
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
                            <b-col md="6" offset="3">
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
        name: 'CreateIncreasementCause',
        mixins: [validationMixin],
        data() {
            return {
                increasementcause: {
                    name: null,
                    code: null,
                    assetTypeId: null
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
            increasementcause: {
                code: { required },
                name: { required }
            }
        },
        created() {

        },
        methods: {
            cancel() {
                this.$router.push({ path: '/master-data/increasement-causes/list' });
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.post('master-data/increasement-causes', this.increasementcause).done((id) => {
                        vm.$toastr.s('Tạo mới lí do tăng thành công');
                        vm.$router.push({ path: '/master-data/increasement-causes/list' });
                    });
                }
            }
        }
    }
</script>
<style scoped>
</style>
