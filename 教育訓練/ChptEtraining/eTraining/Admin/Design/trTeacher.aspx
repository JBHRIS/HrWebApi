<%@ Page Title="講師資料" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="trTeacher.aspx.cs" Inherits="Admin_Design_trTeacher" %>

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

                window.radopen("trTeacherEdit.aspx?iAutoKey=" + id, "UserListDialog");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("trTeacherEdit.aspx", "UserListDialog");
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
                window.radopen("trTeacherEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }

            function StandardConfirm(sender, args) {
                args.set_cancel(!window.confirm("確認是否同步講師資料?"));                
            }
            $('.funcblock').corner("15px");
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
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnCloseS" />
                    <telerik:AjaxUpdatedControl ControlID="pnlNobr" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCloseS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnCloseS" />
                    <telerik:AjaxUpdatedControl ControlID="pnlNobr" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearchNobr">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvNobr" />
                    <telerik:AjaxUpdatedControl ControlID="sdsNobr" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gv">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gv" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <h2>
        講師資料</h2>
    <table>
        <tr>
            <td>
                <telerik:RadButton ID="btnAdd" runat="server" Text="新增">
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnExcel" runat="server" OnClick="btnExcel_Click" Text="匯出Excel">
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnSyncInnerTeacherData" runat="server" Text="同步講師資料" 
                    onclick="btnSyncInnerTeacherData_Click" onclientclicking="StandardConfirm">
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnSearch" runat="server" Text="查詢工號" 
                    onclick="btnSearch_Click">
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnCloseS" runat="server" Text="關閉查詢" Visible="false" 
                    onclick="btnCloseS_Click">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="pnlNobr" runat="server" Visible="False" DefaultButton="btnSearchNobr">
        <div style="width: 450px; background-color: #CDE5FF" class="funcblock">
            <br />
            姓名<telerik:RadTextBox ID="txtName" runat="server">
            </telerik:RadTextBox>
            &nbsp;&nbsp;
            <telerik:RadButton ID="btnSearchNobr" runat="server" Text="查詢" 
                onclick="btnSearchNobr_Click">
            </telerik:RadButton>
            <br />
            <br />
            <telerik:RadGrid ID="gvNobr" runat="server" AllowPaging="True" CellSpacing="0" Culture="zh-TW"
                DataSourceID="sdsNobr" GridLines="None" Skin="Outlook" 
                AutoGenerateColumns="False">
                <MasterTableView DataSourceID="sdsNobr">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                            HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                            HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                            HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
            <asp:SqlDataSource ID="sdsNobr" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select b.NAME_C,tts.NOBR,d.D_NAME,j.JOB_NAME from BASE b
join BASETTS tts on b.NOBR=tts.NOBR
join DEPT d on tts.DEPT=d.D_NO
join JOB j on tts.JOB=j.JOB
where b.NAME_C like @txtName + '%'
and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and tts.TTSCODE in('1','4','6')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtName" DefaultValue="0" Name="txtName" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
        </div>
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="gv" runat="server" AllowPaging="True" DataSourceID="sdsGV" GridLines="None"
        OnItemCreated="gv_ItemCreated" Culture="zh-TW" ShowFooter="True" CellSpacing="0"
        OnDeleteCommand="gv_DeleteCommand" Skin="Windows7" AllowAutomaticDeletes="True"
        AutoGenerateColumns="False" OnExcelExportCellFormatting="gv_ExcelExportCellFormatting"
        OnExcelMLExportStylesCreated="gv_ExcelMLExportStylesCreated" OnExportCellFormatting="gv_ExportCellFormatting"
        AllowFilteringByColumn="True" AllowSorting="True" 
        onitemcommand="gv_ItemCommand">
        <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsGV" ShowFooter="False">
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                    HeaderText="代碼" SortExpression="sCode" UniqueName="sCode" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                    HeaderText="工號" SortExpression="sNobr" UniqueName="sNobr" FilterControlWidth="80px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                    HeaderText="姓名" SortExpression="sName" UniqueName="sName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                    HeaderText="部門" UniqueName="D_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                    HeaderText="職稱" UniqueName="JOB_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sSex" FilterControlAltText="Filter sSex column"
                    HeaderText="性別" SortExpression="sSex" UniqueName="sSex" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sCellPhone" FilterControlAltText="Filter sCellPhone column"
                    HeaderText="行動電話" SortExpression="sCellPhone" UniqueName="sCellPhone" AllowFiltering="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="WorkYear" FilterControlAltText="Filter WorkYear column"
                    HeaderText="年資" UniqueName="WorkYear" AllowFiltering="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sEmail" FilterControlAltText="Filter sEmail column"
                    HeaderText="信箱" SortExpression="sEmail" UniqueName="sEmail" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sTel" FilterControlAltText="Filter sTel column"
                    HeaderText="電話" SortExpression="sTel" UniqueName="sTel" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sFax" FilterControlAltText="Filter sFax column"
                    HeaderText="傳真" SortExpression="sFax" UniqueName="sFax" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sAddr" FilterControlAltText="Filter sAddr column"
                    HeaderText="住址" SortExpression="sAddr" UniqueName="sAddr" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sNote1" FilterControlAltText="Filter sNote1 column"
                    HeaderText="學經歷" SortExpression="sNote1" UniqueName="sNote1" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sNote2" FilterControlAltText="Filter sNote2 column"
                    HeaderText="專長" SortExpression="sNote2" UniqueName="sNote2" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sTeachExp" FilterControlAltText="Filter sTeachExp column"
                    HeaderText="授課經驗" UniqueName="sTeachExp" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sWorkExp" FilterControlAltText="Filter sWorkExp column"
                    HeaderText="工作經歴" UniqueName="sWorkExp" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sNote3" FilterControlAltText="Filter sNote3 column"
                    HeaderText="備註" SortExpression="sNote3" UniqueName="sNote3" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn"
                    AllowFiltering="False">
                    <FooterTemplate>
                        <telerik:RadButton ID="btnExport" runat="server" Text="匯出">
                        </telerik:RadButton>
                    </FooterTemplate>
                    <ItemTemplate>
                        <telerik:RadButton ID="btnEdit" runat="server" Text="編輯">
                        </telerik:RadButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                    ConfirmText="是否要刪除?" ConfirmTitle="刪除" FilterControlAltText="Filter column column"
                    UniqueName="column" Visible="False">
                </telerik:GridButtonColumn>
                <telerik:GridHyperLinkColumn DataNavigateUrlFields="iAutoKey" DataNavigateUrlFormatString="~/eTraining/Teacher/LicenseUpLoad.aspx?ID={0}"
                    DataTextField="證照上傳" FilterControlAltText="Filter column1 column" Text="證照及檔案上傳"
                    UniqueName="column1" AllowFiltering="False">
                </telerik:GridHyperLinkColumn>
                <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                    UniqueName="iAutoKey" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn CommandName="Del" ConfirmText="確認是否刪除?" 
                    FilterControlAltText="Filter Del column" Text="刪除" UniqueName="Del">
                </telerik:GridButtonColumn>
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
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        DeleteCommand="DELETE FROM [trTeacher] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [trTeacher] ([sCode], [sName], [sSex], [sEmail], [sTel], [sFax], [sCallPhone], [sAddr], [sNote1], [sNote2], [sNote3], [sNote4], [sNote5], [sNobr], [sKeyMan], [dKeyDate]) VALUES (@sCode, @sName, @sSex, @sEmail, @sTel, @sFax, @sCallPhone, @sAddr, @sNote1, @sNote2, @sNote3, @sNote4, @sNote5, @sNobr, @sKeyMan, @dKeyDate)"
        
        SelectCommand="SELECT *,dbo.GetTotalYears1(sNobr,GETDATE()) as WorkYear FROM [trTeacher] t 
left join (select job.JOB_NAME,DEPT.D_NAME,tts.NOBR from BASETTS tts
left join JOB on tts.JOB = JOB.JOB
left join DEPT on tts.DEPT = DEPT.D_NO
where CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE) as a  on t.sNobr = a.NOBR" 
        UpdateCommand="UPDATE [trTeacher] SET [sCode] = @sCode, [sName] = @sName, [sSex] = @sSex, [sEmail] = @sEmail, [sTel] = @sTel, [sFax] = @sFax, [sCallPhone] = @sCallPhone, [sAddr] = @sAddr, [sNote1] = @sNote1, [sNote2] = @sNote2, [sNote3] = @sNote3, [sNote4] = @sNote4, [sNote5] = @sNote5, [sNobr] = @sNobr, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sSex" Type="String" />
            <asp:Parameter Name="sEmail" Type="String" />
            <asp:Parameter Name="sTel" Type="String" />
            <asp:Parameter Name="sFax" Type="String" />
            <asp:Parameter Name="sCallPhone" Type="String" />
            <asp:Parameter Name="sAddr" Type="String" />
            <asp:Parameter Name="sNote1" Type="String" />
            <asp:Parameter Name="sNote2" Type="String" />
            <asp:Parameter Name="sNote3" Type="String" />
            <asp:Parameter Name="sNote4" Type="String" />
            <asp:Parameter Name="sNote5" Type="String" />
            <asp:Parameter Name="sNobr" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sSex" Type="String" />
            <asp:Parameter Name="sEmail" Type="String" />
            <asp:Parameter Name="sTel" Type="String" />
            <asp:Parameter Name="sFax" Type="String" />
            <asp:Parameter Name="sCallPhone" Type="String" />
            <asp:Parameter Name="sAddr" Type="String" />
            <asp:Parameter Name="sNote1" Type="String" />
            <asp:Parameter Name="sNote2" Type="String" />
            <asp:Parameter Name="sNote3" Type="String" />
            <asp:Parameter Name="sNote4" Type="String" />
            <asp:Parameter Name="sNote5" Type="String" />
            <asp:Parameter Name="sNobr" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="True">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Editing record" Height="450px"
                Width="650px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true" />
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
