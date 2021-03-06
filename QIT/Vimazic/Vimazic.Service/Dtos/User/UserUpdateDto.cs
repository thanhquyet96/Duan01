﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.TSC.Service.Dtos.User
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UnitId { get; set; }
        public List<int> RoleIds { get; set; }
        public string NewPassword { get; set; }
    }
}
