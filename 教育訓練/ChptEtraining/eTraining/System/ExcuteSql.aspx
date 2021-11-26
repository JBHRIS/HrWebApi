<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="ExcuteSql.aspx.cs" Inherits="HR_Mang_ExcuteSql" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server" Rows="10" TextMode="MultiLine" 
        Width="800px"></asp:TextBox>
    <br />
    <asp:Button ID="btnExcute" runat="server" onclick="btnExcute_Click" Text="執行" />
    <asp:Label ID="lbMsg" runat="server" Font-Size="Large"></asp:Label>
    <asp:GridView ID="gv" runat="server" onpageindexchanging="gv_PageIndexChanging" 
        Width="100%">
    </asp:GridView>
    <br />
</asp:Content>

