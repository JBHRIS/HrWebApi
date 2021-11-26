<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpSelect_hr.aspx.cs" Inherits="Mang_EmpSelect_hr" Title="Untitled Page" %>

<%@ Register Src="../../Employee/EmpBase.ascx" TagName="EmpBase" TagPrefix="uc7" %>
<%@ Register Src="../../Employee/EmpTtsInfo.ascx" TagName="EmpTtsInfo" TagPrefix="uc4" %>
<%@ Register Src="../../Employee/EmployeeContactPeople.ascx" TagName="EmployeeContactPeople"
    TagPrefix="uc5" %>
    <%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Src="../../Employee/EmpFamilyInfo.ascx" TagName="EmpFamilyInfo" TagPrefix="uc6" %>
<%@ Register Src="../../Employee/EmpInfoState.ascx" TagName="EmpInfoState" TagPrefix="uc2" %>
<%@ Register Src="../../Employee/EmployeeContact.ascx" TagName="EmployeeContact"
    TagPrefix="uc3" %>
<%@ Register Src="../../Utli/DeptTree.ascx" TagName="DeptTree" TagPrefix="uc1" %>
<%@ Register Src="../../Templet/EmployeeSecretarySetting.ascx" TagName="EmployeeSecretarySetting"
    TagPrefix="uc8" %>
<%@ Register Src="../../AbsList.ascx" TagName="AbsList" TagPrefix="uc9" %>
<%@ Register Src="../../Templet/SelectEmp.ascx" TagName="SelectEmp" TagPrefix="uc10" %>
<%@ Register Src="../../Templet/SelectEmpHr.ascx" TagName="SelectEmpHr" TagPrefix="uc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>

<asp:Button ID="btnExcelSecretary" runat="server" Text="匯出助理Excel" OnClick="btnExcelSecretary_Click" />
    
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
            <table width="100%">
                <tr>
                    <td valign="top">
                        <h3>
                            <asp:Localize ID="Localize2" runat="server">員工基本資料</asp:Localize>
                        </h3>
                        <table width="100%">
                            <tr>
                                <td style="width: 50%" valign="top">
                                    <uc7:EmpBase ID="EmpBase1" runat="server" />
                                </td>
                                <td style="width: 50%" valign="top">
                                    <uc2:EmpInfoState ID="EmpInfoState1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" valign="top">
                                    <uc3:EmployeeContact ID="EmployeeContact1" runat="server" />
                                </td>
                                <td style="width: 50%" valign="top">
                                    <uc4:EmpTtsInfo ID="EmpTtsInfo1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" valign="top">
                                    <uc5:EmployeeContactPeople ID="EmployeeContactPeople1" runat="server" />
                                    <uc8:EmployeeSecretarySetting ID="EmployeeSecretarySetting1" runat="server" />
                                    <br />
                                    <uc9:AbsList ID="AbsList1" runat="server" />
                                </td>
                                <td style="width: 50%" valign="top">
                                    <uc6:EmpFamilyInfo ID="EmpFamilyInfo1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lb_dept" runat="server" Visible="False"></asp:Label>
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
