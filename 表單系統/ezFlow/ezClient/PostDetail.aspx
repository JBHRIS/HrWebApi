<%@ Page Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="PostDetail.aspx.cs" Inherits="PostDetail" Title="ezClient v1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	<table border="0" width="100%">
		<tr>
			<td align="right">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td style="font-weight: bold; font-size: 12pt">
							<span style="font-size: 12pt; font-family: 新細明體; mso-bidi-font-family: 'Times New Roman';
								mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-TW;
								mso-bidi-language: AR-SA">◆ </span>
							<asp:Label ID="lbCaption" runat="server"></asp:Label>
							&gt;
							<asp:Label ID="lbSubject" runat="server"></asp:Label></td>
						<td width="1%">
							<asp:Button ID="bnNewPost" runat="server" Text="發表文章" OnClick="bnNewPost_Click" /></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<asp:DataList ID="DataList1" runat="server" DataKeyField="auto" DataSourceID="ObjectDataSource1" OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand">
					<ItemTemplate>
						<table border="1" bordercolordark="white" bordercolorlight="gray" cellpadding="0"
							cellspacing="0" width="100%">
							<tr>
								<td align="center" bgcolor="gray" style="width: 160px">
									<asp:Label ID="Label1" runat="server" Font-Size="Smaller" ForeColor="White" Text="作者"></asp:Label></td>
								<td align="left" bgcolor="gray">
									<table border="0" cellpadding="0" cellspacing="0" width="100%">
										<tr>
											<td style="width: 1%">
												<asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("moodType", "images/M{0}.gif") %>' /></td>
											<td>
												<asp:Label ID="Label2" runat="server" Font-Size="Smaller" ForeColor="White" Text="發表時間: "></asp:Label>
												<asp:Label ID="Label3" runat="server" Font-Size="Smaller" ForeColor="White" Text='<%# Eval("adate", "{0:yyyy-MM-dd HH:mm}") %>'></asp:Label></td>
											<td align="right" width="1%">
												<asp:Button ID="btnPraise" runat="server" Text="讚美獎勵" CommandArgument='<%# Eval("Emp_id") %>' CommandName="Praise" /></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="center" bgcolor="whitesmoke" rowspan="2" valign="top" style="width: 160px">
									<table border="0" width="90%">
										<tr>
											<td align="center" colspan="2" style="border-top-style: none; border-bottom: #000000 1px solid;
												border-right-style: none; border-left-style: none; height: 19px;">
												<asp:Label ID="lbName" runat="server" Font-Size="Smaller"></asp:Label></td>
										</tr>
										<tr>
											<td align="right" style="height: 23px" width="50%">
												<asp:Label ID="Label6" runat="server" Font-Size="Smaller" Text="發表次數: "></asp:Label></td>
											<td align="left" style="height: 23px">
												<asp:Label ID="lbPostCount" runat="server" Font-Size="Smaller"></asp:Label><asp:Label ID="Label8" runat="server" Font-Size="Smaller" Text="次"></asp:Label></td>
										</tr>
										<tr>
											<td align="right" width="50%">
												<asp:Label ID="Label7" runat="server" Font-Size="Smaller" Text="讚美獎勵: "></asp:Label></td>
											<td align="left">
												<asp:Label ID="lbPraiseCount" runat="server" Font-Size="Smaller"></asp:Label>
												<asp:Label ID="Label9" runat="server" Font-Size="Smaller" Text="個"></asp:Label></td>
										</tr>
										<tr>
											<td align="center" colspan="2" style="border-top: #000000 1px solid; border-right-style: none;
												border-left-style: none; border-bottom-style: none">
												<asp:Label ID="lbEmail" runat="server" Font-Size="Smaller"></asp:Label></td>
										</tr>
									</table>
								</td>
								<td align="left" bgcolor="#ffffff" valign="top" style="font-size: 12pt">
									<table border="0" cellpadding="0" cellspacing="0" width="100%">
										<tr>
											<td>
												<asp:Label ID="Label4" runat="server" Text='<%# Eval("content", "{0}<BR>") %>'></asp:Label></td>
										</tr>
										<tr>
											<td align="left" style="border-top: darkgray 1px solid; border-right-style: none;
												border-left-style: none; border-bottom-style: none; height: 50px;" valign="middle">
												<asp:Label ID="lbSignText" runat="server" Font-Size="Smaller"></asp:Label></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="right" bgcolor="whitesmoke">
									<table border="0" cellpadding="0" cellspacing="0" width="100%">
										<tr>
											<td style="height: 24px">
												&nbsp;<asp:Button ID="bnEdit" runat="server" CommandArgument='<%# Eval("auto") %>'
													CommandName="EditPost" Text="編輯" />
												<asp:Button ID="bnDel" runat="server" CommandArgument='<%# Eval("auto") %>' CommandName="DelPost"
													OnClientClick="return confirm('您確定要刪文並發出刪文通知嗎？')" Text="刪除" /></td>
											<td align="right" style="height: 24px">
									<asp:Button ID="Button1" runat="server" Text="回覆主題" CommandArgument='<%# Eval("auto") %>' CommandName="ReplyEmpty" />
												<asp:Button ID="Button4" runat="server" Text="引言回覆" CommandArgument='<%# Eval("auto") %>' CommandName="Reply" /></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</ItemTemplate>
				</asp:DataList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
					InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByPostMain"
					TypeName="ezClientDSTableAdapters.PostDetailTableAdapter" UpdateMethod="Update">
					<DeleteParameters>
						<asp:Parameter Name="Original_auto" Type="Int32" />
					</DeleteParameters>
					<UpdateParameters>
						<asp:Parameter Name="PostMain_auto" Type="Int32" />
						<asp:Parameter Name="content" Type="String" />
						<asp:Parameter Name="Emp_id" Type="String" />
						<asp:Parameter Name="adate" Type="DateTime" />
						<asp:Parameter Name="Original_auto" Type="Int32" />
					</UpdateParameters>
					<SelectParameters>
						<asp:QueryStringParameter Name="PostMain_auto" QueryStringField="PostMain_auto" Type="Int32" />
					</SelectParameters>
					<InsertParameters>
						<asp:Parameter Name="PostMain_auto" Type="Int32" />
						<asp:Parameter Name="content" Type="String" />
						<asp:Parameter Name="Emp_id" Type="String" />
						<asp:Parameter Name="adate" Type="DateTime" />
					</InsertParameters>
				</asp:ObjectDataSource>
			</td>
		</tr>
	</table>
</asp:Content>

