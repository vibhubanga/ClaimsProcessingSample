using ClaimsProcessingSample.Application.Models.Chat;
using ClaimsProcessingSample.Application.Responses.Identity;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}