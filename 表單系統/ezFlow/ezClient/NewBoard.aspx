<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="NewBoard.aspx.cs" Inherits="NewBoard" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	<asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" OnItemDataBound="DataList1_ItemDataBound" BorderColor="Olive" BorderStyle="Double" BorderWidth="3px" OnItemCommand="DataList1_ItemCommand">
		<ItemTemplate>
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td>
						<asp:Label ID="Label1" runat="server" Font-Size="Small" Text="新板名稱："></asp:Label><asp:Label
							ID="Label2" runat="server" Font-Size="Small" Text='<%# Eval("boardName") %>'></asp:Label>
						<asp:Button ID="bnCreate" runat="server" Text="開立新版" CommandArgument='<%# Eval("auto") %>' CommandName="Create" /></td>
					<td width="50%">
						<asp:Label ID="Label5" runat="server" Font-Size="Small" Text="準板主："></asp:Label>
						<asp:Label ID="lbAdmin" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td colspan="2" style="height: 21px">
						<asp:Label ID="Label3" runat="server" Font-Size="Small" Text="新板簡要："></asp:Label><asp:Label
							ID="Label4" runat="server" Font-Size="Small" Text='<%# Eval("boardNote") %>'></asp:Label></td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label ID="Label7" runat="server" Font-Size="Small" Text="連署名單："></asp:Label><asp:Label
							ID="lbAll" runat="server" Font-Italic="True"></asp:Label></td>
				</tr>
				<tr>
					<td>
					</td>
					<td width="50%">
						<asp:LinkButton ID="LinkButton4" runat="server" CommandName="Sign" CommandArgument='<%# Eval("auto") %>'>我也要加入連署名單，支持此版成立！</asp:LinkButton>
					</td>
				</tr>
			</table>
		</ItemTemplate>
		<AlternatingItemStyle BackColor="#E0E0E0" />
		<ItemStyle BackColor="LightCyan" />
		<SeparatorStyle HorizontalAlign="Center" />
		<SeparatorTemplate>
			<img src="images/dye_li_h_001.gif" />
		</SeparatorTemplate>
		<FooterStyle HorizontalAlign="Center" />
		<HeaderTemplate>
			<img src="images/dye_li_na_001.gif" /><br />
			<asp:Label ID="lbNon" runat="server" Font-Size="Small" Text="目前沒有新申請的討論板"></asp:Label>
		</HeaderTemplate>
		<HeaderStyle HorizontalAlign="Center" />
		<FooterTemplate>
			<img src="images/dye_li_na_007.gif" />
		</FooterTemplate>
	</asp:DataList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
		InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
		TypeName="ezClientDSTableAdapters.BoardApplyTableAdapter" UpdateMethod="Update">
		<DeleteParameters>
			<asp:Parameter Name="Original_auto" Type="Int32" />
		</DeleteParameters>
		<UpdateParameters>
			<asp:Parameter Name="Emp_idAdmin1" Type="String" />
			<asp:Parameter Name="Emp_idAdmin2" Type="String" />
			<asp:Parameter Name="boardName" Type="String" />
			<asp:Parameter Name="boardNote" Type="String" />
			<asp:Parameter Name="adate" Type="DateTime" />
			<asp:Parameter Name="Original_auto" Type="Int32" />
		</UpdateParameters>
		<InsertParameters>
			<asp:Parameter Name="Emp_idAdmin1" Type="String" />
			<asp:Parameter Name="Emp_idAdmin2" Type="String" />
			<asp:Parameter Name="boardName" Type="String" />
			<asp:Parameter Name="boardNote" Type="String" />
			<asp:Parameter Name="adate" Type="DateTime" />
		</InsertParameters>
	</asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td align="center" background="images/dye_li_pe_003.gif" height="56">
				<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Names="標楷體"
					PostBackUrl="~/LoginData.aspx">帳號資料變更</asp:LinkButton></td>
		</tr>
		<tr>
			<td align="center" background="images/dye_li_pe_004.gif" height="56">
				<asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Names="標楷體"
					PostBackUrl="~/Agent.aspx">我的代理規劃</asp:LinkButton></td>
		</tr>
		<tr>
			<td align="center" background="images/dye_li_pe_002.gif" height="56">
				<asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" Font-Names="標楷體"
					PostBackUrl="~/NewBoard.aspx">新板申請進度</asp:LinkButton></td>
		</tr>
	</table>
</asp:Content>

