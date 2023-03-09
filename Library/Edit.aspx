<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Library.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit</title>
    <link rel="stylesheet" href="./main.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-conn">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Author"></asp:Label><asp:TextBox ID="Author" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label><asp:TextBox ID="Title" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label><asp:TextBox ID="Date" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="ISBN"></asp:Label><asp:TextBox ID="ISBN" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label5" runat="server" Text="Format"></asp:Label><asp:TextBox ID="Format" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label6" runat="server" Text="Pages"></asp:Label><asp:TextBox ID="Pages" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label7" runat="server" Text="Description"></asp:Label><asp:TextBox ID="Description" runat="server"></asp:TextBox>
            </div>
            <div class="Conn-Btn">
                <asp:Button ID="EditBtn" AutoPostBack="true" runat="server" Text="Edit" OnClick="EditBtn_Click" UseSubmitBehavior="False" />
            </div>
            <div class="Conn-Btn">
                <asp:Button ID="CancelBtn" AutoPostBack="true" runat="server" Text="Cancel" OnClick="CancelBtn_Click" UseSubmitBehavior="False" />
            </div>
            <asp:Label ID="Errors" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
