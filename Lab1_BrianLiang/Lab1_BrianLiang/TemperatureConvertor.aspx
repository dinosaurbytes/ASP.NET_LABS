<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemperatureConvertor.aspx.cs" Inherits="Lab1_BrianLiang.TemperatureConvertor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Style/Style.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="jumbotron">
        <div>
            <h1 class="text-center">Temperature Convertor</h1><br />
            <br />
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <img alt="thermometer image" class="auto-style2" src="Images/thermometer.jpg" /><br />
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label1" runat="server" Text="From:"></asp:Label>
                        <asp:DropDownList ID="ddlFrom" runat="server" OnSelectedIndexChanged="ddlFrom_SelectedIndexChanged">
                            <asp:ListItem>Celsius</asp:ListItem>
                            <asp:ListItem>Fahrenheit</asp:ListItem>
                            <asp:ListItem>Kelvin</asp:ListItem>
                        </asp:DropDownList>
                        <br /><br />
                        <asp:Label ID="Label3" runat="server" Text="Input Temperature"></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="validator" runat="server" ControlToValidate="txtInput" Display="Dynamic" ErrorMessage="Input field cannot be Empty"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" class="validator" runat="server" ControlToValidate="txtInput" Display="Dynamic" EnableTheming="True" ErrorMessage="Input must be a number between -1000 and 1000" MaximumValue="1000" MinimumValue="-1000" Type="Double"></asp:RangeValidator>
                        <br />
                        <asp:Button ID="btnConvert" runat="server" class="btn btn-outline-success" Text="Convert" OnClick="btnConvert_Click" />
                    </div>
                    <div class="col-md-4">
                         <asp:Label ID="Label2" runat="server" Text="To:"></asp:Label>
                        <asp:DropDownList ID="ddlTo" runat="server">
                            <asp:ListItem>Fahrenheit</asp:ListItem>
                            <asp:ListItem>Celsius</asp:ListItem>
                            <asp:ListItem>Kelvin</asp:ListItem>
                        </asp:DropDownList>
                        <br /><br />
                        <asp:Label ID="Label4" runat="server" Text="Output Temperature"></asp:Label>
                        <br /><br />
                        <asp:TextBox ID="txtOutput" runat="server" ReadOnly="True"></asp:TextBox>
                        <br /><br />
                        <asp:Button ID="btnClear" runat="server" class="btn btn-outline-danger" Text="Clear" CausesValidation="False" OnClick="btnClear_Click" />
                    </div> 
                </div>
            </div>
               </div>
                </div>
            </div>
                
    </form>
</body>
<script src="Scripts/jquery-3.3.1.js"></script>
<script src="Scripts/bootstrap.js"></script>
<script src="Scripts/popper.js"></script>
</html>
