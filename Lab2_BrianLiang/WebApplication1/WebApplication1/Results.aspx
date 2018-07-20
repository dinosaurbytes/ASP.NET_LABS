<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="WebApplication1.Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Results"></asp:Label>
            <br />
            <br />
            Results are:
            <asp:Label ID="lblResults" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblNextSaturday" runat="server"></asp:Label>
            <asp:TextBox ID="firstSatTotal" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblSecondSaturday" runat="server"></asp:Label>
            <asp:TextBox ID="secondSatCounter" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblThridSaturday" runat="server"></asp:Label>
            <asp:TextBox ID="thirdSatCounter" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnGoBack" runat="server" PostBackUrl="~/PartyPicker.aspx" Text="Go Back" />
            <asp:Button ID="Button1" runat="server" Text="Add" />
        </div>
    </form>
</body>
</html>
