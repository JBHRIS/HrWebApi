<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodPost.aspx.cs" Inherits="GoodPost" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body style="background-image: url(images/dye_fa_0019.gif); background-repeat: repeat-y; margin-left: 70px;
	margin-top: 20px;">
    <form id="form1" runat="server">    
		<table border="0" height="99%" width="650px">
			<tr>
				<td align="center" style="width:100%; height: 1%">
					<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="◎　最佳文章精選　◎"></asp:Label></td>
			</tr>
			<tr>
				<td align="center" style="width: 100%; height: 1%; border-bottom: #cc00ff 3px double;">
					<asp:Label ID="Label2" runat="server" Font-Bold="True" Text="主旨："></asp:Label><asp:Label ID="lbSubject" runat="server" Font-Bold="True"></asp:Label></td>
			</tr>
			<tr>
				<td style="width: 100%; border-top-width: 1px; border-left-width: 1px; border-left-color: #000000; border-bottom-width: 1px; border-bottom-color: #000000; border-top-color: #000000; border-right-width: 1px; border-right-color: #000000;" valign="top">
					<asp:Label ID="lbContent" runat="server" Width="100%"></asp:Label></td>
			</tr>
			<tr>
				<td align="center" style="border-right: #000000 1px; border-top: #cc00ff 3px double; border-left: #000000 1px;
					border-bottom: #000000 1px; width: 100%; height: 1%" valign="top">
					<asp:Label ID="lbDate" runat="server" Font-Bold="False" Font-Size="Smaller"></asp:Label></td>
			</tr>
			<tr>
				<td align="center" style="border-right: #000000 1px; border-top: #000000 1px; border-left: #000000 1px;
					width: 100%; border-bottom: #000000 1px; height: 1%" valign="top">
					&nbsp;</td>
			</tr>
		</table>    
    </form>
</body>
</html>
