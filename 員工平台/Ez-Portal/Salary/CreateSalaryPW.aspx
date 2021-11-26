<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateSalaryPW.aspx.cs" Inherits="Salary_CreateSalaryPW" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<div class="GreenForm">
        <div class="GreenFormHeader">
            <span class="GHLeft"></span><span class="GHeader">新增薪資密碼</span> <span class="GHRight">
            </span>
        </div>
        <div class="GreenFormContent">
            <table width="100%">
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="Label1" runat="server" Text="薪資密碼："></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="RequiredFieldValidator">*不能空白</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator3" runat="server" ControlToValidate="TextBox1"
                            Display="Dynamic" ErrorMessage="*密碼格式錯誤　" ValidationExpression="\w{4,}">*密碼格式錯誤　</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="確認薪資密碼："></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2"
                            Display="Dynamic" ErrorMessage="RequiredFieldValidator">*不能空白</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2"
                            ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="CompareValidator">*請再次輸入一次薪資密碼！！</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px">
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClick="LinkButton1_Click">回查詢薪資</asp:LinkButton></td>
                    <td style="height: 21px">
                        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="確定儲存" />
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 21px">
                        <asp:Label ID="Label3" runat="server" ForeColor="Red">（填入 4 個字元以上最多8個字元的英文字母、數字，但不含空白鍵、及「"」。）</asp:Label></td>
                </tr>
            </table>
            <br />
            <br />
        </div>
        <div class="GreenFormFooter">
            <span class="GFLeft"></span><span class="GFRight"></span>
        </div>
    </div>
</asp:Content>

