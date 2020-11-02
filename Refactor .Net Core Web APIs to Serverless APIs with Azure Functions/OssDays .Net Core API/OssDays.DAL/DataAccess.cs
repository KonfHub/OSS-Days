
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using OssDays.Model;

namespace OssDays.DAL
{
    public class DataAccess
    {
        private static string connectionString = "connection-string-for-your-db";
        public static int InsertData(Feedback feedback)
        {
            int recordsInserted;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = @"INSERT INTO [dbo].[CustomerFeedback]
                                       ([CustomerName]
                                       ,[CustomerEmail]
                                       ,[FeedbackOnProduct]
                                       ,[FeedbackRating]
                                       ,[ProductId]
                                       ,[CreatedOn])
                                 VALUES(@name,@email,@feedback,@feedbackRating,@productId,@createdOn)";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@name", feedback.Name);
                    command.Parameters.AddWithValue("@email", feedback.Email);
                    command.Parameters.AddWithValue("@feedback", feedback.FeedbackOnProduct);
                    command.Parameters.AddWithValue("@feedbackRating", feedback.FeedbackRating);
                    command.Parameters.AddWithValue("@productId", feedback.Product.ProductId);
                    command.Parameters.AddWithValue("@createdOn", feedback.CreatedOn);
                    connection.Open();
                    recordsInserted = command.ExecuteNonQuery();
                }

            }

            return recordsInserted;
        }

        public static string GetFeedback()
        {
            string JsonString = string.Empty;
            //DataTable dt = new DataTable();

            DataTable dt = new DataTable();
            string queryString = "SELECT * from CustomerFeedback";
            List<Feedback> feedbacks = new List<Feedback>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable data = new DataTable())
                        {
                            sda.Fill(data);
                            dt = data;
                        }
                    }
                }
            }
            JsonString = JsonConvert.SerializeObject(dt);
            return JsonString;
        }

    }
}
