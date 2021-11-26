<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WriteGuest.aspx.cs" Inherits="WriteGuest" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body style="margin-left:16px">
    <form id="form1" runat="server">    
		<table border="0" style="width: 100%; height: 100%">
			<tr>
				<td align="right" style="height: 1%">
					<asp:Label ID="Label1" runat="server" Text="留言對象(工號 or 姓名 or Email)"></asp:Label></td>
				<td style="height: 1%">
					<asp:TextBox ID="txtName" runat="server" Width="233px" AutoPostBack="True" OnTextChanged="txtName_TextChanged"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="2" style="width: 100%; height: 98%">
					<FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="100%">
					</FCKeditorV2:FCKeditor>
				</td>
			</tr>
			<tr>
				<td align="center" colspan="2" style="width: 100%; height: 1%">
					<asp:Button ID="bnSend" runat="server" Text="送出" OnClick="bnSend_Click" /></td>
			</tr>
		</table>
    </form>
</body>
</html>
