<%@ Page Title="填寫組訓員評估報告" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="FillQuestionary.aspx.cs" Inherits="eTraining_Admin_Do_FillQuestionary" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>填寫組訓員評估報告</h2>
    &nbsp;年度
    <telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" 
        onselectedindexchanged="cbxYear_SelectedIndexChanged" AutoPostBack="True">
    </telerik:RadComboBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <telerik:RadGrid ID="gv" runat="server" Skin="Windows7" CellSpacing="0" 
        Culture="zh-TW" DataSourceID="sdsGv" GridLines="None" 
        onitemdatabound="gv_ItemDataBound">
<MasterTableView autogeneratecolumns="False" datakeynames="iAutokey" 
            datasourceid="sdsGv" AllowPaging="True">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="CateName" 
            FilterControlAltText="Filter CateName column" HeaderText="階層" 
            UniqueName="CateName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CourseName" 
            FilterControlAltText="Filter CourseName column" HeaderText="課程名稱" 
            UniqueName="CourseName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ClassSession" 
            FilterControlAltText="Filter ClassSession column" HeaderText="梯次" 
            UniqueName="ClassSession">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DateA" DataFormatString="{0:d}" 
            FilterControlAltText="Filter dDateA column" HeaderText="課程日期" 
            UniqueName="dDateA">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Qname" 
            FilterControlAltText="Filter Qname column" HeaderText="問卷名稱" 
            SortExpression="Qname" UniqueName="Qname">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAutokey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutokey column" HeaderText="iAutokey" 
            ReadOnly="True" SortExpression="iAutokey" UniqueName="iAutokey" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sCode" 
            FilterControlAltText="Filter sCode column" HeaderText="sCode" 
            SortExpression="sCode" UniqueName="sCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="qType_sCode" 
            FilterControlAltText="Filter qType_sCode column" HeaderText="qType_sCode" 
            SortExpression="qType_sCode" UniqueName="qType_sCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sNobr" 
            FilterControlAltText="Filter sNobr column" HeaderText="sNobr" 
            SortExpression="sNobr" UniqueName="sNobr" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sPW" 
            FilterControlAltText="Filter sPW column" HeaderText="sPW" SortExpression="sPW" 
            UniqueName="sPW" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sName" 
            FilterControlAltText="Filter sName column" HeaderText="sName" 
            SortExpression="sName" UniqueName="sName" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sDeptCode" 
            FilterControlAltText="Filter sDeptCode column" HeaderText="sDeptCode" 
            SortExpression="sDeptCode" UniqueName="sDeptCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sDeptName" 
            FilterControlAltText="Filter sDeptName column" HeaderText="sDeptName" 
            SortExpression="sDeptName" UniqueName="sDeptName" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dAmountDate" DataType="System.DateTime" 
            FilterControlAltText="Filter dAmountDate column" HeaderText="dAmountDate" 
            SortExpression="dAmountDate" UniqueName="dAmountDate" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dWriteDate" DataType="System.DateTime" 
            FilterControlAltText="Filter dWriteDate column" HeaderText="填寫日" 
            SortExpression="dWriteDate" UniqueName="dWriteDate" 
            DataFormatString="{0:d}" Visible="False" EmptyDataText="">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dSchoolDateB" DataType="System.DateTime" 
            FilterControlAltText="Filter dSchoolDateB column" HeaderText="dSchoolDateB" 
            SortExpression="dSchoolDateB" UniqueName="dSchoolDateB" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dSchoolDateE" DataType="System.DateTime" 
            FilterControlAltText="Filter dSchoolDateE column" HeaderText="dSchoolDateE" 
            SortExpression="dSchoolDateE" UniqueName="dSchoolDateE" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dFillFormDatetimeB" 
            DataType="System.DateTime" 
            FilterControlAltText="Filter dFillFormDatetimeB column" 
            HeaderText="填寫日起" SortExpression="dFillFormDatetimeB" 
            UniqueName="dFillFormDatetimeB" DataFormatString="{0:d}" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dFillFormDatetimeE" 
            DataType="System.DateTime" 
            FilterControlAltText="Filter dFillFormDatetimeE column" 
            HeaderText="填寫截止日" SortExpression="dFillFormDatetimeE" 
            UniqueName="dFillFormDatetimeE" DataFormatString="{0:d}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dTeacherCheckedDate" 
            DataType="System.DateTime" 
            FilterControlAltText="Filter dTeacherCheckedDate column" 
            HeaderText="dTeacherCheckedDate" SortExpression="dTeacherCheckedDate" 
            UniqueName="dTeacherCheckedDate" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dTRCheckedDate" DataType="System.DateTime" 
            FilterControlAltText="Filter dTRCheckedDate column" HeaderText="dTRCheckedDate" 
            SortExpression="dTRCheckedDate" UniqueName="dTRCheckedDate" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" 
            FilterControlAltText="Filter iYear column" HeaderText="iYear" 
            SortExpression="iYear" UniqueName="iYear" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" 
            FilterControlAltText="Filter iSession column" HeaderText="iSession" 
            SortExpression="iSession" UniqueName="iSession" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iClassAutoKey column" HeaderText="iClassAutoKey" 
            SortExpression="iClassAutoKey" UniqueName="iClassAutoKey" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="trCourse_sCode" 
            FilterControlAltText="Filter trCourse_sCode column" HeaderText="trCourse_sCode" 
            SortExpression="trCourse_sCode" UniqueName="trCourse_sCode" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="trCourse_sName" 
            FilterControlAltText="Filter trCourse_sName column" HeaderText="trCourse_sName" 
            SortExpression="trCourse_sName" UniqueName="trCourse_sName" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iTotalFraction" DataType="System.Int32" 
            FilterControlAltText="Filter iTotalFraction column" HeaderText="總分" 
            SortExpression="iTotalFraction" UniqueName="iTotalFraction" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sKeyMan" 
            FilterControlAltText="Filter sKeyMan column" HeaderText="sKeyMan" 
            SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
            FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
            SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridHyperLinkColumn DataNavigateUrlFormatString="~/eTraining/Questionary/qWrite.aspx?Code={0}" 
        DataNavigateUrlFields="sCode" 
            FilterControlAltText="Filter Write column" Text="填寫" UniqueName="Write">
        </telerik:GridHyperLinkColumn>
        <telerik:GridBoundColumn DataField="CourseCode" 
            FilterControlAltText="Filter CourseCode column" HeaderText="課程代碼" 
            UniqueName="CourseCode" Visible="False">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Windows7"></HeaderContextMenu>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="sdsGv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        onselecting="sdsGv_Selecting" SelectCommand="select bm.*,qm.sName as Qname,bm.iClassAutoKey,dm.iSession as ClassSession,dm.trCourse_sCode as CourseCode,c.sName as CourseName,ca.sName as CateName,dm.dDateA as DateA
from qBaseM bm 
left join qQuestionaryM qm on bm.qQuestionary_sCode = qm.sCode
left join ClassQuestionnaire cq on bm.iClassAutoKey = cq.iClassAutoKey and bm.qQuestionary_sCode = cq.qQuestionaryM
left join trTrainingDetailM dm on cq.iClassAutoKey = dm.iAutoKey
left join trCourse c on dm.trCourse_sCode = c.sCode
left join trCategory ca on dm.sKey=ca.sCode
where dm.iYear =@year and qm.FillerCategory ='M'
order by dFillFormDatetimeE desc">
        <SelectParameters>
            <asp:ControlParameter ControlID="cbxYear" DefaultValue="-1" Name="year" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
</asp:Content>
