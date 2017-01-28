using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using PaulLanePT.Services.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace PaulLanePT.Services.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public MailConfig MailConfig { get; }

        // GET api/values
        [HttpGet]
        public void Get()
        {
            RestClient client = new RestClient();

            client.BaseUrl = new Uri("https://api.mailgun.net/v3");

            client.Authenticator = new HttpBasicAuthenticator("api", MailConfig.MailgunKey);

            RestRequest request = new RestRequest();

            request.AddParameter("domain", "paullanept.co.uk", ParameterType.UrlSegment);

            request.Resource = "{domain}/messages";

            request.AddParameter("from", "New Comment <noreply@paullanept.co.uk>");

            request.AddParameter("to", "Oliver Cooke <ocooke@hotmail.com>");

            request.AddParameter("subject", "New Comment");

            request.AddParameter("text", "Congratulations Oliver Cooke, you just sent an email with Mailgun!  You are truly awesome!  You can see a record of this email in your logs: https://mailgun.com/cp/log .  You can send up to 300 emails/day from this sandbox server.  Next, you should add your own domain so you can send 10,000 emails/month for free.");

            request.Method = Method.POST;

            var tcs = new TaskCompletionSource<string>();

            client.ExecuteAsync(request, response => {
                tcs.SetResult(response.Content);
            });
            
        }
    }
}
