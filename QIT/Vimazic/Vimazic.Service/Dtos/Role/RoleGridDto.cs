using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.TSC.Service.Dtos.Role
{
    public class RoleGridDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsExploitingRole { get; set; }
        
    }
}
