<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="Library.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Books</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Search"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Label">Author</asp:Label>
                    <asp:TextBox ID="Author" runat="server" OnTextChanged="ChangeRows" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="Label">Title</asp:Label>
                    <asp:TextBox ID="Title" runat="server" OnTextChanged="ChangeRows" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="Label">Date</asp:Label>
                    <asp:TextBox ID="Date" runat="server" OnTextChanged="ChangeRows" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="Label">ISBN</asp:Label>
                    <asp:TextBox ID="ISBN" runat="server" OnTextChanged="ChangeRows" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Text="Label">Description</asp:Label>
                    <asp:TextBox ID="Description" runat="server" OnTextChanged="ChangeRows" AutoPostBack="true"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" />
                <asp:Button ID="Users" runat="server" Text="Users" OnClick="Users_Click" />
                <asp:Button ID="Addnew" runat="server" Text="Add New" OnClick="Addnew_Click" />
            </div>
            
            <asp:GridView ID="BooksGrid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="BooksGrid_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField ButtonType="Link" CommandName="DeleteRow" Text="Delete"/>
                    <asp:ButtonField ButtonType="Link" CommandName="EditRow" Text="Edit" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
