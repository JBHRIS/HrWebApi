<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="DataInfo.aspx.cs" Inherits="DataInfo" Title="ezClient v1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	<asp:Panel ID="Panel1" runat="server" Height="500px" Width="100%">
	<iframe src="about.htm" width="100%" height="100%" frameborder="0" scrolling="auto"></iframe>
	</asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td align="center" background="images/dye_li_pe_003.gif" height="56">
				<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/LoginData.aspx" Font-Bold="True" Font-Names="標楷體">帳號資料變更</asp:LinkButton></td>
		</tr>
		<tr>
			<td align="center" background="images/dye_li_pe_004.gif" height="56">
				<asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Agent.aspx" Font-Bold="True" Font-Names="標楷體">我的代理規劃</asp:LinkButton></td>
		</tr>
		<tr>
			<td align="center" background="images/dye_li_pe_002.gif" height="56">
				<asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/NewBoard.aspx" Font-Bold="True" Font-Names="標楷體">新板申請進度</asp:LinkButton></td>
		</tr>
	</table>
</asp:Content>

