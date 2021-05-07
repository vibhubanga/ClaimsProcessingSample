using ClaimsProcessingSample.Application.Models.Chat;
using ClaimsProcessingSample.Application.Responses.Identity;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}