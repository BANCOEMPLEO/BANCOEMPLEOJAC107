using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Interfase;
//using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
//using MailKit.Net.Smtp;
//using MailKit;
//using MimeKit;

namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class EnvioCorreoServicio : IEnvioCorreoServicio
    {
        private readonly IEnvioCorreoServicio _envioCorreo;
        public EnvioCorreoServicio(IEnvioCorreoServicio envioCorreo)
        {
                _envioCorreo = envioCorreo;
        }

        public async  Task<bool> Enviar(MensajeCorreoDTO modelo)
        {
            string correo = "hivanr@hotmail.com";
            string pass = "fPNG&i8#7wI6BF8k";

            //var client = new SmtpClient("smtp.live.com", 587)
            //{
            //    UseDefaultCredentials = true,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    Credentials = new NetworkCredential(correo, pass),

            //};
            //ResponseDTO<MensajeCorreoDTO> respuesta = new ResponseDTO<MensajeCorreoDTO>();
            //try
            //{
            //    await client.SendMailAsync(new MailMessage(from: correo.ToString(), to: modelo.Para, "correo prueba", modelo.Mensaje));
            //    respuesta.EsCorrecto = true;
            //}
            //catch (Exception ex)
            //{
            //    //respuesta.EsCorrecto = false;
            //    //respuesta.Mensaje = ex.Message;
            //    return respuesta.Resultado;
            //}
            return true;// respuesta.Resultado;

            //using (SmtpClient client = new())
            //{
            //    try
            //    {
            //        await client.ConnectAsync("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            //        client.AuthenticationMechanisms.Remove("XOAUTH2");

            //        await client.AuthenticateAsync("Your_User_Name", "Your_Password");

            //        await client.SendAsync(mailMessage);
            //    }
            //    catch
            //    {
            //        //log an error message or throw an exception, or both.
            //        throw;
            //    }
            //    finally
            //    {
            //        await client.DisconnectAsync(true);
            //        client.Dispose();
            //    }
            //}
            //return respuesta.Resultado;

            //            var message = new MimeMessage();
            //            message.From.Add(new MailboxAddress("Joey", "joey@friends.com"));
            //            message.To.Add(new MailboxAddress("Alice", "alice@wonderland.com"));
            //            message.Subject = "How you doin?";

            //            message.Body = new TextPart("plain")
            //            {
            //                Text = @"Hey Alice,

            //What are you up to this weekend? Monica is throwing one of her parties on
            //Saturday and I was hoping you could make it.

            //Will you be my +1?

            //-- Joey
            //"
            //            };

            //var email = new MimeMessage();

            //email.From.Add(new MailboxAddress("Sender Name", "sender@email.com"));
            //email.To.Add(new MailboxAddress("Receiver Name", "receiver@email.com"));

            //email.Subject = "Testing out email sending";
            //email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text = "<b>Hello all the way from the land of C#</b>"
            //};

            //using (var smtp = new SmtpClient())
            //{
            //    smtp.Connect("smtp.gmail.com", 587, false);

            //    // Note: only needed if the SMTP server requires authentication
            //    smtp.Authenticate("smtp_username", "smtp_password");

            //    smtp.Send(email);
            //    smtp.Disconnect(true);
            //}
        }
    }
}
