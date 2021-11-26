<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuestHistory.aspx.cs" Inherits="GuestHistory" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body style="background-image: url(images/w06.gif); background-repeat: repeat-y; margin-left: 50px; margin-right: 25px;">
    <form id="form1" runat="server">    
		<asp:DataList ID="DataList1" runat="server" DataKeyField="auto" DataSourceID="ObjectDataSource1"
			Font-Size="Smaller" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound" Width="100%">
			<ItemTemplate>
				<asp:Panel ID="Panel1" runat="server" BackColor="Honeydew" BorderStyle="Solid" BorderWidth="1px"
					Width="99%" Wrap="False" BorderColor="Black">
					<asp:Label ID="lbName" runat="server" ForeColor="Blue"></asp:Label>於<asp:Label
								ID="adateLabel" runat="server" Text='<%# Eval("adate", "{0:yyyy-MM-dd HH:mm}") %>' ForeColor="Blue"></asp:Label>的時候留下訊息…(<asp:Label ID="lbFlag" runat="server" ForeColor="Teal"></asp:Label>)<br />
							<asp:Label ID="noteLabel" runat="server" Text='<%# Eval("note") %>' Font-Bold="True" ForeColor="Black"></asp:Label></asp:Panel>
				<asp:Panel ID="Panel2" runat="server" HorizontalAlign="Right" Width="99%">
					<asp:Button ID="bnRead" runat="server" CommandArgument='<%# Eval("auto") %>' CommandName="MsgRead"
						Text="已閱讀" />
					<asp:Button ID="bnDel" runat="server" CommandArgument='<%# Eval("auto") %>' CommandName="MsgDel"
						Text="刪除" /></asp:Panel>
			</ItemTemplate>
			<HeaderTemplate>				
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" Text="◎　我的留言板　◎"></asp:Label>
			</HeaderTemplate>
			<HeaderStyle HorizontalAlign="Center" />
		</asp:DataList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
			InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByEmp"
			TypeName="ezClientDSTableAdapters.GuestMsgTableAdapter" UpdateMethod="Update">
			<DeleteParameters>
				<asp:Parameter Name="Original_auto" Type="Int32" />
			</DeleteParameters>
			<UpdateParameters>
				<asp:Parameter Name="note" Type="String" />
				<asp:Parameter Name="adate" Type="DateTime" />
				<asp:Parameter Name="Emp_idFrom" Type="String" />
				<asp:Parameter Name="Emp_idTo" Type="String" />
				<asp:Parameter Name="isRead" Type="Boolean" />
				<asp:Parameter Name="Original_auto" Type="Int32" />
			</UpdateParameters>
			<SelectParameters>
				<asp:SessionParameter Name="Emp_idTo" SessionField="Emp_id" Type="String" />
			</SelectParameters>
			<InsertParameters>
				<asp:Parameter Name="note" Type="String" />
				<asp:Parameter Name="adate" Type="DateTime" />
				<asp:Parameter Name="Emp_idFrom" Type="String" />
				<asp:Parameter Name="Emp_idTo" Type="String" />
				<asp:Parameter Name="isRead" Type="Boolean" />
			</InsertParameters>
		</asp:ObjectDataSource>
		<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete"
			InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByNotRead"
			TypeName="ezClientDSTableAdapters.GuestMsgTableAdapter" UpdateMethod="Update">
			<DeleteParameters>
				<asp:Parameter Name="Original_auto" Type="Int32" />
			</DeleteParameters>
			<UpdateParameters>
				<asp:Parameter Name="note" Type="String" />
				<asp:Parameter Name="adate" Type="DateTime" />
				<asp:Parameter Name="Emp_idFrom" Type="String" />
				<asp:Parameter Name="Emp_idTo" Type="String" />
				<asp:Parameter Name="isRead" Type="Boolean" />
				<asp:Parameter Name="Original_auto" Type="Int32" />
			</UpdateParameters>
			<SelectParameters>
				<asp:SessionParameter Name="Emp_idTo" SessionField="Emp_id" Type="String" />
			</SelectParameters>
			<InsertParameters>
				<asp:Parameter Name="note" Type="String" />
				<asp:Parameter Name="adate" Type="DateTime" />
				<asp:Parameter Name="Emp_idFrom" Type="String" />
				<asp:Parameter Name="Emp_idTo" Type="String" />
				<asp:Parameter Name="isRead" Type="Boolean" />
			</InsertParameters>
		</asp:ObjectDataSource>    
    </form>
</body>
</html>
