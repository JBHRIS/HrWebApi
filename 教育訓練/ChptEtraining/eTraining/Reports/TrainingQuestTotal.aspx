<%@ Page Title="需求調查統計總表" Language="C#" MasterPageFile="~/mpTraining.master"
    AutoEventWireup="true" CodeFile="TrainingQuestTotal.aspx.cs" Inherits="eTraining_Reports_TrainingQuestTotal" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        教育訓練需求調查統計總表</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 300px">
            <legend>篩選條件</legend>年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" />
                    <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" />
                </Items>
            </telerik:RadComboBox>
            &nbsp;&nbsp; &nbsp;<br />
            <br />
            職等<telerik:RadComboBox ID="cbxJoblB" runat="server" Width="50px">
            </telerik:RadComboBox>
            &nbsp;到
            <telerik:RadComboBox ID="cbxJoblE" runat="server" Width="50px">
            </telerik:RadComboBox>
            <br />
            <br />
            部門<br />
            <telerik:RadTreeView ID="tvDept" runat="server" CheckBoxes="True" CheckChildNodes="True">
            </telerik:RadTreeView>
            <br />
            <telerik:RadButton ID="RadButton1" runat="server" Text="確定" 
                OnClick="RadButton1_Click" Skin="Office2007">
            </telerik:RadButton>
            <br />
        </fieldset>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Font-Names="Verdana"
        Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="14pt" Height="800px">
        <LocalReport ReportPath="eTraining\Reports\TrainingQuestTotal.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
