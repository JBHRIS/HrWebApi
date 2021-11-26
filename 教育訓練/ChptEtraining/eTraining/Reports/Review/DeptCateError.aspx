<%@ Page Title="各部門開立矯正措施通知單件數" Language="C#" MasterPageFile="~/mpTraining.master"
    AutoEventWireup="true" CodeFile="DeptCateError.aspx.cs" Inherits="eTraining_Reports_Review_DeptCateError" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        各部門開立矯正措施通知單件數</h2>
    <div class="field">
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
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Visible="False"
        Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="eTraining\Reports\Review\DeptCateError.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
    <%--<div style="line-height: 40px">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>test1</asp:ListItem>
            <asp:ListItem>test2</asp:ListItem>
            <asp:ListItem>test3</asp:ListItem>
        </asp:RadioButtonList>
    </div>--%>
</asp:Content>
