<%@ Page Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="PostMain.aspx.cs" Inherits="PostMain" Title="ezClient v1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td height="1%" align="left">				
				<table border="0" cellpadding="0" cellspacing="0" style="border-right: #9999ff 3px double; border-top: #9999ff 3px double; border-left: #9999ff 3px double; width: 520px; border-bottom: #9999ff 3px double">
					<tr>
						<td align="right" style="height: 1%; padding-left: 10px;" valign="middle" width="30%" bgcolor="#006699">
							<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox><asp:Button ID="Button2"
								runat="server" Text="搜尋" /></td>
						<td style="height: 1%; width: 295px;" valign="middle" bgcolor="#006699" nowrap="noWrap">
							<asp:RadioButtonList ID="rbnSearchType" runat="server" Font-Size="Smaller" RepeatDirection="Horizontal" ForeColor="White">
								<asp:ListItem Selected="True" Value="1">僅搜尋標題</asp:ListItem>
								<asp:ListItem Value="2">搜尋標題和內文</asp:ListItem>
								<asp:ListItem Value="3">僅搜尋作者</asp:ListItem>
							</asp:RadioButtonList></td>
					</tr>
				</table>
			</td>
			<td align="right" height="1%">
				<asp:Button ID="bnNewPost" runat="server" Text="發表文章" OnClick="bnNewPost_Click" /></td>
		</tr>
		<tr>
			<td colspan="2">
	<asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="False" DataKeyNames="auto"
		DataSourceID="ObjectDataSource1" Width="100%" OnRowDataBound="grdMain_RowDataBound">
		<Columns>
			<asp:TemplateField>
				<EditItemTemplate>
					<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
				</EditItemTemplate>
				<HeaderStyle Width="1%" />
				<ItemTemplate>
					<asp:Image ID="imgFlag" runat="server" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<EditItemTemplate>
					<asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("moodType") %>'></asp:TextBox>
				</EditItemTemplate>
				<HeaderStyle Width="1%" />
				<ItemTemplate>
					<asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("moodType", "images/M{0}.gif") %>' />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="主題" SortExpression="subject">
				<EditItemTemplate>
					<asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("subject") %>'></asp:TextBox>
				</EditItemTemplate>
				<HeaderStyle Width="60%" />
				<ItemTemplate>
					<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("auto", "PostDetail.aspx?PostMain_auto={0}") %>'
						Text='<%# Eval("subject") %>'></asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="作者" SortExpression="Emp_id">
				<EditItemTemplate>
					<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Emp_id") %>'></asp:TextBox>
				</EditItemTemplate>
				<HeaderStyle Width="15%" />
				<ItemTemplate>
					<asp:Label ID="lbAuthor" runat="server"></asp:Label>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="回覆">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate>
					<asp:Label ID="lbCount" runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="最後發表時間">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate>
					<asp:Label ID="lbReply" runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
		<EmptyDataTemplate>
			&nbsp;<br />
			此討論區目前沒有任何的主題。
			<br />
			&nbsp;
		</EmptyDataTemplate>
	</asp:GridView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
		InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBySearch1"
		TypeName="ezClientDSTableAdapters.PostMainTableAdapter" UpdateMethod="Update">
		<DeleteParameters>
			<asp:Parameter Name="Original_auto" Type="Int32" />
		</DeleteParameters>
		<UpdateParameters>
			<asp:Parameter Name="BoardList_auto" Type="Int32" />
			<asp:Parameter Name="subject" Type="String" />
			<asp:Parameter Name="Emp_id" Type="String" />
			<asp:Parameter Name="adate" Type="DateTime" />
			<asp:Parameter Name="isTop" Type="Boolean" />
			<asp:Parameter Name="moodType" Type="Int32" />
			<asp:Parameter Name="Original_auto" Type="Int32" />
			<asp:Parameter Name="auto" Type="Int32" />
		</UpdateParameters>
		<InsertParameters>
			<asp:Parameter Name="BoardList_auto" Type="Int32" />
			<asp:Parameter Name="subject" Type="String" />
			<asp:Parameter Name="Emp_id" Type="String" />
			<asp:Parameter Name="adate" Type="DateTime" />
			<asp:Parameter Name="isTop" Type="Boolean" />
			<asp:Parameter Name="moodType" Type="Int32" />
		</InsertParameters><SelectParameters>
			<asp:QueryStringParameter Name="BoardList_auto" QueryStringField="BoardList_auto"
				Type="Int32" ConvertEmptyStringToNull="False" DefaultValue="0" />
			<asp:ControlParameter ControlID="txtKeyword" ConvertEmptyStringToNull="False" Name="keyword"
				PropertyName="Text" Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>
				<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete"
		InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBySearch2"
		TypeName="ezClientDSTableAdapters.PostMainTableAdapter" UpdateMethod="Update">
					<DeleteParameters>
						<asp:Parameter Name="Original_auto" Type="Int32" />
					</DeleteParameters>
					<UpdateParameters>
						<asp:Parameter Name="BoardList_auto" Type="Int32" />
						<asp:Parameter Name="subject" Type="String" />
						<asp:Parameter Name="Emp_id" Type="String" />
						<asp:Parameter Name="adate" Type="DateTime" />
						<asp:Parameter Name="isTop" Type="Boolean" />
						<asp:Parameter Name="moodType" Type="Int32" />
						<asp:Parameter Name="Original_auto" Type="Int32" />
						<asp:Parameter Name="auto" Type="Int32" />
					</UpdateParameters>
					<SelectParameters>
						<asp:QueryStringParameter Name="BoardList_auto" QueryStringField="BoardList_auto"
				Type="Int32" ConvertEmptyStringToNull="False" DefaultValue="0" />
						<asp:ControlParameter ControlID="txtKeyword" ConvertEmptyStringToNull="False" Name="keyword"
							PropertyName="Text" Type="String" />
					</SelectParameters>
					<InsertParameters>
						<asp:Parameter Name="BoardList_auto" Type="Int32" />
						<asp:Parameter Name="subject" Type="String" />
						<asp:Parameter Name="Emp_id" Type="String" />
						<asp:Parameter Name="adate" Type="DateTime" />
						<asp:Parameter Name="isTop" Type="Boolean" />
						<asp:Parameter Name="moodType" Type="Int32" />
					</InsertParameters>
				</asp:ObjectDataSource>
				<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DeleteMethod="Delete"
		InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBySearch3"
		TypeName="ezClientDSTableAdapters.PostMainTableAdapter" UpdateMethod="Update">
					<DeleteParameters>
						<asp:Parameter Name="Original_auto" Type="Int32" />
					</DeleteParameters>
					<UpdateParameters>
						<asp:Parameter Name="BoardList_auto" Type="Int32" />
						<asp:Parameter Name="subject" Type="String" />
						<asp:Parameter Name="Emp_id" Type="String" />
						<asp:Parameter Name="adate" Type="DateTime" />
						<asp:Parameter Name="isTop" Type="Boolean" />
						<asp:Parameter Name="moodType" Type="Int32" />
						<asp:Parameter Name="Original_auto" Type="Int32" />
						<asp:Parameter Name="auto" Type="Int32" />
					</UpdateParameters>
					<SelectParameters>
						<asp:QueryStringParameter Name="BoardList_auto" QueryStringField="BoardList_auto"
				Type="Int32" ConvertEmptyStringToNull="False" DefaultValue="0" />
						<asp:ControlParameter ControlID="txtKeyword" ConvertEmptyStringToNull="False" Name="keyword"
							PropertyName="Text" Type="String" />
					</SelectParameters>
					<InsertParameters>
						<asp:Parameter Name="BoardList_auto" Type="Int32" />
						<asp:Parameter Name="subject" Type="String" />
						<asp:Parameter Name="Emp_id" Type="String" />
						<asp:Parameter Name="adate" Type="DateTime" />
						<asp:Parameter Name="isTop" Type="Boolean" />
						<asp:Parameter Name="moodType" Type="Int32" />
					</InsertParameters>
	</asp:ObjectDataSource>
			</td>
		</tr>
		<tr>
			<td>
			</td>
			<td>
			</td>
		</tr>
	</table>
</asp:Content>

