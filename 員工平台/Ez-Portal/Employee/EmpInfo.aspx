<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpInfo.aspx.cs" Inherits="Employee_EmpInfo" Title="e-HR" %>
<%@ Register Src="~/calendarabslist.ascx" TagPrefix="uc" TagName="CalendarAbsList" %>

<%@ Register Src="EmpBase.ascx" TagName="EmpBase" TagPrefix="uc7" %>
<%@ Register Src="EmpSchl.ascx" TagName="EmpSchl" TagPrefix="uc6" %>
<%@ Register Src="EmpInfoState.ascx" TagName="EmpInfoState" TagPrefix="uc4" %>
<%@ Register Src="EmpFamilyInfo.ascx" TagName="EmpFamilyInfo" TagPrefix="uc5" %>
<%@ Register Src="EmpTtsInfo.ascx" TagName="EmpTtsInfo" TagPrefix="uc3" %>
<%@ Register Src="EmployeeContactPeople.ascx" TagName="EmployeeContactPeople" TagPrefix="uc2" %>
<%@ Register Src="EmployeeContact.ascx" TagName="EmployeeContact" TagPrefix="uc1" %>
<%@ Register src="../CalendarAbsList.ascx" tagname="CalendarAbsList" tagprefix="uc9" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td style="width: 50%; height: 15px" valign="top">
                <uc7:EmpBase ID="EmpBase1" runat="server" />
            </td>
            <td style="width: 50%; height: 15px" valign="top">
                <uc4:EmpInfoState ID="EmpInfoState1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 50%" valign="top">
                <uc3:EmpTtsInfo ID="EmpTtsInfo1" runat="server" OnLoad="EmpTtsInfo1_Load"></uc3:EmpTtsInfo>
            </td>
            <td style="width: 50%" valign="top">
                <uc1:EmployeeContact ID="EmployeeContact1" runat="server"></uc1:EmployeeContact>
            </td>
        </tr>
        <tr>
            <td style="width: 50%" valign="top">
                <uc5:EmpFamilyInfo ID="EmpFamilyInfo1" runat="server" />
            </td>
            <td style="width: 50%" valign="top">
                <uc2:EmployeeContactPeople ID="EmployeeContactPeople1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 50%" valign="top">
                <uc6:EmpSchl ID="EmpSchl1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
