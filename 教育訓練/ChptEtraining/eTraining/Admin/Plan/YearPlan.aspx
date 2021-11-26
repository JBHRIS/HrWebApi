<%@ Page Title="年度訓練計劃" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="YearPlan.aspx.cs" Inherits="eTraining_Admin_Plan_YearPlan" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <div>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                Height="100px" IsSticky="True" Skin="Windows7" Width="68px">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
                width="100%" LoadingPanelID="RadAjaxLoadingPanel1">
                        <asp:Panel ID="pnView" runat="server">
            <h2>
                年度訓練計劃<asp:Label ID="lblMode" runat="server" Text="v" Visible="False"></asp:Label>
            </h2>
                        年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" AutoPostBack="True">
            </telerik:RadComboBox>
            <asp:Label ID="lblMonth" runat="server" Text="1" Visible="False"></asp:Label>
            <br />
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage2"
                SelectedIndex="12" Skin="Windows7" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" PageViewID="RadPageView3" Text="1月"
                        Value="1">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="2月" PageViewID="RadPageView3"
                        Value="2">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="3月" Value="3">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="4月" Value="4">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="5月" Value="5">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="6月" Value="6">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="7月" Value="7">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="8月" Value="8">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="9月" Value="9">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="10月" Value="10">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="11月" Value="11">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="12月" Value="12">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="全年度" Selected="True" Value="13">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage2" runat="server" SelectedIndex="0" Height="100%" 
                                Width="100%">
                <telerik:RadPageView ID="RadPageView3" runat="server" BackColor="#FFEBEB">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <telerik:RadButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadAsyncUpload ID="ul" runat="server" AutoAddFileInputs="False" 
                                    Culture="zh-TW" Skin="Windows7">
                                    <Localization Remove="刪除檔案" Select="選擇檔案" />
                                </telerik:RadAsyncUpload>
                                <telerik:RadButton ID="btnUpload" runat="server" Text="上傳檔案" 
                                    onclick="btnUpload_Click" Skin="Windows7">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <asp:HyperLink ID="hplkFile" runat="server" 
                                    NavigateUrl="~/UPLOAD/PLAN/PlanTemplate.xls" Target="_blank">年度計畫匯入範本</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                    <telerik:RadGrid ID="gv" runat="server" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
                        AllowAutomaticUpdates="True" AutoGenerateColumns="False" CellSpacing="0"
                        GridLines="None" Skin="Sunset" OnDataBound="gv_DataBound" OnItemDataBound="gv_ItemDataBound"
                        OnItemCommand="gv_ItemCommand" Culture="zh-TW" onprerender="gv_PreRender" 
                        ShowFooter="True" onneeddatasource="gv_NeedDataSource">
                        <MasterTableView DataKeyNames="iAutokey" 
                    allowpaging="True" pagesize="20" allowmulticolumnsorting="True" 
                    allowsorting="True">
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
                            <commanditemsettings exporttopdftext="Export to PDF" />
                            <commanditemsettings exporttopdftext="Export to PDF" />
                            <commanditemsettings exporttopdftext="Export to PDF" />
                            <commanditemsettings exporttopdftext="Export to PDF" />
                            <commanditemsettings exporttopdftext="Export to PDF" />
                            <commanditemsettings exporttopdftext="Export to PDF" />
                            <commanditemsettings exporttopdftext="Export to PDF" />
                            <commanditemsettings exporttopdftext="Export to PDF" />
                            <commanditemsettings exporttopdftext="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" FilterControlAltText="Filter iYear column"
                                    HeaderText="年度" SortExpression="iYear" UniqueName="iYear" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iMonth" DataType="System.Int32" FilterControlAltText="Filter iMonth column"
                                    HeaderText="月份" SortExpression="iMonth" UniqueName="iMonth">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" FilterControlAltText="Filter iSession column"
                                    HeaderText="梯次" SortExpression="iSession" UniqueName="iSession">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="catsName" 
                                    FilterControlAltText="Filter catsName column" HeaderText="階層" 
                                    SortExpression="catsName" UniqueName="catsName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="csName" FilterControlAltText="Filter csName column"
                                    HeaderText="課程名稱" SortExpression="csName" UniqueName="csName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iMins" DataType="System.Int16" FilterControlAltText="Filter iMins column"
                                    HeaderText="時間" SortExpression="iMins" UniqueName="iMins">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iNumOfPeople" DataType="System.Int32" FilterControlAltText="Filter iNumOfPeople column"
                                    HeaderText="人數" SortExpression="iNumOfPeople" UniqueName="iNumOfPeople">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iAmt" DataType="System.Int32" FilterControlAltText="Filter iAmt column"
                                    HeaderText="預估費用" SortExpression="iAmt" UniqueName="iAmt">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit"
                                    FilterControlAltText="Filter Edit column" UniqueName="Edit">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                    ConfirmText="確定刪除?" FilterControlAltText="Filter Delete column" 
                                    UniqueName="Delete">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                                    UniqueName="trCourse_sCode" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iClassAutoKey" EmptyDataText="" 
                                    FilterControlAltText="Filter iClassAutoKey column" UniqueName="iClassAutoKey" 
                                    Visible="False">
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
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnAdd" runat="server">
            <h3>
                <asp:Label ID="lblYYMM" runat="server"></asp:Label>
            </h3>
            <p>
                &nbsp;</p>
            <div style="background-color: #CDE5FF; float: left; width: 28%" class="funcblock">
                <br />
                <telerik:RadTreeView ID="tv" runat="server" OnNodeClick="tv_NodeClick" Skin="Vista">
                </telerik:RadTreeView>
                <br />
            </div>
            <div style="float: right; width: 70%">
                <div style="background-color: #EBF5FF; width: 80%" class="funcblock">
                    <br />
                    &nbsp;&nbsp;<asp:Label ID="lblCourse" runat="server" Font-Bold="True" Font-Size="Medium"
                        ForeColor="#3366FF" Text="尚未選擇課程"></asp:Label>
                    <asp:Label ID="lblCourseCode" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblAutoKey" runat="server" Visible="False"></asp:Label>
                    <table class="tableBlue">
                        <tr>
                            <td>
                            </td>
                            <th>
                                梯次
                            </th>
                            <td>
                                <telerik:RadNumericTextBox ID="txtSession" Runat="server" Width="50px" 
                                    DataType="System.Int32" MinValue="0">
                                    <numberformat decimaldigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="15px">
                            </td>
                            <th>
                                時數 (小時)</th>
                            <td>
                                <telerik:RadNumericTextBox ID="txtHour" runat="server" Width="50px">
                                    <numberformat decimaldigits="0" />
                                    <NumberFormat DecimalDigits="1" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <th>
                                人數
                            </th>
                            <td>
                                <telerik:RadNumericTextBox ID="txtNumOfPeople" runat="server" Width="50px">
                                    <NumberFormat AllowRounding="False" DecimalDigits="2" />
                                    <NumberFormat AllowRounding="False" DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <th width="70px">
                                預估費用
                            </th>
                            <td>
                                <telerik:RadNumericTextBox ID="txtAmt" runat="server" Type="Currency" Width="70px">
                                    <numberformat decimaldigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <th width="70px">
                                課程類型</th>
                            <td>
                                <asp:RadioButtonList ID="rblCourseType" runat="server" DataTextField="sName" 
                                    DataValueField="sCode" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="display:none">>
                            </td>
                            <th style="display:none">>
                                負責人
                            </th>
                            <td style="display:none">>
                                輸入工號或姓名<telerik:RadTextBox ID="tbSearch" runat="server" Width="70px">
                                </telerik:RadTextBox>
                                <telerik:RadButton ID="btnSearchMan" runat="server" Text="搜尋" >
                                </telerik:RadButton>
                                <br />
                                <br />
                                <telerik:RadGrid ID="gvPerson" runat="server" Skin="WebBlue" Width="220px" CellSpacing="0"
                                    DataSourceID="sdsGvPerson" GridLines="None" 
                                    AllowPaging="True">
                                    <MasterTableView AutoGenerateColumns="False" DataSourceID="sdsGvPerson">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter column column"
                                                Text="選擇" UniqueName="column">
                                            </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                                                HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                                                HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                                            </telerik:GridBoundColumn>
                                        </Columns>                                        
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_WebBlue">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                                <br />
                            </td>
                            <td>
                                <telerik:RadListBox ID="lbManager" runat="server" Height="100px" Width="80px" 
                                    AllowDelete="True" Visible="False">
                                    <ButtonSettings TransferButtons="All" />
                                    <ButtonSettings TransferButtons="All" />
                                    <ButtonSettings TransferButtons="All" />
                                </telerik:RadListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:SqlDataSource ID="sdsGvPerson" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                    SelectCommand="select b.NOBR,b.NAME_C from BASE b join BASETTS t on b.NOBR = t.NOBR and t.TTSCODE in ('1','4','6') and CONVERT(varchar(10), GETDATE(),111) between t.ADATE and t.DDATE where b.NAME_C like @value or b.NOBR like @value">
                                    <SelectParameters>
                                        <asp:Parameter Name="value" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                <asp:CheckBox ID="cbIsSerialCourse" runat="server" Enabled="False" />
                                &nbsp;序列課程
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="3" style="text-align: center">
                                <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="存檔">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
                &nbsp;<br />
            </div>
        </asp:Panel>
            </telerik:RadAjaxPanel>

    </div>
</asp:Content>
