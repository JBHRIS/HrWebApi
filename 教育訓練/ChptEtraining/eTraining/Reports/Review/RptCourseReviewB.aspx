<%@ Page Title="專業課程檢討" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="RptCourseReviewB.aspx.cs" Inherits="eTraining_Reports_Review_RptCourseReviewB" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        專業課程檢討</h2>
    年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
    </telerik:RadComboBox>
    <br />
    <br />
    <telerik:RadButton ID="btnCheck" runat="server" Text="確定" 
        onclick="btnCheck_Click">
    </telerik:RadButton>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Visible="False" 
    Font-Names="Verdana" Font-Size="8pt" Height="600px" 
    InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
    WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="eTraining\Reports\Review\RptCourseReviewB.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
