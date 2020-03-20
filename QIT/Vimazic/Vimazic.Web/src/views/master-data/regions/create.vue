<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thêm mới địa bàn</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Địa bàn:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <region-tree v-model="region.parentId" ref="regionTree"></region-tree>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Mã địa bàn:"
                                              label-for="code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="text" id="code"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.region.code.$model"
                                                  :state="$v.region.code.$dirty? !$v.region.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã địa bàn
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Tên địa bàn"
                                              label-for="name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              label-class="required">
                                    <b-form-input type="text" id="name"
                                                  aria-describedby="nameFeedback"
                                                  v-model="$v.region.name.$model"
                                                  :state="$v.region.name.$dirty? !$v.region.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập tên địa bàn
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Đang hoạt động:"
                                              id="status"
                                              label-for="isActive"
                                              :label-cols="4"
                                              label-align-md="right"
                                              :horizontal="true">
                                    <b-form-checkbox id="isActive"
                                                     class="mgt-10"
                                                     v-model="region.isActive">
                                        <!--Trạng thái-->
                                    </b-form-checkbox>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button v-if="authorize(['ManageRegion'])" type="submit" variant="primary">Ghi lại</b-button>
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
    import { required, sameAs, minLength, helpers } from 'vuelidate/lib/validators'
    import { authorizationMixin } from '@/shared/mixins'

    export default {
        name: 'CreateNation',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                region: {
                    name: null,
                    code: null,
                    parentId: null
                },

            }
        },
        validations: {
            region: {
                name: { required },
                code: { required },
            }
        },
        watch: {

        },
        created() {

        },
        methods: {
            cancel() {
                this.$router.push({ path: '/master-data/regions/list' });
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.post('master-data/regions', this.region).done((id) => {
                        vm.$toastr.s('Tạo mới địa bàn thành công');
                        vm.$router.push({ path: '/master-data/regions/list' });
                    });
                }
            },
        }
    }
</script>
<style scoped>
    .mgt-10{
        margin-top:10px;
    }
</style>
