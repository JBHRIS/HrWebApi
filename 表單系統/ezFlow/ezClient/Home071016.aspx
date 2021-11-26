<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home071016.aspx.cs" Inherits="Home" Title="ezClient v1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:DataList ID="DataList1" runat="server" DataKeyField="auto" DataSourceID="ObjectDataSource1" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound">
		<ItemTemplate>
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td nowrap="nowrap" valign="top" width="1%">
						<asp:Label ID="Label9" runat="server" Font-Size="Smaller" Text="日期:" Font-Bold="True" ForeColor="Navy"></asp:Label></td>
					<td valign="top">
			<asp:Label ID="adateLabel" runat="server" Text='<%# Eval("adate", "{0:yyyy-MM-dd HH:mm}") %>' Font-Size="Smaller" Font-Bold="True" ForeColor="Navy"></asp:Label></td>
				</tr>
				<tr>
					<td nowrap="nowrap" valign="top" width="1%">
						<asp:Label ID="Label10" runat="server" Font-Size="Smaller" Text="主題:" ForeColor="Navy"></asp:Label></td>
					<td>
			<asp:LinkButton ID="lnkBtnCaption" runat="server" CommandArgument='<%# Eval("auto") %>'
				CommandName="Link" Text='<%# Eval("caption") %>' Font-Size="Smaller"></asp:LinkButton></td>
				</tr>
			</table>
		</ItemTemplate>
		<SeparatorTemplate>
			<hr />
		</SeparatorTemplate>
		<HeaderTemplate>
			<asp:Button ID="bnAdmin" runat="server" CommandName="NewPost" Text="張貼最新公告" Width="100%" />
		</HeaderTemplate>
		<HeaderStyle BackColor="Silver" HorizontalAlign="Center" />
	</asp:DataList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
		SelectMethod="GetData" TypeName="ezClientDSTableAdapters.HrPostTableAdapter"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	<table border="0" width="100%">
		<tr>
			<td align="left" style="border-top-style: none; border-bottom: #000000 1px solid;
				border-right-style: none; border-left-style: none">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td style="height: 21px">
							<asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Smaller" Text="您好！"></asp:Label>
							<asp:Label ID="lbName" runat="server" Font-Bold="True" Font-Size="Smaller"></asp:Label>
							<asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Smaller" Text="，歡迎您回來…"></asp:Label></td>
						<td align="right" style="height: 21px">
				<asp:Label ID="lbMsg" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Red"></asp:Label></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td bgcolor="#ccccff" style="border-right: #009900 3px double; border-top: #009900 3px double;
				border-left: #009900 3px double; border-bottom: #009900 3px double; height: 21px">
				<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Font-Size="Smaller"
					OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
					<asp:ListItem Value="1" Selected="True">我的行事曆</asp:ListItem>
					<asp:ListItem Value="2">行事曆查詢</asp:ListItem>
					<asp:ListItem Value="0">討論區列表</asp:ListItem>
				</asp:RadioButtonList></td>
		</tr>
		<tr>
			<td style="height: 21px">
				<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
					<asp:View ID="View1" runat="server">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td style="border-top: #000000 1px solid; border-right: #000000 3px double; height: 22px; border-left: #000000 3px double; width: 50%;" valign="middle">
							<asp:Image ID="Image1" runat="server" ImageUrl="~/images/no1.bmp" /><asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Smaller" Text="最多讚美:" ForeColor="Red"></asp:Label><asp:Label ID="lbBestPraise" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Red"></asp:Label></td>
						<td style="border-top: #000000 1px solid; height: 22px; border-right: #000000 3px double;" align="center" width="50%" bgcolor="linen">
							<table border="0" cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td align="center">
										<img src="images/dye_ob_st_021.gif" /></td>
									<td align="center">
										<strong>一我的留言板一</strong></td>
									<td align="center">
										<img src="images/dye_ob_st_021.gif" /></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style="border-right: #000000 3px double; height: 21px; border-left: #000000 3px double; width: 50%;" valign="middle">
							<asp:Image ID="Image2" runat="server" ImageUrl="~/images/no1.bmp" /><asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Smaller" Text="最多張貼:" ForeColor="Blue"></asp:Label><asp:Label ID="lbBestPost" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Blue"></asp:Label></td>
						<td style="height: 21px; border-right: #000000 3px double;" align="center" width="50%">
							<asp:LinkButton ID="linkBtnGuest" runat="server" Font-Bold="True" Font-Size="Smaller"
								OnClick="linkBtnGuest_Click">目前沒有尚未閱讀的留言</asp:LinkButton></td>
					</tr>
					<tr>
						<td style="border-right: #000000 3px double; height: 21px; border-bottom: #000000 1px solid; border-left: #000000 3px double; width: 50%;" valign="middle">
							<asp:Image ID="Image3" runat="server" ImageUrl="~/images/no1.bmp" /><asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Smaller" Text="最多回應:" ForeColor="Green"></asp:Label><asp:Label ID="lbBestReply" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Green"></asp:Label></td>
						<td align="center" style="height: 21px; border-right: #000000 3px double; border-bottom: #000000 1px solid;" width="50%">
							<asp:Button ID="bnGuestHistory" runat="server" OnClick="bnGuestHistory_Click" Text="看全部留言" Width="49%" /><asp:Button
								ID="bnWriteGuest" runat="server" Text="留言給別人" OnClick="bnWriteGuest_Click" Width="49%" /></td>
					</tr>
				</table>
								</td>
							</tr>
							<tr>
								<td background="images/tb-m-1.GIF">
				<asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Smaller" Text="↙討論區列表↗"></asp:Label></td>
							</tr>
							<tr>
								<td>
				<asp:DataList ID="dlstBoard" runat="server" DataKeyField="auto" DataSourceID="ObjectDataSource3" OnItemDataBound="dlstBoard_ItemDataBound" Font-Bold="True">
					<ItemTemplate>
						<table border="0" style="border-right: #cccccc 1px solid; border-top: #cccccc 1px;
							font-size: 10pt; border-left: #cccccc 1px solid; border-bottom: #cccccc 1px solid"
							width="100%">
							<tr>
								<td align="right" style="height: 20px" width="1%" valign="middle">
									<asp:Label ID="Label3" runat="server" ForeColor="#993333" Text="★"></asp:Label></td>
								<td style="height: 20px" width="65%" valign="middle">
									<asp:Label ID="captionLabel" runat="server" Text='<%# Eval("caption") %>' Font-Bold="True" ForeColor="#993333"></asp:Label></td>
								<td align="right" style="height: 20px" width="10%" valign="middle">
									板主:</td>
								<td align="left" style="height: 20px" valign="middle">
									<asp:Label ID="lbAdmin" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td align="right" style="height: 20px" valign="top">
								</td>
								<td colspan="3" style="height: 20px" width="50%" valign="top">
									<asp:Label ID="noteLabel" runat="server" Text='<%# Eval("note") %>' Font-Italic="False" ForeColor="#CC9933"></asp:Label></td>
							</tr>
						</table>
					</ItemTemplate>
					<AlternatingItemStyle BackColor="WhiteSmoke" />
					<ItemStyle BackColor="White" />
				</asp:DataList><asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}"
					SelectMethod="GetData" TypeName="ezClientDSTableAdapters.BoardListTableAdapter">
				</asp:ObjectDataSource>
								</td>
							</tr>
							<tr>
								<td background="images/tb-m-1.GIF" style="height: 16px">
				<asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Smaller" Text="↙新板申請區↗"></asp:Label></td>
							</tr>
							<tr>
								<td style="font-size: 10pt; height: 50px">
				您覺得有滿腹文章，卻找不到合適的討論區可以發表嗎？<br />
				或者，您也想當板主呢？又或者？？？<br />
				不管您有什麼理由…請先填寫<asp:LinkButton ID="LinkButton1" runat="server" OnClick="linkBtnBoardApply_Click">申請單</asp:LinkButton>，經審核通過後，即可開立新板。</td>
							</tr>
						</table>
					</asp:View>
					<asp:View ID="View2" runat="server">
						<table border="0" cellpadding="0" cellspacing="0" style="border-top: #000000 1px;
							border-bottom: #000000 3px; border-right-style: none; border-left-style: none;" width="100%">
							<tr>
								<td align="center">
											<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black"
												Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth"
												OnDayRender="Calendar1_DayRender" ShowGridLines="True" Width="100%" OnSelectionChanged="Calendar1_SelectionChanged" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged">
												<SelectedDayStyle BackColor="Yellow" ForeColor="Black" />
												<TodayDayStyle ForeColor="Blue" />
												<DayStyle BorderColor="Black" BorderStyle="Solid" Font-Bold="True" />
												<WeekendDayStyle BackColor="#FFC0C0" />
												<OtherMonthDayStyle Font-Bold="False" ForeColor="#999999" />
												<NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
												<DayHeaderStyle BackColor="#C0C0FF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
													Font-Bold="True" Font-Size="8pt" ForeColor="Navy" />
												<TitleStyle BackColor="#FFFFC0" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
													Font-Size="12pt" ForeColor="#333399" />
											</asp:Calendar>
								</td>
							</tr>
							<tr>
								<td style="border-top: #000000 3px; padding-bottom: 5px; border-bottom: #000000 1px; border-right-style: none; border-left-style: none" align="center">									
										<asp:Label ID="Label48" runat="server" Font-Size="Smaller" ForeColor="Orange" Text="█"></asp:Label>
										<asp:Label ID="Label49" runat="server" Font-Size="Smaller" Text="個人記事"></asp:Label>
									<asp:Label ID="Label56" runat="server" Font-Size="Smaller" ForeColor="White" Text="█"></asp:Label>
									<asp:Label
											ID="Label50" runat="server" Font-Size="Smaller" ForeColor="MediumOrchid" Text="█"></asp:Label>
										<asp:Label ID="Label51" runat="server" Font-Size="Smaller" Text="留言記事"></asp:Label>
									<asp:Label ID="Label57" runat="server" Font-Size="Smaller" ForeColor="White" Text="█"></asp:Label>
									<asp:Label
											ID="Label52" runat="server" Font-Size="Smaller" ForeColor="Green" Text="█"></asp:Label>
										<asp:Label ID="Label53" runat="server" Font-Size="Smaller" Text="部門記事"></asp:Label>
									<asp:Label ID="Label58" runat="server" Font-Size="Smaller" ForeColor="White" Text="█"></asp:Label>
									<asp:Label
											ID="Label54" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="█"></asp:Label>
										<asp:Label ID="Label55" runat="server" Font-Size="Smaller" Text="公司記事"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" bgcolor="#ffffff" style="border-right: #ccccff 3px; border-top: #6699ff 3px double;
									border-left: #ccccff 3px; border-bottom: #6699ff 3px double">
						<asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" Font-Size="Smaller"
							OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal">
							<asp:ListItem Selected="True" Value="0">行事記錄列表</asp:ListItem>
							<asp:ListItem Value="1">新增個人記事</asp:ListItem>
							<asp:ListItem Value="2">新增部門記事</asp:ListItem>
							<asp:ListItem Value="3">新增公司記事</asp:ListItem>
						</asp:RadioButtonList></td>
							</tr>
						</table>
						<asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
							<asp:View ID="View3" runat="server">
								<asp:Label ID="Label19" runat="server" Font-Size="Smaller" Text="查詢日期：" Font-Bold="True"></asp:Label>
								<asp:Label ID="lbQueryDate" runat="server" Font-Size="Smaller" Font-Bold="True"></asp:Label>
								<br />
								<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="auto"
									DataSourceID="ObjectDataSource4" OnRowDataBound="GridView1_RowDataBound" Width="100%" Caption="↙個人記事↗">
									<Columns>
										<asp:TemplateField ShowHeader="False">
											<EditItemTemplate>
												<asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
													Text="更新" />&nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False"
														CommandName="Cancel" Text="取消" />
												<asp:Label ID="Label20" runat="server" Text='<%# Bind("auto") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label21" runat="server" Text='<%# Bind("Emp_id") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label22" runat="server" Text='<%# Bind("adate") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label83" runat="server" Text='<%# Bind("Emp_idSource", "{0}") %>'
													Visible="False"></asp:Label>
												<asp:Label ID="Label84" runat="server" Text='<%# Bind("msgType", "{0}") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label29" runat="server" Text='<%# Bind("calType", "{0}") %>' Visible="False"></asp:Label>
											</EditItemTemplate>
											<ItemStyle Width="1%" Wrap="False" />
											<ItemTemplate>
												<asp:Button ID="bnEdit" runat="server" CausesValidation="False" CommandName="Edit"
													Text="編輯" />&nbsp;<asp:Button ID="bnDel" runat="server" CausesValidation="False"
														CommandName="Delete" OnClientClick="return confirm('刪除確認')" Text="刪除" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="開始" SortExpression="timeB">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("timeB") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="Label1" runat="server" Text='<%# Bind("timeB") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="結束" SortExpression="timeE">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("timeE") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="Label2" runat="server" Text='<%# Bind("timeE") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="記事" SortExpression="content">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("content") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Left" />
											<HeaderStyle HorizontalAlign="Left" />
											<ItemTemplate>
												<asp:Label ID="Label3" runat="server" Text='<%# Bind("content") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="訊息來源" SortExpression="Emp_idSource">
											<EditItemTemplate>
												&nbsp;<asp:Label ID="lbIdSource" runat="server"></asp:Label>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="lbIdSource" runat="server"></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView><asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="auto"
									DataSourceID="ObjectDataSource6" OnRowDataBound="GridView1_RowDataBound" Width="100%" Caption="↙訊息留言↗">
									<Columns>
										<asp:TemplateField ShowHeader="False">
											<EditItemTemplate>
												<asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
													Text="更新" />
												<asp:Button ID="Button2" runat="server" CausesValidation="False"
														CommandName="Cancel" Text="取消" />
												<asp:Label ID="Label20" runat="server" Text='<%# Bind("auto") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label21" runat="server" Text='<%# Bind("Emp_id") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label22" runat="server" Text='<%# Bind("adate") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label83" runat="server" Text='<%# Bind("Emp_idSource", "{0}") %>'
													Visible="False"></asp:Label>
												<asp:Label ID="Label84" runat="server" Text='<%# Bind("msgType", "{0}") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label85" runat="server" Text='<%# Bind("calType", "{0}") %>' Visible="False"></asp:Label>
											</EditItemTemplate>
											<ItemStyle Width="1%" Wrap="False" />
											<ItemTemplate>
												<asp:Button ID="bnEdit" runat="server" CausesValidation="False" CommandName="Edit"
													Text="編輯" />
												<asp:Button ID="bnDel" runat="server" CausesValidation="False"
														CommandName="Delete" OnClientClick="return confirm('刪除確認')" Text="刪除" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="開始" SortExpression="timeB">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("timeB") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="Label1" runat="server" Text='<%# Bind("timeB") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="結束" SortExpression="timeE">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("timeE") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="Label2" runat="server" Text='<%# Bind("timeE") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="記事" SortExpression="content">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("content") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Left" />
											<HeaderStyle HorizontalAlign="Left" />
											<ItemTemplate>
												<asp:Label ID="Label3" runat="server" Text='<%# Bind("content") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="訊息來源" SortExpression="Emp_idSource">
											<EditItemTemplate>
												&nbsp;<asp:Label ID="lbIdSource" runat="server"></asp:Label>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="lbIdSource" runat="server"></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
								<asp:ObjectDataSource ID="ObjectDataSource6" runat="server" DeleteMethod="Delete"
									InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByType2"
									TypeName="ezClientDSTableAdapters.CalendarTableAdapter" UpdateMethod="Update">
									<DeleteParameters>
										<asp:Parameter Name="Original_auto" Type="Int32" />
									</DeleteParameters>
									<UpdateParameters>
										<asp:Parameter Name="Emp_id" Type="String" />
										<asp:Parameter Name="adate" Type="DateTime" />
										<asp:Parameter Name="timeB" Type="String" />
										<asp:Parameter Name="timeE" Type="String" />
										<asp:Parameter Name="calType" Type="String" />
										<asp:Parameter Name="content" Type="String" />
										<asp:Parameter Name="Emp_idSource" Type="String" />
										<asp:Parameter Name="msgType" Type="String" />
										<asp:Parameter Name="Original_auto" Type="Int32" />
										<asp:Parameter Name="auto" Type="Int32" />
									</UpdateParameters>
									<SelectParameters>
										<asp:SessionParameter Name="Emp_id" SessionField="Emp_id" Type="String" />
										<asp:SessionParameter Name="DateB" SessionField="baseDateB" Type="DateTime" />
										<asp:SessionParameter Name="DateE" SessionField="baseDateE" Type="DateTime" />
									</SelectParameters>
									<InsertParameters>
										<asp:Parameter Name="Emp_id" Type="String" />
										<asp:Parameter Name="adate" Type="DateTime" />
										<asp:Parameter Name="timeB" Type="String" />
										<asp:Parameter Name="timeE" Type="String" />
										<asp:Parameter Name="calType" Type="String" />
										<asp:Parameter Name="content" Type="String" />
										<asp:Parameter Name="Emp_idSource" Type="String" />
										<asp:Parameter Name="msgType" Type="String" />
									</InsertParameters>
								</asp:ObjectDataSource>
								<asp:ObjectDataSource ID="ObjectDataSource4" runat="server" DeleteMethod="Delete"
									InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByType1"
									TypeName="ezClientDSTableAdapters.CalendarTableAdapter" UpdateMethod="Update" OnDeleted="ObjectDataSource4_Deleted" OnUpdating="ObjectDataSource4_Updating">
									<DeleteParameters>
										<asp:Parameter Name="Original_auto" Type="Int32" />
									</DeleteParameters>
									<UpdateParameters>
										<asp:Parameter Name="Emp_id" Type="String" />
										<asp:Parameter Name="adate" Type="DateTime" />
										<asp:Parameter Name="timeB" Type="String" />
										<asp:Parameter Name="timeE" Type="String" />
										<asp:Parameter Name="calType" Type="String" />
										<asp:Parameter Name="content" Type="String" />
										<asp:Parameter Name="Emp_idSource" Type="String" />
										<asp:Parameter Name="msgType" Type="String" />
										<asp:Parameter Name="Original_auto" Type="Int32" />
										<asp:Parameter Name="auto" Type="Int32" />
									</UpdateParameters>
									<SelectParameters>
										<asp:SessionParameter Name="Emp_id" SessionField="Emp_id" Type="String" />
										<asp:SessionParameter Name="DateB" SessionField="baseDateB" Type="DateTime" />
										<asp:SessionParameter Name="DateE" SessionField="baseDateE" Type="DateTime" />
									</SelectParameters>
									<InsertParameters>
										<asp:Parameter Name="Emp_id" Type="String" />
										<asp:Parameter Name="adate" Type="DateTime" />
										<asp:Parameter Name="timeB" Type="String" />
										<asp:Parameter Name="timeE" Type="String" />
										<asp:Parameter Name="calType" Type="String" />
										<asp:Parameter Name="content" Type="String" />
										<asp:Parameter Name="Emp_idSource" Type="String" />
										<asp:Parameter Name="msgType" Type="String" />
									</InsertParameters>
								</asp:ObjectDataSource><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="auto"
									DataSourceID="ObjectDataSource5" OnRowDataBound="GridView2_RowDataBound" Width="100%" Caption="↙部門記事↗">
									<Columns>
										<asp:TemplateField ShowHeader="False">
											<EditItemTemplate>
												<asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
													Text="更新" />
												<asp:Button ID="Button2" runat="server" CausesValidation="False"
														CommandName="Cancel" Text="取消" />
												<asp:Label ID="Label20" runat="server" Text='<%# Bind("auto") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label21" runat="server" Text='<%# Bind("Dept_id") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label22" runat="server" Text='<%# Bind("adate") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label86" runat="server" Text='<%# Bind("calType", "{0}") %>' Visible="False"></asp:Label>
											</EditItemTemplate>
											<ItemStyle Width="1%" Wrap="False" />
											<ItemTemplate>
												<asp:Button ID="bnEdit" runat="server" CausesValidation="False" CommandName="Edit"
													Text="編輯" />
												<asp:Button ID="bnDel" runat="server" CausesValidation="False"
														CommandName="Delete" OnClientClick="return confirm('刪除確認')" Text="刪除" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="開始" SortExpression="timeB">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("timeB") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="Label1" runat="server" Text='<%# Bind("timeB") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="結束" SortExpression="timeE">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("timeE") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="Label2" runat="server" Text='<%# Bind("timeE") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="記事" SortExpression="content">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("content") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Left" />
											<HeaderStyle HorizontalAlign="Left" />
											<ItemTemplate>
												<asp:Label ID="lbContent" runat="server" Text='<%# Eval("content") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="資料來源" SortExpression="Emp_idSource">
											<EditItemTemplate>
												<asp:Label ID="Label63" runat="server" Text='<%# Bind("Emp_idSource") %>' Visible="False"></asp:Label>
												<asp:Label ID="lbEmpName" runat="server"></asp:Label>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="lbEmpName" runat="server"></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
								<asp:ObjectDataSource ID="ObjectDataSource5" runat="server" DeleteMethod="Delete"
									InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByType2"
									TypeName="ezClientDSTableAdapters.CalendarAllTableAdapter" UpdateMethod="Update" OnDeleted="ObjectDataSource5_Deleted" OnUpdating="ObjectDataSource5_Updating">
									<DeleteParameters>
										<asp:Parameter Name="Original_auto" Type="Int32" />
									</DeleteParameters>
									<UpdateParameters>
										<asp:Parameter Name="Dept_id" Type="String" />
										<asp:Parameter Name="adate" Type="DateTime" />
										<asp:Parameter Name="timeB" Type="String" />
										<asp:Parameter Name="timeE" Type="String" />
										<asp:Parameter Name="calType" Type="String" />
										<asp:Parameter Name="content" Type="String" />
										<asp:Parameter Name="Emp_idSource" Type="String" />
										<asp:Parameter Name="Original_auto" Type="Int32" />
										<asp:Parameter Name="auto" Type="Int32" />
									</UpdateParameters>
									<SelectParameters>
										<asp:SessionParameter Name="dateB" SessionField="baseDateB" Type="DateTime" />
										<asp:SessionParameter Name="dateE" SessionField="baseDateE" Type="DateTime" />
										<asp:SessionParameter Name="ids" SessionField="FullDeptTree" Type="String" />
									</SelectParameters>
									<InsertParameters>
										<asp:Parameter Name="Dept_id" Type="String" />
										<asp:Parameter Name="adate" Type="DateTime" />
										<asp:Parameter Name="timeB" Type="String" />
										<asp:Parameter Name="timeE" Type="String" />
										<asp:Parameter Name="calType" Type="String" />
										<asp:Parameter Name="content" Type="String" />
										<asp:Parameter Name="Emp_idSource" Type="String" />
									</InsertParameters>
								</asp:ObjectDataSource><asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="auto"
									DataSourceID="ObjectDataSource7" OnRowDataBound="GridView2_RowDataBound" Width="100%" Caption="↙公司記事↗">
									<Columns>
										<asp:TemplateField ShowHeader="False">
											<EditItemTemplate>
												<asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
													Text="更新" />
												<asp:Button ID="Button2" runat="server" CausesValidation="False"
														CommandName="Cancel" Text="取消" />
												<asp:Label ID="Label20" runat="server" Text='<%# Bind("auto") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label21" runat="server" Text='<%# Bind("Dept_id") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label22" runat="server" Text='<%# Bind("adate") %>' Visible="False"></asp:Label>
												<asp:Label ID="Label87" runat="server" Text='<%# Bind("calType", "{0}") %>' Visible="False"></asp:Label>
											</EditItemTemplate>
											<ItemStyle Width="1%" Wrap="False" />
											<ItemTemplate>
												<asp:Button ID="bnEdit" runat="server" CausesValidation="False" CommandName="Edit"
													Text="編輯" />
												<asp:Button ID="bnDel" runat="server" CausesValidation="False"
														CommandName="Delete" OnClientClick="return confirm('刪除確認')" Text="刪除" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="開始" SortExpression="timeB">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("timeB") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="Label1" runat="server" Text='<%# Bind("timeB") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="結束" SortExpression="timeE">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("timeE") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="Label2" runat="server" Text='<%# Bind("timeE") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="記事" SortExpression="content">
											<EditItemTemplate>
												<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("content") %>' Width="100%"></asp:TextBox>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Left" />
											<HeaderStyle HorizontalAlign="Left" />
											<ItemTemplate>
												<asp:Label ID="lbContent" runat="server" Text='<%# Eval("content") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="資料來源" SortExpression="Emp_idSource">
											<EditItemTemplate>
												<asp:Label ID="Label63" runat="server" Text='<%# Bind("Emp_idSource") %>' Visible="False"></asp:Label>
												<asp:Label ID="lbEmpName" runat="server"></asp:Label>
											</EditItemTemplate>
											<ItemStyle HorizontalAlign="Center" Wrap="False" />
											<HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											<ItemTemplate>
												<asp:Label ID="lbEmpName" runat="server"></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
								<asp:ObjectDataSource ID="ObjectDataSource7" runat="server" DeleteMethod="Delete"
									InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByType1"
									TypeName="ezClientDSTableAdapters.CalendarAllTableAdapter" UpdateMethod="Update">
									<DeleteParameters>
										<asp:Parameter Name="Original_auto" Type="Int32" />
									</DeleteParameters>
									<UpdateParameters>
										<asp:Parameter Name="Dept_id" Type="String" />
										<asp:Parameter Name="adate" Type="DateTime" />
										<asp:Parameter Name="timeB" Type="String" />
										<asp:Parameter Name="timeE" Type="String" />
										<asp:Parameter Name="calType" Type="String" />
										<asp:Parameter Name="content" Type="String" />
										<asp:Parameter Name="Emp_idSource" Type="String" />
										<asp:Parameter Name="Original_auto" Type="Int32" />
										<asp:Parameter Name="auto" Type="Int32" />
									</UpdateParameters>
									<SelectParameters>
										<asp:SessionParameter Name="DateB" SessionField="baseDateB" Type="DateTime" />
										<asp:SessionParameter Name="DateE" SessionField="baseDateE" Type="DateTime" />
									</SelectParameters>
									<InsertParameters>
										<asp:Parameter Name="Dept_id" Type="String" />
										<asp:Parameter Name="adate" Type="DateTime" />
										<asp:Parameter Name="timeB" Type="String" />
										<asp:Parameter Name="timeE" Type="String" />
										<asp:Parameter Name="calType" Type="String" />
										<asp:Parameter Name="content" Type="String" />
										<asp:Parameter Name="Emp_idSource" Type="String" />
									</InsertParameters>
								</asp:ObjectDataSource>
							</asp:View>
							<asp:View ID="View4" runat="server">
								<table border="0" cellpadding="0" cellspacing="5" width="100%" style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid">
									<tr>
										<td colspan="3" nowrap="nowrap" style="height: 1%" valign="bottom">
											<asp:Label ID="Label67" runat="server" Font-Bold="True" Font-Size="Smaller" Text="↙新增個人記事↗"></asp:Label></td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label1" runat="server" Font-Size="Smaller" Text="選取日期："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="lbSelectedDate" runat="server" Font-Size="Smaller"></asp:Label>
											<asp:Label ID="Label18" runat="server" Font-Size="Smaller" Text="(行事曆上的選取日期)"></asp:Label></td>
										<td style="width: 1%; height: 1%" valign="middle">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label99" runat="server" Font-Size="Smaller" Text="時間範圍："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:TextBox ID="txtTimeB" runat="server" Width="40px"></asp:TextBox>-<asp:TextBox
												ID="txtTimeE" runat="server" Width="40px"></asp:TextBox>
											<asp:Label ID="Label17" runat="server" Font-Size="Smaller" Text="(時間格式 0000 ex:0830)"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%;" valign="baseline" height="1%">
											<asp:Label ID="Label16" runat="server" Font-Size="Smaller" Text="隱藏內容："></asp:Label></td>
										<td valign="bottom" height="1%">
											<asp:RadioButtonList ID="rblstCalType" runat="server" Font-Size="Smaller" RepeatDirection="Horizontal" Height="1%">
												<asp:ListItem Value="1">是</asp:ListItem>
												<asp:ListItem Selected="True" Value="2">否</asp:ListItem>
											</asp:RadioButtonList></td>
										<td style="width: 1%;" valign="middle" height="1%">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
										</td>
										<td style="height: 1%" valign="bottom">
										</td>
										<td style="width: 1%; height: 1%" valign="middle">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label15" runat="server" Font-Size="Smaller" Text="記事內容："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:TextBox ID="txtContent" runat="server" Width="100%"></asp:TextBox></td>
										<td style="width: 1%; height: 1%">
											<asp:Button ID="bnAddCal" runat="server" OnClick="bnAddCal_Click" Text="新增" /></td>
									</tr>
									<tr>
										<td height="1%" nowrap="nowrap" style="width: 1%; border-top: #9999ff 3px double;" valign="baseline">
											<asp:Label ID="Label68" runat="server" Font-Size="Smaller" Text="通知方式："></asp:Label></td>
										<td height="1%" valign="bottom" style="border-top: #9999ff 3px double">
											<asp:RadioButtonList ID="rbnMsgType" runat="server" Font-Size="Smaller" RepeatDirection="Horizontal" Height="1%">
												<asp:ListItem Value="2" Selected="True">訊息</asp:ListItem>
												<asp:ListItem Value="1">約會</asp:ListItem>
											</asp:RadioButtonList></td>
										<td height="1%" style="width: 1%; border-top: #9999ff 3px double;">
											&nbsp;</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label36" runat="server" Font-Size="Smaller" Text="通知他人："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:TextBox ID="txtOtherEmp" runat="server" Width="100%"></asp:TextBox></td>
										<td style="width: 1%; height: 1%">
											</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
										</td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label42" runat="server" Font-Size="Smaller" Text="(可輸入工號、中英文姓名或電子郵件，多人以逗號隔開。)"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label66" runat="server" Font-Size="Smaller" Text="通知部門："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:CheckBox ID="ckMsgDept" runat="server" Font-Bold="False" Font-Size="Smaller"
												Text="所屬的部門包含上層部門及子部門皆會收到通知。" /></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label79" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="註一："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label62" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="若選取日期小於今天，那您的記事是無法儲存的。"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label80" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="註二："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label81" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="如果事情同時需要他人的參予，則通知方式選擇約會。"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
										</td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label82" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="如果事情只是單純的告知他人，則通知方式選擇訊息。"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
								</table>
							</asp:View>
							<asp:View ID="View9" runat="server">
								<table border="0" cellpadding="0" cellspacing="5" width="100%" style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid">
									<tr>
										<td colspan="3" nowrap="nowrap" style="height: 1%" valign="bottom">
											<asp:Label ID="Label61" runat="server" Font-Bold="True" Font-Size="Smaller" Text="↙發佈部門記事↗"></asp:Label></td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label30" runat="server" Font-Size="Smaller" Text="選取日期："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="lbSelectedDate1" runat="server" Font-Size="Smaller"></asp:Label>
											<asp:Label ID="Label38" runat="server" Font-Size="Smaller" Text="(行事曆上的選取日期)"></asp:Label></td>
										<td style="width: 1%; height: 1%" valign="middle">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label32" runat="server" Font-Size="Smaller" Text="張貼部門："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:DropDownList ID="cbDept" runat="server">
											</asp:DropDownList></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label39" runat="server" Font-Size="Smaller" Text="時間範圍："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:TextBox ID="txtTimeB1" runat="server" Width="40px"></asp:TextBox>-<asp:TextBox
												ID="txtTimeE1" runat="server" Width="40px"></asp:TextBox>
											<asp:Label ID="Label40" runat="server" Font-Size="Smaller" Text="(時間格式 0000 ex:0830)"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label41" runat="server" Font-Size="Smaller" Text="記事內容："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:TextBox ID="txtContent1" runat="server" Width="100%"></asp:TextBox></td>
										<td style="width: 1%; height: 1%">
											<asp:Button ID="bnAddCal1" runat="server" OnClick="bnAddCal1_Click" Text="新增" /></td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label59" runat="server" Font-Size="Smaller" Text="發佈他人："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:TextBox ID="txtOther" runat="server" Width="100%"></asp:TextBox></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
										</td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label60" runat="server" Font-Size="Smaller" Text="(可輸入工號、中英文姓名或電子郵件，多人以逗號隔開。)"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label70" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="註一："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label71" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="若選取日期小於今天，那您的記事是無法儲存的。"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label72" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="註二："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label73" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="主管的個人記事，請勿以發佈部門的方式來公怖。"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label78" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="註三："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label77" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="建議您以　【類別】記事內容　的格式撰寫記事內容。"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
								</table>
							</asp:View>
							<asp:View ID="View8" runat="server">
								<table border="0" cellpadding="0" cellspacing="5" width="100%" style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid">
									<tr>
										<td colspan="3" nowrap="nowrap" style="height: 1%" valign="bottom">
											<asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="Smaller" Text="↙發佈公司記事↗"></asp:Label></td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label31" runat="server" Font-Size="Smaller" Text="選取日期："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="lbSelectedDate2" runat="server" Font-Size="Smaller"></asp:Label>
											<asp:Label ID="Label33" runat="server" Font-Size="Smaller" Text="(行事曆上的選取日期)"></asp:Label></td>
										<td style="width: 1%; height: 1%" valign="middle">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label34" runat="server" Font-Size="Smaller" Text="時間範圍："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:TextBox ID="txtTimeB2" runat="server" Width="40px"></asp:TextBox>-<asp:TextBox
												ID="txtTimeE2" runat="server" Width="40px"></asp:TextBox>
											<asp:Label ID="Label35" runat="server" Font-Size="Smaller" Text="(時間格式 0000 ex:0830)"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label37" runat="server" Font-Size="Smaller" Text="記事內容："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:TextBox ID="txtContent2" runat="server" Width="100%"></asp:TextBox></td>
										<td style="width: 1%; height: 1%">
											<asp:Button ID="bnAddCal2" runat="server" OnClick="bnAddCal2_Click" Text="新增" /></td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label64" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="註一："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label69" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="若選取日期小於今天，那您的記事是無法儲存的。"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label74" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="註二："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label75" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="關於個人或某些人的記事，請勿在這裡做此公怖。"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label65" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="註三："></asp:Label></td>
										<td style="height: 1%" valign="bottom">
											<asp:Label ID="Label76" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="建議您以　【類別】記事內容　的格式撰寫記事內容。"></asp:Label></td>
										<td style="width: 1%; height: 1%">
										</td>
									</tr>
								</table>
							</asp:View>
						</asp:MultiView></asp:View>
					<asp:View ID="View5" runat="server">
						<asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" Font-Size="Smaller"
							OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" RepeatDirection="Horizontal">
							<asp:ListItem Selected="True" Value="0">自訂查詢報表</asp:ListItem>
							<asp:ListItem Value="1">全部員工報表</asp:ListItem>
							<asp:ListItem Value="2">部門記事報表</asp:ListItem>
							<asp:ListItem Value="3">公司記事報表</asp:ListItem>
						</asp:RadioButtonList>
						<asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
							<asp:View ID="View6" runat="server">
								<table border="0" cellpadding="0" cellspacing="5" width="100%" style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid" bgcolor="#ffffcc">
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label23" runat="server" Font-Size="Smaller" Text="員工代碼："></asp:Label></td>
										<td nowrap="nowrap" style="height: 1%" valign="bottom">
											<asp:TextBox ID="txtEmpID" runat="server" Width="100%"></asp:TextBox></td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label26" runat="server" Font-Size="Smaller" Text="查詢年度："></asp:Label></td>
										<td nowrap="nowrap" style="height: 1%" valign="bottom">
											<asp:DropDownList ID="cbQueryYear1" runat="server">
											</asp:DropDownList>&nbsp;</td>
									</tr>
									<tr>
										<td nowrap="nowrap" style="width: 1%; height: 1%" valign="bottom">
											<asp:Label ID="Label28" runat="server" Font-Size="Smaller" Text="查詢月份："></asp:Label></td>
										<td nowrap="nowrap" style="height: 1%" valign="bottom">
											<asp:DropDownList ID="cbQueryMonth1" runat="server">
												<asp:ListItem Value="1">一月</asp:ListItem>
												<asp:ListItem Value="2">二月</asp:ListItem>
												<asp:ListItem Value="3">三月</asp:ListItem>
												<asp:ListItem Value="4">四月</asp:ListItem>
												<asp:ListItem Value="5">五月</asp:ListItem>
												<asp:ListItem Value="6">六月</asp:ListItem>
												<asp:ListItem Value="7">七月</asp:ListItem>
												<asp:ListItem Value="8">八月</asp:ListItem>
												<asp:ListItem Value="9">九月</asp:ListItem>
												<asp:ListItem Value="10">十月</asp:ListItem>
												<asp:ListItem Value="11">十一月</asp:ListItem>
												<asp:ListItem Value="12">十二月</asp:ListItem>
											</asp:DropDownList>
											<asp:Button ID="bnReport1" runat="server" Text="報表" OnClick="bnReport1_Click" /></td>
									</tr>
									<tr>
										<td colspan="2" style="height: 1%" valign="bottom">
											<asp:Label ID="Label24" runat="server" Font-Size="Smaller" ForeColor="Blue" Text="PS：員工代碼可輸入工號、中英文姓名或電子郵件，多人以逗號隔開。"></asp:Label></td>
									</tr>
								</table>
							</asp:View>
							<asp:View ID="View7" runat="server">
								<table border="0" cellpadding="0" cellspacing="3" width="100%" style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid" bgcolor="#ffffcc">
									<tr>
										<td colspan="2" valign="top">
											<asp:RadioButtonList ID="rblstReportStyle" runat="server" Font-Size="Smaller"
												Width="280px">
												<asp:ListItem Selected="True" Value="1">主群組為部門；次群組為工號；排序依日期</asp:ListItem>
												<asp:ListItem Value="2">主群組為日期；次群組為部門；排序依工號</asp:ListItem>
											</asp:RadioButtonList></td>
									</tr>
									<tr>
										<td align="right" nowrap="nowrap" style="padding-left: 22px; width: 1%" valign="bottom">
											<asp:Label ID="Label25" runat="server" Font-Size="Smaller" Text="查詢年度："></asp:Label></td>
										<td valign="bottom">
											<asp:DropDownList ID="cbQueryYear2" runat="server">
											</asp:DropDownList></td>
									</tr>
									<tr>
										<td style="width: 1%; padding-left: 22px;" align="right" valign="bottom" nowrap="noWrap">
											<asp:Label ID="Label27" runat="server" Font-Size="Smaller" Text="查詢月份："></asp:Label></td>
										<td valign="bottom">
											<asp:DropDownList ID="cbQueryMonth2" runat="server">
												<asp:ListItem Value="1">一月</asp:ListItem>
												<asp:ListItem Value="2">二月</asp:ListItem>
												<asp:ListItem Value="3">三月</asp:ListItem>
												<asp:ListItem Value="4">四月</asp:ListItem>
												<asp:ListItem Value="5">五月</asp:ListItem>
												<asp:ListItem Value="6">六月</asp:ListItem>
												<asp:ListItem Value="7">七月</asp:ListItem>
												<asp:ListItem Value="8">八月</asp:ListItem>
												<asp:ListItem Value="9">九月</asp:ListItem>
												<asp:ListItem Value="10">十月</asp:ListItem>
												<asp:ListItem Value="11">十一月</asp:ListItem>
												<asp:ListItem Value="12">十二月</asp:ListItem>
											</asp:DropDownList>
											<asp:Button ID="bnReport2" runat="server" Text="報表" OnClick="bnReport2_Click" /></td>
									</tr>
								</table>
							</asp:View>
							<asp:View ID="View10" runat="server">
								<table border="0" cellpadding="0" cellspacing="3" width="100%" style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid" bgcolor="#ffffcc">
									<tr>
										<td align="right" nowrap="nowrap" style="padding-left: 22px; width: 1%" valign="bottom">
											<asp:Label ID="Label43" runat="server" Font-Size="Smaller" Text="查詢年度："></asp:Label></td>
										<td valign="bottom">
											<asp:DropDownList ID="cbQueryYear3" runat="server">
											</asp:DropDownList></td>
									</tr>
									<tr>
										<td style="width: 1%; padding-left: 22px;" align="right" valign="bottom" nowrap="noWrap">
											<asp:Label ID="Label44" runat="server" Font-Size="Smaller" Text="查詢月份："></asp:Label></td>
										<td valign="bottom">
											<asp:DropDownList ID="cbQueryMonth3" runat="server">
												<asp:ListItem Value="1">一月</asp:ListItem>
												<asp:ListItem Value="2">二月</asp:ListItem>
												<asp:ListItem Value="3">三月</asp:ListItem>
												<asp:ListItem Value="4">四月</asp:ListItem>
												<asp:ListItem Value="5">五月</asp:ListItem>
												<asp:ListItem Value="6">六月</asp:ListItem>
												<asp:ListItem Value="7">七月</asp:ListItem>
												<asp:ListItem Value="8">八月</asp:ListItem>
												<asp:ListItem Value="9">九月</asp:ListItem>
												<asp:ListItem Value="10">十月</asp:ListItem>
												<asp:ListItem Value="11">十一月</asp:ListItem>
												<asp:ListItem Value="12">十二月</asp:ListItem>
											</asp:DropDownList>
											<asp:Button ID="bnReport3" runat="server" Text="報表" OnClick="bnReport3_Click" /></td>
									</tr>
								</table>
							</asp:View>
							<asp:View ID="View11" runat="server">
								<table border="0" cellpadding="0" cellspacing="3" width="100%" style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid" bgcolor="#ffffcc">
									<tr>
										<td align="right" nowrap="nowrap" style="padding-left: 22px; width: 1%" valign="bottom">
											<asp:Label ID="Label45" runat="server" Font-Size="Smaller" Text="查詢年度："></asp:Label></td>
										<td valign="bottom">
											<asp:DropDownList ID="cbQueryYear4" runat="server">
											</asp:DropDownList></td>
									</tr>
									<tr>
										<td style="width: 1%; padding-left: 22px;" align="right" valign="bottom" nowrap="noWrap">
											<asp:Label ID="Label46" runat="server" Font-Size="Smaller" Text="查詢月份："></asp:Label></td>
										<td valign="bottom">
											<asp:DropDownList ID="cbQueryMonth4" runat="server">
												<asp:ListItem Value="1">一月</asp:ListItem>
												<asp:ListItem Value="2">二月</asp:ListItem>
												<asp:ListItem Value="3">三月</asp:ListItem>
												<asp:ListItem Value="4">四月</asp:ListItem>
												<asp:ListItem Value="5">五月</asp:ListItem>
												<asp:ListItem Value="6">六月</asp:ListItem>
												<asp:ListItem Value="7">七月</asp:ListItem>
												<asp:ListItem Value="8">八月</asp:ListItem>
												<asp:ListItem Value="9">九月</asp:ListItem>
												<asp:ListItem Value="10">十月</asp:ListItem>
												<asp:ListItem Value="11">十一月</asp:ListItem>
												<asp:ListItem Value="12">十二月</asp:ListItem>
											</asp:DropDownList>
											<asp:Button ID="bnReport4" runat="server" Text="報表" OnClick="bnReport4_Click" /></td>
									</tr>
								</table>
							</asp:View>
						</asp:MultiView></asp:View>
				</asp:MultiView></td>
		</tr>
	</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
	<asp:DataList ID="DataList2" runat="server" DataKeyField="auto" DataSourceID="SqlDataSource1">
		<ItemTemplate>
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td nowrap="nowrap" width="1%">
			<asp:Label ID="Label90" runat="server" Font-Bold="True" Text="設備名稱:" Font-Size="Smaller" ForeColor="Navy"></asp:Label></td>
					<td>
			<asp:Label ID="DeviceNameLabel" runat="server" Font-Bold="True" Text='<%# Eval("DeviceName") %>' Font-Size="Smaller" ForeColor="Navy"></asp:Label></td>
				</tr>
				<tr>
					<td nowrap="nowrap" width="1%">
						<asp:Label ID="Label7" runat="server" Font-Size="Smaller" ForeColor="Navy" Text="預約人員:"></asp:Label></td>
					<td>
						<asp:Label ID="Label8" runat="server" Font-Size="Smaller" ForeColor="Navy" Text='<%# Eval("Emp_name", "{0}") %>'></asp:Label></td>
				</tr>
				<tr>
					<td nowrap="nowrap" width="1%">
						<asp:Label ID="Label88" runat="server" Font-Size="Smaller" ForeColor="Navy" Text="開始使用:"></asp:Label></td>
					<td>
			<asp:Label ID="dateBLabel" runat="server" Text='<%# Eval("dateB", "{0:yyyy-MM-dd HH:mm}") %>' Font-Size="Smaller" ForeColor="Navy"></asp:Label></td>
				</tr>
				<tr>
					<td nowrap="nowrap" width="1%">
			<asp:Label ID="Label89" runat="server" Text="結束使用:" Font-Size="Smaller" ForeColor="Navy"></asp:Label></td>
					<td>
			<asp:Label ID="dateELabel" runat="server" Text='<%# Eval("dateE", "{0:yyyy-MM-dd HH:mm}") %>' Font-Size="Smaller" ForeColor="Navy"></asp:Label></td>
				</tr>
			</table>
		</ItemTemplate>
		<SeparatorTemplate>
			<hr />
		</SeparatorTemplate>
	</asp:DataList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
		SelectCommand="SELECT DeviceUse.dateB, DeviceUse.dateE, DeviceItems.name AS DeviceName, DeviceUse.auto, DeviceUse.Emp_name, DeviceUse.note FROM DeviceUse INNER JOIN DeviceItems ON DeviceUse.DeviceItems_auto = DeviceItems.auto WHERE (DATEDIFF(day, DeviceUse.dateB, @date) = 0) AND (DeviceUse.isOK = 1) AND (DeviceItems.isPublic = 1) OR (DATEDIFF(day, DeviceUse.dateB, @date) > 0) AND (DeviceUse.isOK = 1) AND (DeviceItems.isPublic = 1) AND (DATEDIFF(day, @date, DeviceUse.dateE) >= 0)">
		<SelectParameters>
			<asp:SessionParameter Name="date" SessionField="baseDate" />
		</SelectParameters>
	</asp:SqlDataSource>
	<asp:Panel ID="pnlEmpty" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Navy"
		HorizontalAlign="Center" Visible="False" Width="100%">
		<br />
		<br />
		公務車與會議室閒置中…<br />
		<br />
	</asp:Panel>
</asp:Content>

