using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.TSC.Data.Helpers
{
    public class BulkOracle
    {
        private static IConfiguration configuration;
        static BulkOracle()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }
        private string _connString;

        public BulkOracle(string connName = "TSC")
        {
            _connString = configuration.GetConnectionString(connName);
        }

        public void InsertData<T>(List<T> list, string tableName)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ToDataTable(list);

                using (var connection = new OracleConnection(_connString))
                {
                    connection.Open();

                    // create command and set properties  
                    OracleCommand cmd = connection.CreateCommand();

                    cmd.CommandText = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName
                        , string.Join(",", dt.Columns.OfType<DataColumn>().Select(x => x.ColumnName))
                        , string.Join(",", Enumerable.Range(1, dt.Columns.Count).Select(x => ":" + x)));

                    cmd.ArrayBindCount = dt.Rows.Count;

                    var rows = dt.Rows.OfType<DataRow>();
                    foreach (DataColumn column in dt.Columns)
                    {
                        var parameter = new OracleParameter();
                        parameter.ParameterName = column.ColumnName;

                        if (column.DataType == typeof(int))
                        {
                            parameter.OracleDbType = OracleDbType.Int32;

                            parameter.Value = rows.Select(x => Convert.ToInt32(x[column])).ToArray();
                        }
                        else if (column.DataType == typeof(string))
                        {

                            parameter.OracleDbType = OracleDbType.Varchar2;

                            parameter.Value = rows.Select(x => x[column].ToString()).ToArray();
                        }
                        else if (column.DataType == typeof(string))
                        {

                        }
                        else if (column.DataType == typeof(string))
                        {

                        }
                        else if (column.DataType == typeof(string))
                        {

                        }
                        else if (column.DataType == typeof(string))
                        {

                        }

                        cmd.Parameters.Add(parameter);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void UpdateData<T>(List<T> list, string tableName, string pkName)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt = ToDataTable(list);
        //        dt.PrimaryKey = new DataColumn[] { dt.Columns["pkName"] };
        //        var updateColumns = dt.Columns.OfType<DataColumn>().Where(x => x.ColumnName != pkName).Select(x => x.ColumnName);

        //        using (var connection = new OracleConnection(_connString))
        //        {
        //            connection.Open();

        //            // create command and set properties  
        //            OracleCommand cmd = connection.CreateCommand();

        //            //Creating temp table on database
        //            cmd.CommandText = SqlTableCreator.GetCreateFromDataTableSQL("BulkTempTable", dt);
        //            cmd.ExecuteNonQuery();

        //            try
        //            {
        //                //Bulk insert into temp table
        //                InsertData(list, "BulkTempTable");

        //                // Updating destination table, and dropping temp table
        //                cmd.CommandTimeout = 1800;
        //                cmd.CommandText = "BEGIN UPDATE T SET " + string.Join(",", updateColumns.Select(col => "T." + col + " = Temp." + col)) + " FROM " + tableName + " T INNER JOIN BulkTempTable Temp ON T." + pkName + " = Temp." + pkName + "; END;";
        //                cmd.ExecuteNonQuery();
        //            }
        //            finally
        //            {
        //                cmd.CommandText = "BEGIN DROP TABLE BulkTempTable END;";
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //        public void DeleteData(List<int> listKey, string tableName, string keyName)
        //        {
        //            using (SqlConnection conn = new SqlConnection(_connString))
        //            {
        //                using (SqlCommand command = new SqlCommand("", conn))
        //                {
        //                    try
        //                    {
        //                        conn.Open();

        //                        command.CommandTimeout = 1800;
        //                        command.CommandText = @"
        //WITH _IDS_ AS (
        //SELECT * FROM (VALUES " + string.Join(",", listKey.Select(x => "(" + x + ")")) + @") AS _IDS_ (Id)
        //)
        //DELETE T1
        //    FROM  " + tableName + @" AS T1
        //    INNER JOIN _IDS_ AS T2 ON T1." + keyName + @" = T2.Id
        //";
        //                        command.ExecuteNonQuery();

        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Handle exception properly
        //                        throw ex;
        //                    }
        //                    finally
        //                    {
        //                        conn.Close();
        //                    }
        //                }
        //            }
        //        }

        private DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                var propertyType = Nullable.GetUnderlyingType(
                property.PropertyType) ?? property.PropertyType;
                if (propertyType.IsPrimitive || propertyType == typeof(DateTime) || propertyType == typeof(string) || propertyType == typeof(decimal))
                {
                    dt.Columns.Add(property.Name, propertyType);
                }
            }
            object[] values = new object[dt.Columns.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    values[i] = properties[dt.Columns[i].ColumnName].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
        public void InsertCanBo<T>(List<T> list)
        {
            DataTable dt = new DataTable();
            dt = ToDataTable(list);
            using (var connection = new OracleConnection(_connString))
            {
                try
                {
                    connection.Open();
                    string[] ids = new string[dt.Rows.Count];
                    string[] dvmas = new string[dt.Rows.Count];
                    string[] sohieus = new string[dt.Rows.Count];
                    string[] tenkhaisinhs = new string[dt.Rows.Count];
                    string[] bidanhs = new string[dt.Rows.Count];
                    string[] socmts = new string[dt.Rows.Count];
                    string[] ngaysinhs = new string[dt.Rows.Count];
                    string[] gioitinhs = new string[dt.Rows.Count];
                    string[] noisinhmas = new string[dt.Rows.Count];
                    string[] noisinhs = new string[dt.Rows.Count];
                    string[] nguyenquanmas = new string[dt.Rows.Count];
                    string[] nguyenquans = new string[dt.Rows.Count];
                    string[] hkthuongtrumas = new string[dt.Rows.Count];
                    string[] hkthuongtrus = new string[dt.Rows.Count];
                    string[] noiohiennaymas = new string[dt.Rows.Count];
                    string[] noiohiennays = new string[dt.Rows.Count];
                    string[] dantocmas = new string[dt.Rows.Count];
                    string[] tpgdmas = new string[dt.Rows.Count];
                    string[] tongiaomas = new string[dt.Rows.Count];
                    string[] nguontdmas = new string[dt.Rows.Count];
                    string[] ngaytds = new string[dt.Rows.Count];
                    string[] ngaybcs = new string[dt.Rows.Count];
                    string[] ngaycqunnus = new string[dt.Rows.Count];
                    string[] ngayvaodoans = new string[dt.Rows.Count];
                    string[] cvdoans = new string[dt.Rows.Count];
                    string[] ngaynhapngus = new string[dt.Rows.Count];
                    string[] dvnhapngus = new string[dt.Rows.Count];
                    string[] ngayxuatngus = new string[dt.Rows.Count];
                    string[] dvxuatngus = new string[dt.Rows.Count];
                    string[] cvxuatngus = new string[dt.Rows.Count];
                    string[] capbacxuatngus = new string[dt.Rows.Count];
                    string[] ngaytaingus = new string[dt.Rows.Count];
                    string[] dvtaingus = new string[dt.Rows.Count];
                    string[] ngachmas = new string[dt.Rows.Count];
                    string[] bacluongs = new string[dt.Rows.Count];
                    string[] ngayhuongngachs = new string[dt.Rows.Count];
                    string[] ngayhuongbacs = new string[dt.Rows.Count];
                    string[] ngayxetnls = new string[dt.Rows.Count];
                    string[] tdoptmas = new string[dt.Rows.Count];
                    string[] ngaynhanchucs = new string[dt.Rows.Count];
                    string[] hesopvcvs = new string[dt.Rows.Count];
                    string[] ngayvaocqs = new string[dt.Rows.Count];
                    string[] ngayracqs = new string[dt.Rows.Count];
                    string[] htnghimas = new string[dt.Rows.Count];
                    string[] qdnghis = new string[dt.Rows.Count];
                    string[] versions = new string[dt.Rows.Count];
                    string[] ngaycapcmts = new string[dt.Rows.Count];
                    string[] noicapcmts = new string[dt.Rows.Count];
                    string[] hinhthuctds = new string[dt.Rows.Count];
                    string[] anqps = new string[dt.Rows.Count];
                    string[] tinhtrangccs = new string[dt.Rows.Count];
                    string[] tiengdantocs = new string[dt.Rows.Count];
                    string[] chucdanhs = new string[dt.Rows.Count];
                    string[] machucvus = new string[dt.Rows.Count];
                    string[] machucdanhs = new string[dt.Rows.Count];
                    string[] macanbos = new string[dt.Rows.Count];
                    string[] tens = new string[dt.Rows.Count];
                    string[] mahochams = new string[dt.Rows.Count];
                    string[] actives = new string[dt.Rows.Count];
                    string[] idgocs = new string[dt.Rows.Count];
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        ids[j] = Convert.ToString(dt.Rows[j]["Id"]);
                        dvmas[j] = Convert.ToString(dt.Rows[j]["DV_MA"]);
                        sohieus[j] = Convert.ToString(dt.Rows[j]["SO_HIEU"]);
                        tenkhaisinhs[j] = Convert.ToString(dt.Rows[j]["TEN_KS"]);
                        bidanhs[j] = Convert.ToString(dt.Rows[j]["BI_DANH"]);
                        socmts[j] = Convert.ToString(dt.Rows[j]["SO_CMT"]);
                        var nsinh = Convert.ToString(dt.Rows[j]["NGAY_SINH"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["NGAY_SINH"]).ToString("dd-MMM-yy");
                        ngaysinhs[j] = nsinh;
                        gioitinhs[j] = Convert.ToString(dt.Rows[j]["GIOI_TINH"]);
                        noisinhmas[j] = Convert.ToString(dt.Rows[j]["NOI_SINH_MA"]);
                        noisinhs[j] = Convert.ToString(dt.Rows[j]["NOI_SINH"]);
                        nguyenquanmas[j] = Convert.ToString(dt.Rows[j]["NGUYEN_QUAN_MA"]);
                        nguyenquans[j] = Convert.ToString(dt.Rows[j]["NGUYEN_QUAN"]);
                        hkthuongtrumas[j] = Convert.ToString(dt.Rows[j]["HK_THUONG_TRU_MA"]);
                        hkthuongtrus[j] = Convert.ToString(dt.Rows[j]["HK_THUONG_TRU"]);
                        noiohiennaymas[j] = Convert.ToString(dt.Rows[j]["NOI_O_HIEN_NAY_MA"]);
                        noiohiennays[j] = Convert.ToString(dt.Rows[j]["NOI_O_HIEN_NAY"]);
                        dantocmas[j] = Convert.ToString(dt.Rows[j]["DAN_TOC_MA"]);
                        tpgdmas[j] = Convert.ToString(dt.Rows[j]["TP_GD_MA"]);
                        tongiaomas[j] = Convert.ToString(dt.Rows[j]["TON_GIAO_MA"]);
                        nguontdmas[j] = Convert.ToString(dt.Rows[j]["NGUON_TD_MA"]);
                        ngaytds[j] = Convert.ToString(dt.Rows[j]["NGAY_TD"]);
                        ngaybcs[j] = Convert.ToString(dt.Rows[j]["NGAY_BC"]);
                        ngaycqunnus[j] = Convert.ToString(dt.Rows[j]["NGAY_CQU_NNU"]);
                        ngayvaodoans[j] = Convert.ToString(dt.Rows[j]["NGAY_VAO_DOAN"]);
                        cvdoans[j] = Convert.ToString(dt.Rows[j]["CV_DOAN"]);
                        ngaynhapngus[j] = Convert.ToString(dt.Rows[j]["NGAY_NHAP_NGU"]);
                        dvnhapngus[j] = Convert.ToString(dt.Rows[j]["DV_NHAP_NGU"]);
                        ngayxuatngus[j] = Convert.ToString(dt.Rows[j]["NGAY_XUAT_NGU"]);
                        dvxuatngus[j] = Convert.ToString(dt.Rows[j]["DV_XUAT_NGU"]);
                        cvxuatngus[j] = Convert.ToString(dt.Rows[j]["CV_XUAT_NGU"]);
                        capbacxuatngus[j] = Convert.ToString(dt.Rows[j]["CAP_BAC_XUAT_NGU"]);
                        var ntaingu = Convert.ToString(dt.Rows[j]["NGAY_TAI_NGU"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["NGAY_TAI_NGU"]).ToString("dd-MMM-yy");
                        ngaytaingus[j] = ntaingu;
                        dvtaingus[j] = Convert.ToString(dt.Rows[j]["DV_TAI_NGU"]);
                        ngachmas[j] = Convert.ToString(dt.Rows[j]["NGACH_MA"]);
                        bacluongs[j] = Convert.ToString(dt.Rows[j]["BAC_LUONG"]);
                        var nhuongngach = Convert.ToString(dt.Rows[j]["NGAY_HUONG_NGACH"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["NGAY_HUONG_NGACH"]).ToString("dd-MMM-yy");
                        ngayhuongngachs[j] = nhuongngach;
                        var nhuongbac = Convert.ToString(dt.Rows[j]["NGAY_HUONG_BAC"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["NGAY_HUONG_BAC"]).ToString("dd-MMM-yy");
                        ngayhuongbacs[j] = nhuongbac;
                        var nxetnl = Convert.ToString(dt.Rows[j]["NGAY_XET_NL"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["NGAY_XET_NL"]).ToString("dd-MMM-yy");
                        ngayxetnls[j] = nxetnl;
                        tdoptmas[j] = Convert.ToString(dt.Rows[j]["TDO_PT_MA"]);
                        var nnhanchuc = Convert.ToString(dt.Rows[j]["NGAY_NHAN_CHUC"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["NGAY_NHAN_CHUC"]).ToString("dd-MMM-yy");
                        ngaynhanchucs[j] = nnhanchuc;
                        hesopvcvs[j] = Convert.ToString(dt.Rows[j]["HE_SO_PC_CV"]);
                        ngayvaocqs[j] = Convert.ToString(dt.Rows[j]["NGAY_VAO_CQ"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["NGAY_VAO_CQ"]).ToString("dd-MMM-yy");
                        ngayracqs[j] = Convert.ToString(dt.Rows[j]["NGAY_RA_CQ"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["NGAY_RA_CQ"]).ToString("dd-MMM-yy");
                        htnghimas[j] = Convert.ToString(dt.Rows[j]["HT_NGHI_MA"]);
                        qdnghis[j] = Convert.ToString(dt.Rows[j]["QD_NGHI"]);
                        versions[j] = Convert.ToString(dt.Rows[j]["VERSION"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["VERSION"]).ToString("dd-MMM-yy");
                        ngaycapcmts[j] = Convert.ToString(dt.Rows[j]["NGAY_CAP_CMT"]) == "" ? "" : Convert.ToDateTime(dt.Rows[j]["NGAY_CAP_CMT"]).ToString("dd-MMM-yy");
                        noicapcmts[j] = Convert.ToString(dt.Rows[j]["NOI_CAP_CMT"]);
                        hinhthuctds[j] = Convert.ToString(dt.Rows[j]["HINH_THUC_TD"]);
                        anqps[j] = Convert.ToString(dt.Rows[j]["AN_QP"]);
                        tinhtrangccs[j] = Convert.ToString(dt.Rows[j]["TINH_TRANG_CC"]);
                        tiengdantocs[j] = Convert.ToString(dt.Rows[j]["TIENG_DAN_TOC"]);
                        chucdanhs[j] = Convert.ToString(dt.Rows[j]["CHUC_DANH"]);
                        machucvus[j] = Convert.ToString(dt.Rows[j]["MA_CHUC_VU"]);
                        machucdanhs[j] = Convert.ToString(dt.Rows[j]["MA_CHUC_DANH"]);
                        macanbos[j] = Convert.ToString(dt.Rows[j]["MA_CAN_BO"]);
                        tens[j] = Convert.ToString(dt.Rows[j]["TEN"]);
                        mahochams[j] = Convert.ToString(dt.Rows[j]["MA_HOC_HAM"]);
                        actives[j] = Convert.ToString(dt.Rows[j]["DEACTIVE"]);
                        idgocs[j] = Convert.ToString(dt.Rows[j]["ID_GOC"]);
                    }
                    #region set parameter
                    OracleParameter id = new OracleParameter();
                    id.OracleDbType = OracleDbType.Varchar2;
                    id.Value = ids;

                    OracleParameter donvima = new OracleParameter();
                    donvima.OracleDbType = OracleDbType.Varchar2;
                    donvima.Value = dvmas;

                    OracleParameter sohieu = new OracleParameter();
                    sohieu.OracleDbType = OracleDbType.Varchar2;
                    sohieu.Value = sohieus;

                    OracleParameter tenks = new OracleParameter();
                    tenks.OracleDbType = OracleDbType.Varchar2;
                    tenks.Value = tenkhaisinhs;

                    OracleParameter bidanh = new OracleParameter();
                    bidanh.OracleDbType = OracleDbType.Varchar2;
                    bidanh.Value = bidanhs;

                    OracleParameter socmt = new OracleParameter();
                    socmt.OracleDbType = OracleDbType.Varchar2;
                    socmt.Value = socmts;

                    OracleParameter ngaysinh = new OracleParameter();
                    ngaysinh.OracleDbType = OracleDbType.Varchar2;
                    ngaysinh.Value = ngaysinhs;

                    OracleParameter gioitinh = new OracleParameter();
                    gioitinh.OracleDbType = OracleDbType.Varchar2;
                    gioitinh.Value = gioitinhs;

                    OracleParameter noisinhma = new OracleParameter();
                    noisinhma.OracleDbType = OracleDbType.Varchar2;
                    noisinhma.Value = noisinhmas;

                    OracleParameter noisinh = new OracleParameter();
                    noisinh.OracleDbType = OracleDbType.Varchar2;
                    noisinh.Value = noisinhs;

                    OracleParameter nguyenquanma = new OracleParameter();
                    nguyenquanma.OracleDbType = OracleDbType.Varchar2;
                    nguyenquanma.Value = nguyenquanmas;
                    OracleParameter nguyenquan = new OracleParameter();
                    nguyenquan.OracleDbType = OracleDbType.Varchar2;
                    nguyenquan.Value = nguyenquans;
                    OracleParameter hkthuongtruma = new OracleParameter();
                    hkthuongtruma.OracleDbType = OracleDbType.Varchar2;
                    hkthuongtruma.Value = hkthuongtrumas;
                    OracleParameter hkthuongtru = new OracleParameter();
                    hkthuongtru.OracleDbType = OracleDbType.Varchar2;
                    hkthuongtru.Value = hkthuongtrus;
                    OracleParameter noiohiennayma = new OracleParameter();
                    noiohiennayma.OracleDbType = OracleDbType.Varchar2;
                    noiohiennayma.Value = noiohiennaymas;
                    OracleParameter noiohiennay = new OracleParameter();
                    noiohiennay.OracleDbType = OracleDbType.Varchar2;
                    noiohiennay.Value = noiohiennays;
                    OracleParameter dantocma = new OracleParameter();
                    dantocma.OracleDbType = OracleDbType.Varchar2;
                    dantocma.Value = dantocmas;
                    OracleParameter tpgdma = new OracleParameter();
                    tpgdma.OracleDbType = OracleDbType.Varchar2;
                    tpgdma.Value = tpgdmas;
                    OracleParameter tongiaoma = new OracleParameter();
                    tongiaoma.OracleDbType = OracleDbType.Varchar2;
                    tongiaoma.Value = tongiaomas;
                    OracleParameter nguontdma = new OracleParameter();
                    nguontdma.OracleDbType = OracleDbType.Varchar2;
                    nguontdma.Value = nguontdmas;
                    OracleParameter ngaytd = new OracleParameter();
                    ngaytd.OracleDbType = OracleDbType.Varchar2;
                    ngaytd.Value = ngaytds;

                    OracleParameter ngaybc = new OracleParameter();
                    ngaybc.OracleDbType = OracleDbType.Varchar2;
                    ngaybc.Value = ngaybcs;
                    OracleParameter ngaycqunnu = new OracleParameter();
                    ngaycqunnu.OracleDbType = OracleDbType.Varchar2;
                    ngaycqunnu.Value = ngaycqunnus;
                    OracleParameter ngayvaodoan = new OracleParameter();
                    ngayvaodoan.OracleDbType = OracleDbType.Varchar2;
                    ngayvaodoan.Value = ngayvaodoans;
                    OracleParameter cvdoan = new OracleParameter();
                    cvdoan.OracleDbType = OracleDbType.Varchar2;
                    cvdoan.Value = cvdoans;
                    OracleParameter ngaynhapngu = new OracleParameter();
                    ngaynhapngu.OracleDbType = OracleDbType.Varchar2;
                    ngaynhapngu.Value = ngaynhapngus;
                    OracleParameter dvnhapngu = new OracleParameter();
                    dvnhapngu.OracleDbType = OracleDbType.Varchar2;
                    dvnhapngu.Value = dvnhapngus;
                    OracleParameter ngayxuatngu = new OracleParameter();
                    ngayxuatngu.OracleDbType = OracleDbType.Varchar2;
                    ngayxuatngu.Value = ngayxuatngus;
                    OracleParameter dvxuatngu = new OracleParameter();
                    dvxuatngu.OracleDbType = OracleDbType.Varchar2;
                    dvxuatngu.Value = dvxuatngus;
                    OracleParameter cvxuatngu = new OracleParameter();
                    cvxuatngu.OracleDbType = OracleDbType.Varchar2;
                    cvxuatngu.Value = cvxuatngus;
                    OracleParameter capbacxuatngu = new OracleParameter();
                    capbacxuatngu.OracleDbType = OracleDbType.Varchar2;
                    capbacxuatngu.Value = capbacxuatngus;
                    OracleParameter ngaytaingu = new OracleParameter();
                    ngaytaingu.OracleDbType = OracleDbType.Varchar2;
                    ngaytaingu.Value = ngaytaingus;
                    OracleParameter dvtaingu = new OracleParameter();
                    dvtaingu.OracleDbType = OracleDbType.Varchar2;
                    dvtaingu.Value = dvtaingus;
                    OracleParameter ngachma = new OracleParameter();
                    ngachma.OracleDbType = OracleDbType.Varchar2;
                    ngachma.Value = ngachmas;
                    OracleParameter bacluong = new OracleParameter();
                    bacluong.OracleDbType = OracleDbType.Varchar2;
                    bacluong.Value = bacluongs;
                    OracleParameter ngayhuongngach = new OracleParameter();
                    ngayhuongngach.OracleDbType = OracleDbType.Varchar2;
                    ngayhuongngach.Value = ngayhuongngachs;
                    OracleParameter ngayhuongbac = new OracleParameter();
                    ngayhuongbac.OracleDbType = OracleDbType.Varchar2;
                    ngayhuongbac.Value = ngayhuongbacs;
                    OracleParameter ngayxetnl = new OracleParameter();
                    ngayxetnl.OracleDbType = OracleDbType.Varchar2;
                    ngayxetnl.Value = ngayxetnls;
                    OracleParameter tdoptma = new OracleParameter();
                    tdoptma.OracleDbType = OracleDbType.Varchar2;
                    tdoptma.Value = tdoptmas;
                    OracleParameter ngaynhanchuc = new OracleParameter();
                    ngaynhanchuc.OracleDbType = OracleDbType.Varchar2;
                    ngaynhanchuc.Value = ngaynhanchucs;
                    OracleParameter hesopvcv = new OracleParameter();
                    hesopvcv.OracleDbType = OracleDbType.Varchar2;
                    hesopvcv.Value = hesopvcvs;
                    OracleParameter ngayvaocq = new OracleParameter();
                    ngayvaocq.OracleDbType = OracleDbType.Varchar2;
                    ngayvaocq.Value = ngayvaocqs;
                    OracleParameter ngayracq = new OracleParameter();
                    ngayracq.OracleDbType = OracleDbType.Varchar2;
                    ngayracq.Value = ngayracqs;

                    OracleParameter htnghima = new OracleParameter();
                    htnghima.OracleDbType = OracleDbType.Varchar2;
                    htnghima.Value = htnghimas;
                    OracleParameter qdnghi = new OracleParameter();
                    qdnghi.OracleDbType = OracleDbType.Varchar2;
                    qdnghi.Value = qdnghis;
                    OracleParameter version = new OracleParameter();
                    version.OracleDbType = OracleDbType.Varchar2;
                    version.Value = versions;

                    OracleParameter ngaycapcmt = new OracleParameter();
                    ngaycapcmt.OracleDbType = OracleDbType.Varchar2;
                    ngaycapcmt.Value = ngaycapcmts;
                    OracleParameter noicapcmt = new OracleParameter();
                    noicapcmt.OracleDbType = OracleDbType.Varchar2;
                    noicapcmt.Value = noicapcmts;
                    OracleParameter hinhthuctd = new OracleParameter();
                    hinhthuctd.OracleDbType = OracleDbType.Varchar2;
                    hinhthuctd.Value = hinhthuctds;

                    OracleParameter anqp = new OracleParameter();
                    anqp.OracleDbType = OracleDbType.Varchar2;
                    anqp.Value = anqps;
                    OracleParameter tinhtrangcc = new OracleParameter();
                    tinhtrangcc.OracleDbType = OracleDbType.Varchar2;
                    tinhtrangcc.Value = tinhtrangccs;

                    OracleParameter tiengdantoc = new OracleParameter();
                    tiengdantoc.OracleDbType = OracleDbType.Varchar2;
                    tiengdantoc.Value = tiengdantocs;

                    OracleParameter chucdanh = new OracleParameter();
                    chucdanh.OracleDbType = OracleDbType.Varchar2;
                    chucdanh.Value = chucdanhs;

                    OracleParameter machucvu = new OracleParameter();
                    machucvu.OracleDbType = OracleDbType.Varchar2;
                    machucvu.Value = machucvus;

                    OracleParameter machucdanh = new OracleParameter();
                    machucdanh.OracleDbType = OracleDbType.Varchar2;
                    machucdanh.Value = machucdanhs;

                    OracleParameter macanbo = new OracleParameter();
                    macanbo.OracleDbType = OracleDbType.Varchar2;
                    macanbo.Value = macanbos;

                    OracleParameter ten = new OracleParameter();
                    ten.OracleDbType = OracleDbType.Varchar2;
                    ten.Value = tens;

                    OracleParameter mahocham = new OracleParameter();
                    mahocham.OracleDbType = OracleDbType.Varchar2;
                    mahocham.Value = mahochams;

                    OracleParameter active = new OracleParameter();
                    active.OracleDbType = OracleDbType.Varchar2;
                    active.Value = actives;

                    OracleParameter idgoc = new OracleParameter();
                    idgoc.OracleDbType = OracleDbType.Varchar2;
                    idgoc.Value = idgocs;

                    #endregion
                    // create command and set properties  
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO CAN_BO (\"ID\",\"DV_MA\",\"SO_HIEU\",\"TEN_KS\",\"BI_DANH\",\"SO_CMT\",\"NGAY_SINH\",\"GIOI_TINH\",\"NOI_SINH_MA\",\"NOI_SINH\",\"NGUYEN_QUAN_MA\",\"NGUYEN_QUAN\",\"HK_THUONG_TRU_MA\",\"HK_THUONG_TRU\",\"NOI_O_HIEN_NAY_MA\",\"NOI_O_HIEN_NAY\",\"DAN_TOC_MA\",\"TP_GD_MA\",\"TON_GIAO_MA\",\"NGUON_TD_MA\",\"NGAY_TD\",\"NGAY_BC\",\"NGAY_CQU_NNU\",\"NGAY_VAO_DOAN\",\"CV_DOAN\",\"NGAY_NHAP_NGU\",\"DV_NHAP_NGU\",\"NGAY_XUAT_NGU\",\"DV_XUAT_NGU\",\"CV_XUAT_NGU\",\"CAP_BAC_XUAT_NGU\",\"NGAY_TAI_NGU\",\"DV_TAI_NGU\",\"NGACH_MA\",\"BAC_LUONG\",\"NGAY_HUONG_NGACH\",\"NGAY_HUONG_BAC\",\"NGAY_XET_NL\",\"TDO_PT_MA\",\"NGAY_NHAN_CHUC\",\"HE_SO_PC_CV\",\"NGAY_VAO_CQ\",\"NGAY_RA_CQ\",\"HT_NGHI_MA\",\"QD_NGHI\",\"VERSION\",\"NGAY_CAP_CMT\",\"NOI_CAP_CMT\",\"HINH_THUC_TD\",\"AN_QP\",\"TINH_TRANG_CC\",\"TIENG_DAN_TOC\",\"CHUC_DANH\",\"MA_CHUC_VU\",\"MA_CHUC_DANH\",\"MA_CAN_BO\",\"TEN\",\"MA_HOC_HAM\",\"ACTIVE\",\"ID_GOC\") VALUES (:1, :2, :3,:4,:5,:6,:7,:8,:9,:10,:11,:12,:13,:14,:15,:16,:17,:18,:19,:20,:21,:22,:23,:24,:25,:26,:27,:28,:29,:30,:31,:32,:33,:34,:35,:36,:37,:38,:39,:40,:41,:42,:43,:44,:45,:46,:47,:48,:49,:50,:51,:52,:53,:54,:55,:56,:57,:58,:59,:60)";
                    cmd.ArrayBindCount = ids.Length;
                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(donvima);
                    cmd.Parameters.Add(sohieu);
                    cmd.Parameters.Add(tenks);
                    cmd.Parameters.Add(bidanh);
                    cmd.Parameters.Add(socmt);
                    cmd.Parameters.Add(ngaysinh);
                    cmd.Parameters.Add(gioitinh);
                    cmd.Parameters.Add(noisinhma);
                    cmd.Parameters.Add(noisinh);
                    cmd.Parameters.Add(nguyenquanma);
                    cmd.Parameters.Add(nguyenquan);
                    cmd.Parameters.Add(hkthuongtruma);
                    cmd.Parameters.Add(hkthuongtru);
                    cmd.Parameters.Add(noiohiennayma);
                    cmd.Parameters.Add(noiohiennay);
                    cmd.Parameters.Add(dantocma);
                    cmd.Parameters.Add(tpgdma);
                    cmd.Parameters.Add(tongiaoma);
                    cmd.Parameters.Add(nguontdma);
                    cmd.Parameters.Add(ngaytd);
                    cmd.Parameters.Add(ngaybc);
                    cmd.Parameters.Add(ngaycqunnu);
                    cmd.Parameters.Add(ngayvaodoan);
                    cmd.Parameters.Add(cvdoan);
                    cmd.Parameters.Add(ngaynhapngu);
                    cmd.Parameters.Add(dvnhapngu);
                    cmd.Parameters.Add(ngayxuatngu);
                    cmd.Parameters.Add(dvxuatngu);
                    cmd.Parameters.Add(cvxuatngu);
                    cmd.Parameters.Add(capbacxuatngu);
                    cmd.Parameters.Add(ngaytaingu);
                    cmd.Parameters.Add(dvtaingu);
                    cmd.Parameters.Add(ngachma);
                    cmd.Parameters.Add(bacluong);
                    cmd.Parameters.Add(ngayhuongngach);
                    cmd.Parameters.Add(ngayhuongbac);
                    cmd.Parameters.Add(ngayxetnl);
                    cmd.Parameters.Add(tdoptma);
                    cmd.Parameters.Add(ngaynhanchuc);
                    cmd.Parameters.Add(hesopvcv);
                    cmd.Parameters.Add(ngayvaocq);
                    cmd.Parameters.Add(ngayracq);
                    cmd.Parameters.Add(htnghima);
                    cmd.Parameters.Add(qdnghi);
                    cmd.Parameters.Add(version);
                    cmd.Parameters.Add(ngaycapcmt);
                    cmd.Parameters.Add(noicapcmt);
                    cmd.Parameters.Add(hinhthuctd);
                    cmd.Parameters.Add(anqp);
                    cmd.Parameters.Add(tinhtrangcc);
                    cmd.Parameters.Add(tiengdantoc);
                    cmd.Parameters.Add(chucdanh);
                    cmd.Parameters.Add(machucvu);
                    cmd.Parameters.Add(machucdanh);
                    cmd.Parameters.Add(macanbo);
                    cmd.Parameters.Add(ten);
                    cmd.Parameters.Add(mahocham);
                    cmd.Parameters.Add(active);
                    cmd.Parameters.Add(idgoc);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }


    public class SqlTableCreator
    {
        public static string GetCreateFromDataTableSQL(string tableName, DataTable table)
        {
            string sql = "CREATE GLOBAL TEMPORARY TABLE " + tableName + " (\n";
            // columns
            foreach (DataColumn column in table.Columns)
            {
                sql += column.ColumnName + " " + SQLGetType(column) + ",\n";
            }
            sql = sql.TrimEnd(new char[] { ',', '\n' }) + "\n";
            // primary keys
            if (table.PrimaryKey.Length > 0)
            {
                sql += "CONSTRAINT PK_" + tableName + " PRIMARY KEY CLUSTERED (";
                foreach (DataColumn column in table.PrimaryKey)
                {
                    sql += column.ColumnName + ",";
                }
                sql = sql.TrimEnd(new char[] { ',' }) + "))\n";
            }
            else
            {
                sql = sql.TrimEnd(new char[] { ',' }) + ")\n";
            }

            return sql;
        }

        public static string[] GetPrimaryKeys(DataTable schema)
        {
            List<string> keys = new List<string>();

            foreach (DataRow column in schema.Rows)
            {
                if (schema.Columns.Contains("IsKey") && (bool)column["IsKey"])
                    keys.Add(column["ColumnName"].ToString());
            }

            return keys.ToArray();
        }

        // Return T-SQL data type definition, based on schema definition for a column
        public static string SQLGetType(object type, int columnSize, int numericPrecision, int numericScale)
        {
            switch (type.ToString())
            {
                case "System.String":
                    return "VARCHAR(" + ((columnSize == -1) ? 255 : columnSize) + ")";

                case "System.Decimal":
                    if (numericScale > 0)
                        return "NUMBER(18,4)";
                    else if (numericPrecision > 10)
                        return "NUMBER(18,0)";
                    else
                        return "NUMBER(10,0)";

                case "System.Double":
                case "System.Single":
                    return "NUMBER(18,4)";

                case "System.Int64":
                    return "NUMBER(18,0)";

                case "System.Int16":
                case "System.Int32":
                    return "NUMBER(10,0)";

                case "System.DateTime":
                    return "DATETIME";
                case "System.Boolean":
                    return "NUMBER(1,0)";

                default:
                    throw new ApplicationException(type.ToString() + " not implemented.");
            }
        }

        // Overload based on row from schema table
        public static string SQLGetType(DataRow schemaRow)
        {
            return SQLGetType(schemaRow["DataType"],
                                int.Parse(schemaRow["ColumnSize"].ToString()),
                                int.Parse(schemaRow["NumericPrecision"].ToString()),
                                int.Parse(schemaRow["NumericScale"].ToString()));
        }

        // Overload based on DataColumn from DataTable type
        public static string SQLGetType(DataColumn column)
        {
            return SQLGetType(column.DataType, column.MaxLength, 10, 2);
        }
    }
}
