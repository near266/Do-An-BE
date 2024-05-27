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


                await _services.SendAsyncV2(rq);
                return Ok(1);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
        [HttpPost("/SendEnterprise")]
        public async Task<IActionResult> EmailSendEnterrpise([FromBody] MailEnterprise rq)
        {


            try
            {
                var str =  $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Email Template</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
        }}
        .container {{
            width: 100%;
            max-width: 600px;
            margin: 0 auto;
            background-color: #ffffff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }}
        .header {{
            text-align: center;
            padding: 10px 0;
        }}
        .header img {{
            max-width: 150px;
        }}
        .content {{
            padding: 20px;
            line-height: 1.6;
        }}
        .content h1 {{
            font-size: 24px;
            margin-bottom: 20px;
        }}
        .content p {{
            font-size: 16px;
            margin-bottom: 20px;
        }}
        .footer {{
            text-align: center;
            padding: 10px 0;
            font-size: 12px;
            color: #888888;
        }}
        .button {{
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            color: #ffffff;
            background-color: #007bff;
            text-decoration: none;
            border-radius: 5px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <img src='{rq.avatar}' alt='Company Logo'>
        </div>
        <div class='content'>
            <h1>Hello, {rq.UserName}!</h1>
            <p>
               Chúng tôi tới từ doanh nghiệp {rq.enterpriseName}
            </p>
            <p>
               Chúng tôi đã xem thông tin ứng tuyển của bạn qua bài viết tuyển dụng của chúng tôi
            </p>
            <p>
               Và thấy bạn phù hợp với  chúng tôi ,Tôi sẽ liên lạc với bạn qua email và số điện thoại bạn đã đăng kí 
            </p>
        </div>
        <div class='footer'>
            <p>
                &copy; 2024 Your Company. All rights reserved.<br>
                1234 Street Address, City, State, Zip
            </p>
        </div>
    </div>
</body>
</html>";
                var req = new EmailSend();
                req.body = str;
                req.to=rq.to;

                await _services.SendAsyncV2(req);
                return Ok(1);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller had problem when running", ex);
            }

        }
    }
}
