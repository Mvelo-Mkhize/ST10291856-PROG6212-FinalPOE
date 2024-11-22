<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewClaims.aspx.cs" Inherits="ST10291856_PROG6212_FinalPOE.Windows.ViewClaims" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Pending Claims</title>
    <link rel="stylesheet" href="../CSS/StyleSheetLecturer.css"/>
    <link rel="stylesheet" href="style-4.css"/>
</head>
<body>
    <nav class="style-4">
		<ul class="menu-4">
			<li class="current"><a href="Home.aspx" data-hover="Home">Home</a></li>
			<li><a href="Lecturer.aspx" data-hover="Lecturer">Lecturer</a></li>
			<li><a href="AcademicManagers.aspx" data-hover="Academic Manager">Academic Manager</a></li>
			<li><a href="ProgrammeCoordinator.aspx" data-hover="Programme Coordinator">Programme Coordinator</a></li>
			<li><a href="Contact.aspx" data-hover="Contact">Contact</a></li>
		</ul>
	</nav>

    <h3>Pending Claims</h3>
    <div class="container">
        <table class="claims-grid">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Hours Worked</th>
                    <th>Hourly Rate</th>
                    <th>Modules Taught</th>
                    <th>Subject</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <!-- This is where the claims will be populated -->
                <asp:Repeater ID="RepeaterClaims" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Email") %></td>
                            <td><%# Eval("HoursWorked") %></td>
                            <td><%# Eval("HourlyRate") %></td>
                            <td><%# Eval("ModulesTaught") %></td>
                            <td><%# Eval("Subject") %></td>
                            <td>
                                <asp:Button ID="btnApprove" runat="server" Text="Approve" CommandArgument='<%# Eval("ClaimID") %>' OnCommand="ApproveClaim" />
                                <asp:Button ID="btnReject" runat="server" Text="Reject" CommandArgument='<%# Eval("ClaimID") %>' OnCommand="RejectClaim" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</body>
</html>