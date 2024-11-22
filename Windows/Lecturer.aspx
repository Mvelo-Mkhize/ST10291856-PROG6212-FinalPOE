<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lecturer.aspx.cs" Inherits="ST10291856_PROG6212_FinalPOE.Windows.Lecturer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lecturer</title>
    <link rel="stylesheet" href="../CSS/StyleSheetLecturer.css" />
    <link rel="stylesheet" href="style-4.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#btnCalculate").click(function () {
                const hoursWorked = parseFloat($("#<%= txtHours.ClientID %>").val());
                const hourlyRate = parseFloat($("#<%= txtRate.ClientID %>").val());
                if (!isNaN(hoursWorked) && !isNaN(hourlyRate)) {
                    $("#totalPayment").text(`Total Payment: R${(hoursWorked * hourlyRate).toFixed(2)}`);
                } else {
                    $("#totalPayment").text("Please enter valid numbers for hours worked and hourly rate.");
                }
            });
        });
    </script>
</head>
<body>
    <nav class="style-4">
        <ul class="menu-4">
            <li><a href="Home.aspx" data-hover="Home">Home</a></li>
            <li class="current"><a href="Lecturer.aspx" data-hover="Lecturer">Lecturer</a></li>
            <li><a href="ProgrammeCoordinator.aspx" data-hover="Programme Coordinator">Programme Coordinator</a></li>
            <li><a href="HumanResources.aspx" data-hover="Human Resources">Human Resources</a></li>
        </ul>
    </nav>
    <h3>Submit Claim</h3>
    <h5>This form is for claim submission</h5>
    <div class="box">
        <a href="#divOne" class="button">Apply</a>
    </div>
    <div class="overlay" id="divOne">
        <div class="wrapper">
            <h2>Fill in the Relevant Information</h2>
            <a href="#" class="close">&times</a>
            <div class="container">
                <form id="claimForm" runat="server">
                    <div class="container">
                        <label>First and Last Name</label>
                        <asp:TextBox ID="txtName" runat="server" placeholder="Your Name and Surname"></asp:TextBox>
                        <label>Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Your Email Address" TextMode="Email"></asp:TextBox>
                        <label>Hours Worked</label>
                        <asp:TextBox ID="txtHours" runat="server" TextMode="Number"></asp:TextBox>
                        <label>Hourly Rate</label>
                        <asp:TextBox ID="txtRate" runat="server" placeholder="Your Hourly Rate"></asp:TextBox>
                        <label>Modules Taught</label>
                        <asp:TextBox ID="txtModules" runat="server" placeholder="Modules Taught"></asp:TextBox>
                        <label>Supporting File</label>
                        <asp:FileUpload ID="fileUpload" runat="server" />
                        <label>Subject</label>
                        <asp:TextBox ID="txtSubject" runat="server" TextMode="MultiLine" placeholder="Your Query Here"></asp:TextBox>
                        <button type="button" id="btnCalculate" class="button">Calculate Payment</button>
                        <asp:Label ID="lblTotalPayment" runat="server" Text="" CssClass="total-payment"></asp:Label>
                        <p id="totalPayment" style="font-weight:bold; margin-top:10px;"></p>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
