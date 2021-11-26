<%@ Page Title="設定部門職能積分卡" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="DeptTrainingCard.aspx.cs" Inherits="eTraining_Admin_Do_DeptTrainingCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        設定部門職能積分卡</h2>

        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
            Skin="Office2010Silver" IsSticky="True">
        </telerik:RadAjaxLoadingPanel>

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        width="100%" LoadingPanelID="RadAjaxLoadingPanel1">
         <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
        SelectedIndex="1" AutoPostBack="True">
        <Tabs>
            <telerik:RadTab runat="server" Text="新增" PageViewID="pvAdd">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="檢示" PageViewID="pvView" Selected="True">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="1" 
        Width="100%" RenderSelectedPageOnly="True">
        <telerik:RadPageView ID="pvAdd" runat="server">
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
            <telerik:RadButton ID="btnSave" runat="server" Text="存檔" OnClick="btnSave_Click">
            </telerik:RadButton>
        </telerik:RadPageView>
        <telerik:RadPageView ID="pvView" runat="server">
            <telerik:RadGrid ID="gvUnitCard" runat="server" 
                CellSpacing="0" Culture="zh-TW" GridLines="None" 
                Skin="Outlook" Width="50%" AllowFilteringByColumn="True" 
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                ondeletecommand="gv_DeleteCommand" onneeddatasource="gv_NeedDataSource" 
                PageSize="20">
                <MasterTableView DataKeyNames="iAutoKey">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                        Visible="True">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                        Visible="True">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
                            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
                            ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ojtCardName" 
                            FilterControlAltText="Filter ojtCardName column" HeaderText="職能積分卡" 
                            SortExpression="ojtCardName" UniqueName="ojtCardName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="deptName" FilterControlAltText="Filter deptName column" 
                            HeaderText="部門" ReadOnly="True" SortExpression="deptName" 
                            UniqueName="deptName">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
                            ConfirmText="是否刪除?" FilterControlAltText="Filter Delete column" 
                            UniqueName="Delete">
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
            <asp:SqlDataSource ID="sdsGv" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                DeleteCommand="DELETE FROM [OjtUnitCard] WHERE [iAutoKey] = @iAutoKey">
                <DeleteParameters>
                    <asp:Parameter Name="iAutoKey" />
                </DeleteParameters>
            </asp:SqlDataSource>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    </telerik:RadAjaxPanel>   
</asp:Content>
