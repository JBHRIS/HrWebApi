<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EmpOtSummurySelect.aspx.cs" Inherits="Mang_EmpOtSummurySelect"
    Title="員工加班彙總" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
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
                        <h3>
                            <asp:Localize ID="Localize1" runat="server" 
                                meta:resourcekey="Localize1Resource1" Text="員工加班"></asp:Localize>
                        </h3>
                        <fieldset>
                            <legend>
                                <asp:Localize ID="Localize2" runat="server" 
                                    meta:resourcekey="Localize2Resource1" Text="查詢條件"></asp:Localize></legend>
                            <asp:Label ID="Label1" runat="server" Text="查詢日期：" 
                                meta:resourcekey="Label1Resource2"></asp:Label>
                            &nbsp;<telerik:RadDatePicker ID="rdpBdate" runat="server" Culture="(Default)">
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdpBdate"
                                Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                                meta:resourcekey="RequiredFieldValidator1Resource2"></asp:RequiredFieldValidator>
                            <asp:Localize ID="Localize3" runat="server" 
                                meta:resourcekey="Localize3Resource1" Text="至"></asp:Localize>
                            <telerik:RadDatePicker ID="rdpEdate" runat="server" Culture="(Default)">
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpEdate"
                                Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                                meta:resourcekey="RequiredFieldValidator2Resource2"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="tbTimeSpan" runat="server" Visible="False" 
                                meta:resourcekey="tbTimeSpanResource2">0</asp:TextBox>
                            <br />
                            &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                                ValidationGroup="group_date" meta:resourcekey="Button1Resource2" />
                            &nbsp;<asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" 
                                Text="匯出明細Excel" meta:resourcekey="ExportExcelResource2" />
                            <asp:Button ID="ExportSummuryExcel" runat="server" OnClick="ExportSummuryExcel_Click"
                                Text="匯出統計Excel" meta:resourcekey="ExportSummuryExcelResource1" />
                            <br />
                            <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Blue" 
                                Text="紅色標題點選可排序!!" meta:resourcekey="lblMsgResource1"></asp:Label>
                        </fieldset>
                        <table style="width: 100%;">
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="Yahoo" AllowPaging="True"
                                        AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="gv_RowDataBound"
                                        OnSorting="gv_Sorting" meta:resourcekey="gvResource2" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="DeptName" HeaderText="部門" SortExpression="DeptName" 
                                                meta:resourcekey="BoundFieldResource7">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptsName" HeaderText="成本部門" 
                                                meta:resourcekey="BoundFieldResource8" />
                                            <asp:BoundField DataField="Nobr" HeaderText="員工編號" SortExpression="Nobr" 
                                                meta:resourcekey="BoundFieldResource9">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Name_C" HeaderText="姓名" 
                                                meta:resourcekey="BoundFieldResource10" />
                                            <asp:BoundField DataField="Name_E" HeaderText="英文名" 
                                                meta:resourcekey="BoundFieldResource11" />
                                            <asp:BoundField DataField="OT" HeaderText="平日加班" 
                                                meta:resourcekey="BoundFieldResource12" />
                                            <asp:BoundField DataField="OtPercent" HeaderText="加班比(平)" DataFormatString="{0:P}"
                                                SortExpression="OtPercent" meta:resourcekey="BoundFieldResource13">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HolidayOT" HeaderText="假日加班" 
                                                meta:resourcekey="BoundFieldResource14" />
                                            <asp:BoundField DataField="HOtPercent" HeaderText="加班比(假)" DataFormatString="{0:P}"
                                                SortExpression="HOtPercent" meta:resourcekey="BoundFieldResource15">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AllHoliHrsAmt" HeaderText="加班比分母(假)" 
                                                meta:resourcekey="BoundFieldResource16" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                                                Text="＊無相關資料！！" meta:resourcekey="lb_emptyResource2"></asp:Label>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <br />
                                    <asp:GridView ID="gvSummury" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSummury_RowDataBound"
                                        ShowFooter="True" AllowSorting="True" OnSorting="gvSummury_Sorting" 
                                        SkinID="Yahoo" meta:resourcekey="gvSummuryResource1" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="DeptName" HeaderText="部門" 
                                                meta:resourcekey="BoundFieldResource17" />
                                            <asp:BoundField DataField="DeptEmpQty" HeaderText="部門人數" 
                                                meta:resourcekey="BoundFieldResource18" />
                                            <asp:BoundField DataField="DeptEmpOtAndHOtQty" HeaderText="加班人數(平假)" 
                                                SortExpression="DeptEmpOtAndHOtQty" meta:resourcekey="BoundFieldResource19">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptOtTimeAmt" HeaderText="部門加班時數(平)" 
                                                SortExpression="DeptOtTimeAmt" meta:resourcekey="BoundFieldResource20">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptOtPercent" HeaderText="加班比(平)" DataFormatString="{0:P}"
                                                SortExpression="DeptOtPercent" meta:resourcekey="BoundFieldResource21">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptHOtTimeAmt" HeaderText="部門加班時數(假)" 
                                                SortExpression="DeptHOtTimeAmt" meta:resourcekey="BoundFieldResource22">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptAllHoliHrsAmt" HeaderText="加班比分母(假)" 
                                                meta:resourcekey="BoundFieldResource23" />
                                            <asp:BoundField DataField="DeptHOtPercent" HeaderText="加班比(假)" DataFormatString="{0:P}"
                                                SortExpression="DeptHOtPercent" meta:resourcekey="BoundFieldResource24">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptOtAndHOtTimeAmt" HeaderText="部門加班時數(平假)" 
                                                Visible="False" meta:resourcekey="BoundFieldResource25" />
                                            <asp:BoundField DataField="DeptOtAndHOtPercent" HeaderText="加班比(平假)" Visible="False"
                                                DataFormatString="{0:P}" meta:resourcekey="BoundFieldResource26" />
                                            <asp:BoundField DataField="DeptEmpOtErrorQty" HeaderText="異常(平)人數" SortExpression="DeptEmpOtErrorQty"
                                                Visible="False" meta:resourcekey="BoundFieldResource27">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptEmpHOtErrorQty" HeaderText="異常(假)人數" SortExpression="DeptEmpHOtErrorQty"
                                                Visible="False" meta:resourcekey="BoundFieldResource28">
                                                <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
