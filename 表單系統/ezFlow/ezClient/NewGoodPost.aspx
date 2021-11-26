<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewGoodPost.aspx.cs" Inherits="NewGoodPost" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body style="margin-left:16px">
    <form id="form1" runat="server">
		<table border="0" style="width: 100%; height: 100%">
			<tr>
				<td align="right" style="height: 1%; word-break:keep-all" nowrap="noWrap" width="1%">
					<asp:Label ID="Label1" runat="server" Text="文章主題"></asp:Label></td>
				<td style="height: 1%">
					<asp:TextBox ID="txtCaption" runat="server" Width="100%"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="2" style="width: 100%; height: 98%">
					<fckeditorv2:fckeditor id="txtContent" runat="server" height="100%" Width="100%">
					</fckeditorv2:fckeditor>
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
