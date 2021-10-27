using System.Threading.Tasks;

namespace WEB_API.email
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
