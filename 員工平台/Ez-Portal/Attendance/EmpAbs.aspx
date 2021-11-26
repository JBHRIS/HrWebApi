<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAbs.aspx.cs" Inherits="Employee_EmpAbs" Title="補休資料" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <h3>
                    <asp:Label ID="lblShowHeader" runat="server" Text="補休資料" meta:resourcekey="lblShowHeaderResource1"></asp:Label>
                </h3>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblShowInquiryCondition" runat="server" Text="查詢條件" meta:resourcekey="lblShowInquiryConditionResource1"></asp:Label></legend>
                    <asp:Label ID="Label1" runat="server" Text="補休日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="adate" runat="server" Culture="Chinese (Taiwan)" 
                         Skin="Windows7">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" 
                            Skin="Windows7"></Calendar>

                        <DateInput Skin="">
                        </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                        Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                        meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="ddate" runat="server" Culture="Chinese (Taiwan)" 
                         Skin="Windows7">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" 
                            Skin="Windows7"></Calendar>

                        <DateInput Skin="">
                        </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                        Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                        meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" meta:resourcekey="Button1Resource1" />&nbsp;
                    <asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" Text="匯出Excel"
                        ValidationGroup="group_date" meta:resourcekey="ExportExcelResource1" 
                        Visible="False" />&nbsp;
                </fieldset>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                    AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging"
                    meta:resourcekey="GridView2Resource1">
                    <Columns>
                        <asp:BoundField DataField="nobr" HeaderText="員工編號" meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="name_c" HeaderText="員工姓名" meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="bdate" DataFormatString="{0:d}" HeaderText="差勤日期" HtmlEncode="False"
                            meta:resourcekey="BoundFieldResource3" />
                        <asp:BoundField DataField="edate" HeaderText="補休失效日" meta:resourcekey="BoundFieldResource4" />
                        <asp:BoundField DataField="h_name1" HeaderText="得假名稱" meta:resourcekey="BoundFieldResource5" />
                        <asp:BoundField DataField="tol_hrs1" HeaderText="得假時數" meta:resourcekey="BoundFieldResource6" />
                        <asp:BoundField DataField="h_name2" HeaderText="請假名稱" meta:resourcekey="BoundFieldResource7" />
                        <asp:BoundField DataField="tol_hrs2" HeaderText="請假時數" meta:resourcekey="BoundFieldResource8" />
                        <asp:BoundField DataField="tolhrs" HeaderText="剩餘時數" meta:resourcekey="BoundFieldResource9" />
                        <asp:BoundField DataField="note" HeaderText="備註" />
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
    <%--    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
            <asp:Label ID="lblShowPageComment" runat="server"
                Text="程式說明" meta:resourcekey="lblShowPageCommentResource1"></asp:Label></span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False" 
                ForeColor="#FF3300" ReadOnly="True" Rows="10" TextMode="MultiLine" 
                Width="100%" meta:resourcekey="TextBox1Resource1">1.查詢員工補休資料！
2.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！
3.輸入日期格式為西元年！例 2008/12/31&nbsp; ,也可點選欄位『日曆 圖案』可直接點選！</asp:TextBox>
            <br />
            <br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
