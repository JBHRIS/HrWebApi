<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="trTeachMaterial.aspx.cs" Inherits="eTraining_Admin_Design_trTeachMaterial" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        教學教案</h2>
    <br />
    <asp:HyperLink ID="hlBack" runat="server" Style="text-align: right" NavigateUrl="~/eTraining/Admin/Design/trTeachingMaterial.aspx"
                Font-Size="Medium" CssClass="Button1">回教案主檔</asp:HyperLink>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <telerik:RadButton ID="btnTeachMaterialAdd" runat="server" Text="新增" OnClick="btnTeachMaterialAdd_Click">
        </telerik:RadButton>
        <telerik:RadButton ID="btnTeachMaterialEdit" runat="server" OnClick="btnTeachMaterialEdit_Click"
            Text="編輯">
        </telerik:RadButton>
        <asp:Label ID="lblMMode" runat="server" Text="v" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblTeachMaterialID" runat="server" Visible="False"></asp:Label>
        <asp:Panel ID="pnlMaterialHead" runat="server">
            <table class="style1">
            <tr>
            <td></td>
            <td></td>
            <td style="text-align:right">
                <asp:CheckBox ID="bSavedCheckBox" runat="server" Text="範本" />
                </td>
            </tr>
                <tr>
                    <td>
                        類別<telerik:RadComboBox ID="cbxBCate" runat="server" AutoPostBack="True" DataSourceID="sdsBCate0"
                            DataTextField="sName" DataValueField="sCode" OnItemDataBound="cbxBCate_ItemDataBound"
                            OnSelectedIndexChanged="cbxBCate_SelectedIndexChanged" Skin="Office2007">
                        </telerik:RadComboBox>
                        <asp:SqlDataSource ID="sdsBCate0" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="select * from trCategory where sParentCode='ROOT'"></asp:SqlDataSource>
                    </td>
                    <td>
                        階層<telerik:RadComboBox ID="cbxDCate" runat="server" AutoPostBack="True" DataSourceID="sdsDCate0"
                            DataTextField="sName" DataValueField="sCode" Skin="Office2007">
                        </telerik:RadComboBox>
                        <asp:SqlDataSource ID="sdsDCate0" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="select * from trCategory where sParentCode=@BCate">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cbxBCate" DefaultValue="-1" Name="BCate" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td>
                        課程<telerik:RadComboBox ID="cbxCourse" runat="server" AutoPostBack="True" DataSourceID="sdsCourse0"
                            DataTextField="sName" DataValueField="sCode" Skin="Office2007">
                        </telerik:RadComboBox>
                        <asp:SqlDataSource ID="sdsCourse0" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="select * from trCourse co
join trCategoryCourse caco on co.sCode=caco.sCourseCode
join trCategory ca on caco.sCateCode=ca.sCode
where ca.sCode=@DCate">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cbxDCate" DefaultValue="-1" Name="DCate" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        課程內容<telerik:RadTextBox ID="tbContent" runat="server" Width="350px">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        版本<telerik:RadTextBox ID="tbVersion" runat="server" Width="125px">
                        </telerik:RadTextBox>
                    </td>
                    
                    <td>
                        教學時間(分鐘)<telerik:RadNumericTextBox ID="ntbTeachingTime" runat="server" Culture="zh-TW"
                            DataType="System.Int32" Width="125px">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
            </table>
            <table class="style1">
                <tr>
                    <td>
                        課程目標<br />
                        <telerik:RadTextBox ID="tbCoursePolicy" runat="server" Rows="5" Skin="Office2007"
                            TextMode="MultiLine" Width="380px">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        具體目標<br />
                        <telerik:RadTextBox ID="tbsCourseExpect" runat="server" Rows="5" Skin="Office2007"
                            TextMode="MultiLine" Width="380px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>

        <telerik:RadButton ID="btnTeachMaterialSave" runat="server" 
            OnClick="btnTeachMaterialSave_Click" Text="儲存">
        </telerik:RadButton>
        &nbsp;
        <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" 
            Text="取消">
        </telerik:RadButton>
        <br />

        <br />
        <div>
            <telerik:RadButton ID="btnAddItem" runat="server" Text="新增項目" Skin="Office2007" OnClick="btnAddItem_Click">
            </telerik:RadButton>
            <br />
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW" GridLines="None"
                Skin="Office2007" DataSourceID="sdsGv" OnItemDataBound="gv_ItemDataBound" 
                onitemcommand="gv_ItemCommand">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" 
                    DataSourceID="sdsGv" nomasterrecordstext="" showheaderswhennorecords="False">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                            HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MaterialAutoKey" DataType="System.Int32" FilterControlAltText="Filter MaterialAutoKey column"
                            HeaderText="MaterialAutoKey" SortExpression="MaterialAutoKey" UniqueName="MaterialAutoKey"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ParentiAutoKey" DataType="System.Int32" FilterControlAltText="Filter ParentiAutoKey column"
                            HeaderText="ParentiAutoKey" SortExpression="ParentiAutoKey" UniqueName="ParentiAutoKey"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sOutline" FilterControlAltText="Filter sOutline column"
                            HeaderText="教學大綱/重點內容" SortExpression="sOutline" UniqueName="sOutline">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter TeachingMethod column" 
                            HeaderText="教學方法" UniqueName="TeachingMethod">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter TeachingResource column" 
                            HeaderText="教學資源" UniqueName="TeachingResource">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iTimeMin" DataType="System.Int32" FilterControlAltText="Filter iTimeMin column"
                            HeaderText="時間" SortExpression="iTimeMin" UniqueName="iTimeMin">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNote" FilterControlAltText="Filter sNote column"
                            HeaderText="備註" SortExpression="sNote" UniqueName="sNote">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iOrder" DataType="System.Int32" FilterControlAltText="Filter iOrder column"
                            HeaderText="iOrder" SortExpression="iOrder" UniqueName="iOrder" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                            HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                            HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn CommandName="EditItem" 
                            FilterControlAltText="Filter EditItem column" Text="編輯" UniqueName="EditItem">
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn CommandName="DeleteItem" ConfirmText="是否刪除?" 
                            FilterControlAltText="Filter DeleteItem column" Text="刪除" 
                            UniqueName="DeleteItem">
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
            <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT * FROM [trTeachingMaterialDetail] WHERE ([MaterialAutoKey] = @MaterialAutoKey)
order by iOrder">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblTeachMaterialID" DefaultValue="-1" Name="MaterialAutoKey"
                        PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <telerik:RadWindow ID="RadWindow1" runat="server" Height="300px" Modal="True" Width="900px">
                <ContentTemplate>
                    <div style="background-color: #CDE5FF">
                        教學大鋼<telerik:RadTextBox ID="tbOutline" runat="server" Rows="4" Width="800px" TextMode="MultiLine">
                        </telerik:RadTextBox>
                        &nbsp;
                        <br />
                        教學方法<telerik:RadComboBox ID="cbxTeachingMethod" runat="server" Width="100px" CheckBoxes="True"
                            DataSourceID="sdsTeachingMethod" DataTextField="sName" DataValueField="sCode">
                        </telerik:RadComboBox>
                        &nbsp;&nbsp; 教學資源<telerik:RadComboBox ID="cbxTeachingResource" runat="server" Width="80px"
                            CheckBoxes="True" DataSourceID="sdsTeachingResource" DataTextField="ResourceName"
                            DataValueField="ResourceCode">
                        </telerik:RadComboBox>
                        &nbsp;&nbsp; 時間<telerik:RadNumericTextBox ID="ntbTimeMin" runat="server" DataType="System.Int32"
                            MinValue="0" Value="0" Width="80px">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        分鐘&nbsp; 備註<telerik:RadTextBox ID="tbNote" runat="server" TextMode="MultiLine" Width="150px">
                        </telerik:RadTextBox>
                        &nbsp; 順位<telerik:RadNumericTextBox ID="ntbOrder" runat="server" MinValue="0" Width="40px">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <br />
                        <telerik:RadButton ID="btnSaveItem" runat="server" OnClick="btnSaveItem_Click" Text="儲存">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnCancelItem" runat="server" OnClick="btnCancelItem_Click"
                            Text="取消">
                        </telerik:RadButton>
                        <asp:Label ID="lblItemID" runat="server" Visible="False"></asp:Label>
                        <asp:SqlDataSource ID="sdsTeachingMethod" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="SELECT * FROM [trTeachingMethod]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="sdsTeachingResource" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="SELECT * FROM [trTeachingResource]"></asp:SqlDataSource>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
