using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OssDays.Business;
using OssDays.Model;

namespace OssDays.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBusiness business;
        public FeedbackController(IFeedbackBusiness feedbackBusiness)
        {
            this.business = feedbackBusiness;
        }

        [HttpGet]
        [Route("GetFeedbacks")]
        public ActionResult<string> GetFeedback()
        {
            return this.business.GetFeedbacks();
        }
        [HttpPost]
        [Route("SubmitFeedback")]
        public ActionResult<Feedback> SubmitFeedback(Feedback feedback)
        {
            return this.business.SubmitFeedback(feedback);
        }
    }
}
