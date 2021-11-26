<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarAbsList.ascx.cs"
    Inherits="CalendarAbsList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<h3>
    <asp:Label ID="lblShowHeader" runat="server" Text="行事曆" 
        meta:resourcekey="lblShowHeaderResource1" Font-Size="Large"></asp:Label>
</h3>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <asp:Label ID="lblJumpYYMM" runat="server" Text="跳轉至" meta:resourcekey="lblJumpYYMMResource1"></asp:Label>
        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
            meta:resourcekey="ddlYearResource1">
        </asp:DropDownList>
        <asp:Label ID="lblYear" runat="server" Text="年" meta:resourcekey="lblYearResource1"></asp:Label>
        <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
            meta:resourcekey="ddlMonthResource1">
            <asp:ListItem meta:resourcekey="ListItemResource1" Text="1"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource2" Text="2"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource3" Text="3"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource4" Text="4"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource5" Text="5"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource6" Text="6"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource7" Text="7"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource8" Text="8"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource9" Text="9"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource10" Text="10"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource11" Text="11"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource12" Text="12"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblMonth" runat="server" Text="月" meta:resourcekey="lblMonthResource1"></asp:Label>
        <br />
        <asp:Label ID="lbMsg" runat="server" Font-Size="Small" ForeColor="#0066FF" 
            Text="*加班請假明細請點選下底線即可" meta:resourcekey="lbMsgResource1"></asp:Label>
        <br />
        <table width="100%">
            <tr>
                <td valign="top">
                    <asp:Calendar ID="Calendar1" runat="server"
                        OnDayRender="Calendar1_DayRender" 
                        OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" ShowGridLines="True" 
                        Width="100%" OnSelectionChanged="Calendar1_SelectionChanged"
                        meta:resourcekey="Calendar1Resource1" SkinID="Chpt">                        
                        <WeekendDayStyle ForeColor="#CF0808" />
                    </asp:Calendar>
                </td>
                <td style="width: 20%" valign="top">
                    <h3>
                        <asp:Label ID="lblShowHeader1" runat="server" Text="當月請假統計" meta:resourcekey="lblShowHeader1Resource1"></asp:Label>
                    </h3>
                    <asp:GridView ID="AbsCountGV" runat="server" SkinID="Yahoo" AutoGenerateColumns="False"
                        meta:resourcekey="AbsCountGVResource1">
                        <Columns>
                            <asp:TemplateField HeaderText="假別" meta:resourcekey="TemplateFieldResource1">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" meta:resourcekey="TextBox1Resource1" Text='<%# Bind("h_name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" meta:resourcekey="LinkButton1Resource1"
                                        OnClick="LinkButton1_Click2" Text='<%# Bind("h_name") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tol_hours" HeaderText="時數" meta:resourcekey="BoundFieldResource1" />
                            <asp:BoundField DataField="unit" HeaderText="單位" meta:resourcekey="BoundFieldResource2" />
                        </Columns>
                        <EmptyDataRowStyle Font-Size="Medium" />
                    </asp:GridView>
                    <h3>
                        <asp:Label ID="lblShowHeader2" runat="server" Text="當月加班統計" meta:resourcekey="lblShowHeader2Resource1"></asp:Label>
                    </h3>
                    <asp:GridView ID="OtCountGV" runat="server" SkinID="Yahoo" AutoGenerateColumns="False"
                        meta:resourcekey="OtCountGVResource1">
                        <Columns>
                            <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" meta:resourcekey="TextBox1Resource2" Text='<%# Bind("ot_name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Select" meta:resourcekey="LinkButton2Resource1"
                                        OnClick="LinkButton2_Click" Text='<%# Bind("ot_name") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="hrs" HeaderText="時數" meta:resourcekey="BoundFieldResource3" />
                        </Columns>
                        <EmptyDataRowStyle Font-Size="Medium" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
            meta:resourcekey="GridView1Resource1">
            <Columns>
                <asp:BoundField DataField="D_NO_DISP" HeaderText="出勤部門" meta:resourcekey="BoundFieldResource4" />
                <asp:BoundField DataField="ROTENAME" HeaderText="出勤班別" meta:resourcekey="BoundFieldResource5" />
                <asp:BoundField DataField="attendcount" HeaderText="應出勤人數" meta:resourcekey="BoundFieldResource6" />
            </Columns>
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        <asp:Label ID="lbABS" runat="server" meta:resourcekey="lbABSResource1" 
            Text="加班"></asp:Label>
        <asp:GridView ID="absGV" runat="server" AutoGenerateColumns="False" 
            meta:resourceKey="absGVResource1" SkinID="Yahoo" Width="100%">
            <Columns>
                <asp:BoundField DataField="NOBR" HeaderText="NOBR" 
                    meta:resourceKey="BoundFieldResource7" SortExpression="NOBR" Visible="False" />
                <asp:BoundField DataField="NAME_C" HeaderText="員工" 
                    meta:resourceKey="BoundFieldResource8" SortExpression="NAME_C" />
                <asp:BoundField DataField="D_NAME" HeaderText="部門" 
                    meta:resourcekey="BoundFieldResource34" />
                <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" 
                    meta:resourceKey="BoundFieldResource9" SortExpression="JOB_NAME" />
                <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" 
                    meta:resourceKey="BoundFieldResource10" SortExpression="D_NAME" 
                    Visible="False" />
                <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" 
                    HeaderText="請假日期" HtmlEncode="False" meta:resourceKey="BoundFieldResource11" 
                    SortExpression="BDATE" />
                <asp:BoundField DataField="BTIME" HeaderText="開始時間" 
                    meta:resourceKey="BoundFieldResource12" SortExpression="BTIME" />
                <asp:BoundField DataField="ETIME" HeaderText="結束時間" 
                    meta:resourceKey="BoundFieldResource13" SortExpression="ETIME" />
                <asp:BoundField DataField="H_CODE" HeaderText="H_CODE" 
                    meta:resourceKey="BoundFieldResource14" SortExpression="H_CODE" 
                    Visible="False" />
                <asp:BoundField DataField="H_NAME" HeaderText="假別" 
                    meta:resourceKey="BoundFieldResource15" SortExpression="H_NAME" />
                <asp:BoundField DataField="UNIT" HeaderText="單位" 
                    meta:resourceKey="BoundFieldResource16" SortExpression="UNIT" />
                <asp:BoundField DataField="TOL_HOURS" HeaderText="請假小計" 
                    meta:resourceKey="BoundFieldResource17" SortExpression="TOL_HOURS" />
                <asp:BoundField DataField="TOL_DAY" HeaderText="請假天數" 
                    meta:resourceKey="BoundFieldResource18" SortExpression="TOL_DAY" 
                    Visible="False" />
                <asp:BoundField DataField="NOTE" HeaderText="備註" 
                    meta:resourceKey="BoundFieldResource19" SortExpression="NOTE" />
                <asp:BoundField DataField="YYMM" HeaderText="計薪年月" 
                    meta:resourceKey="BoundFieldResource20" SortExpression="YYMM" />
            </Columns>
            <EmptyDataRowStyle Font-Size="Small" />
            <EmptyDataTemplate>
                <asp:Label ID="lb_empty" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Red" meta:resourceKey="lb_emptyResource1" Text="＊請假無相關資料！！"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        <br />
        <asp:Label ID="lbOT" runat="server" meta:resourcekey="lbOTResource1" Text="加班"></asp:Label>
        <asp:GridView ID="otGV" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
            meta:resourcekey="otGVResource1" Width="100%">
            <Columns>
                <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" Visible="False"
                    meta:resourcekey="BoundFieldResource21" />
                <asp:BoundField DataField="NAME_C" HeaderText="員工" SortExpression="NAME_C" 
                    meta:resourcekey="BoundFieldResource22" >
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="D_NAME" HeaderText="部門" 
                    meta:resourcekey="BoundFieldResource35" />
                <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" SortExpression="JOB_NAME" meta:resourcekey="BoundFieldResource23" />
                <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" Visible="False"
                    meta:resourcekey="BoundFieldResource24" />
                <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="加班日期"
                    HtmlEncode="False" SortExpression="BDATE" meta:resourcekey="BoundFieldResource25" />
                <asp:BoundField DataField="BTIME" HeaderText="開始時間" SortExpression="BTIME" meta:resourcekey="BoundFieldResource26" />
                <asp:BoundField DataField="ETIME" HeaderText="結束時間" SortExpression="ETIME" meta:resourcekey="BoundFieldResource27" />
                <asp:BoundField DataField="TOT_HOURS" HeaderText="總時數" SortExpression="TOT_HOURS"
                    meta:resourcekey="BoundFieldResource28" />
                <asp:BoundField DataField="OT_HRS" HeaderText="加班小計" SortExpression="OT_HRS" meta:resourcekey="BoundFieldResource29" />
                <asp:BoundField DataField="REST_HRS" HeaderText="補休小計" SortExpression="REST_HRS"
                    meta:resourcekey="BoundFieldResource30" />
                <asp:BoundField DataField="OTRNAME" HeaderText="加班原因" SortExpression="OTRNAME" meta:resourcekey="BoundFieldResource31" />
                <asp:BoundField DataField="NOTE" HeaderText="備註" SortExpression="NOTE" 
                    meta:resourcekey="BoundFieldResource32" >
                <ItemStyle Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" meta:resourcekey="BoundFieldResource33" />
            </Columns>
            <EmptyDataRowStyle Font-Size="Small" />
            <EmptyDataTemplate>
                <asp:Label ID="lb_empty1" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊加班無相關資料！！"
                    meta:resourcekey="lb_empty1Resource1"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回行事曆" 
            meta:resourcekey="Button1Resource2" Height="21px" /></asp:View>
</asp:MultiView>
<asp:Label ID="lblDept" runat="server" meta:resourcekey="lblDeptResource1" Visible="False"></asp:Label>
<br />
<telerik:RadDatePicker ID="adate" runat="server" Visible="False" Culture="zh-TW"
    meta:resourcekey="adateResource1" Skin="">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
        ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" DisplayText="" 
        LabelWidth="64px" Width=""></DateInput>

<DatePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
<telerik:RadDatePicker ID="ddate" runat="server" Visible="False" Culture="zh-TW"
    meta:resourcekey="ddateResource1" Skin="">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
        ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" DisplayText="" 
        LabelWidth="64px" Width=""></DateInput>

<DatePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
<telerik:RadAjaxLoadingPanel ID="AjaxLoadingPanel1" runat="server" Height="75px"
    Width="75px" meta:resourcekey="AjaxLoadingPanel1Resource1">
    <asp:Image ID="Image1" runat="server" AlternateText="Loading..." ImageUrl="~/RadControls/Ajax/Skins/Default/Loading.gif"
        meta:resourcekey="Image1Resource1" />
</telerik:RadAjaxLoadingPanel>
