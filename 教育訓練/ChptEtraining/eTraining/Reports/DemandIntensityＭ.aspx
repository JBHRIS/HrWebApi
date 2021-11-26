<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="DemandIntensityＭ.aspx.cs" Inherits="eTraining_Reports_DemandIntensityＭ" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>教育訓練需求調查表 主管核定統計分析</h2>
年度
 
    <telerik:RadComboBox ID="RadComboBox1" Runat="server" Width="70px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" />
            <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" />
        </Items>
    </telerik:RadComboBox>
    &nbsp;&nbsp;
    <telerik:RadButton ID="RadButton1" runat="server" onclick="RadButton1_Click" 
        Text="確認">
    </telerik:RadButton>
&nbsp;<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Width="710px">
        <LocalReport ReportPath="eTraining\Reports\DemandIntensityＭ.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>

