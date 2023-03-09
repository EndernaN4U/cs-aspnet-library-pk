<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Library.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" href="./main.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-conn">
            <asp:Label ID="Label1" runat="server" Text="Nick"></asp:Label>
            <asp:TextBox ID="Nick" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <div class="Conn-Btn">
                <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
            </div>
            <div class="Conn-Btn">
                <asp:Button ID="CancelBtn" runat="server" Text="Cancel" OnClick="CancelBtn_Click" />  
            </div>
            <div>
                <asp:Label ID="Errors" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
    </form>
</body>
</html>
