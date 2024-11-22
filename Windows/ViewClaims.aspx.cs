using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace ST10291856_PROG6212_FinalPOE.Windows
{
    public partial class ViewClaims : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPendingClaims();
            }
        }

        private void LoadPendingClaims()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ClaimID, Name, Email, HoursWorked, HourlyRate, ModulesTaught, Subject FROM LecturerClaims WHERE Status = 'Pending'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                RepeaterClaims.DataSource = dt;
                RepeaterClaims.DataBind();
            }
        }

        protected void ApproveClaim(object sender, CommandEventArgs e)
        {
            int claimId = Convert.ToInt32(e.CommandArgument);
            UpdateClaimStatus(claimId, "Approved");
        }

        protected void RejectClaim(object sender, CommandEventArgs e)
        {
            int claimId = Convert.ToInt32(e.CommandArgument);
            UpdateClaimStatus(claimId, "Rejected");
        }

        private void UpdateClaimStatus(int claimId, string status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE LecturerClaims SET Status = @Status WHERE ClaimID = @ClaimID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@ClaimID", claimId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            LoadPendingClaims(); // Refresh the claims list
        }
    }
}