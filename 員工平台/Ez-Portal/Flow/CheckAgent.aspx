<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CheckAgent.aspx.cs" Inherits="Flow_CheckAgent" Title="代理人設定" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table bgcolor="whitesmoke" border="0" cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td>
				&nbsp;</td>
		</tr>
		<tr>
			<td>
				<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Font-Size="Smaller"
					OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
					<asp:ListItem Selected="True" Value="0">順位簽核代理人</asp:ListItem>
					<asp:ListItem Value="1">常態簽核代理人</asp:ListItem>
				</asp:RadioButtonList><asp:Label ID="Label4" runat="server" Font-Size="Smaller" Text="我的角色"></asp:Label>
				<asp:DropDownList ID="cbMyRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbMyRole_SelectedIndexChanged">
				</asp:DropDownList>
				<asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Smaller" Text="(若您有多重身份，請為每個身份設定好代理人)"></asp:Label>
				<br />
				<hr />
				<asp:Label ID="Label1" runat="server" Font-Size="Smaller" Text="成員姓名"></asp:Label>
				<asp:TextBox ID="txtAgentEmp" runat="server" OnTextChanged="txtAgentEmp_TextChanged"
					Width="207px"></asp:TextBox>
				<asp:Button ID="Button1" runat="server" Text="查找" />
				<asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Smaller" Text="(可輸入工號、中英文姓名或電子郵件。)"></asp:Label><br />
				<asp:Label ID="Label5" runat="server" Font-Size="Smaller" Text="成員角色"></asp:Label>
				<asp:DropDownList ID="cbAgentRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbAgentRole_SelectedIndexChanged">
				</asp:DropDownList>
				<asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Smaller" Text="(若該人有多重身份，請選擇該人可代理您的適當身份)"></asp:Label><br />
				<asp:Label ID="Label2" runat="server" Font-Size="Smaller" Text="部門名稱"></asp:Label>
				<asp:TextBox ID="txtAgentDept" runat="server" BackColor="#E0E0E0" ReadOnly="True"></asp:TextBox>
				<asp:Label ID="Label3" runat="server" Font-Size="Smaller" Text="職務名稱"></asp:Label>
				<asp:TextBox ID="txtAgentPos" runat="server" BackColor="#E0E0E0" ReadOnly="True"></asp:TextBox>
				<asp:Button ID="bnAddAgent" runat="server" OnClick="bnAddAgent_Click" Text="加入代理人"
					UseSubmitBehavior="False" />
			</td>
		</tr>
		<tr style="font-size: 12pt">
			<td style="height: 19px">
				&nbsp;</td>
		</tr>
		<tr style="font-size: 12pt">
			<td align="center" bgcolor="lavender" style="border-right: #0099ff 3px double; border-top: #0099ff 3px double;
				border-left: #0099ff 3px double; border-bottom: #0099ff 3px double">
				<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
					<asp:View ID="View1" runat="server">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td align="center" style="height: 18px" width="33%">
									<asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Smaller" Text="第一順位代理人"></asp:Label></td>
								<td align="center" style="height: 18px" width="34%">
									<asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Smaller" Text="第二順位代理人"></asp:Label></td>
								<td align="center" style="height: 18px" width="33%">
									<asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Smaller" Height="0%"
										Text="第三順位代理人"></asp:Label></td>
							</tr>
							<tr>
								<td align="center" style="height: 0%" valign="top" width="33%">
									<table width="100%">
										<tr>
											<td align="center" bgcolor="#99ccff" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="Label12" runat="server" Font-Size="Smaller" Text="部門"></asp:Label></td>
											<td align="center" bgcolor="#99ccff" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="Label13" runat="server" Font-Size="Smaller" Text="職稱"></asp:Label></td>
											<td align="center" bgcolor="#99ccff" nowrap="nowrap" style="height: 0%" width="20%">
												<asp:Label ID="Label14" runat="server" Font-Size="Smaller" Text="姓名"></asp:Label></td>
										</tr>
										<tr>
											<td align="center" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="lbDept1" runat="server" Font-Size="Smaller"></asp:Label></td>
											<td align="center" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="lbPos1" runat="server" Font-Size="Smaller"></asp:Label></td>
											<td align="center" nowrap="nowrap" style="height: 0%" width="20%">
												<asp:Label ID="lbEmp1" runat="server" Font-Size="Smaller" Height="0%"></asp:Label></td>
										</tr>
									</table>
								</td>
								<td align="center" style="height: 0%" valign="top" width="34%">
									<table width="100%">
										<tr>
											<td align="center" bgcolor="#99ccff" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="Label18" runat="server" Font-Size="Smaller" Text="部門"></asp:Label></td>
											<td align="center" bgcolor="#99ccff" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="Label19" runat="server" Font-Size="Smaller" Text="職稱"></asp:Label></td>
											<td align="center" bgcolor="#99ccff" nowrap="nowrap" style="height: 0%" width="20%">
												<asp:Label ID="Label20" runat="server" Font-Size="Smaller" Text="姓名"></asp:Label></td>
										</tr>
										<tr>
											<td align="center" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="lbDept2" runat="server" Font-Size="Smaller"></asp:Label></td>
											<td align="center" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="lbPos2" runat="server" Font-Size="Smaller"></asp:Label></td>
											<td align="center" nowrap="nowrap" style="height: 0%" width="20%">
												<asp:Label ID="lbEmp2" runat="server" Font-Size="Smaller" Height="0%"></asp:Label></td>
										</tr>
									</table>
								</td>
								<td align="center" style="height: 0%" valign="top" width="33%">
									<table width="100%">
										<tr>
											<td align="center" bgcolor="#99ccff" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="Label24" runat="server" Font-Size="Smaller" Text="部門"></asp:Label></td>
											<td align="center" bgcolor="#99ccff" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="Label25" runat="server" Font-Size="Smaller" Text="職稱"></asp:Label></td>
											<td align="center" bgcolor="#99ccff" nowrap="nowrap" style="height: 0%" width="20%">
												<asp:Label ID="Label26" runat="server" Font-Size="Smaller" Text="姓名"></asp:Label></td>
										</tr>
										<tr>
											<td align="center" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="lbDept3" runat="server" Font-Size="Smaller"></asp:Label></td>
											<td align="center" nowrap="nowrap" style="height: 0%" width="40%">
												<asp:Label ID="lbPos3" runat="server" Font-Size="Smaller"></asp:Label></td>
											<td align="center" nowrap="nowrap" style="height: 0%" width="20%">
												<asp:Label ID="lbEmp3" runat="server" Font-Size="Smaller" Height="0%"></asp:Label></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="center" style="height: 0%" valign="top" width="33%">
									<asp:Button ID="bnDel1" runat="server" OnClick="bnDel1_Click" OnClientClick="return confirm('刪除確認')"
										Text="刪除第一順位代理人" Width="100%" /></td>
								<td align="center" style="height: 0%" valign="top" width="34%">
									<asp:Button ID="bnDel2" runat="server" OnClick="bnDel2_Click" OnClientClick="return confirm('刪除確認')"
										Text="刪除第二順位代理人" Width="100%" /></td>
								<td align="center" style="height: 0%" valign="top" width="33%">
									<asp:Button ID="bnDel3" runat="server" OnClick="bnDel3_Click" OnClientClick="return confirm('刪除確認')"
										Text="刪除第三順位代理人" Width="100%" /></td>
							</tr>
						</table>
					</asp:View>
					<asp:View ID="View2" runat="server">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td style="height: 19px" width="40%" align="right">
								</td>
								<td style="height: 19px" width="35%" align="right">
									<asp:DropDownList ID="cbDept" runat="server" DataSourceID="ObjectDataSource4" DataTextField="name" DataValueField="id">
									</asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource4" runat="server" DeleteMethod="Delete"
										InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByPath"
										TypeName="ezClientDSTableAdapters.DeptTableAdapter" UpdateMethod="Update">
										<DeleteParameters>
											<asp:Parameter Name="Original_id" Type="String" />
										</DeleteParameters>
										<UpdateParameters>
											<asp:Parameter Name="id" Type="String" />
											<asp:Parameter Name="idParent" Type="String" />
											<asp:Parameter Name="name" Type="String" />
											<asp:Parameter Name="path" Type="String" />
											<asp:Parameter Name="DeptLevel_id" Type="String" />
											<asp:Parameter Name="Original_id" Type="String" />
										</UpdateParameters>
										<SelectParameters>
											<asp:SessionParameter ConvertEmptyStringToNull="False" Name="path" SessionField="Dept_path"
												Type="String" />
										</SelectParameters>
										<InsertParameters>
											<asp:Parameter Name="id" Type="String" />
											<asp:Parameter Name="idParent" Type="String" />
											<asp:Parameter Name="name" Type="String" />
											<asp:Parameter Name="path" Type="String" />
											<asp:Parameter Name="DeptLevel_id" Type="String" />
										</InsertParameters>
									</asp:ObjectDataSource>
									<asp:CheckBox ID="ckAllSub" runat="server" Font-Size="Smaller" Text="含子部門" />
									<asp:Button ID="bnAddOrg" runat="server" Text="加入" OnClick="bnAddOrg_Click" /></td>
								<td style="height: 19px" width="25%" align="right">
									<asp:DropDownList ID="cbFlow" runat="server" DataSourceID="ObjectDataSource5" DataTextField="name" DataValueField="id">
									</asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource5" runat="server" DeleteMethod="Delete"
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
											<asp:SessionParameter ConvertEmptyStringToNull="False" Name="Path" SessionField="Dept_path"
												Type="String" />
											<asp:ControlParameter ControlID="cbMyRole" ConvertEmptyStringToNull="False" Name="Role_ID"
												PropertyName="SelectedValue" Type="String" />
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
									<asp:Button ID="bnAddFlow" runat="server" Text="加入" OnClick="bnAddFlow_Click" /></td>
							</tr>
							<tr>
								<td valign="top" width="40%">
									<asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="auto" DataSourceID="ObjectDataSource1" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
										<Columns>
											<asp:TemplateField ShowHeader="False">
												<HeaderStyle Width="1%" />
												<ItemTemplate>
													<asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select"
														Text="選取" /><asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete"
															OnClientClick="return confirm('刪除確認')" Text="刪除" />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="職稱">
												<ItemStyle HorizontalAlign="Center" />
												<HeaderStyle HorizontalAlign="Center" />
												<ItemTemplate>
													<asp:Label ID="lbPos" runat="server"></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="姓名">
												<ItemStyle HorizontalAlign="Center" />
												<HeaderStyle HorizontalAlign="Center" />
												<ItemTemplate>
													<asp:Label ID="lbEmp" runat="server"></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
										</Columns>
										<EmptyDataTemplate>
											&nbsp;<br />
											尚未加入常態代理人<br />
											&nbsp;
										</EmptyDataTemplate>
									</asp:GridView>
									<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
										InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByIdSource"
										TypeName="ezClientDSTableAdapters.CheckAgentAlwaysTableAdapter" UpdateMethod="Update" OnDeleted="ObjectDataSource1_Deleted">
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
											<asp:SessionParameter ConvertEmptyStringToNull="False" Name="Emp_idSource" SessionField="Emp_id"
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
								<td valign="top" width="35%">
									<asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="auto" DataSourceID="ObjectDataSource2" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting">
										<Columns>
											<asp:TemplateField ShowHeader="False">
												<HeaderStyle Width="1%" />
												<ItemTemplate>
													<asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select"
														Text="選取" /><asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete"
															OnClientClick="return confirm('刪除確認')" Text="刪除" />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="可簽核的部門">
												<ItemStyle HorizontalAlign="Center" />
												<HeaderStyle HorizontalAlign="Center" />
												<ItemTemplate>
													<asp:Label ID="lbDept" runat="server"></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:CheckBoxField DataField="isAllSub" HeaderText="含子部門" SortExpression="isAllSub">
												<ItemStyle HorizontalAlign="Center" />
												<HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
											</asp:CheckBoxField>
										</Columns>
										<EmptyDataTemplate>
											&nbsp;<br />
											尚未加入可簽核部門限制<br />
											&nbsp;
										</EmptyDataTemplate>
									</asp:GridView>
									<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete"
										InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCheckAgentAlways"
										TypeName="ezClientDSTableAdapters.CheckAgentPowerMTableAdapter" UpdateMethod="Update" OnDeleted="ObjectDataSource2_Deleted">
										<DeleteParameters>
											<asp:Parameter Name="Original_auto" Type="Int32" />
										</DeleteParameters>
										<UpdateParameters>
											<asp:Parameter Name="CheckAgentAlways_auto" Type="Int32" />
											<asp:Parameter Name="Dept_id" Type="String" />
											<asp:Parameter Name="isAllSub" Type="Boolean" />
											<asp:Parameter Name="Original_auto" Type="Int32" />
										</UpdateParameters>
										<SelectParameters>
											<asp:ControlParameter ControlID="GridView1" Name="CheckAgentAlways_auto" PropertyName="SelectedValue"
												Type="Int32" />
										</SelectParameters>
										<InsertParameters>
											<asp:Parameter Name="CheckAgentAlways_auto" Type="Int32" />
											<asp:Parameter Name="Dept_id" Type="String" />
											<asp:Parameter Name="isAllSub" Type="Boolean" />
										</InsertParameters>
									</asp:ObjectDataSource>
								</td>
								<td valign="top" width="25%">
									<asp:GridView ID="GridView3" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="auto" DataSourceID="ObjectDataSource3" OnRowDataBound="GridView3_RowDataBound">
										<Columns>
											<asp:TemplateField ShowHeader="False">
												<HeaderStyle Width="1%" />
												<ItemTemplate>
													<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete"
															OnClientClick="return confirm('刪除確認')" Text="刪除" />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="可簽核流程">
												<ItemTemplate>
													<asp:Label ID="lbFlow" runat="server"></asp:Label>
												</ItemTemplate>
												<ItemStyle HorizontalAlign="Center" />
												<HeaderStyle HorizontalAlign="Center" />
											</asp:TemplateField>
										</Columns>
										<EmptyDataTemplate>
											&nbsp;<br />
											尚未加入可簽核流程限制<br />
											&nbsp;
										</EmptyDataTemplate>
									</asp:GridView>
									<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DeleteMethod="Delete"
										InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCheckAgentPowerM"
										TypeName="ezClientDSTableAdapters.CheckAgentPowerDTableAdapter" UpdateMethod="Update">
										<DeleteParameters>
											<asp:Parameter Name="Original_auto" Type="Int32" />
										</DeleteParameters>
										<UpdateParameters>
											<asp:Parameter Name="CheckAgentPowerM_auto" Type="Int32" />
											<asp:Parameter Name="FlowTree_id" Type="String" />
											<asp:Parameter Name="Original_auto" Type="Int32" />
										</UpdateParameters>
										<SelectParameters>
											<asp:ControlParameter ControlID="GridView2" Name="CheckAgentPowerM_auto" PropertyName="SelectedValue"
												Type="Int32" />
										</SelectParameters>
										<InsertParameters>
											<asp:Parameter Name="CheckAgentPowerM_auto" Type="Int32" />
											<asp:Parameter Name="FlowTree_id" Type="String" />
										</InsertParameters>
									</asp:ObjectDataSource>
								</td>
							</tr>
						</table>
					</asp:View>
				</asp:MultiView></td>
		</tr>
		<tr style="font-size: 12pt">
			<td>
			</td>
		</tr>
	</table>
</asp:Content>

