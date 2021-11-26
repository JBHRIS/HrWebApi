<%@ Page Title="課程績效統計表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="RptPerformance.aspx.cs" Inherits="eTraining_Reports_Review_RptPerformance" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        課程績效統計表</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 400px">
            <legend>篩選條件</legend><telerik:RadComboBox ID="cbxYear" runat="server" 
                Width="70px" Visible="False">
            </telerik:RadComboBox>
            <br />
            日期區間<telerik:RadDatePicker ID="dpA" runat="server" Skin="Vista">
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                    Skin="Vista">
                </Calendar>
                <DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            ~<telerik:RadDatePicker ID="dpD" runat="server" Skin="Vista">
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                    Skin="Vista">
                </Calendar>
                <DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            <br />
            <br />
            &nbsp;
            <telerik:RadButton ID="btnCheck" runat="server" Text="確定" Skin="Office2007" OnClick="btnCheck_Click">
            </telerik:RadButton>
        </fieldset>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Height="800px" Width="100%" Visible="False">
        <LocalReport ReportPath="eTraining\Reports\Review\RptPerformance.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
