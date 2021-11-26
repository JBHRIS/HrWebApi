<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="eTraining_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    table td img {display:block;}
    table td input{display:block;}    
    </style>
</head>
<body style="background-color: #e1eaf3">
    <form id="form1" runat="server">
    <div align="center" style="background-color: #e1eaf3; width: auto; height: auto;">
        <table border="0" cellpadding="0" style="border-collapse: collapse;">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/eTraining/login_1.gif" />
                </td>
                <td>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/eTraining/login_2.gif" />
                </td>
                <td>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/eTraining/login_3.gif" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/eTraining/login_4.gif" />
                </td>
                <td style="background-image: url('Images/eTraining/login_5.gif');">
                    <table style="width: 100%; height: 100px;">
    <tr>
        <td>
            帳號
        </td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtID" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            密碼
        </td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtPW" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2"<%-- style="text-align: center"--%> align="right">            
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
            </telerik:RadScriptManager>
            <telerik:RadButton ID="btnSubmit" runat="server" Text="登入" 
                onclick="btnSubmit_Click" style="top: 0px; left: 0px">
            </telerik:RadButton>
        </td>
    </tr>
</table>
                </td>
                <td>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/eTraining/login_6.gif" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/eTraining/login_7.gif" />
                </td>
                <td>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/eTraining/login_8.gif" />
                </td>
                <td>
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/eTraining/login_9.gif" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
