<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeMenu.ascx.cs" Inherits="Employee_EmployeeMenu" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div class="GreenForm" >
    <div class="GreenFormHeader">
    
        <span class="GHLeft"></span>
        <span class="GHeader"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/16-file-archive.png" /></span><span class="GHeader">員工資料功能</span> <span class="GHRight">
        </span>
        </div>
    <div class="GreenFormContent">
        <telerik:RadPanelbar ID="RadPanelbar1" runat="server" DataSourceID="SiteMapDataSource1"
            DataTextField="Title" PersistStateInCookie="True" Width="135px">
        </telerik:RadPanelbar>
    </div>
    <div class="GreenFormFooter">
        <span class="GFLeft"></span><span class="GFRight"></span>
    </div>
</div>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" OnDataBinding="SiteMapDataSource1_DataBinding"
    ShowStartingNode="False" StartingNodeUrl="~/EmpDefault.aspx" />
