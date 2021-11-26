<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="OnlineListUser.aspx.cs" Inherits="HR_OnlineListUser" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="../Utli/UserRecord.ascx" TagName="UserRecord" TagPrefix="uc3" %>
<%@ Register Src="../Utli/OnlineList.ascx" TagName="OnlineList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        <asp:Label ID="lblList" runat="server" Text="目前線上人數及名單" meta:resourcekey="lblListResource1"></asp:Label>
    </h3>
    <table width="90%">
        <tr valign="top">
            <td style="width: 20%">
                <uc2:OnlineList ID="OnlineList1" runat="server" />
            </td>
            <td style="width: 70%">
                <asp:Label ID="Label1" runat="server" Text="目前線上名單" ForeColor="Red" meta:resourcekey="Label1Resource1"></asp:Label><br />
                <uc3:UserRecord ID="UserRecord1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
