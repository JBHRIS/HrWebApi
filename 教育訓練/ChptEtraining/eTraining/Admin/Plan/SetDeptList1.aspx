<%@ Page Title="調查部門清單" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SetDeptList1.aspx.cs" Inherits="eTraining_Admin_Plan_SetDeptList1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .RadGrid_Vista
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Vista
        {
            border: 1px solid #9cb6c5;
            background: #fff;
            color: #333;
        }
        
        .RadGrid_Vista .rgMasterTable
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
        }
        
        .RadGrid_Vista .rgHeader:first-child
        {
            border-left-width: 0;
            padding-left: 8px;
        }
        
        .RadGrid_Vista .rgHeader
        {
            color: #333;
        }
        
        .RadGrid_Vista .rgHeader
        {
            border: 1px solid;
            border-color: #fff #dcf2fc #3c7fb1 #8bbdde;
            border-top-width: 0;
            background: 0 -2300px repeat-x #a6d9f4 url('mvwres://Telerik.Web.UI, Version=2011.1.519.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Vista.Grid.sprite.gif');
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
        
        .RadComboBox_Default
        {
            font: 12px "Segoe UI" , Arial, sans-serif;
            color: #333;
        }
        
        .RadComboBox
        {
            vertical-align: middle;
            display: -moz-inline-stack;
            display: inline-block;
        }
        
        .RadComboBox
        {
            text-align: left;
        }
        
        .RadComboBox_Default
        {
            font: 12px "Segoe UI" , Arial, sans-serif;
            color: #333;
        }
        
        .RadComboBox
        {
            vertical-align: middle;
            display: -moz-inline-stack;
            display: inline-block;
        }
        
        .RadComboBox
        {
            text-align: left;
        }
        
        .RadComboBox *
        {
            margin: 0;
            padding: 0;
        }
        
        .RadComboBox *
        {
            margin: 0;
            padding: 0;
        }
        
        .RadComboBox_Default .rcbInputCellLeft
        {
            background-image: url('mvwres://Telerik.Web.UI, Version=2011.1.519.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png');
        }
        
        .RadComboBox .rcbInputCellLeft
        {
            background-color: transparent;
            background-repeat: no-repeat;
        }
        
        .RadComboBox_Default .rcbInputCellLeft
        {
            background-image: url('mvwres://Telerik.Web.UI, Version=2011.1.519.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png');
        }
        
        .RadComboBox .rcbInputCellLeft
        {
            background-color: transparent;
            background-repeat: no-repeat;
        }
        
        .RadComboBox .rcbReadOnly .rcbInput
        {
            cursor: default;
        }
        
        .RadComboBox .rcbReadOnly .rcbInput
        {
            cursor: default;
        }
        
        .RadComboBox_Default .rcbInput
        {
            font: 12px "Segoe UI" , Arial, sans-serif;
            color: #333;
        }
        
        .RadComboBox .rcbInput
        {
            text-align: left;
        }
        
        .RadComboBox_Default .rcbInput
        {
            font: 12px "Segoe UI" , Arial, sans-serif;
            color: #333;
        }
        
        .RadComboBox .rcbInput
        {
            text-align: left;
        }
        
        .RadComboBox_Default .rcbArrowCellRight
        {
            background-image: url('mvwres://Telerik.Web.UI, Version=2011.1.519.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png');
        }
        
        .RadComboBox .rcbArrowCellRight
        {
            background-color: transparent;
            background-repeat: no-repeat;
        }
        
        .RadComboBox_Default .rcbArrowCellRight
        {
            background-image: url('mvwres://Telerik.Web.UI, Version=2011.1.519.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png');
        }
        
        .RadComboBox .rcbArrowCellRight
        {
            background-color: transparent;
            background-repeat: no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">&nbsp;
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowInsertForm() {
                var year = document.getElementById("<%= cbYear.ClientID %>");
                window.radopen("DeptPicker.aspx?year=" + year.value, "UserListDialog");
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
        </script>
    </telerik:RadCodeBlock>
    <h2>
        調查部門清單</h2>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gv" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadButton3" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    年度
    <telerik:RadComboBox ID="cbYear" runat="server" Width="70px" AutoPostBack="True"
        OnSelectedIndexChanged="cbYear_SelectedIndexChanged" Skin="Transparent">
    </telerik:RadComboBox>
    <br />
    <br />
    <telerik:RadButton ID="RadButton3" runat="server" Text="加入調查部門" 
        AutoPostBack="False">
    </telerik:RadButton>
    <br />
    <br />
    <telerik:RadGrid ID="gv" runat="server" DataSourceID="sdsGv" 
    CellSpacing="0" GridLines="None"
        Skin="Outlook" Width="80%" AllowPaging="True" AllowSorting="True" 
        AllowFilteringByColumn="True" Culture="zh-TW" 
         AutoGenerateColumns="False" onitemcommand="gv_ItemCommand">
        <MasterTableView DataSourceID="sdsGv" DataKeyNames="Id"
            AllowAutomaticDeletes="True">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column"
                    HeaderText="Id" SortExpression="Id" UniqueName="Id" 
                    DataType="System.Int32" ReadOnly="True" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Year" 
                    FilterControlAltText="Filter Year column" HeaderText="年度" 
                    UniqueName="Year" DataType="System.Int32" SortExpression="Year" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DeptCode" FilterControlAltText="Filter DeptCode column"
                    HeaderText="DeptCode" SortExpression="DeptCode" UniqueName="DeptCode" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                    HeaderText="部門名稱" SortExpression="D_NAME" UniqueName="D_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="WriteDate" 
                    FilterControlAltText="Filter WriteDate column" HeaderText="填寫日期" 
                    UniqueName="WriteDate" DataType="System.DateTime" 
                    SortExpression="WriteDate">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="WritedBy" FilterControlAltText="Filter WritedBy column"
                    HeaderText="填寫人" SortExpression="WritedBy" UniqueName="WritedBy">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn CommandName="Del" ConfirmText="確認是否刪除?(會影響到已填寫資料)" 
                    FilterControlAltText="Filter cmdDelete column" Text="刪除" UniqueName="cmdDelete">
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <ItemStyle VerticalAlign="Middle" />
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="True">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Editing record" Height="550px"
                Width="400px" Left="10px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true" />
        </Windows>
    </telerik:RadWindowManager>
    <br />
    <br />
    <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select qd.*,d.D_NAME from QuestDept qd left join DEPT d on qd.DeptCode=d.D_NO
where Year = @year"
        DeleteCommand="DELETE FROM [trTrainingStudentD] WHERE [iAutoKey] = @iAutoKey"
        InsertCommand="INSERT INTO [trTrainingStudentD] ([iYear], [sJoblCode], [sDeptCode], [sNobr]) VALUES (@iYear, @sJoblCode, @sDeptCode, @sNobr)"
        
        
        UpdateCommand="UPDATE [trTrainingStudentD] SET [iYear] = @iYear, [sJoblCode] = @sJoblCode, [sDeptCode] = @sDeptCode, [sNobr] = @sNobr WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="iYear" Type="Int32" />
            <asp:Parameter Name="sJoblCode" Type="String" />
            <asp:Parameter Name="sDeptCode" Type="String" />
            <asp:Parameter Name="sNobr" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="cbYear" DefaultValue="0" Name="year" 
                PropertyName="SelectedValue" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="iYear" Type="Int32" />
            <asp:Parameter Name="sJoblCode" Type="String" />
            <asp:Parameter Name="sDeptCode" Type="String" />
            <asp:Parameter Name="sNobr" Type="String" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
