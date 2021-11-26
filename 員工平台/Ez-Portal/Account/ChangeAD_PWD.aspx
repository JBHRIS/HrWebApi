<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeAD_PWD.aspx.cs" Inherits="Account_ChangeAD_PWD" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="GreenForm">
        <div class="GreenFormHeader">
            <span class="GHLeft"></span><span class="GHeader">更改AD密碼</span> <span class="GHRight">
            </span>
        </div>
        <div class="GreenFormContent">
        <table width="50%">
            <tr>
                <td style="width:20%; height: 28px;">
                    原本AD密碼：</td>
                <td style="height: 28px"><asp:TextBox ID="old_pwd" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="old_pwd"
                        Display="Dynamic" ErrorMessage="不可空白">不可空白</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 20%">
                    新AD密碼：&nbsp;</td>
                <td>
            <asp:TextBox ID="new_pwd" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="new_pwd"
                        Display="Dynamic" ErrorMessage="不可空白">不可空白</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 20%">
                    新AD密確認：</td>
                <td>
                    <asp:TextBox ID="new_pwd1" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="new_pwd1"
                        Display="Dynamic" ErrorMessage="不可空白">不可空白</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="new_pwd"
                        ControlToValidate="new_pwd1" ErrorMessage="確認密碼錯誤">確認密碼錯誤</asp:CompareValidator></td>
            </tr>
        </table>
            &nbsp;
            <br />
            <asp:Button ID="Button1" runat="server" Text="確定修改" OnClick="Button1_Click" /><br />
        </div>
        <div class="GreenFormFooter">
            <span class="GFLeft"></span><span class="GFRight"></span>
        </div>
    </div>
</asp:Content>

