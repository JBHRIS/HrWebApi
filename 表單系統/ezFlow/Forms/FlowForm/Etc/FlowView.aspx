<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT20140325.master" AutoEventWireup="true"
    CodeFile="FlowView.aspx.cs" Inherits="Etc_FlowView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plContent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plContent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnActive">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plContent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gvAppM">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plContent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="rwMT" runat="server" Title="" Height="500px" Width="700px"
                Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <asp:Panel ID="plContent" runat="server">
        <table>
            <tr>
                <td>
                    表單名稱<telerik:RadComboBox ID="txtFlowForm" runat="server" CssClass="formItem" Culture="zh-TW"
                        LoadingMessage="載入中…" AppendDataBoundItems="True">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Selected="True" Text="All"
                                Value="0" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbManage" runat="server" Text="全部" />
                </td>
            </tr>
            <tr>
                <td>
                    流程編號<telerik:RadNumericTextBox ID="txtProcessID" runat="server" CssClass="formItem"
                        DataType="System.Int32">
                        <NumberFormat DecimalDigits="0" GroupSeparator="" ZeroPattern="n" />
                    </telerik:RadNumericTextBox>
                </td>
                <td>
                    工號<telerik:RadTextBox ID="txtNobr" runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                                申請日期
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="txtDateAppB" runat="server" CssClass="formItem">
                                    <Calendar ID="cldDateAppB" runat="server" EnableKeyboardNavigation="true">
                                    </Calendar>
                                    <DateInput ToolTip="Date input">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                到
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="txtDateAppE" runat="server" CssClass="formItem" Width="150px">
                                    <Calendar ID="cldDateAppE" runat="server" EnableKeyboardNavigation="true">
                                    </Calendar>
                                    <DateInput ToolTip="Date input">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                                核准日期
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="txtDateSignB" runat="server" CssClass="formItem" Width="150px">
                                    <Calendar ID="cldDateSignB" runat="server" EnableKeyboardNavigation="true">
                                    </Calendar>
                                    <DateInput ToolTip="Date input">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                到
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="txtDateSignE" runat="server" CssClass="formItem" Width="150px">
                                    <Calendar ID="cldDateSignE" runat="server" EnableKeyboardNavigation="true">
                                    </Calendar>
                                    <DateInput ToolTip="Date input">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadMenu ID="muApp" runat="server" Style="top: 0px; left: 0px; z-index: 2900">
                        <Items>
                            <telerik:RadMenuItem runat="server" Selected="True" Text="申請者" Value="1">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="被申請者" Value="2">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="審核者" Value="3">
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td>
                    <telerik:RadMenu ID="muState" runat="server" Style="top: 0px; left: 0px; z-index: 2900">
                        <Items>
                            <telerik:RadMenuItem runat="server" Selected="True" Text="進行中" Value="1">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="已完成" Value="3">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="已駁回" Value="2">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="已抽單" Value="7">
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btnExport" runat="server" Text="匯出" Visible="False">
                    </telerik:RadButton>
                </td>
                <td>
                    <asp:Panel ID="plManage" runat="server">
                        <telerik:RadComboBox ID="txtActive" runat="server" CssClass="formItem" Culture="zh-TW"
                            LoadingMessage="載入中…" AppendDataBoundItems="True">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Selected="True" Text="起點重送流程"
                                    Value="1" />
                                <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="上點重送流程" Value="2" />
                                <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="核准" Value="3" />
                                <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="作廢" Value="4" />
                                <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="刪除實體資料" Value="5" />
                                <telerik:RadComboBoxItem runat="server" Owner="txtFlowForm" Text="寄信催簽" Value="6" />
                            </Items>
                        </telerik:RadComboBox>
                        <telerik:RadButton ID="btnActive" runat="server" Text="執行">
                        </telerik:RadButton>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <telerik:RadGrid ID="gvAppM" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None"
            OnItemCommand="gvAppM_ItemCommand" OnItemDataBound="gvAppM_ItemDataBound">
            <MasterTableView>
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnView" runat="server" CommandArgument='<%# Eval("ProcessID") %>'
                                CommandName="View" Text="檢視">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnTake" runat="server" CommandArgument='<%# Eval("ProcessID") %>'
                                ToolTip='<%# Eval("Nobr") %>' CommandName="Take" Text="抽單" OnClientClicking="ExcuteConfirm">
                            </telerik:RadButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="ProcessID" FilterControlAltText="Filter column column"
                        HeaderText="流程序號" SortExpression="ProcessID" UniqueName="ProcessID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FormName" FilterControlAltText="Filter column1 column"
                        HeaderText="表單名稱" SortExpression="FormName" UniqueName="FormName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Info" FilterControlAltText="Filter column2 column"
                        HeaderText="資訊" SortExpression="Info" UniqueName="Info">
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
        <asp:Label ID="lblFormCode" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblViewUrl" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
</asp:Content>
