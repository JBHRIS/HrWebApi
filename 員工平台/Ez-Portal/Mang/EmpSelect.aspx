<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpSelect.aspx.cs" Inherits="Mang_EmpSelect" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="../Employee/EmpTtsInfoByUser.ascx" TagName="EmpTtsInfo" TagPrefix="uc4" %>
<%@ Register Src="../Employee/EmployeeContactPeopleByUser.ascx" TagName="EmployeeContactPeople"
    TagPrefix="uc5" %>
<%@ Register Src="../Employee/EmpFamilyInfoByUser.ascx" TagName="EmpFamilyInfo" TagPrefix="uc6" %>
<%@ Register Src="../Employee/EmpInfoStateByUser.ascx" TagName="EmpInfoState" TagPrefix="uc2" %>
<%@ Register Src="../Utli/DeptTree.ascx" TagName="DeptTree" TagPrefix="uc1" %>
<%@ Register Src="EmpBaseByUser.ascx" TagName="EmpBase" TagPrefix="uc8" %>
<%@ Register Src="EmployeeContactByUser.ascx" TagName="EmployeeContact" TagPrefix="uc9" %>
<%@ Register Src="../Templet/EmployeeSecretarySetting.ascx" TagName="EmployeeSecretarySetting"
    TagPrefix="uc10" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Src="../AbsList.ascx" TagName="AbsList" TagPrefix="uc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:empdeptqs runat="server" ID="ucEmpDeptQS" />
        </div>
  
        <h3>
            <asp:Label ID="lblEmpBase" runat="server" Text="員工基本資料" meta:resourcekey="lblEmpBaseResource1"></asp:Label></h3>
        <table width="100%">
            <tr>
                <td style="width: 50%" valign="top">
                    <uc8:EmpBase ID="EmpBase2" runat="server" Visible="True" />
                </td>
                <td style="width: 50%" valign="top">
                    <uc2:EmpInfoState ID="EmpInfoState1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 50%" valign="top">
                    <uc9:EmployeeContact ID="EmployeeContact2" runat="server" />
                    <uc10:EmployeeSecretarySetting ID="EmployeeSecretarySetting1" runat="server" Visible="False" />
                </td>
                <td style="width: 50%" valign="top">
                    <uc4:EmpTtsInfo ID="EmpTtsInfo1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 50%" valign="top">
                    <uc5:EmployeeContactPeople ID="EmployeeContactPeople1" runat="server" Visible="True" />
                    <br />
                    <uc11:AbsList ID="AbsList1" runat="server" Visible="False" />
                </td>
                <td style="width: 50%" valign="top">
                    <uc6:EmpFamilyInfo ID="EmpFamilyInfo1" runat="server" Visible="False" />
                </td>
            </tr>
        </table>

    <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        SelectCommand="SELECT NOBR, NAME_C,NAME_AD, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
        <SelectParameters>
           <%--  <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />--%>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="HR_Portal_EmpInfo_LeSqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        SelectCommand="SELECT NOBR, NAME_C,NAME_AD, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo_Le WHERE (DEPT = @Dept) ORDER BY INDT">
        <SelectParameters>
           <%--<asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" /> --%> 
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
