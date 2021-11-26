<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WorkAgent.aspx.cs" Inherits="Flow_WorkAgent" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table bgcolor="whitesmoke" border="0" cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td>
				&nbsp;</td>
		</tr>
		<tr>
			<td style="height: 54px">
				<asp:Label ID="Label4" runat="server" Font-Size="Smaller" Text="我的角色"></asp:Label>
				<asp:DropDownList ID="cbMyRole" runat="server" AutoPostBack="True">
				</asp:DropDownList>
				<asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Smaller" Text="(若您有多重身份，請為每個身份設定好代理人)"></asp:Label>
                <asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label><br />
				<asp:Label ID="Label1" runat="server" Font-Size="Smaller" Text="成員姓名"></asp:Label>
				<asp:TextBox ID="txtAgentEmp" runat="server" OnTextChanged="txtAgentEmp_TextChanged" Width="207px"></asp:TextBox>
				<asp:Button ID="Button1" runat="server" Text="查找" />
				<asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Smaller" Text="(可輸入工號、中英文姓名或電子郵件。)"></asp:Label><br />
				<asp:Label ID="Label5" runat="server" Font-Size="Smaller" Text="成員角色"></asp:Label>
				<asp:DropDownList ID="cbAgentRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbAgentRole_SelectedIndexChanged">
				</asp:DropDownList>
				<asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Smaller" Text="(若該人有多重身份，請選擇該人可代理您的適當身份)"></asp:Label><br />
				<asp:Label ID="Label2" runat="server" Font-Size="Smaller" Text="部門名稱"></asp:Label>
				<asp:TextBox ID="txtAgentDept" runat="server" ReadOnly="True" BackColor="#E0E0E0"></asp:TextBox>
				<asp:Label ID="Label3" runat="server" Font-Size="Smaller" Text="職務名稱"></asp:Label>
				<asp:TextBox ID="txtAgentPos" runat="server" ReadOnly="True" BackColor="#E0E0E0"></asp:TextBox>
				<asp:Button ID="bnAddAgent" runat="server" Text="加入新代理人" OnClick="bnAddAgent_Click" UseSubmitBehavior="False" /></td>
		</tr>
		<tr>
			<td>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top" style="height: 19px" width="50%">
						</td>
						<td valign="top" style="height: 19px" align="center" width="50%">
							&nbsp;</td>
					</tr>
					<tr>
						<td bgcolor="lavender" style="border-top: #000000 3px double; border-bottom: #000000 1px solid"
							valign="top" width="50%" align="right">
							&nbsp;</td>
						<td bgcolor="lavender" style="border-top: #000000 3px double; border-bottom: #000000 1px solid"
							valign="top" align="right" width="50%">
							<asp:DropDownList ID="cbFlow" runat="server" DataSourceID="ObjectDataSource3"
								DataTextField="name" DataValueField="id">
							</asp:DropDownList><asp:Button ID="bnAddFlow" runat="server" Text="加入" OnClick="bnAddFlow_Click" /></td>
					</tr>
					<tr>
						<td valign="top" width="50%">
							<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="auto" DataSourceID="ObjectDataSource1" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" Width="100%">
								<RowStyle Wrap="False" />
								<HeaderStyle Wrap="False" />
								<Columns>
									<asp:TemplateField ShowHeader="False">
										<ItemTemplate>
											<asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select"
												Text="選取" /><asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete"
													OnClientClick="return confirm('確除確認')" Text="刪除" />
										</ItemTemplate>
										<ItemStyle Wrap="False" />
										<HeaderStyle Width="1%" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="部門">
										<ItemStyle HorizontalAlign="Center" Wrap="False" />
										<HeaderStyle HorizontalAlign="Center" Wrap="False" />
										<ItemTemplate>
											<asp:Label ID="lbDept" runat="server"></asp:Label>
											<asp:Label ID="Label9" runat="server" Text='<%# Eval("auto") %>' Visible="False"></asp:Label>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="職稱">
										<ItemStyle HorizontalAlign="Center" Wrap="False" />
										<HeaderStyle HorizontalAlign="Center" Wrap="False" />
										<ItemTemplate>
											<asp:Label ID="lbPos" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="姓名" SortExpression="Emp_idTarget">
										<EditItemTemplate>
											<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Emp_idTarget") %>'></asp:TextBox>
										</EditItemTemplate>
										<ItemStyle HorizontalAlign="Center" Wrap="False" />
										<HeaderStyle HorizontalAlign="Center" Wrap="False" />
										<ItemTemplate>
											<asp:Label ID="lbEmp" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
								<EmptyDataRowStyle HorizontalAlign="Center" BackColor="#FFE0C0" />
								<EmptyDataTemplate>
									&nbsp;<br />
									尚未指定代理人
									<br />
									&nbsp;
								</EmptyDataTemplate>
							</asp:GridView>
							<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
								InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByIdSource"
								TypeName="ezClientDSTableAdapters.WorkAgentTableAdapter" UpdateMethod="Update" OnDeleted="ObjectDataSource1_Deleted">
								<DeleteParameters>
									<asp:Parameter Name="Original_auto" Type="Int32" />
								</DeleteParameters>
								<UpdateParameters>
									<asp:Parameter Name="Role_idSource" Type="String" />
									<asp:Parameter Name="Emp_idSource" Type="String" />
									<asp:Parameter Name="Role_idTarget" Type="String" />
									<asp:Parameter Name="Emp_idTarget" Type="String" />
									<asp:Parameter Name="Original_auto" Type="Int32" />
								</UpdateParameters>
								<SelectParameters>
									<asp:ControlParameter ControlID="cbMyRole" ConvertEmptyStringToNull="False" Name="Role_idSource"
										PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="lb_nobr" Name="Emp_idSource" PropertyName="Text"
                                        Type="String" />
								</SelectParameters>
								<InsertParameters>
									<asp:Parameter Name="Role_idSource" Type="String" />
									<asp:Parameter Name="Emp_idSource" Type="String" />
									<asp:Parameter Name="Role_idTarget" Type="String" />
									<asp:Parameter Name="Emp_idTarget" Type="String" />
								</InsertParameters>
							</asp:ObjectDataSource>
							&nbsp;
						</td>
						<td valign="top" align="center" width="50%">
							<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DeleteMethod="Delete"
								InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByPower"
								TypeName="ezClientDSTableAdapters.FlowTreeTableAdapter" UpdateMethod="Update">
								<DeleteParameters>
									<asp:Parameter Name="Original_id" Type="String" />
								</DeleteParameters>
								<UpdateParameters>
									<asp:Parameter Name="id" Type="String" />
									<asp:Parameter Name="FlowGroup_id" Type="String" />
									<asp:Parameter Name="name" Type="String" />
									<asp:Parameter Name="dateB" Type="DateTime" />
									<asp:Parameter Name="dateE" Type="DateTime" />
									<asp:Parameter Name="isVisible" Type="Boolean" />
									<asp:Parameter Name="Original_id" Type="String" />
								</UpdateParameters>
								<SelectParameters>
									<asp:SessionParameter ConvertEmptyStringToNull="False" Name="Path" SessionField="Path"
										Type="String" />
									<asp:SessionParameter ConvertEmptyStringToNull="False" Name="Role_ID" SessionField="Role_ID"
										Type="String" />
								</SelectParameters>
								<InsertParameters>
									<asp:Parameter Name="id" Type="String" />
									<asp:Parameter Name="FlowGroup_id" Type="String" />
									<asp:Parameter Name="name" Type="String" />
									<asp:Parameter Name="dateB" Type="DateTime" />
									<asp:Parameter Name="dateE" Type="DateTime" />
									<asp:Parameter Name="isVisible" Type="Boolean" />
								</InsertParameters>
							</asp:ObjectDataSource>
							<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="auto" DataSourceID="ObjectDataSource2" OnRowDataBound="GridView2_RowDataBound" Width="100%">
								<RowStyle Wrap="False" />
								<HeaderStyle Wrap="False" />
								<Columns>
									<asp:TemplateField ShowHeader="False">
										<HeaderStyle Width="1%" />
										<ItemTemplate>
											<asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete"
												OnClientClick="return confirm('刪除確認')" Text="刪除" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="可代理的流程名稱" SortExpression="FlowTree_id">
										<EditItemTemplate>
											<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FlowTree_id") %>'></asp:TextBox>
										</EditItemTemplate>
										<ItemStyle HorizontalAlign="Center" />
										<ItemTemplate>
											<asp:Label ID="lbFlow" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
								<EmptyDataRowStyle HorizontalAlign="Center" BackColor="#FFE0C0" />
								<EmptyDataTemplate>
									&nbsp;<br />
									代理人目前可代理所有工作
									<br />
									&nbsp;
								</EmptyDataTemplate>
							</asp:GridView>
							<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete"
								InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByWorkAgent"
								TypeName="ezClientDSTableAdapters.WorkAgentPowerTableAdapter" UpdateMethod="Update">
								<DeleteParameters>
									<asp:Parameter Name="Original_auto" Type="Int32" />
								</DeleteParameters>
								<UpdateParameters>
									<asp:Parameter Name="WorkAgent_auto" Type="Int32" />
									<asp:Parameter Name="FlowTree_id" Type="String" />
									<asp:Parameter Name="Original_auto" Type="Int32" />
								</UpdateParameters>
								<SelectParameters>
									<asp:ControlParameter ControlID="GridView1" ConvertEmptyStringToNull="False" DefaultValue="0"
										Name="WorkAgent_auto" PropertyName="SelectedValue" Type="Int32" />
								</SelectParameters>
								<InsertParameters>
									<asp:Parameter Name="WorkAgent_auto" Type="Int32" />
									<asp:Parameter Name="FlowTree_id" Type="String" />
								</InsertParameters>
							</asp:ObjectDataSource>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>

