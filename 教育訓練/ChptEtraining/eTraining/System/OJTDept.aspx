<%@ Page Title="職能積分簽核部門設定" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="OJTDept.aspx.cs" Inherits="eTraining_System_OJTDept" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 237px;
        }
        .style2
        {
            width: 232px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        職能積分卡部門設定
    </h2>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="WebBlue"
        Width="100%" IsSticky="True">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
            Skin="WebBlue" Width="100%" AutoPostBack="True" EnableSubLevelStyles="True" SelectedIndex="1"
            ShowBaseLine="True">
            <Tabs>
                <telerik:RadTab runat="server" PageViewID="RadPageView1" Text="區主管">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="部門主管" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="RadPageView3" Text="職能積分卡部門給卡">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%" RenderSelectedPageOnly="True"
            SelectedIndex="1">
            <telerik:RadPageView ID="RadPageView1" runat="server">
                <table style="width: 70%;">
                    <tr>
                        <td class="style1">
                            區主管部門<telerik:RadComboBox ID="cbxOjtVerificationUnit" runat="server" DataSourceID="sdsOjtDept"
                                DataTextField="D_NAME" DataValueField="D_NO" MarkFirstMatch="True">
                            </telerik:RadComboBox>
                        </td>
                        <td class="style2">
                            OJT部門<telerik:RadComboBox ID="cbxOjtUnit" runat="server" DataSourceID="sdsOjtDept"
                                DataTextField="D_NAME" DataValueField="D_NO" MarkFirstMatch="True">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增" Skin="Default">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
                <br />
                <telerik:RadGrid ID="gv" runat="server" AllowAutomaticDeletes="True" CellSpacing="0"
                    Culture="zh-TW" DataSourceID="sdsGv" GridLines="None" Width="55%" AllowCustomPaging="True"
                    AllowPaging="True" Skin="Outlook" AllowSorting="True">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsGv"
                        AllowCustomPaging="False">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VerificationUnit" FilterControlAltText="Filter VerificationUnit column"
                                HeaderText="區主管部門代碼" SortExpression="VerificationUnit" UniqueName="VerificationUnit"
                                Visible="False">
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OjtUnit" FilterControlAltText="Filter OjtUnit column"
                                HeaderText="OJT部門代碼" SortExpression="OjtUnit" UniqueName="OjtUnit" Visible="False">
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dDateTime" DataType="System.DateTime" FilterControlAltText="Filter dDateTime column"
                                HeaderText="dDateTime" SortExpression="dDateTime" UniqueName="dDateTime" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VUnitName" FilterControlAltText="Filter VUnitName column"
                                HeaderText="區主管部門" SortExpression="VUnitName" UniqueName="VUnitName">
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OjtUnitName" FilterControlAltText="Filter OjtUnitName column"
                                HeaderText="OJT部門" SortExpression="OjtUnitName" UniqueName="OjtUnitName">
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmText="確定要刪除"
                                FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridButtonColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
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
                <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    DeleteCommand="DELETE FROM [OjtVerificationUnit] WHERE [iAutoKey] = @iAutoKey"
                    InsertCommand="INSERT INTO [OjtVerificationUnit] ([VerificationUnit], [OjtUnit], [dDateTime], [sKeyMan]) VALUES (@VerificationUnit, @OjtUnit, @dDateTime, @sKeyMan)"
                    SelectCommand="SELECT u.*,
(d1.D_NO+' '+d1.D_NAME) as VUnitName,
(d2.D_NO+' '+d2.D_NAME) as OjtUnitName FROM [OjtVerificationUnit] u 
left join DEPT d1 on u.VerificationUnit = d1.D_NO
left join DEPT d2 on u.OjtUnit = d2.D_NO" UpdateCommand="UPDATE [OjtVerificationUnit] SET [VerificationUnit] = @VerificationUnit, [OjtUnit] = @OjtUnit, [dDateTime] = @dDateTime, [sKeyMan] = @sKeyMan WHERE [iAutoKey] = @iAutoKey">
                    <DeleteParameters>
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="VerificationUnit" Type="String" />
                        <asp:Parameter Name="OjtUnit" Type="String" />
                        <asp:Parameter Name="dDateTime" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="VerificationUnit" Type="String" />
                        <asp:Parameter Name="OjtUnit" Type="String" />
                        <asp:Parameter Name="dDateTime" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <br />
                <asp:SqlDataSource ID="sdsOjtDept" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    SelectCommand="select D_NO,D_NO+' '+D_NAME as D_NAME  from dept where CONVERT(varchar(10), GETDATE(),111) between ADATE and DDATE
 order by D_NAME"></asp:SqlDataSource>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server" Width="100%">
                <table style="width: 70%;">
                    <tr>
                        <td class="style1">
                            主管部門<telerik:RadComboBox ID="cbxOjtCheckUnit" runat="server" DataSourceID="sdsOjtDept"
                                DataTextField="D_NAME" DataValueField="D_NO" MarkFirstMatch="True">
                            </telerik:RadComboBox>
                        </td>
                        <td class="style2">
                            OJT部門<telerik:RadComboBox ID="cbxOjtDept2" runat="server" DataSourceID="sdsOjtDept"
                                DataTextField="D_NAME" DataValueField="D_NO" MarkFirstMatch="True">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnAddOjtCheckUnit" runat="server" OnClick="btnAddOjtCheckUnit_Click"
                                Text="新增" Skin="Default">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
                <br />
                <telerik:RadGrid ID="gvCheckUnit" runat="server" AllowAutomaticDeletes="True" CellSpacing="0"
                    Culture="zh-TW" DataSourceID="sds_gvCheckUnit" GridLines="None" Width="55%" AllowCustomPaging="True"
                    AllowPaging="True" Skin="Outlook" AllowSorting="True" AutoGenerateColumns="False">
                    <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sds_gvCheckUnit" AllowCustomPaging="False">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CheckUnit" FilterControlAltText="Filter CheckUnit column"
                                HeaderText="區主管部門代碼" SortExpression="CheckUnit" UniqueName="CheckUnit" Visible="False">
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OjtUnit" FilterControlAltText="Filter OjtUnit column"
                                HeaderText="OJT部門代碼" SortExpression="OjtUnit" UniqueName="OjtUnit" Visible="False">
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VUnitName" FilterControlAltText="Filter VUnitName column"
                                HeaderText="主管部門" SortExpression="VUnitName" UniqueName="VUnitName">
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OjtUnitName" FilterControlAltText="Filter OjtUnitName column"
                                HeaderText="OJT部門" SortExpression="OjtUnitName" UniqueName="OjtUnitName">
                                <ItemStyle Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmText="確定要刪除"
                                FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridButtonColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
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
                <asp:SqlDataSource ID="sds_gvCheckUnit" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    DeleteCommand="DELETE FROM [OjtCheckUnit] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [OjtCheckUnit] ([CheckUnit], [OjtUnit], [dKeyDate], [sKeyMan]) VALUES (@CheckUnit, @OjtUnit, @dKeyDate, @sKeyMan)"
                    SelectCommand="SELECT u.*,
(d1.D_NO+' '+d1.D_NAME) as VUnitName,
(d2.D_NO+' '+d2.D_NAME) as OjtUnitName FROM OjtCheckUnit u 
left join DEPT d1 on u.CheckUnit = d1.D_NO
left join DEPT d2 on u.OjtUnit = d2.D_NO" UpdateCommand="UPDATE [OjtCheckUnit] SET CheckUnit = @CheckUnit, [OjtUnit] = @OjtUnit, [dKeyDate] = @dKeyDate, [sKeyMan] = @sKeyMan WHERE [iAutoKey] = @iAutoKey">
                    <DeleteParameters>
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CheckUnit" />
                        <asp:Parameter Name="OjtUnit" Type="String" />
                        <asp:Parameter Name="dKeyDate" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CheckUnit" />
                        <asp:Parameter Name="OjtUnit" Type="String" />
                        <asp:Parameter Name="dKeyDate" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <br />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView3" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td title style="width: 50%;" valign="top">
                            選擇職能積分卡<telerik:RadComboBox ID="cbxOJT" runat="server" Culture="zh-TW" DataSourceID="sdsCbx"
                                DataTextField="sName" DataValueField="sCode">
                            </telerik:RadComboBox>
                            <br />
                            <br />
                            選擇部門
                            <telerik:RadTreeView ID="tvDept" runat="server" CheckBoxes="True">
                            </telerik:RadTreeView>
                            <asp:SqlDataSource ID="sdsCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                SelectCommand="SELECT [sCode], [sName] FROM [trOJTTemplate]"></asp:SqlDataSource>
                            <br />
                            <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="存檔">
                            </telerik:RadButton>
                        </td>
                        <td style="width: 49%;" valign="top">
                            <telerik:RadGrid ID="gvUnitCard" runat="server" CellSpacing="0" Culture="zh-TW" GridLines="None"
                                Skin="Outlook" Width="100%" AllowFilteringByColumn="True" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" OnDeleteCommand="gvUnitCard_DeleteCommand"
                                OnNeedDataSource="gvUnitCard_NeedDataSource" PageSize="20">
                                <MasterTableView DataKeyNames="iAutoKey">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                            HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                            Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ojtCardName" FilterControlAltText="Filter ojtCardName column"
                                            HeaderText="職能積分卡" SortExpression="ojtCardName" UniqueName="ojtCardName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="deptName" FilterControlAltText="Filter deptName column"
                                            HeaderText="部門" ReadOnly="True" SortExpression="deptName" UniqueName="deptName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmText="是否刪除?"
                                            FilterControlAltText="Filter Delete column" UniqueName="Delete">
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
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
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </telerik:RadAjaxPanel>
</asp:Content>
