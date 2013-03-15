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
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Ange ett anställningsnummer från 1 - 999999999" Type="Integer" MaximumValue="999999999" MinimumValue="1" ControlToValidate="txtSearch" Display="Dynamic" EnableClientScript="False" ForeColor="#FF3300"></asp:RangeValidator>
                <br />
                <asp:GridView ID="gridViewUserInfo" runat="server" Height="130px" Width="522px">
                    <%--<Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Fr.o.m" HeaderText="Fr.o.m" />
                        <asp:BoundField DataField="Läkarintyg" HeaderText="Läkarintyg" />
                        <asp:BoundField DataField="T.o.m" HeaderText="T.o.m" />
                        <asp:BoundField DataField="Barnets personnummer" HeaderText="Barnets personnummer" />
                    </Columns>--%>
                </asp:GridView>
            </div>
        </div>

    </form>
</body>
</html>
