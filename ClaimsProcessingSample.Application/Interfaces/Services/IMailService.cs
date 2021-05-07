using ClaimsProcessingSample.Application.Requests.Mail;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}