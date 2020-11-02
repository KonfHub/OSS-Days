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

namespace OssDays.ServerlessAPI
{
    public static class GetFeedbacks
    {
        [FunctionName("GetFeedbacks")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            FeedbackBusiness feedbackBusiness = new FeedbackBusiness();
            var responseMessage = feedbackBusiness.GetFeedbacks();
            return new OkObjectResult(responseMessage);
        }
    }
}
