<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountInfo.ascx.cs" Inherits="Account_AccountInfo" %>
<%@ Register Src="~/account/accountpicture.ascx" TagPrefix="uc" TagName="AccountPicture" %>

<%--<div class="BlueForm">
    <div class="BlueFormHeader">
        <span class="BHLeft"></span><span class="GHeader">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/16-member.png" meta:resourcekey="Image1Resource1" /></span>
        <span class="BHeader">--%>
            <h3>
                <asp:Label ID="lblUserInfo" runat="server" Text="員工資訊" meta:resourcekey="lblUserInfoResource1"></asp:Label>
            </h3>
   <%--     </span><span class="BHRight"></span>
    </div>
    <div class="BlueFormContent">--%>
<uc:AccountPicture runat="server" ID="ucAccountPicture" />
        <br />
        <table>
            <tr>
                <td width="40px">
                    <asp:Label ID="lblShowNobr" runat="server" Text="工號：" meta:resourcekey="lblShowNobrResource1"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lb_nobr" runat="server" meta:resourcekey="lb_nobrResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblShowName" runat="server" Text="姓名：" meta:resourcekey="lblShowNameResource1"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lb_name" runat="server" meta:resourcekey="lb_nameResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblShowEName" runat="server" Text="英文名：" meta:resourcekey="lblShowENameResource1"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEname" runat="server" meta:resourcekey="lblEnameResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblShowJobName" runat="server" Text="職稱：" meta:resourcekey="lblShowJobNameResource1"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lb_job" runat="server" meta:resourcekey="lb_jobResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblShowDept" runat="server" Text="部門：" meta:resourcekey="lblShowDeptResource1"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lb_dept" runat="server" meta:resourcekey="lb_deptResource1"></asp:Label>
                </td>
            </tr>
        </table>
<%--    </div>
    <div class="BlueFormFooter">
        <span class="BFLeft"></span><span class="BFRight"></span>
    </div>
</div>--%>
