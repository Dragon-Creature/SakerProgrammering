<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.1/themes/base/jquery-ui.css" type="html/css" media="all" />
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

            $('input[name=chkDoctor]').change(function () {
                if ($(this).attr('checked')) {
                    $('#DivDoctor').fadeOut();
                    return;
                }
                $('#DivDoctor').fadeIn();
            });

            $('input[name=chkChild]').change(function () {
                if ($(this).attr('checked')) {
                    $('#DivChild').fadeOut();
                    return;
                }
                $('#DivChild').fadeIn();
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Sjukanmälan</h1>
        <asp:Label ID="lblFromDate" runat="server" Text="Från och med:" AssociatedControlID="txtFromDate"></asp:Label>
        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDoctor" runat="server" Text="Sjukskriven av läkare?"></asp:Label>
        <input type="checkbox" name="chkDoctor" />
        <br />
        <div id="DivDoctor" style="display: none">
            <asp:Label ID="lblToDate" runat="server" Text="Till och med:" AssociatedControlID="txtToDate"></asp:Label>
            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
            <br />
        </div>
        <asp:Label ID="lblChild" runat="server" Text="Vård av barn?"></asp:Label>
        <input type="checkbox" name="chkChild" />
        <div id="DivChild" style="display: none">
            <asp:Label ID="Label1" runat="server" Text="Barnets Personnummer:" AssociatedControlID="txtChild"></asp:Label>
            <asp:TextBox ID="txtChild" runat="server"></asp:TextBox>
            <br />
        </div>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Skicka" />
    </div>
    </form>
</body>
</html>
