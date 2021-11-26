<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT0990113.master" AutoEventWireup="true" CodeFile="ViewFlowM.aspx.cs" Inherits="Manage_ViewFlowM" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                        <asp:Button ID="btnExport" runat="server" onclick="btnExport_Click" Text="匯出" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvForm" runat="server" onrowdatabound="gvForm_RowDataBound">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        人員總筆數：<asp:Label ID="lblCount" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

