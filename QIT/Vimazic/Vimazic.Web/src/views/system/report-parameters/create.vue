<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Tham số báo cáo</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row v-for="(param, index) in reportParameter.parameters" :key="param.name">
                            <b-col md="9">
                                <b-form-group :label="param.displayName"
                                              :label-cols="7"
                                              :horizontal="true"
                                              label-align-md="right"
                                              v-b-tooltip.focus
                                              :title="param.description">
                                    <b-form-input type="text"
                                                  v-model="param.value"
                                                  placeholder="Giá trị...">
                                    </b-form-input>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="9">
                                <b-form-group label=""
                                              :label-cols="7">
                                    <b-button type="submit" variant="primary">Ghi lại</b-button>
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

    export default {
        name: 'CreateReportParameter',
        data() {
            return {
                editing: false,
                reportParameter: {
                    parameters: []
                }
            }
        },
        computed: {

        },
        created() {
            this.loadReportParamter();
        },
        methods: {
            save() {
                var vm = this;
                this.$services.put('system-parameters/reports', this.reportParameter).done((response) => {
                    vm.$toastr.s('Cập nhật tham số báo cáo thành công');
                    vm.$router.push({ path: '/system/report-parameters/create' });
                });
            },
            loadReportParamter() {
                var vm = this;
                this.$services.get('system-parameters/reports').done((response) => {
                    vm.reportParameter.parameters = response;
                });
            }
        }
    }
</script>
<style scoped>
</style>
