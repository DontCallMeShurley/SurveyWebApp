using System.Net.Mail;
using System.Net;

public sealed class EmailSender
{
    private static readonly EmailSender instance = new EmailSender();
    private EmailSender() { }

    public static EmailSender Instance
    {
        get
        {
            return instance;
        }
    }
    public async Task SendEmail(string toEmail, string password, string fio)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("370716@edu.itmo.ru");
        mail.To.Add(new MailAddress(toEmail));
        mail.Subject = "Успешная регистрация на портале опросников";
        mail.IsBodyHtml = true;
        mail.Body = $"<html><h4>Уважаемый(ая) {fio}!</h4><br>Учётные данные для входа: <br><b>Логин: </b>{toEmail}<br><b>Пароль: </b>{password}</html>";

        SmtpClient client = new SmtpClient();
        client.Host = "smtp.yandex.ru";
        client.Port = 587;
        client.EnableSsl = true;

        await client.SendMailAsync(mail);


    }
}