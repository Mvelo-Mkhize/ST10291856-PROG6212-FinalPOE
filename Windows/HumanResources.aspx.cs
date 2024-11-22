using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ST10291856_PROG6212_FinalPOE.Windows
{
    public partial class HumanResources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClaims();
            }
        }

        private void LoadClaims()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ClaimID, Name, Email, HoursWorked, HourlyRate, TotalPayment, ModulesTaught, Subject FROM LecturerClaims";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                adapter.Fill(dt);
                gvClaims.DataSource = dt;
                gvClaims.DataBind();
            }
        }

        protected void gvClaims_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int claimId = Convert.ToInt32(e.CommandArgument);
                LoadClaimDetails(claimId);
            }
        }

        private void LoadClaimDetails(int claimId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LecturerClaims WHERE ClaimID = @ClaimID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClaimID", claimId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    hfClaimID.Value = reader["ClaimID"].ToString();
                    txtName.Text = reader["Name"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtHours.Text = reader["HoursWorked"].ToString();
                    txtRate.Text = reader["HourlyRate"].ToString();
                    pnlEditClaim.Visible = true;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE LecturerClaims SET Name = @Name, Email = @Email, HoursWorked = @HoursWorked, HourlyRate = @HourlyRate WHERE ClaimID = @ClaimID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClaimID", hfClaimID.Value);
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@HoursWorked", int.Parse(txtHours.Text));
                command.Parameters.AddWithValue("@HourlyRate", decimal.Parse(txtRate.Text));

                connection.Open();
                command.ExecuteNonQuery();
                lblMessage.Text = "Claim updated successfully.";
                lblMessage.Visible = true;

                LoadClaims();
                pnlEditClaim.Visible = false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlEditClaim.Visible = false;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportClaimsAsInvoice();
        }

        private void ExportClaimsAsInvoice()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ClaimID, Name, Email, HoursWorked, HourlyRate, TotalPayment, ModulesTaught, Subject FROM LecturerClaims";
                SqlCommand command = new SqlCommand(query, connection);

                // Increase the command timeout
                command.CommandTimeout = 120; // Set to 120 seconds (or a value you deem appropriate)

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Create a CSV file
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=ClaimsInvoice.csv");
                Response.ContentType = "text/csv";

                // Write the header line
                Response.Write("ClaimID,Name,Email,HoursWorked,HourlyRate,TotalPayment,ModulesTaught,Subject\n");

                // Write the data
                while (reader.Read())
                {
                    Response.Write($"{reader["ClaimID"]},{reader["Name"]},{reader["Email"]},{reader["HoursWorked"]}," +
                                   $"{reader["HourlyRate"]},{reader["TotalPayment"]},{reader["ModulesTaught"]}," +
                                   $"{reader["Subject"]}\n");
                }

                Response.Flush();
                Response.End();
            }
        }

        protected void gvClaims_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvClaims.EditIndex = e.NewEditIndex; // Set the row to edit
            LoadClaims(); // Rebind data to the GridView
        }

        protected void gvClaims_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvClaims.EditIndex = -1; // Cancel editing
            LoadClaims(); // Rebind data to the GridView
        }
    }
}