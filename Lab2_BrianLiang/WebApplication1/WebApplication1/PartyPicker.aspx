<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartyPicker.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">     
        <div class="jumbotron">
                <div>
                <h1 class="text-center">Celebration Time</h1>
                <h2 class="text-center">Select A Party Date!</h2>

                <div class="container">
                    
                            <asp:Calendar ID="Calendar" runat="server" OnDayRender="Calendar1_DayRender" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                                <DayStyle Width="14%" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#009933" BorderColor="#33CC33" BorderStyle="Dashed" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                                <TodayDayStyle BackColor="#CCCC99" />
                            </asp:Calendar>
                        
                            <asp:TextBox ID="txtFirstSatCount" runat="server"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtSecondSatCount" runat="server"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtThirdSatCount" runat="server"></asp:TextBox>
                            <br />
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit Vote" OnClick="btnSubmit_Click" />
                            
                      
                </div>

                    
            </div>
        </div>
           
        
        
    </form>
</body>
<script src="Scripts/jquery-3.0.0.js"></script>
<script src="Scripts/bootstrap.js"></script>
<script src="Scripts/popper.js"></script>
</html>
