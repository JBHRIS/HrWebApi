<%@ Page Title="課表所附檢討報告" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="CoursePS.aspx.cs" Inherits="eTraining_Reports_Do_CoursePS" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        課表所附檢討報告</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 400px">
            <legend>篩選條件</legend>年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
            </telerik:RadComboBox>
            <br />
            <br />
            <telerik:RadComboBox ID="cbxMonth" runat="server" Width="50px" Visible="False">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="1" Value="1" />
                    <telerik:RadComboBoxItem runat="server" Text="2" Value="2" />
                    <telerik:RadComboBoxItem runat="server" Text="3" Value="3" />
                    <telerik:RadComboBoxItem runat="server" Text="4" Value="4" />
                    <telerik:RadComboBoxItem runat="server" Text="5" Value="5" />
                    <telerik:RadComboBoxItem runat="server" Text="6" Value="6" />
                    <telerik:RadComboBoxItem runat="server" Text="7" Value="7" />
                    <telerik:RadComboBoxItem runat="server" Text="8" Value="8" />
                    <telerik:RadComboBoxItem runat="server" Text="9" Value="9" />
                    <telerik:RadComboBoxItem runat="server" Text="10" Value="10" />
                    <telerik:RadComboBoxItem runat="server" Text="11" Value="11" />
                    <telerik:RadComboBoxItem runat="server" Text="12" Value="12" />
                </Items>
            </telerik:RadComboBox>
            <br />
            日期區間<telerik:RadDatePicker ID="dpStart" runat="server" Skin="Outlook">
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                    Skin="Outlook">
                </Calendar>
                <DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>~<telerik:RadDatePicker ID="dpEnd" runat="server" 
                Skin="Outlook">
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                    Skin="Outlook">
                </Calendar>
                <DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker><br />
            <br />
            &nbsp;
            <telerik:RadButton ID="btnCheck" runat="server" Text="確定" 
                onclick="btnCheck_Click">
            </telerik:RadButton>
        </fieldset>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Height="600px" Visible="False" Width="100%">
        <LocalReport ReportPath="eTraining\Reports\Do\CoursePS.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
