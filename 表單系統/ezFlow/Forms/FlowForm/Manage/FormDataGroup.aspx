<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT0990113.master" AutoEventWireup="true" CodeFile="FormDataGroup.aspx.cs" Inherits="Manage_FormDataGroup" %>


<%@ Register TagPrefix="customEditors" Namespace="AjaxControlToolkit.HTMLEditor.Samples" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            color: #FF0000;
            font-weight: bold;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="TableFullBorder">
                            <tr>
                                <th nowrap="nowrap" width="20%">
                                    表單名稱</th>
                                <th nowrap="nowrap" width="20%">
                                    薪資群組</th>
                                <td rowspan="2">
                                    <asp:Button ID="btnAdd" runat="server" Text="增加不顯示" onclick="btnAdd_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:DropDownList ID="ddlFormName" runat="server" DataSourceID="sdsFormName" 
                                        DataTextField="sFormName" DataValueField="sFormCode">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sdsFormName" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:Flow %>" 
                                        SelectCommand="SELECT [sFormCode], [sFormName] FROM [wfForm]"></asp:SqlDataSource>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlDataGroup" runat="server" DataSourceID="sdsDataGroup" 
                                        DataTextField="sGroupName" DataValueField="sDataGroup">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sdsDataGroup" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:HR %>" 
                                        SelectCommand="SELECT [sDataGroup], [sGroupName] FROM [JB_HR_DataGroup]">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                       <font size="4"> ※本功能採用黑名單方法，被加入到下列的表單於薪資群組裡的人員將<span class="style1">不會</span>被顯示。</font></td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gv" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsGV" 
                            onrowdatabound="gv_RowDataBound">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" 
                                            CommandName="Delete" Text="刪除" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sFormName" HeaderText="表單名稱" 
                                    SortExpression="sFormName" />
                                <asp:BoundField DataField="sDataGroup" HeaderText="薪資群組" 
                                    SortExpression="sDataGroup" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsGV" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Flow %>" 
                            DeleteCommand="DELETE FROM [wfFormDataGroup] WHERE [iAutoKey] = @iAutoKey" 
                            SelectCommand="SELECT wfFormDataGroup.iAutoKey, wfFormDataGroup.sFormCode, wfFormDataGroup.sDataGroup, wfFormDataGroup.bMsgManage, wfFormDataGroup.bFormDisplay, wfForm.sFormName FROM wfFormDataGroup INNER JOIN wfForm ON wfFormDataGroup.sFormCode = wfForm.sFormCode">
                            <DeleteParameters>
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
