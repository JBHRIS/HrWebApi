<%@ Page Title="員工報名訓練課程" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="StaffApplyCourse.aspx.cs" Inherits="eTraining_Manager_StaffApplyCourse" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../../UC/ApplyCourse.ascx" tagname="ApplyCourse" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="style1">
        <h2 class="style1">
            報名員工訓練課程</h2>
        <div class="style1">
            <br />
            年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" 
                AutoPostBack="True" onselectedindexchanged="cbxYear_SelectedIndexChanged">
            </telerik:RadComboBox>
            <br />
            <br />
        <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW" GridLines="None" 
            onitemdatabound="RadGrid1_ItemDataBound" Skin="Windows7" 
                AutoGenerateColumns="False" onneeddatasource="gv_NeedDataSource">
<MasterTableView datakeynames="iAutoKey">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="iAutokey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutokey column" HeaderText="iAutokey" 
            ReadOnly="True" SortExpression="iAutokey" UniqueName="iAutokey" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="cateName" 
            FilterControlAltText="Filter cateName column" HeaderText="階層" 
            UniqueName="cateName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="courseName" 
            FilterControlAltText="Filter courseName column" HeaderText="課程" 
            SortExpression="courseName" UniqueName="courseName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dDateTimeA" DataType="System.DateTime" 
            FilterControlAltText="Filter dDateTimeA column" HeaderText="上課時間" 
            SortExpression="dDateTimeA" UniqueName="dDateTimeA" 
            DataFormatString="{0:yyyy/M/d HHmm}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dWebJoinDateB" DataType="System.DateTime" 
            FilterControlAltText="Filter dWebJoinDateB column" HeaderText="報名開始日" 
            SortExpression="dWebJoinDateB" UniqueName="dWebJoinDateB" 
            DataFormatString="{0:d}" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dWebJoinDateE" DataType="System.DateTime" 
            FilterControlAltText="Filter dWebJoinDateE column" HeaderText="報名截止日" 
            SortExpression="dWebJoinDateE" UniqueName="dWebJoinDateE" 
            DataFormatString="{0:d}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iUpLimitP" DataType="System.Int32" 
            FilterControlAltText="Filter iUpLimitP column" HeaderText="上限人數" 
            SortExpression="iUpLimitP" UniqueName="iUpLimitP" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="studentNum" 
            FilterControlAltText="Filter studentNum column" HeaderText="已報名人數" 
            UniqueName="studentNum">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
            UniqueName="TemplateColumn">
            <ItemTemplate>
                <asp:HyperLink ID="hlJoin" runat="server" 
                    NavigateUrl="~/eTraining/Manager/CourseDetailM.aspx">報名</asp:HyperLink>
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
        </div>
        <br />
        <asp:SqlDataSource ID="sdsGV" runat="server" 
            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select  tm.iAutokey,co.sName,tm.dDateTimeA,tm.dWebJoinDateB,tm.dWebJoinDateE,tm.iUpLimitP from trTrainingDetailM tm
join trCourse co on tm.trCourse_sCode=co.sCode
where tm.bIsPublished=1 and GETDATE()&lt;=tm.dWebJoinDateE and GETDATE()&gt;=tm.dWebJoinDateB
and bWebJoin=1
 and tm.iYear=@Year
">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="Year" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        
    </div>
</asp:Content>
