<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="ExtQuery.aspx.cs" Inherits="ExtQuery" Title="Untitled Page" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
        Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <div style="float: left; width: 1000px">
            <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
        <asp:Panel ID="pnlEdit" runat="server" Visible="False">
            <telerik:RadTextBox ID="tbExtNum" runat="server" BackColor="#FF99FF">
            </telerik:RadTextBox>
            <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click">
            </telerik:RadButton>
            <telerik:RadButton ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click">
            </telerik:RadButton>
            <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
        </asp:Panel>
        <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
            Culture="zh-TW" GridLines="None" OnItemCommand="gv_ItemCommand" OnItemDataBound="gv_ItemDataBound">
            <MasterTableView DataKeyNames="Nobr">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridButtonColumn CommandName="cmdEdit" FilterControlAltText="Filter cmdEdit column"
                        Text="編輯" UniqueName="cmdEdit">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                        HeaderText="工號" UniqueName="Nobr" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NameC" FilterControlAltText="Filter NameC column"
                        HeaderText="姓名" UniqueName="NameC">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NameE" FilterControlAltText="Filter NameE column"
                        HeaderText="英文名" UniqueName="NameE">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column"
                        HeaderText="部門" UniqueName="DeptName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JobTitle" FilterControlAltText="Filter JobTitle column"
                        HeaderText="職稱" UniqueName="JobTitle">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExtNum" FilterControlAltText="Filter ExtNum column"
                        HeaderText="分機" UniqueName="ExtNum">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DeptCode" FilterControlAltText="Filter DeptCode column"
                        HeaderText="部門代碼" UniqueName="DeptCode" Visible="False">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader"><asp:Label ID="lblNote" runat="server" Text="程式說明" meta:resourcekey="lblNoteResource1"></asp:Label></span></span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:Label ID="lblNoteDetail" runat="server" Text="1.查詢員工獎懲資料！" meta:resourcekey="lblNoteDetailResource1"></asp:Label><br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
