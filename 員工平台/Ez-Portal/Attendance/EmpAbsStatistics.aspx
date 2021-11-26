<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAbsStatistics.aspx.cs" Inherits="Employee_EmpAbsStatistics" Title="休假統計"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <table width="100%">
        <tr>
            <td valign="top">
                <h3>
                    <asp:Label ID="lblShowHeader" runat="server" Text="休假統計表" meta:resourcekey="lblShowHeaderResource1"></asp:Label>
                </h3>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblShowInquiryCondition" runat="server" Text=" " meta:resourcekey="lblShowInquiryConditionResource1"></asp:Label>資料查詢</legend>
                    <asp:Label ID="Label1" runat="server" Text="補休日期：" meta:resourcekey="Label1Resource1"
                        Visible="False"></asp:Label>
                    <telerik:RadDatePicker ID="adate" runat="server" Culture="zh-TW" meta:resourcekey="adateResource1"
                        Visible="False">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                        <DateInput Skin="" LabelWidth="64px" Width="">
                        </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                        Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                        meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"
                        Visible="False"></asp:Label>
                    <telerik:RadDatePicker ID="ddate" runat="server" Culture="zh-TW" meta:resourcekey="ddateResource1"
                        Visible="False">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                        <DateInput Skin="" LabelWidth="64px" Width="">
                        </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                        Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                        meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" meta:resourcekey="Button1Resource1"
                        Visible="False" />&nbsp;
                    <asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" Text="匯出Excel"
                        ValidationGroup="group_date" meta:resourcekey="ExportExcelResource1" Visible="False" />&nbsp;<br />
                    <asp:Label ID="lblYear" runat="server" Text="年度選擇：" 
                        meta:resourcekey="lblYearResource1"></asp:Label>
                    <telerik:RadComboBox ID="cbxYear" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="cbxYear_SelectedIndexChanged" Culture="zh-TW" 
                        meta:resourcekey="cbxYearResource1">
                    </telerik:RadComboBox>
                </fieldset>
                <br />
                <asp:GridView ID="gv" runat="server" SkinID="Yahoo" AllowPaging="True" AllowSorting="True"
                    meta:resourcekey="GridView2Resource1" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="NOBR" HeaderText="工號" 
                            meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="NAME_C" HeaderText="姓名" 
                            meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="DI" HeaderText="直間接" Visible="False" 
                            meta:resourcekey="BoundFieldResource3" />
                        <asp:BoundField DataField="INDT" HeaderText="到職日" Visible="False" 
                            meta:resourcekey="BoundFieldResource4" />
                        <asp:BoundField DataField="GET_HOURS" HeaderText="特休應休" 
                            meta:resourcekey="BoundFieldResource5" />
                        <asp:BoundField DataField="FullHours1" HeaderText="特休已休" 
                            meta:resourcekey="BoundFieldResource6" />
                        <asp:BoundField DataField="LEAVE_HOURS" HeaderText="特休未休" 
                            meta:resourcekey="BoundFieldResource7" />
                        <asp:BoundField DataField="ABS_HOURS" HeaderText="其他已休" 
                            meta:resourcekey="BoundFieldResource8" />
                        <asp:BoundField DataField="TOL_HOURS" HeaderText="剩餘可休" 
                            meta:resourcekey="BoundFieldResource9" />
                        <asp:BoundField DataField="FullHours2" HeaderText="事假" 
                            meta:resourcekey="BoundFieldResource10" />
                        <asp:BoundField DataField="FullHours3" HeaderText="家庭照顧假" 
                            meta:resourcekey="BoundFieldResource11" />
                        <asp:BoundField DataField="HalfHours1" HeaderText="病假" 
                            meta:resourcekey="BoundFieldResource12" />
                        <asp:BoundField DataField="FullHours6" HeaderText="無薪病假" 
                            meta:resourcekey="BoundFieldResource13" />
                        <asp:BoundField DataField="HalfHours2" HeaderText="生理假" 
                            meta:resourcekey="BoundFieldResource14" />
                        <asp:BoundField DataField="FullHours4" HeaderText="無薪假" 
                            meta:resourcekey="BoundFieldResource15" />
                        <asp:BoundField DataField="FullHours5" HeaderText="曠職" 
                            meta:resourcekey="BoundFieldResource16" />
                        <asp:BoundField DataField="TOL_HOURS" HeaderText="剩餘時數" Visible="False" 
                            meta:resourcekey="BoundFieldResource17" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lb_empty" Font-Size="Small" runat="server" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                            meta:resourcekey="lb_emptyResource1"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
                <%--                <div class="SilverForm">
                    <div class="SilverFormHeader">
                        <span class="SHLeft"></span><span class="SHeader">
                            <asp:Label ID="lblShowPageComment" runat="server" Text="程式說明"></asp:Label></span>
                        <span class="SHRight"></span>
                    </div>
                    <div class="SilverFormContent" style="color: red">
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" ForeColor="Red" Rows="10" TextMode="MultiLine"
                            Width="100%" meta:resourcekey="TextBox1Resource1" Text="1.本算法適用於間接人員，全部以小時計
2.在途假單全部計入已休
3.特休應休的計算是預設至當年度年底
4.特休未休=特休應休－特休已休
5.其他已休=事假+家庭+病假+無薪病假+生理+無薪假
6.剩餘可休=特休未休－事假－家庭－[病假/2]－[生理/2]"></asp:TextBox>
                        <br />
                    </div>
                    <div class="SilverFormFooter">
                        <span class="SFLeft"></span><span class="SFRight"></span>
                    </div>
                </div>
                </div>--%>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
  
</asp:Content>
