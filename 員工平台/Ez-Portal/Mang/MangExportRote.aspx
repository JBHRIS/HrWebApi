<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MangExportRote.aspx.cs" Inherits="Mang_MangSelectOt" Title="部門班表匯出" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Src="../Utli/DeptUserShift.ascx" TagName="DeptUserShift" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div style="float: left; width: 1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
    </div>
    <uc1:DeptUserShift ID="DeptUserShift1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>