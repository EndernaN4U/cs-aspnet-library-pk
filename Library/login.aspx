<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Library.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="./main.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-conn">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
                <asp:TextBox ID="LoginTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="Conn-Btn">
                <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
            </div>
            <div>
                <asp:Label ID="ErrorsTxt" runat="server" Text=""></asp:Label>
                <asp:Button ID="Register" runat="server" Text="Register" OnClick="Register_Click" />
            </div>
            <div class="Conn-Btn">
                <asp:Button ID="BackConn" runat="server" Text="Back to Connection" OnClick="BackConn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
