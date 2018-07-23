<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicianSelect.aspx.cs" Inherits="Lab3_BrianLiang.WebForm1" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="dsTechnicians" runat="server" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" SelectCommand="SELECT [TechID], [Name] FROM [Technicians]"></asp:SqlDataSource>
            <br />
            <asp:DropDownList ID="ddlTechnicians" runat="server">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
