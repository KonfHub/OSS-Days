using OssDays.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OssDays.Business
{
    public interface IFeedbackBusiness
    {
        string GetFeedbacks();

        Feedback SubmitFeedback(Feedback feedback);

    }
}
