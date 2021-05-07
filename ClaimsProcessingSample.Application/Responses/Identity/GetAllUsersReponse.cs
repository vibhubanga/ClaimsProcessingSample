using System.Collections.Generic;

namespace ClaimsProcessingSample.Application.Responses.Identity
{
    public class GetAllUsersReponse
    {
        public IEnumerable<UserResponse> Users { get; set; }
    }
}