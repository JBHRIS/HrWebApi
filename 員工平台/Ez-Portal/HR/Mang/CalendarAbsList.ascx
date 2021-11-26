<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarAbsList.ascx.cs" Inherits="CalendarAbsList" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div class="GreenForm">
    <div class="GreenFormHeader">
        <span class="GHLeft"></span><span class="GHeader">加班請假行事曆</span> <span class="GHRight">
        </span>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
            meta:resourcekey="RadAjaxManager1Resource1">
        </telerik:RadAjaxManager>
    </div>
    <div class="GreenFormContent">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" 
            LoadingPanelID="AjaxLoadingPanel1" HorizontalAlign="NotSet" 
            meta:resourcekey="RadAjaxPanel1Resource1" ScrollBars="None">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <table width="100%" >
                <tr>
                <td valign="top">
                    &nbsp;<asp:Calendar ID="Calendar1" runat="server" BorderColor="#C1CDD8" BorderWidth="0px"
            CellPadding="0" CssClass="offWhtBg" NextMonthText='下個月<IMG tabIndex="1" height="12" alt="下個月" src="files/arrow_right.gif" width="7" align="absMiddle" border="0">'
            OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged"
            
                        PrevMonthText='<IMG tabIndex="1" height="12" alt="下個月" src="files/arrow_left.gif" width="7" align="absMiddle" border="0">上個月' 
                        SelectWeekText=">>" ShowGridLines="True" Width="100%" 
                        OnSelectionChanged="Calendar1_SelectionChanged" 
                        meta:resourcekey="Calendar1Resource1" SkinID="Chpt">
            <DayHeaderStyle BorderWidth="1px" CssClass="titlelistTD" />
                        <DayStyle BorderWidth="1px" Font-Bold="True" Font-Size="18px" 
                            ForeColor="#0000C0" Height="70px" HorizontalAlign="Right" VerticalAlign="Top" 
                            Width="10%" />
                        <OtherMonthDayStyle CssClass="notCurMonDate" Font-Size="10pt" />
            <SelectedDayStyle BackColor="#FFFAE0" ForeColor="Black" />
            <TitleStyle BackColor="White" BorderColor="#C1CDD8" BorderStyle="None" BorderWidth="1px"
                Font-Size="17pt" ForeColor="Black" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:Calendar>
                </td>
                <td style="width: 20%" valign="top">
                    &nbsp;<div class="BlueForm">
                        <div class="BlueFormHeader">
                            <span class="BHLeft"></span><span class="BHeader">
                                <asp:Label ID="lblLeaveMonth" runat="server" Text="當月請假統計" 
                                meta:resourcekey="lblLeaveMonthResource1"></asp:Label></span> <span class="BHRight">
                            </span>
                        </div>
                        <div class="BlueFormContent">
                <asp:GridView ID="AbsCountGV" runat="server" SkinID="Yahoo" AutoGenerateColumns="False" 
                                meta:resourcekey="AbsCountGVResource1">
                    <Columns>
                        <asp:TemplateField HeaderText="假別" meta:resourcekey="TemplateFieldResource1">
                            <ItemTemplate>
                                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" OnClick="LinkButton1_Click2"
                                    Text='<%# Bind("h_name") %>' meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" meta:resourcekey="TextBox1Resource1" 
                                    Text='<%# Bind("h_name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="tol_hours" HeaderText="時數" 
                            meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="unit" HeaderText="單位" 
                            meta:resourcekey="BoundFieldResource2" />
                    </Columns>
                </asp:GridView>
                            &nbsp;</div>
                        <div class="BlueFormFooter">
                            <span class="BFLeft"></span><span class="BFRight"></span>
                        </div>
                    </div>
                    &nbsp;<div class="BlueForm">
                        <div class="BlueFormHeader">
                            <span class="BHLeft"></span><span class="BHeader">
                                <asp:Label ID="lblOT" runat="server" Text="當月加班統計" 
                                meta:resourcekey="lblOTResource1"></asp:Label></span> <span class="BHRight">
                            </span>
                        </div>
                        <div class="BlueFormContent">
                <asp:GridView ID="OtCountGV" runat="server" SkinID="Yahoo" AutoGenerateColumns="False" 
                                meta:resourcekey="OtCountGVResource1">
                    <Columns>
                        <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                            <ItemTemplate>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CommandName="Select" OnClick="LinkButton2_Click"
                                    Text='<%# Bind("ot_name") %>' meta:resourcekey="LinkButton2Resource1"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" meta:resourcekey="TextBox1Resource2" 
                                    Text='<%# Bind("ot_name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="hrs" HeaderText="時數" 
                            meta:resourcekey="BoundFieldResource3" />
                    </Columns>
                </asp:GridView>
                    &nbsp;</div>
                        <div class="BlueFormFooter">
                            <span class="BFLeft"></span><span class="BFRight"></span>
                        </div>
                    </div>
                    &nbsp;
                </td>
                </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    SkinID="Yahoo" meta:resourcekey="GridView1Resource1">
                    <Columns>
                        <asp:BoundField DataField="DEPT" HeaderText="出勤部門" 
                            meta:resourcekey="BoundFieldResource4" />
                        <asp:BoundField DataField="ROTENAME" HeaderText="出勤班別" 
                            meta:resourcekey="BoundFieldResource5" />
                        <asp:BoundField DataField="attendcount" HeaderText="應出勤人數" 
                            meta:resourcekey="BoundFieldResource6" />
                    </Columns>
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView>
                <asp:GridView ID="absGV" runat="server" AutoGenerateColumns="False" 
                    SkinID="Yahoo" meta:resourcekey="absGVResource1">
                    <Columns>
                        <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" 
                            Visible="False" meta:resourcekey="BoundFieldResource7" />
                        <asp:BoundField DataField="NAME_C" HeaderText="員工" SortExpression="NAME_C" 
                            meta:resourcekey="BoundFieldResource8" />
                        <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" SortExpression="JOB_NAME" 
                            meta:resourcekey="BoundFieldResource9" />
                        <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" 
                            Visible="False" meta:resourcekey="BoundFieldResource10" />
                        <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="請假日期"
                            HtmlEncode="False" SortExpression="BDATE" 
                            meta:resourcekey="BoundFieldResource11" />
                        <asp:BoundField DataField="BTIME" HeaderText="開始時間" SortExpression="BTIME" 
                            meta:resourcekey="BoundFieldResource12" />
                        <asp:BoundField DataField="ETIME" HeaderText="結束時間" SortExpression="ETIME" 
                            meta:resourcekey="BoundFieldResource13" />
                        <asp:BoundField DataField="H_CODE" HeaderText="H_CODE" SortExpression="H_CODE" 
                            Visible="False" meta:resourcekey="BoundFieldResource14" />
                        <asp:BoundField DataField="H_NAME" HeaderText="假別" SortExpression="H_NAME" 
                            meta:resourcekey="BoundFieldResource15" />
                        <asp:BoundField DataField="UNIT" HeaderText="單位" SortExpression="UNIT" 
                            meta:resourcekey="BoundFieldResource16" />
                        <asp:BoundField DataField="TOL_HOURS" HeaderText="請假時數" 
                            SortExpression="TOL_HOURS" meta:resourcekey="BoundFieldResource17" />
                        <asp:BoundField DataField="TOL_DAY" HeaderText="請假天數" SortExpression="TOL_DAY" 
                            meta:resourcekey="BoundFieldResource18" />
                        <asp:BoundField DataField="NOTE" HeaderText="備註" SortExpression="NOTE" 
                            meta:resourcekey="BoundFieldResource19" />
                        <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" 
                            meta:resourcekey="BoundFieldResource20" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                            Text="＊請假無相關資料！！" meta:resourcekey="lb_emptyResource1"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:GridView ID="otGV" runat="server" AutoGenerateColumns="False" 
                    SkinID="Yahoo" meta:resourcekey="otGVResource1">
                    <Columns>
                        <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" 
                            Visible="False" meta:resourcekey="BoundFieldResource21" />
                        <asp:BoundField DataField="NAME_C" HeaderText="員工" SortExpression="NAME_C" 
                            meta:resourcekey="BoundFieldResource22" />
                        <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" SortExpression="JOB_NAME" 
                            meta:resourcekey="BoundFieldResource23" />
                        <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" 
                            Visible="False" meta:resourcekey="BoundFieldResource24" />
                        <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="加班日期"
                            HtmlEncode="False" SortExpression="BDATE" 
                            meta:resourcekey="BoundFieldResource25" />
                        <asp:BoundField DataField="BTIME" HeaderText="開始時間" SortExpression="BTIME" 
                            meta:resourcekey="BoundFieldResource26" />
                        <asp:BoundField DataField="ETIME" HeaderText="結束時間" SortExpression="ETIME" 
                            meta:resourcekey="BoundFieldResource27" />
                        <asp:BoundField DataField="TOT_HOURS" HeaderText="總時數" 
                            SortExpression="TOT_HOURS" meta:resourcekey="BoundFieldResource28" />
                        <asp:BoundField DataField="OT_HRS" HeaderText="加班時數" SortExpression="OT_HRS" 
                            meta:resourcekey="BoundFieldResource29" />
                        <asp:BoundField DataField="REST_HRS" HeaderText="補休時數" 
                            SortExpression="REST_HRS" meta:resourcekey="BoundFieldResource30" />
                        <asp:BoundField DataField="OTRNAME" HeaderText="加班原因" SortExpression="OTRNAME" 
                            meta:resourcekey="BoundFieldResource31" />
                        <asp:BoundField DataField="NOTE" HeaderText="備註" SortExpression="NOTE" 
                            meta:resourcekey="BoundFieldResource32" />
                        <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" 
                            meta:resourcekey="BoundFieldResource33" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lb_empty1" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                            Text="＊加班無相關資料！！" meta:resourcekey="lb_empty1Resource1"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回行事曆" 
                    meta:resourcekey="Button1Resource2" /></asp:View>
        </asp:MultiView></telerik:RadAjaxPanel>
        <telerik:RadAjaxLoadingPanel ID="AjaxLoadingPanel1" runat="server" Height="75px" 
            Width="75px" meta:resourcekey="AjaxLoadingPanel1Resource1">
            <asp:Image ID="Image1" runat="server" AlternateText="Loading..." 
                meta:resourcekey="Image1Resource1" />
        </telerik:RadAjaxLoadingPanel >
        <br />
        </div>
    <div class="GreenFormFooter">
        <span class="GFLeft"></span><span class="GFRight"></span>
    </div>
</div>
