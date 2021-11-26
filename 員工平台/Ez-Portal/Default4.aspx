<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="_Default4" EnableEventValidation="false" Title="e-HR" %>

<%@ Register Src="Flow/FlowCheck.ascx" TagName="FlowCheck" TagPrefix="uc13" %>

<%@ Register Src="Utli/OnlineList.ascx" TagName="OnlineList" TagPrefix="uc11" %>
<%@ Register Src="Utli/UserRecord.ascx" TagName="UserRecord" TagPrefix="uc12" %>

<%@ Register Src="CalendarAbsList.ascx" TagName="CalendarAbsList" TagPrefix="uc10" %>

<%@ Register Src="calendarList.ascx" TagName="calendarList" TagPrefix="uc9" %>

<%@ Register Src="AbsList.ascx" TagName="AbsList" TagPrefix="uc7" %>
<%@ Register Src="FamilyList.ascx" TagName="FamilyList" TagPrefix="uc8" %>

<%@ Register Src="Templet/BirthdayControl.ascx" TagName="BirthdayControl" TagPrefix="uc5" %>
<%@ Register Src="Templet/NoviceControl.ascx" TagName="NoviceControl" TagPrefix="uc6" %>

<%@ Register Src="Templet/TRContral.ascx" TagName="TRContral" TagPrefix="uc3" %>
<%@ Register Src="Templet/AbsDayControl.ascx" TagName="AbsDayControl" TagPrefix="uc4" %>

<%@ Register Src="Employee/EmployeeContactPeople.ascx" TagName="EmployeeContactPeople"
    TagPrefix="uc1" %>
<%@ Register Src="Templet/NewsContral.ascx" TagName="NewsContral" TagPrefix="uc2" %>
<%@ Register src="HR/RoteChgViewControl.ascx" tagname="RoteChgViewControl" tagprefix="uc14" %>
<%@ Register src="HR/RotationWithNoAttendControl.ascx" tagname="RotationWithNoAttendControl" tagprefix="uc15" %>
<%@ Register src="Templet/AttendUnusual.ascx" tagname="AttendUnusual" tagprefix="uc16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    &nbsp;
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table width="100%">
        <tr>
            <td  valign="top" style="width:65%">
                <uc2:NewsContral ID="NewsContral1" runat="server" Visible="False" />                              
                <uc16:AttendUnusual ID="AttendUnusual1" runat="server" />
                <uc14:RoteChgViewControl ID="RoteChgViewControl1" runat="server" 
                    Visible="False" />
              
                
            </td>
            <td  valign="top" style="width:35%">
                <uc5:BirthdayControl id="BirthdayControl1" runat="server">
                </uc5:BirthdayControl>
                &nbsp;
            </td>
            </tr></table>
             <table width="100%">
        <tr>
            <td  valign="top" >

                &nbsp;
            </td>
            
            </tr></table>
    <table width="100%">
        <tr>
            <td  valign="top" style="width:65%">
                <uc7:AbsList ID="AbsList1" runat="server" />
            <uc4:AbsDayControl id="AbsDayControl1" runat="server">
                </uc4:AbsDayControl>
                &nbsp;<uc15:RotationWithNoAttendControl ID="RotationWithNoAttendControl1" 
                    runat="server" Visible="False" />
            </td>
            <td  valign="top" style="width:35%">
                <uc6:NoviceControl id="NoviceControl1" runat="server">
                </uc6:NoviceControl></td>
            
            </tr></table>
     <table width="100%">
        <tr>
        <td>
            
            </td>
            
            </tr></table>

</asp:Content>

