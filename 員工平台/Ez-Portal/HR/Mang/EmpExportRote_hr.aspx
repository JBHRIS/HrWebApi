<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpExportRote_hr.aspx.cs" Inherits="Mang_EmpOtSelect_hr" Title="Untitled Page" %>

<%@ Register Src="../../Utli/DeptUserShift.ascx" TagName="DeptUserShift" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div id="sideContent">
            <h3>
                <asp:Label ID="lblShowDepartment" runat="server" Text="部門資料" meta:resourcekey="lblShowDepartmentResource1"></asp:Label>
            </h3>
            <fieldset>
                <asp:RadioButtonList ID="RBL_deptr" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RBL_deptr_SelectedIndexChanged"
                    RepeatColumns="1" Width="128px">
                    <asp:ListItem Selected="True" Value="0" Enabled="False">員工</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">部門</asp:ListItem>
                    <asp:ListItem Value="2" Enabled="False">含子部門</asp:ListItem>
                </asp:RadioButtonList>
            </fieldset>
            <fieldset>
                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                </asp:TreeView>
            </fieldset>
        </div>
        <div id="mainContent">
            <table width="100%">
                <tr>
                    <td valign="top">
                        <asp:Localize ID="Localize1" runat="server">部門班表匯出</asp:Localize>
                        <table width="100%">
                            <tr>
                                <td colspan="2" valign="top">
                                    <uc1:DeptUserShift ID="DeptUserShift1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
