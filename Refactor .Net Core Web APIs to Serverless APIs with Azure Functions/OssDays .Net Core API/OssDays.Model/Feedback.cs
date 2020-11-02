using System;
using System.Collections.Generic;
using System.Text;

namespace OssDays.Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FeedbackOnProduct { get; set; }
        public string FeedbackRating { get; set; }
        public Product Product { get; set; }
        public string CreatedOn => DateTime.UtcNow.ToString();

    }
}
