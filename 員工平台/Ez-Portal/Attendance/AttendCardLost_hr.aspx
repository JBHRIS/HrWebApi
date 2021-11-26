<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="AttendCardLost_hr.aspx.cs" Inherits="Mang_MangCard_hr" Title="刷卡資料"
    Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <h3>
                    <asp:Label ID="lblEmp" runat="server" Text="員工忘刷卡" meta:resourcekey="lblEmpResource1"></asp:Label></span>
                </h3>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblSearch" runat="server" Text="查詢條件" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                    <asp:Label ID="Label1" runat="server" Text="查詢日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="adate" runat="server" Culture="Chinese (Taiwan)" meta:resourcekey="adateResource2">
                    </telerik:RadDatePicker>
                    &nbsp;
                    <asp:Label ID="lblTo" runat="server" Text="至" meta:resourcekey="lblToResource1"></asp:Label>
                    <telerik:RadDatePicker ID="ddate" runat="server" Culture="Chinese (Taiwan)" meta:resourcekey="ddateResource2">
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                        ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource2"></asp:RequiredFieldValidator>&nbsp;
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                        meta:resourcekey="Button1Resource1" />&nbsp;<asp:Button ID="ExportExcel" runat="server"
                            OnClick="ExportExcel_Click" Text="匯出Excel" meta:resourcekey="ExportExcelResource1" />
                    <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource2"></asp:Label>
                </fieldset>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                    AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging"
                    meta:resourcekey="GridView2Resource1">
                    <Columns>
                        <asp:BoundField DataField="nobr" HeaderText="員工編號" meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="NAME_C" HeaderText="姓名" meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="adate" HeaderText="日期" DataFormatString="{0:d}" meta:resourcekey="BoundFieldResource3" />
                        <asp:BoundField DataField="ROTE_DISP" HeaderText="班別" meta:resourcekey="BoundFieldResource4" />
                        <asp:BoundField DataField="ROTENAME" HeaderText="班別時段" meta:resourcekey="BoundFieldResource5" />
                        <asp:BoundField DataField="T1" HeaderText="上班時間" meta:resourcekey="BoundFieldResource6" />
                        <asp:BoundField DataField="T2" HeaderText="下班時間" meta:resourcekey="BoundFieldResource7" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                            meta:resourcekey="lb_emptyResource1"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
