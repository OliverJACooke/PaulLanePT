using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using PaulLanePT.Services.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace PaulLanePT.Services.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public MailConfig MailConfig { get; }

        public HomeController(IOptions<MailConfig> mailConfig)
        {
            MailConfig = mailConfig.Value;
        }

        // Post api/values
        [HttpPost]
        public void Post([FromBody] MailModel message)
        {
            RestClient client = new RestClient();

            client.BaseUrl = new Uri("https://api.mailgun.net/v3");

            client.Authenticator = new HttpBasicAuthenticator("api", MailConfig.MailgunKey);

            RestRequest request = new RestRequest();

            request.AddParameter("domain", "sandbox762ab82aaddd453f82a7d185ecfbe851.mailgun.org", ParameterType.UrlSegment);

            request.Resource = "{domain}/messages";

            request.AddParameter("from", "New Comment <noreply@paullanept.co.uk>");

            request.AddParameter("to", "Oliver Cooke <ocooke@hotmail.com>");

            request.AddParameter("subject", "New Comment");

            request.AddParameter("text", "Name: " + message.Name + " E-Mail: " + message.Email + " Contact Number: " + message.ContactNumber + " Service: " + message.Service + " Message: " + message.Message);

            request.Method = Method.POST;

            var tcs = new TaskCompletionSource<string>();

            client.ExecuteAsync(request, response =>
            {
                tcs.SetResult(response.Content);
            });

        }
    }
}
