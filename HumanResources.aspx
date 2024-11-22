<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR.aspx.cs" Inherits="YourNamespace.HR" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Human Resources</title>
    <link rel="stylesheet" href="../CSS/StyleSheetHR.css"/>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form id="hrForm" runat="server">
        <h3>Manage Lecturer Claims</h3>
        <div class="container">
            <label>Claim ID</label>
            <asp:TextBox ID="txtClaimId" runat="server" placeholder="Enter Claim ID" />
            
            <label>First and Last Name</label>
            <asp:TextBox ID="txtName" runat="server" placeholder="Name" />
            
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Email" />
            
            <label>Hours Worked</label>
            <asp:TextBox ID="txtHours" runat="server" TextMode="Number" placeholder="Hours" />
            
            <label>Hourly Rate</label>
            <asp:TextBox ID="txtRate" runat="server" placeholder="Rate" />
            
            <label>Modules Taught</label>
            <asp:TextBox ID="txtModules" runat="server" placeholder="Modules" />
            
            <asp:Button ID="btnUpdate" runat="server" Text="Update Claim" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnExport" runat="server" Text="Export to Invoice" OnClick="btnExport_Click" />
        </div>
    </form>

    <script>
        $(document).ready(function() {
            $('#btnExport').click(function(e) {
                e.preventDefault();
                // Call the server-side method to export data
                $.ajax({
                    type: "POST",
                    url: "HR.aspx/ExportClaims",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(response) {
                        // Assuming the server returns a URL to the exported document
                        window.location.href = response.d;
                    },
                    error: function(err) {
                        console.log(err);
                    }
                });
            });
        });
    </script>
</body>
</html>