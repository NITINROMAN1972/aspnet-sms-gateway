<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendSMS.aspx.cs" Inherits="SendSMS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form1" runat="server">
        <div>
        </div>
    </form>--%>

    <form id="form2" runat="server">
        <table border="0">
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSend" runat="server" Text="Send SMS" OnClick="btnSend_Click" />
                </td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
