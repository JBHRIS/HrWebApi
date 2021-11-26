<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SelectBak.aspx.cs" Inherits="Attendance_SelectBak" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <fieldset><legend>備勤行事曆</legend>
    <asp:Calendar ID="Calendar2" runat="server" BorderColor="#C1CDD8" BorderWidth="0px"
        CellPadding="0" CssClass="offWhtBg" NextMonthText='&gt;'
        OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
        OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" PrevMonthText='&lt;'
        SelectWeekText=">>" ShowGridLines="True" Width="100%">
        <DayStyle BorderWidth="1px" Font-Bold="True" Font-Size="18px" ForeColor="#0000C0"
            Height="70px" HorizontalAlign="Right" VerticalAlign="Top" Width="10%" />
        <DayHeaderStyle BorderWidth="1px" CssClass="titlelistTD" />
        <SelectedDayStyle BackColor="#FFFAE0" ForeColor="Black" />
        <TitleStyle BackColor="White" BorderColor="#C1CDD8" BorderStyle="None" BorderWidth="1px"
            Font-Size="17pt" ForeColor="Black" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
        <OtherMonthDayStyle CssClass="notCurMonDate" Font-Size="10pt" />
        
    </asp:Calendar>
    </fieldset>
</asp:Content>

