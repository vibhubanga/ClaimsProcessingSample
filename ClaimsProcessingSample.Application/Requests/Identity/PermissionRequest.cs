﻿using System.Collections.Generic;

namespace ClaimsProcessingSample.Application.Requests.Identity
{
    public class PermissionRequest
    {
        public string RoleId { get; set; }
        public IList<RoleClaimsRequest> RoleClaims { get; set; }
    }
}