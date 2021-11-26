<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmpApplyFormSelect.aspx.cs" Inherits="Mang_EmpApplyFormSelect" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div style="float:left;width:1000px">
        <uc:empdeptqs runat="server" ID="ucEmpDeptQS" />
        </div>
            <h3>
                <asp:Label ID="lblShowEmpLeaveHeader" runat="server" Text="員工假單資料" 
                    meta:resourcekey="lblShowEmpLeaveHeaderResource1"></asp:Label>
            </h3>
            <fieldset>
                <legend>
                    <asp:Label ID="lblShowQueryHeader" runat="server" Text="查詢條件" meta:resourcekey="lblShowQueryHeaderResource1"></asp:Label></legend>
                <asp:Label ID="lblAbsDate" runat="server" Text="請假日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                <telerik:RadDatePicker ID="adate" runat="server" 
                    meta:resourcekey="adateResource1" Culture="(Default)">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" DisplayText="" LabelWidth="64px" 
                        Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" 
                    meta:resourcekey="ddateResource1" Culture="(Default)">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" DisplayText="" LabelWidth="64px" 
                        Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblCat" runat="server" Text="查詢類別：" meta:resourcekey="Label1Resource1"></asp:Label>
                <asp:DropDownList ID="ddlCat" runat="server" meta:resourcekey="ddlCatResource1">
                    <asp:ListItem Selected="True" Value="0" meta:resourcekey="ListItemResource1">全部</asp:ListItem>
                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">請假</asp:ListItem>
                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">公出</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                    meta:resourcekey="Button1Resource2" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="匯出" meta:resourcekey="Button2Resource1" />
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
            </fieldset>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                SkinID="Yahoo" OnPageIndexChanging="GridView2_PageIndexChanging" meta:resourcekey="GridView2Resource1"
                OnRowDataBound="GridView2_RowDataBound" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Nobr" HeaderText="sNobr" SortExpression="Nobr" Visible="False"
                        meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="NameC" HeaderText="員工" SortExpression="NameC" meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="NameE" HeaderText="英文名" meta:resourcekey="BoundFieldResource25" />
                    <asp:BoundField DataField="DateB" DataFormatString="{0:yyyy/MM/dd}" HeaderText="請假起始日期"
                        SortExpression="dDateB" meta:resourcekey="BoundFieldResource15" />
                    <asp:BoundField DataField="DateE" HeaderText="請假結束日期" 
                        DataFormatString="{0:yyyy/MM/dd}" meta:resourcekey="BoundFieldResource3" />
                    <asp:BoundField DataField="TimeB" HeaderText="開始時間" SortExpression="TimeB" meta:resourcekey="BoundFieldResource16" />
                    <asp:BoundField DataField="TimeE" HeaderText="結束時間" SortExpression="TimeE" meta:resourcekey="BoundFieldResource17" />
                    <asp:BoundField DataField="Hcode" HeaderText="sHcode" SortExpression="Hcode" Visible="False"
                        meta:resourcekey="BoundFieldResource18" />
                    <asp:BoundField DataField="HcodeName" HeaderText="假別" SortExpression="HcodeName"
                        meta:resourcekey="BoundFieldResource19" />
                    <asp:BoundField DataField="Unit" HeaderText="單位" SortExpression="Unit" meta:resourcekey="BoundFieldResource20" />
                    <asp:BoundField DataField="TotalHour" HeaderText="請假小計" SortExpression="TotalHour"
                        meta:resourcekey="BoundFieldResource21" />
                    <asp:BoundField DataField="TotalDay" HeaderText="請假天數" SortExpression="TotalDay"
                        meta:resourcekey="BoundFieldResource22" Visible="False" />
                    <asp:BoundField DataField="Note" HeaderText="備註" SortExpression="Note" meta:resourcekey="BoundFieldResource23" />
                    <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" meta:resourcekey="BoundFieldResource24" />
                    <asp:BoundField DataField="State" HeaderText="狀態" SortExpression="State" 
                        meta:resourcekey="BoundFieldResource4" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Text="＊無相關資料！！"
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--
    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
                <asp:Label ID="lblNote" runat="server" Text="程式說明" 
                meta:resourcekey="lblNoteResource1"></asp:Label></span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:Label ID="Label1" runat="server" Text="1.主管查詢員工請假資料！" 
                meta:resourcekey="Label1Resource2"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="2.『部門資料』分三個選項：" 
                meta:resourcekey="Label3Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="Label4" runat="server" Text="-員工：單一查詢每一個員工的相關資料" 
                meta:resourcekey="Label4Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="Label5" runat="server" Text="-部門：查詢所選定的部門，所有員工的相關資料" 
                meta:resourcekey="Label5Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="Label6" runat="server" Text="-含子部門：查詢所選定的部門及子部門，所有員工的相關資料" 
                meta:resourcekey="Label6Resource1"></asp:Label><br />
            <asp:Label ID="Label7" runat="server" 
                Text="3.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！" 
                meta:resourcekey="Label7Resource1"></asp:Label><br />
            <asp:Label ID="Label8" runat="server" 
                Text="4.輸入日期格式為西元年！例 2008/12/31 ,也可點選欄位『日曆 圖案』可直接點選！" 
                meta:resourcekey="Label8Resource1"></asp:Label><br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
