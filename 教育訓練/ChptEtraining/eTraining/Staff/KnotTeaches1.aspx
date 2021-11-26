<%@ Page Title="填寫課後資料" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="KnotTeaches1.aspx.cs" Inherits="eTraining_Staff_KnotTeaches1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>填寫課後資料</h2>
    &nbsp;年度
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function refreshGrid(arg) {
                $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("Rebind");
            }
        </script>
    </telerik:RadCodeBlock>

        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        OnAjaxRequest="RadAjaxPanel1_AjaxRequest">
    <telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" 
        onselectedindexchanged="cbxYear_SelectedIndexChanged" AutoPostBack="True">
    </telerik:RadComboBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
   <br />
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
        SelectedIndex="0" Skin="Vista">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="pvExpReport" Text="心得報告" 
                Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="pvQuestionary" Text="問卷填寫">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" 
        Width="100%">
        <telerik:RadPageView ID="pvExpReport" runat="server">
            <asp:SqlDataSource ID="sdsReport" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                onselecting="sdsReport_Selecting" 
                
                SelectCommand="select sm.*,course.sName,dm.dDateTimeA,dm.iSession,dm.sKey,cate.sName as categoryName  from trTrainingStudentM sm 
join trTrainingDetailM dm on sm.iClassAutoKey = dm.iAutoKey
join trCourse course on dm.trCourse_sCode = course.sCode
join trCategory cate on dm.sKey = cate.sCode
 where sNobr =@nobr and dm.iYear =@year and dm.bIsPublished = 1 and GETDATE() &gt; dm.dDateTimeD and dm.bIsNeedClassRpt = 1 and sm.bPresence= 1
order by dDateTimeA desc">
                <SelectParameters>
                    <asp:Parameter Name="nobr" />
                    <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="year" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <telerik:RadGrid ID="gvReport" runat="server" CellSpacing="0" Culture="zh-TW" 
                DataSourceID="sdsReport" GridLines="None" Skin="Vista" AllowPaging="True" onitemdatabound="gvReport_ItemDataBound" 
                >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" 
                    DataSourceID="sdsReport">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="categoryName" 
                            FilterControlAltText="Filter categoryName column" HeaderText="階層" 
                            UniqueName="categoryName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
                            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
                            ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" 
                            FilterControlAltText="Filter iClassAutoKey column" HeaderText="iClassAutoKey" 
                            SortExpression="iClassAutoKey" UniqueName="iClassAutoKey" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sJobCode" 
                            FilterControlAltText="Filter sJobCode column" HeaderText="sJobCode" 
                            SortExpression="sJobCode" UniqueName="sJobCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sJobsCode" 
                            FilterControlAltText="Filter sJobsCode column" HeaderText="sJobsCode" 
                            SortExpression="sJobsCode" UniqueName="sJobsCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sJoblCode" 
                            FilterControlAltText="Filter sJoblCode column" HeaderText="sJoblCode" 
                            SortExpression="sJoblCode" UniqueName="sJoblCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sDeptCode" 
                            FilterControlAltText="Filter sDeptCode column" HeaderText="sDeptCode" 
                            SortExpression="sDeptCode" UniqueName="sDeptCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNobr" 
                            FilterControlAltText="Filter sNobr column" HeaderText="sNobr" 
                            SortExpression="sNobr" UniqueName="sNobr" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trJoinType_sCode" 
                            FilterControlAltText="Filter trJoinType_sCode column" 
                            HeaderText="trJoinType_sCode" SortExpression="trJoinType_sCode" 
                            UniqueName="trJoinType_sCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bPresence" DataType="System.Boolean" 
                            FilterControlAltText="Filter bPresence column" HeaderText="bPresence" 
                            SortExpression="bPresence" UniqueName="bPresence" Visible="False">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="sAbsenceNote" 
                            FilterControlAltText="Filter sAbsenceNote column" HeaderText="sAbsenceNote" 
                            SortExpression="sAbsenceNote" UniqueName="sAbsenceNote" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNote1" 
                            FilterControlAltText="Filter sNote1 column" HeaderText="sNote1" 
                            SortExpression="sNote1" UniqueName="sNote1" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iScore" DataType="System.Int32" 
                            FilterControlAltText="Filter iScore column" HeaderText="iScore" 
                            SortExpression="iScore" UniqueName="iScore" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dTeacherKeyDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dTeacherKeyDate column" 
                            HeaderText="dTeacherKeyDate" SortExpression="dTeacherKeyDate" 
                            UniqueName="dTeacherKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sTeacherCode" 
                            FilterControlAltText="Filter sTeacherCode column" HeaderText="sTeacherCode" 
                            SortExpression="sTeacherCode" UniqueName="sTeacherCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" 
                            FilterControlAltText="Filter bPass column" HeaderText="bPass" 
                            SortExpression="bPass" UniqueName="bPass" Visible="False">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="sPassNote" 
                            FilterControlAltText="Filter sPassNote column" HeaderText="sPassNote" 
                            SortExpression="sPassNote" UniqueName="sPassNote" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNote2" 
                            FilterControlAltText="Filter sNote2 column" HeaderText="sNote2" 
                            SortExpression="sNote2" UniqueName="sNote2" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iNote2Score" DataType="System.Int32" 
                            FilterControlAltText="Filter iNote2Score column" HeaderText="iNote2Score" 
                            SortExpression="iNote2Score" UniqueName="iNote2Score" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dNote2ScoreKeyDate" 
                            DataType="System.DateTime" 
                            FilterControlAltText="Filter dNote2ScoreKeyDate column" 
                            HeaderText="dNote2ScoreKeyDate" SortExpression="dNote2ScoreKeyDate" 
                            UniqueName="dNote2ScoreKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNote3" 
                            FilterControlAltText="Filter sNote3 column" HeaderText="sNote3" 
                            SortExpression="sNote3" UniqueName="sNote3" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNote4" 
                            FilterControlAltText="Filter sNote4 column" HeaderText="sNote4" 
                            SortExpression="sNote4" UniqueName="sNote4" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNote5" 
                            FilterControlAltText="Filter sNote5 column" HeaderText="sNote5" 
                            SortExpression="sNote5" UniqueName="sNote5" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sKeyMan" 
                            FilterControlAltText="Filter sKeyMan column" HeaderText="sKeyMan" 
                            SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
                            SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName" 
                            FilterControlAltText="Filter sName column" HeaderText="課程名稱" 
                            SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iSession" 
                            FilterControlAltText="Filter iSession column" HeaderText="梯次" 
                            UniqueName="iSession">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dDateTimeA" DataFormatString="{0:d}" 
                            DataType="System.DateTime" FilterControlAltText="Filter dDateTimeA column" 
                            HeaderText="開課日期" SortExpression="dDateTimeA" UniqueName="dDateTimeA">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dNote2KeyDate" DataType="System.DateTime" 
                            EmptyDataText="" FilterControlAltText="Filter dNote2KeyDate column" 
                            HeaderText="心得填寫日期" SortExpression="dNote2KeyDate" 
                            UniqueName="dNote2KeyDate" DataFormatString="{0:yyyy/M/d HH:mm:ss}">
                        </telerik:GridBoundColumn>
                        <telerik:GridHyperLinkColumn DataNavigateUrlFields="iAutoKey" DataNavigateUrlFormatString="~/eTraining/Staff/ExpReport.aspx?ID={0}&amp;tab=0" 
                            FilterControlAltText="Filter hlFill column" Text="心得填寫" 
                            UniqueName="hlFill">
                        </telerik:GridHyperLinkColumn>
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
        <telerik:RadPageView ID="pvQuestionary" runat="server">
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW" 
                GridLines="None" Skin="Vista" AllowPaging="True" 
                onitemdatabound="gv_ItemDataBound" AutoGenerateColumns="False" 
                OnItemCommand="gv_ItemCommand" OnNeedDataSource="gv_NeedDataSource" 
                >
                <MasterTableView datakeynames="Id">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="CourseName" 
                            FilterControlAltText="Filter CourseName column" HeaderText="課程名稱" 
                            UniqueName="CourseName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ClassSession" 
                            FilterControlAltText="Filter ClassSession column" HeaderText="梯次" 
                            UniqueName="ClassSession">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Qname" 
                            FilterControlAltText="Filter Qname column" HeaderText="問卷名稱" 
                            SortExpression="Qname" UniqueName="Qname">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="WriteDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter WriteDate column" HeaderText="填寫時間" 
                            SortExpression="WriteDate" UniqueName="WriteDate" 
                            DataFormatString="{0:yyyy/M/d HH:mm}" EmptyDataText="">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FillFormDatetimeB" 
                            FilterControlAltText="Filter FillFormDatetimeB column" HeaderText="填寫日起" 
                            SortExpression="FillFormDatetimeB" UniqueName="FillFormDatetimeB" 
                            Visible="False" DataFormatString="{0:d}" DataType="System.DateTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FillFormDatetimeE" 
                            FilterControlAltText="Filter FillFormDatetimeE column" HeaderText="填寫截止日" 
                            SortExpression="FillFormDatetimeE" UniqueName="FillFormDatetimeE" 
                            DataFormatString="{0:d}" DataType="System.DateTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TotalScore" 
                            FilterControlAltText="Filter iTotalFraction column" HeaderText="總分" 
                            SortExpression="TotalScore" UniqueName="TotalScore" Visible="False" 
                            DataType="System.Int32">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn CommandName="Write" 
                            FilterControlAltText="Filter column column" Text="填寫" UniqueName="column">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="Id" 
                            FilterControlAltText="Filter Id column" 
                            UniqueName="Id" Visible="False">
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
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Windows7">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </HeaderContextMenu>
            </telerik:RadGrid>
            <br />
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <telerik:RadWindow ID="win" runat="server" Height="600px" Modal="True" 
        VisibleStatusbar="False" Width="800px">
    </telerik:RadWindow>
       </telerik:RadAjaxPanel>
</asp:Content>
