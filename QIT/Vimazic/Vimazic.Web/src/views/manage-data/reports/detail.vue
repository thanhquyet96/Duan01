<template>
    <div class="animated fadeIn">
        <!--thong tin chung-->
        <b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>Thông tin chung tài sản</strong>
                    </div>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Mã tài sản đồng bộ từ phần mềm khác: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.syncSourceId}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Mã tài sản toàn quốc do kho cấp (tự động sinh): "
                                          label-for="assetName"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.code}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Tài khoản đồng bộ:"
                                          label-for="region"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.syncUserId}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày đồng bộ:"
                                          label-for="address"
                                          class="text-1"
                                          :label-cols="4"
                                          label-align-md="right"
                                          :horizontal="true">
                                <label class="col-form-label">{{asset.syncDate | formatDate('DD/MM/YYYY HH:mm:ss')}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Tên tài sản: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.name}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Mô tả tài sản: "
                                          label-for="userName"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.description}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nhóm tài sản: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.assetTypeName}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Nhóm tài sản lớn (cấp 2 trong cây nhóm tài sản): "
                                          label-for="userName"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.assetCategoryName}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="ID đơn vị quản lý tài sản: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.unitId}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Đơn vị sử dụng: "
                                          label-for="userName"
                                          :label-cols="4"
                                          class="text-1"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.unitName}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Mã bộ phận sử dụng tài sản (đối với đơn vị hành chính): "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.departmentCode}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Tên bộ phận sử dụng tài sản (đối với đơn vị hành chính): "
                                          label-for="userName"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.departmentName}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Cán bộ sử dụng:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.userName}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Mã nguồn gốc tài sản:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.assetSourceId}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Chế độ hạch toán:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.accountingStandardName}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Tỷ lệ khấu hao:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.depreciationRate}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Tỷ lệ hao mòn:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.amortizationRate}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Kế hoạch mua sắm:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.procurementPlan}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Hình thức mua sắm:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.procurementForm}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày nhập thông tin:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.inputDate | formatDate('DD/MM/YYYY HH:mm:ss')}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Ngày sử dụng:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.dateOfUse | formatDate}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày duyệt:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.approvedDate | formatDate}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Ngày hết hạn sử dụng:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.expiryDate | formatDate}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày sản xuất:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.manufacturerDate | formatDate}}</label>

                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Ngày hết hạn bảo hành:"
                                          class="text-1"
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.warrantyExpiryDate | formatDate}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Tình trạng sử dụng:"
                                          label-for="unit"
                                          :label-cols="4"
                                          class="text-1"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.usageStatus}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Hiện trạng sử dụng:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.usageStateId}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Mục đích sử dụng:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.usagePurposeId}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Hình thức sử dụng:"
                                          class="text-1"
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.usageForm}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Người duyệt:"
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.approverName}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <strong>
                        Giá trị
                    </strong>
                    <hr />
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguyên giá: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValue | formatCurrency}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguồn ngân sách nhà nước: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">
                                    {{asset.originalValueSourceStateBudget | formatCurrency}}
                                </label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Nguồn ODA:"
                                          label-for="region"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceOda | formatCurrency}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguồn viện trợ: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceAid | formatCurrency}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Nguồn vay: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceBorrow | formatCurrency}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguồn khác:"
                                          label-for="region"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceOther | formatCurrency}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Giá trị còn lại:"
                                          label-for="region"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.residualValue | formatCurrency}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <strong>
                        Hồ sơ giấy tờ
                    </strong>
                    <hr />
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Hoa hồng/chiết khấu: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.discountCommissionValue}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Hoa hồng/chiết khấu nộp ngân sách nhà nước:"
                                          label-for="region"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.discountCommissionToBudget}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Hoa hồng/chiết khấu được giữ lại đơn vị: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.discountCommissionRemain}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Biên bản nghiệm thu: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentAcceptance}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày nghiệm thu:"
                                          label-for="region"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateAcceptance | formatDate}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Biên bản nghiệm thu: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentAcceptance}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày nghiệm thu:"
                                          label-for="region"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateAcceptance | formatDate}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Biên bản bàn giao: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDelivery}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày bàn giao:"
                                          label-for="region"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateDelivery | formatDate}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Hóa đơn/chứng từ: "
                                          label-for="unit"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentReceipt}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày ký hóa đơn/chứng từ:"
                                          label-for="region"
                                          class="text-1"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateReceipt | formatDate}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Chứng từ pháp lý khác: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentOther}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                </b-card>
            </b-col>
        </b-row>
        <!--end thong tin chung-->
        <!--ASSET NPA LAND-->
        <template v-if="asset.assetCategoryId == constantAssetCategory.NpaLand">
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Tài sản là đất
                            </strong>
                        </div>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandArea | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm trụ sở làm việc:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaHeadquarterUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cơ sở hoạt động sự nghiệp:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaBusinessUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà để ở:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaHouseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cho thuê:"
                                              class="text-1"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaLeaseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích bỏ trống:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaVacantUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích bị lấn chiếm:"
                                              label-for="region"
                                              :label-cols="4"
                                              class="text-1"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaOccupiedUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Địa bàn:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandRegionName}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Địa chỉ:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAddress}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Hồ sơ pháp lý
                            </strong>
                        </div>
                        <b-form-group>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Giá trị quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandUseRightValue}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Giá trị quyền sử dụng đất theo khung giá đất địa phương:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  class="text-1"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandLocalUseRightValue}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số giấy chứng nhận quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandUseRight}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày chứng nhận quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandUseRightDate | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số quyết định giao đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandAllocate}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày quyết định giao đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandAllocate | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Hợp đồng chuyển nhượng quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandUseRightTransfer}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày ký hợp đồng chuyển nhượng quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandUseRightTransfer | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số quyết định cho thuê đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  class="text-1"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandLease}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày quyết định cho thuê đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandLease | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Biên bản xác định giá trị quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  class="text-1"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandUseRightEvaluation}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày ký biên bản xác định giá trị quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandUseRightEvaluation | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                        </b-form-group>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back">Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET NPA LAND-->
        <!--ASSET NPA HOUSE-->
        <template v-if="asset.assetCategoryId == constantAssetCategory.NpaHouse">
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Tài sản là nhà
                            </strong>
                        </div>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Mã tài sản đất: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseLandId}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Số tầng (nhà): "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseNumberOfFloor}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích xây dựng: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaBuilding | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích sàn: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaFloor | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm trụ sở làm việc: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaHeadquarterUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cơ sở hoạt động sự nghiệp: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaBusinessUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà để ở: "
                                              label-for="unit"
                                              :label-cols="4"
                                              class="text-1"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaHouseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà kho: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaWarehouseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà tạm: "
                                              label-for="unit"
                                              :label-cols="4"
                                              class="text-1"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaTemporaryHouseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cho thuê: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaLeaseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích bỏ trống: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaVacantUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích bị lấn chiếm: "
                                              label-for="unit"
                                              :label-cols="4"
                                              class="text-1"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaOccupiedUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích sử dụng khác: "
                                              label-for="unit"
                                              :label-cols="4"
                                              class="text-1"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaOtherUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back">Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET NPA HOUSE-->
        <!--ASSET NPA VEHICLE-->
        <template v-if="asset.assetCategoryId == constantAssetCategory.NpaVehicle">
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Tài sản là xe
                            </strong>
                        </div>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nước sản xuất: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleCountryOfOrigin}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nhãn hiệu: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleBrandName}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Số khung/Mã nhận dạng phương tiện: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleVehicleIdentificationNumber}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Biển kiểm soát/số hiệu kiểm soát: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleRegistrationPlateNumber}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Kích cỡ (Số chỗ ngồi/kích cỡ tàu ...): "
                                              label-for="unit"
                                              :label-cols="4"
                                              class="text-1"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleSize}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Sức chứa (tải trọng/công suất ...): "
                                              label-for="unit"
                                              :label-cols="4"
                                              class="text-1"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleCapacity}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back">Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET NPA VEHICLE-->
        <!--ASSET NPA OTHER-->
        <template v-if="asset.assetCategoryId == constantAssetCategory.NpaOther">
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Tài sản khác
                            </strong>
                        </div>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Thông số kỹ thuật: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaOtherAssetSpecifications}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Số serie: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaOtherAssetSerialNumber}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nhà cung cấp: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaOtherAssetSupplier}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nước sản xuất: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaOtherAssetCountryOfOrigin}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nhãn hiệu: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaOtherAssetBrandName}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back">Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END NPA OTHER-->
        <!-- -----------------------OA----------------------- -->
        <!--ASSET OA LAND-->
        <template v-if="asset.assetCategoryId == constantAssetCategory.OaLand">
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Tài sản là đất
                            </strong>
                        </div>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandArea | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm trụ sở làm việc:"
                                              class="text-1"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaBusinessUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cơ sở hoạt động sự nghiệp:"
                                              class="text-1"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaBusinessUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà để ở:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaHouseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cho thuê:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaLeaseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích bỏ trống:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaVacantUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích bị lấn chiếm:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaOccupiedUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Địa bàn:"
                                              label-for="region"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandRegionName}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Địa chỉ:"
                                              class="text-1"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAddress}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Hồ sơ pháp lý
                            </strong>
                        </div>
                        <b-form-group>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Giá trị quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandUseRightValue}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Giá trị quyền sử dụng đất theo khung giá đất địa phương:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandLocalUseRightValue}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số giấy chứng nhận quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentLandUseRight}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày chứng nhận quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandUseRightDate | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số quyết định giao đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  class="text-1"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentLandAllocate}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày quyết định giao đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  class="text-1"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandAllocate | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Hợp đồng chuyển nhượng quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  class="text-1"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentLandUseRightTransfer}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày ký hợp đồng chuyển nhượng quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandUseRightTransfer | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số quyết định cho thuê đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentLandLease}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày quyết định cho thuê đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandLease | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Biên bản xác định giá trị quyền sử dụng đất:"
                                                  label-for="region"
                                                  class="text-1"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentLandUseRightEvaluation}}</label>
                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày ký biên bản xác định giá trị quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  class="text-1"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandUseRightEvaluation | formatDate}}</label>
                                    </b-form-group>
                                </b-col>
                            </b-row>
                        </b-form-group>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back">Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET OA LAND-->
        <!--ASSET OA HOUSE-->
        <template v-if="asset.assetCategoryId == constantAssetCategory.OaHouse">
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Tài sản là nhà
                            </strong>
                        </div>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Mã tài sản đất: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseLandId}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Số tầng (nhà): "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseNumberOfFloor}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích xây dựng: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaBuilding | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích sàn: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaFloor | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm trụ sở làm việc: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaHeadquarterUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cơ sở hoạt động sự nghiệp: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaBusinessUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà để ở: "
                                              label-for="unit"
                                              :label-cols="4"
                                              class="text-1"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaHouseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà kho: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaWarehouseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà tạm: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaTemporaryHouseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cho thuê: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaLeaseUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích bỏ trống: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaVacantUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích bị lấn chiếm: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaOccupiedUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích sử dụng khác: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaOtherUsage | formatCurrency}} m&sup2;</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back">Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET OA HOUSE-->
        <!--ASSET OA VEHICLE-->
        <template v-if="asset.assetCategoryId == constantAssetCategory.OaVehicle">
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Tài sản là xe
                            </strong>
                        </div>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nước sản xuất: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaVehicleCountryOfOrigin}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nhãn hiệu: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaVehicleBrandName}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Số khung/Mã nhận dạng phương tiện: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaVehicleVehicleIdentificationNumber}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Biển kiểm soát/số hiệu kiểm soát: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaVehicleRegistrationPlateNumber}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Kích cỡ (Số chỗ ngồi/kích cỡ tàu ...): "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaVehicleSize}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Sức chứa (tải trọng/công suất ...): "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaVehicleCapacity}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back">Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET OA VEHICLE-->
        <!--ASSET OA ABOVE 500M-->
        <template v-if="asset.assetCategoryId == constantAssetCategory.OaAbove500M">
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Tài sản trên 500M
                            </strong>
                        </div>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Thông số kỹ thuật: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaAbove500MSpecifications}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Số serie: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaAbove500MSerialNumber}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nhà cung cấp: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaAbove500MSupplier}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nước sản xuất: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaAbove500MCountryOfOrigin}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nhãn hiệu: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaAbove500MBrandName}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back">Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET OA ABOVE 500M-->
        <!--ASSET OA BELOW 500M-->
        <template v-if="asset.assetCategoryId == constantAssetCategory.OaBelow500M">
            <b-row>
                <b-col lg="12">
                    <b-card>
                        <div slot="header">
                            <strong>
                                Tài sản dưới 500M
                            </strong>
                        </div>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Thông số kỹ thuật: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaBelow500MSpecifications}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Số serie: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaBelow500MSerialNumber}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nhà cung cấp: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaBelow500MSupplier}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nước sản xuất: "
                                              class="text-1"
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaBelow500MCountryOfOrigin}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Nhãn hiệu: "
                                              label-for="unit"
                                              class="text-1"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaBelow500MBrandName}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back">Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET OA BELOW 500M-->
    </div>

</template>
<script>
    import { mapState, mapGetters } from 'vuex'
    import { authorizationMixin } from '@/shared/mixins'

    export default {
        name: 'ListUnitType',
        mixins: [authorizationMixin],
        data() {
            return {
                asset: {},
                editing: false,
            }
        },
        computed: {
            assetId() {
                return this.$route.params.assetId;
            },
            ...mapGetters({
                constantAssetCategory: 'ListAssetCategory'
            })
        },
        created() {
            this.loadAssetDetail();
        },
        methods: {
            loadAssetDetail() {
                var vm = this;
                return this.$services.get(`manage-data/assets/${this.assetId}`).done(asset => {
                    vm.asset = asset;
                });
            },
            edit() {
                this.editing = true;
            },
            back() {
                this.$router.push({ path: '/manage-data/assets/list' });
            },
            cancel() {
                var vm = this;
                this.loadAssetDetail().done(() => vm.editing = false);
            },
        }
    }
</script>
<style scoped>

    label {
        font-weight: 400;
        font-style: italic;
    }

    .text-1 {
        font-weight: 500;
    }
</style>
