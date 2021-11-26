<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="TrainingQuest.aspx.cs" Inherits="eTraining_Reports_TrainingQuest" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>教育訓練需求調查表</h2>
年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" 
                Owner="cbxYear" />
        </Items>
    </telerik:RadComboBox>
    &nbsp;&nbsp;&nbsp;
    <telerik:RadButton ID="RadButton1" runat="server" onclick="RadButton1_Click" 
        Text="確定">
    </telerik:RadButton>
&nbsp;<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Width="812px" Height="1200px" Visible="False">
        <LocalReport ReportPath="eTraining\Reports\TrainingQuest.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
    </asp:Content>

