using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EPS.TSC.Data
{
    public class Constants
    {
        /// <summary>
        /// Chế độ hạch toán
        /// </summary>
        public enum AccountingStandardEnum
        {
            /// <summary>
            /// Tài sản chỉ tính hao mòn
            /// </summary>
            [Display(Name = "Tài sản chỉ tính hao mòn")]
            DepreciationAsset = 1,
            /// <summary>
            /// Tài sản chỉ tính khấu hao
            /// </summary>
            [Display(Name = "Tài sản chỉ tính khấu hao")]
            AmortizationAsset,
            /// <summary>
            /// Cả hai
            /// </summary>
            [Display(Name = "Cả hai")]
            Both
        }
        /// <summary>
        /// Chức năng đơn vị
        /// </summary>
        public enum FunctionalUnitEnum
        {
            /// <summary>
            /// Đơn vị tổng hợp
            /// </summary>
            [Display(Name = "Đơn vị tổng hợp")]
            UnitAggregate = 1,
            /// <summary>
            /// Đơn vị quản lý
            /// </summary>
            [Display(Name = "Đơn vị quản lý")]
            UnitManagement

        }
        /// <summary>
        /// Loại tham số
        /// </summary>
        public enum ParameterType
        {
            /// <summary>
            /// Tham số hoạt động
            /// </summary>
            OperationParameter = 1,
            /// <summary>
            /// Tham số báo cáo
            /// </summary>
            ReportParamter,
            /// <summary>
            /// Tham số quy định phương thức quản lý tài sản
            /// </summary>
            AssetManagementMethodParameter,
            /// <summary>
            /// Tham số đồng bộ
            /// </summary>
            SyncParameter
        }
        /// <summary>
        /// Kiểu dữ liệu tham số hệ thống 
        /// </summary>
        public enum DataTypeSystemParameter
        {
            DateTime = 1,
            Number,
            String
        }
        /// <summary>
        /// Tham số hệ thống
        /// </summary>
        public class SystemParameters
        {
            [Display(Name = "Ngày chốt số dư ban đầu", Order = 1), DefaultValue("abc"), DataType("1")]
            public const string NgayChotSoDuBanDau = "NGAY_CHOT_SO_DU_BAN_DAU";
            
            [Display(Name = "Nguyên giá tối thiểu tài sản", Order = 2), DefaultValue("abc"), DataType("1")]
            public const string NguyenGiaToiThieuTaiSan = "NGUYEN_GIA_TOI_THIEU_TAI_SAN";
            
            [Display(Name = "Số lượng sao chép tối đa tài sản", Order = 3), DefaultValue("abc"), DataType("1")]
            public const string SoLuongSaoChepToiDaTaiSan = "SO_LUONG_SAO_CHEP_TOI_DA_TAI_SAN";
            
            [Display(Name = "Tần xuất sao lưu dữ liệu", Order = 4), DefaultValue("abc"), DataType("1")]
            public const string TanXuatSaoLuuDuLieu = "TAN_XUAT_SAO_LUU_DU_LIEU";
            
            [Display(Name = "Hệ số hiệu chỉnh với tài sản", Order = 5), DefaultValue("abc"), DataType("1")]
            public const string HeSoHieuChinhVoiTaiSan = "HE_SO_HIEU_CHINH_VOI_TAI_SAN";
            
            [Display(Name = "Năm tài chính", Order = 6), DefaultValue("abc"), DataType("1")]
            public const string NamTaiChinh = "NAM_TAI_CHINH";
            
            [Display(Name = "Tính số liệu từ năm chốt", Order = 7), DefaultValue("abc"), DataType("1")]
            public const string TinhSoLieuTuNamChot = "TINH_SO_LIEU_TU_NAM_CHOT";
            
            [Display(Name = "Năm chốt số", Order = 8), DefaultValue("abc"), DataType("1")]
            public const string NamChotSo = "NAM_CHOT_SO";
        }
        /// <summary>
        /// Tham số báo cáo
        /// </summary>
        public class ReportParameters
        {
            [Display(Name = "Tên đơn vị cấp trên", Order = 1), DefaultValue("abc"), DataType("1")]
            public const string TenDonViCapTren = "TEN_DON_VI_CAP_TREN";

            [Display(Name = "Tên đơn vị", Order = 2), DefaultValue("abc"), DataType("1")]
            public const string TenDonVi = "TEN_DON_VI";

            [Display(Name = "Chức danh người lập biểu", Order = 3), DefaultValue("abc"), DataType("1")]
            public const string ChucDanhNguoiLapBieu = "CHUC_DANH_NGUOI_LAP_BIEU";
            
            [Display(Name = "Tên người lập biểu", Order = 4), DefaultValue("abc"), DataType("1")]
            public const string TenNguoiLapBieu = "TEN_NGUOI_LAP_BIEU";
            
            [Display(Name = "Chức danh kế toán trưởng", Order = 5), DefaultValue("abc"), DataType("1")]
            public const string ChucDanhKeToanTruong = "CHUC_DANH_KE_TOAN_TRUONG";
           
            [Display(Name = "Tên kế toán trưởng", Order = 6), DefaultValue("abc"), DataType("1")]
            public const string TenKeToanTruong = "TEN_KE_TOAN_TRUONG";
           
            [Display(Name = "Chức danh thủ trưởng đơn vị", Order = 7), DefaultValue("abc"), DataType("1")]
            public const string ChucDanhThuTruongDonVi = "CHUC_DANH_THU_TRUONG_DON_VI";
            
            [Display(Name = "Tên thủ trưởng đơn vị", Order = 8), DefaultValue("abc"), DataType("1")]
            public const string TenThuTruongDonVi = "TEN_THU_TRUONG_DON_VI";
            
            [Display(Name = "Địa danh", Order = 9), DefaultValue("abc"), DataType("1")]
            public const string DiaDanh = "DIA_DANH";
            
            [Display(Name = "Canh lề trái báo cáo", Order = 10), DefaultValue("abc"), DataType("1")]
            public const string CanhLeTraiBaoCao = "CANH_LE_TRAI_BAO_CAO";
            
            [Display(Name = "Canh lề phải báo cáo", Order = 11), DefaultValue("abc"), DataType("1")]
            public const string CanhLePhaiBaoCao = "CANH_LE_PHAI_BAO_CAO";
            
            [Display(Name = "Canh lề trên báo cáo", Order = 12), DefaultValue("abc"), DataType("1")]
            public const string CanhLeTrenBaoCao = "CANH_LE_TREN_BAO_CAO";
            
            [Display(Name = "Canh lề dưới báo cáo", Order = 13), DefaultValue("abc"), DataType("1")]
            public const string CanhLeDuoiBaoCao = "CANH_LE_DUOI_BAO_CAO";
        }
        public class SyncParameters
        {
            [Display(Name = "Đơn vị đồng bộ dữ liệu", Order = 1), DefaultValue("abc"), DataType("1")]
            public const string DonViDongBoDuLieu = "DON_VI_DONG_BO_DU_LIEU";

            [Display(Name = "Loại dữ liệu đồng bộ", Order = 2), DefaultValue("abc"), DataType("1")]
            public const string LoaiDongBoDuLieu = "LOAI_DONG_BO_DU_LIEU";

            [Display(Name = "Cơ sở dữ liệu liên kết", Order = 3), DefaultValue("abc"), DataType("1")]
            public const string CoSoDuLieuLienKet = "CO_SO_DU_LIEU_LIEN_KET";

            //[Display(Name = "Ngày đồng bộ", Order = 4), DefaultValue("abc"), DataType("1")]
            //public const string NgayDongBo = "NGAY_DONG_BO";

            //[Display(Name = "Mô tả", Order = 5), DefaultValue("abc"), DataType("1")]
            //public const string MoTa = "MO_TA";

        }
        public static List<FieldInfo> GetParameterConstants(Type type)
        {
            List<FieldInfo> paramters = new List<FieldInfo>();
            foreach (FieldInfo field in type.GetFields())
            {
                paramters.Add(field);
            }
            return paramters;
        }
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()?
           .GetMember(enumValue.ToString())?[0]?
           .GetCustomAttribute<DisplayAttribute>()?
           .Name;
        }
        /// <summary>
        /// loại tài sản
        /// </summary>
        public enum AssetCategoryConstant
        {
            /// <summary>
            /// tài sản công - đất
            /// </summary>
            NpaLand = 21,
            /// <summary>
            /// tài sản công - nhà
            /// </summary>
            NpaHouse,
            /// <summary>
            /// tài sản công - xe
            /// </summary>
            NpaVehicle,
            /// <summary>
            /// tài sản công - khác
            /// </summary>
            NpaOther,
            /// <summary>
            /// tài sản toàn dân - đất
            /// </summary>
            OaLand,
            /// <summary>
            /// tài sản toàn dân - nhà
            /// </summary>
            OaHouse,
            /// <summary>
            /// tài sản toàn dân - xe
            /// </summary>
            OaVehicle,
            /// <summary>
            /// tài sản toàn dân - trên 500M
            /// </summary>
            OaAbove500M,
            /// <summary>
            /// tài sản toàn dân - dưới 500M
            /// </summary>
            OaBelow500M
        }
    }
    public static class Extensions
    {
        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute => enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
    }

}
