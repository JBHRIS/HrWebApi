<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EmpAttendList_hr.aspx.cs" Inherits="HR_Mang_EmpAttendList_hr"
    Title="出勤清單" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
    <%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
                <h3>
                    <asp:Label ID="lblShowDepartment" runat="server" meta:resourceKey="lblShowDepartmentResource1" Text="部門資料"></asp:Label>
                </h3>
    
            <fieldset>
                <legend>
                    <asp:Label ID="lblSearch" runat="server" Text="查詢條件" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                <asp:Label ID="Label1" runat="server" Text="查詢日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                    meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:Label ID="lblTo" runat="server" Text="至" meta:resourcekey="lblToResource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                    meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                <br />
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                    meta:resourcekey="Button1Resource1" />&nbsp;<asp:Button ID="ExportExcel" runat="server"
                        OnClick="ExportExcel_Click" Text="匯出Excel" meta:resourcekey="ExportExcelResource1" />
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
            </fieldset>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="Yahoo" AllowPaging="True"
                AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging" meta:resourcekey="gvResource1"
                OnRowDataBound="gv_RowDataBound" Width="100%">
                <Columns>
                    <asp:BoundField DataField="DeptName" HeaderText="部門" meta:resourcekey="BoundFieldResource1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nobr" HeaderText="員工編號" meta:resourcekey="BoundFieldResource2">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NameC" HeaderText="姓名" meta:resourcekey="BoundFieldResource3">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AttendDate" HeaderText="出勤日期" DataFormatString="{0:d}"
                        meta:resourcekey="BoundFieldResource4">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="星期" DataField="DayOfWeek" 
                        meta:resourcekey="BoundFieldResource5">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="行事曆" DataField="Calendar" Visible="False" 
                        meta:resourcekey="BoundFieldResource6">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="班別" DataField="Shift" Visible="False" 
                        meta:resourcekey="BoundFieldResource7">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ShiftName" HeaderText="班別" 
                        meta:resourcekey="BoundFieldResource8" />
                    <asp:BoundField HeaderText="上班時間" DataField="StartWorkingTime" 
                        meta:resourcekey="BoundFieldResource9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="下班時間" DataField="EndWorkingTime" 
                        meta:resourcekey="BoundFieldResource10">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="出勤時數" DataField="RealWorkHours" Visible="False" 
                        meta:resourcekey="BoundFieldResource11">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LateMins" HeaderText="遲到(分)" 
                        meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="LeaveEarlyMins" HeaderText="早退(分)" 
                        meta:resourcekey="BoundFieldResource13" />
                    <asp:BoundField DataField="IsAbsent" HeaderText="曠職" 
                        meta:resourcekey="BoundFieldResource14" />
                    <asp:BoundField DataField="LostCardTimes" HeaderText="忘刷(次)" 
                        meta:resourcekey="BoundFieldResource15" />
                    <asp:BoundField DataField="TakeLeaveNote" HeaderText="請假" 
                        meta:resourcekey="BoundFieldResource16" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                        meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
      
</asp:Content>
