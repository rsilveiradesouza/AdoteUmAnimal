using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;

namespace AdoteUmCao.Aplicacao.Utilitarios
{
    public class Email
    {
        private static string urlBase = ConfigurationManager.AppSettings["urlBase"];
        private static string usuario = ConfigurationManager.AppSettings["usuarioEmail"];
        private static string remetenteEmail = ConfigurationManager.AppSettings["nomeEmail"];
        private static string senha = ConfigurationManager.AppSettings["senhaEmail"];
        private static string smtp = ConfigurationManager.AppSettings["servidorSmtp"];
        private static bool ssl = Convert.ToBoolean(ConfigurationManager.AppSettings["sslSmtp"]);
        private static int porta = Convert.ToInt32(ConfigurationManager.AppSettings["portaSmtp"]);

        public static void EnviarEmail(string msg, string email, string subject = "Aviso")
        {
            SmtpClient client = new SmtpClient(smtp, porta)
            {
                Credentials = new NetworkCredential(usuario, senha),
                EnableSsl = ssl
            };

            MailMessage mail = new MailMessage();

            mail.Subject = "Adote um cão - " + subject;

            mail.Body = msg;
            mail.From = new MailAddress(usuario, remetenteEmail);
            mail.To.Add(new MailAddress(email));

            client.Send(mail);
        }
    }
}
