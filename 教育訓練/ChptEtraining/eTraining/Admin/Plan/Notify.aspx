<%@ Page Title="待辦事項" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="Notify.aspx.cs" Inherits="eTraining_Admin_Plan_Notify" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>待辦事項</h2>
    <telerik:RadButton ID="btnExport" runat="server" Text="匯出Excel" 
        onclick="btnExport_Click">
    </telerik:RadButton>
    <br />
    <br />
    <telerik:RadGrid ID="gvNotify" runat="server" Skin="Windows7" Width="100%" CellSpacing="0"
        Culture="zh-TW" DataSourceID="sdsNotifyGv" GridLines="None" AllowPaging="True"
        AllowAutomaticDeletes="True" AllowMultiRowSelection="True" AutoGenerateColumns="False"
        Font-Size="X-Small" AllowFilteringByColumn="True" 
        onitemcommand="gvNotify_ItemCommand" onitemcreated="gvNotify_ItemCreated" >
        <MasterTableView DataSourceID="sdsNotifyGv" DataKeyNames="iAutoKey">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                    HeaderText="階層" SortExpression="sName" UniqueName="Cate">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sName1" FilterControlAltText="Filter sName1 column"
                    HeaderText="課程名稱" SortExpression="sName1" UniqueName="Course">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sCode" 
                    FilterControlAltText="Filter sCode column" HeaderText="課程代碼" UniqueName="sCode">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sName2" 
                    FilterControlAltText="Filter Notify column" HeaderText="待辦項目" 
                    UniqueName="Notify">
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
    <br />
    <asp:SqlDataSource ID="sdsNotifyGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select ca.sName,co.sName,co.sCode,ni.sName,tn.dNotifyDate,tn.iAutoKey,tn.dCompletedDate  from trClassNotify tn 
join trTrainingDetailM tm on tn.iClassAutoKey=tm.iAutoKey
join trCourse co on tm.trCourse_sCode=co.sCode
join trNotifyItem ni on tn.iNotifyItemAutoKey=ni.iAutokey
join trCategory ca on tm.sKey=ca.sCode
where tn.dNotifyDate &lt;= @nfdate and  tn.dCompletedDate is null
order by tn.dNotifyDate">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMonth" DefaultValue="0" Name="nfdate" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

