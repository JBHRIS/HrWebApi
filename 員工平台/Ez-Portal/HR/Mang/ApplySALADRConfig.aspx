<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplySALADRConfig.aspx.cs" Inherits="HR_Mang_SiteMapSALADRConfig" 
MasterPageFile="~/NoteMasterPage.master" Title="Untitled Page" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" width="100%">
        <telerik:RadButton runat="server" Text="更新快取" ID="btnUpdateCache" 
            onclick="btnUpdateCache_Click">
        </telerik:RadButton>
                <table border="1px">
            <tr>
                <td valign="top" align="left">
                    <telerik:RadTreeView ID="tv" runat="server" OnNodeClick="tv_NodeClick" 
                        CausesValidation="False">
                    </telerik:RadTreeView>
                </td>
                <td valign="top" align="left">
                    <asp:Panel ID="Panel1" runat="server" Height="110px">
                        資料群組代碼<telerik:RadComboBox ID="dgCbx" Runat="server" DataTextField="GROUPNAME" 
                            DataValueField="DATAGROUP1">
                        </telerik:RadComboBox>
                        <br />
                        <br />
                        <telerik:RadButton ID="RadButton1" runat="server" Text="加入" 
                            OnClick="RadButton1_Click" ValidationGroup="g">
                        </telerik:RadButton>
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                        <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" 
                            CellSpacing="0" Culture="zh-TW" GridLines="None" onitemcommand="gv_ItemCommand" 
                            onneeddatasource="gv_NeedDataSource1">
                            <MasterTableView DataKeyNames="Pid">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                    Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                    Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Pid" 
                                        FilterControlAltText="Filter Pid column" UniqueName="Pid" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SALADR_Code" 
                                        FilterControlAltText="Filter SALADR_Code column" HeaderText="資料群組" 
                                        UniqueName="SALADR_Code">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Del" 
                                        ConfirmText="確認是否刪除?" FilterControlAltText="Filter Del column" 
                                        UniqueName="Del" Text="刪除">
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="GROUPNAME" 
                                        FilterControlAltText="Filter GROUPNAME column" HeaderText="資料群組名稱" 
                                        UniqueName="GROUPNAME">
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