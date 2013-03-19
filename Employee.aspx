<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="http://localhost:50075/ajax.googleapis.com/ajax/libs/jqueryui/1.10.1/themes/base/jquery-ui.css" type="html/css" media="all" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.1/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //$('#DivDoctor').hide();

            $(function () {
                $('#txtFromDate').val('<%= DateTime.Now.ToString("yyyy-MM-dd") %>');
                $('#txtFromDate').datepicker({
                    dateFormat: 'yy-mm-dd'
                });

                $('#txtToDate').val('<%= DateTime.Now.ToString("yyyy-MM-dd") %>');
                $('#txtToDate').datepicker({
                    dateFormat: 'yy-mm-dd'
                });
            });


            $('#radioDiv input').click(function () {
                var selected = $("#radioDiv input:radio:checked").val();
                $("#DivDoctor").hide();
                $("#DivChild").hide();
                //alert(selected);
                //$("#info").text('Selected Value: ' + $("#RadioDiv input:radio:checked").val());
                if ($("#radioDiv input:radio:checked").val() == "Sjukskriven av läkare") {
                    $("#DivDoctor").fadeIn();
                }
                else if ($("#radioDiv input:radio:checked").val() == "Vård av barn") {
                    $("#DivChild").fadeIn();
                }
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" Text="Logga ut" OnClick="btnLogout_Click" />
    <div>
        <h1>Sjukanmälan</h1>
        <asp:Label ID="lblFromDate" runat="server" Text="Från och med:" AssociatedControlID="txtFromDate"></asp:Label>
        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="txtFromDateValidator" runat="server" ErrorMessage="Ange ett datum med formatet: ÅÅÅÅ-MM-DD" ValidationExpression="^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$" ControlToValidate="txtFromDate" ForeColor="#FF3300"></asp:RegularExpressionValidator>
        <br />
        <div id="radioDiv">
        <fieldset>
        <legend>Välj ett alternativ</legend>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Selected="True">Första sjukdagen</asp:ListItem>
                <asp:ListItem>Sjukskriven av läkare</asp:ListItem>
                <asp:ListItem>Vård av barn</asp:ListItem>
            </asp:RadioButtonList>
        </fieldset>
        </div>
        <div id="DivDoctor" style="display: none">
                    <asp:Label ID="lblToDate" runat="server" Text="Till och med:" AssociatedControlID="txtToDate"></asp:Label>
                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="txtToDateValidator" runat="server" ErrorMessage="Ange ett datum med formatet: ÅÅÅÅ-MM-DD" ValidationExpression="^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$" ControlToValidate="txtToDate"></asp:RegularExpressionValidator>
            </div>
            <div id="DivChild" style="display: none">
                <asp:Label ID="Label1" runat="server" Text="Barnets Personnummer:" AssociatedControlID="txtChild"></asp:Label>
                <asp:TextBox ID="txtChild" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="txtChildValidator" runat="server" ErrorMessage='Ange ett personnummer med formatet: "ÅÅMMDD-xxxx"' ValidationExpression="\d{6}-\d{4}" ControlToValidate="txtChild" ForeColor="#FF3300"></asp:RegularExpressionValidator>
            </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Skicka" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
