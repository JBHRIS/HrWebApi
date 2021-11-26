<%@ Control Language="C#" AutoEventWireup="true" CodeFile="calendarList.ascx.cs"
    Inherits="calendarList" %>
    <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div class="GreenForm">
    <div class="GreenFormHeader">
        <span class="GHLeft"></span><span class="GHeader">員工到離職行事曆</span> <span class="GHRight">
        </span>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
            meta:resourcekey="RadAjaxManager1Resource1">
        </telerik:RadAjaxManager>
    </div>
    <div class="GreenFormContent">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" 
            HorizontalAlign="NotSet" LoadingPanelID="" 
            meta:resourcekey="RadAjaxPanel1Resource1" ScrollBars="None">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    &nbsp;<table width="100%">
                        <tr>
                            <td valign="top">
        <asp:Calendar ID="Calendar1" runat="server" BorderColor="#C1CDD8" BorderWidth="0px"
            CellPadding="0" CssClass="offWhtBg" NextMonthText='下個月<IMG tabIndex="1" height="12" alt="下個月" src="files/arrow_right.gif" width="7" align="absMiddle" border="0">'
            OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
            OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" PrevMonthText='<IMG tabIndex="1" height="12" alt="下個月" src="files/arrow_left.gif" width="7" align="absMiddle" border="0">上個月'
            SelectWeekText=">>" ShowGridLines="True" Width="100%" meta:resourcekey="Calendar1Resource1" 
                                    SkinID="Chpt">
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
                                <div class="BlueForm">
                                    <div class="BlueFormHeader">
                                        <span class="BHLeft"></span><span class="BHeader">
                                            <asp:Label ID="lblEmpTts" runat="server" Text="當月員工異動統計" 
                                            meta:resourcekey="lblEmpTtsResource1"></asp:Label></span> <span class="BHRight">
                                        </span>
                                    </div>
                                    <div class="BlueFormContent">
                    <asp:GridView ID="BdtGV" runat="server" AutoGenerateColumns="False" SkinID="Yahoo" 
                                            meta:resourcekey="BdtGVResource1">
                        <Columns>
                            <asp:TemplateField HeaderText="異動狀態" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" OnClick="LinkButton1_Click"
                                        Text='<%# Bind("ttsdesc") %>' meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" meta:resourcekey="TextBox1Resource1" 
                                        Text='<%# Bind("ttsdesc") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="count" HeaderText="人數" 
                                meta:resourcekey="BoundFieldResource1" />
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
                    <asp:GridView ID="baseGV" runat="server" AutoGenerateColumns="False" 
                        SkinID="Yahoo" meta:resourcekey="baseGVResource1">
                        <Columns>
                            <asp:BoundField DataField="Adate" HeaderText="生效日期" 
                                meta:resourcekey="BoundFieldResource2" />
                            <asp:BoundField DataField="TTSDESC" HeaderText="異動狀態" 
                                meta:resourcekey="BoundFieldResource3" />
                            <asp:BoundField DataField="nobr" HeaderText="員工編號" 
                                meta:resourcekey="BoundFieldResource4" />
                            <asp:BoundField DataField="name_c" HeaderText="員工姓名" 
                                meta:resourcekey="BoundFieldResource5" />
                            <asp:BoundField DataField="d_name" HeaderText="部門" 
                                meta:resourcekey="BoundFieldResource6" />
                            <asp:BoundField DataField="job_name" HeaderText="職稱" 
                                meta:resourcekey="BoundFieldResource7" />
                            <asp:BoundField DataField="empdescr" HeaderText="員別" 
                                meta:resourcekey="BoundFieldResource8" />
                            <asp:BoundField DataField="mang" HeaderText="主管" 
                                meta:resourcekey="BoundFieldResource9" />
                            <asp:BoundField DataField="di" HeaderText="直/間接" 
                                meta:resourcekey="BoundFieldResource10" />
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回行事曆" 
                        meta:resourcekey="Button1Resource2" /></asp:View>
            </asp:MultiView></telerik:RadAjaxPanel>
    </div>
    <div class="GreenFormFooter">
        <span class="GFLeft"></span><span class="GFRight"></span>
    </div>
</div>

