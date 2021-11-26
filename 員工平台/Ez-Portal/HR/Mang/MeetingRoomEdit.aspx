<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="MeetingRoomEdit.aspx.cs" Inherits="MeetingRoomEdit" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: left; width: 1000px">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
            <div>
                <telerik:RadButton ID="btnAddForm" runat="server" OnClick="btnAddForm_Click" Text="新增">
                </telerik:RadButton>
            </div>
            <div style="float: left; width: 800px" runat="server" id="pnlAddForm" visible="false">
                <table width="100%">
                    <tr>
                        <td>
                            名稱
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbName" runat="server" Rows="3" Width="100%">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            可循環租借
                        </td>
                        <td>
                            <asp:CheckBox ID="cbEnableSchedueRent" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            可租借
                        </td>
                        <td>
                            <asp:CheckBox ID="cbCanRent" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            顯示底色
                        </td>
                        <td>
                            <telerik:RadColorPicker ID="cp" runat="server" PaletteModes="HSB" Preset="None">
                            </telerik:RadColorPicker>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnSave" runat="server" Text="存檔" OnClick="btnSave_Click">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click">
                            </telerik:RadButton>
                            <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblMode" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 100%">
                <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                    Culture="zh-TW" GridLines="None" OnNeedDataSource="gv_NeedDataSource" 
                    OnUpdateCommand="gv_UpdateCommand" onitemcommand="gv_ItemCommand" 
                    onitemdatabound="gv_ItemDataBound">
                    <MasterTableView DataKeyNames="Id">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridEditCommandColumn FilterControlAltText="Filter EditCommandColumn column" 
                                Visible="False">
                            </telerik:GridEditCommandColumn>
                            <telerik:GridButtonColumn CommandName="cmdEdit" 
                                FilterControlAltText="Filter cmdEdit column" Text="編輯" UniqueName="cmdEdit">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" HeaderText="Id"
                                UniqueName="Id" Visible="False" ReadOnly="True">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                                HeaderText="名稱" UniqueName="Name">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="EnableSchedueRent" FilterControlAltText="Filter EnableSchedueRent column"
                                HeaderText="可循環租借" UniqueName="EnableSchedueRent">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridCheckBoxColumn DataField="CanRent" FilterControlAltText="Filter CanRent column"
                                HeaderText="可租借" UniqueName="CanRent">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="DispBackColor" EmptyDataText="" FilterControlAltText="Filter DispBackColor column"
                                HeaderText="顏色" UniqueName="DispBackColor" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Color" EmptyDataText="" FilterControlAltText="Filter Color column"
                                HeaderText="顯示顏色" UniqueName="Color">
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
            </div>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
