<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAttendSelect_ma.aspx.cs" Inherits="Mang_EmpAttendSelect_ma" Title="外勞出勤資料查詢" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
            <h3>
                <asp:Localize ID="Localize1" runat="server" 
                    meta:resourcekey="Localize1Resource1" Text="員工出勤資料"></asp:Localize>
                <asp:Calendar ID="Calendar2" runat="server" 
                    meta:resourcekey="Calendar2Resource1" SkinID="Chpt"></asp:Calendar>
            </h3>
            <fieldset>
                <legend>查詢條件</legend>
                <asp:Label ID="Label1" runat="server" Text="出勤日期：" 
                    meta:resourcekey="Label1Resource1"></asp:Label>
                <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                    meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="至" 
                    meta:resourcekey="Label2Resource1"></asp:Label>&nbsp;
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                    meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                    ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />&nbsp;
                <asp:Label ID="lb_nobr" runat="server" Visible="False" 
                    meta:resourcekey="lb_nobrResource1"></asp:Label></fieldset>
            <asp:Calendar ID="Calendar1" runat="server" BorderColor="#C1CDD8" BorderWidth="0px"
                CellPadding="0" CssClass="offWhtBg"
                OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
                OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" ShowGridLines="True" 
                Width="90%" meta:resourcekey="Calendar1Resource1" SkinID="Chpt">
                <DayStyle BorderWidth="1px" Font-Bold="True" Font-Size="18px" ForeColor="#0000C0"
                    Height="70px" HorizontalAlign="Right" VerticalAlign="Top" Width="10%" />
                <DayHeaderStyle BorderWidth="1px" CssClass="titlelistTD" />
                <SelectedDayStyle BackColor="#FFFAE0" ForeColor="Black" />
                <TitleStyle BackColor="White" BorderColor="#C1CDD8" BorderStyle="None" BorderWidth="1px"
                    Font-Size="17pt" ForeColor="Black" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <OtherMonthDayStyle CssClass="notCurMonDate" Font-Size="10pt" />
            </asp:Calendar>
            <%-- OnPageIndexChanging="GridView2_PageIndexChanging"--%>>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                SkinID="Yahoo" meta:resourcekey="GridView2Resource1" Width="100%" >
                <Columns>
                    <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" 
                        Visible="False" meta:resourcekey="BoundFieldResource1" />
                    <asp:BoundField DataField="NAME_C" HeaderText="員工" SortExpression="NAME_C" 
                        meta:resourcekey="BoundFieldResource2" />
                    <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" SortExpression="JOB_NAME" 
                        meta:resourcekey="BoundFieldResource3" />
                    <asp:BoundField DataField="ADATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="出勤日期"
                        HtmlEncode="False" SortExpression="ADATE" 
                        meta:resourcekey="BoundFieldResource4" />
                    <asp:BoundField DataField="ROTE" HeaderText="班別" SortExpression="ROTE" 
                        meta:resourcekey="BoundFieldResource5" />
                    <asp:BoundField DataField="ROTENAME" HeaderText="班別名稱" 
                        SortExpression="ROTENAME" meta:resourcekey="BoundFieldResource6" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                        Text="＊無相關資料！！" meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:Label ID="lb_dept" runat="server" Visible="False" 
            meta:resourcekey="lb_deptResource1"></asp:Label>
            <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT NOBR, NAME_C, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">程式說明</span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            1.主管查詢員工出勤資料！<br />
            2.『部門資料』分三個選項：<br />
            &nbsp; &nbsp; -員工：單一查詢每一個員工的相關資料<br />
            &nbsp; &nbsp; -部門：查詢所選定的部門，所有員工的相關資料<br />
            &nbsp; &nbsp; -含子部門：查詢所選定的部門及子部門，所有員工的相關資料<br />
            3.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！<br />
            4.輸入日期格式為西元年！例 2008/12/31&nbsp; ,也可點選欄位『日曆 圖案』可直接點選！<br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
