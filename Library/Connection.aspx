<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connection.aspx.cs" Inherits="Library.Connection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div
            <div>
                <asp:Label ID="Label1" runat="server" Text="Server"></asp:Label><asp:TextBox ID="ServerTxt" runat="server" Text="localhost"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Database"></asp:Label><asp:TextBox ID="DatabaseTxt" runat="server" Text="library"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="User"></asp:Label><asp:TextBox ID="UserTxt" runat="server" Text="root"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label><asp:TextBox ID="PasswordTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="Connect" runat="server" Text="Connect" OnClick="Connect_Click" />
            </div>
            
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
