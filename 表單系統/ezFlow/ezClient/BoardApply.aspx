<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BoardApply.aspx.cs" Inherits="BoardApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body style="margin-top:35px;margin-left:50px; background-image: url(images/dye_fa_0005.gif); background-repeat: repeat-y;">
    <form id="form1" runat="server">    
		<table border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td align="center" colspan="2" style="height: 22px">
					<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" Text="◎　開立新板申請表　◎"></asp:Label></td>
			</tr>
			<tr>
				<td align="right">
				</td>
				<td align="left">
					&nbsp;</td>
			</tr>
			<tr>
				<td align="right">
					<asp:Label ID="Label6" runat="server" Text="申請人: "></asp:Label></td>
				<td align="left">
					<asp:Label ID="lbName" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td align="right">
					<asp:Label ID="Label1" runat="server" Text="討論區名稱: "></asp:Label></td>
				<td align="left">
					<asp:TextBox ID="txtBoardName" runat="server" Font-Size="Medium" Width="300px"></asp:TextBox></td>
			</tr>
			<tr>
				<td align="right">
					<asp:Label ID="Label2" runat="server" Text="討論區簡要: "></asp:Label></td>
				<td align="left">
					<asp:TextBox ID="txtBoardNote" runat="server" Font-Size="Medium" Rows="2" TextMode="MultiLine"
						Width="300px"></asp:TextBox></td>
			</tr>
			<tr>
				<td align="right">
					<asp:Label ID="Label3" runat="server" Text="推薦副板主: "></asp:Label></td>
				<td align="left">
					<asp:TextBox ID="txtAdmin2" runat="server" Font-Size="Medium"></asp:TextBox>
					<asp:Label ID="Label4" runat="server" Text="(完整姓名)"></asp:Label></td>
			</tr>
			<tr>
				<td align="right">
				</td>
				<td align="left">
					&nbsp;</td>
			</tr>
			<tr>
				<td align="right">
				</td>
				<td align="left">
					<asp:Button ID="bnOK" runat="server" Text="送出申請" Font-Underline="False" OnClick="bnOK_Click" /></td>
			</tr>
		</table>    
    </form>
</body>
</html>
