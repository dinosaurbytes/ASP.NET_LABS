<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerIncidentForm.aspx.cs" Inherits="Lab4_BrianLiang_WebApp.CustomerIncidentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="CustomerID:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlCustomerID" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="gvCustomerIncidents" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
