<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="MangAward_hr.aspx.cs" Inherits="Mang_MangAward_hr" Title="Untitled Page" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
            <h3>
                <asp:Localize ID="Localize3" runat="server" 
                    meta:resourcekey="Localize3Resource1" Text="員工獎懲資料"></asp:Localize>
            </h3>
            <fieldset>
                <legend>查詢條件</legend>
                <asp:Label ID="Label1" runat="server" Text="獎懲日期：" 
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
                    meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                &nbsp;
                <asp:Label ID="Label2" runat="server" Text="至" 
                    meta:resourcekey="Label2Resource1"></asp:Label>
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
                    ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />&nbsp;<asp:Button
                    ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" Text="匯出Excel" 
                    meta:resourcekey="ExportExcelResource1" />
                <asp:Label ID="lb_nobr" runat="server" Visible="False" 
                    meta:resourcekey="lb_nobrResource1"></asp:Label>
            </fieldset>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                AllowPaging="True" AllowSorting="True" 
            OnPageIndexChanging="GridView2_PageIndexChanging" 
            meta:resourcekey="GridView2Resource1">
                <Columns>
                    <asp:BoundField DataField="nobr" HeaderText="員工編號" 
                        meta:resourcekey="BoundFieldResource1" />
                    <asp:BoundField DataField="name_c" HeaderText="員工姓名" 
                        meta:resourcekey="BoundFieldResource2" />
                    <asp:BoundField DataField="NAME_E" HeaderText="英文名" 
                        meta:resourcekey="BoundFieldResource3" />
                    <asp:BoundField DataField="adate" DataFormatString="{0:d}" HeaderText="獎懲日期" 
                        HtmlEncode="False" meta:resourcekey="BoundFieldResource4" />
                    <asp:BoundField DataField="descr" HeaderText="獎懲原因" 
                        meta:resourcekey="BoundFieldResource5" />
                    <asp:BoundField DataField="award1" HeaderText="大功" 
                        meta:resourcekey="BoundFieldResource6" />
                    <asp:BoundField DataField="award2" HeaderText="小功" 
                        meta:resourcekey="BoundFieldResource7" />
                    <asp:BoundField DataField="award3" HeaderText="嘉獎" 
                        meta:resourcekey="BoundFieldResource8" />
                    <asp:BoundField DataField="award4" HeaderText="獎金" 
                        meta:resourcekey="BoundFieldResource9" />
                    <asp:BoundField DataField="award5" HeaderText="晋級" 
                        meta:resourcekey="BoundFieldResource10" />
                    <asp:BoundField DataField="fault1" HeaderText="大過" 
                        meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="fault2" HeaderText="小過" 
                        meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="fault3" HeaderText="申誡" 
                        meta:resourcekey="BoundFieldResource13" />
                    <asp:BoundField DataField="note" HeaderText="備註" 
                        meta:resourcekey="BoundFieldResource14" />
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">程式說明</span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            1.主管查詢員工獎懲資料！<br />
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
