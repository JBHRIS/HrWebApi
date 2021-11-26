<%@ Page Title="查詢上課紀錄" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ViewCourseY.aspx.cs" Inherits="eTraining_Staff_ViewCourseY" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        查詢上課紀錄</h2>
    年度<telerik:RadComboBox ID="cbxYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbxYear_SelectedIndexChanged"
        Width="70px">
    </telerik:RadComboBox>
    <asp:Label ID="lblClassID" runat="server" Visible="False"></asp:Label>
    <br />
    <br />
    <div style="float: left; width: 65%">
        <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
            Culture="zh-TW" DataSourceID="sdsGv" GridLines="None" Skin="WebBlue" 
            Width="100%" onselectedindexchanged="gv_SelectedIndexChanged">
            <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsGv" 
                AllowPaging="True">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="categoryName" FilterControlAltText="Filter categoryName column"
                        HeaderText="階層名稱" SortExpression="categoryName" UniqueName="categoryName">
                        <ItemStyle Wrap="False" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="courseName" FilterControlAltText="Filter courseName column"
                        HeaderText="課程名稱" SortExpression="courseName" UniqueName="courseName">
                        <ItemStyle Wrap="False" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" FilterControlAltText="Filter iSession column"
                        HeaderText="梯次" SortExpression="iSession" UniqueName="iSession">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dDateA" DataFormatString="{0:d}" DataType="System.DateTime"
                        FilterControlAltText="Filter dDateA column" HeaderText="開課日期" SortExpression="dDateA"
                        UniqueName="dDateA">
                        <ItemStyle Wrap="False" />
                    </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" FilterControlAltText="Filter bPass column"
                        HeaderText="是否結訓" SortExpression="bPass" UniqueName="bPass">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                        HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sPassNote" FilterControlAltText="Filter sPassNote column"
                        HeaderText="sPassNote" SortExpression="sPassNote" UniqueName="sPassNote" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                        HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sJobCode" FilterControlAltText="Filter sJobCode column"
                        HeaderText="sJobCode" SortExpression="sJobCode" UniqueName="sJobCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sNote1" FilterControlAltText="Filter sNote1 column"
                        HeaderText="sNote1" SortExpression="sNote1" UniqueName="sNote1" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iScore" DataType="System.Decimal" FilterControlAltText="Filter iScore column"
                        HeaderText="iScore" SortExpression="iScore" UniqueName="iScore" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sAbsenceNote" FilterControlAltText="Filter sAbsenceNote column"
                        HeaderText="sAbsenceNote" SortExpression="sAbsenceNote" UniqueName="sAbsenceNote"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn DataField="bAbsence" DataType="System.Boolean" FilterControlAltText="Filter bAbsence column"
                        HeaderText="bAbsence" SortExpression="bAbsence" UniqueName="bAbsence" Visible="False">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridBoundColumn DataField="trJoinType_sCode" FilterControlAltText="Filter trJoinType_sCode column"
                        HeaderText="trJoinType_sCode" SortExpression="trJoinType_sCode" UniqueName="trJoinType_sCode"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                        HeaderText="trCourse_sCode" SortExpression="trCourse_sCode" UniqueName="trCourse_sCode"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                        HeaderText="sNobr" SortExpression="sNobr" UniqueName="sNobr" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sDeptCode" FilterControlAltText="Filter sDeptCode column"
                        HeaderText="sDeptCode" SortExpression="sDeptCode" UniqueName="sDeptCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sJoblCode" FilterControlAltText="Filter sJoblCode column"
                        HeaderText="sJoblCode" SortExpression="sJoblCode" UniqueName="sJoblCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sJobsCode" FilterControlAltText="Filter sJobsCode column"
                        HeaderText="sJobsCode" SortExpression="sJobsCode" UniqueName="sJobsCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn CommandName="Select" 
                        FilterControlAltText="Filter Select column" Text="教材" UniqueName="Select">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="ClassID" 
                        FilterControlAltText="Filter ClassID column" HeaderText="課程ID" 
                        UniqueName="ClassID" Visible="False">
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
        <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            OnSelecting="sdsGv_Selecting" SelectCommand="select sm.*,dm.trCourse_sCode,c.sName as courseName,dm.iSession,dm.dDateA,cat.sName as categoryName,dm.iAutoKey as ClassID from trTrainingStudentM sm 
join trTrainingDetailM dm on sm.iClassAutoKey = dm.iAutoKey
join trCourse c on dm.trCourse_sCode = c.sCode
join trCategory cat on dm.sKey = cat.sCode
where dm.iYear = @year
and sm.sNobr = @nobr
and GETDATE()&gt;dm.dDateTimeD
and bPresence =1
order by dm.dDateA desc">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="year" PropertyName="SelectedValue" />
                <asp:Parameter Name="nobr" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div style="float: right; width: 34%">
        <telerik:RadGrid ID="gvMaterial" runat="server" CellSpacing="0" Culture="zh-TW" 
            DataSourceID="sdsMaterial" GridLines="None">
<MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" 
                DataSourceID="sdsMaterial">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridHyperLinkColumn DataNavigateUrlFormatString="~/eTraining/Admin/download.ashx?ID={0}" 
            DataTextField="FileOriginName" DataNavigateUrlFields="FileStoredName" FilterControlAltText="Filter column column" 
            HeaderText="檔案" UniqueName="Download">
        </telerik:GridHyperLinkColumn>
        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
            ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileSize" DataType="System.Int32" 
            FilterControlAltText="Filter FileSize column" HeaderText="FileSize" 
            SortExpression="FileSize" UniqueName="FileSize" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileCategory" 
            FilterControlAltText="Filter FileCategory column" HeaderText="FileCategory" 
            SortExpression="FileCategory" UniqueName="FileCategory" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileCategoryKey" 
            FilterControlAltText="Filter FileCategoryKey column" 
            HeaderText="FileCategoryKey" SortExpression="FileCategoryKey" 
            UniqueName="FileCategoryKey" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileOriginName" 
            FilterControlAltText="Filter FileOriginName column" HeaderText="檔案" 
            SortExpression="FileOriginName" UniqueName="FileOriginName" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileNameExt" 
            FilterControlAltText="Filter FileNameExt column" HeaderText="FileNameExt" 
            SortExpression="FileNameExt" UniqueName="FileNameExt" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileStoredName" 
            FilterControlAltText="Filter FileStoredName column" HeaderText="FileStoredName" 
            SortExpression="FileStoredName" UniqueName="FileStoredName" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileStoredPath" 
            FilterControlAltText="Filter FileStoredPath column" HeaderText="FileStoredPath" 
            SortExpression="FileStoredPath" UniqueName="FileStoredPath" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileNote" 
            FilterControlAltText="Filter FileNote column" HeaderText="備註" 
            SortExpression="FileNote" UniqueName="FileNote">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileKeyMan" 
            FilterControlAltText="Filter FileKeyMan column" HeaderText="FileKeyMan" 
            SortExpression="FileKeyMan" UniqueName="FileKeyMan" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileKeyDate" DataType="System.DateTime" 
            FilterControlAltText="Filter FileKeyDate column" HeaderText="FileKeyDate" 
            SortExpression="FileKeyDate" UniqueName="FileKeyDate" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="FileDeleted" DataType="System.Boolean" 
            FilterControlAltText="Filter FileDeleted column" HeaderText="FileDeleted" 
            SortExpression="FileDeleted" UniqueName="FileDeleted" Visible="False">
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="FileDeletedMan" 
            FilterControlAltText="Filter FileDeletedMan column" HeaderText="FileDeletedMan" 
            SortExpression="FileDeletedMan" UniqueName="FileDeletedMan" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileDeletedDate" DataType="System.DateTime" 
            FilterControlAltText="Filter FileDeletedDate column" 
            HeaderText="FileDeletedDate" SortExpression="FileDeletedDate" 
            UniqueName="FileDeletedDate" Visible="False">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="sdsMaterial" runat="server" 
            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select * from UPLOAD where FileCategory = 'TeachingMaterial' and FileCategoryKey=@ID
and FileDeleted =0">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblClassID" DefaultValue=" " Name="ID" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <br />
</asp:Content>
