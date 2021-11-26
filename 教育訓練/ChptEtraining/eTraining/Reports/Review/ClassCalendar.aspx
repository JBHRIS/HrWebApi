<%@ Page Title="教育中心行事曆" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ClassCalendar.aspx.cs" Inherits="eTraining_Reports_Review_ClassCalendar" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../../UC/UC_ClassCalendar.ascx" TagName="UC_ClassCalendar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h2>教育中心行事曆</h2>
    <style>
        
    </style>
    <uc1:UC_ClassCalendar ID="UC_ClassCalendar1" runat="server" />
    <asp:LinkButton ID="lbtn" runat="server">列印</asp:LinkButton>
    <br />
</asp:Content>
