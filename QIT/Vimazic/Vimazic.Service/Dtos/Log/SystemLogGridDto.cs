using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.TSC.Service.Dtos.Log
{
    public class SystemLogGridDto
    {
        public decimal Id { get; set; }
        public DateTime Date { get; set; }
        public string Origin { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Actor { get; set; }
        public string Action { get; set; }
        public string Data { get; set; }
    }
}
