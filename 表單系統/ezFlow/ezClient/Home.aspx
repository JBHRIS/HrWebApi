<%@ Page Language="C#" MasterPageFile="~/MasterPage_NoSubMenu.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Home" Title="ezClient v1.0" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td>
                您好，
                <asp:Label ID="lbName" runat="server" SkinID="Name"></asp:Label>
                歡迎您回來！</td>
            <td align="right">
                <asp:Label ID="lbMsg" runat="server" SkinID="Msg"></asp:Label></td>
        </tr>
        <tr>
            <td>
                您使用的瀏覽器：<asp:Label ID="lblBrowser" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="使用手機簽核" 
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                    OnRowCommand="grdMain_RowCommand" OnRowDataBound="grdMain_RowDataBound" 
                    Width="100%" AllowSorting="True" DataKeyNames="ProcessFlow_id" 
                    onselectedindexchanged="grdMain_SelectedIndexChanged">
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
                        <asp:BoundField DataField="Emp_name_Agent" HeaderText="簽核代理人" 
                            SortExpression="Emp_name_Agent">
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                &nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:DataList ID="dlNews" runat="server" DataKeyField="auto" DataSourceID="odsNews"
        OnItemCommand="dlNews_ItemCommand" OnItemDataBound="dlNews_ItemDataBound" Width="100%">
        <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td nowrap="nowrap" valign="top" width="1%">
                        <asp:Label ID="Label9" runat="server" Text="日期:"></asp:Label></td>
                    <td valign="top">
                        <asp:Label ID="adateLabel" runat="server" Text='<%# Eval("adate", "{0:yyyy-MM-dd HH:mm}") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td nowrap="nowrap" valign="top" width="1%">
                        <asp:Label ID="Label10" runat="server" Text="主題:"></asp:Label></td>
                    <td>
                        <asp:LinkButton ID="lnkBtnCaption" runat="server" CommandArgument='<%# Eval("auto") %>'
                            CommandName="HrPost" Text='<%# Eval("caption") %>'></asp:LinkButton></td>
                </tr>
            </table>
        </ItemTemplate>
        <HeaderTemplate>
            <asp:Button ID="bnAdmin" runat="server" CommandName="NewHrPost" Text="張貼最新消息" Width="100%" />
        </HeaderTemplate>
        <HeaderStyle HorizontalAlign="Center" />
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="odsNews" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="ezClientDSTableAdapters.HrPostTableAdapter"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <asp:DataList ID="dlNotice" runat="server" DataKeyField="iAutoKey" DataSourceID="odsNotice"
        OnItemCommand="dlNews_ItemCommand" OnItemDataBound="dlNews_ItemDataBound" Width="100%">
        <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td nowrap="nowrap" valign="top" width="1%">
                        <asp:Label ID="Label9" runat="server" Text="日期："></asp:Label></td>
                    <td valign="top">
                        <asp:Label ID="adateLabel" runat="server" Text='<%# Eval("dDate", "{0:d}") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td nowrap="nowrap" valign="top" width="1%">
                        <asp:Label ID="Label10" runat="server" Text="主題："></asp:Label></td>
                    <td>
                        <asp:LinkButton ID="lnkBtnCaption" runat="server" CommandArgument='<%# Eval("iAutoKey") %>'
                            CommandName="HrNotice" Text='<%# Eval("sCaption") %>'></asp:LinkButton></td>
                </tr>
                <tr>
                    <td nowrap="nowrap" valign="top" width="1%">
                    </td>
                    <td>
                        有<asp:Label ID="Label2" runat="server" Text='<%# Eval("FilesCount") %>' SkinID="Notice"></asp:Label>個附件</td>
                </tr>
            </table>
        </ItemTemplate>
        <HeaderTemplate>
            <asp:Button ID="bnAdmin" runat="server" CommandName="NewHrNotice" Text="管理公告" Width="100%" />
        </HeaderTemplate>
        <HeaderStyle BackColor="Silver" HorizontalAlign="Center" />
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="odsNotice" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataByBetweenDate" TypeName="ezClientDSTableAdapters.HrNoticeTableAdapter"
        DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_iAutoKey" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="sCaption" Type="String" />
            <asp:Parameter Name="sContent" Type="String" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dDate" Type="DateTime" />
            <asp:Parameter Name="Original_iAutoKey" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="sCaption" Type="String" />
            <asp:Parameter Name="sContent" Type="String" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dDate" Type="DateTime" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>
