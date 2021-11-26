<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FlowMonitor.aspx.cs" Inherits="FlowMonitor" Title="流程查詢" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Font-Size="Smaller"
		OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
		<asp:ListItem Selected="True" Value="0">進行中的流程</asp:ListItem>
		<asp:ListItem Value="1">流程歷史查詢</asp:ListItem>
	</asp:RadioButtonList>
	<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
		<asp:View ID="View1" runat="server">
	<asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="False" DataKeyNames="ProcessFlow_id"
		DataSourceID="ObjectDataSource1" OnRowCommand="grdMain_RowCommand" OnRowDataBound="grdMain_RowDataBound"
		Width="100%">
		<Columns>
			<asp:TemplateField ShowHeader="False">
				<HeaderStyle Width="1%" />
				<ItemTemplate>
					<asp:Button ID="bnView" runat="server" CausesValidation="false" CommandName="View"
						Text="內容" />
					<asp:Button ID="bnHistory" runat="server" CommandName="History" Text="過程" CommandArgument='<%# Eval("ProcessFlow_id") %>' />
				</ItemTemplate>
				<ItemStyle Wrap="False" />
			</asp:TemplateField>
			<asp:BoundField DataField="ProcessFlow_id" HeaderText="流程序" ReadOnly="True" SortExpression="ProcessFlow_id">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="8%" />
			</asp:BoundField>
			<asp:BoundField DataField="FlowTree_name" HeaderText="流程名稱" SortExpression="FlowTree_name">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="25%" />
			</asp:BoundField>
			<asp:BoundField DataField="FlowNode_name" HeaderText="處理進度" SortExpression="FlowNode_name">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="25%" />
			</asp:BoundField>
			<asp:BoundField DataField="date_Start" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="申請時間"
				HtmlEncode="False" SortExpression="date_Start">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="15%" />
			</asp:BoundField>
			<asp:BoundField DataField="date_Check" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="送審時間"
				HtmlEncode="False" SortExpression="date_Check">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="15%" />
			</asp:BoundField>
			<asp:BoundField DataField="Emp_name_Check" HeaderText="處理者姓名" SortExpression="Emp_name_Check" Visible="False">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle Width="12%" />
			</asp:BoundField>
		</Columns>
		<EmptyDataTemplate>
			<br />
			<br />
			<br />
			&nbsp;<br />
			<br />
			<br />
			<br />
			您好！目前沒有未完成的流程。謝謝！&nbsp;<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			&nbsp;
		</EmptyDataTemplate>
	</asp:GridView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
		SelectMethod="GetData" TypeName="ezClientDSTableAdapters.StartListTableAdapter">
		<SelectParameters>
            <asp:ControlParameter ControlID="lb_nobr" Name="Emp_id" PropertyName="Text" Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>
            <asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>
		</asp:View>
		<asp:View ID="View2" runat="server">
			&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="Smaller" Text="查詢年度"></asp:Label>&nbsp;<asp:DropDownList
				ID="cbQueryYear" runat="server" DataSourceID="sdsYear" DataTextField="sYear" DataValueField="sYear">
			</asp:DropDownList>
			<asp:Label ID="Label2" runat="server" Font-Size="Smaller" Text="月份"></asp:Label>&nbsp;<asp:DropDownList
				ID="cbQueryMonth" runat="server">
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
			</asp:DropDownList>&nbsp;<asp:Button ID="bnQuery" runat="server" OnClick="bnQuery_Click"
				Text="查詢" /><br />
			<asp:GridView ID="grdHistory" runat="server" AutoGenerateColumns="False" DataKeyNames="id,ProcessApView_auto"
		DataSourceID="ObjectDataSource2" OnRowCommand="grdHistory_RowCommand" OnRowDataBound="grdHistory_RowDataBound"
		Width="100%">
				<Columns>
					<asp:TemplateField ShowHeader="False">
						<ItemStyle HorizontalAlign="Center" Wrap="False" />
						<HeaderStyle Width="1%" />
						<ItemTemplate>
							<asp:Button ID="bnView" runat="server" CausesValidation="False" CommandName="View"
						Text="內容" CommandArgument='<%# Eval("ProcessApView_auto", "{0}") %>' /><asp:Button ID="bnHistory" runat="server" CommandName="History" Text="過程" CommandArgument='<%# Eval("id", "{0}") %>' />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="id" HeaderText="流程序" ReadOnly="True" SortExpression="id">
						<ItemStyle HorizontalAlign="Center" />
						<HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
					</asp:BoundField>
					<asp:BoundField DataField="adate" DataFormatString="{0:yyyy/MM/dd HH:mm}" HeaderText="申請日期"
						HtmlEncode="False" SortExpression="adate">
						<ItemStyle HorizontalAlign="Center" Wrap="False" />
						<HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
					</asp:BoundField>
					<asp:TemplateField HeaderText="流程名稱" SortExpression="FlowTree_id">
						<EditItemTemplate>
							<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FlowTree_id") %>'></asp:TextBox>
						</EditItemTemplate>
						<ItemStyle HorizontalAlign="Left" />
						<HeaderStyle HorizontalAlign="Left" />
						<ItemTemplate>
							<asp:Label ID="lbFlowName" runat="server"></asp:Label>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<EmptyDataTemplate>
					<br />
					<br />
					<br />
					&nbsp;<br />
					<br />
					<br />
					<br />
					您好！目前沒有未完成的流程。謝謝！&nbsp;<br />
					<br />
					<br />
					<br />
					<br />
					<br />
					&nbsp;
				</EmptyDataTemplate>
			</asp:GridView>
			<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
				SelectMethod="GetData" TypeName="ezClientDSTableAdapters.FlowHistoryTableAdapter">
				<SelectParameters>
                    <asp:ControlParameter ControlID="lb_nobr" Name="Emp_id" PropertyName="Text" Type="String" />
					<asp:SessionParameter DefaultValue="" Name="dateB" SessionField="dateB" Type="DateTime" />
					<asp:SessionParameter Name="dateE" SessionField="dateE" Type="DateTime" />
				</SelectParameters>
			</asp:ObjectDataSource>
            <asp:SqlDataSource ID="sdsYear" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                SelectCommand="SELECT DISTINCT YEAR(adate) AS sYear FROM ProcessFlow ORDER BY sYear DESC">
            </asp:SqlDataSource>
		</asp:View>
	</asp:MultiView>
</asp:Content>

