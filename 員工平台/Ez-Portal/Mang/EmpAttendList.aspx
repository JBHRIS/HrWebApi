<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EmpAttendList.aspx.cs" Inherits="Mang_EmpAttendList"
    Title="員工出勤清單" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../CalendarAbsList.ascx" TagName="CalendarAbsList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
            <h3>
                <asp:Localize ID="lHeader" runat="server" meta:resourcekey="lHeaderResource1" Text="
                                出勤清單查詢
                "></asp:Localize>
            </h3>
            <fieldset>
                <legend>
                    <asp:Localize ID="Localize1" runat="server" 
                        meta:resourcekey="Localize1Resource1" Text="查詢條件"></asp:Localize></legend>
                <asp:Label ID="Label1" runat="server" Text="查詢日期：" 
                    meta:resourcekey="Label1Resource1"></asp:Label>
                &nbsp;<telerik:RadDatePicker ID="rdpBdate" runat="server" Culture="(Default)" 
                    meta:resourcekey="rdpBdateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdpBdate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                <asp:Localize ID="Localize2" runat="server" 
                    meta:resourcekey="Localize2Resource1" Text="至"></asp:Localize>
                <telerik:RadDatePicker ID="rdpEdate" runat="server" Culture="(Default)" 
                    meta:resourcekey="rdpEdateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpEdate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <br />
                <br />
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                    ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />
                &nbsp;<asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" 
                    Text="匯出Excel" meta:resourcekey="ExportExcelResource1" />
                <br />
            </fieldset>
            <table style="width: 100%;">
                <tr>
                    <td valign="top">
                        <br />
                        <telerik:RadGrid ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemDataBound="gv_ItemDataBound" OnNeedDataSource="gv_NeedDataSource">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column" HeaderText="部門" UniqueName="DeptName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column" HeaderText="工號" UniqueName="Nobr">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NameC" FilterControlAltText="Filter NameC column" HeaderText="姓名" UniqueName="NameC">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="AttendDate" DataFormatString="{0:yyyy/MM/dd}" FilterControlAltText="Filter AttendDate column" HeaderText="出勤日" UniqueName="AttendDate">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DayOfWeek" FilterControlAltText="Filter DayOfWeek column" HeaderText="星期" UniqueName="DayOfWeek">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Calendar" FilterControlAltText="Filter Calendar column" HeaderText="行事曆" UniqueName="Calendar">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ShiftName" FilterControlAltText="Filter ShiftName column" HeaderText="班別" UniqueName="ShiftName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="StartWorkingTime" FilterControlAltText="Filter StartWorkingTime column" HeaderText="上班時間" UniqueName="StartWorkingTime">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="EndWorkingTime" FilterControlAltText="Filter EndWorkingTime column" HeaderText="下班時間" UniqueName="EndWorkingTime">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="RealWorkHours" FilterControlAltText="Filter RealWorkHours column" HeaderText="出勤時數" UniqueName="RealWorkHours">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="LateMins" FilterControlAltText="Filter LateMins column" HeaderText="遲到(分)" UniqueName="LateMins">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="LeaveEarlyMins" FilterControlAltText="Filter LeaveEarlyMins column" HeaderText="早退(分)" UniqueName="LeaveEarlyMins">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="IsAbsent" FilterControlAltText="Filter IsAbsent column" HeaderText="曠職" UniqueName="IsAbsent">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="LostCardTimes" FilterControlAltText="Filter LostCardTimes column" HeaderText="忘刷(次)" UniqueName="LostCardTimes">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TakeLeaveNote" FilterControlAltText="Filter TakeLeaveNote column" HeaderText="請假" UniqueName="TakeLeaveNote">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                        </telerik:RadGrid>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
