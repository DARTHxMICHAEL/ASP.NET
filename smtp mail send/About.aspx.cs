using System;
using EASendMail;

namespace ClearWebsiteASP
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

        /// <summary>
        /// Wysyłanie wiadomosci email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Mail_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("****");

                //adres nadwacy
                oMail.From = "*****************";

                //adres odbiorcy
                oMail.To = "9bitstudio.contact@gmail.com";

                //tytul wiadomosci
                oMail.Subject = "Formularz WebsiteCV z " + DateTime.Now.DayOfYear.ToString();

                //zawratosc wiadomosci
                oMail.TextBody = TextBoxWiad.Text + " od " + TextBoxKont.Text;

                //adres serweras SMTP
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");

                //uwierzytelnianie użytkownika z kontem ze skonfigurowaną aplikacją do
                //obsługi wysyłanie emaili
                oServer.User = "*****************";

                //haslo aplikacji
                oServer.Password = "*****************";

                //domyślny port SSL
                //oServer.Port = 465;

                //uzywamy portu 587
                oServer.Port = 587;

                //wykryj SSL/TLS automatycznie
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                TextBoxWiad.Text = "Wysyłanie wiadomości z wykorzystaniem szyfrowania SSL...";

                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                TextBoxWiad.Text = "Wiadomość wysłana pomyślnie!";
            }
            catch (Exception ex)
            {
                TextBoxWiad.Text = "Błąd przy wysyłaniu formularza: ";
                TextBoxWiad.Text = ex.Message.ToString();
            }
        }

    }
}