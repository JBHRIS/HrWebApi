<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MangSelectOt.aspx.cs" Inherits="Mang_MangSelectOt" Title="部門加班資料分析" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
    <legend>
        <asp:Label ID="lblSearch" runat="server" Text="查詢條件" 
            meta:resourcekey="lblSearchResource1"></asp:Label></legend>
    <br />
    <table width="100%">
        <tr>
            <td width="20%">
                <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" Text="日期區間查詢：" 
                    GroupName="otSelect" meta:resourcekey="RadioButton1Resource1" /></td>
            <td>
                <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                    meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" 
                    ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                <asp:Label
                        ID="lblTo" runat="server" Text="至" meta:resourcekey="lblToResource1"></asp:Label>
                <telerik:RadDatePicker 
                    ID="ddate" runat="server" Culture="(Default)" 
                    meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" 
                    ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 24px">
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="otSelect" 
                    Text="計薪年月查詢：" meta:resourcekey="RadioButton2Resource1" /></td>
            <td style="height: 24px">
                <asp:TextBox ID="tb_yymm" runat="server" Width="79px" 
                    meta:resourcekey="tb_yymmResource1"></asp:TextBox>
                <asp:Label ID="lblEx" runat="server" Text="例：查詢2010年8月，請輸入" 
                    meta:resourcekey="lblExResource1"></asp:Label>
                <span style="color: #ff0000"><strong>
                    <asp:Label ID="lblYearMonth" runat="server" Text="201008" 
                    meta:resourcekey="lblYearMonthResource1"></asp:Label></strong></span></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                    meta:resourcekey="Button1Resource2" />
                <asp:Label ID="tb_count" runat="server" Font-Bold="True"
                    ForeColor="Red" meta:resourcekey="tb_countResource1"></asp:Label></td>
        </tr>
    </table>
</fieldset>
    <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" OnMenuItemClick="Menu1_MenuItemClick"
        Orientation="Horizontal" StaticSubMenuIndent="10px" 
        meta:resourcekey="Menu1Resource1">
        <StaticSelectedStyle BackColor="#507CD1" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
        <DynamicMenuStyle BackColor="#B5C7DE" />
        <DynamicSelectedStyle BackColor="#507CD1" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
        <Items>
            <asp:MenuItem Selected="True" Text="統計資料" Value="0" 
                meta:resourcekey="MenuItemResource1"></asp:MenuItem>
            <asp:MenuItem Text="加班資料" Value="1" meta:resourcekey="MenuItemResource2"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <asp:GridView ID="gv_otSelect" runat="server" AutoGenerateColumns="False" 
                OnRowDataBound="gv_otSelect_RowDataBound" ShowFooter="True" 
                meta:resourcekey="gv_otSelectResource1">
                <Columns>
                    <asp:BoundField DataField="dept" HeaderText="部門" 
                        meta:resourcekey="BoundFieldResource1" />
                    <asp:BoundField DataField="ot_t" HeaderText="平日加班時數" 
                        meta:resourcekey="BoundFieldResource2" />
                    <asp:BoundField DataField="ot_r" HeaderText="平日加班轉補休時數" 
                        meta:resourcekey="BoundFieldResource3" />
                    <asp:BoundField DataField="h_ot_t" HeaderText="假日加班時數" 
                        meta:resourcekey="BoundFieldResource4" />
                    <asp:BoundField DataField="h_ot_r" HeaderText="假日加班轉補休時數" 
                        meta:resourcekey="BoundFieldResource5" />
                </Columns>
                <FooterStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:GridView ID="ot_select" runat="server" AutoGenerateColumns="False" 
                meta:resourcekey="ot_selectResource1">
                <Columns>
                    <asp:BoundField DataField="NOBR" HeaderText="員工工號" SortExpression="NOBR" 
                        meta:resourcekey="BoundFieldResource6" />
                    <asp:BoundField DataField="NAME_C" HeaderText="員工姓名" SortExpression="NAME_C" 
                        meta:resourcekey="BoundFieldResource7" />
                    <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="加班日期"
                        SortExpression="BDATE" meta:resourcekey="BoundFieldResource8" />
                    <asp:BoundField DataField="BTIME" HeaderText="開始時間" SortExpression="BTIME" 
                        meta:resourcekey="BoundFieldResource9" />
                    <asp:BoundField DataField="ETIME" HeaderText="結束時間" SortExpression="ETIME" 
                        meta:resourcekey="BoundFieldResource10" />
                    <asp:BoundField DataField="TOT_HOURS" HeaderText="加班總時數" 
                        SortExpression="TOT_HOURS" meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="OT_HRS" HeaderText="申請加班費時數" SortExpression="OT_HRS" 
                        meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="REST_HRS" HeaderText="申請補休時數" 
                        SortExpression="REST_HRS" meta:resourcekey="BoundFieldResource13" />
                    <asp:BoundField DataField="OT_CAR" HeaderText="OT_CAR" SortExpression="OT_CAR" 
                        Visible="False" meta:resourcekey="BoundFieldResource14" />
                    <asp:BoundField DataField="D_NO" HeaderText="部門" SortExpression="D_NO" 
                        meta:resourcekey="BoundFieldResource15" />
                    <asp:BoundField DataField="NOTE" HeaderText="說明" SortExpression="NOTE" 
                        meta:resourcekey="BoundFieldResource16" />
                    <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" 
                        meta:resourcekey="BoundFieldResource17" />
                    <asp:BoundField DataField="isHoli" HeaderText="假日" ReadOnly="True" 
                        SortExpression="isHoli" meta:resourcekey="BoundFieldResource18" />
                    <asp:BoundField DataField="OT_FOOD" HeaderText="OT_FOOD" SortExpression="OT_FOOD"
                        Visible="False" meta:resourcekey="BoundFieldResource19" />
                    <asp:BoundField DataField="FOOD_PRI" HeaderText="FOOD_PRI" SortExpression="FOOD_PRI"
                        Visible="False" meta:resourcekey="BoundFieldResource20" />
                    <asp:BoundField DataField="FOOD_CNT" HeaderText="FOOD_CNT" SortExpression="FOOD_CNT"
                        Visible="False" meta:resourcekey="BoundFieldResource21" />
                    <asp:BoundField DataField="SER" HeaderText="SER" SortExpression="SER" 
                        Visible="False" meta:resourcekey="BoundFieldResource22" />
                    <asp:CheckBoxField DataField="SUM" HeaderText="SUM" SortExpression="SUM" 
                        Visible="False" meta:resourcekey="CheckBoxFieldResource1" />
                    <asp:CheckBoxField DataField="SYSCREAT" HeaderText="SYSCREAT" SortExpression="SYSCREAT"
                        Visible="False" meta:resourcekey="CheckBoxFieldResource2" />
                    <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" 
                        Visible="False" meta:resourcekey="BoundFieldResource23" />
                    <asp:BoundField DataField="DS_NO" HeaderText="DS_NO" SortExpression="DS_NO" 
                        Visible="False" meta:resourcekey="BoundFieldResource24" />
                    <asp:BoundField DataField="DS_NAME" HeaderText="DS_NAME" SortExpression="DS_NAME"
                        Visible="False" meta:resourcekey="BoundFieldResource25" />
                    <asp:BoundField DataField="ROTENAME" HeaderText="ROTENAME" SortExpression="ROTENAME"
                        Visible="False" meta:resourcekey="BoundFieldResource26" />
                    <asp:BoundField DataField="ROTET" HeaderText="ROTET" SortExpression="ROTET" 
                        Visible="False" meta:resourcekey="BoundFieldResource27" />
                    <asp:BoundField DataField="OTRNAME" HeaderText="OTRNAME" SortExpression="OTRNAME"
                        Visible="False" meta:resourcekey="BoundFieldResource28" />
                    <asp:BoundField DataField="OT_DEPTNAME" HeaderText="OT_DEPTNAME" SortExpression="OT_DEPTNAME"
                        Visible="False" meta:resourcekey="BoundFieldResource29" />
                    <asp:CheckBoxField DataField="NOFOOD1" HeaderText="NOFOOD1" SortExpression="NOFOOD1"
                        Visible="False" meta:resourcekey="CheckBoxFieldResource3" />
                    <asp:BoundField DataField="JOBS" HeaderText="JOBS" SortExpression="JOBS" 
                        Visible="False" meta:resourcekey="BoundFieldResource30" />
                    <asp:BoundField DataField="Jobs_Name" HeaderText="Jobs_Name" SortExpression="Jobs_Name"
                        Visible="False" meta:resourcekey="BoundFieldResource31" />
                    <asp:CheckBoxField DataField="COUNT_MA" HeaderText="COUNT_MA" SortExpression="COUNT_MA"
                        Visible="False" meta:resourcekey="CheckBoxFieldResource4" />
                </Columns>
            </asp:GridView>
            &nbsp; &nbsp;
        </asp:View>
    </asp:MultiView>
</asp:Content>

