<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="PunchOut.aspx.cs" Inherits="PunchOut" Title="Untitled Page" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <asp:Panel runat="server" ID="pnl1">
            <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
            </asp:Timer>
            <div style="float: left; width: 1000px">
                <table width="40%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="員工姓名" Font-Size="Medium" 
                                ViewStateMode="Disabled"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbName" runat="server" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="現在時間" Font-Size="Medium" 
                                ViewStateMode="Disabled"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbTime" runat="server" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnSubmit" runat="server" Text="確認送出" 
                                OnClick="btnSubmit_Click" Font-Size="Medium">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader"><asp:Label ID="lblNote" runat="server" Text="程式說明" meta:resourcekey="lblNoteResource1"></asp:Label></span></span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:Label ID="lblNoteDetail" runat="server" Text="1.查詢員工獎懲資料！" meta:resourcekey="lblNoteDetailResource1"></asp:Label><br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
