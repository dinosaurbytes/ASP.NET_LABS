<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartyPicker.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">     
        <div class="jumbotron">
                <div>
                <h1 class="text-center">Celebration Time</h1>
                <h2 class="text-center">Select A Party Date!</h2>

                <div class="container">
                    <div class="row">
                        <div class="col-6">
                            <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender"></asp:Calendar>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
                            <br />
                            <asp:Button ID="Button1" runat="server" PostBackUrl="~/Results.aspx" Text="Submit Vote" />
                            
                        </div>
                    </div>
                </div>

                    
            </div>
        </div>
           
        
        
    </form>
</body>
<script src="Scripts/jquery-3.0.0.js"></script>
<script src="Scripts/bootstrap.js"></script>
<script src="Scripts/popper.js"></script>
</html>
