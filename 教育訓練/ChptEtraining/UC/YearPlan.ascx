<%@ Control Language="C#" AutoEventWireup="true" CodeFile="YearPlan.ascx.cs" Inherits="UC_YearPlan" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .RadComboBox
    {
        text-align: left;
    }
    
    .RadComboBox
    {
        vertical-align: middle;
        display: -moz-inline-stack;
        display: inline-block;
    }
    
    .RadComboBox_Default
    {
        font: 12px "Segoe UI" , Arial, sans-serif;
        color: #333;
    }
    
    .RadComboBox
    {
        text-align: left;
    }
    
    .RadComboBox
    {
        vertical-align: middle;
        display: -moz-inline-stack;
        display: inline-block;
    }
    
    .RadComboBox_Default
    {
        font: 12px "Segoe UI" , Arial, sans-serif;
        color: #333;
    }
    
    .RadComboBox
    {
        text-align: left;
    }
    
    .RadComboBox
    {
        vertical-align: middle;
        display: -moz-inline-stack;
        display: inline-block;
    }
    
    .RadComboBox_Default
    {
        font: 12px "Segoe UI" , Arial, sans-serif;
        color: #333;
    }
    
    .RadComboBox
    {
        text-align: left;
    }
    
    .RadComboBox
    {
        vertical-align: middle;
        display: -moz-inline-stack;
        display: inline-block;
    }
    
    
    .RadComboBox_Default
    {
        font: 12px "Segoe UI" , Arial, sans-serif;
        color: #333;
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
    
    .RadComboBox_Default .rcbInputCellLeft
    {
        background-image: url('mvwres://Telerik.Web.UI, Version=2011.1.519.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png');
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
    
    .RadComboBox_Default .rcbInput
    {
        font: 12px "Segoe UI" , Arial, sans-serif;
        color: #333;
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
    
    .RadComboBox_Default .rcbArrowCellRight
    {
        background-image: url('mvwres://Telerik.Web.UI, Version=2011.1.519.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png');
    }
</style>
<div class="block">
<br />
<h2>年度訓練計劃</h2>
    年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" Owner="cbxYear" />
        </Items>
    </telerik:RadComboBox>
    <asp:Label ID="lblMonth" runat="server" Text="0" Visible="False"></asp:Label>
    <br />
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage2"
        SelectedIndex="8" Skin="Windows7" 
        OnTabClick="RadTabStrip1_TabClick">
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
            <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="9月" Value="9" 
                Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="10月" Value="10">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="11月" Value="11">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="12月" Value="12">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage2" runat="server" SelectedIndex="0">
        <telerik:RadPageView ID="RadPageView3" runat="server" BackColor="#FFEBEB">
            <br />
            <br />
            <asp:SqlDataSource ID="sdsgvtest" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                DeleteCommand="DELETE FROM [trTrainingPlanDetail] WHERE [iAutoKey] = @iAutoKey"
                SelectCommand="
select a.iAutokey,a.iYear,a.iMonth,c.sName,b.sName,a.iHours,a.iNumOfPeople,a.iAmt from trTrainingPlanDetail a
left join trCategory b on a.sKey=b.sCode
left join trCourse c on a.trCourse_sCode=c.sCode
 WHERE (([iMonth] = @iMonth) AND ([iYear] = @iYear))" UpdateCommand="UPDATE [trTrainingPlanDetail] SET [iYear] = @iYear, 
[iSession] = @iSession, [iMonth] = @iMonth, 
[trCourse_sCode] = @trCourse_sCode, [sKey] = @sKey, 
[iHours] = @iHours, [iNumOfPeople] = @iNumOfPeople, 
[iAmt] = @iAmt, [sPersonInCharge] = @sPersonInCharge, 
[sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate 
WHERE [iAutoKey] = @iAutoKey">
                <DeleteParameters>
                    <asp:Parameter Name="iAutoKey" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblMonth" DefaultValue="0" Name="iMonth" PropertyName="Text" />
                    <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="iYear" PropertyName="SelectedValue" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="iYear" />
                    <asp:Parameter Name="iSession" />
                    <asp:Parameter Name="iMonth" />
                    <asp:Parameter Name="trCourse_sCode" />
                    <asp:Parameter Name="sKey" />
                    <asp:Parameter Name="iHours" />
                    <asp:Parameter Name="iNumOfPeople" />
                    <asp:Parameter Name="iAmt" />
                    <asp:Parameter Name="sPersonInCharge" />
                    <asp:Parameter Name="sKeyMan" />
                    <asp:Parameter Name="dKeyDate" />
                    <asp:Parameter Name="iAutoKey" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <telerik:RadGrid ID="gv" runat="server" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
                AllowAutomaticUpdates="True" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True"
                AutoGenerateEditColumn="True" CellSpacing="0" DataSourceID="sdsgvtest" GridLines="None"
                Skin="Sunset">
                <MasterTableView DataKeyNames="iAutokey" DataSourceID="sdsgvtest">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" FilterControlAltText="Filter iYear column"
                            HeaderText="年度" SortExpression="iYear" UniqueName="iYear">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iMonth" DataType="System.Int32" FilterControlAltText="Filter iMonth column"
                            HeaderText="月份" SortExpression="iMonth" UniqueName="iMonth">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                            HeaderText="課程名稱" SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName1" FilterControlAltText="Filter sName1 column"
                            HeaderText="課程類別" SortExpression="sName1" UniqueName="sName1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iHours" DataType="System.Decimal" FilterControlAltText="Filter iHours column"
                            HeaderText="時數" SortExpression="iHours" UniqueName="iHours">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iNumOfPeople" DataType="System.Int32" FilterControlAltText="Filter iNumOfPeople column"
                            HeaderText="人數" SortExpression="iNumOfPeople" UniqueName="iNumOfPeople">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iAmt" DataType="System.Int32" FilterControlAltText="Filter iAmt column"
                            HeaderText="預估費用" SortExpression="iAmt" UniqueName="iAmt">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" DataTextField="iAmt"
                            FilterControlAltText="Filter column1 column" UniqueName="column1">
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                            ConfirmText="確定刪除?" FilterControlAltText="Filter column column" UniqueName="column">
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
            <br />
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</div>
