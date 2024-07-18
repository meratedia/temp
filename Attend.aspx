<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attend.aspx.cs" Inherits="Helpdesk.Attend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="wwwroot/dash.css" />
       <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</head>
<body>
    <form id="form1" runat="server">
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
                    <td></td>
                    <td></td>
                </tr>
            </thead> 
    <tbody>
        <asp:Literal ID="LiteralCases" runat="server"></asp:Literal>

            </tbody>
        </table>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Attend" BackColor="#009933" ForeColor="White" Height="37px" Width="81px" />
            </div>
                      </div>
         </div>
    </form>
</body>
</html>
