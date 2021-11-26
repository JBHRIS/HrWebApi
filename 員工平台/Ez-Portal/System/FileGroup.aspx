<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FileGroup.aspx.cs" Inherits="System_FileGroup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" OnAjaxRequest="RadAjaxPanel1_AjaxRequest">
        <div style="float: left; width: 600px">
            <telerik:RadButton ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click">
            </telerik:RadButton>
            <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                Culture="zh-TW" GridLines="None" OnItemCommand="gv_ItemCommand" OnNeedDataSource="gv_NeedDataSource">
                <MasterTableView DataKeyNames="Id">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn CommandName="EditContent" FilterControlAltText="Filter cmdEdit column"
                            Text="EditContent" UniqueName="cmdEditContent">
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn CommandName="Edt" FilterControlAltText="Filter cmdEdit column"
                            Text="Edit" UniqueName="cmdEdit">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                            HeaderText="Name" UniqueName="Name">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Sequence" FilterControlAltText="Filter Sequence column"
                            HeaderText="Sequence" UniqueName="Sequence">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" HeaderText="Id"
                            UniqueName="Id" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn CommandName="Del" ConfirmText="Delete item?" FilterControlAltText="Filter cmdDel column"
                            Text="Delete" UniqueName="cmdDel">
                        </telerik:GridButtonColumn>
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
        <div style="float: left;">
            <asp:Panel ID="pnlAddForm" runat="server" Visible="false">
                <table>
                    <tr>
                        <td>
                            Name
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbName" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Sequence
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="ntbSequence" runat="server" DataType="System.Int32"
                                MinValue="0" ValidationGroup="a">
                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="rfvSequence" runat="server" ControlToValidate="ntbSequence"
                                ErrorMessage="*Required" ValidationGroup="a"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Role
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cbRole" runat="server" CheckBoxes="True">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
                                ValidationGroup="a">
                            </telerik:RadButton>
                            <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblFormMode" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Style="z-index: 7001"
            Left="300px" Top="300px" Modal="True">
            <Windows>
                <telerik:RadWindow ID="win" runat="server" Height="600px" Width="1024px" 
                    Left="0px" Top="0px">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </telerik:RadAjaxPanel>
</asp:Content>
