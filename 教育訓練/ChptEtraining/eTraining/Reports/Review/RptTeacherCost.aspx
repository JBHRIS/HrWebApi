<%@ Page Title="內部講師費發放明細表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="RptTeacherCost.aspx.cs" Inherits="eTraining_Reports_Review_RptTeacherCost" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        內部講師費發放明細表</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 400px">
            <legend>篩選條件</legend>年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
            </telerik:RadComboBox>
             
            <br />
            <br />
            日期區間<telerik:RadDatePicker ID="dpA" Runat="server" Skin="Office2007">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                    ViewSelectorText="x" Skin="Office2007"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            ~<telerik:RadDatePicker ID="dpD" Runat="server" Skin="Office2007">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                    ViewSelectorText="x" Skin="Office2007"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            <br />
            <br />
            講師<telerik:RadComboBox ID="cbxTeacher" runat="server" CheckBoxes="True" DataSourceID="sdsTeacher"
                DataTextField="sName" DataValueField="sCode" EnableCheckAllItemsCheckBox="True" 
                >
            </telerik:RadComboBox>
            <asp:SqlDataSource ID="sdsTeacher" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select sCode,sName from trTeacher
where bEntTeacherType=1
"></asp:SqlDataSource>
            &nbsp;
            <telerik:RadButton ID="btnCheck" runat="server" Text="確定" 
                onclick="btnCheck_Click">
            </telerik:RadButton>
        </fieldset>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="600px" InteractiveDeviceInfos="(集合)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" 
        Visible="False">
        <LocalReport ReportPath="eTraining\Reports\Review\RptTeacherCost.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
    <br />

</asp:Content>
