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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.syncSourceId}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Mã tài sản toàn quốc do kho cấp (tự động sinh): "
                                          label-for="assetName"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.syncUserId}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày đồng bộ:"
                                          label-for="address"
                                          :label-cols="4"
                                          label-align-md="right"
                                          :horizontal="true">
                                <label class="col-form-label">{{asset.syncDate}}</label>

                            </b-form-group>
                        </b-col>
                    </b-row>

                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Tên tài sản: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.name}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Mô tả tài sản: "
                                          label-for="userName"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.assetTypeName}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Nhóm tài sản lớn (cấp 2 trong cây nhóm tài sản): "
                                          label-for="userName"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.departmentCode}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Tên bộ phận sử dụng tài sản (đối với đơn vị hành chính): "
                                          label-for="userName"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.userName}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Mã nguồn gốc tài sản:"
                                          label-for="unit"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.accountingStandardName}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Tỷ lệ khấu hao:"
                                          label-for="unit"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.amortizationRate}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Kế hoạch mua sắm:"
                                          label-for="unit"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.procurementForm}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày nhập thông tin:"
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.inputDate}}</label>

                            </b-form-group>
                        </b-col>

                    </b-row>

                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Ngày sử dụng:"
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.dateOfUse}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày duyệt:"
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.approvedDate}}</label>

                            </b-form-group>
                        </b-col>

                    </b-row>

                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Ngày hết hạn sử dụng:"
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.expiryDate}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày sản xuất:"
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.manufacturerDate}}</label>

                            </b-form-group>
                        </b-col>

                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Ngày hết hạn bảo hành:"
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.warrantyExpiryDate}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Tình trạng sử dụng:"
                                          label-for="unit"
                                          :label-cols="4"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.usageStateId}}</label>

                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Mục đích sử dụng:"
                                          label-for="unit"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValue}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguồn ngân sách nhà nước: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">
                                    {{asset.originalValueSourceStateBudget}}
                                </label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Nguồn ODA:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceOda}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguồn viện trợ: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceAid}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Nguồn vay: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceBorrow}}</label>
                            </b-form-group>
                        </b-col>

                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguồn khác:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceOther}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Giá trị còn lại:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.residualValue}}</label>
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.discountCommissionValue}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Hoa hồng/chiết khấu nộp ngân sách nhà nước:"
                                          label-for="region"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentAcceptance}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày nghiệm thu:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateAcceptance}}</label>

                            </b-form-group>
                        </b-col>
                    </b-row>

                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Biên bản nghiệm thu: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentAcceptance}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày nghiệm thu:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateAcceptance}}</label>

                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Biên bản bàn giao: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDelivery}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày bàn giao:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateDelivery}}</label>

                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Hóa đơn/chứng từ: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentReceipt}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày ký hóa đơn/chứng từ:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateReceipt}}</label>

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



        <!--<b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>
                            Giá trị
                        </strong>
                    </div>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguyên giá: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValue}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <label class="col-form-label">Trong đó:</label>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguồn ngân sách nhà nước: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">
                                    {{asset.originalValueSourceStateBudget}}
                                </label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Nguồn ODA:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceOda}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguồn viện trợ: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceAid}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Nguồn vay: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceBorrow}}</label>
                            </b-form-group>
                        </b-col>

                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Nguồn khác:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.originalValueSourceOther}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Giá trị còn lại:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.residualValue}}</label>
                            </b-form-group>
                        </b-col>
                    </b-row>
                </b-card>
            </b-col>
        </b-row>-->
        <!--<b-row>
            <b-col lg="12">
                <b-card>
                    <div slot="header">
                        <strong>
                            Hồ sơ giấy tờ
                        </strong>
                    </div>

                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Hoa hồng/chiết khấu: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.discountCommissionValue}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Hoa hồng/chiết khấu nộp ngân sách nhà nước:"
                                          label-for="region"
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
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentAcceptance}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày nghiệm thu:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateAcceptance}}</label>

                            </b-form-group>
                        </b-col>
                    </b-row>

                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Biên bản nghiệm thu: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentAcceptance}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày nghiệm thu:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateAcceptance}}</label>

                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Biên bản bàn giao: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDelivery}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày bàn giao:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateDelivery}}</label>

                            </b-form-group>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col md="6">
                            <b-form-group label="Hóa đơn/chứng từ: "
                                          label-for="unit"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentReceipt}}</label>
                            </b-form-group>
                        </b-col>
                        <b-col md="6">
                            <b-form-group label="Ngày ký hóa đơn/chứng từ:"
                                          label-for="region"
                                          :label-cols="4"
                                          :horizontal="true"
                                          label-align-md="right">
                                <label class="col-form-label">{{asset.documentDateReceipt}}</label>

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
        </b-row>-->
        <!--end thong tin chung-->
        <!--ASSET NPA LAND-->
        <template v-if="asset.assetCategoryId == 21">
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandArea}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm trụ sở làm việc:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaHeadquarterUsage}}</label>

                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cơ sở hoạt động sự nghiệp:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaBusinessUsage}}</label>

                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà để ở:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaHouseUsage}}</label>

                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cho thuê:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaLeaseUsage}}</label>

                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích bỏ trống:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaVacantUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích bị lấn chiếm:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaOccupiedUsage}}</label>

                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Địa bàn:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandRegionId}}</label>

                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Địa chỉ:"
                                              label-for="region"
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
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandUseRight}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày chứng nhận quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandUseRightDate}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số quyết định giao đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandAllocate}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày quyết định giao đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandAllocate}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Hợp đồng chuyển nhượng quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandUseRightTransfer}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày ký hợp đồng chuyển nhượng quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandUseRightTransfer}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số quyết định cho thuê đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandLease}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày quyết định cho thuê đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandLease}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Biên bản xác định giá trị quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentLandUseRightEvaluation}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày ký biên bản xác định giá trị quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.npaLandDocumentDateLandUseRightEvaluation}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                        </b-form-group>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back"><i class="fa fa-ban"></i> Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET NPA LAND-->
        <!--ASSET NPA HOUSE-->
        <template v-if="asset.assetCategoryId == 22">
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseLandId}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Số tầng (nhà): "
                                              label-for="unit"
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
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaBuilding}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích sàn: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaFloor}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>

                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm trụ sở làm việc: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaHeadquarterUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cơ sở hoạt động sự nghiệp: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaBusinessUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>

                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà để ở: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaHouseUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà kho: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaWarehouseUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>

                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà tạm: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaTemporaryHouseUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cho thuê: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaLeaseUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích bỏ trống: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaVacantUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích bị lấn chiếm: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaOccupiedUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích sử dụng khác: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaHouseAreaOtherUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back"><i class="fa fa-ban"></i> Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>

                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET NPA HOUSE-->
        <!--ASSET NPA VEHICLE-->
        <template v-if="asset.assetCategoryId == 23">
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleCountryOfOrigin}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nhãn hiệu: "
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleVehicleIdentificationNumber}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Biển kiểm soát/số hiệu kiểm soát: "
                                              label-for="unit"
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
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleSize}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Sức chứa (tải trọng/công suất ...): "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaVehicleCapacity}}</label>
                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back"><i class="fa fa-ban"></i> Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET NPA VEHICLE-->
        <!--ASSET NPA OTHER-->
        <template v-if="asset.assetCategoryId == 24">
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaOtherAssetSupplier}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nước sản xuất: "
                                              label-for="unit"
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
                                    <b-button type="button" variant="secondary" @click="back"><i class="fa fa-ban"></i> Quay lại</b-button>
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
        <template v-if="asset.assetCategoryId == 25">
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandArea}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm trụ sở làm việc:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaBusinessUsage}}</label>

                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cơ sở hoạt động sự nghiệp:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.npaLandAreaBusinessUsage}}</label>

                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà để ở:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaHouseUsage}}</label>

                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cho thuê:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaLeaseUsage}}</label>

                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích bỏ trống:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaVacantUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích bị lấn chiếm:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandAreaOccupiedUsage}}</label>

                                </b-form-group>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Địa bàn:"
                                              label-for="region"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaLandRegionId}}</label>

                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Địa chỉ:"
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
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandUseRightValue}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Giá trị quyền sử dụng đất theo khung giá đất địa phương:"
                                                  label-for="region"
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
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentLandUseRight}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày chứng nhận quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandUseRightDate}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số quyết định giao đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentLandAllocate}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày quyết định giao đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandAllocate}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Hợp đồng chuyển nhượng quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentLandUseRightTransfer}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày ký hợp đồng chuyển nhượng quyền sử dụng đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandUseRightTransfer}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Số quyết định cho thuê đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentLandLease}}</label>

                                    </b-form-group>
                                </b-col>
                                <b-col md="6">
                                    <b-form-group label="Ngày quyết định cho thuê đất:"
                                                  label-for="region"
                                                  :label-cols="4"
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandLease}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col md="6">
                                    <b-form-group label="Biên bản xác định giá trị quyền sử dụng đất:"
                                                  label-for="region"
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
                                                  :horizontal="true"
                                                  label-align-md="right">
                                        <label class="col-form-label">{{asset.oaLandDocumentDateLandUseRightEvaluation}}</label>

                                    </b-form-group>
                                </b-col>
                            </b-row>
                        </b-form-group>
                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back"><i class="fa fa-ban"></i> Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET OA LAND-->
        <!--ASSET OA HOUSE-->
        <template v-if="asset.assetCategoryId == 26">
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseLandId}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Số tầng (nhà): "
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
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaBuilding}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích sàn: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaFloor}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>

                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm trụ sở làm việc: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaHeadquarterUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cơ sở hoạt động sự nghiệp: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaBusinessUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>

                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà để ở: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaHouseUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà kho: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaWarehouseUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>

                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích làm nhà tạm: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaTemporaryHouseUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích cho thuê: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaLeaseUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích bỏ trống: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaVacantUsage}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Diện tích bị lấn chiếm: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaOccupiedUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>
                        <b-row>
                            <b-col md="6">
                                <b-form-group label="Diện tích sử dụng khác: "
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaHouseAreaOtherUsage}}</label>
                                </b-form-group>
                            </b-col>

                        </b-row>

                        <b-row>
                            <b-col md="6" offset="3">
                                <b-form-group label="" :label-cols="4">
                                    <b-button type="button" variant="secondary" @click="back"><i class="fa fa-ban"></i> Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET OA HOUSE-->
        <!--ASSET OA VEHICLE-->
        <template v-if="asset.assetCategoryId == 27">
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaVehicleCountryOfOrigin}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nhãn hiệu: "
                                              label-for="unit"
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaVehicleVehicleIdentificationNumber}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Biển kiểm soát/số hiệu kiểm soát: "
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
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaVehicleSize}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Sức chứa (tải trọng/công suất ...): "
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
                                    <b-button type="button" variant="secondary" @click="back"><i class="fa fa-ban"></i> Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET OA VEHICLE-->
        <!--ASSET OA ABOVE 500M-->
        <template v-if="asset.assetCategoryId == 28">
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
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaAbove500MSpecifications}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Số serie: "
                                              label-for="unit"
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
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaAbove500MSupplier}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nước sản xuất: "
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
                                    <b-button type="button" variant="secondary" @click="back"><i class="fa fa-ban"></i> Quay lại</b-button>
                                </b-form-group>
                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </template>
        <!--END ASSET OA ABOVE 500M-->
        <!--ASSET OA BELOW 500M-->
        <template v-if="asset.assetCategoryId == 29">
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
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaBelow500MSpecifications}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Số serie: "
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
                                              label-for="unit"
                                              :label-cols="4"
                                              :horizontal="true"
                                              label-align-md="right">
                                    <label class="col-form-label">{{asset.oaBelow500MSupplier}}</label>
                                </b-form-group>
                            </b-col>
                            <b-col md="6">
                                <b-form-group label="Nước sản xuất: "
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
                                    <b-button type="button" variant="secondary" @click="back"><i class="fa fa-ban"></i> Quay lại</b-button>
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
    import { mapState } from 'vuex'
    import { authorizationMixin } from '@/shared/mixins'

    export default {
        name: 'ListUnitType',
        mixins: [authorizationMixin],
        data() {
            return {
                asset: {},
                editing: false,
                isFile: false,
                assetType: null,
                assetTypes: {
                    NPA: 1,//tafi san cong
                    OA: 2 //tai san toan dan
                },
                isManageLand: false,
            }
        },
        computed: {
            assetId() {
                return this.$route.params.assetId;
            },
        },
        //validations: {
        //    country: {
        //        code: { required },
        //        name: { required },
        //        description: {}
        //    }
        //},
        created() {
            this.loadAssetDetail();
        },
        methods: {
            loadAssetDetail() {
                var vm = this;
                return this.$services.get(`manage-data/assets/${this.assetId}`).done(asset => {
                    //vm.assetType = asset.assetTypeId == vm.assetTypes.NPA ? 1 : 2;

                    console.log(asset);
                    vm.asset = asset;
                });
            },
            edit() {
                this.editing = true;
            },
            back() {
                this.$router.push({ path: '/manage/assets/list' });
            },
            cancel() {
                var vm = this;
                this.loadAssetDetail().done(() => vm.editing = false);
            },
            //save() {
            //    this.$v.$touch();
            //    if (!this.$v.$invalid) {
            //        var vm = this;
            //        this.$services.put(`master-data/countries/${this.countryId}`, this.country).done(() => {
            //            vm.$toastr.s('Cập nhật quốc gia thành công');
            //            vm.cancel();
            //        });
            //    }
            //},
        }
    }
</script>
<style scoped>
</style>
