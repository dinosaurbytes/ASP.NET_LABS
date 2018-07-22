<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="WebApplication1.Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>The Votes So Far:</h1>

            <table>
                <tr>
                    <td><asp:Label ID="lblNextSaturday" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="txtFirstSatCount" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblSecondSaturday" runat="server"></asp:Label></td>
                    <td> <asp:TextBox ID="txtSecondSatCount" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblThridSaturday" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="txtThirdSatCount" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
            </table>

            <br />
            <asp:Button ID="btnGoBack" runat="server" PostBackUrl="~/PartyPicker.aspx" Text="Go Back" />
        </div>
    </form>
</body>
</html>
