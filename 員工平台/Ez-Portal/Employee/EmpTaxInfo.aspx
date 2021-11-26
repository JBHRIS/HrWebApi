<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpTaxInfo.aspx.cs" Inherits="Employee_EmpTaxInfo" Title="e-HR" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Src="~/templet/mytax.ascx" TagPrefix="uc" TagName="MyTax" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: left;width:100%">
    <uc:MyTax runat="server" ID="ucMyTax" />
    </div>
</asp:Content>
