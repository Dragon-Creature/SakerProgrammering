<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            Id
            <asp:TextBox ID="txtUserId" runat="server" CausesValidation="True" ValidationGroup="check"></asp:TextBox>
            <asp:RegularExpressionValidator ControlToValidate="txtUserId" ValidationExpression="\d+" ErrorMessage="*Endast siffror tillåtna" EnableClientScript="false" runat="server" ID="RegularExpressionValidator1" ForeColor="#CC3300"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserId" ErrorMessage="*Endast siffror tillåtna" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            <br />
            Lösenord
        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtpassword" ErrorMessage="*Minimum sju tecken [Innehållande minst en siffra och versal]"
                ValidationExpression="^(?=.{7,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$" EnableClientScript="False" ForeColor="#CC3300"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Minimum sju tecken [Innehållande minst en siffra och versal]" ControlToValidate="txtpassword" EnableClientScript="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <%--<asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
        </asp:Login>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" />--%>
            <br />
            <asp:Label ID="lblLoginFail" runat="server" Text="* Fel id och/eller lösenord" Visible="False" ForeColor="#CC3300"></asp:Label>
    </form>
</body>
</html>
