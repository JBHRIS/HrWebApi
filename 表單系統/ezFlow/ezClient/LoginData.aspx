<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="LoginData.aspx.cs" Inherits="LoginData" Title="ezClient v1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--
		<h5>
            ◎更改帳號◎</h5>
	<ul>
	<li>原始帳號：<asp:Label ID="lblLoginID" runat="server"></asp:Label>(工號與帳號兩者皆可為登入之帳號)</li><li>更改帳號：<asp:TextBox ID="txtLoingID" runat="server"></asp:TextBox><asp:Button ID="btnChangID" runat="server" Text="變更帳號" OnClick="btnChangID_Click" /></li></ul>
	<b>PS：至少四個字元</b>
	<h5>◎變更登入密碼◎</h5>
	<ul>
	<li>請輸入您舊的密碼：<asp:TextBox ID="txtOldPW" runat="server" TextMode="Password"></asp:TextBox></li><li>請輸入您新的密碼：<asp:TextBox ID="txtNewPW" runat="server" TextMode="Password"></asp:TextBox><asp:Button ID="bnChgPW" runat="server" Text="變更密碼" OnClick="bnChgPW_Click" /></li></ul>
	<b>PS：系統不接受空白密碼</b>
	-->
	<h5>◎預定啟動代理◎</h5>
	<ul>
	<li>啟動代理起始日期：<asp:TextBox ID="txtDateB" runat="server"></asp:TextBox></li><li>啟動代理結束日期：<asp:TextBox ID="txtDateE" runat="server"></asp:TextBox><asp:Button ID="bnAgent" runat="server" Text="預定啟動" OnClick="bnAgent_Click" /></li></ul>
	<b>PS：日期的格式為 yyyy-mm-dd 例如：2006-01-01</b>

</asp:Content>
