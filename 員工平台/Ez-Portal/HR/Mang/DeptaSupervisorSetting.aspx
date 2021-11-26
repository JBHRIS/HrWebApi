<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="DeptaSupervisorSetting.aspx.cs" Inherits="DeptaSupervisorSetting" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="../../Templet/SelectEmp.ascx" TagName="SelectEmp" TagPrefix="uc1" %>
<%@ Register Src="../../Templet/UserQuickSearch.ascx" TagName="UserQuickSearch" TagPrefix="uc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <div id="content">
            <div id="sideContent">
                <h3>
                    <asp:Localize ID="Localize1" runat="server">員工資料</asp:Localize>
                </h3>
                <fieldset>
                    <uc2:UserQuickSearch ID="UserQuickSearch1" runat="server" />
                </fieldset>
                <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                <h3 id="empMenu" runat="server">
                    <asp:Label ID="lblDept" runat="server" Text="部門資料" meta:resourcekey="lblDeptResource1"></asp:Label>
                </h3>
                <fieldset>
                    <asp:TreeView ID="TreeView1" runat="server" meta:resourcekey="TreeView1Resource1">
                        <SelectedNodeStyle ForeColor="#99CCFF" />
                    </asp:TreeView>
                </fieldset>
            </div>
            <div id="mainContent">
                <fieldset>
                    <legend>
                        <asp:Label ID="lblSearch" runat="server" Text="查詢條件" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                    &nbsp;By<asp:DropDownList ID="ddlSearchType" runat="server">
                        <asp:ListItem Selected="True" Value="0">依員工資料</asp:ListItem>
                        <asp:ListItem Value="1">依部門資料</asp:ListItem>
                        <asp:ListItem Value="2">全部</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                        meta:resourcekey="Button1Resource2" />
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="加入" meta:resourcekey="Button1Resource2" />
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Selected="True" Value="1">新增</asp:ListItem>
                        <asp:ListItem Value="0">排除</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <telerik:RadGrid ID="gv" runat="server" OnNeedDataSource="gv_NeedDataSource" AutoGenerateColumns="False"
                        CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemCommand="gv_ItemCommand">
                        <MasterTableView DataKeyNames="AutoKey">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="DeptCode" FilterControlAltText="Filter DeptCode column"
                                    HeaderText="部門代碼" UniqueName="DeptCode">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column"
                                    HeaderText="部門名稱" UniqueName="DeptName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                                    HeaderText="工號" UniqueName="Nobr">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Name_C" FilterControlAltText="Filter Name_C column"
                                    HeaderText="姓名" UniqueName="Name_C">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AddOrDel" FilterControlAltText="Filter AddOrDel column"
                                    HeaderText="新增或排除" UniqueName="AddOrDel">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AutoKey" FilterControlAltText="Filter AutoKey column"
                                    HeaderText="AutoKey" UniqueName="AutoKey" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="PushButton" ConfirmText="是否確認刪除?" FilterControlAltText="Filter Del column"
                                    Text="刪除" UniqueName="Del" CommandName="Del">
                                </telerik:GridButtonColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </fieldset>
            </div>
        </div>
        <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
