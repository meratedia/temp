<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Capture.aspx.cs" Inherits="Helpdesk.Capture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="wwwroot/capture.css" />
    <link rel="stylesheet" href="wwwroot/dash.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">

</head>
    <script>
     function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition, showError);
            } else {
                alert("Geolocation is not supported by this browser.");
            }
        }

        function showPosition(position) {
            var latitude = position.coords.latitude;
            var longitude = position.coords.longitude;
            document.getElementById("loca").value = latitude +" " + longitude;
        }

        function showError(error) {
            switch (error.code) {
                case error.PERMISSION_DENIED:
                    alert("User denied the request for Geolocation.");
                    break;
                case error.POSITION_UNAVAILABLE:
                    alert("Location information is unavailable.");
                    break;
                case error.TIMEOUT:
                    alert("The request to get user location timed out.");
                    break;
                case error.UNKNOWN_ERROR:
                    alert("An unknown error occurred.");
                    break;
            }
        }
    </script>
<body>
      <div class="navigation">
    <ul>
        <li>
            <a href="/">
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
     <div class="container">
        <h2>Enter Your Details</h2>
        <form id="userDetailsForm" runat="server" >
            <div class="form-group">
                <label for="firstName">First Name</label>
                <input type="text" id="firstName" name="firstName" required>
            </div>
            <div class="form-group">
                <label for="lastName">Last Name</label>
                <input type="text" id="lastName" name="lastName" required>
            </div>
            <div class="form-group">
                <label for="email">Email</label>
                <input type="email" id="email" name="email" required>
            </div>
            <div class="form-group">
                <label for="phone">Phone</label>
                <input type="tel" id="phone" name="phone" required>
            </div>
            <div class="form-group">
                <label for="address1">Address</label>
                <input type="text" id="address1" name="address1" required>
            </div>
            <div class="form-group">
                <label for="state">Case</label>
                <input type="text" id="state" name="state" required>
            </div>
            <div class="form-group">
                <label for="gender">Priority</label>
                <select id="gender" name="gender" required>
                    <option value="">Select...</option>
                    <option value="low">Low</option>
                    <option value="med">Medium</option>
                    <option value="high">High</option>
                </select>
            </div>
            <div class="form-group">
                <label for="state">Location</label>
                <input type="text" id="loca" name="loca" required onclick="getLocation()" readonly="true">
            </div>
            <asp:Button ID="Button1" type="submit" runat="server" Text="Submit" OnClick="Button1_Click" BackColor="#009900" BorderColor="White" ForeColor="White" />
            <button type="reset" id="btnReset">Reset</button>
         
         
        </form>
    </div>
          </div> 
</body>
    
</html>
