<%@ Page Title="指定調查範本" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SetSurveyTemplate.aspx.cs" Inherits="eTraining_Admin_Plan_SetSurveyTemplate" %>

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
                DataSourceID="sdsNowSet" GridLines="None" Skin="Outlook" Width="50%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" 
                    DataSourceID="sdsNowSet">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="sName1" 
                            FilterControlAltText="Filter sName1 column" HeaderText="類別名稱" 
                            SortExpression="sName1" UniqueName="sName1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="course_name" 
                            FilterControlAltText="Filter course_name column" HeaderText="課程名稱" 
                            SortExpression="course_name" UniqueName="course_name">
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
        <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" DataSourceID="sdsTplView" GridLines="None" Skin="Windows7" 
            Width="50%">
            <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsTplView">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="cat_name" 
                        FilterControlAltText="Filter cat_name column" HeaderText="樣板類別名稱" 
                        SortExpression="cat_name" UniqueName="cat_name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="course_name" 
                        FilterControlAltText="Filter course_name column" HeaderText="課程項目名稱" 
                        SortExpression="course_name" UniqueName="course_name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Rt_sCode" 
                        FilterControlAltText="Filter Rt_sCode column" HeaderText="Rt_sCode" 
                        SortExpression="Rt_sCode" UniqueName="Rt_sCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Rtc_sCode" 
                        FilterControlAltText="Filter Rtc_sCode column" HeaderText="Rtc_sCode" 
                        SortExpression="Rtc_sCode" UniqueName="Rtc_sCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sKey" 
                        FilterControlAltText="Filter sKey column" HeaderText="sKey" 
                        SortExpression="sKey" UniqueName="sKey" Visible="False">
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
            SelectCommand="SELECT tplcatdtl.iAutoKey, tplcatdtl.Rt_sCode, tplcatdtl.Rtc_sCode, tplcatdtl.trCourse_sCode, tplcatdtl.iOrder, tplcatdtl.sKey, tpl.sCode, tpl.sName, cat.sCode AS cat_scode, cat.sName AS cat_name, course.sName AS course_name, course.dKeyDate AS Expr13 FROM trRequirementTemplateCatDetail AS tplcatdtl 
INNER JOIN trRequirementTemplate AS tpl ON tplcatdtl.Rt_sCode = tpl.sCode 
INNER JOIN trRequirementTemplateCat AS cat ON tplcatdtl.Rtc_sCode = cat.sCode 
INNER JOIN trCourse AS course ON tplcatdtl.trCourse_sCode = course.sCode 
WHERE (tplcatdtl.Rt_sCode = @tplCode)">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbTpl" DefaultValue="0" Name="tplCode" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsNowSet" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="SELECT *,course.sName as course_name  FROM trRequirementTemplateCatDetail tplcatdtl 
join trRequirementTemplate as tpl on tplcatdtl.Rt_sCode=tpl.sCode 
join trRequirementTemplateCat cat on tplcatdtl.Rtc_sCode = cat.sCode
join trCourse course on    tplcatdtl.trCourse_sCode =course.sCode
where  tplcatdtl.Rt_sCode = @sCode">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblSelectTpl" DefaultValue="0" Name="sCode" 
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
