<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ST10291856_PROG6212_FinalPOE.Windows.Home1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Home Page</title>
	<link rel="stylesheet" href="../CSS/StyleSheetHome.css"/>
	<link rel="stylesheet" href="style-4.css"/>
</head>
<body>
    <nav class="style-4">
		<ul class="menu-4">
			<li class="current"><a href="Home.aspx" data-hover="Home">Home</a></li>
			<li><a href="Lecturer.aspx" data-hover="Lecturer">Lecturer</a></li>
			<li><a href="ProgrammeCoordinator.aspx" data-hover="Programme Coordinator">Programme Coordinator</a></li>
			<li><a href="HumanResources.aspx" data-hover="Human Resources">Human Resources</a></li>
			<li><a href="Contact.aspx" data-hover="Contact">Contact</a></li>
		</ul>
	</nav>

	<div class="container">
		
		<div class="box3">
			<a href="ProgrammeCoordinators.aspx" class="button">Programme Coordinator</a>
		</div>

		<div class="box2">
			<a href="Lecturer.aspx" class="button">Lecturer</a>
		</div>

		<div class="box1">
			<a href="HumanResources.aspx" class="button">Human Resources</a>
		</div>

	</div>
</body>
</html>
