using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPS.TSC.API.Models
{
    public class ResponseData
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
