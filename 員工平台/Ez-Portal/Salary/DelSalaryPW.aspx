<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DelSalaryPW.aspx.cs" Inherits="Salary_DelSalaryPW" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 &nbsp;<div class="GreenForm">
        <div class="GreenFormHeader">
            <span class="GHLeft"></span><span class="GHeader">刪除薪資密碼</span> <span class="GHRight">
            </span>
        </div>
        <div class="GreenFormContent">
            &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="員工工號："></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="刪除" />
            <asp:Label ID="showMeg" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <br />
        </div>
        <div class="GreenFormFooter">
            <span class="GFLeft"></span><span class="GFRight"></span>
        </div>
    </div>
</asp:Content>

