using Azure;
using System;
using System.Globalization;
using Azure.AI.TextAnalytics;

namespace OssDays.Utility
{
    public class FeedbackAnalyzer
    {
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("key");
        private static readonly Uri endpoint = new Uri("endpoint");
        public static string AnalyzeSentiment(string feedback)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(feedback);
            return documentSentiment.Sentiment.ToString();
        }
    }
}
