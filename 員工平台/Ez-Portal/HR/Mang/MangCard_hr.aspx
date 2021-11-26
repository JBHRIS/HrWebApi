<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="MangCard_hr.aspx.cs" Inherits="Mang_MangCard_hr" Title="刷卡資料" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Templet/SelectEmp.ascx" TagName="SelectEmp" TagPrefix="uc1" %>
<%@ Register Src="../../Templet/SelectEmpHr.ascx" TagName="SelectEmpHr" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>

            <h3>
                <asp:Label ID="lblCard" runat="server" Text="員工刷卡資料" meta:resourcekey="lblCardResource1"></asp:Label>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                    meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                    meta:resourcekey="Button1Resource2" />&nbsp;<asp:Button ID="ExportExcel" runat="server"
                        OnClick="ExportExcel_Click" Text="匯出Excel" meta:resourcekey="ExportExcelResource1" />
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>&nbsp;
            </fieldset>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging"
                meta:resourcekey="GridView2Resource1" Width="100%">
                <Columns>
                    <asp:BoundField DataField="nobr" HeaderText="員工編號" meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="name_c" HeaderText="員工姓名" meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="NAME_E" HeaderText="英文名" meta:resourcekey="BoundFieldResource13" />
                    <asp:BoundField DataField="adate" DataFormatString="{0:d}" HeaderText="刷卡日期" HtmlEncode="False"
                        meta:resourcekey="BoundFieldResource14" />
                    <asp:BoundField DataField="ontime" HeaderText="刷卡時間" meta:resourcekey="BoundFieldResource15" />
                    <asp:BoundField DataField="not_tran" HeaderText="不轉換" meta:resourcekey="BoundFieldResource16" />
                    <asp:BoundField DataField="cardno" HeaderText="刷卡號碼" meta:resourcekey="BoundFieldResource17" />
                    <asp:BoundField DataField="code" HeaderText="來源" meta:resourcekey="BoundFieldResource18" />
                    <asp:BoundField DataField="IPADD" HeaderText="電子刷卡IP" meta:resourcekey="BoundFieldResource19"
                        Visible="False" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                        meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%-- <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
                <asp:Label ID="lblNote" runat="server" Text="程式說明" 
                meta:resourcekey="lblNoteResource1"></asp:Label></span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:Label ID="lblDetail1" runat="server" Text="1.主管查詢員工刷卡資料！" 
                meta:resourcekey="lblDetail1Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail2" runat="server" Text="2.『部門資料』分三個選項：" 
                meta:resourcekey="lblDetail2Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="lblDetail3" runat="server" Text="-員工：單一查詢每一個員工的相關資料" 
                meta:resourcekey="lblDetail3Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="lblDetail4" runat="server" Text="-部門：查詢所選定的部門，所有員工的相關資料" 
                meta:resourcekey="lblDetail4Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="lblDetail5" runat="server" Text="-含子部門：查詢所選定的部門及子部門，所有員工的相關資料" 
                meta:resourcekey="lblDetail5Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail6" runat="server" 
                Text="3.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！" 
                meta:resourcekey="lblDetail6Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail7" runat="server" 
                Text="4.輸入日期格式為西元年！例 2008/12/31 ,也可點選欄位『日曆 圖案』可直接點選！" 
                meta:resourcekey="lblDetail7Resource1"></asp:Label><br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
