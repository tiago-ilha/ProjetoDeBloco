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
        public static void EnviarEmail(string para, string assunto, string corpo)
        {
             try
        {
            //Mensagem
            MailMessage message = new MailMessage();
 
            //Estes 2 campos corresponde a quem está enviando o e-mail
            
            message.From = new MailAddress("projetodeblocoinfnet@gmail.com");
 
            //Aqui você coloca para quem você quer enviar o e-mail
            message.To.Add(new MailAddress(para));
 
            //Aqui você coloca o assunto
            message.Subject = "Teste de e-mail";
 
            //E aqui você coloca o corpo do e-mail
            message.Body = "Hello <strong>world</strong>.";
 
            //Se o corpo do e-mail for HTML, coloque o IsBodyHtml = true, caso contrário, = false
            message.IsBodyHtml = true;
 
            //Smtp
            SmtpClient smtp = new SmtpClient();
 
            //Aqui você coloca seu usuário e senha
            smtp.Credentials = new NetworkCredential("projetodeblocoinfnet@gmail.com", "86724022");
 
            //Caso o servidor tenha SSL, habilite utilizando true (gmail usa ssl e meu teste foi com gmail)
            smtp.EnableSsl = true;
 
            //Aqui é o endereço do SMTP
            smtp.Host = "smtp.gmail.com";
 
            //E a porta utilizada para conexão
            smtp.Port = 587;
 
            //Envia o e-mail :)
            smtp.Send(message);
 
            //Firula só pra saber que enviamos
            System.Console.WriteLine("OK");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        Console.ReadKey();


            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.EnableSsl = true;

            //MailAddress remetente = new MailAddress("projetodeblocoinfnet@gmail.com", "Infnet - Projeto de Bloco");
            //MailAddress destinatario = new MailAddress(para);

            //MailMessage email = new MailMessage(remetente, destinatario);
            //email.Subject = assunto;
            //email.Body = corpo;

            //using (var smtp = new SmtpClient("smtp.gmail.com"))
            //{
            //    smtp.EnableSsl = true; // GMail requer SSL
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;       // porta para SSL
            //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
            //    smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas
            //    // seu usuário e senha para autenticação
            //    smtp.Credentials = new NetworkCredential("projetodeblocoinfnet@gmail.com", "86724022");

            //    // envia o e-mail
            //    smtp.Send(email);
            //}
        }
    }
}
