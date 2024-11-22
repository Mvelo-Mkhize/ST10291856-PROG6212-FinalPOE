using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ST10291856_PROG6212_FinalPOE.Windows
{
    public partial class Lecturer : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mvelo.MonthlyClaimsApp.dbo"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string filePath = "";
                string uploadFolder = Server.MapPath("~/UploadedFiles/");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                if (fileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(fileUpload.FileName);
                    filePath = Path.Combine(uploadFolder, fileName);
                    fileUpload.SaveAs(filePath);
                }

                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtHours.Text) ||
                    string.IsNullOrWhiteSpace(txtRate.Text) ||
                    string.IsNullOrWhiteSpace(txtModules.Text) ||
                    string.IsNullOrWhiteSpace(txtSubject.Text))
                {
                    lblTotalPayment.Text = "All fields are required.";
                    lblTotalPayment.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!int.TryParse(txtHours.Text, out int hoursWorked) ||
                    !decimal.TryParse(txtRate.Text, out decimal hourlyRate))
                {
                    lblTotalPayment.Text = "Invalid input for hours or rate.";
                    lblTotalPayment.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Calculate total payment
                decimal totalPayment = hoursWorked * hourlyRate;

                string query = "INSERT INTO LecturerClaims (Name, Email, HoursWorked, HourlyRate, TotalPayment, ModulesTaught, Subject, FilePath, Status) " +
                               "VALUES (@Name, @Email, @HoursWorked, @HourlyRate, @TotalPayment, @ModulesTaught, @Subject, @FilePath, 'Pending')";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@HoursWorked", hoursWorked);
                command.Parameters.AddWithValue("@HourlyRate", hourlyRate);
                command.Parameters.AddWithValue("@TotalPayment", totalPayment);
                command.Parameters.AddWithValue("@ModulesTaught", txtModules.Text);
                command.Parameters.AddWithValue("@Subject", txtSubject.Text);
                command.Parameters.AddWithValue("@FilePath", filePath);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    lblTotalPayment.Text = $"Claim submitted successfully! Total Payment: R{totalPayment:F2}";
                    lblTotalPayment.ForeColor = System.Drawing.Color.Green;

                    // Clear form fields
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtHours.Text = "";
                    txtRate.Text = "";
                    txtModules.Text = "";
                    txtSubject.Text = "";
                }
                catch (Exception ex)
                {
                    lblTotalPayment.Text = $"Error submitting claim: {ex.Message}";
                    lblTotalPayment.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

    }
}
