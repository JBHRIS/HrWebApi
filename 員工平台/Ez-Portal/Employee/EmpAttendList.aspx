<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EmpAttendList.aspx.cs" Inherits="EmpAttendForgetCard"
    Title="出勤清單" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="content">
        <div id="sideContent">
            <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1" Visible="False">
                <h3>
                    <asp:Label ID="lblShowDepartment" runat="server" meta:resourceKey="lblShowDepartmentResource1"
                        Text="部門資料"></asp:Label>
                </h3>
                <fieldset>
                    <asp:CheckBox ID="cbChildDept" runat="server" Text="查詢含子部門" 
                        meta:resourcekey="cbChildDeptResource1" />
                    <asp:TreeView ID="TreeView1" runat="server" meta:resourceKey="TreeView1Resource1"
                        OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                        <SelectedNodeStyle BackColor="#FF66FF" />
                    </asp:TreeView>
                    <asp:Label ID="lb_nobr" runat="server" meta:resourceKey="lb_nobrResource1" Visible="False"></asp:Label>
                </fieldset>
                <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
            </asp:Panel>
        </div>
        <div id="mainContent">
            <h3>
                <asp:Localize ID="Localize1" runat="server" 
                    meta:resourcekey="Localize1Resource1" Text="出勤清單"></asp:Localize>
            </h3>
            <fieldset>
                <legend>查詢條件</legend>
                <asp:Label ID="Label1" runat="server" Text="查詢日期：" 
                    meta:resourcekey="Label1Resource1"></asp:Label>
                &nbsp;<telerik:RadDatePicker ID="rdpBdate" runat="server" Culture="zh-TW" 
                    meta:resourcekey="rdpBdateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" DisplayText="" LabelWidth="64px" 
                        Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdpBdate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                至
                <telerik:RadDatePicker ID="rdpEdate" runat="server" Culture="zh-TW" 
                    meta:resourcekey="rdpEdateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" DisplayText="" LabelWidth="64px" 
                        Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpEdate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="tbTimeSpan" runat="server" Visible="False" 
                    meta:resourcekey="tbTimeSpanResource1">0</asp:TextBox>
                <br />
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                    ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />
                &nbsp;<asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" 
                    Text="匯出Excel" meta:resourcekey="ExportExcelResource1" />
                <br />
                <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Blue" Text="紅色標題點選可排序!!"
                    Visible="False" meta:resourcekey="lblMsgResource1"></asp:Label>
            </fieldset>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="Yahoo" AllowPaging="True"
                AllowSorting="True" OnPageIndexChanging="gv_PageIndexChanging" Width="100%" meta:resourcekey="gvResource1"
                OnRowDataBound="gv_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="DeptName" HeaderText="部門" meta:resourcekey="BoundFieldResource1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nobr" HeaderText="員工編號" meta:resourcekey="BoundFieldResource2">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NameC" HeaderText="姓名" meta:resourcekey="BoundFieldResource3">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
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
                    <asp:BoundField HeaderText="班別" DataField="ShiftName" 
                        meta:resourcekey="BoundFieldResource7">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="上班時間" DataField="StartWorkingTime" 
                        meta:resourcekey="BoundFieldResource8">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="下班時間" DataField="EndWorkingTime" 
                        meta:resourcekey="BoundFieldResource9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="出勤時數" DataField="RealWorkHours" Visible="False" 
                        meta:resourcekey="BoundFieldResource10">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LateMins" HeaderText="遲到(分)" 
                        meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="LeaveEarlyMins" HeaderText="早退(分)" 
                        meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="IsAbsent" HeaderText="曠職" 
                        meta:resourcekey="BoundFieldResource13" />
                    <asp:BoundField DataField="LostCardTimes" HeaderText="忘刷(次)" 
                        meta:resourcekey="BoundFieldResource14" />
                    <asp:BoundField DataField="TakeLeaveNote" HeaderText="請假" 
                        meta:resourcekey="BoundFieldResource15" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                        meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
