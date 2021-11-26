<%@ Page Title="需求調查檢視" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ViewPlanFill.aspx.cs" Inherits="eTraining_Admin_Plan_ViewPlanFill" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <div>
        <h2>
            需求調查檢視</h2>
            年度<telerik:RadComboBox ID="cbYear" runat="server" Width="60px">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" Width="70px" Owner="cbYear" />
                </Items>
            </telerik:RadComboBox>
            <br />
            <br />
        <div style="background-color:#CDE5FF;float: left; width: 24%" class="funcblock">
            
            <br />
            <telerik:RadTreeView ID="tvDept" runat="server" OnNodeClick="tvDept_NodeClick">
            </telerik:RadTreeView>
            <br />
        </div>
        <div style="float: right; width: 75%">
            <asp:Label ID="lblDept" runat="server" Visible="False"></asp:Label>
            
            <asp:Label ID="lblMang" runat="server" Font-Size="Medium" Visible="False"></asp:Label>
            <br />
            <telerik:RadGrid ID="gvDetail" runat="server" CellSpacing="0" DataSourceID="sdsDetail"
                GridLines="None" Skin="Outlook" Visible="False">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsDetail">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                            HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="JOBL_NAME" FilterControlAltText="Filter JOBL_NAME column"
                            HeaderText="職等" SortExpression="JOBL_NAME" UniqueName="JOBL_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                            HeaderText="工號" SortExpression="sNobr" UniqueName="sNobr">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                            HeaderText="課程" SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iDemandIntensityP" DataType="System.Int32" FilterControlAltText="Filter iDemandIntensityP column"
                            HeaderText="個人需求強度" SortExpression="iDemandIntensityP" UniqueName="iDemandIntensityP">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iDemandIntensityM" DataType="System.Int32" FilterControlAltText="Filter iDemandIntensityM column"
                            HeaderText="主管需求強度" SortExpression="iDemandIntensityM" UniqueName="iDemandIntensityM">
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
            <telerik:RadButton ID="btnBack" runat="server" OnClick="RadButton2_Click" Text="回上頁"
                Visible="False">
            </telerik:RadButton>
            <br />
            <telerik:RadButton ID="btnDetail" runat="server" OnClick="RadButton1_Click1" 
                Text="明細">
            </telerik:RadButton>
            <br />
            <br />
            <telerik:RadGrid ID="gvTotal" runat="server" CellSpacing="0" 
                DataSourceID="sdsSum" GridLines="None" Skin="Outlook" AllowSorting="True" 
                Culture="zh-TW">
<MasterTableView autogeneratecolumns="False" datasourceid="sdsSum">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="sDeptCode" 
            FilterControlAltText="Filter sDeptCode column" HeaderText="部門" 
            SortExpression="sDeptCode" UniqueName="sDeptCode">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sName" 
            FilterControlAltText="Filter sName column" HeaderText="類別" 
            SortExpression="sName" UniqueName="sName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Expr1" 
            FilterControlAltText="Filter Expr1 column" HeaderText="課程" 
            SortExpression="Expr1" UniqueName="Expr1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Expr2" DataType="System.Int32" 
            FilterControlAltText="Filter Expr2 column" HeaderText="個人需求" ReadOnly="True" 
            SortExpression="Expr2" UniqueName="Expr2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Expr3" DataType="System.Int32" 
            FilterControlAltText="Filter Expr3 column" HeaderText="主管需求" ReadOnly="True" 
            SortExpression="Expr3" UniqueName="Expr3">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
            </telerik:RadGrid>
            <br />
            <asp:SqlDataSource ID="sdsDetail" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT q.*,b.*,d.*,j.*,cat.*,jl.JOB_NAME as JOBL_NAME FROM [trTrainingQuest] as q 
left join BASE b on q.sNobr= b.NOBR 
join dept as d on q.sDeptCode =d.D_NO 
join JOB as j on q.sJobCode=j.JOB 
join trRequirementTemplateCat as cat on q.sKey=cat.sCode 
join jobl as jl on q.sJoblCode = jl.JOBL
WHERE (([iYear] = @iYear) AND ([sDeptCode] = @sDeptCode))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cbYear" DefaultValue="0" Name="iYear" PropertyName="SelectedValue"
                        Type="Int32" />
                    <asp:ControlParameter ControlID="lblDept" DefaultValue="0" Name="sDeptCode" PropertyName="Text"
                        Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsSum" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                
                SelectCommand="SELECT tq.sDeptCode, ca.sName, co.sName AS Expr1, SUM(tq.iDemandIntensityP) AS Expr2, SUM(tq.iDemandIntensityM) AS Expr3 FROM trTrainingQuest AS tq INNER JOIN trRequirementTemplateCat AS ca ON tq.sKey = ca.sCode INNER JOIN trCourse AS co ON tq.trCourse_sCode = co.sCode WHERE (tq.sDeptCode = @sDeptCode) AND (tq.iYear = @iYear) GROUP BY tq.sDeptCode, ca.sName, co.sName">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblDept" DefaultValue="0" Name="sDeptCode" PropertyName="Text" />
                    <asp:ControlParameter ControlID="cbYear" DefaultValue="0" Name="iYear" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
        </div>
    </div>

</asp:Content>
