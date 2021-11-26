<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAttendSelect_hr.aspx.cs" Inherits="Mang_EmpAttendSelect_hr" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
  <%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Src="../../Account/AccountPictureBind.ascx" TagName="AccountPictureBind" TagPrefix="uc1" %>
<%@ Register Src="../../Attendance/RoteList.ascx" TagName="RoteList" TagPrefix="uc2" %>
<%@ Register Src="../../Templet/SelectEmp.ascx" TagName="SelectEmp" TagPrefix="uc3" %>
<%@ Register Src="../../Templet/SelectEmpHr.ascx" TagName="SelectEmpHr" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div style="float:left;width:1000px">
        <uc:empdeptqs runat="server" ID="ucEmpDeptQS" />
        </div>


            <uc2:RoteList ID="RoteList1" runat="server" />
            <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
            <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT NOBR, NAME_C, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="HR_Portal_EmpInfo_LeSqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT NOBR, NAME_C, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo_Le WHERE (DEPT = @Dept) ORDER BY INDT">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsEmpInfo_QuickSearch" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                ProviderName="<%$ ConnectionStrings:HRSqlServer.ProviderName %>"></asp:SqlDataSource>

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
