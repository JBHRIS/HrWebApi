<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChangPWD.aspx.cs" Inherits="Account_ChangPWD" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        <asp:Label ID="lblHeader" runat="server" Text="更改密碼" meta:resourcekey="lblHeaderResource1"></asp:Label>
    </h3>
    <table width="80%">
        <tr>
            <td style="width: 30%; height: 28px;">
                <asp:Label ID="lblOldPWD" runat="server" Text="原本密碼：" meta:resourcekey="lblOldPWDResource1"></asp:Label>
            </td>
            <td style="height: 28px">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" meta:resourcekey="TextBox1Resource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                    Display="Dynamic" ErrorMessage="不可空白" meta:resourcekey="RequiredFieldValidator1Resource1">不可空白</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 30%">
                <asp:Label ID="lblNewPWD" runat="server" Text="新密碼：" meta:resourcekey="lblNewPWDResource1"></asp:Label>&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" meta:resourcekey="TextBox2Resource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                    Display="Dynamic" ErrorMessage="不可空白" meta:resourcekey="RequiredFieldValidator2Resource1">
                    <asp:Label ID="lblErrorMsg" runat="server" Text="不可空白" meta:resourcekey="lblErrorMsgResource1"></asp:Label>
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 30%">
                <asp:Label ID="lblNewPWDRe" runat="server" Text="新密確認：" meta:resourcekey="lblNewPWDReResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" meta:resourcekey="TextBox3Resource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                    Display="Dynamic" ErrorMessage="不可空白" meta:resourcekey="RequiredFieldValidator3Resource1">
                    <asp:Label ID="lblErrorMsg1" runat="server" Text="不可空白" meta:resourcekey="lblErrorMsg1Resource1"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2"
                    ControlToValidate="TextBox3" ErrorMessage="確認密碼錯誤" meta:resourcekey="CompareValidator1Resource1">
                    <asp:Label ID="lblErrorMsg2" runat="server" Text="確認密碼錯誤" meta:resourcekey="lblErrorMsg2Resource1"></asp:Label>
                </asp:CompareValidator>
            </td>
        </tr>
    </table>
    &nbsp;
    <br />
    <asp:Button ID="Button1" runat="server" Text="確定修改" OnClick="Button1_Click" meta:resourcekey="Button1Resource1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
