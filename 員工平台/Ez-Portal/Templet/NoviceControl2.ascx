<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NoviceControl2.ascx.cs"
    Inherits="Templet_NoviceControl2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
<h3>
            <telerik:RadButton ID="btnHeader" runat="server" ButtonType="ToggleButton" Text="新進人員"
            Font-Size="14px" OnCheckedChanged="btnHeader_CheckedChanged" Skin="Simple"
            ToggleType="CheckBox" Font-Names="微軟正黑體,arial" HoveredCssClass="Home">
        </telerik:RadButton>
</h3>
<asp:DataList ID="DataList1" runat="server" OnDataBinding="DataList1_DataBinding"
    OnItemDataBound="DataList1_ItemDataBound" 
    meta:resourcekey="DataList1Resource1" Visible="False">
    <ItemTemplate>
        <fieldset>
            <table width="100%">
                <tr>
                    <td width="80">
                        <asp:Image ID="Image1" runat="server" Height="120px" Width="90px" AlternateText='<%# Eval("nobr") %>'
                            ImageUrl="~/Images/stick_on_picture.gif" meta:resourcekey="Image1Resource1" />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" ForeColor="Blue" Text="部門：" meta:resourcekey="Label5Resource1"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("d_name") %>' ForeColor="Blue"
                            meta:resourcekey="Label1Resource1"></asp:Label><br />
                        <asp:Label ID="Label6" runat="server" ForeColor="Blue" Text="姓名：" meta:resourcekey="Label6Resource1"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("name_c") %>' ForeColor="Blue"
                            meta:resourcekey="Label2Resource1"></asp:Label>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="英文名：" meta:resourcekey="Label9Resource1"></asp:Label>
                        <asp:Label ID="lblNameE" runat="server" Text='<%# Eval("name_e") %>' meta:resourcekey="lblNameEResource1"></asp:Label>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="工號：" meta:resourcekey="Label7Resource1"></asp:Label>
                        <asp:Label ID="lblNobr" runat="server" Text='<%# Eval("nobr") %>' meta:resourcekey="lblNobrResource1"></asp:Label>
                        <br />
                        <asp:Label ID="lblShowJobTitle" runat="server" Text="職稱" meta:resourcekey="lblShowJobTitleResource1"
                            Visible="False"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("JOB_NAME") %>' meta:resourcekey="Label3Resource1"
                            Visible="False"></asp:Label><br />
                        <asp:Label ID="lblShowBeginWork" runat="server" Text="到職日：" meta:resourcekey="lblShowBeginWorkResource1"></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("adate","{0:yyyy/MM/dd}") %>'
                            meta:resourcekey="Label4Resource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </ItemTemplate>
</asp:DataList>
<asp:Label ID="lblCurPage" runat="server" 
    meta:resourcekey="lblCurPageResource1" Visible="False"></asp:Label>
<asp:HyperLink ID="lnkPrev" runat="server" meta:resourcekey="lnkPrevResource1" Visible="False">上一頁</asp:HyperLink>
<asp:HyperLink ID="lnkNext" runat="server" meta:resourcekey="lnkNextResource1" Visible="False">下一頁</asp:HyperLink>
<asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
<telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" 
    CellSpacing="0" Culture="zh-TW" GridLines="None" Skin="Simple" Visible="False">
    <ClientSettings>
        <Scrolling AllowScroll="True" />
    </ClientSettings>
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn FilterControlAltText="Filter d_name column" 
            UniqueName="d_name" DataField="d_name" HeaderText="部門">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter nobr column" 
            UniqueName="nobr" DataField="nobr" HeaderText="工號" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter name_c column" 
            UniqueName="name_c" DataField="name_c" HeaderText="姓名">
        </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter name_c column" 
            UniqueName="adate" DataField="adate" DataFormatString="{0:d}" HeaderText="到職日期">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
</telerik:RadGrid>
</telerik:RadAjaxPanel>