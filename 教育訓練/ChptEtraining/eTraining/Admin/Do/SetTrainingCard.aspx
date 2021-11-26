<%@ Page Title="指定職能積分卡" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SetTrainingCard.aspx.cs" Inherits="eTraining_Admin_Do_SetTrainingCard" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>
            指定職能積分卡</h2>
        <asp:Panel ID="pnlTP" runat="server">
            <telerik:RadGrid ID="gvTP" runat="server" CellSpacing="0" Culture="zh-TW" 
                DataSourceID="sdsGvTp" GridLines="None" 
                onselectedindexchanged="gvTP_SelectedIndexChanged" Skin="Outlook" 
                Width="70%" AutoGenerateColumns="False">
                <MasterTableView datakeynames="sCode" 
                    datasourceid="sdsGvTp">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
                            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
                            ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName" 
                            FilterControlAltText="Filter sName column" HeaderText="名稱" 
                            SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sKeyMan" 
                            FilterControlAltText="Filter sKeyMan column" HeaderText="sKeyMan" 
                            SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
                            SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn FilterControlAltText="Filter column column" 
                            Text="加入學員" UniqueName="Select" CommandName="Select">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="sCode" 
                            FilterControlAltText="Filter sCode column" HeaderText="代碼" 
                            SortExpression="sCode" UniqueName="sCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                            UniqueName="TemplateColumn" Visible="False">
                            <ItemTemplate>
                                <telerik:RadButton ID="btnView" runat="server" 
                                    CommandArgument='<%# Eval("sCode") %>' onclick="btnView_Click" Text="檢視學員">
                                </telerik:RadButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
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
            <asp:SqlDataSource ID="sdsGvTp" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                SelectCommand="SELECT * FROM [trOJTTemplate] where IsValid = 1"></asp:SqlDataSource>
            <asp:Label ID="lblOJTcode" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblOJTcodeV" runat="server"></asp:Label>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnlMember" runat="server" Visible="False">
            <telerik:RadGrid ID="gv" runat="server" AllowFilteringByColumn="True" 
            AllowPaging="True" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGV" 
            GridLines="None" Skin="Outlook" Width="80%" AllowMultiRowSelection="True" 
                AllowSorting="True" AutoGenerateColumns="False" 
                onitemdatabound="gv_ItemDataBound">
                <clientsettings>
                    <selecting allowrowselect="True" EnableDragToSelectRows="False" 
                        UseClientSelectColumnOnly="True" />
                    <Selecting AllowRowSelect="True" />
                </clientsettings>
                <MasterTableView datasourceid="sdsGV" 
                    datakeynames="nobr">
                    <CommandItemSettings ExportToPdfText="Export to PDF">
                    </CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column1 column" 
                            UniqueName="column1">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" 
            FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
            SortExpression="NAME_C" UniqueName="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NOBR" 
            FilterControlAltText="Filter NOBR column" HeaderText="工號" SortExpression="NOBR" 
            UniqueName="NOBR">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="D_NAME" 
            FilterControlAltText="Filter D_NAME column" HeaderText="部門" 
            SortExpression="D_NAME" UniqueName="D_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="JOB_NAME" 
            FilterControlAltText="Filter JOB_NAME column" HeaderText="職稱" 
            SortExpression="JOB_NAME" UniqueName="JOB_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="JOB_NAME1" 
            FilterControlAltText="Filter JOB_NAME1 column" HeaderText="職等" 
            SortExpression="JOB_NAME1" UniqueName="JOB_NAME1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OJT_sCode" EmptyDataText="" 
                            FilterControlAltText="Filter OJT_sCode column" UniqueName="OJT_sCode" 
                            Visible="False">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Outlook">
                </HeaderContextMenu>
            </telerik:RadGrid>
            <br />
            <telerik:RadButton ID="btnSave" runat="server" onclick="btnSave_Click" 
                Text="儲存">
            </telerik:RadButton>
            &nbsp;&nbsp;<telerik:RadButton ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                Text="取消">
            </telerik:RadButton>
            &nbsp;<asp:SqlDataSource ID="sdsGV" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select e.NAME_C,a.NOBR,(dept.D_NO +dept.D_NAME) as D_NAME,c.JOB_NAME,d.JOB_NAME,stu.OJT_sCode
from BASETTS a
join DEPT dept on a.DEPT=dept.D_NO
join JOB c on a.JOB=c.JOB
join JOBL d on a.JOBL=d.JOBL
join BASE e on a.NOBR=e.NOBR
left join trOJTStudentM stu on e.NOBR = stu.sNobr and OJT_sCode=@id
where CONVERT(varchar(10), GETDATE(),111) between a.ADATE and a.DDATE 
and CONVERT(varchar(10), GETDATE(),111) between dept.ADATE and dept.DDATE
and TTSCODE in('1','4','6')
">
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvTP" DefaultValue="0" Name="id" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            &nbsp;<br />
        </asp:Panel>
        
        <br />
        <asp:Panel ID="pnlView" runat="server" Visible="False">
            <telerik:RadGrid ID="gvView" runat="server" CellSpacing="0" Culture="zh-TW" 
                DataSourceID="sdsGvView" GridLines="None" Skin="Outlook" 
                AllowPaging="True">
                <MasterTableView autogeneratecolumns="False" datakeynames="iAutokey" 
                    datasourceid="sdsGvView">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="iAutokey" DataType="System.Int32" 
                            FilterControlAltText="Filter iAutokey column" HeaderText="iAutokey" 
                            ReadOnly="True" SortExpression="iAutokey" UniqueName="iAutokey" 
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNobr" 
                            FilterControlAltText="Filter sNobr column" HeaderText="工號" 
                            SortExpression="sNobr" UniqueName="sNobr">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OJT_sCode" 
                            FilterControlAltText="Filter OJT_sCode column" HeaderText="OJT_sCode" 
                            SortExpression="OJT_sCode" UniqueName="OJT_sCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trCourse_sCode" 
                            FilterControlAltText="Filter trCourse_sCode column" HeaderText="課程代碼" 
                            SortExpression="trCourse_sCode" UniqueName="trCourse_sCode">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sTeacher" 
                            FilterControlAltText="Filter sTeacher column" HeaderText="sTeacher" 
                            SortExpression="sTeacher" UniqueName="sTeacher" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dTeacherKeyDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dTeacherKeyDate column" 
                            HeaderText="dTeacherKeyDate" SortExpression="dTeacherKeyDate" 
                            UniqueName="dTeacherKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" 
                            FilterControlAltText="Filter bPass column" HeaderText="bPass" 
                            SortExpression="bPass" UniqueName="bPass" Visible="False">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="dOJT_Date" DataType="System.DateTime" 
                            FilterControlAltText="Filter dOJT_Date column" HeaderText="dOJT_Date" 
                            SortExpression="dOJT_Date" UniqueName="dOJT_Date" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iJobScore" DataType="System.Decimal" 
                            FilterControlAltText="Filter iJobScore column" HeaderText="iJobScore" 
                            SortExpression="iJobScore" UniqueName="iJobScore" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iLevel" 
                            FilterControlAltText="Filter iLevel column" HeaderText="iLevel" 
                            SortExpression="iLevel" UniqueName="iLevel" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dCreatedDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dCreatedDate column" HeaderText="dCreatedDate" 
                            SortExpression="dCreatedDate" UniqueName="dCreatedDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sCreateMan" 
                            FilterControlAltText="Filter sCreateMan column" HeaderText="sCreateMan" 
                            SortExpression="sCreateMan" UniqueName="sCreateMan" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sKeyMan" 
                            FilterControlAltText="Filter sKeyMan column" HeaderText="sKeyMan" 
                            SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
                            SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" 
                            FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
                            SortExpression="NAME_C" UniqueName="NAME_C">
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
            <asp:SqlDataSource ID="sdsGvView" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select tpld.OJT_sCode,sd.*,b.NAME_C from trOJTTemplateDetail tpld
left join  trOJTStudentD sd on tpld.trCourse_sCode = sd.trCourse_sCode
left join BASE b on sd.sNobr=b.NOBR
where tpld.OJT_sCode=@OJTcode">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblOJTcodeV" DefaultValue="0" Name="OJTcode" 
                        PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <telerik:RadButton ID="btnBACKL" runat="server" onclick="btnBACKL_Click" 
                Text="返回">
            </telerik:RadButton>
            <br />
        </asp:Panel>
        <br />
    </div>
</asp:Content>
