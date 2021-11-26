<%@ Page Title="教育訓練系統" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" %>
    <%@ Register src="UC/HRNotify.ascx" tagname="HRNotify" tagprefix="uc1" %>
    <%@ Register src="UC/ErrorMsg.ascx" tagname="ErrorMsg" tagprefix="uc3" %>
    <%@ Register src="UC/ApplyCourse.ascx" tagname="ApplyCourse" tagprefix="uc2" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="UC/DeptEmpAttendedClass.ascx" tagname="DeptEmpAttendedClass" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Table ID="Table1" runat="server" Width="100%">
    </asp:Table>

</asp:Content>
