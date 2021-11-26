<%@ Page Title="開課報名" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="JoinCourse.aspx.cs" Inherits="eTraining_Staff_JoinCourse" %>

<%@ Register src="../../UC/ApplyCourse.ascx" tagname="ApplyCourse" tagprefix="uc1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ApplyCourse ID="ApplyCourse1" runat="server" />
    <br />
    <telerik:RadGrid ID="gvJoinCourse" runat="server" CellSpacing="0" 
        DataSourceID="sdsJoinCourse" GridLines="None" Culture="zh-TW" 
        Visible="False" AutoGenerateColumns="False">
<MasterTableView DataKeyNames="iAutoKey" 
            DataSourceID="sdsJoinCourse">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="sName" 
            FilterControlAltText="Filter sName column" HeaderText="階層" 
            SortExpression="sName" UniqueName="sName" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Expr1" 
            FilterControlAltText="Filter Expr1 column" HeaderText="課程名稱" 
            SortExpression="Expr1" UniqueName="Expr1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
            ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" 
            FilterControlAltText="Filter iYear column" HeaderText="iYear" 
            SortExpression="iYear" UniqueName="iYear" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dDateA" DataType="System.DateTime" 
            FilterControlAltText="Filter dDateA column" HeaderText="dDateA" 
            SortExpression="dDateA" UniqueName="dDateA" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dDateD" DataType="System.DateTime" 
            FilterControlAltText="Filter dDateD column" HeaderText="dDateD" 
            SortExpression="dDateD" UniqueName="dDateD" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sTimeA" 
            FilterControlAltText="Filter sTimeA column" HeaderText="sTimeA" 
            SortExpression="sTimeA" UniqueName="sTimeA" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sTimeD" 
            FilterControlAltText="Filter sTimeD column" HeaderText="sTimeD" 
            SortExpression="sTimeD" UniqueName="sTimeD" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" 
            FilterControlAltText="Filter iSession column" HeaderText="iSession" 
            SortExpression="iSession" UniqueName="iSession" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="trTeacher_sCode" 
            FilterControlAltText="Filter trTeacher_sCode column" 
            HeaderText="trTeacher_sCode" SortExpression="trTeacher_sCode" 
            UniqueName="trTeacher_sCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="trClassroom_sCode" 
            FilterControlAltText="Filter trClassroom_sCode column" 
            HeaderText="trClassroom_sCode" SortExpression="trClassroom_sCode" 
            UniqueName="trClassroom_sCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="bWebJoin" DataType="System.Boolean" 
            FilterControlAltText="Filter bWebJoin column" HeaderText="網路報名" 
            SortExpression="bWebJoin" UniqueName="bWebJoin">
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="dWebJoinDateB" DataType="System.DateTime" 
            FilterControlAltText="Filter dWebJoinDateB column" HeaderText="線上報名開始日" 
            SortExpression="dWebJoinDateB" UniqueName="dWebJoinDateB">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dWebJoinDateE" DataType="System.DateTime" 
            FilterControlAltText="Filter dWebJoinDateE column" HeaderText="線上報名截止日" 
            SortExpression="dWebJoinDateE" UniqueName="dWebJoinDateE">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sKeyMan" 
            FilterControlAltText="Filter sKeyMan column" HeaderText="sKeyMan" 
            SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
            FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
            SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iUpLimitP" DataType="System.Int32" 
            FilterControlAltText="Filter iUpLimitP column" HeaderText="人數上限" 
            SortExpression="iUpLimitP" UniqueName="iUpLimitP">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iLowLimitP" DataType="System.Int32" 
            FilterControlAltText="Filter iLowLimitP column" HeaderText="iLowLimitP" 
            SortExpression="iLowLimitP" UniqueName="iLowLimitP" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="bIsPublished" DataType="System.Boolean" 
            FilterControlAltText="Filter bIsPublished column" HeaderText="bIsPublished" 
            SortExpression="bIsPublished" UniqueName="bIsPublished" Visible="False">
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="iYearPlanAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iYearPlanAutoKey column" 
            HeaderText="iYearPlanAutoKey" SortExpression="iYearPlanAutoKey" 
            UniqueName="iYearPlanAutoKey" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
            UniqueName="TemplateColumn">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="~/eTraining/Staff/CourseDetail.aspx">詳細資料</asp:HyperLink>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
        </FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <asp:SqlDataSource ID="sdsJoinCourse" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        
        SelectCommand="SELECT ca.sName, co.sName AS Expr1, tdm.iAutoKey, tdm.iYear, tdm.dDateTimeA, tdm.dDateTimeD, tdm.dDateA, tdm.dDateD, tdm.sTimeA, tdm.sTimeD, tdm.iSession, tdm.trCourse_sCode, tdm.sKey, tdm.trTeacher_sCode, tdm.trClassroom_sCode, tdm.bWebJoin, tdm.dWebJoinDateB, tdm.dWebJoinDateE, tdm.sKeyMan, tdm.dKeyDate, tdm.iUpLimitP, tdm.iLowLimitP, tdm.bIsPublished, tdm.iYearPlanAutoKey FROM trTrainingDetailM AS tdm INNER JOIN trCategory AS ca ON tdm.sKey = ca.sCode INNER JOIN trCourse AS co ON tdm.trCourse_sCode = co.sCode
where tdm.bIsPublished=1 and tdm.bWebJoin=1 and  GETDATE()&lt;=tdm.dWebJoinDateE and GETDATE()&gt;=tdm.dWebJoinDateB">
    </asp:SqlDataSource>
</asp:Content>

