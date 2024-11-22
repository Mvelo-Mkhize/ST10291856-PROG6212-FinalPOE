<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HumanResources.aspx.cs" Inherits="ST10291856_PROG6212_FinalPOE.Windows.HumanResources" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Human Resources - Manage Claims</title>
    <link rel="stylesheet" href="../CSS/StyleSheetHumanResources.css" />
    <link rel="stylesheet" href="style-4.css" />
</head>
<body>
    <nav class="style-4">
        <ul class="menu-4">
            <li><a href="Home.aspx" data-hover="Home">Home</a></li>
            <li><a href="Lecturer.aspx" data-hover="Lecturer">Lecturer</a></li>
            <li><a href="ProgrammeCoordinator.aspx" data-hover="Programme Coordinator">Programme Coordinator</a></li>
            <li class="current"><a href="HumanResources.aspx" data-hover="Human Resources">Human Resources</a></li>
        </ul>
    </nav>

    <form id="form1" runat="server">
        <h3>Manage Claims</h3>
        <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
       <asp:GridView ID="gvClaims" runat="server" AutoGenerateColumns="False" CssClass="claims-grid" 
    OnRowCommand="gvClaims_RowCommand" OnRowEditing="gvClaims_RowEditing" OnRowCancelingEdit="gvClaims_RowCancelingEdit">
    <Columns>
        <asp:BoundField DataField="ClaimID" HeaderText="Claim ID" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="HoursWorked" HeaderText="Hours Worked" />
        <asp:BoundField DataField="HourlyRate" HeaderText="Hourly Rate" />
        <asp:BoundField DataField="TotalPayment" HeaderText="Total Payment" />
        <asp:BoundField DataField="ModulesTaught" HeaderText="Modules Taught" />
        <asp:BoundField DataField="Subject" HeaderText="Subject" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("ClaimID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

        <asp:Panel ID="pnlEditClaim" runat="server" Visible="false">
            <h4>Edit Claim Details</h4>
            <asp:HiddenField ID="hfClaimID" runat="server" />
            <label>Name:</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            <label>Hours Worked:</label>
            <asp:TextBox ID="txtHours" runat="server"></asp:TextBox><br />
            <label>Hourly Rate:</label>
            <asp:TextBox ID="txtRate" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </asp:Panel>
        
        <asp:Button ID="btnExport" runat="server" Text="Export Claims as Invoice" OnClick="btnExport_Click" />
    </form>
</body>
</html>