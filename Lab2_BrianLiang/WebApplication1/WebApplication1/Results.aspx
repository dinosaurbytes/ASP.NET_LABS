<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="WebApplication1.Results" %>

<!--
    *Lab 2 ASP.NET
    *Author: Brian Liang
    *792783
    *Date: July 2018
    -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" /> <!-- Using bootstrap for styling -->
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <h1 class="text-center text-primary">The Votes So Far:</h1>

            <table class="col-md-12 text-center">
                <tr>
                    <td><asp:Label ID="lblNextSaturday" class="float-right" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="txtFirstSatCount" class="float-left" style="text-align: center" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblSecondSaturday" class="float-right" runat="server"></asp:Label></td>
                    <td> <asp:TextBox ID="txtSecondSatCount" class="float-left" style="text-align: center" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblThridSaturday" class="float-right" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="txtThirdSatCount" class="float-left" style="text-align: center" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
            </table>

            <br />
            <asp:Button ID="btnGoBack" class="btn btn-primary btn-lg" runat="server" PostBackUrl="~/PartyPicker.aspx" Text="Go Back" />
                </div>

            </div>
            
        </div>
    </form>
</body>
    <script src="Scripts/jquery-3.0.0.js"></script>
<script src="Scripts/bootstrap.js"></script>
<script src="Scripts/popper.js"></script>
</html>
