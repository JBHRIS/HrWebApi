<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Abs1Select.aspx.cs" Inherits="Attendance_Abs1Select" Title="e-HR" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        <asp:Label ID="lblShowHeader" runat="server" Text="公出資料" meta:resourcekey="lblShowHeaderResource1"></asp:Label>
    </h3>
    <fieldset>
        <legend>
            <asp:Label ID="lblShowInquiryCondition" runat="server" Text="查詢條件" meta:resourcekey="lblShowInquiryConditionResource1"></asp:Label></legend>
        <asp:Label ID="Label1" runat="server" Text="查詢日期：" meta:resourcekey="Label1Resource1"></asp:Label>
        <telerik:RadDatePicker ID="adate" runat="server" Culture="zh-TW" meta:resourcekey="adateResource1"
            Skin="Transparent">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                ViewSelectorText="x" Skin="Transparent"></Calendar>

            <DateInput Skin="" LabelWidth="64px" Width="" />

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
        </telerik:RadDatePicker>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
            Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
            meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
        <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
        <telerik:RadDatePicker ID="ddate" runat="server" Culture="zh-TW" meta:resourcekey="ddateResource1"
            Skin="Transparent">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                ViewSelectorText="x" Skin="Transparent"></Calendar>

            <DateInput Skin="" LabelWidth="64px" Width="" />

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
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
        AutoGenerateColumns="False" SkinID="Yahoo" meta:resourcekey="GridView1Resource1">
        <Columns>
            <asp:BoundField DataField="Nobr" HeaderText="Nobr" SortExpression="Nobr" Visible="False"
                meta:resourcekey="BoundFieldResource1" />
            <asp:BoundField DataField="NameC" HeaderText="NameC" SortExpression="NameC" Visible="False"
                meta:resourcekey="BoundFieldResource2" />
            <asp:BoundField DataField="JobName" HeaderText="JobName" SortExpression="JobName"
                Visible="False" meta:resourcekey="BoundFieldResource3" />
            <asp:BoundField DataField="DeptName" HeaderText="DeptName" SortExpression="DeptName"
                Visible="False" meta:resourcekey="BoundFieldResource4" />
            <asp:BoundField DataField="AbsDate" DataFormatString="{0:yyyy/MM/dd}" HeaderText="請假日期"
                HtmlEncode="False" SortExpression="AbsDate" meta:resourcekey="BoundFieldResource5" />
            <asp:BoundField DataField="AbsBtime" HeaderText="開始時間" SortExpression="AbsBtime"
                meta:resourcekey="BoundFieldResource6" />
            <asp:BoundField DataField="AbsEtime" HeaderText="結束時間" SortExpression="AbsEtime"
                meta:resourcekey="BoundFieldResource7" />
            <asp:BoundField DataField="H_Code" HeaderText="H_Code" SortExpression="H_Code" Visible="False"
                meta:resourcekey="BoundFieldResource8" />
            <asp:BoundField DataField="H_CodeName" HeaderText="假別" SortExpression="H_CodeName"
                meta:resourcekey="BoundFieldResource9" />
            <asp:BoundField DataField="H_CodeUnit" HeaderText="單位" SortExpression="H_CodeUnit"
                meta:resourcekey="BoundFieldResource10" />
            <asp:BoundField DataField="TOL_HOURS" HeaderText="請假時數" SortExpression="TOL_HOURS"
                meta:resourcekey="BoundFieldResource11" />
            <asp:BoundField DataField="Reason" HeaderText="理由" SortExpression="Reason" meta:resourcekey="BoundFieldResource13"
                Visible="False" />
            <asp:BoundField DataField="NOTE" HeaderText="備註" 
                meta:resourcekey="BoundFieldResource12" />
            <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" meta:resourcekey="BoundFieldResource14" />
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                meta:resourcekey="lb_emptyResource1"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
    <%--    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
            <asp:Label ID="lblShowPageComment" runat="server"
                Text="程式說明" meta:resourcekey="lblShowPageCommentResource1"></asp:Label></span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <br />
            <asp:TextBox ID="TextBox1" runat="server" ForeColor="Red" Rows="10" 
                TextMode="MultiLine" Width="100%" meta:resourcekey="TextBox1Resource1" Text="1.查詢員工公出資料！
2.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！
3.輸入日期格式為西元年！例 2008/12/31&nbsp; ,也可點選欄位『日曆 圖案』可直接點選！"></asp:TextBox>
            <br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
