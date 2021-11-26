<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HrPost.aspx.cs" Inherits="HrPost" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body class="DlgPage" STYLE="OVERFLOW:SCROLL;OVERFLOW-X:HIDDEN" scroll="auto">
<div class="Dlg">
    <form id="form1" runat="server">
		<table border="0" width="630" height="99%">
			<tr>
				<td class="DlgHeader" align="center" style="width:100%; height: 1%">
					<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="◎　最新消息公告　◎"></asp:Label></td>
			</tr>
			<tr>
				<td align="center" style="width: 100%; height: 1%">
					<asp:Label ID="Label2" runat="server" Font-Bold="True" Text="主旨："></asp:Label><asp:Label ID="lbSubject" runat="server" Font-Bold="True"></asp:Label></td>
			</tr>
			<tr>
				<td style="border: #CCCCCC 3px double; width: 100%;" valign="top">
					<asp:Label ID="lbContent" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td align="center" style="border-right: #000000 1px; border-top: #000000 1px; border-left: #000000 1px;
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
    </div>
</body>
</html>
