<%@ Page Title="職能積分檢討" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="JobScoreGoal.aspx.cs" Inherits="eTraining_Reports_Review_JobScoreGoal" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        職能積分檢討</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 300px">
            <legend>篩選條件</legend>年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="80px"
                AutoPostBack="True">
            </telerik:RadComboBox>
            <br />
            <br />
            職能積分卡<telerik:RadComboBox ID="cbxOjt" runat="server" DataSourceID="sdscbx" DataTextField="sName"
                DataValueField="sCode" AutoPostBack="True">
            </telerik:RadComboBox>
            <asp:SqlDataSource ID="sdscbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT [sCode], [sName] FROM [trOJTTemplate]"></asp:SqlDataSource>
            <br />
            <br />
            &nbsp;<telerik:RadButton ID="btnCheck" runat="server" Text="確定" 
                onclick="btnCheck_Click">
            </telerik:RadButton>
        </fieldset>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Visible="False" 
        Width="100%" Font-Names="Verdana" Font-Size="8pt" 
        InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="eTraining\Reports\Review\JobScoreGoal.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
