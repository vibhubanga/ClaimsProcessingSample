using AutoMapper;
using ClaimsProcessingSample.Application.Exceptions;
using ClaimsProcessingSample.Application.Interfaces.Services;
using ClaimsProcessingSample.Application.Interfaces.Services.Identity;
using ClaimsProcessingSample.Application.Models.Chat;
using ClaimsProcessingSample.Application.Responses.Identity;
using ClaimsProcessingSample.Infrastructure.Contexts;
using ClaimsProcessingSample.Shared.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Infrastructure.Services
{
    public class ChatService : IChatService
    {
        private readonly BlazorHeroContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ChatService(BlazorHeroContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId)
        {
            var response = await _userService.GetAsync(userId);
            if (response.Succeeded)
            {
                var user = response.Data;
                var query = await _context.ChatHistories
                    .Where(h => (h.FromUserId == userId && h.ToUserId == contactId) || (h.FromUserId == contactId && h.ToUserId == userId))
                    .OrderBy(a => a.CreatedDate)
                    .Include(a => a.FromUser)
                    .Include(a => a.ToUser)
                    .Select(x => new ChatHistoryResponse
                    {
                        FromUserId = x.FromUserId,
                        FromUserFullName = $"{x.FromUser.FirstName} {x.FromUser.LastName}",
                        Message = x.Message,
                        CreatedDate = x.CreatedDate,
                        Id = x.Id,
                        ToUserId = x.ToUserId,
                        ToUserFullName = $"{x.ToUser.FirstName} {x.ToUser.LastName}",
                        ToUserImageURL = x.ToUser.ProfilePictureDataUrl,
                        FromUserImageURL = x.FromUser.ProfilePictureDataUrl
                    }).ToListAsync();
                return Result<IEnumerable<ChatHistoryResponse>>.Success(query);
            }
            else
            {
                throw new ApiException("User Not Found!");
            }
        }

        public async Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId)
        {
            var allUsers = await _context.Users.Where(user => user.Id != userId).ToListAsync();
            var chatUsers = _mapper.Map<IEnumerable<ChatUserResponse>>(allUsers);
            return Result<IEnumerable<ChatUserResponse>>.Success(chatUsers);
        }

        public async Task<IResult> SaveMessageAsync(ChatHistory message)
        {
            message.ToUser = await _context.Users.Where(user => user.Id == message.ToUserId).FirstOrDefaultAsync();
            await _context.ChatHistories.AddAsync(message);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}