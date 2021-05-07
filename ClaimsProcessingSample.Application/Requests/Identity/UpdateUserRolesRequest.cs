using ClaimsProcessingSample.Application.Responses.Identity;
using System.Collections.Generic;

namespace ClaimsProcessingSample.Application.Requests.Identity
{
    public class UpdateUserRolesRequest
    {
        public string UserId { get; set; }
        public IList<UserRoleModel> UserRoles { get; set; }
    }
}