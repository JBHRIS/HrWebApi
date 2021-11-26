<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EmpAbsStatistics.aspx.cs" Inherits="Mang_EmpAbsStatistics"
    Title="員工休假統計" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Src="../CalendarAbsList.ascx" TagName="CalendarAbsList" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:empdeptqs runat="server" ID="ucEmpDeptQS" />
        </div>
                        <fieldset>
                            <legend>查詢條件</legend>
                            <asp:Label ID="lblYear" runat="server" Text="年度選擇：" 
                                meta:resourcekey="lblYearResource1"></asp:Label>
                            <telerik:RadComboBox ID="cbxYear" runat="server" Culture="zh-TW" 
                                meta:resourcekey="cbxYearResource1">
                            </telerik:RadComboBox>
                            <br />
                            &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                                ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />
                            &nbsp;<asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" 
                                Text="匯出Excel" meta:resourcekey="ExportExcelResource1" />
                        </fieldset>
                        <asp:GridView ID="gv" runat="server" SkinID="Yahoo" 
            AllowPaging="True" AllowSorting="True"
                            meta:resourcekey="GridView2Resource1" 
            AutoGenerateColumns="False" OnPageIndexChanging="gv_PageIndexChanging" 
            Width="100%">
                            <Columns>
                                <asp:BoundField DataField="NOBR" HeaderText="工號" 
                                    meta:resourcekey="BoundFieldResource1" />
                                <asp:BoundField DataField="NAME_C" HeaderText="姓名" 
                                    meta:resourcekey="BoundFieldResource2" />
                                <asp:BoundField DataField="DeptName" HeaderText="部門" 
                                    meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="DI" HeaderText="直間接" Visible="False" 
                                    meta:resourcekey="BoundFieldResource4" />
                                <asp:BoundField DataField="INDT" HeaderText="到職日" Visible="False" 
                                    meta:resourcekey="BoundFieldResource5" />
                                <asp:BoundField DataField="GET_HOURS" HeaderText="特休應休" 
                                    meta:resourcekey="BoundFieldResource6" />
                                <asp:BoundField DataField="FullHours1" HeaderText="特休已休" 
                                    meta:resourcekey="BoundFieldResource7" />
                                <asp:BoundField DataField="LEAVE_HOURS" HeaderText="特休未休" 
                                    meta:resourcekey="BoundFieldResource8" />
                                <asp:BoundField DataField="ABS_HOURS" HeaderText="其他已休" 
                                    meta:resourcekey="BoundFieldResource9" />
                                <asp:BoundField DataField="TOL_HOURS" HeaderText="剩餘可休" 
                                    meta:resourcekey="BoundFieldResource10" />
                                <asp:BoundField DataField="FullHours2" HeaderText="事假" 
                                    meta:resourcekey="BoundFieldResource11" />
                                <asp:BoundField DataField="FullHours3" HeaderText="家庭照顧假" 
                                    meta:resourcekey="BoundFieldResource12" />
                                <asp:BoundField DataField="HalfHours1" HeaderText="病假" 
                                    meta:resourcekey="BoundFieldResource13" />
                                <asp:BoundField DataField="FullHours6" HeaderText="無薪病假" 
                                    meta:resourcekey="BoundFieldResource14" />
                                <asp:BoundField DataField="HalfHours2" HeaderText="生理假" 
                                    meta:resourcekey="BoundFieldResource15" />
                                <asp:BoundField DataField="FullHours4" HeaderText="無薪假" 
                                    meta:resourcekey="BoundFieldResource16" />
                                <asp:BoundField DataField="FullHours5" HeaderText="曠職" 
                                    meta:resourcekey="BoundFieldResource17" />
                                <asp:BoundField DataField="TOL_HOURS" HeaderText="剩餘時數" Visible="False" 
                                    meta:resourcekey="BoundFieldResource18" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                                    meta:resourcekey="lb_emptyResource1"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--
                <div class="SilverForm">
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
6.剩餘可休=特休未休－(事假－(家庭－[病假/2]－[生理/2]"></asp:TextBox>
                        <br />
                    </div>
                    <div class="SilverFormFooter">
                        <span class="SFLeft"></span><span class="SFRight"></span>
                    </div>
                </div>
                </div>--%>
</asp:Content>
