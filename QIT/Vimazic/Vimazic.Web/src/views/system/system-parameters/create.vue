<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Tham số hệ thống</strong>
                    </div>
                    <b-form @submit.prevent="save">
                        <b-row v-for="(param, index) in systemParameter.parameters" :key="param.name">
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
        name: 'CreateSytemParameter',
        data() {
            return {
                editing: false,
                systemParameter: {
                    parameters: []
                }
            }
        },
        computed: {

        },
        created() {
            this.loadSytemParamter();
        },
        methods: {
            save() {
                var vm = this;
                this.$services.put('system-parameters/systems', this.systemParameter).done((response) => {
                    vm.$toastr.s('Cập nhật tham số hệ thống thành công');
                    vm.$router.push({ path: '/system/system-parameters/create' });
                });
            },
            loadSytemParamter() {
                var vm = this;
                this.$services.get('system-parameters/systems').done((response) => {
                    vm.systemParameter.parameters = response;
                });
            }
        }
    }
</script>
<style scoped>
</style>
