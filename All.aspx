<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="Helpdesk.All" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="wwwroot/dash.css" />
       <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</head>
    <script>
    function redi(caseID) {
   
        var url = 'Attend.aspx?caseID=' + caseID; 
        window.location.href = url;
    }
</script>
<body>
    <div class="navigation">
    <ul>
        <li>
            <a href="">
                <span class="icon">
                    <ion-icon name="logo-apple"></ion-icon>
                </span>
                <span class="title">Helpdesk Dashboard</span>
            </a>
        </li>

        <li>
            <a href="/">
                <span class="icon">
                    <ion-icon name="home-outline"><i class="fas fa-home"></i></ion-icon>
                </span>
                <span class="title">Dashboard</span>
            </a>
        </li>

        <li>
            <a href="/Capture">
                <span class="icon">
                    <ion-icon name="people-outline"><i class="fas fa-folder"></i></ion-icon>
                </span>
                <span class="title">New Case</span>
            </a>
        </li>

        <li>
            <a href="/Attend">
                <span class="icon">
                    <ion-icon name="chatbubble-outline">  <i class="fas fa-folder"></i></ion-icon>
                </span>
                <span class="title">Attend Case</span>
            </a>
        </li>

        <li>
            <a href="/Login">
                <span class="icon">
                    <ion-icon name="help-outline"> <i class="fas fa-sign-out-alt"></i></ion-icon>
                </span>
                <span class="title">Logout</span>
            </a>
        </li>
    </ul>
</div>
    <div class="main">
         <div class="details">
        <div class="recentOrders">

        <table>
            <thead>
                <tr onclick="">
                    <td>Username</td>
                    <td>Priority</td>
                    <td>Date</td>
                    <td>Status</td>
                </tr>
            </thead> 
    <tbody>
        <asp:Literal ID="LiteralCases" runat="server"></asp:Literal>

            </tbody>
        </table>
    </div>
        </div>
        </div>
</body>
</html>
