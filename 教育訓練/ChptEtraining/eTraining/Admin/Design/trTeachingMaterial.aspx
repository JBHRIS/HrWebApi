<%@ Page Title="教案主檔" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="trTeachingMaterial.aspx.cs" Inherits="Admin_Design_trTeachingMaterial" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= gv.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("trTeachingMaterialEdit.aspx?iAutoKey=" + id, "UserListDialog");
                return false;
            }
            function ShowDetailForm(id, rowIndex) {
                var grid = $find("<%= gv.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("trTeachingMaterialDetailEdit.aspx?iAutoKey=" + id, "UserListDialog");
                return false;
            }

            function ShowInsertForm() {
                window.radopen("trTeachingMaterialEdit.aspx", "UserListDialog");
                return false;
            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("trTeachingMaterialEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gv" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnAdd" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlCopy">
                <updatedcontrols>
                    <telerik:AjaxUpdatedControl ControlID="pnlCopy" />
                </updatedcontrols>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gv">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlCopy" />
                    <telerik:AjaxUpdatedControl ControlID="gv" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <h2>教案主檔</h2>
    <asp:Panel ID="pnlCopy" runat="server" Visible="False">
        複製版本：<telerik:RadTextBox ID="tbCloneVision" Runat="server">
        </telerik:RadTextBox>
        <telerik:RadButton ID="btnCopy" runat="server" onclick="btnCopy_Click" 
            Text="複製">
        </telerik:RadButton>
        <telerik:RadButton ID="btnCancel" runat="server" onclick="btnCancel_Click" 
            Text="取消">
        </telerik:RadButton>
        <asp:Label ID="lblMsg" runat="server" Font-Size="Large" ForeColor="#FF3300"></asp:Label>
    </asp:Panel>
    <telerik:RadButton ID="btnAdd" runat="server" Text="新增" Visible="False">
    </telerik:RadButton>
    <telerik:RadButton ID="btnAddMaterial" runat="server" onclick="btnAddMaterial_Click" 
        Text="新增教案">
    </telerik:RadButton>
    <br />
    <br />
    <telerik:RadGrid ID="gv" runat="server" AllowPaging="True" DataSourceID="sdsGV"
        GridLines="None" OnItemCreated="gv_ItemCreated" Culture="zh-TW" 
    ShowFooter="True" CellSpacing="0" AllowFilteringByColumn="True" 
        ondeletecommand="gv_DeleteCommand" Skin="Windows7" 
        onitemdatabound="gv_ItemDataBound" 
        onselectedindexchanged="gv_SelectedIndexChanged" 
        onitemcommand="gv_ItemCommand" AutoGenerateColumns="False" 
        AllowSorting="True">
        <MasterTableView DataKeyNames="iAutoKey" 
            DataSourceID="sdsGV" showfooter="False" allowmulticolumnsorting="True">
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridButtonColumn CommandName="Select" 
                    FilterControlAltText="Filter Select column" UniqueName="Select" Text="選擇" 
                    Visible="False">
                </telerik:GridButtonColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
                    ConfirmDialogType="RadWindow" ConfirmText="是否刪除?" 
                    FilterControlAltText="Filter Delete column" UniqueName="Delete" Visible="False">
                </telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="sName" 
                    FilterControlAltText="Filter trCourse_sName column" HeaderText="課程名稱" 
                    UniqueName="trCourse_sName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sVersion" FilterControlAltText="Filter sVersion column"
                    HeaderText="版本" SortExpression="sVersion" UniqueName="sVersion">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sCoursePolicy" FilterControlAltText="Filter sCoursePolicy column"
                    HeaderText="課程目標" SortExpression="sCoursePolicy" 
                    UniqueName="sCoursePolicy">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sCourseExpect" FilterControlAltText="Filter sCourseExpect column"
                    HeaderText="具體目標" SortExpression="sCourseExpect" 
                    UniqueName="sCourseExpect" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                    UniqueName="TemplateColumn" Visible="False" AllowFiltering="False">
                    <ItemTemplate>
                        <telerik:RadButton ID="btnEdit" runat="server" Text="編輯">
                        </telerik:RadButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter detail column" 
                    UniqueName="detail" Visible="False" AllowFiltering="False">
                    <ItemTemplate>
                        <telerik:RadButton ID="btnDetail" runat="server" Text="詳細內容">
                        </telerik:RadButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn CommandName="View" 
                    FilterControlAltText="Filter View  column" Text="檢視教案" UniqueName="View" 
                    ShowFilterIcon="False">
                </telerik:GridButtonColumn>
                <telerik:GridCheckBoxColumn DataField="bSaved" DataType="System.Boolean" 
                    FilterControlAltText="Filter bSaved column" HeaderText="已存檔" 
                    UniqueName="bSaved">
                </telerik:GridCheckBoxColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter attachment column" 
                    HeaderText="附件" UniqueName="attachment" AllowFiltering="False" 
                    ShowFilterIcon="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="Upload">上傳</asp:LinkButton>
                        <br />
                        <asp:HyperLink ID="hl" runat="server" 
                            Text="下載"></asp:HyperLink>
                        <br />
                        <asp:LinkButton ID="lbtnDelAtt" runat="server" CommandName="DeleteAtt">刪除</asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="FileKey" 
                    FilterControlAltText="Filter FileKey column" UniqueName="FileKey" 
                    Visible="False" EmptyDataText="">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="trCourse_sCode" 
                    FilterControlAltText="Filter trCourse_sCode column" HeaderText="課程代碼"
                    SortExpression="trCourse_sCode" UniqueName="trCourse_sCode" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="name_c" 
                    FilterControlAltText="Filter name_c column" HeaderText="輸入者" 
                    SortExpression="name_c" UniqueName="name_c" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter dKeyDate column" HeaderText="輸入日期" 
                    SortExpression="dKeyDate" UniqueName="dKeyDate" DataFormatString="{0:d}" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FileStoredName" 
                    FilterControlAltText="Filter FileStoredName column" UniqueName="FileStoredName" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridHyperLinkColumn DataNavigateUrlFields="iAutoKey" 
                    DataNavigateUrlFormatString="trTeachMaterial.aspx?ID={0}" 
                    DataTextFormatString="內容" FilterControlAltText="Filter Edit column" Text="內容" 
                    UniqueName="Edit" AllowFiltering="False" ShowFilterIcon="False">
                </telerik:GridHyperLinkColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column" 
                    uniquename="EditCommandColumn1">
                </EditColumn>
            </EditFormSettings>
            <HeaderStyle Wrap="False" />
        </MasterTableView>
        <HeaderStyle Wrap="False" />
        <CommandItemStyle Wrap="True" />
        <CommandItemStyle Wrap="True"></CommandItemStyle>
        <ItemStyle Wrap="True" />
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <br />
    <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        
        
        
        
        DeleteCommand="DELETE FROM [trTeachingMaterial] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [trTeachingMaterial] ([iAutoKey], [trCourse_sCode], [sCode], [sCoursePolicy], [sCourseExpect], [sKeyMan], [dKeyDate]) VALUES (@iAutoKey, @trCourse_sCode, @sCode, @sCoursePolicy, @sCourseExpect, @sKeyMan, @dKeyDate)"
        SelectCommand="SELECT tm.*,base.name_c,c.sName,ul.FileOriginName,ul.iAutoKey as FileKey FROM [trTeachingMaterial] tm join base  on 
tm.sKeyMan = base.nobr  left join trCourse c on tm.trCourse_sCode = c.sCode
left join UPLOAD ul on tm.iAutoKey = ul.FileCategoryKey and ul.FileDeleted =0" 
        
        
        
        
        UpdateCommand="UPDATE [trTeachingMaterial] SET [trCourse_sCode] = @trCourse_sCode, [sCode] = @sCode, [sCoursePolicy] = @sCoursePolicy, [sCourseExpect] = @sCourseExpect, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
            <asp:Parameter Name="trCourse_sCode" Type="String" />
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sCoursePolicy" Type="String" />
            <asp:Parameter Name="sCourseExpect" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="trCourse_sCode" Type="String" />
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sCoursePolicy" Type="String" />
            <asp:Parameter Name="sCourseExpect" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
        EnableShadow="True">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Editing record" Height="500px"
                Width="800px" Left="100px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true" />
            <telerik:RadWindow ID="BigForm" runat="server" EnableShadow="True" 
                Height="600px" style="display:none;" Width="800px" Left="0px" 
                Top="0px">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
