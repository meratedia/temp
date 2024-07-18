<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Helpdesk.dashboard" %>

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
          <div class="topbar">
        <div class="toggle">
               <i class="fas fa-bars"></i>
        </div>

        <div class="search">
            <label>
                <input type="text" placeholder="Search here"/>
                <ion-icon name="search-outline">  <i class="fas fa-search"></i> </ion-icon>
            </label>
        </div>

        <div class="user">
              <i class="fas fa-user"></i>
        </div>
    </div>
    <div class="cardBox">
   <div class="card">
        <div>
            <div class="numbers">    <asp:Literal ID="fresh" runat="server"></asp:Literal></div>
            <div class="cardName">UnAttended Cases</div>
        </div>

        <div class="iconBx">
          <i class="fas fa-chart-bar"></i>
        </div>
    </div>

    <div class="card">
        <div>
            <div class="numbers">    <asp:Literal ID="solved" runat="server"></asp:Literal></div>
            <div class="cardName">Solved Cases</div>
        </div>

        <div class="iconBx">
          <i class="fas fa-chart-bar"></i>
        </div>
    </div>

    <div class="card">
        <div>
            <div class="numbers">    <asp:Literal ID="total" runat="server"></asp:Literal></div>
            <div class="cardName">Total Cases</div>
        </div>

        <div class="iconBx">
         <i class="fas fa-chart-bar"></i>
        </div>
    </div> 
</div>
           <div class="details">
    <div class="recentOrders">
        <div class="cardHeader">
            <h2>Recent Cases</h2>
            <a href="/All" class="btn">View All</a>
        </div>

        <table>
            <thead>
                <tr>
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

    <div class="recentCustomers">
        <div class="cardHeader">
            <h2>Recent Clients</h2>
        </div>
 <table>
            <asp:Literal ID="LiteralUsers" runat="server"></asp:Literal>



        </table> 
    </div>
</div>
   

        </div>
</body>

</html>
