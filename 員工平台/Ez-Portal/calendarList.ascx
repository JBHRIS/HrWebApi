<%@ Control Language="C#" AutoEventWireup="true" CodeFile="calendarList.ascx.cs"
    Inherits="CalendarList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="BlueForm">
    <div class="BlueFormHeader">
        <span class="BHLeft"></span><span class="BHeader">
            <asp:Label ID="lblPersonnelChangeHeader" runat="server" Text="員工到離職行事曆" meta:resourcekey="lblPersonnelChangeHeaderResource1"></asp:Label></span>
        <span class="BHRight"></span>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" meta:resourcekey="RadAjaxManager1Resource1">
        </telerik:RadAjaxManager>
    </div>
    <div class="BlueFormContent">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet"
            LoadingPanelID="" meta:resourcekey="RadAjaxPanel1Resource1" ScrollBars="None">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    &nbsp;<asp:Label ID="lblJumpYYMM" runat="server" Text="跳轉至" meta:resourcekey="lblJumpYYMMResource1"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                        meta:resourcekey="ddlYearResource1">
                    </asp:DropDownList>
                    &nbsp;<asp:Label ID="lblYear" runat="server" Text="年" meta:resourcekey="lblYearResource1"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                        meta:resourcekey="ddlMonthResource1">
                        <asp:ListItem meta:resourcekey="ListItemResource1">1</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource2">2</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource3">3</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource4">4</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource5">5</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource6">6</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource7">7</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource8">8</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource9">9</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource10">10</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource11">11</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource12">12</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:Label ID="lblMonth" runat="server" Text="月" meta:resourcekey="lblMonthResource1"></asp:Label>
                    <table width="100%">
                        <tr>
                            <td valign="top">
                                <asp:Calendar ID="Calendar1" runat="server" BorderColor="#C1CDD8" BorderWidth="0px"
                                    CellPadding="0" CssClass="offWhtBg" meta:resourceKey="Calendar1Resource1" NextMonthText="下個月&lt;IMG tabIndex=&quot;1&quot; height=&quot;12&quot; alt=&quot;下個月&quot; src=&quot;files/arrow_right.gif&quot; width=&quot;7&quot; align=&quot;absMiddle&quot; border=&quot;0&quot;&gt;"
                                    OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
                                    OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" PrevMonthText="&lt;IMG tabIndex=&quot;1&quot; height=&quot;12&quot; alt=&quot;下個月&quot; src=&quot;files/arrow_left.gif&quot; width=&quot;7&quot; align=&quot;absMiddle&quot; border=&quot;0&quot;&gt;上個月"
                                    SelectWeekText="&gt;&gt;" ShowGridLines="True" Width="100%">
                                    <DayHeaderStyle BorderWidth="1px" CssClass="titlelistTD" />
                                    <DayStyle BorderWidth="1px" Font-Bold="True" Font-Size="18px" ForeColor="#0000C0"
                                        Height="70px" HorizontalAlign="Right" VerticalAlign="Top" Width="10%" />
                                    <OtherMonthDayStyle CssClass="notCurMonDate" Font-Size="10pt" />
                                    <SelectedDayStyle BackColor="#FFFAE0" ForeColor="Black" />
                                    <TitleStyle BackColor="White" BorderColor="#C1CDD8" BorderStyle="None" BorderWidth="1px"
                                        Font-Size="17pt" ForeColor="Black" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:Calendar>
                            </td>
                            <td style="width: 20%" valign="top">
                                <div class="BlueForm">
                                    <div class="BlueFormHeader">
                                        <span class="BHLeft"></span><span class="BHeader">
                                            <asp:Label ID="lblChangeHeader" runat="server" meta:resourceKey="lblChangeHeaderResource1"
                                                Text="當月員工異動統計"></asp:Label>
                                        </span><span class="BHRight"></span>
                                    </div>
                                    <div class="BlueFormContent">
                                        <asp:GridView ID="BdtGV" runat="server" AutoGenerateColumns="False" meta:resourceKey="BdtGVResource1"
                                            SkinID="Yahoo">
                                            <Columns>
                                                <asp:TemplateField HeaderText="異動狀態" meta:resourceKey="TemplateFieldResource1">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" meta:resourceKey="TextBox1Resource1" Text='<%# Bind("ttsdesc") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" meta:resourceKey="LinkButton1Resource1"
                                                            OnClick="LinkButton1_Click" Text='<%# Bind("ttsdesc") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="count" HeaderText="人數" meta:resourceKey="BoundFieldResource1" />
                                            </Columns>
                                        </asp:GridView>
                                        &nbsp;</div>
                                    <div class="BlueFormFooter">
                                        <span class="BFLeft"></span><span class="BFRight"></span>
                                    </div>
                                </div>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    &nbsp;<br />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:GridView ID="baseGV" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                        meta:resourceKey="baseGVResource1">
                        <Columns>
                            <asp:BoundField DataField="Adate" HeaderText="生效日期" meta:resourceKey="BoundFieldResource2" />
                            <asp:BoundField DataField="TTSDESC" HeaderText="異動狀態" meta:resourceKey="BoundFieldResource3" />
                            <asp:BoundField DataField="nobr" HeaderText="員工編號" meta:resourceKey="BoundFieldResource4" />
                            <asp:BoundField DataField="name_c" HeaderText="員工姓名" meta:resourceKey="BoundFieldResource5" />
                            <asp:BoundField DataField="d_name" HeaderText="部門" meta:resourceKey="BoundFieldResource6" />
                            <asp:BoundField DataField="job_name" HeaderText="職稱" meta:resourceKey="BoundFieldResource7" />
                            <asp:BoundField DataField="empdescr" HeaderText="員別" meta:resourceKey="BoundFieldResource8" />
                            <asp:BoundField DataField="mang" HeaderText="主管" meta:resourceKey="BoundFieldResource9" />
                            <asp:BoundField DataField="di" HeaderText="直/間接" meta:resourceKey="BoundFieldResource10" />
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回行事曆" meta:resourceKey="Button1Resource2" />
                    <asp:Label ID="lblDept" runat="server" Visible="False" meta:resourceKey="lblDeptResource1"></asp:Label>
                </asp:View>
            </asp:MultiView></telerik:RadAjaxPanel>
    </div>
    <div class="BlueFormFooter">
        <span class="BFLeft"></span><span class="BFRight"></span>
    </div>
</div>
