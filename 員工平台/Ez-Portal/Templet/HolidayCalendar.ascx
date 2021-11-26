<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HolidayCalendar.ascx.cs"
    Inherits="Templet_HolidayCalendar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="arrangeBlock">
    <h3 class="arrangeBlockTitle">
        <asp:Localize ID="locCal" runat="server" meta:resourcekey="locCalResource1" Text="Calendar"></asp:Localize></h3>
    <telerik:RadCalendar ID="cld" runat="server" AutoPostBack="True" CultureInfo=""
        EnableMultiSelect="False" OnDayRender="cld_DayRender" OnPreRender="cld_PreRender"
        SelectedDate="" ShowRowHeaders="False" Skin="Windows7" UseColumnHeadersAsSelectors="False"
        UseRowHeadersAsSelectors="False" ViewSelectorText="x" 
        meta:resourcekey="cldResource1" Width="100%">
        <WeekendDayStyle CssClass="rcWeekend"></WeekendDayStyle>
        <CalendarTableStyle CssClass="rcMainTable"></CalendarTableStyle>
        <OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle>
        <OutOfRangeDayStyle CssClass="rcOutOfRange"></OutOfRangeDayStyle>
        <DisabledDayStyle CssClass="rcDisabled"></DisabledDayStyle>
        <SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle>
        <DayOverStyle CssClass="rcHover"></DayOverStyle>
        <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Windows7">
        </FastNavigationStyle>
        <ViewSelectorStyle CssClass="rcViewSel"></ViewSelectorStyle>
    </telerik:RadCalendar>
</div>
