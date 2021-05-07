using System.Collections.Generic;

namespace ClaimsProcessingSample.Application.Responses.Identity
{
    public class GetAllRolesResponse
    {
        public IEnumerable<RoleResponse> Roles { get; set; }
    }
}