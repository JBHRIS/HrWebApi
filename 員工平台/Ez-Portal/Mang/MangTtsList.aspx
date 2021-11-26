<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MangTtsList.aspx.cs" Inherits="Mang_MangTtsList" Title="員工到離職行事曆 "
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Src="../calendarList.ascx" TagName="calendarList" TagPrefix="uc1" %>
<%@ Register Src="../Templet/calendarListCustomDept.ascx" TagName="calendarListCustomDept"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>

        <uc2:calendarListCustomDept ID="calendarListCustomDept1" runat="server" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
