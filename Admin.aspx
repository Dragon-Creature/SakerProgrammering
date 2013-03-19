<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Admin</h1>

            <asp:Label Text="Ange anställningsnummer:" runat="server" AssociatedControlID="txtSearch" />
            <div>
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Sök" OnClick="btnSearch_Click" />
                <!--<asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Ange ett anställningsnummer från 1 - 999999999" Type="Integer" MaximumValue="999999999" MinimumValue="1" ControlToValidate="txtSearch" Display="Dynamic" EnableClientScript="False" ForeColor="#FF3300"></asp:RangeValidator>-->
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ange ett anställningsnummer, 1 - 999999999" ControlToValidate="txtSearch" ValidationExpression="^[0-9]{1,9}" ForeColor="#FF3300" Display="None"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ange ett anställningsnummer, 1 - 99999999" ControlToValidate="txtSearch" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <br />
                <asp:GridView ID="gridViewUserInfo" runat="server" Height="130px" Width="522px" />
            </div>
        </div>

    </form>
</body>
</html>
