<%@ Page Language="C#" MasterPageFile="~/MasterPage_WithSubMenu.master" AutoEventWireup="true" CodeFile="AgentStart.aspx.cs" Inherits="AgentStart" Title="ezClient v1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div style="overflow: auto; width: 100%; height: 100%">
        <span class="tag">申請身份：<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="FlowStart.aspx">自己</asp:HyperLink>｜<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AgentStart.aspx">代理</asp:HyperLink></span>
        <asp:TreeView ID="tvMain" runat="server">
	</asp:TreeView>
        &nbsp;
	</div>
</asp:Content>

