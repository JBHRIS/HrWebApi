<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpCard.aspx.cs" Inherits="Attendance_EmpCard" Title="刷卡查詢" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <h3>
                    <asp:Label ID="lblShowHeader" runat="server" Text="刷卡資料" meta:resourcekey="lblShowHeaderResource1"></asp:Label>
                </h3>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblInquiryCondition" runat="server" Text="查詢條件" meta:resourcekey="lblInquiryConditionResource1"></asp:Label></legend>
                    <asp:Label ID="Label1" runat="server" Text="刷卡日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="adate" runat="server" Culture="Chinese (Taiwan)" meta:resourcekey="adateResource1"
                        Skin="Transparent">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                            Skin="Transparent">
                        </Calendar>
                        <DateInput Skin="">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                        Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                        meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="ddate" runat="server" Culture="Chinese (Taiwan)" meta:resourcekey="ddateResource1"
                        Skin="Transparent">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                            Skin="Transparent">
                        </Calendar>
                        <DateInput Skin="">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                        Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                        meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                        meta:resourcekey="Button1Resource1" />
                    <asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" Text="匯出Excel"
                        Visible="False" ValidationGroup="group_date" meta:resourcekey="ExportExcelResource1" />&nbsp;
                </fieldset>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                    AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging"
                    meta:resourcekey="GridView2Resource1">
                    <Columns>
                        <asp:BoundField DataField="nobr" HeaderText="員工編號" meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="name_c" HeaderText="員工姓名" meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="adate" DataFormatString="{0:d}" HeaderText="刷卡日期" HtmlEncode="False"
                            meta:resourcekey="BoundFieldResource3" />
                        <asp:BoundField DataField="ontime" HeaderText="刷卡時間" meta:resourcekey="BoundFieldResource4" />
                        <asp:BoundField DataField="not_tran" HeaderText="不轉換" Visible="false" meta:resourcekey="BoundFieldResource5" />
                        <asp:BoundField DataField="cardno" HeaderText="刷卡號碼" Visible="false" meta:resourcekey="BoundFieldResource6" />
                        <asp:BoundField DataField="code" HeaderText="來源" Visible="false" meta:resourcekey="BoundFieldResource7" />
                        <asp:BoundField DataField="IPADD" HeaderText="電子刷卡IP" Visible="false" meta:resourcekey="BoundFieldResource8" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                            meta:resourcekey="lb_emptyResource1"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
            </td>
        </tr>
    </table>
    <%--
    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
                <asp:Label ID="lblShowPageComment" runat="server" Text="程式說明" meta:resourcekey="lblShowPageCommentResource1"></asp:Label></span>
            <span class="SHRight"></span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <br />
            <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False" ForeColor="#FF3300"
                meta:resourcekey="TextBox1Resource1" ReadOnly="True" Rows="10" TextMode="MultiLine"
                Width="100%">1.查詢員工刷卡資料！
2.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！
3.輸入日期格式為西元年！例 2008/12/31&nbsp; ,也可點選欄位『日曆 圖案』可直接點選！</asp:TextBox>
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
