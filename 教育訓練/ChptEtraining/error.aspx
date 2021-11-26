<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="eTraining_error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #d4e6f8">
    <form id="form1" runat="server">
    <div align="center" style="background-color: #d4e6f8; width: auto; height: auto;">
<%--    table-layout: fixed;
word-wrap:break-word;
--%><%--
<table style="table-layout:fixed"></table>--%>

        <table border="0" width="640" cellpadding="0" style="border-collapse: collapse">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl="~/Images/eTraining/error_01.gif" />
                </td>
                <td>
                    <asp:Image ID="Image2" runat="server" 
                        ImageUrl="~/Images/eTraining/error_02.gif" />
                </td>
                <td>
                    <asp:Image ID="Image3" runat="server" 
                        ImageUrl="~/Images/eTraining/login_03.gif" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="Image4" runat="server" 
                        ImageUrl="~/Images/eTraining/error_04.gif" />
                </td>
                <td style="background-color:White;word-break:break-all">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    <br />
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" 
                    NavigateUrl="~/Default.aspx">回首頁</asp:HyperLink>
                </td>
                <td>
                    <asp:Image ID="Image6" runat="server" 
                        ImageUrl="~/Images/eTraining/login_06.gif" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="Image7" runat="server" 
                        ImageUrl="~/Images/eTraining/login_07.gif" />
                </td>
                <td>
                    <asp:Image ID="Image8" runat="server" 
                        ImageUrl="~/Images/eTraining/login_08.gif" />
                </td>
                <td>
                    <asp:Image ID="Image9" runat="server" 
                        ImageUrl="~/Images/eTraining/login_09.gif" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
