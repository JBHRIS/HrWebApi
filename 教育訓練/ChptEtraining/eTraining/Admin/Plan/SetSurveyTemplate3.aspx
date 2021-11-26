<%@ Page Title="指定調查範本" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SetSurveyTemplate3.aspx.cs" Inherits="eTraining_Admin_Plan_SetSurveyTemplate3" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .RadGrid_Default
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Default
        {
            border: 1px solid #828282;
            background: #fff;
            color: #333;
        }
        
        .RadGrid_Default
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Default
        {
            border: 1px solid #828282;
            background: #fff;
            color: #333;
        }
        
        .RadGrid_Default .rgMasterTable
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
        }
        
        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
        }
        
        .RadGrid_Default .rgMasterTable
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
        }
        
        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
        }
        
        .RadGrid_Default .rgHeader
        {
            color: #333;
        }
        
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-bottom: 1px solid #828282;
            background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2011.1.519.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        }
        
        .RadGrid .rgHeader
        {
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
        }
        
        .RadGrid .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }
        
        .RadGrid .rgHeader
        {
            cursor: default;
        }
        
        .RadGrid .rgHeader
        {
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
        }
        
        .RadGrid .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }
        
        .RadGrid .rgHeader
        {
            cursor: default;
        }
        
        .RadGrid_Default .rgHeader
        {
            color: #333;
        }
        
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-bottom: 1px solid #828282;
            background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2011.1.519.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        }
        
        .RadGrid .rgHeader
        {
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
        }
        
        .RadGrid .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }
        
        .RadGrid .rgHeader
        {
            cursor: default;
        }
        
        .RadGrid .rgHeader
        {
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
        }
        
        .RadGrid .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }
        
        .RadGrid .rgHeader
        {
            cursor: default;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>--%>
    <h2>
        指定調查範本</h2>
    年度<telerik:RadComboBox ID="cbYear" runat="server" Width="70px" 
        AutoPostBack="True" onselectedindexchanged="cbYear_SelectedIndexChanged">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" Owner="cbYear" />
            <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" />
        </Items>
    </telerik:RadComboBox>
    <br />
    &nbsp;&nbsp;
        <br />
        <asp:Panel ID="pnView" runat="server">
            <asp:Label ID="lblTp" runat="server" Font-Bold="True" Font-Size="Medium" 
    ForeColor="#0066FF" BorderColor="#91C7FF" BorderStyle="Solid">尚未設定範本</asp:Label>
            <telerik:RadButton ID="btnSet" runat="server" OnClick="btnSet_Click" 
                Skin="WebBlue" Text="設定">
            </telerik:RadButton>
<telerik:RadGrid ID="gvNowSet" runat="server" CellSpacing="0"
                            GridLines="None" Skin="Windows7" Culture="zh-TW" 
                            OnNeedDataSource="gvNowSet_NeedDataSource" 
                            AutoGenerateColumns="False">
                            <MasterTableView DataKeyNames="Id">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" 
                                        HeaderText="Id" UniqueName="Id" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CourseCode" 
                                        FilterControlAltText="Filter CourseCode column" HeaderText="CourseCode" 
                                        UniqueName="CourseCode" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CourseName" 
                                        FilterControlAltText="Filter CourseName column" HeaderText="課程名稱" 
                                        UniqueName="CourseName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Budget" 
                                        FilterControlAltText="Filter Budget column" HeaderText="外訓課程預估費用/位" 
                                        UniqueName="Budget">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Sequence" 
                                        FilterControlAltText="Filter Sequence column" HeaderText="順序" 
                                        UniqueName="Sequence">
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
    </asp:Panel>
    <asp:Panel ID="pnSet" runat="server" Height="131px" Visible="False">
        <telerik:RadComboBox ID="cbTpl" runat="server" DataSourceID="sdsCbTpl" DataTextField="sName"
            DataValueField="sCode" AutoPostBack="True" Visible="True" 
            onselectedindexchanged="cbTpl_SelectedIndexChanged">
        </telerik:RadComboBox>
        <telerik:RadButton ID="btnCheck" runat="server" OnClick="btnCheck_Click" 
            Text="確定">
        </telerik:RadButton>
        <telerik:RadButton ID="btnCancel" runat="server" onclick="btnCancel_Click" 
            Text="取消">
        </telerik:RadButton>
        <telerik:RadGrid ID="gv" runat="server" CellSpacing="0"
                            GridLines="None" Skin="Windows7" Culture="zh-TW" 
                            OnNeedDataSource="gv_NeedDataSource" 
                            AutoGenerateColumns="False">
                            <MasterTableView DataKeyNames="Id">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" 
                                        HeaderText="Id" UniqueName="Id" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CourseCode" 
                                        FilterControlAltText="Filter CourseCode column" HeaderText="CourseCode" 
                                        UniqueName="CourseCode" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CourseName" 
                                        FilterControlAltText="Filter CourseName column" HeaderText="課程名稱" 
                                        UniqueName="CourseName">
                                    </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Budget" 
                                        FilterControlAltText="Filter Budget column" HeaderText="外訓課程預估費用/位" 
                                        UniqueName="Budget">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Sequence" 
                                        FilterControlAltText="Filter Sequence column" HeaderText="順序" 
                                        UniqueName="Sequence">
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
    </asp:Panel>
    <asp:Label ID="lblSelectTpl" runat="server" Visible="False"></asp:Label>
        <asp:SqlDataSource ID="sdsTplView" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            
        SelectCommand="SELECT d.*,c.sName,c.iFillMaxNum FROM [trRequirementTemplateDetail] d join trRequirementTemplateCat c on d.rtc_sCode = c.sCode where Rt_sCode=@Rt_sCode order by iOrder">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbTpl" DefaultValue=" " Name="Rt_sCode" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsNowSet" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        
        SelectCommand="SELECT d.*,c.sName,c.iFillMaxNum FROM [trRequirementTemplateDetail] d join trRequirementTemplateCat c on d.rtc_sCode = c.sCode where Rt_sCode=@Rt_sCode order by iOrder">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblSelectTpl" DefaultValue=" " Name="Rt_sCode" 
                PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsCbTpl" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            DeleteCommand="delete  [trRequirementTemplate] where iAutoKey=@iAutoKey" SelectCommand="select * from trRequirementTemplate">
            <DeleteParameters>
                <asp:Parameter DefaultValue="0" Name="iAutoKey" />
            </DeleteParameters>
        </asp:SqlDataSource>
    <br />
    <br />
</asp:Content>
