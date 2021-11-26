<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payslip.aspx.cs" Inherits="SalaryWeb.Payslip" MasterPageFile="~/SalaryShowMaster.Master"
    EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>--%>
        
        <asp:Content ID="ContentPlaceHolderabc" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblYear" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblMonth" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSeq" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblLang" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

            <rsweb:ReportViewer ID="RptViewer" runat="server" ClientIDMode="Static"
                Height="1200px" Width="863px" ShowPrintButton="False" AsyncRendering="False" InteractivityPostBackMode="AlwaysSynchronous" KeepSessionAlive="False" ShowToolBar="False" ShowBackButton="False" ShowExportControls="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowRefreshButton="False" ShowZoomControl="False">
            </rsweb:ReportViewer>
        </asp:Content>

<%--</form>
</body>
</html>--%>
