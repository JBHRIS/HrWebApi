<%@ Page AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" Language="C#"
	MasterPageFile="~/MasterPage3.master" Title="ezClient v1.0" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	<asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center"
		Width="100%" style="background-position-x: center; background-attachment: scroll; background-image: url(images/dye_fa_0127.gif); background-repeat: repeat-y; background-color: whitesmoke; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;">
		<table border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
		<tr>
			<td align="center" colspan="2" style="height: 18px">			
				&nbsp;</td>
		</tr>
		<tr>
			<td style="width: 34px; border-left: #000000 1px; border-top-style: none; border-right-style: none; height: 1%; border-bottom-style: none;">
				<asp:Label ID="Label2" runat="server" Text="心情"></asp:Label></td>
			<td style="border-right: #000000 1px; border-top-style: none; border-left-style: none; height: 1%; border-bottom-style: none">
				<table border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td style="height: 21px">
							&nbsp;<asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="Mood"
								Text=" " /></td>
						<td style="height: 21px">
							<img src="images/M1.gif" /></td>
						<td style="height: 21px">
							(開心)</td>
						<td style="height: 21px">
							&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="Mood" Text=" " /></td>
						<td style="height: 21px">
							<img src="images/M2.gif" /></td>
						<td style="height: 21px">
							(哀傷)</td>
						<td style="height: 21px">
							&nbsp;<asp:RadioButton ID="RadioButton3" runat="server" GroupName="Mood" Text=" " /></td>
						<td style="height: 21px">
							<img src="images/M3.gif" /></td>
						<td style="height: 21px">
							(驚訝)</td>
						<td style="height: 21px">
							&nbsp;<asp:RadioButton ID="RadioButton4" runat="server" GroupName="Mood" Text=" " /></td>
						<td style="height: 21px">
							<img src="images/M4.gif" /></td>
						<td style="height: 21px">
							(困惑)</td>
						<td style="height: 21px">
							&nbsp;<asp:RadioButton ID="RadioButton5" runat="server" GroupName="Mood" Text=" " /></td>
						<td style="height: 21px">
							<img src="images/M5.gif" /></td>
						<td style="height: 21px">
							(生氣)</td>
						<td style="height: 21px">
							&nbsp;<asp:RadioButton ID="RadioButton6" runat="server" GroupName="Mood" Text=" " /></td>
						<td style="height: 21px">
							<img src="images/M6.gif" /></td>
						<td style="height: 21px">
							(普通)</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td style="border-right: #000000 1px; border-top: #000000 1px; border-left: #000000 1px;
				width: 34px; border-bottom: #000000 1px; height: 1%" valign="middle">
				<asp:Label ID="Label1" runat="server" Text="標題"></asp:Label></td>
			<td style="border-right: #000000 1px; border-top-style: none; border-bottom: #000000 1px;
				border-left-style: none; height: 1%">
				<asp:TextBox ID="txtSubject" runat="server" Width="600px" Font-Size="Small"></asp:TextBox></td>
		</tr>
		<tr>
			<td style="width: 34px; border-right: #000000 1px; border-top: #000000 1px; border-left: #000000 1px; border-bottom: #000000 1px;" valign="middle" height="1%">
				<asp:Label ID="Label3" runat="server" Text="內容"></asp:Label></td>
			<td style="border-right: #000000 1px; border-top-style: none; border-bottom: #000000 1px; border-left-style: none" height="1%">
				<fckeditorv2:fckeditor id="txtContent" runat="server" Height="300px"></fckeditorv2:fckeditor>
			</td>
		</tr>
		<tr>
			<td align="center" bgcolor="whitesmoke" colspan="2" style="height: 24px">
				&nbsp;<asp:Button ID="bnSave" runat="server" Text="送出張貼" OnClick="bnSave_Click" />
				<asp:Button ID="bnCancel" runat="server" Text="取消張貼" OnClick="bnCancel_Click" /></td>
		</tr>
		<tr>
			<td align="center" bgcolor="whitesmoke" colspan="2" style="height: 24px">
				&nbsp;</td>
		</tr>
	</table>
	</asp:Panel>
</asp:Content>
