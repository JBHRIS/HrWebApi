<%@ Page Title="" Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="QTpl.aspx.cs" Inherits="eTraining_Questionary_QTpl" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowEditForm(url, rowIndex) {
                var grid = $find("<%= gv.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen(url, "UserListDialog");
                return false;
            }
            function ShowInsertForm(url, winName) {
                window.radopen(url, winName);
                return false;
            }
            function ShowCateForm(url) {
                window.radopen(url, "UserListDialogC");
                return false;
            }
            function ShowContentForm(url) {
                window.radopen(url, "UserListDialogM");
                return false;
            }
            function ShowViewForm(url) {
                window.radopen(url, "UserListDialogV");
                return false;
            }

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
    <h2>
        問卷範本</h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        OnAjaxRequest="RadAjaxPanel1_AjaxRequest">
        <telerik:RadButton ID="btnAddTpl" runat="server" Text="新增問卷樣板" CommandName="Add"
            Style="top: 0px; left: 0px" OnClick="btnAddTpl_Click">
        </telerik:RadButton>
        <telerik:RadButton ID="btnEditCate" runat="server" OnClick="btnEditCate_Click" Text="編輯類別">
        </telerik:RadButton>
        <br />
        <telerik:RadGrid ID="gv" runat="server" GridLines="None" OnItemCreated="gv_ItemCreated"
            Culture="zh-TW" ShowFooter="True" CellSpacing="0" OnDeleteCommand="gv_DeleteCommand"
            Skin="Windows7" OnItemDataBound="gv_ItemDataBound" AutoGenerateColumns="False"
            OnNeedDataSource="gv_NeedDataSource" OnItemCommand="gv_ItemCommand">
            <MasterTableView DataKeyNames="Code" ShowFooter="False">
                <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="Code" FilterControlAltText="Filter Code column"
                        HeaderText="代碼" UniqueName="Code" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                        HeaderText="名稱" UniqueName="Name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FillerCategory" FilterControlAltText="Filter FillerCategory column"
                        HeaderText="填寫類別" UniqueName="FillerCategory">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FillFormSpan" FilterControlAltText="Filter FillFormSpan column"
                        HeaderText="填寫結束日間距" UniqueName="FillFormSpan" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter CommandTpl column" UniqueName="CommandTpl">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnTplEdit" runat="server" CommandName="TplEdit" Text="編輯樣板">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnRelCate" runat="server" CommandName="RelCate" Text="關聯類別">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnSetQ" runat="server" CommandName="SetQ" Text="編排題目">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnViewTpl" runat="server" CommandName="ViewTpl" Text="檢視範本">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnPublish" runat="server" CommandName="Publish" Text="發佈">
                            </telerik:RadButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column" UniqueName="EditCommandColumn1">
                    </EditColumn>
                </EditFormSettings>
                <HeaderStyle Wrap="False" />
            </MasterTableView>
            <HeaderStyle Wrap="False" />
            <CommandItemStyle Wrap="True" />
            <CommandItemStyle Wrap="True"></CommandItemStyle>
            <ItemStyle Wrap="True" />
            <FilterMenu EnableImageSprites="False">
                <WebServiceSettings>
                    <ODataSettings InitialContainerName="">
                    </ODataSettings>
                </WebServiceSettings>
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                <WebServiceSettings>
                    <ODataSettings InitialContainerName="">
                    </ODataSettings>
                </WebServiceSettings>
            </HeaderContextMenu>
        </telerik:RadGrid>
        <br />
        <telerik:RadWindow ID="win" runat="server" Modal="True" EnableShadow="True" VisibleStatusbar="False">
        </telerik:RadWindow>
    </telerik:RadAjaxPanel>
</asp:Content>