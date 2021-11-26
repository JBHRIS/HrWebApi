<%@ Page Language="C#" MasterPageFile="~/MasterPage_WithSubMenu.master" AutoEventWireup="true" CodeFile="FlowStart.aspx.cs" Inherits="FlowStart" Title="ezClient v1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div style="overflow: auto; width: 100%; height: 100%">
        <span class="tag">申請身份：<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="FlowStart.aspx">自己</asp:HyperLink></span>
	<asp:TreeView ID="tvMain" runat="server" ExpandDepth="30">
	</asp:TreeView>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
	</div>
</asp:Content>

