<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="LoginData.aspx.cs" Inherits="LoginData" Title="ezClient v1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--
		<h5>
            �����b����</h5>
	<ul>
	<li>��l�b���G<asp:Label ID="lblLoginID" runat="server"></asp:Label>(�u���P�b����̬ҥi���n�J���b��)</li><li>���b���G<asp:TextBox ID="txtLoingID" runat="server"></asp:TextBox><asp:Button ID="btnChangID" runat="server" Text="�ܧ�b��" OnClick="btnChangID_Click" /></li></ul>
	<b>PS�G�ܤ֥|�Ӧr��</b>
	<h5>���ܧ�n�J�K�X��</h5>
	<ul>
	<li>�п�J�z�ª��K�X�G<asp:TextBox ID="txtOldPW" runat="server" TextMode="Password"></asp:TextBox></li><li>�п�J�z�s���K�X�G<asp:TextBox ID="txtNewPW" runat="server" TextMode="Password"></asp:TextBox><asp:Button ID="bnChgPW" runat="server" Text="�ܧ�K�X" OnClick="bnChgPW_Click" /></li></ul>
	<b>PS�G�t�Τ������ťձK�X</b>
	-->
	<h5>���w�w�ҰʥN�z��</h5>
	<ul>
	<li>�ҰʥN�z�_�l����G<asp:TextBox ID="txtDateB" runat="server"></asp:TextBox></li><li>�ҰʥN�z��������G<asp:TextBox ID="txtDateE" runat="server"></asp:TextBox><asp:Button ID="bnAgent" runat="server" Text="�w�w�Ұ�" OnClick="bnAgent_Click" /></li></ul>
	<b>PS�G������榡�� yyyy-mm-dd �Ҧp�G2006-01-01</b>

</asp:Content>
