<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpOtForm.aspx.cs" Inherits="Mang_EmpOtForm" Title="休假統計"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../Templet/EmpDeptQS.ascx" tagname="EmpDeptQS" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
        Width="100%" HorizontalAlign="NotSet" meta:resourcekey="RadAjaxPanel1Resource1">
            <div style="float:left;width:1000px">
        
                <uc1:EmpDeptQS ID="EmpDeptQS1" runat="server" />        
        </div>
                <h3>
                    <asp:Label ID="lblShowHeader" runat="server" Text="員工加班資料" 
                        meta:resourcekey="lblShowHeaderResource1"></asp:Label>
                </h3>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblShowQueryHeader" runat="server" Text="查詢條件" meta:resourcekey="lblShowQueryHeaderResource1"></asp:Label></legend>
                    <asp:Label ID="lblAbsDate" runat="server" Text="請假日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="dpDtlB" runat="server" 
                        meta:resourcekey="adateResource1" Culture="(Default)">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                            ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" DisplayText="" 
                            LabelWidth="64px" Width="">
                        </DateInput>
                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dpDtlB"
                        ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="dpDtlE" runat="server" 
                        meta:resourcekey="ddateResource1" Culture="(Default)">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                            ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" DisplayText="" 
                            LabelWidth="64px" Width="">
                        </DateInput>
                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dpDtlE"
                        ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="查詢" ValidationGroup="group_date"
                        meta:resourcekey="Button1Resource2" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button2_Click" Text="匯出" meta:resourcekey="Button2Resource1" />
                    <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW" 
                        GridLines="None" meta:resourcekey="gvResource1">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                Visible="True">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                Visible="True">
                            </ExpandCollapseColumn>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                    <br />
                </fieldset>
                
        </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
