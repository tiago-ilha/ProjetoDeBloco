using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Utilitarios.ServicoEmail
{
    public static class EmailUtil
    {
        public static bool EnviaEmail(string assunto, string de, string para, bool formato, StringBuilder msg, string smtp, string senha)
        {
            try
            {
                var mail = new MailMessage { From = new MailAddress(de) };
                int i;

                var strArray = para.Split(';');
                var f = strArray.GetUpperBound(0);

                for (i = 0; i <= f; i++)
                {
                    mail.To.Add((strArray[i].Trim()));
                }

                mail.Subject = assunto;
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = formato;
                mail.Body = msg.ToString();

                var smtpClient = new SmtpClient(smtp)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(de, senha),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                smtpClient.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
