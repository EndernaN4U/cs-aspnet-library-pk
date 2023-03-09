<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Library.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
            </div>
            <div>
                <asp:GridView ID="UsersGrid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="BooksGrid_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField ButtonType="Link" CommandName="Delete" Text="Delete"/>
                        <asp:ButtonField ButtonType="Link" CommandName="Promote" Text="Promote" />
                        <asp:ButtonField ButtonType="Link" CommandName="Demote" Text="Demote" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
