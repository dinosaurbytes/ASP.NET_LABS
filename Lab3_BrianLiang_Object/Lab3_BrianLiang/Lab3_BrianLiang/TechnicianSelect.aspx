<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicianSelect.aspx.cs" Inherits="Lab3_BrianLiang.TechnicianSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="TechID">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTechnicians" TypeName="Lab3_BrianLiang.TechnicianDB"></asp:ObjectDataSource>
            <br />
        </div>
    </form>
</body>
</html>
