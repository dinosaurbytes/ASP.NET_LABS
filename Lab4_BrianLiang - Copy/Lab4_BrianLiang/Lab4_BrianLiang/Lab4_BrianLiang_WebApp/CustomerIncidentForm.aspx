<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerIncidentForm.aspx.cs" Inherits="Lab4_BrianLiang_WebApp.CustomerIncidentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <div class="text-black shadow-lg p-3 mb-5 bg-info rounded">
            <asp:Label ID="Label2" class="font-weight-bold" runat="server" Text="Customer Incident List"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="CustomerID:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlCustomerID" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="gvCustomerIncidents" runat="server">
            </asp:GridView>
        </div>
            </div>
    </form>
</body>
<script src="Scripts/jquery-3.0.0.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/popper.min.js"></script>
</html>
