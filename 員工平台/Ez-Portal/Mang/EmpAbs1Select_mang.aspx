<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAbs1Select_mang.aspx.cs" Inherits="Mang_EmpAbs1Select_mang" Title="公出查詢"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
    <%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Templet/SelectEmp.ascx" TagName="SelectEmp" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
        <asp:Label ID="lblEmpAbs" runat="server" Text="員工公出資料" meta:resourcekey="lblEmpAbsResource1"></asp:Label>
        <fieldset>
            <legend>
                <asp:Label ID="lblSearch" runat="server" Text="查詢條件" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
            <asp:Label ID="Label1" runat="server" Text="查詢日期：" meta:resourcekey="Label1Resource1"></asp:Label>
            <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                <DateInput Skin="" LabelWidth="64px" Width="" DateFormat="MM/dd/yyyy" 
                    DisplayDateFormat="MM/dd/yyyy">
                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
            </telerik:RadDatePicker>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
            <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
            <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                <DateInput Skin="" LabelWidth="64px" Width="" DateFormat="MM/dd/yyyy" 
                    DisplayDateFormat="MM/dd/yyyy">
                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
            </telerik:RadDatePicker>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                meta:resourcekey="Button1Resource2" />
            <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
            <br />
        </fieldset>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            SkinID="Yahoo" OnPageIndexChanging="GridView2_PageIndexChanging" 
            meta:resourcekey="GridView2Resource1" Width="100%">
            <Columns>
                <asp:BoundField DataField="Nobr" HeaderText="NOBR" SortExpression="Nobr" Visible="False"
                    meta:resourcekey="BoundFieldResource11" />
                <asp:BoundField DataField="NameC" HeaderText="員工" SortExpression="NameC" meta:resourcekey="BoundFieldResource12" />
                <asp:BoundField DataField="NameE" HeaderText="英文名字" meta:resourcekey="BoundFieldResource13" />
                <asp:BoundField DataField="JobName" HeaderText="職稱" SortExpression="JobName" meta:resourcekey="BoundFieldResource14" />
                <asp:BoundField DataField="DeptName" HeaderText="部門" SortExpression="DeptName" meta:resourcekey="BoundFieldResource15" />
                <asp:BoundField DataField="AbsDate" DataFormatString="{0:yyyy/MM/dd}" HeaderText="請假日期"
                    HtmlEncode="False" SortExpression="AbsDate" meta:resourcekey="BoundFieldResource16" />
                <asp:BoundField DataField="AbsBtime" HeaderText="開始時間" SortExpression="AbsBtime"
                    meta:resourcekey="BoundFieldResource17" />
                <asp:BoundField DataField="AbsEtime" HeaderText="結束時間" SortExpression="AbsEtime"
                    meta:resourcekey="BoundFieldResource18" />
                <asp:BoundField DataField="H_Code" HeaderText="H_CODE" SortExpression="H_Code" Visible="False"
                    meta:resourcekey="BoundFieldResource19" />
                <asp:BoundField DataField="H_CodeName" HeaderText="假別" SortExpression="H_CodeName"
                    meta:resourcekey="BoundFieldResource20" />
                <asp:BoundField DataField="H_CodeUnit" HeaderText="單位" SortExpression="H_CodeUnit"
                    meta:resourcekey="BoundFieldResource21" />
                <asp:BoundField DataField="TOL_HOURS" HeaderText="請假時數" SortExpression="TOL_HOURS"
                    meta:resourcekey="BoundFieldResource22" />
                <asp:BoundField DataField="Reason" HeaderText="原因" SortExpression="Reason" meta:resourcekey="BoundFieldResource24"
                    Visible="False" />
                <asp:BoundField DataField="NOTE" HeaderText="備註" 
                    meta:resourcekey="BoundFieldResource3" />
                <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" meta:resourcekey="BoundFieldResource25" />
            </Columns>
            <EmptyDataTemplate>
                <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                    meta:resourcekey="lb_emptyResource1"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
        <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
            SelectCommand="SELECT NOBR, NAME_C, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
            <SelectParameters>
                <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    <%--            <asp:Label ID="lblDetail1" runat="server" Text="1.主管查詢員工公出資料！" 
                meta:resourcekey="lblDetail1Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail2" runat="server" Text="2.『部門資料』分三個選項：" 
                meta:resourcekey="lblDetail2Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="lblDetail3" runat="server" Text="-員工：單一查詢每一個員工的相關資料" 
                meta:resourcekey="lblDetail3Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="lblDetail4" runat="server" Text="-部門：查詢所選定的部門，所有員工的相關資料" 
                meta:resourcekey="lblDetail4Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="lblDetail5" runat="server" Text="-含子部門：查詢所選定的部門及子部門，所有員工的相關資料" 
                meta:resourcekey="lblDetail5Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail6" runat="server" 
                Text="3.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！" 
                meta:resourcekey="lblDetail6Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail7" runat="server" 
                Text="4.輸入日期格式為西元年！例 2008/12/31,也可點選欄位『日曆 圖案』可直接點選！" 
                meta:resourcekey="lblDetail7Resource1"></asp:Label><br />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
