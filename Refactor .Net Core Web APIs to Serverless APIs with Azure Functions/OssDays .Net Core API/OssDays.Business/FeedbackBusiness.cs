using OssDays.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OssDays.Utility;
using OssDays.DAL;
namespace OssDays.Business
{
    public class FeedbackBusiness : IFeedbackBusiness
    {
        public FeedbackBusiness()
        {
        }
        public string GetFeedbacks()
        {
            var data = DataAccess.GetFeedback();
            return data;
            
        }

        public Feedback SubmitFeedback(Feedback feedback)
        {
            feedback.FeedbackRating = FeedbackAnalyzer.AnalyzeSentiment(feedback.FeedbackOnProduct);

            EmailHelper.SendEmail(feedback);
            var records = DataAccess.InsertData(feedback);
            return feedback;
        }

    }
}
