using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System;

namespace ST10291856_PROG6212_FinalPOE.Windows
{
    public partial class ProgrammeCoordinators : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPendingClaims();
            }
        }

        protected void LoadPendingClaims()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ClaimID, Name, Email, HoursWorked, HourlyRate, TotalPayment, ModulesTaught, Subject, FilePath, Status FROM LecturerClaims";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvClaims.DataSource = dt;
                        gvClaims.DataBind();
                    }
                    else
                    {
                        gvClaims.DataSource = null;
                        gvClaims.DataBind();
                        lblMessage.Text = "No claims available.";
                        lblMessage.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error loading data: " + ex.Message;
                    lblMessage.Visible = true;
                }
            }
        }


        protected void gvClaims_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;

            if (e.CommandName == "Approve")
            {
                int claimId = Convert.ToInt32(e.CommandArgument);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE LecturerClaims SET Status = 'Approved' WHERE ClaimID = @ClaimID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ClaimID", claimId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        lblMessage.Text = "Claim approved successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Visible = true;

                        // Reload claims after updating
                        LoadPendingClaims();
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Error approving claim: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Visible = true;
                    }
                }
            }
            else if (e.CommandName == "Reject")
            {
                int claimId = Convert.ToInt32(e.CommandArgument);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE LecturerClaims SET Status = 'Rejected' WHERE ClaimID = @ClaimID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ClaimID", claimId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        lblMessage.Text = "Claim rejected successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Visible = true;

                        // Reload claims after updating
                        LoadPendingClaims();
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Error rejecting claim: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Visible = true;
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                int claimId = Convert.ToInt32(e.CommandArgument);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM LecturerClaims WHERE ClaimID = @ClaimID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ClaimID", claimId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Claim deleted successfully.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMessage.Text = "Error: Claim not found or could not be deleted.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }

                        lblMessage.Visible = true;

                        // Reload claims after deletion
                        LoadPendingClaims();
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Error deleting claim: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Visible = true;
                    }
                }
            }
        }

        protected void BindClaims()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ClaimID, Name, Email, HoursWorked, HourlyRate, ModulesTaught, Subject, FilePath, Status FROM LecturerClaims";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gvClaims.DataSource = dt;
                    gvClaims.DataBind();
                }
            }
        }

        protected string GetProgressBarClass(string status)
        {
            switch (status)
            {
                case "Pending":
                    return "progress-pending";
                case "Approved":
                    return "progress-approved";
                case "Rejected":
                    return "progress-rejected";
                default:
                    return "progress-default";
            }
        }

    }
}