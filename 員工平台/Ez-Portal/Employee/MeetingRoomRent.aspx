<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="MeetingRoomRent.aspx.cs" Inherits="MeetingRoomRent" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../Templet/SelectEmp3.ascx" TagName="SelectEmp3" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: left; width: 1000px">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
            HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
            <div>
                <telerik:RadComboBox ID="cbxItem" runat="server" DataTextField="Name" DataValueField="Id"
                    AutoPostBack="True" OnSelectedIndexChanged="cbxItem_SelectedIndexChanged">
                </telerik:RadComboBox>
                <telerik:RadButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增">
                </telerik:RadButton>
                <telerik:RadButton ID="btnEdit" runat="server" Visible="false" Text="修改" 
                    OnClick="btnEdit_Click">
                </telerik:RadButton>
                <asp:Label ID="lblFormStatus" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
            </div>
            <div style="float: left; width: 100%">
                <div style="float: left; width: 990px" runat="server" id="pnlAddForm" visible="false">
                    <div style="float: left; width: 500px">
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="rblType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblType_SelectedIndexChanged"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">單一</asp:ListItem>
                                        <asp:ListItem Value="1">循環</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="pnlCycle" runat="server" Visible="false">
                                        日期起<telerik:RadDatePicker ID="dpB" runat="server" Culture="zh-TW">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" DisplayText="" LabelWidth="40%"
                                                type="text" value="">
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="rfv_dpB" runat="server" ControlToValidate="dpB" ErrorMessage="*必填"
                                            ForeColor="#FF3300" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        時間起<telerik:RadTimePicker ID="tpB" runat="server" Culture="zh-TW" EnableTyping="False">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                            <TimeView CellSpacing="-1" Columns="6" Culture="zh-TW" Interval="00:30:00" TimeFormat="HH:mm">
                                            </TimeView>
                                            <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                            <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" DisplayText="" LabelWidth="64px"
                                                ReadOnly="True" Width="">
                                            </DateInput>
                                        </telerik:RadTimePicker>
                                        <asp:RequiredFieldValidator ID="rfv_tpB" runat="server" ControlToValidate="tpB" ErrorMessage="*必填"
                                            ForeColor="#FF3300" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        <br />
                                        日期迄<telerik:RadDatePicker ID="dpE" runat="server">
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="rfv_dpE" runat="server" ControlToValidate="dpE" ErrorMessage="*必填"
                                            ForeColor="#FF3300" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        時間迄<telerik:RadTimePicker ID="tpE" runat="server" Culture="zh-TW" EnableTyping="False">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                            <TimeView CellSpacing="-1" Columns="6" Culture="zh-TW" Interval="00:30:00" TimeFormat="HH:mm">
                                            </TimeView>
                                            <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                            <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" DisplayText="" LabelWidth="64px"
                                                ReadOnly="True" Width="">
                                            </DateInput>
                                        </telerik:RadTimePicker>
                                        <asp:RequiredFieldValidator ID="rfv_tpE" runat="server" ControlToValidate="tpE" ErrorMessage="*必填"
                                            ForeColor="#FF3300" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        <br />
                                        循環週期<telerik:RadComboBox ID="cbxCycleType" runat="server" Culture="zh-TW" Width="50px">
                                            <Items>
                                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="周" Value="W" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <telerik:RadComboBox ID="cbxWeekValue" runat="server" CheckBoxes="True" Culture="zh-TW">
                                            <Items>
                                                <telerik:RadComboBoxItem runat="server" Text="周一" Value="1" />
                                                <telerik:RadComboBoxItem runat="server" Text="周二" Value="2" />
                                                <telerik:RadComboBoxItem runat="server" Text="周三" Value="3" />
                                                <telerik:RadComboBoxItem runat="server" Text="周四" Value="4" />
                                                <telerik:RadComboBoxItem runat="server" Text="周五" Value="5" />
                                                <telerik:RadComboBoxItem runat="server" Text="周六" Value="6" />
                                                <telerik:RadComboBoxItem runat="server" Text="周日" Value="0" />
                                            </Items>
                                        </telerik:RadComboBox>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlSingle" runat="server" Visible="true">
                                        <div>
                                            起<telerik:RadDateTimePicker ID="dtpB" runat="server" Culture="zh-TW" Width="200px"
                                                EnableTyping="False" AutoPostBackControl="Calendar" OnSelectedDateChanged="dtpB_SelectedDateChanged"
                                                AutoPostBack="True" Skin="Windows7">
                                                <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm" Columns="6" Interval="00:30:00">
                                                </TimeView>
                                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"
                                                    Skin="Windows7">
                                                </Calendar>
                                                <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                                    LabelWidth="40%" type="text" value="" ReadOnly="True" AutoPostBack="True">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDateTimePicker>
                                            <asp:RequiredFieldValidator ID="fv_dtpB" runat="server" ControlToValidate="dtpB"
                                                ErrorMessage="*必填" ForeColor="#FF3300" ValidationGroup="G0"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            訖<telerik:RadDateTimePicker ID="dtpE" runat="server" Culture="zh-TW" Width="200px"
                                                EnableTyping="False" Skin="Windows7">
                                                <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm" Columns="6" Interval="00:30:00">
                                                </TimeView>
                                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"
                                                    Skin="Windows7">
                                                    <WeekendDayStyle ForeColor="Red" />
                                                </Calendar>
                                                <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                                    LabelWidth="40%" type="text" value="" ReadOnly="True">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDateTimePicker>
                                            <asp:RequiredFieldValidator ID="fv_dtpE" runat="server" ControlToValidate="dtpE"
                                                ErrorMessage="*必填" ForeColor="#FF3300" ValidationGroup="G0"></asp:RequiredFieldValidator>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 60px">
                                    會議主旨
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="tbTopic" runat="server" Rows="3" TextMode="MultiLine" Width="90%">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    會議內容
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="tbContents" runat="server" Rows="3" TextMode="MultiLine"
                                        Width="90%">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnSave" runat="server" Text="存檔" OnClick="btnSave_Click"
                                        ValidationGroup="G0">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: left; width: 480px">
                        <table>
                            <tr>
                                <td style="width: 80px">
                                    &nbsp;郵件通知
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbEmailNotification" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    與會人員
                                </td>
                                <td>
                                    <uc1:SelectEmp3 ID="SelectEmp31" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <telerik:RadScheduler runat="server" ID="RadScheduler1" Width="100%" DayStartTime="00:00:00"
                    DayEndTime="23:59:00" TimeZoneOffset="03:00:00" OnAppointmentDelete="RadScheduler1_AppointmentDelete"
                    DataKeyField="ID" DataSubjectField="Subject" DataStartField="Start" DataEndField="End"
                    DataRecurrenceField="RecurrenceRule" DataRecurrenceParentKeyField="RecurrenceParentId"
                    DataReminderField="Reminder" AllowEdit="False" AllowInsert="False" AppointmentStyleMode="Simple"
                    Height="1500px" OnAppointmentCommand="RadScheduler1_AppointmentCommand" OnFormCreating="RadScheduler1_FormCreating"
                    OnNavigationCommand="RadScheduler1_NavigationCommand" ShowAllDayRow="False" ShowFooter="False"
                    ShowFullTime="True" ShowResourceHeaders="False" Skin="Web20" WorkDayEndTime="23:59:00"
                    WorkDayStartTime="00:00:00" Culture="zh-TW" HoursPanelTimeFormat="HH" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound"
                    RowHeight="20px" EnableDescriptionField="true" OnAppointmentCreated="RadScheduler1_AppointmentCreated"
                    OnNavigationComplete="RadScheduler1_NavigationComplete" OnAppointmentClick="RadScheduler1_AppointmentClick">
                    <AdvancedForm Modal="true"></AdvancedForm>
                    <AppointmentTemplate>
                        <asp:Panel ID="pnlDelCycle" runat="server" Visible="false">
                            <asp:CheckBox ID="cbDelCycle" runat="server" Text="刪除循環? " TextAlign="Left" Visible="true"
                                AutoPostBack="false"></asp:CheckBox>
                        </asp:Panel>
                        <%#Eval("Subject") %>
                    </AppointmentTemplate>
                    <AppointmentContextMenus>
                        <telerik:RadSchedulerContextMenu runat="server" ID="SchedulerAppointmentContextMenu">
                            <Items>
                                <telerik:RadMenuItem Text="刪除" Value="CommandDelete">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadSchedulerContextMenu>
                    </AppointmentContextMenus>
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
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Windows7" />
</asp:Content>
