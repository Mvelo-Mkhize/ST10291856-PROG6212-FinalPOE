<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgrammeCoordinator.aspx.cs" Inherits="ST10291856_PROG6212_FinalPOE.Windows.ProgrammeCoordinators" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Programme Coordinator - Pending Claims</title>
    <link rel="stylesheet" href="../CSS/StyleSheetProgramme.css" />
    <link rel="stylesheet" href="style-4.css"/>
</head>
<body>
    <nav class="style-4">
		<ul class="menu-4">
			<li><a href="Home.aspx" data-hover="Home">Home</a></li>
            <li><a href="Lecturer.aspx" data-hover="Lecturer">Lecturer</a></li>
            <li class="current"><a href="ProgrammeCoordinator.aspx" data-hover="Programme Coordinator">Programme Coordinator</a></li>
            <li><a href="HumanResources.aspx" data-hover="Human Resources">Human Resources</a></li>
		</ul>
	</nav>

    <form id="form1" runat="server">
        <h3>Pending Claims</h3>
            <div class="claims-container">
                <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
               <asp:GridView ID="gvClaims" runat="server" AutoGenerateColumns="False" CssClass="claims-grid" OnRowCommand="gvClaims_RowCommand">
    <Columns>
        <asp:BoundField DataField="ClaimID" HeaderText="Claim ID" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="HoursWorked" HeaderText="Hours Worked" />
        <asp:BoundField DataField="HourlyRate" HeaderText="Hourly Rate" />
        <asp:BoundField DataField="TotalPayment" HeaderText="Total Payment" />
        <asp:BoundField DataField="ModulesTaught" HeaderText="Modules Taught" />
        <asp:BoundField DataField="Subject" HeaderText="Subject" />
        <asp:BoundField DataField="FilePath" HeaderText="Supporting File" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnApprove" runat="server" Text="Approve" CommandName="Approve" CommandArgument='<%# Eval("ClaimID") %>' />
                <asp:Button ID="btnReject" runat="server" Text="Reject" CommandName="Reject" CommandArgument='<%# Eval("ClaimID") %>' />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ClaimID") %>' CssClass="delete-button" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <div class="progress-container">
                           <div class="progress-bar <%# GetProgressBarClass(Eval("Status").ToString()) %>">
                                <%# Eval("Status") %>
                           </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </div>
    </form>
</body>
</html>