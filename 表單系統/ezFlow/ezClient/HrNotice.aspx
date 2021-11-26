<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HrNotice.aspx.cs" Inherits="HrNotice" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body class="DlgPage" STYLE="OVERFLOW:SCROLL;OVERFLOW-X:HIDDEN" scroll="auto">
<div class="Dlg">
    <form id="form1" runat="server">
		<table border="0" width="630" height="99%">
			<tr>
				<td class="DlgHeader" align="center" style="width:100%; height: 1%">
					<asp:Label ID="Label1" runat="server" Text="◎　公告　◎"></asp:Label></td>
			</tr>
			<tr>
				<td align="center" style="width: 100%; height: 1%">
					<asp:Label ID="Label2" runat="server" Text="標題："></asp:Label><asp:Label ID="lbSubject" runat="server" Font-Bold="True"></asp:Label></td>
			</tr>
			<tr>
				<td style="border: #CCCCCC 3px double; width: 100%;" valign="top">
					<asp:Label ID="lbContent" runat="server"></asp:Label></td>
			</tr>
            <tr>
                <td align="center" style="border-right: #000000 1px; border-top: #000000 1px; border-left: #000000 1px;
                    width: 100%; border-bottom: #000000 1px; height: 1%" valign="top">
                    <asp:GridView ID="gvFiles" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        DataKeyNames="iAutoKey" DataSourceID="odsFiles" OnRowCommand="gvFiles_RowCommand"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemStyle Width="1%" Wrap="False" />
                                <HeaderStyle Wrap="True" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("iAutoKey") %>'
                                        CommandName="Download" Text="下載"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="iAutoKey" HeaderText="iAutoKey" InsertVisible="False"
                                ReadOnly="True" SortExpression="iAutoKey" Visible="False" />
                            <asp:BoundField DataField="HrNotice_iAutoKey" HeaderText="HrNotice_iAutoKey" SortExpression="HrNotice_iAutoKey"
                                Visible="False" />
                            <asp:BoundField DataField="sServerName" HeaderText="加密檔名" SortExpression="sServerName"
                                Visible="False" />
                            <asp:BoundField DataField="sUploadName" HeaderText="上傳檔名" SortExpression="sUploadName" />
                            <asp:BoundField DataField="sType" HeaderText="檔案型態" SortExpression="sType" Visible="False" />
                            <asp:BoundField DataField="iSize" HeaderText="檔案大小(KB)" SortExpression="iSize">
                                <ItemStyle HorizontalAlign="Right" />
                                <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="上傳日期" HtmlEncode="False"
                                SortExpression="dDate" />
                            <asp:BoundField DataField="sDescription" HeaderText="檔案說明" SortExpression="sDescription" />
                        </Columns>
                        <EmptyDataTemplate>
                            目前無任何附件。
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsFiles" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByHrNotice_iAutoKey"
                        TypeName="ezClientDSTableAdapters.HrNoticeFilesTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_iAutoKey" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="HrNotice_iAutoKey" Type="Int32" />
                            <asp:Parameter Name="sServerName" Type="String" />
                            <asp:Parameter Name="sUploadName" Type="String" />
                            <asp:Parameter Name="sType" Type="String" />
                            <asp:Parameter Name="iSize" Type="Int32" />
                            <asp:Parameter Name="dDate" Type="DateTime" />
                            <asp:Parameter Name="sDescription" Type="String" />
                            <asp:Parameter Name="Original_iAutoKey" Type="Int32" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblAutoKey" Name="HrNotice_iAutoKey" PropertyName="Text"
                                Type="Int32" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="HrNotice_iAutoKey" Type="Int32" />
                            <asp:Parameter Name="sServerName" Type="String" />
                            <asp:Parameter Name="sUploadName" Type="String" />
                            <asp:Parameter Name="sType" Type="String" />
                            <asp:Parameter Name="iSize" Type="Int32" />
                            <asp:Parameter Name="dDate" Type="DateTime" />
                            <asp:Parameter Name="sDescription" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
			<tr>
				<td align="center" style="border-right: #000000 1px; border-top: #000000 1px; border-left: #000000 1px;
					border-bottom: #000000 1px; width: 100%; height: 1%" valign="top">
					<asp:Label ID="lbDate" runat="server" Font-Bold="False" Font-Size="Smaller"></asp:Label></td>
			</tr>
			<tr>
				<td align="center" style="border-right: #000000 1px; border-top: #000000 1px; border-left: #000000 1px;
					width: 100%; border-bottom: #000000 1px; height: 1%" valign="top">
					&nbsp;<asp:Label ID="lblAutoKey" runat="server" Font-Bold="False" Font-Size="Smaller"
                        Visible="False"></asp:Label></td>
			</tr>
		</table>
    </form>
    </div>
</body>
</html>
