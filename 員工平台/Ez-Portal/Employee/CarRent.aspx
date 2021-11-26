<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="CarRent.aspx.cs" Inherits="CarRent" Title="Untitled Page" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: left; width: 1000px">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
            <div>
                <telerik:RadComboBox ID="cbxItem" runat="server" DataTextField="Name" DataValueField="Id"
                    AutoPostBack="True" OnSelectedIndexChanged="cbxItem_SelectedIndexChanged">
                </telerik:RadComboBox>
                <telerik:RadButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增">
                </telerik:RadButton>
                <telerik:RadButton ID="btnEdit" runat="server" OnClick="btnEdit_Click"
                    Text="修改" Visible="false">
                </telerik:RadButton>
                <asp:Label ID="lblFormStatus" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
            </div>
            <div style="float: left; width: 100%">
                <div style="float: left; width: 345px" runat="server" id="pnlAddForm" visible="false">
                    <table>
                        <tr>
                            <td>起
                            </td>
                            <td>
                                <telerik:RadDateTimePicker ID="dtpB" runat="server" Culture="zh-TW" Width="200px"
                                    EnableTyping="False" AutoPostBackControl="Calendar" OnSelectedDateChanged="dtpB_SelectedDateChanged">
                                    <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm" Columns="6" Interval="00:30:00">
                                    </TimeView>
                                    <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                        LabelWidth="40%" type="text" value="" ReadOnly="True" AutoPostBack="True">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDateTimePicker>
                                <asp:RequiredFieldValidator ID="fv_dtpB" runat="server" ControlToValidate="dtpB"
                                    ErrorMessage="*必填" ForeColor="#FF3300" ValidationGroup="G"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>訖
                            </td>
                            <td>
                                <telerik:RadDateTimePicker ID="dtpE" runat="server" Culture="zh-TW" Width="200px"
                                    EnableTyping="False">
                                    <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm" Columns="6" Interval="00:30:00">
                                    </TimeView>
                                    <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                        LabelWidth="40%" type="text" value="" ReadOnly="True">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDateTimePicker>
                                <asp:RequiredFieldValidator ID="fv_dtpE" runat="server" ControlToValidate="dtpE"
                                    ErrorMessage="*必填" ForeColor="#FF3300" ValidationGroup="G"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>目的地
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbDestination" runat="server" Rows="3" TextMode="MultiLine"
                                    Width="100%">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>預約用途
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbContents" runat="server" Rows="3" TextMode="MultiLine"
                                    Width="100%">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>使用前里程數
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="ntbMileageBeforeRent" runat="server" DataType="System.Int32"
                                    MinValue="0">
                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>使用後里程數
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="ntbMileageAfterRent" runat="server" DataType="System.Int32"
                                    MinValue="0">
                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <telerik:RadButton ID="btnSave" runat="server" Text="存檔" OnClick="btnSave_Click"
                                    ValidationGroup="G">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <telerik:RadScheduler runat="server" ID="RadScheduler1" Width="100%" DayStartTime="00:00:00"
                    DayEndTime="23:59:00" TimeZoneOffset="03:00:00" OnAppointmentInsert="RadScheduler1_AppointmentInsert"
                    OnAppointmentUpdate="RadScheduler1_AppointmentUpdate" OnAppointmentDelete="RadScheduler1_AppointmentDelete"
                    DataKeyField="ID" DataSubjectField="Subject" DataStartField="Start" DataEndField="End"
                    DataRecurrenceField="RecurrenceRule" DataRecurrenceParentKeyField="RecurrenceParentId"
                    DataReminderField="Reminder" AllowEdit="False" AllowInsert="False" AppointmentStyleMode="Simple"
                    Height="1500px" OnAppointmentCommand="RadScheduler1_AppointmentCommand" OnFormCreating="RadScheduler1_FormCreating"
                    OnNavigationCommand="RadScheduler1_NavigationCommand"
                    ShowAllDayRow="False" ShowFooter="False"
                    ShowFullTime="True" ShowResourceHeaders="False" Skin="Web20" WorkDayEndTime="23:59:00"
                    WorkDayStartTime="00:00:00" Culture="zh-TW" HoursPanelTimeFormat="HH" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound"
                    RowHeight="20px" EnableDescriptionField="true"
                    OnAppointmentCreated="RadScheduler1_AppointmentCreated"
                    OnNavigationComplete="RadScheduler1_NavigationComplete"
                    OnAppointmentClick="RadScheduler1_AppointmentClick">
                    <AdvancedForm Modal="true"></AdvancedForm>
                    <Localization AdvancedCalendarToday="今日" ContextMenuDelete="刪除" ContextMenuEdit="編輯"
                        ContextMenuGoToToday="今日" HeaderMonth="月" AdvancedDay="日" ConfirmDeleteText="確認是否要刪除？"
                        HeaderDay="日" HeaderToday="今日" HeaderWeek="周" />
                    <TimelineView UserSelectable="false"></TimelineView>
                    <MonthView UserSelectable="False" />
                    <TimeSlotContextMenuSettings EnableDefault="true"></TimeSlotContextMenuSettings>
                    <WeekView WorkDayEndTime="23:59:00" WorkDayStartTime="00:00:00" DayEndTime="23:59:00"
                        DayStartTime="00:00:00" EnableExactTimeRendering="True" />
                </telerik:RadScheduler>
            </div>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>