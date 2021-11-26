<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ClassCalendar.ascx.cs" Inherits="UC_UC_ClassCalendar" %>
    <asp:Calendar ID="Calendar1" runat="server" FirstDayOfWeek="Monday" 
        Height="100%" ondayrender="Calendar1_DayRender" ShowGridLines="True" 
        Width="100%" onload="Calendar1_Load" 
        onvisiblemonthchanged="Calendar1_VisibleMonthChanged" 
        BorderColor="#C1CDD8" CssClass="offWhtBg" CellPadding="1" 
    onselectionchanged="Calendar1_SelectionChanged">
        <DayHeaderStyle BorderWidth="1px" CssClass="titlelistTD" />
        <DayStyle BorderColor="#0000C0" BorderWidth="1px" Height="20px" 
            HorizontalAlign="Right" VerticalAlign="Top" Font-Size="14px" />
        <OtherMonthDayStyle CssClass="notCurMonDate" Font-Size="10px" />
    </asp:Calendar>
    <p>
    <telerik:RadButton ID="RadButton1" runat="server" onclick="RadButton1_Click" 
        Text="Excel" Visible="False">
    </telerik:RadButton>

        <asp:Label ID="lblDate" runat="server" Visible="False"></asp:Label>

    </p>

