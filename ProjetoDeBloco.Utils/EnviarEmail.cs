using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Utils
{
    public static class EnviarEmail
    {
        public static void Enviar(string emailDestinatario, string assunto, string mensagem)
        {
            string remetente = ConfigurationManager.AppSettings["Email"];
            string senhaRemetente = ConfigurationManager.AppSettings["SenhaEmail"];

            //Cria o endereço de email do remetente
            MailAddress de = new MailAddress(remetente);

            //Cria o endereço de email do destinatário -->
            MailAddress para = new MailAddress(emailDestinatario);

            MailMessage email = new MailMessage(de, para);
            email.IsBodyHtml = true;

            //Assunto do email
            email.Subject = assunto;

            email.Body = mensagem;

            //Cria o objeto que envia o e-mail
            SmtpClient cliente = new SmtpClient();

            cliente.Credentials = new NetworkCredential(remetente, senhaRemetente);

            try
            {
                cliente.Send(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
