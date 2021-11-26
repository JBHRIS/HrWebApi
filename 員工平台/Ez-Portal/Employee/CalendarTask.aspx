<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CalendarTask.aspx.cs" Inherits="Employee_CalendarTask" Title="Untitled Page" %>

<%@ Register Src="../Utli/CalendarTaskList.ascx" TagName="CalendarTaskList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:CalendarTaskList ID="CalendarTaskList1" runat="server" />
</asp:Content>

