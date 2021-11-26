<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true" CodeFile="MangTtsList_hr.aspx.cs" Inherits="Mang_MangTtsList_hr" Title="員工到離職行事曆 " culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="HR_CalendarList.ascx" TagName="calendarList" TagPrefix="uc2" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:calendarList ID="CalendarList1" runat="server" />
</asp:Content>

