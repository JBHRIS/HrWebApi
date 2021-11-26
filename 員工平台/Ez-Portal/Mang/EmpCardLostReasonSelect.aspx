<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EmpCardLostReasonSelect.aspx.cs" Inherits="Mang_EmpCardLostReasonSelect"
    Title="員工忘刷卡原因" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../CalendarAbsList.ascx" TagName="CalendarAbsList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
            <table width="100%">
                <tr>
                    <td valign="top">
                        <div class="SilverForm">
                            <div class="SilverFormHeader">
                                <span class="SHLeft"></span><span class="SHeader">員工補卡原因</span> <span class="SHRight">
                                </span>
                            </div>
                            <div class="SilverFormContent">
                                <fieldset>
                                    <legend>查詢條件</legend>
                                    <asp:Label ID="Label1" runat="server" Text="查詢日期：" 
                                        meta:resourcekey="Label1Resource1"></asp:Label>
                                    &nbsp;<telerik:RadDatePicker ID="rdpBdate" runat="server" Culture="(Default)" 
                                        meta:resourcekey="rdpBdateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                        <DateInput Skin="" DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                                            LabelWidth="64px" Width="">
                                        </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdpBdate"
                                        Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                                        meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                    <asp:Localize ID="Localize1" runat="server" 
                                        meta:resourcekey="Localize1Resource1" Text="至"></asp:Localize>
                                    <telerik:RadDatePicker ID="rdpEdate" runat="server" Culture="(Default)" 
                                        meta:resourcekey="rdpEdateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                        <DateInput Skin="" DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                                            LabelWidth="64px" Width="">
                                        </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpEdate"
                                        Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                                        meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                    <asp:CheckBox ID="cbZero" runat="server" Text="顯示次數0" 
                                        meta:resourcekey="cbZeroResource1" />
                                    <br />
                                    <asp:TextBox ID="tbTimeSpan" runat="server" Visible="False" 
                                        meta:resourcekey="tbTimeSpanResource1">0</asp:TextBox>
                                    <br />
                                    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                                        ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />
                                    &nbsp;<asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" 
                                        Text="匯出明細Excel" meta:resourcekey="ExportExcelResource1" />
                                    <asp:Button ID="ExportSummuryExcel" runat="server" OnClick="ExportSummuryExcel_Click"
                                        Text="匯出統計Excel" meta:resourcekey="ExportSummuryExcelResource1" />
                                    <asp:Button ID="ExportReasonSummury" runat="server" OnClick="ExportReasonSummury_Click"
                                        Text="原因統計Excel" meta:resourcekey="ExportReasonSummuryResource1" />
                                    <br />
                                    <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Blue" 
                                        Text="紅色標題點選可排序!!" meta:resourcekey="lblMsgResource1"></asp:Label>
                                </fieldset>
                                <table style="width: 100%;">
                                    <tr>
                                        <td valign="top">
                                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="Yahoo" AllowPaging="True"
                                                AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="gv_RowDataBound"
                                                OnSorting="gv_Sorting" meta:resourcekey="gvResource1" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="DeptName" HeaderText="部門" SortExpression="DeptName" 
                                                        meta:resourcekey="BoundFieldResource1">
                                                        <HeaderStyle ForeColor="Red" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DeptsName" HeaderText="成本部門" Visible="False" 
                                                        meta:resourcekey="BoundFieldResource2" />
                                                    <asp:BoundField DataField="Nobr" HeaderText="員工編號" SortExpression="Nobr" 
                                                        meta:resourcekey="BoundFieldResource3">
                                                        <HeaderStyle ForeColor="Red" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Name_C" HeaderText="姓名" 
                                                        meta:resourcekey="BoundFieldResource4" />
                                                    <asp:BoundField DataField="Name_E" HeaderText="英文名" 
                                                        meta:resourcekey="BoundFieldResource5" />
                                                    <asp:BoundField DataField="Adate" DataFormatString="{0:d}" HeaderText="補卡日期" 
                                                        meta:resourcekey="BoundFieldResource6" />
                                                    <asp:BoundField DataField="ReasonName" HeaderText="補卡原因" 
                                                        meta:resourcekey="BoundFieldResource7" />
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                                                        Text="＊無相關資料！！" meta:resourcekey="lb_emptyResource1"></asp:Label>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                            <br />
                                            <asp:GridView ID="gvSummury" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSummury_RowDataBound"
                                                ShowFooter="True" AllowSorting="True" SkinID="Yahoo" 
                                                meta:resourcekey="gvSummuryResource1" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="DeptName" HeaderText="部門" 
                                                        meta:resourcekey="BoundFieldResource8" />
                                                    <asp:BoundField DataField="DeptEmpQty" HeaderText="部門人數" Visible="False" 
                                                        meta:resourcekey="BoundFieldResource9" />
                                                    <asp:BoundField DataField="ReasonName" HeaderText="原因" 
                                                        meta:resourcekey="BoundFieldResource10"></asp:BoundField>
                                                    <asp:BoundField DataField="Counter" HeaderText="次數" 
                                                        meta:resourcekey="BoundFieldResource11"></asp:BoundField>
                                                    <asp:BoundField DataField="PercentOfDept" HeaderText="比例" 
                                                        DataFormatString="{0:p}" meta:resourcekey="BoundFieldResource12">
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <asp:GridView ID="gvAllSummury" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                                AllowSorting="True" SkinID="Yahoo" 
                                                meta:resourcekey="gvAllSummuryResource1" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="ReasonName" HeaderText="原因" 
                                                        meta:resourcekey="BoundFieldResource13"></asp:BoundField>
                                                    <asp:BoundField DataField="Counter" HeaderText="次數" 
                                                        meta:resourcekey="BoundFieldResource14"></asp:BoundField>
                                                    <asp:BoundField DataField="PercentOfReason" HeaderText="比例" 
                                                        DataFormatString="{0:p}" meta:resourcekey="BoundFieldResource15">
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td valign="top">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="SilverFormFooter">
                                <span class="SFLeft"></span><span class="SFRight"></span>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
