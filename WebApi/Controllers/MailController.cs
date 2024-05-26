using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using WebApi.Application.Command.JobC;
using WebApi.Modules.Email.Interface;
using WebApi.Modules.Email.Services;
using WebApi.Wrappers.DTOS.EmailDtos;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailServices _services;
       
        public MailController(IEmailServices services)
        {
            _services = services;
           
        }
        [HttpPost("/Send")]
        public async Task<IActionResult> EmailSend([FromBody] EmailSend rq)
        {
            

            try
            {
              
                var emailRequest = new EmailRequest()
                {
                    Body = rq.body,
                    To = rq.to,
                    Subject = "Reset-Pass",
                   
                };
                await  _services.SendAsync(emailRequest);
                return Ok(1);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        [HttpPost("/SendV2")]
        public async Task<IActionResult> EmailSendV2([FromBody] EmailSend rq)
        {


            try
            {

             
                string fromMail = "thedotnetchannelsender22@gmail.com";
                string fromPassword = "lgioehkvchemfkrw";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = rq.Sub;
                message.To.Add(new MailAddress(rq.to));
                message.Body = $"<html><body>{rq.body}  </body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
                return Ok(1);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
    }
}
