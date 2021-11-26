<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SiteMapConfig.aspx.cs" Inherits="HR_Mang_SiteMapConfig" 
MasterPageFile="~/NoteMasterPage.master" Title="Untitled Page" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table border="1px">
            <tr>
                <td valign=top align=left>
                    <telerik:RadTreeView ID="tv" runat="server" OnNodeClick="tv_NodeClick" 
                        meta:resourcekey="tvResource1">
                    </telerik:RadTreeView>
                </td>
                <td valign=top align=left>
                    <asp:Panel ID="Panel1" runat="server" Height="110px" 
                        meta:resourcekey="Panel1Resource1">
                        <asp:Localize ID="Localize1" runat="server" 
                            meta:resourcekey="Localize1Resource1" Text="角色"></asp:Localize>
                        <telerik:RadTextBox ID="tbRole" runat="server" Visible="False" DisplayText="" 
                            LabelCssClass="" LabelWidth="64px" meta:resourcekey="tbRoleResource1">
                        </telerik:RadTextBox>
                        <br />
                        <br />
                        <telerik:RadGrid ID="gv" runat="server" AllowMultiRowSelection="True" 
                            AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" 
                            GridLines="None" meta:resourcekey="gvResource1">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                    Visible="True">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                    Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
                                        UniqueName="column" meta:resourcekey="GridClientSelectColumnResource1">
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridBoundColumn DataField="Role" 
                                        FilterControlAltText="Filter Role column" HeaderText="角色" 
                                        UniqueName="Role" meta:resourcekey="GridBoundColumnResource1">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Desc" 
                                        FilterControlAltText="Filter Desc column" HeaderText="備註" 
                                        UniqueName="Desc" meta:resourcekey="GridBoundColumnResource2">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                        <telerik:RadButton ID="RadButton1" runat="server" Text="存檔" 
                            OnClick="RadButton1_Click" meta:resourcekey="RadButton1Resource1">
                        </telerik:RadButton>
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" 
                            meta:resourcekey="lblMsgResource1"></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>