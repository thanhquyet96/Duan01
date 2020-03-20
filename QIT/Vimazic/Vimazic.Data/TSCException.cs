using EPS.Utils.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EPS.TSC.Data
{
    public class TSCException : ApplicationException
    {
        public TSCException(TSCExceptionCode code, params object[] args) : base(string.Format(code.GetEnumDescription(), args)) { }

        public TSCException(string message) : base(message) { }
    }

    public enum TSCExceptionCode
    {
        [Description("Không thể xóa {0} do có dữ liệu liên quan.")]
        DeleteRecordWithRelatedData = 1
    }
}
