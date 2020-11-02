using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OssDays.Business;
using OssDays.Model;

namespace OssDays.ServerlessAPI
{
    public static class SubmitFeedback
    {
        [FunctionName("SubmitFeedback")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject<Feedback>(requestBody);

            FeedbackBusiness feedbackBusiness = new FeedbackBusiness();

            var responseMessage = feedbackBusiness.SubmitFeedback(data); 

            return new OkObjectResult(responseMessage);
        }
    }
}
