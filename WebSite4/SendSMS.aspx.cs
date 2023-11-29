using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendSMS : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        SendSMS360Marketing();
    }

    protected void SendSMS360Marketing()
    {
        //to get only un-sent mobile numbers (records which has sentOn column as null)
        DataTable dt = GetMobileNumbers();

        // API endpoint URL
        string baseUrl = "http://164.52.205.46:6005/api/v2/SendSMS";

        // Get http request url parameters
        string senderId = "ITFAST";
        bool isUnicode = false;
        bool isFlash = false;
        string apiKey = "Yf65Pp09pjhMIXlLFpQyhMrRJWDGunJyHV/YwXkrg8U=";
        string clientId = "c6c7b7c0-0576-427d-9d9a-ecbd6c1a5ef5";

        using (HttpClient client = new HttpClient())
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string mobileNumber = dt.Rows[i][1].ToString();
                string message = dt.Rows[i][2].ToString();

                // Construct the full URL with query string parameters
                string fullUrl = $"{baseUrl}?SenderId={senderId}&Is_Unicode={isUnicode}&Is_Flash={isFlash}&Message={Uri.EscapeDataString(message)}&MobileNumbers={mobileNumber}&ApiKey={apiKey}&ClientId={clientId}";

                // Send an HTTP GET request to the API
                HttpResponseMessage response = client.GetAsync(fullUrl).Result;

                if (response.StatusCode.ToString() == "OK")
                {
                    //setting the SetOn column with date and time to know that the SMS has been sent to this numbers
                    UpdateSentOn(mobileNumber);
                }
            }
        }
    }

    protected DataTable GetMobileNumbers()
    {
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        string sql = "SELECT * FROM SMS WHERE SentOn IS NULL";
        SqlCommand cmd = new SqlCommand(sql, con);

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        con.Close();
        return dt;
    }

    protected void UpdateSentOn(string mobileNumber)
    {
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        string sql = "UPDATE SMS SET SentOn = GETDATE() WHERE MobileNumber = @MobileNumber";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}