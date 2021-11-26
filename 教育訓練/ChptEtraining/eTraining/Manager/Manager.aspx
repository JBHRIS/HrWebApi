<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="Manager.aspx.cs" Inherits="eTraining_Manager_Manager" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UC/ApplyCourse.ascx" TagName="ApplyCourse" TagPrefix="uc5" %>
<%@ Register Src="~/UC/YearPlan.ascx" TagName="YearPlan" TagPrefix="uc6" %>
<%@ Register Src="~/UC/ApplyCourse.ascx" TagName="ApplyCourse" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .block
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div>
            <uc7:ApplyCourse ID="ApplyCourse1" runat="server" />
        </div>
    </div>
</asp:Content>
