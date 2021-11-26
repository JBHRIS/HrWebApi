<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="RptYearPlan.aspx.cs" Inherits="eTraining_Reports_RptYearPlan" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        月份工作計劃表</h2>
    年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" 
                Owner="cbxYear" />
            <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" 
                Owner="cbxYear" />
        </Items>
    </telerik:RadComboBox>
    &nbsp;&nbsp;
    <telerik:RadButton ID="RadButton1" runat="server" OnClick="RadButton1_Click" Text="確定">
    </telerik:RadButton>
    &nbsp;<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"
        Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="14pt" Width="811px" Height="">
        <LocalReport ReportPath="eTraining\Reports\YearPlan.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
