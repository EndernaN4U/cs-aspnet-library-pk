<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNew.aspx.cs" Inherits="Library.AddNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Author"></asp:Label>
                <asp:TextBox ID="Author" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label>
                <asp:TextBox ID="Title" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                <asp:TextBox ID="Date" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="ISBN"></asp:Label>
                <asp:TextBox ID="ISBN" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label5" runat="server" Text="Format"></asp:Label>
                <asp:TextBox ID="Format" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label6" runat="server" Text="Pages"></asp:Label>
                <asp:TextBox ID="Pages" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label7" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="Description" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="Add" runat="server" Text="Add" OnClick="Add_Click" />
            <asp:Button ID="Cancel" runat="server" Text="Back" OnClick="Cancel_Click" />
            <asp:Label ID="Errors" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
