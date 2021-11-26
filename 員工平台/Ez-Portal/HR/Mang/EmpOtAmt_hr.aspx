<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true" EnableEventValidation = "false" CodeFile="EmpOtAmt_hr.aspx.cs" Inherits="HR_Mang_EmpOtAmt_hr" Title="痁" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                        <fieldset>
                            <legend>琩高兵ン</legend>
                            <asp:Label ID="Label1" runat="server" Text="琩高ら戳" 
                                meta:resourcekey="Label1Resource1"></asp:Label>
                            <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                                meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" type="text" 
                                    value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                                </telerik:RadDatePicker>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                                ErrorMessage="ら戳Α岿粇" ValidationGroup="group_date" Display="Dynamic" 
                                meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>                            
                            <asp:Localize ID="Localize1" runat="server" 
                                meta:resourcekey="Localize1Resource1" Text=""></asp:Localize>
                            <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                                meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" type="text" 
                                    value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                                </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                                ErrorMessage="ら戳Α岿粇" ValidationGroup="group_date" Display="Dynamic" 
                                meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="tbTimeSpan" runat="server" Visible="False" 
                                meta:resourcekey="tbTimeSpanResource1">0</asp:TextBox>
                            <br />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="琩高" 
                                ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />&nbsp;<asp:Button
                                ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" 
                                Text="蹲灿Excel" meta:resourcekey="ExportExcelResource1" />
                            <asp:Button
                                ID="ExportSummuryExcel" runat="server" OnClick="ExportSummuryExcel_Click" 
                                Text="蹲参璸Excel" meta:resourcekey="ExportSummuryExcelResource1" />
                            <asp:Label ID="lb_nobr" runat="server" Visible="False" 
                                meta:resourcekey="lb_nobrResource1"></asp:Label>

                            <br />
                            <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Blue" 
                                Text="︹夹肈翴匡逼!!" meta:resourcekey="lblMsgResource1"></asp:Label>

                        </fieldset>
                        <table style="width:100%;">
                            <tr>
                                <td valign="top">
                       <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False"
                            SkinID="Yahoo" AllowPaging="True" AllowSorting="True" 
                            OnPageIndexChanging="GridView2_PageIndexChanging" onrowdatabound="gv_RowDataBound" 
                                        onsorting="gv_Sorting" meta:resourcekey="gvResource1">
                            <Columns>
                                <asp:BoundField DataField="DeptName" HeaderText="场" SortExpression="DeptName" 
                                    meta:resourcekey="BoundFieldResource1" >
                                <HeaderStyle ForeColor="Red" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeptsName" HeaderText="Θセ场" 
                                    meta:resourcekey="BoundFieldResource2" />
                                <asp:BoundField DataField="Nobr" HeaderText="絪腹" SortExpression="Nobr" 
                                    meta:resourcekey="BoundFieldResource3" >
                                <HeaderStyle ForeColor="Red" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name_C" HeaderText="﹎" 
                                    meta:resourcekey="BoundFieldResource4" />
                                <asp:BoundField DataField="Name_E" HeaderText="璣ゅ" 
                                    meta:resourcekey="BoundFieldResource5" />
                                <asp:BoundField DataField="OT" HeaderText="キら痁" 
                                    meta:resourcekey="BoundFieldResource6" />

                                <asp:BoundField DataField="OtPercent" HeaderText="痁ゑ(キ)" 
                                    DataFormatString="{0:P}" SortExpression="OtPercent" 
                                    meta:resourcekey="BoundFieldResource7" >

                                <HeaderStyle ForeColor="Red" />
                                </asp:BoundField>

                                <asp:BoundField DataField="HolidayOT" HeaderText="安ら痁" 
                                    meta:resourcekey="BoundFieldResource8" />

                                <asp:BoundField DataField="HOtPercent" HeaderText="痁ゑ(安)" 
                                    DataFormatString="{0:P}" SortExpression="HOtPercent" 
                                    meta:resourcekey="BoundFieldResource9" >

                                <HeaderStyle ForeColor="Red" />
                                </asp:BoundField>

                                <asp:BoundField DataField="AllHoliHrsAmt" HeaderText="痁ゑだダ(安)" 
                                    meta:resourcekey="BoundFieldResource10" />

                            </Columns>
                           <EmptyDataTemplate>
                               <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                                   Text="’礚闽戈" meta:resourcekey="lb_emptyResource1"></asp:Label>
                           </EmptyDataTemplate>
                        </asp:GridView>
                      
                                </td>
                                <tr>
                                <td valign="top">
                                    <asp:GridView ID="gvSummury" runat="server" AutoGenerateColumns="False" 
                                        onrowdatabound="gvSummury_RowDataBound" ShowFooter="True" 
                                        AllowSorting="True" onsorting="gvSummury_Sorting" SkinID="Yahoo" 
                                        meta:resourcekey="gvSummuryResource1">
                                        <Columns>
                                            <asp:BoundField DataField="DeptName" HeaderText="场" 
                                                meta:resourcekey="BoundFieldResource11" />
                                            <asp:BoundField DataField="DeptEmpQty" HeaderText="场计" 
                                                meta:resourcekey="BoundFieldResource12" />
                                            <asp:BoundField DataField="DeptEmpOtAndHOtQty" HeaderText="痁计(キ安)" 
                                                SortExpression="DeptEmpOtAndHOtQty" meta:resourcekey="BoundFieldResource13" >
                                            <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptOtTimeAmt" HeaderText="场痁计(キ)" 
                                                SortExpression="DeptOtTimeAmt" meta:resourcekey="BoundFieldResource14" >
                                            <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptOtPercent" HeaderText="痁ゑ(キ)" 
                                                DataFormatString="{0:P}" SortExpression="DeptOtPercent" 
                                                meta:resourcekey="BoundFieldResource15" >
                                            <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptHOtTimeAmt" HeaderText="场痁计(安)"  
                                                SortExpression="DeptHOtTimeAmt" meta:resourcekey="BoundFieldResource16" >
                                            <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptAllHoliHrsAmt" HeaderText="痁ゑだダ(安)" 
                                                meta:resourcekey="BoundFieldResource17" />
                                            <asp:BoundField DataField="DeptHOtPercent" HeaderText="痁ゑ(安)" 
                                                DataFormatString="{0:P}" SortExpression="DeptHOtPercent" 
                                                meta:resourcekey="BoundFieldResource18" >
                                            <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptOtAndHOtTimeAmt" HeaderText="场痁计(キ安)" 
                                                Visible="False" meta:resourcekey="BoundFieldResource19" />
                                            <asp:BoundField DataField="DeptOtAndHOtPercent" HeaderText="痁ゑ(キ安)" 
                                                Visible="False" DataFormatString="{0:P}" 
                                                meta:resourcekey="BoundFieldResource20" />                                            
                                            <asp:BoundField DataField="DeptEmpOtErrorQty" HeaderText="钵盽(キ)计" 
                                                SortExpression="DeptEmpOtErrorQty" Visible="False" 
                                                meta:resourcekey="BoundFieldResource21" >
                                            <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeptEmpHOtErrorQty" HeaderText="钵盽(安)计" 
                                                SortExpression="DeptEmpHOtErrorQty" Visible="False" 
                                                meta:resourcekey="BoundFieldResource22" >
                                            <HeaderStyle ForeColor="Red" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    </td>
                                    </tr>
                            </tr>
                        </table>
            </td>
        </tr>
    </table>
    </asp:Content>

