<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true" CodeFile="MangAbsOtList_hr.aspx.cs" Inherits="Mang_MangAbsOtList_hr" Title="加班請假行事曆" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="HR_CalendarAbsList.ascx" TagName="HR_CalendarAbsList" TagPrefix="uc2" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:HR_CalendarAbsList ID="CalendarAbsList1" runat="server" />
</asp:Content>

