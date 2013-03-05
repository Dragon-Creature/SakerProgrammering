<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        UserId
        <asp:TextBox ID="txtUsUserId" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revNumber" runat="server" ControlToValidate="txtUsUserId" ErrorMessage="Not a number" ValidationExpression="[0-9]"></asp:RegularExpressionValidator>
        <br />
        Password
        <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </form>
</body>
</html>
