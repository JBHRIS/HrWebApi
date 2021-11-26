<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestSpeed.aspx.cs" Inherits="Test_TestSpeed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    <asp:TextBox ID="txtNobr" runat="server">110406</asp:TextBox>
                    <asp:Button ID="btnService" runat="server" onclick="btnService_Click" 
                        Text="服務" />
                    <asp:Button ID="btnOldService" runat="server" onclick="btnOldService_Click" 
                        Text="傳統服務" />
                    <asp:Button ID="btnDll" runat="server" onclick="btnDll_Click" Text="DLL" />
                    <asp:Label ID="lblTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
