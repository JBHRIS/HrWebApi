<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SiteMapSALADRConfig.aspx.cs" Inherits="HR_Mang_SiteMapSALADRConfig" 
MasterPageFile="~/NoteMasterPage.master" Title="Untitled Page" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Default" meta:resourcekey="RadAjaxLoadingPanel1Resource1">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" 
        width="100%" meta:resourcekey="RadAjaxPanel1Resource1">
        <telerik:RadButton runat="server" Text="更新快取" ID="btnUpdateCache" 
            onclick="btnUpdateCache_Click" meta:resourcekey="btnUpdateCacheResource1">
        </telerik:RadButton>
                <table border="1px">
            <tr>
                <td valign="top" align="left">
                    <telerik:RadTreeView ID="tv" runat="server" OnNodeClick="tv_NodeClick" 
                        CausesValidation="False" meta:resourcekey="tvResource1">
                    </telerik:RadTreeView>
                </td>
                <td valign="top" align="left">
                    <asp:Panel ID="Panel1" runat="server" Height="110px" 
                        meta:resourcekey="Panel1Resource2">
                        <asp:Localize ID="Localize1" runat="server" 
                            meta:resourcekey="Localize1Resource1" Text="資料群組代碼"></asp:Localize>
                        <telerik:RadComboBox ID="dgCbx" Runat="server" DataTextField="GROUPNAME" 
                            DataValueField="DATAGROUP1" Culture="zh-TW" 
                            meta:resourcekey="dgCbxResource1">
                        </telerik:RadComboBox>
                        <br />
                        <br />
                        <telerik:RadButton ID="RadButton1" runat="server" Text="加入" 
                            OnClick="RadButton1_Click" ValidationGroup="g" 
                            meta:resourcekey="RadButton1Resource1">
                        </telerik:RadButton>
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" 
                            meta:resourcekey="lblMsgResource1"></asp:Label>
                        <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" 
                            CellSpacing="0" Culture="zh-TW" GridLines="None" onitemcommand="gv_ItemCommand" 
                            onneeddatasource="gv_NeedDataSource1" meta:resourcekey="gvResource1">
                            <MasterTableView DataKeyNames="Pid">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                    Visible="True">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                    Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Pid" 
                                        FilterControlAltText="Filter Pid column" UniqueName="Pid" Visible="False" 
                                        meta:resourcekey="GridBoundColumnResource1">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SALADR_Code" 
                                        FilterControlAltText="Filter SALADR_Code column" HeaderText="資料群組" 
                                        UniqueName="SALADR_Code" meta:resourcekey="GridBoundColumnResource2">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Del" 
                                        ConfirmText="確認是否刪除?" FilterControlAltText="Filter Del column" 
                                        UniqueName="Del" Text="刪除" meta:resourcekey="GridButtonColumnResource1">
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="GROUPNAME" 
                                        FilterControlAltText="Filter GROUPNAME column" HeaderText="資料群組名稱" 
                                        UniqueName="GROUPNAME" meta:resourcekey="GridBoundColumnResource3">
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
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
    <div>

    </div>
</asp:Content>