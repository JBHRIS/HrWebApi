<%@ Page Title="調查人員清單" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="MemberList1.aspx.cs" Inherits="eTraining_Admin_Plan_MemberList1" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowInsertForm() {
                var year = document.getElementById("<%= cbYear.ClientID %>");
                window.radopen("MemberList.aspx?year=" + year.value, "UserListDialog");
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
                window.radopen("trClassroomEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
    <h2>
        調查人員清單</h2>
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
        OnSelectedIndexChanged="cbYear_SelectedIndexChanged">
    </telerik:RadComboBox>
    <br />
    <br />
    <telerik:RadButton ID="RadButton3" runat="server" Text="加入調查人員" AutoPostBack="False">
    </telerik:RadButton>
    <br />
    <br />
    <telerik:RadGrid ID="gv" runat="server" DataSourceID="sdsGv" CellSpacing="0" GridLines="None"
        Skin="Outlook" Width="80%" AllowPaging="True" AllowSorting="True" 
        AllowFilteringByColumn="True" Culture="zh-TW" 
        onitemdatabound="gv_ItemDataBound">
        <MasterTableView DataSourceID="sdsGv" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
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
                <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                    HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NOBR" 
                    FilterControlAltText="Filter NOBR column" HeaderText="工號" UniqueName="NOBR">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="iYear" FilterControlAltText="Filter iYear column"
                    HeaderText="年度" SortExpression="iYear" UniqueName="iYear" 
                    DataType="System.Int32" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                    HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="joblName" 
                    FilterControlAltText="Filter joblName column" HeaderText="職等" 
                    UniqueName="joblName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                    HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="D_NO" 
                    FilterControlAltText="Filter D_NO column" HeaderText="部門代碼" UniqueName="D_NO" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" FilterControlAltText="Filter Delete column"
                    UniqueName="Delete">
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
        SelectCommand="SELECT s.iAutoKey,s.iYear,jobl.JOB_NAME as joblName,DEPT.D_NAME,dept.D_NO,b.NAME_C,b.NOBR,JOB.JOB_NAME FROM [trTrainingStudentD] as s 
left join BASE b on s.sNobr = b.NOBR
left join JOBL jobl on s.sJoblCode = jobl.JOBL
left join BASETTS tts on b.NOBR = tts.NOBR
left join JOB on tts.JOB = job.JOB
left join DEPT on DEPT.D_NO =tts.DEPT
 WHERE ([iYear] =@iYear) and s.sJoblCode=jobl.jobl and s.sDeptCode = dept.d_no and s.sNobr=b.nobr  
and tts.TTSCODE in ('1','4','6') and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and CONVERT(varchar(10), GETDATE(),111) between DEPT.ADATE and DEPT.DDATE
order by joblName,dept.D_NO"
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
            <asp:ControlParameter ControlID="cbYear" DefaultValue="0" Name="iYear" PropertyName="SelectedValue"
                Type="Int32" />
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
