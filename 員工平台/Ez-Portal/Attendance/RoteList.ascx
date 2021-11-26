<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoteList.ascx.cs" Inherits="Attendance_RoteList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../Account/AccountPictureBind.ascx" TagName="accountpicture1" TagPrefix="uc2" %>
<h3>
    <asp:Label ID="lblShowStaffShiftHeader" runat="server" Text="員工出勤資料" meta:resourcekey="lblShowStaffShiftHeaderResource1"></asp:Label></h3>
<asp:Button ID="btnPrint" runat="server" Text="友善列印" OnClick="btnPrint_Click" 
    meta:resourcekey="btnPrintResource1" Visible="False" />
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <table width="97%">
            <tr>
                <td valign="top">
<%--                    <fieldset>
                        <table width="100%">
                            <tr>
                                <td valign="top" width="200">
                                    <uc2:accountpicture1 ID="AccountPicture1_1" runat="server" Visible="false" />
                                </td>
                                <td valign="top">
                                    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="LightGoldenrodYellow"
                                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource2"
                                        Font-Size="X-Small" ForeColor="Black" GridLines="None" Width="200px" meta:resourcekey="DetailsView1Resource1">
                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                        <Fields>
                                            <asp:BoundField DataField="NOBR" HeaderText="員工工號" meta:resourcekey="BoundFieldResource1"
                                                SortExpression="NOBR" />
                                            <asp:BoundField DataField="NAME_C" HeaderText="中文姓名" meta:resourcekey="BoundFieldResource2"
                                                SortExpression="NAME_C" />
                                            <asp:BoundField DataField="NAME_E" HeaderText="英文姓名" meta:resourcekey="BoundFieldResource12" />
                                            <asp:BoundField DataField="COMPNAME" HeaderText="公司" meta:resourcekey="BoundFieldResource3"
                                                SortExpression="COMPNAME" Visible="False" />
                                            <asp:BoundField DataField="D_NAME" HeaderText="部門" meta:resourcekey="BoundFieldResource4"
                                                SortExpression="D_NAME" />
                                            <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" meta:resourcekey="BoundFieldResource5"
                                                SortExpression="JOB_NAME" />
                                        </Fields>
                                        <FooterStyle BackColor="Tan" />
                                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    </asp:DetailsView>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                                        SelectCommand="SELECT BASE.NOBR, BASE.NAME_C, BASE.NAME_E, COMP.COMPNAME, DEPT.D_NAME, JOB.JOB_NAME FROM BASE INNER JOIN BASETTS ON BASE.NOBR = BASETTS.NOBR INNER JOIN JOB ON BASETTS.JOB = JOB.JOB LEFT OUTER JOIN COMP ON BASETTS.COMP = COMP.COMP LEFT OUTER JOIN DEPT ON BASETTS.DEPT = DEPT.D_NO WHERE (BASE.NOBR = @NOBR) AND (GETDATE() BETWEEN BASETTS.ADATE AND BASETTS.DDATE)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="lb_nobr" Name="NOBR" PropertyName="Text" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td valign="top">
                                    <asp:Panel ID="Panel1" runat="server" Visible="False" meta:resourcekey="Panel1Resource1">
                                        <table class="Mytable td" style="width: 30%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblShowHoliDayAmt" runat="server" Text="當月應休" meta:resourcekey="lblShowHoliDayAmtResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lb_Holi" runat="server" ForeColor="#0000CC" Text="0" meta:resourcekey="lb_HoliResource1"></asp:Label>
                                                    &nbsp;<asp:Label ID="lblShowUnit" runat="server" Text="日" meta:resourcekey="lblShowUnitResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblShowBeenOnLeaveAmt" runat="server" Text="當月已休" meta:resourcekey="lblShowBeenOnLeaveAmtResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lb_attHoli" runat="server" ForeColor="Red" Text="0" meta:resourcekey="lb_attHoliResource1"></asp:Label>
                                                    &nbsp;<asp:Label ID="lblShowUnit2" runat="server" Text="日" meta:resourcekey="lblShowUnit2Resource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblShowForgetSwipeCardTimes" runat="server" Text="忘刷卡" meta:resourcekey="lblShowForgetSwipeCardTimesResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Red" Text="0" meta:resourcekey="Label5Resource1"></asp:Label>
                                                    &nbsp;<asp:Label ID="Label17" runat="server" Font-Bold="True" Text=",扣假" Visible="False"
                                                        meta:resourcekey="Label17Resource1"></asp:Label>
                                                    <asp:Label ID="A3" runat="server" Font-Bold="True" ForeColor="Red" Text="0" Visible="False"
                                                        meta:resourcekey="A3Resource1"></asp:Label>
                                                    <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="日" Visible="False"
                                                        meta:resourcekey="Label19Resource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblShowTardy" runat="server" Text="遲到" meta:resourcekey="lblShowTardyResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Text="0" meta:resourcekey="Label3Resource1"></asp:Label>
                                                    &nbsp;<asp:Label ID="Label11" runat="server" Font-Bold="True" Text=",扣假" Visible="False"
                                                        meta:resourcekey="Label11Resource1"></asp:Label>
                                                    <asp:Label ID="A1" runat="server" Font-Bold="True" ForeColor="Red" Text="0" Visible="False"
                                                        meta:resourcekey="A1Resource1"></asp:Label>
                                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="日" Visible="False"
                                                        meta:resourcekey="Label13Resource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblShowEarlyLeave" runat="server" Text="早退" meta:resourcekey="lblShowEarlyLeaveResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Red" Text="0" meta:resourcekey="Label4Resource1"></asp:Label>
                                                    &nbsp;<asp:Label ID="Label14" runat="server" Font-Bold="True" Text=",扣假" Visible="False"
                                                        meta:resourcekey="Label14Resource1"></asp:Label>
                                                    <asp:Label ID="A2" runat="server" Font-Bold="True" ForeColor="Red" Text="0" Visible="False"
                                                        meta:resourcekey="A2Resource1"></asp:Label>
                                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="日" Visible="False"
                                                        meta:resourcekey="Label16Resource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblShowOverTime" runat="server" Text="加班" meta:resourcekey="lblShowOverTimeResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lb_ot" runat="server" Text="0" meta:resourcekey="lb_otResource1"></asp:Label>
                                                    &nbsp;<asp:Label ID="lblShowUnit3" runat="server" Text="日" meta:resourcekey="lblShowUnit3Resource1"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lbl_remainDays" runat="server" Text="0" Visible="False" meta:resourcekey="lbl_remainDaysResource1"></asp:Label>
                                        <asp:Label ID="lb_TotMealMoney" runat="server" Text="0" Visible="False" meta:resourcekey="lb_TotMealMoneyResource1"></asp:Label>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </fieldset>--%>
                    <asp:Calendar ID="Calendar1" runat="server" BorderColor="#C1CDD8" BorderWidth="0px"
                        CellPadding="0" NextMonthText='&gt;' OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
                        OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" PrevMonthText='&lt;' SelectWeekText=">>"
                        ShowGridLines="True" Width="100%" OnDataBinding="Calendar1_DataBinding" OnPreRender="Calendar1_PreRender"
                        meta:resourcekey="Calendar1Resource1" SkinID="Chpt">
                        <DayHeaderStyle BorderWidth="1px" CssClass="titlelistTD" />
                        <DayStyle BorderWidth="1px" Font-Bold="True" ForeColor="#0000C0" HorizontalAlign="Right"
                            VerticalAlign="Top" Width="10%" />
                        <OtherMonthDayStyle Font-Size="10pt" />
                        <SelectedDayStyle BackColor="#FFFAE0" ForeColor="Black" />
                        <TitleStyle BackColor="White" BorderColor="#C1CDD8" BorderStyle="None" BorderWidth="1px"
                            ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:Calendar>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        SkinID="Yahoo" OnPageIndexChanging="GridView2_PageIndexChanging" Visible="False"
                        meta:resourcekey="GridView2Resource1">
                        <Columns>
                            <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" Visible="False"
                                meta:resourcekey="BoundFieldResource6" />
                            <asp:BoundField DataField="NAME_C" HeaderText="員工" SortExpression="NAME_C" meta:resourcekey="BoundFieldResource7" />
                            <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" SortExpression="JOB_NAME" meta:resourcekey="BoundFieldResource8" />
                            <asp:BoundField DataField="ADATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="出勤日期"
                                HtmlEncode="False" SortExpression="ADATE" meta:resourcekey="BoundFieldResource9" />
                            <asp:BoundField DataField="ROTE" HeaderText="班別" SortExpression="ROTE" meta:resourcekey="BoundFieldResource10" />
                            <asp:BoundField DataField="ROTENAME" HeaderText="班別名稱" SortExpression="ROTENAME"
                                meta:resourcekey="BoundFieldResource11" />
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red"
                                Text="＊無相關資料！！" meta:resourcekey="lb_emptyResource1"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:Label ID="Label1" runat="server" Text="出勤日期：" Visible="False" meta:resourcekey="Label1Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="adate" runat="server" Visible="False" Culture="Chinese (Taiwan)"
                        meta:resourcekey="adateResource1">
                        <DateInput Skin="" /></telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                        ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Visible="False" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label2" runat="server" Text="至" Visible="False" meta:resourcekey="Label2Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="ddate" runat="server" Visible="False" Culture="Chinese (Taiwan)"
                        meta:resourcekey="ddateResource1">
                        <DateInput Skin="" /></telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                        ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Visible="False" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                        Visible="False" meta:resourcekey="Button1Resource1" /><asp:Label ID="lb_nobr" runat="server"
                            Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        &nbsp;<fieldset>
            <legend>
                <asp:Label ID="lblShiftManageHeader" runat="server" Text="上班班別維護" meta:resourcekey="lblShiftManageHeaderResource1"></asp:Label></legend>
            <br />
            <asp:Label ID="lblShowModifyDate" runat="server" Text="異動日期：" meta:resourcekey="lblShowModifyDateResource1"></asp:Label>
            <asp:Label ID="b_adate" runat="server" meta:resourcekey="b_adateResource1"></asp:Label><br />
            <asp:Label ID="lblShowOrgShift" runat="server" Text="原別時段：" meta:resourcekey="lblShowOrgShiftResource1"></asp:Label>
            &nbsp;
            <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="專職常日班0800~1530" meta:resourcekey="Label6Resource1"></asp:Label><br />
            <asp:Label ID="lblShowChangedShift" runat="server" Text="異動後班別：" meta:resourcekey="lblShowChangedShiftResource1"></asp:Label>
            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1"
                DataTextField="ROTENAME" DataValueField="ROTE" meta:resourcekey="DropDownList3Resource1">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblShowComment" runat="server" Text="備註：" meta:resourcekey="lblShowCommentResource1"></asp:Label>
            <asp:TextBox ID="note" runat="server" Width="330px" meta:resourcekey="noteResource1"></asp:TextBox>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT     RTRIM(ROTE) AS ROTE, ROTE + '-' + ROTENAME AS ROTENAME FROM         ROTE">
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" OnClientClick="return confirm('確認填寫完成！');"
                Text="確認" meta:resourcekey="Button2Resource1" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="取消" meta:resourcekey="Button3Resource1" /><br />
            <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="※請先選先日期，再輸入時間！" meta:resourcekey="Label8Resource1"></asp:Label></fieldset>
    </asp:View>
</asp:MultiView>
