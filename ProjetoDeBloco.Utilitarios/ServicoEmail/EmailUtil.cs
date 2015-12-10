using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Utilitarios.ServicoEmail
{
    public static class EmailUtil
    {
        public static void EnviarEmail(string para, string assunto, string corpo)
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("projetodeblocoinfnet@gmail.com");
            mail.To.Add(para);
            mail.Subject = assunto;
            mail.Body = corpo;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Send(mail);
        }
    }
}
