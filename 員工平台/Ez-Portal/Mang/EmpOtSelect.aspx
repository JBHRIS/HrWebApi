﻿<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpOtSelect.aspx.cs" Inherits="Mang_EmpOtSelect" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:empdeptqs runat="server" ID="ucEmpDeptQS" />
        </div>
            <h3>
                <asp:Label ID="lblEmpOT" runat="server" Text="員工加班資料" meta:resourcekey="lblEmpOTResource1"></asp:Label>
            </h3>
            <fieldset>
                <legend>
                    <asp:Label ID="lblSearch" runat="server" Text="查詢條件" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                <asp:Label ID="Label1" runat="server" Text="加班日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" meta:resourcekey="adateResource1"
                    Skin="Transparent">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Transparent"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>&nbsp;
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" meta:resourcekey="ddateResource1"
                    Skin="Transparent">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Transparent"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                    meta:resourcekey="Button1Resource2" />&nbsp;
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="匯出" meta:resourcekey="Button2Resource1" />
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label></fieldset>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                SkinID="Yahoo" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound"
                meta:resourcekey="GridView2Resource1" Width="100%">
                <Columns>
                    <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" Visible="False"
                        meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="NAME_C" HeaderText="員工" SortExpression="NAME_C" meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="NAME_E" HeaderText="英文名" meta:resourcekey="BoundFieldResource13" />
                    <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" SortExpression="JOB_NAME" meta:resourcekey="BoundFieldResource14" />
                    <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" Visible="False"
                        meta:resourcekey="BoundFieldResource15" />
                    <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="加班日期"
                        HtmlEncode="False" SortExpression="BDATE" meta:resourcekey="BoundFieldResource16" />
                    <asp:BoundField DataField="BTIME" HeaderText="開始時間" SortExpression="BTIME" meta:resourcekey="BoundFieldResource17" />
                    <asp:BoundField DataField="ETIME" HeaderText="結束時間" SortExpression="ETIME" meta:resourcekey="BoundFieldResource18" />
                    <asp:BoundField DataField="TOT_HOURS" HeaderText="總時數" SortExpression="TOT_HOURS"
                        meta:resourcekey="BoundFieldResource19" />
                    <asp:BoundField DataField="OT_HRS" HeaderText="加班時數" SortExpression="OT_HRS" meta:resourcekey="BoundFieldResource20" />
                    <asp:BoundField DataField="REST_HRS" HeaderText="補休時數" SortExpression="REST_HRS"
                        meta:resourcekey="BoundFieldResource21" />
                    <asp:BoundField DataField="OTRNAME" HeaderText="加班原因" SortExpression="OTRNAME" meta:resourcekey="BoundFieldResource22" />
                    <asp:BoundField DataField="NOTE" HeaderText="備註" SortExpression="NOTE" meta:resourcekey="BoundFieldResource23" />
                    <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" meta:resourcekey="BoundFieldResource24" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                        meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
            <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT NOBR, NAME_C,NAME_AD, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--
    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
                <asp:Label ID="Label3" runat="server" Text="程式說明" meta:resourcekey="Label3Resource1"></asp:Label></span>
            <span class="SHRight"></span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:Label ID="lblDetail1" runat="server" Text="1.主管查詢員工加班資料！" meta:resourcekey="lblDetail1Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail2" runat="server" Text="2.『部門資料』分三個選項：" meta:resourcekey="lblDetail2Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="lblDetail3" runat="server" Text="-員工：單一查詢每一個員工的相關資料" meta:resourcekey="lblDetail3Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="lblDetail4" runat="server" Text="-部門：查詢所選定的部門，所有員工的相關資料" meta:resourcekey="lblDetail4Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="lblDetail5" runat="server" Text="-含子部門：查詢所選定的部門及子部門，所有員工的相關資料" meta:resourcekey="lblDetail5Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail6" runat="server" Text="3.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！"
                meta:resourcekey="lblDetail6Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail7" runat="server" Text="4.輸入日期格式為西元年！例 2008/12/31&nbsp; ,也可點選欄位『日曆 圖案』可直接點選！"
                meta:resourcekey="lblDetail7Resource1"></asp:Label><br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
