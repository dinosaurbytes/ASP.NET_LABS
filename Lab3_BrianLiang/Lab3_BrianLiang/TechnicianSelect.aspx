<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicianSelect.aspx.cs" Inherits="Lab3_BrianLiang.WebForm1" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="dsTechnicians" runat="server" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" SelectCommand="SELECT [TechID], [Name] FROM [Technicians] ORDER BY [Name]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsIncidents" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" DeleteCommand="DELETE FROM [Incidents] WHERE [IncidentID] = @original_IncidentID AND [DateOpened] = @original_DateOpened AND [CustomerID] = @original_CustomerID AND [ProductCode] = @original_ProductCode AND (([TechID] = @original_TechID) OR ([TechID] IS NULL AND @original_TechID IS NULL)) AND [Title] = @original_Title AND [Description] = @original_Description AND (([DateClosed] = @original_DateClosed) OR ([DateClosed] IS NULL AND @original_DateClosed IS NULL))" InsertCommand="INSERT INTO [Incidents] ([DateOpened], [CustomerID], [ProductCode], [TechID], [Title], [Description], [DateClosed]) VALUES (@DateOpened, @CustomerID, @ProductCode, @TechID, @Title, @Description, @DateClosed)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [DateOpened], [IncidentID], [CustomerID], [ProductCode], [TechID], [Title], [Description], [DateClosed] FROM [Incidents] WHERE (([TechID] = @TechID) AND ([DateClosed] IS NULL)) ORDER BY [TechID]" UpdateCommand="UPDATE [Incidents] SET [DateOpened] = @DateOpened, [CustomerID] = @CustomerID, [ProductCode] = @ProductCode, [TechID] = @TechID, [Title] = @Title, [Description] = @Description, [DateClosed] = @DateClosed WHERE [IncidentID] = @original_IncidentID AND [DateOpened] = @original_DateOpened AND [CustomerID] = @original_CustomerID AND [ProductCode] = @original_ProductCode AND (([TechID] = @original_TechID) OR ([TechID] IS NULL AND @original_TechID IS NULL)) AND [Title] = @original_Title AND [Description] = @original_Description AND (([DateClosed] = @original_DateClosed) OR ([DateClosed] IS NULL AND @original_DateClosed IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_IncidentID" Type="Int32" />
                    <asp:Parameter Name="original_DateOpened" Type="DateTime" />
                    <asp:Parameter Name="original_CustomerID" Type="Int32" />
                    <asp:Parameter Name="original_ProductCode" Type="String" />
                    <asp:Parameter Name="original_TechID" Type="Int32" />
                    <asp:Parameter Name="original_Title" Type="String" />
                    <asp:Parameter Name="original_Description" Type="String" />
                    <asp:Parameter Name="original_DateClosed" Type="DateTime" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="DateOpened" Type="DateTime" />
                    <asp:Parameter Name="CustomerID" Type="Int32" />
                    <asp:Parameter Name="ProductCode" Type="String" />
                    <asp:Parameter Name="TechID" Type="Int32" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="DateClosed" Type="DateTime" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTechnicians" Name="TechID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="DateOpened" Type="DateTime" />
                    <asp:Parameter Name="CustomerID" Type="Int32" />
                    <asp:Parameter Name="ProductCode" Type="String" />
                    <asp:Parameter Name="TechID" Type="Int32" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="DateClosed" Type="DateTime" />
                    <asp:Parameter Name="original_IncidentID" Type="Int32" />
                    <asp:Parameter Name="original_DateOpened" Type="DateTime" />
                    <asp:Parameter Name="original_CustomerID" Type="Int32" />
                    <asp:Parameter Name="original_ProductCode" Type="String" />
                    <asp:Parameter Name="original_TechID" Type="Int32" />
                    <asp:Parameter Name="original_Title" Type="String" />
                    <asp:Parameter Name="original_Description" Type="String" />
                    <asp:Parameter Name="original_DateClosed" Type="DateTime" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <asp:DropDownList ID="ddlTechnicians" runat="server" AutoPostBack="True" DataSourceID="dsTechnicians" DataTextField="Name" DataValueField="TechID">
            </asp:DropDownList>
            <br />
            <asp:GridView ID="gvIncidents" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="IncidentID" DataSourceID="dsIncidents">
                <Columns>
                    <asp:BoundField DataField="TechID" HeaderText="TechID" SortExpression="TechID" />
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                    <asp:BoundField DataField="IncidentID" HeaderText="IncidentID" InsertVisible="False" ReadOnly="True" SortExpression="IncidentID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" />
                    <asp:BoundField DataField="DateOpened" HeaderText="Date Opened" SortExpression="DateOpened" />
                    <asp:BoundField DataField="DateClosed" HeaderText="Date Closed" SortExpression="DateClosed" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
