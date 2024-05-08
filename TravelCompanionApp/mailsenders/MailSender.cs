using System.Net;
using System.Net.Mail;
using TravelCompanionApp.models;

namespace TravelCompanionApp.mailsenders;

public class MailSender
{
    private SmtpClient smtpClient;
    private static string senderEmail = "romatempforjet@gmail.com";
    private readonly ApplicationContext db;
    
    public MailSender(ApplicationContext db)
    {
        this.db = db;
        this.smtpClient = new SmtpClient("smtp.gmail.com");
        smtpClient.Port = 587;
        smtpClient.Credentials = new NetworkCredential("romatempforjet@gmail.com", "ydkl aobk ctcc jloj");
        smtpClient.EnableSsl = true;
    }

    public void sendResponseNotification(Post post, PostResponse postResponse)
    {
        MailMessage mailMessage = new MailMessage(senderEmail, db.Users.Find(post.UserId).Email);
        mailMessage.Body = $"Комментарий: {postResponse.Comment}";
        mailMessage.Subject = $"У вас новый отклик на объявление \\\" {post.Title} \\\" от пользователя {db.Users.Find(postResponse.UserId).Email}\"";
        mailMessage.IsBodyHtml = true;
        smtpClient.Send(mailMessage);
    }
}