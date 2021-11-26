<%@ Page Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="WorkFinish.aspx.cs" Inherits="WorkFinish" Title="ezClient v1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	<asp:GridView ID="grdMain" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowCommand="grdMain_RowCommand" OnRowDataBound="grdMain_RowDataBound">
		<Columns>
			<asp:TemplateField ShowHeader="False">
				<HeaderStyle Width="1%" />
				<ItemTemplate>
					<asp:Button ID="bnCheck" runat="server" CausesValidation="false" CommandName="Check"
						Text="處理" />&nbsp;
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="ProcessFlow_id" HeaderText="流程序" SortExpression="ProcessFlow_id">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="10%" />
			</asp:BoundField>
			<asp:BoundField DataField="Emp_name_Start" HeaderText="申請人" SortExpression="Emp_name_Start">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="10%" />
			</asp:BoundField>
			<asp:BoundField DataField="adate" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="申請時間"
				HtmlEncode="False" SortExpression="adate">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="15%" />
			</asp:BoundField>
			<asp:BoundField DataField="FlowTree_name" HeaderText="流程名稱" SortExpression="FlowTree_name">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="20%" />
			</asp:BoundField>
			<asp:BoundField DataField="FlowNode_name" HeaderText="處理方式" SortExpression="FlowNode_name">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="25%" />
			</asp:BoundField>
			<asp:BoundField DataField="Emp_name_Agent" HeaderText="代理人" SortExpression="Emp_name_Agent">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="10%" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="狀態">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="10%" />
				<ItemTemplate>
					<asp:Label ID="lbStatus" runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
		<EmptyDataTemplate>
			&nbsp;<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			您好！目前沒有待處理的工作。謝謝！
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			&nbsp;
		</EmptyDataTemplate>
		<EmptyDataRowStyle BorderStyle="None" />
	</asp:GridView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
		SelectMethod="GetData" TypeName="ezClientDSTableAdapters.WorkListTableAdapter">
		<SelectParameters>
			<asp:SessionParameter Name="Emp_id" SessionField="Emp_id" Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>