<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicianSelect.aspx.cs" Inherits="Lab3_BrianLiang.TechnicianSelect" %>

<!DOCTYPE html>

<!--*
    * Lab3 ASP.NET
    * Author: Brian Liang
    * Date: July 2018
    *-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" /> <!-- Using bootstrap for styling -->
</head>
<body>
    <form id="form1" runat="server">
        <div class="p-3 mb-2 bg-info text-white">
            <h1>Open Incident Board</h1> 
            <br />
            <h2>Select A Technician</h2>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="TechID">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTechnicians" TypeName="Lab3_BrianLiang.TechnicianDB"></asp:ObjectDataSource>
            <br />
            <br />
            <h2>Open Incidents</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
                <Columns>
                    <asp:BoundField DataField="IncidentID" HeaderText="IncidentID" SortExpression="IncidentID" />
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                    <asp:BoundField DataField="ProductCode" HeaderText="ProductCode" SortExpression="ProductCode" />
                    <asp:BoundField DataField="TechID" HeaderText="TechID" SortExpression="TechID" />
                    <asp:BoundField DataField="DateOpened" HeaderText="DateOpened" SortExpression="DateOpened" />
                    <asp:BoundField DataField="DateClosed" HeaderText="DateClosed" SortExpression="DateClosed" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetIncidentByTechnician" TypeName="Lab3_BrianLiang.IncidentDB">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="techID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <br />
        </div>
    </form>
</body>
    <script src="Scripts/jquery-3.0.0.js"></script>
<script src="Scripts/bootstrap.js"></script>
<script src="Scripts/popper.js"></script>
</html>
