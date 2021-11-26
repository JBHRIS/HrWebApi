<%@ Page Title="設定職能積分卡" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="TrainingTemplate.aspx.cs" Inherits="eTraining_Admin_Do_TrainingTemplate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>
            設定職能積分卡</h2>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
            SelectedIndex="0">
            <Tabs>
                <telerik:RadTab runat="server" Text="新增OJT訓練範本" PageViewID="RadPageView1" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="編輯OJT訓練範本內容" PageViewID="RadPageView2">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="檢示OJT訓練範本">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
            <telerik:RadPageView ID="RadPageView1" runat="server" BackColor="#E6DEEE" Height="500px">
                <br />
                範本名稱<telerik:RadTextBox ID="txtName" runat="server" ValidationGroup="a">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="必填欄位" ForeColor="Red"
                    ValidationGroup="a"></asp:RequiredFieldValidator>
                <br />
                <br />
                <telerik:RadButton ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" ValidationGroup="a">
                </telerik:RadButton>
                &nbsp;
                <br />
                <asp:Label ID="lblMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                <br />
                <telerik:RadGrid ID="gvOJTtp" runat="server" CellSpacing="0" GridLines="None" Width="300px"
                    AllowAutomaticDeletes="True" AllowAutomaticUpdates="True" Culture="zh-TW" DataSourceID="sdsGvOJTtp"
                    Skin="Windows7" OnDataBound="gvOJTtp_DataBound" OnItemDataBound="gvOJTtp_ItemDataBound"
                    AutoGenerateColumns="False" Height="44px" OnEditCommand="gvOJTtp_EditCommand"
                    OnItemUpdated="gvOJTtp_ItemUpdated" OnUpdateCommand="gvOJTtp_UpdateCommand" Style="margin-top: 0px">
                    <MasterTableView DataKeyNames="sCode" DataSourceID="sdsGvOJTtp">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                                HeaderText="代碼" SortExpression="sCode" UniqueName="sCode" Visible="False" ReadOnly="True">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                HeaderText="範本名稱" SortExpression="sName" UniqueName="sName">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="IsValid" FilterControlAltText="Filter IsValid column"
                                HeaderText="有效" UniqueName="IsValid">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                HeaderText="sKeyMan" ReadOnly="True" SortExpression="sKeyMan" UniqueName="sKeyMan"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                HeaderText="dKeyDate" ReadOnly="True" SortExpression="dKeyDate" UniqueName="dKeyDate"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                ConfirmText="確定刪除" FilterControlAltText="Filter column1 column" UniqueName="column1"
                                Visible="False">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" FilterControlAltText="Filter column column"
                                UniqueName="column">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="ExpirationDate" FilterControlAltText="Filter ExpirationDate column"
                                HeaderText="失效日期" ReadOnly="True" UniqueName="ExpirationDate" Visible="False">
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
                <asp:SqlDataSource ID="sdsGvOJTtp" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    SelectCommand="SELECT * FROM [trOJTTemplate]" DeleteCommand="DELETE FROM [trOJTTemplate] WHERE [iAutoKey] = @iAutoKey"
                    InsertCommand="INSERT INTO [trOJTTemplate] ([sCode], [sName], [sKeyMan], [dKeyDate]) VALUES (@sCode, @sName, @sKeyMan, @dKeyDate)"
                    UpdateCommand="UPDATE [trOJTTemplate] SET [sName] = @sName,[IsValid]=@IsValid,[ExpirationDate]=getdate() WHERE [sCode] = @sCode"
                    OnUpdating="sdsGvOJTtp_Updating">
                    <DeleteParameters>
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="sCode" Type="String" />
                        <asp:Parameter Name="sName" Type="String" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="sName" Type="String" />
                        <asp:Parameter Name="IsValid" />
                        <asp:Parameter Name="sCode" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <br />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server" BackColor="#CAE4E4">
                <br />
                <asp:Panel ID="pnlTpChoose" runat="server">
                    <telerik:RadGrid ID="gvAddCourse" runat="server" AllowAutomaticDeletes="True" AllowAutomaticUpdates="True"
                        CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGvOJTtp" GridLines="None" OnDataBound="gvOJTtp_DataBound"
                        OnItemDataBound="gvOJTtp_ItemDataBound" Skin="Windows7" Width="300px" OnItemCommand="gvAddCourse_ItemCommand"
                        OnSelectedIndexChanged="gvAddCourse_SelectedIndexChanged" AutoGenerateColumns="False">
                        <MasterTableView DataKeyNames="sCode" DataSourceID="sdsGvOJTtp">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                    HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                                    HeaderText="代碼" SortExpression="sCode" UniqueName="sCode" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                    HeaderText="範本名稱" SortExpression="sName" UniqueName="sName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                    HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                    HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandArgument="sCode" CommandName="Select" FilterControlAltText="Filter Add column"
                                    Text="加入課程" UniqueName="Select">
                                </telerik:GridButtonColumn>
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
                </asp:Panel>
                <asp:Panel ID="pnlCourseAdd" runat="server" Visible="False">
                    <asp:Label ID="lblTplID" runat="server"></asp:Label>
                    <br />
                    <telerik:RadGrid ID="gvCourse" runat="server" AllowFilteringByColumn="True" AllowMultiRowSelection="True"
                        AllowPaging="True" AllowSorting="True" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsCourse"
                        GridLines="None" Skin="Windows7" AutoGenerateColumns="False" OnItemDataBound="gvCourse_ItemDataBound"
                        PageSize="20" Width="50%">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                            <Selecting AllowRowSelect="True" />
                            <Selecting AllowRowSelect="True" />
                            <Selecting AllowRowSelect="True" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="sCode" DataSourceID="sdsCourse" PageSize="10">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                                    HeaderText="課程代碼" SortExpression="sCode" UniqueName="sCode" FilterControlWidth="40px">
                                    <HeaderStyle Width="40px" Wrap="False" />
                                    <ItemStyle Width="40px" Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                    HeaderText="課程名稱" SortExpression="sName" UniqueName="sName">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ojtKey" EmptyDataText="" FilterControlAltText="Filter ojtKey column"
                                    UniqueName="ojtKey" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iJobScore" FilterControlAltText="Filter iJobScore column"
                                    HeaderText="職能積分" UniqueName="iJobScore">
                                </telerik:GridBoundColumn>
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
                    <telerik:RadButton ID="btnCourseIn" runat="server" OnClick="btnCourseIn_Click" Text="加入">
                    </telerik:RadButton>
                    &#160;
                    <telerik:RadButton ID="btnCnl" runat="server" OnClick="btnCnl_Click" Text="回上頁">
                    </telerik:RadButton>
                </asp:Panel>
                <asp:SqlDataSource ID="sdsCourse" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    SelectCommand="select co.sCode,co.sName,ojtd.iAutoKey as ojtKey,co.iJobScore from trCourse co
left join trOJTTemplateDetail ojtd on co.sCode = ojtd.trCourse_sCode and
ojtd.OJT_sCode =@ID
where co.sCode like 'F%' or sCode like 'G%'">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvAddCourse" DefaultValue="0" Name="ID" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <br />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView3" runat="server">
                選擇範本<telerik:RadComboBox ID="cbxOJTcode" runat="server" DataSourceID="sdsGvOJTtp"
                    DataTextField="sName" DataValueField="sCode" OnSelectedIndexChanged="cbxOJTcode_SelectedIndexChanged"
                    AutoPostBack="True">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="指導員訓練卡" Value="指導員訓練卡" Owner="cbxOJTcode" />
                        <telerik:RadComboBoxItem runat="server" Text="新人訓練卡" Value="新人訓練卡" Owner="cbxOJTcode" />
                    </Items>
                </telerik:RadComboBox>
                <br />
                <br />
                <telerik:RadGrid ID="gvView" runat="server" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsAddCourse"
                    GridLines="None" Skin="Windows7" Width="50%" AutoGenerateColumns="False" OnItemDataBound="gvView_ItemDataBound">
                    <MasterTableView DataSourceID="sdsAddCourse" ShowFooter="True">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                HeaderText="訓練卡名稱" SortExpression="sName" UniqueName="sName" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                                HeaderText="課程代碼" SortExpression="trCourse_sCode" UniqueName="trCourse_sCode">
                                <HeaderStyle Width="40px" Wrap="False" />
                                <ItemStyle Width="40px" Wrap="False" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sName1" FilterControlAltText="Filter sName1 column"
                                HeaderText="課程名稱" SortExpression="sName1" UniqueName="sName1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iJobScore" FilterControlAltText="Filter iJobScore column"
                                HeaderText="職能積分" UniqueName="iJobScore">
                            </telerik:GridBoundColumn>
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
                <asp:SqlDataSource ID="sdsAddCourse" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    SelectCommand="select ot.sName,otd.trCourse_sCode,co.sName,co.iJobScore from trOJTTemplateDetail otd
join trOJTTemplate ot on otd.OJT_sCode=ot.sCode
join trCourse co on otd.trCourse_sCode=co.sCode
where otd.OJT_sCode=@OJTcode

">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cbxOJTcode" DefaultValue="0" Name="OJTcode" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
        <br />
    </div>
</asp:Content>
