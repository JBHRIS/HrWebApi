<%@ Page Title="年度教育訓練目標" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="TrainingGoal.aspx.cs" Inherits="eTraining_Reports_Review_TrainingGoal" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>年度教育訓練目標</h2>
年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
    </telerik:RadComboBox>
    <br />
    <br />
    <telerik:RadButton ID="btnCheck" runat="server" onclick="btnCheck_Click" 
        Skin="Windows7" Text="確定">
    </telerik:RadButton>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Width="100%" Visible="False" Height="600px">
        <LocalReport ReportPath="eTraining\Reports\Review\TrainingGoal.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>

