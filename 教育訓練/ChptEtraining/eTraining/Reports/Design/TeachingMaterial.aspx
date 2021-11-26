<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="TeachingMaterial.aspx.cs" Inherits="eTraining_Reports_Design_TeachingMaterial" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>單元教學教案</h2>
    <br />
    <telerik:RadButton ID="btnGoBack" runat="server" onclick="btnGoBack_Click" 
        Text="回上頁">
    </telerik:RadButton>
    <asp:SqlDataSource ID="sdsGv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select TM.iAutoKey,co.sName from trTeachingMaterial TM

join trCourse co on TM.trCourse_sCode=co.sCode"></asp:SqlDataSource>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
        Height="700px">
    </rsweb:ReportViewer>
</asp:Content>

