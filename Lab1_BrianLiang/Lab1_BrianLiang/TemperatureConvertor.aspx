<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemperatureConvertor.aspx.cs" Inherits="Lab1_BrianLiang.TemperatureConvertor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            color: #009933;
        }
        .auto-style2 {
            width: 183px;
            height: 275px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span class="auto-style1">Temperature Convertor</span><br />
            <br />
            <img alt="thermometer image" class="auto-style2" src="Images/thermometer.jpg" /><br />
            <asp:Label ID="Label1" runat="server" Text="From:"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="To:"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlFrom" runat="server" OnSelectedIndexChanged="ddlFrom_SelectedIndexChanged">
                <asp:ListItem>Celsius</asp:ListItem>
                <asp:ListItem>Fahrenheit</asp:ListItem>
                <asp:ListItem>Kelvin</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlTo" runat="server">
                <asp:ListItem>Celsius</asp:ListItem>
                <asp:ListItem>Fahrenheit</asp:ListItem>
                <asp:ListItem>Kelvin</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Input Temperature"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Output Temperature"></asp:Label>
            <br />
            <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtOutput" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInput" Display="Dynamic" ErrorMessage="Input field cannot be Empty"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtInput" Display="Dynamic" EnableTheming="True" ErrorMessage="Input must be a number between -1000 and 1000" MaximumValue="1000" MinimumValue="-1000" Type="Double"></asp:RangeValidator>
            <br />
            <asp:Button ID="btnConvert" runat="server" Text="Convert" OnClick="btnConvert_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="False" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
