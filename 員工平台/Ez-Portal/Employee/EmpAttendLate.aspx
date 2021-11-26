﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EmpAttendLate.aspx.cs" Inherits="EmpAttendLate"
    Title="員工遲到" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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
                    meta:resourcekey="Localize1Resource1" Text="遲到統計"></asp:Localize>
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
                    Text="匯出明細Excel" meta:resourcekey="ExportExcelResource1" />
                <asp:Button ID="ExportSummuryExcel" runat="server" OnClick="ExportSummuryExcel_Click"
                    Text="匯出統計Excel" meta:resourcekey="ExportSummuryExcelResource1" />
                <br />
                <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Blue" Text="紅色標題點選可排序!!"
                    Visible="False" meta:resourcekey="lblMsgResource1"></asp:Label>
            </fieldset>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                OnPageIndexChanging="GridView2_PageIndexChanging" AllowPaging="True" 
                meta:resourcekey="gvResource1">
                <Columns>
                    <asp:BoundField DataField="Nobr" HeaderText="員工編號" 
                        meta:resourcekey="BoundFieldResource1"></asp:BoundField>
                    <asp:BoundField DataField="Name_C" HeaderText="姓名" 
                        meta:resourcekey="BoundFieldResource2" />
                    <asp:BoundField DataField="DeptName" HeaderText="部門" 
                        meta:resourcekey="BoundFieldResource3"></asp:BoundField>
                    <asp:BoundField DataField="DeptCode" HeaderText="部門代碼" 
                        meta:resourcekey="BoundFieldResource4" />
                    <asp:BoundField DataField="JobName" HeaderText="職稱" 
                        meta:resourcekey="BoundFieldResource5"></asp:BoundField>
                    <asp:BoundField DataField="JobCode" HeaderText="職稱代碼" 
                        meta:resourcekey="BoundFieldResource6" />
                    <asp:BoundField DataField="Date" HeaderText="日期" DataFormatString="{0:d}" 
                        meta:resourcekey="BoundFieldResource7" />
                    <asp:BoundField DataField="Qty" HeaderText="遲到分鐘數" 
                        meta:resourcekey="BoundFieldResource8" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                        Text="＊無相關資料！！" meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <br />
            <asp:GridView ID="gvSummury" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                AllowPaging="True" OnPageIndexChanging="gvSummury_PageIndexChanging" 
                meta:resourcekey="gvSummuryResource1">
                <Columns>
                    <asp:BoundField DataField="Place" HeaderText="名次" 
                        meta:resourcekey="BoundFieldResource9" />
                    <asp:BoundField DataField="Nobr" HeaderText="工號" 
                        meta:resourcekey="BoundFieldResource10" />
                    <asp:BoundField DataField="Name_C" HeaderText="姓名" 
                        meta:resourcekey="BoundFieldResource11"></asp:BoundField>
                    <asp:BoundField DataField="DeptCode" HeaderText="單位代碼" 
                        meta:resourcekey="BoundFieldResource12"></asp:BoundField>
                    <asp:BoundField DataField="DeptName" HeaderText="單位名稱" 
                        meta:resourcekey="BoundFieldResource13"></asp:BoundField>
                    <asp:BoundField DataField="JobCode" HeaderText="職稱代碼" 
                        meta:resourcekey="BoundFieldResource14"></asp:BoundField>
                    <asp:BoundField DataField="JobName" HeaderText="職稱名稱" 
                        meta:resourcekey="BoundFieldResource15" />
                    <asp:BoundField DataField="MinsAmt" HeaderText="遲到分鐘數" 
                        meta:resourcekey="BoundFieldResource16"></asp:BoundField>
                    <asp:BoundField DataField="MinsNum" HeaderText="遲到次數" 
                        meta:resourcekey="BoundFieldResource17" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
