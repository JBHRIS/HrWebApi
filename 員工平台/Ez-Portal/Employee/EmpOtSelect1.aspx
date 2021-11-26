<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EmpOtSelect1.aspx.cs" Inherits="Employee_EmpOtSelect1"
    Title="超時查詢" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <h3>
        <asp:Localize ID="Localize1" runat="server">超時統計</asp:Localize>
    </h3>
    <fieldset>
        <legend>資料查詢</legend>
        <asp:Label ID="Label1" runat="server" Text="查詢日期："></asp:Label>
        &nbsp;<telerik:RadDatePicker ID="rdpBdate" runat="server">
        </telerik:RadDatePicker>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdpBdate"
            Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date"></asp:RequiredFieldValidator>
        至
        <telerik:RadDatePicker ID="rdpEdate" runat="server">
        </telerik:RadDatePicker>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpEdate"
            Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="tbTimeSpan" runat="server" Visible="False">0</asp:TextBox>
        <br />
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date" />
        &nbsp;<br />
        <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Blue" Text="紅色標題點選可排序!!"
            Visible="False"></asp:Label>
    </fieldset>
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        SkinID="Yahoo" meta:resourcekey="GridView2Resource1">
        <Columns>
            <asp:BoundField DataField="NOBR" HeaderText="員工編號" SortExpression="NOBR" meta:resourcekey="BoundFieldResource11" />
            <asp:BoundField DataField="NameC" HeaderText="姓名" SortExpression="NameC" meta:resourcekey="BoundFieldResource12" />
            <asp:BoundField DataField="DeptName" HeaderText="部門名稱" SortExpression="DeptName"
                meta:resourcekey="BoundFieldResource15" />
            <asp:BoundField DataField="DeptDispCode" HeaderText="部門代碼" />
            <asp:BoundField DataField="JobName" HeaderText="職稱" />
            <asp:BoundField DataField="JobDispCode" HeaderText="職稱代碼" SortExpression="JobDispCode" />
            <asp:BoundField DataField="OtAmt" HeaderText="超時時數" meta:resourceKey="BoundFieldResource19"
                SortExpression="OtAmt" />
            <asp:BoundField DataField="OtSubmittedAmt" HeaderText="已申請加班時數" meta:resourceKey="BoundFieldResource20"
                SortExpression="OtSubmittedAmt" />
            <asp:BoundField DataField="OtUnSubmittedAmt" HeaderText="未申請時數" meta:resourceKey="BoundFieldResource21"
                SortExpression="OtUnSubmittedAmt" />
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                meta:resourcekey="lb_emptyResource1"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
