using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.TSC.Service.Dtos.Common
{
    public class UnitTreeDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? UnitTypeId { get; set; }
        public int? ParentId { get; set; }
        public bool HasChildren { get; set; }
    }
}
