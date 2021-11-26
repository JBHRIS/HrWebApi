<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DoWork.aspx.cs" Inherits="Flow_DoWork" Title="表單申請" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:TreeView ID="tvMain" runat="server" ExpandDepth="30">
    </asp:TreeView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <iframe  height="550px" width="100%" frameborder="0" id="frameMain" name="frameMain" scrolling="no" marginheight="0" marginwidth="0"  onload="AutoIframe();" ></iframe>

</asp:Content>

