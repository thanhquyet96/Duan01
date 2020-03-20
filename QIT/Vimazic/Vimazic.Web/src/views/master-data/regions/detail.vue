<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thông tin địa bàn</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Trực thuộc tỉnh/thành phố: "
                                              label-for="code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{ region.provinceName != null ?region.provinceName : "Không"}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Trực thuộc quận/huyện: "
                                              label-for="code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{ region.districtName != null ? region.districtName : "Không" }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Mã địa bàn: "
                                              label-for="code"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              :label-class="editing? 'required' : ''">
                                    <b-form-input type="text" id="code" v-if="editing"
                                                  aria-describedby="codeFeedback"
                                                  v-model="$v.region.code.$model"
                                                  :state="$v.region.code.$dirty? !$v.region.code.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="codeFeedback">
                                        Vui lòng nhập mã địa bàn
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ region.code }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="Tên địa bàn: "
                                              label-for="name"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right"
                                              :label-class="editing? 'required' : ''">
                                    <b-form-input type="text" id="name" v-if="editing"
                                                  aria-describedby="nameFeedback"
                                                  v-model="$v.region.name.$model"
                                                  :state="$v.region.name.$dirty? !$v.region.name.$error : null">
                                    </b-form-input>
                                    <b-form-invalid-feedback id="nameFeedback">
                                        Vui lòng nhập tên địa bàn
                                    </b-form-invalid-feedback>
                                    <label class="col-form-label" v-if="!editing">{{ region.name }}</label>
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
                                                     v-if="editing"
                                                     class="mgt-10"
                                                     v-model="region.isActive">
                                        <!--Trạng thái-->
                                    </b-form-checkbox>
                                    <label class="col-form-label" v-if="!editing">{{ region.isActive ? "Có" : "Không" }}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="primary" @click="edit" v-if="!editing && authorize(['ManageRegion'])">Sửa</b-button>
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
    import { authorizationMixin } from '@/shared/mixins'

    export default {
        name: 'RegionDetail',
        mixins: [validationMixin, authorizationMixin],
        data() {
            return {
                region: {},
                editing: false
            }
        },
        computed: {
            regionId() {
                return this.$route.params.regionId;
            },
        },
        validations: {
            region: {
                name: { required },
                code: { required }
            }
        },
        created() {
            this.loadRegionDetail();
        },
        methods: {
            loadRegionDetail() {
                var vm = this;
                return this.$services.get(`master-data/regions/${this.regionId}`).done(region => {
                    vm.region = region;
                });
            },
            edit() {
                this.editing = true;
            },
            back() {
                this.$router.push({ path: '/master-data/regions' });
            },
            cancel() {
                var vm = this;
                this.loadRegionDetail().done(() => vm.editing = false);
            },
            save() {
                this.$v.$touch();
                if (!this.$v.$invalid) {
                    var vm = this;
                    this.$services.put(`master-data/regions/${this.regionId}`, this.region).done(() => {
                        vm.$toastr.s('Cập nhật địa bàn thành công');
                        vm.cancel();
                    });
                }
            }
        }
    }
</script>
<style scoped>

    .mgt-10 {
        margin-top: 10px;
    }
</style>
