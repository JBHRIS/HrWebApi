<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Src="~/templet/questionaryview.ascx" TagPrefix="uc" TagName="QuestionaryView" %>
<%@ Register Src="~/templet/birthdaycontrol2.ascx" TagPrefix="uc" TagName="BirthdayControl" %>
<%@ Register Src="~/templet/novicecontrol2.ascx" TagPrefix="uc" TagName="NoviceControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="Templet/HolidayCalendar.ascx" TagName="HolidayCalendar" TagPrefix="uc1" %>
<%@ Register Src="Templet/NewsContral.ascx" TagName="NewsContral" TagPrefix="uc2" %>
<%@ Register Src="Templet/Marquee.ascx" TagName="Marquee" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--mainNavi end-->
    <div id="content">
        <div id="sideContent">
            <uc1:HolidayCalendar ID="HolidayCalendar1" runat="server" />
            <uc:BirthdayControl runat="server" ID="ucBirthdayControl" />
            <uc:NoviceControl runat="server" ID="ucNoviceControl" />
            <uc:QuestionaryView runat="server" ID="ucQuestionaryView" />
        </div>
        <div id="mainContent" class="mainContent" runat="server">
            <uc3:Marquee ID="Marquee1" runat="server" />
            <uc2:NewsContral ID="NewsContral1" runat="server" Visible="True" />
        </div>
        <%--<div class="expand"></div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
</asp:Content>