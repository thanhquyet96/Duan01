using EPS.TSC.Service.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPS.TSC.API.Models
{
    public class AppSetting
    {
        public object ModuleRights { get; set; }
        public List<SelectItem> Genders { get; set; }
        public List<SelectItem> UnitTypes { get; set; }
    }
}
