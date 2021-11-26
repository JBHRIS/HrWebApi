<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HRNotify.ascx.cs" Inherits="UC_HRNotify" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="Notify" style="margin: 0px; padding: 0px; width: 99%; ">
    <h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 待辦事項</h2>
    <telerik:RadGrid ID="gvNotify" runat="server" Skin="Windows7" Width="100%" CellSpacing="0"
        Culture="zh-TW" DataSourceID="sdsNotifyGv" GridLines="None" AllowPaging="True"
        AllowAutomaticDeletes="True" AllowMultiRowSelection="True" AutoGenerateColumns="False"
        Font-Size="X-Small" OnItemCommand="gvNotify_ItemCommand">
        <MasterTableView DataSourceID="sdsNotifyGv" DataKeyNames="iAutoKey">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                    HeaderText="課程名稱" SortExpression="sName" UniqueName="sName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sName1" FilterControlAltText="Filter sName1 column"
                    HeaderText="待辦項目" SortExpression="sName1" UniqueName="sName1">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dNotifyDate" DataFormatString="{0:d}" DataType="System.DateTime"
                    FilterControlAltText="Filter dNotifyDate column" HeaderText="執行日期" SortExpression="dNotifyDate"
                    UniqueName="dNotifyDate">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn CommandName="Done" ConfirmText="確認是否完成?"
                    FilterControlAltText="Filter Done column" UniqueName="Done" Text="完成">
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
            <PagerStyle ShowPagerText="False" />
        </MasterTableView>
        <PagerStyle EnableSEOPaging="True" />
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Windows7">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <asp:Label ID="lblMonth" runat="server" Visible="False"></asp:Label>
    <asp:SqlDataSource ID="sdsNotifyGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select co.sName,ni.sName,tn.dNotifyDate,tn.iAutoKey,tn.dCompletedDate  from trClassNotify tn 
join trTrainingDetailM tm on tn.iClassAutoKey=tm.iAutoKey
join trCourse co on tm.trCourse_sCode=co.sCode
join trNotifyItem ni on tn.iNotifyItemAutoKey=ni.iAutokey
where tn.dNotifyDate &lt;= @nfdate and  tn.dCompletedDate is null
order by tn.dNotifyDate">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMonth" DefaultValue="0" Name="nfdate" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div style="text-align:right">
        <asp:HyperLink ID="hlDetail" runat="server" 
            NavigateUrl="~/eTraining/Admin/Plan/Notify.aspx">詳細資料</asp:HyperLink></div>
</div>
