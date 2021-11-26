<%@ Page Title="矯正措施通知單開立類別" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ErrorCate.aspx.cs" Inherits="eTraining_Reports_Review_ErrorCate" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        矯正措施通知單開立類別</h2>
        <%--<div style="vertical-align:top">aa</div>--%>
    <div class="field" >
        <fieldset style="background-color: #EEF5FC; width: 400px">
            <legend>篩選條件</legend>日期區間<telerik:RadDatePicker ID="dpA" runat="server" Skin="Office2007">
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                    Skin="Office2007">
                </Calendar>
                <DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            ~<telerik:RadDatePicker ID="dpD" runat="server" Skin="Office2007">
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                    Skin="Office2007">
                </Calendar>
                <DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            <br />
            <br />
            &nbsp;
            <telerik:RadButton ID="btnCheck" runat="server" Text="確定" OnClick="btnCheck_Click">
            </telerik:RadButton>
        </fieldset>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Visible="False" Font-Names="Verdana"
        Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="eTraining\Reports\Review\ErrorCate.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
