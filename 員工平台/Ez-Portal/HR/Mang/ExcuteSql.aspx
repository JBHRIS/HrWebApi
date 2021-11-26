<%@ Page Title="" Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true" CodeFile="ExcuteSql.aspx.cs" Inherits="HR_Mang_ExcuteSql" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server" Rows="10" TextMode="MultiLine" 
        Width="800px" meta:resourcekey="TextBox1Resource1"></asp:TextBox>
    <br />
    <asp:Button ID="btnExcute" runat="server" onclick="btnExcute_Click" Text="執行" 
        meta:resourcekey="btnExcuteResource1" />
    <asp:Label ID="lbMsg" runat="server" Font-Size="Large" 
        meta:resourcekey="lbMsgResource1"></asp:Label>
    <asp:GridView ID="gv" runat="server" onpageindexchanging="gv_PageIndexChanging" 
        Width="100%" meta:resourcekey="gvResource1">
    </asp:GridView>
    <br />
</asp:Content>

