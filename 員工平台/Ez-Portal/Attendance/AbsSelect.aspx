<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AbsSelect.aspx.cs" Inherits="Attendance_AbsSelect" Title="e-HR" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div>
        <h3>
            <asp:Label ID="lblShowHeader" runat="server" Text="請假資料" meta:resourcekey="lblShowHeaderResource1"></asp:Label>
        </h3>
            <fieldset>
                <legend>
                    <asp:Label ID="lblShowInquiryCondition" runat="server" Text="查詢條件" meta:resourcekey="lblShowInquiryConditionResource1"></asp:Label></legend>
                <asp:Label ID="Label1" runat="server" Text="請假日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                    meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                    meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                    meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="" DateFormat="" DisplayText="" LabelWidth="40%" type="text" value=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                    meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                    meta:resourcekey="Button1Resource1" />&nbsp;
                <asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" Text="匯出Excel"
                    ValidationGroup="group_date" Visible="False" meta:resourcekey="ExportExcelResource1" />
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label></fieldset>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" DataSourceID="HR_Portal_Abs_SqlDataSource" SkinID="Yahoo"
                meta:resourcekey="GridView1Resource1" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" Visible="False"
                        meta:resourcekey="BoundFieldResource1" />
                    <asp:BoundField DataField="NAME_C" HeaderText="NAME_C" SortExpression="NAME_C" Visible="False"
                        meta:resourcekey="BoundFieldResource2" />
                    <asp:BoundField DataField="JOB_NAME" HeaderText="JOB_NAME" SortExpression="JOB_NAME"
                        Visible="False" meta:resourcekey="BoundFieldResource3" />
                    <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" Visible="False"
                        meta:resourcekey="BoundFieldResource4" />
                    <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="請假日期"
                        HtmlEncode="False" SortExpression="BDATE" meta:resourcekey="BoundFieldResource5" />
                    <asp:BoundField DataField="BTIME" HeaderText="開始時間" SortExpression="BTIME" meta:resourcekey="BoundFieldResource6" />
                    <asp:BoundField DataField="ETIME" HeaderText="結束時間" SortExpression="ETIME" meta:resourcekey="BoundFieldResource7" />
                    <asp:BoundField DataField="H_CODE" HeaderText="H_CODE" SortExpression="H_CODE" Visible="False"
                        meta:resourcekey="BoundFieldResource8" />
                    <asp:BoundField DataField="H_NAME" HeaderText="假別" SortExpression="H_NAME" meta:resourcekey="BoundFieldResource9" />
                    <asp:BoundField DataField="UNIT" HeaderText="單位" SortExpression="UNIT" meta:resourcekey="BoundFieldResource10" />
                    <asp:BoundField DataField="TOL_HOURS" HeaderText="請假小計" SortExpression="TOL_HOURS"
                        meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="TOL_DAY" HeaderText="請假天數" SortExpression="TOL_DAY" meta:resourcekey="BoundFieldResource12"
                        Visible="False" />
                    <asp:BoundField DataField="NOTE" HeaderText="備註" SortExpression="NOTE" meta:resourcekey="BoundFieldResource13" />
                    <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" meta:resourcekey="BoundFieldResource14" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                        meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="HR_Portal_Abs_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT NOBR, NAME_C, JOB_NAME, D_NAME, BDATE, BTIME, ETIME, H_CODE, H_NAME, UNIT, TOL_HOURS, TOL_DAY, NOTE, YYMM FROM HR_Portal_Abs WHERE (NOBR = @nobr) AND (CONVERT (char(10), BDATE, 111) BETWEEN CONVERT (char(10), @adate, 111) AND CONVERT (char(10), @ddate, 111))
order by BDATE desc">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
                    <asp:ControlParameter ControlID="adate" Name="adate" PropertyName="SelectedDate" />
                    <asp:ControlParameter ControlID="ddate" Name="ddate" PropertyName="SelectedDate" />
                </SelectParameters>
            </asp:SqlDataSource>
    </div>
</asp:Content>
