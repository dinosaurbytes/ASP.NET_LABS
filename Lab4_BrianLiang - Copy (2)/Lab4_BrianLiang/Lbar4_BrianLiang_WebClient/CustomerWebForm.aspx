<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerWebForm.aspx.cs" Inherits="Lbar4_BrianLiang_WebClient.CustomerWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Select Customer ID:"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlCustomerID" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
