<template>
    <div class="animated fadeIn">
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Tìm kiếm chung</strong>
                    </div>
                    <b-form @submit.prevent="search">
                        <b-row class="justify-content-md-center">
                            <b-col md="5">
                                <b-form-group label="Đơn vị:"
                                              label-for="input-unit"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <unit-tree v-model="unitId" ref="unitTree"></unit-tree>
                                </b-form-group>
                            </b-col>
                            <b-col md="5">
                                <b-form-group label="Tài khoản:"
                                              label-for="input-actor"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <select2 v-model="searchForm.actor" :options="listActors"
                                             style="width:100%"
                                             allowClear="true"
                                             placeholder="--- Chọn tài khoản ---"></select2>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row class="justify-content-md-center">
                            <b-col md="5">
                                <b-form-group label="Từ ngày:"
                                              label-for="input-startdate"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <date-picker id="input-startdate" v-model="searchForm.startDate" style="width: 280px"></date-picker>
                                </b-form-group>
                            </b-col>
                            <b-col md="5">
                                <b-form-group label="Đến ngày:"
                                              label-for="input-enddate"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <date-picker id="input-enddate" v-model="searchForm.endDate" style="width: 280px"></date-picker>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row class="justify-content-md-center">
                            <b-col md="5">
                                <b-form-group label="Hành vi:"
                                              label-for="input-action"
                                              :label-cols="3"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <select2 v-model="searchForm.action" :options="listActions"
                                             style="width:100%"
                                             allowClear="true"
                                             placeholder="--- Chọn hành vi ---"></select2>
                                </b-form-group>
                            </b-col>
                            <b-col md="5">
                            </b-col>
                        </b-row>
                        <b-row class="justify-content-md-center">
                            <b-col md="5">
                                <b-form-group label="" :label-cols="3">
                                    <b-button type="submit" variant="primary">Tìm kiếm</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-form>
                    <b-grid :searchForm="searchForm"
                            :gridOptions="gridOptions"
                            selectable
                            dataUrl="logging/system-logs"
                            gridName="Nhật ký hệ thống"
                            ref="actionLogTable">
                        <template v-slot:cell(show_details)="row">
                            <b-button size="sm" @click="row.toggleDetails" class="mr-2">
                                {{ row.detailsShowing ? 'Hide' : 'Show'}} Details
                            </b-button>
                        </template>
                        <template v-slot:row-details="row">
                            <b-card>
                                <b-row class="mb-2">
                                    <b-col sm="3" class="text-sm-right"><b>Địa chỉ ip:</b></b-col>
                                    <b-col>{{ JSON.parse(row.item.origin).request_ip }}</b-col>
                                </b-row>
                                <b-button size="sm" @click="row.toggleDetails">Hide Details</b-button>
                            </b-card>
                        </template>
                    </b-grid>

                </b-card>
            </b-col>
        </b-row>
    </div>
</template>
<script>
    import { mapState } from 'vuex'
    import { authorizationMixin } from '@/shared/mixins'

    export default {
        name: 'ListAssetSource',
        mixins: [authorizationMixin],
        data() {
            return {
                listActors: [],
                listActions: ['Thêm', 'Xóa', 'Sửa'],
                unitId: null,
                searchForm: {
                    actor: null,
                    action: null,
                    startDate: null,
                    endDate: null
                },
                gridOptions: {
                    fields: [
                        { key: 'actor', label: 'Tài khoản', sortable: true },
                        { key: 'date', label: 'Thời gian', sortable: true, sortDirection: 'asc' },
                        { key: 'message', label: 'Hoạt động', sortable: true },
                        'show_details'
                    ],
                    sortBy: 'actor',
                },
                statuses: [
                    { id: 1, text: 'active' },
                    { id: 0, text: 'inactive' }
                ],
            }
        },
        computed: {

        },
        watch: {
            unitId() {
                return this.loadUserNameByUnitId();
            }
        },
        created() {
        },
        methods: {
            search() {
                this.$refs.actionLogTable.refresh();
            },
            loadUserNameByUnitId() {
                var vm = this;
                console.log(vm.unitId);
                return this.$services.get(`users/get-list-users/${this.unitId}`).done(response => {
                    vm.listActors = response;
                });
            }

        }
    }
</script>
<style scoped>
</style>
