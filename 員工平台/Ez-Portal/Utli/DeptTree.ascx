<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeptTree.ascx.cs" Inherits="Utli_DeptTree" %>
<div class="GreenForm">
    <div class="GreenFormHeader">
        <span class="GHLeft"></span><span class="GHeader">組織圖</span> <span class="GHRight"></span>
    </div>
    <div class="GreenFormContent">
        <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
        </asp:TreeView>
        &nbsp;</div>
    <div class="GreenFormFooter">
        <span class="GFLeft"></span><span class="GFRight"></span>
    </div>
</div>
