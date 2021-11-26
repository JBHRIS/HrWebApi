<%@ Page Title="員工職能訓練" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="OJT.aspx.cs" Inherits="eTraining_Manager_OJT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        員工職能訓練<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
            IsSticky="True" Skin="Web20" Height="50px">
            載入中，請稍後...
        </telerik:RadAjaxLoadingPanel>
    </h2>
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
            width="100%" HorizontalAlign="NotSet" 
        LoadingPanelID="RadAjaxLoadingPanel1">
                <div style="float: left; width: 20%">
                    部門<telerik:RadComboBox ID="cbxOjtDept" Runat="server" AutoPostBack="True" 
                        DataTextField="Text" DataValueField="Value" 
                        onselectedindexchanged="cbxOjtDept_SelectedIndexChanged">
                    </telerik:RadComboBox>
        <telerik:RadGrid ID="gvEmp" runat="server" AutoGenerateColumns="False" CellSpacing="0"
            Culture="zh-TW" DataSourceID="sdsName" GridLines="None" OnSelectedIndexChanged="gvEmp_SelectedIndexChanged"
            Skin="Outlook">
            <MasterTableView DataKeyNames="NOBR" DataSourceID="sdsName">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                        Text="選擇" UniqueName="Select">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                        HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                        HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                        HeaderText="D_NAME" SortExpression="D_NAME" UniqueName="D_NAME" Visible="False">
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
    </div>
    <div style="float: right; width: 78%">
        <asp:Panel ID="pnlOJT" runat="server" Visible="False">
            <br />
            <table style="width:100%;">
                <tr>
                    <td>
                        <telerik:RadComboBox ID="cbxCard" runat="server" AutoPostBack="True" 
                            DataSourceID="sdsCard" DataTextField="sName" DataValueField="sCode">
                        </telerik:RadComboBox>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblUserJobScore" runat="server" Font-Size="Large" 
                            ForeColor="#FF6600" Font-Bold="True"></asp:Label>
                        ｜<asp:Label ID="lblJobScoreAmt" runat="server" ForeColor="Gray"></asp:Label>
                    </td>
                    <td>
                                <telerik:RadButton ID="btnSaveList2" runat="server" onclick="btnSaveList_Click" 
                Text="儲存">
            </telerik:RadButton>
        
                    </td>
                </tr>
            </table>
            <br />
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" GridLines="None" Skin="WebBlue"
                Width="100%" AutoGenerateColumns="False" Culture="zh-TW" 
                DataSourceID="sdsCardData" onitemcommand="gv_ItemCommand" 
                onitemdatabound="gv_ItemDataBound" ondatabound="gv_DataBound" >
                <MasterTableView DataKeyNames="iAutokey" DataSourceID="sdsCardData" 
                    nomasterrecordstext="未設定訓練卡" showheaderswhennorecords="False">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                            HeaderText="課程名稱" SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iAutokey" FilterControlAltText="Filter iAutokey column"
                            HeaderText="iAutokey" SortExpression="iAutokey" UniqueName="iAutokey" 
                            DataType="System.Int32" ReadOnly="True" Visible="False" EmptyDataText="">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNobr" 
                            FilterControlAltText="Filter sNobr column" HeaderText="sNobr" 
                            SortExpression="sNobr" UniqueName="sNobr" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OJT_sCode" 
                            FilterControlAltText="Filter OJT_sCode column" HeaderText="OJT_sCode" 
                            SortExpression="OJT_sCode" UniqueName="OJT_sCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CourseCode" 
                            FilterControlAltText="Filter CourseCode column" HeaderText="CourseCode" 
                            SortExpression="CourseCode" UniqueName="CourseCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sTeacher" 
                            FilterControlAltText="Filter sTeacher column" HeaderText="教導者" 
                            SortExpression="sTeacher" UniqueName="sTeacher" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dTeacherKeyDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dTeacherKeyDate column" 
                            HeaderText="dTeacherKeyDate" SortExpression="dTeacherKeyDate" 
                            UniqueName="dTeacherKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" FilterControlAltText="Filter bPass column"
                            HeaderText="通過" SortExpression="bPass" UniqueName="bPass">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="dOJT_Date" DataType="System.DateTime" FilterControlAltText="Filter dOJT_Date column"
                            HeaderText="上課日期" SortExpression="dOJT_Date" UniqueName="dOJT_Date" 
                            DataFormatString="{0:d}" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iJobScore" DataType="System.Decimal" FilterControlAltText="Filter iJobScore column"
                            HeaderText="iJobScore" SortExpression="iJobScore" UniqueName="iJobScore" 
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iLevel" FilterControlAltText="Filter iLevel column"
                            HeaderText="熟練度" SortExpression="iLevel" UniqueName="iLevel" 
                            EmptyDataText="" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dCreatedDate" DataType="System.DateTime" FilterControlAltText="Filter dCreatedDate column"
                            HeaderText="dCreatedDate" SortExpression="dCreatedDate" 
                            UniqueName="dCreatedDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sCreateMan" FilterControlAltText="Filter sCreateMan column"
                            HeaderText="sCreateMan" SortExpression="sCreateMan" UniqueName="sCreateMan" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                            HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                            HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CourseJobScore" FilterControlAltText="Filter CourseJobScore column"
                            HeaderText="職能積分" SortExpression="CourseJobScore" UniqueName="CourseJobScore" 
                            DataType="System.Int32">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="PushButton" CommandName="DataEdit" 
                            FilterControlAltText="Filter DataEdit column" Text="編輯" 
                            UniqueName="DataEdit" Visible="False">
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn ButtonType="PushButton" CommandName="LevelEdit" 
                            FilterControlAltText="Filter LevelEdit column" Text="熟練度" 
                            UniqueName="LevelEdit" Visible="False">
                        </telerik:GridButtonColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter Level column" 
                            UniqueName="Level" HeaderText="熟練度">
                            <ItemTemplate>
                                <telerik:RadComboBox ID="cbxLevel" Runat="server" AppendDataBoundItems="True" 
                                    DataSourceID="sdsJobSkill" DataTextField="sName" DataValueField="iAutoKey">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="未選擇" Value="non-selected" />
                                    </Items>
                                </telerik:RadComboBox>
                                <asp:SqlDataSource ID="sdsLevel" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                                    SelectCommand="SELECT * FROM [JobSkill]"></asp:SqlDataSource>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridCheckBoxColumn FilterControlAltText="Filter trainned column" 
                            UniqueName="trainned" HeaderText="確認">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" 
                            FilterControlAltText="Filter NAME_C column" HeaderText="確認者" 
                            UniqueName="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dCheckDate" DataFormatString="{0:d}" 
                            EmptyDataText="" FilterControlAltText="Filter dCheckDate column" 
                            HeaderText="主管確認日期" UniqueName="dCheckDate">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sCheckMan" EmptyDataText="" 
                            FilterControlAltText="Filter sCheckMan column" UniqueName="sCheckMan" 
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
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
            <br />
            <telerik:RadButton ID="btnSaveList" runat="server" onclick="btnSaveList_Click" 
                Text="儲存">
            </telerik:RadButton>
        </asp:Panel>
        <asp:Panel ID="pnlEdit" runat="server" Visible="False">
            <table class="tableBlue">
                <tr>
                    <th>
                        已訓練</th>
                    <td>
                        <asp:CheckBox ID="cbPass" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>
                        訓練日期</th>
                    <td>
                        <telerik:RadDatePicker ID="dpDate" Runat="server">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                <td colspan="2">
                    <telerik:RadButton ID="btnSave" runat="server" Text="存檔" 
                        onclick="btnSave_Click">
                    </telerik:RadButton>
                    &nbsp;&nbsp;
                    <telerik:RadButton ID="btnCancel" runat="server" Text="返回" 
                        onclick="btnCancel_Click">
                    </telerik:RadButton>
                    <telerik:RadGrid ID="gvNobr" runat="server" AllowFilteringByColumn="True" 
                        AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" 
                        DataSourceID="sdsNobr" GridLines="None" 
                        onselectedindexchanged="gvNobr_SelectedIndexChanged" Visible="False" Width="5%">
                        <MasterTableView datakeynames="NOBR" datasourceid="sdsNobr">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Select" 
                                    FilterControlAltText="Filter column column" Text="選擇" UniqueName="column">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn AutoPostBackOnFilter="True" 
                                    CurrentFilterFunction="Contains" DataField="NAME_C" 
                                    FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
                                    ShowFilterIcon="False" SortExpression="NAME_C" UniqueName="NAME_C">
                                    <HeaderStyle Font-Size="Smaller" />
                                    <ItemStyle Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn AutoPostBackOnFilter="True" 
                                    CurrentFilterFunction="Contains" DataField="NOBR" 
                                    FilterControlAltText="Filter NOBR column" HeaderText="工號" 
                                    ShowFilterIcon="False" SortExpression="NOBR" UniqueName="NOBR">
                                    <HeaderStyle Font-Size="Smaller" />
                                    <ItemStyle Font-Size="Smaller" />
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
                    <telerik:RadTextBox ID="tbTeacher" Runat="server" Enabled="False" 
                        ReadOnly="True" Visible="False">
                    </telerik:RadTextBox>
                    <asp:Label ID="lblTeacherNobr" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlLevel" runat="server" Visible="False">
        
        <table class="tableBlue">
            <tr>
                <th>
                    熟練度</th>
                <td>
                    <asp:SqlDataSource ID="sdsJobSkill" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                        SelectCommand="SELECT * FROM [JobSkill]"></asp:SqlDataSource>
                    <telerik:RadComboBox ID="cbxJobSkill" Runat="server" DataSourceID="sdsJobSkill" 
                        DataTextField="sCode" DataValueField="iAutoKey">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <telerik:RadButton ID="btnSaveLevel" runat="server" Text="存檔" 
                        onclick="btnSaveLevel_Click">
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>
    <asp:SqlDataSource ID="sdsName" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select dt.D_NAME,ba.NOBR,ba.NAME_C from BASE ba 
join BASETTS tts on ba.NOBR = tts.NOBR
join DEPT dt on dt.D_NO=tts.DEPT
where tts.TTSCODE in ('1','4','6')
and tts.DEPT = @dept
and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and CONVERT(varchar(10), GETDATE(),111) between dt.ADATE and dt.DDATE
group by dt.D_NAME,ba.NOBR,ba.NAME_C

" OnSelecting="sdsName_Selecting">
        <SelectParameters>
            <asp:ControlParameter ControlID="cbxOjtDept" DefaultValue="-1" Name="dept" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsCardData" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select sd.*,tpld.trCourse_sCode as CourseCode,tpld.OJT_sCode,course.sName,course.iJobScore as CourseJobScore,b.NAME_C from trOJTTemplateDetail tpld 
left join trOJTStudentD sd on tpld.trCourse_sCode = sd.trCourse_sCode and sd.sNobr =@nobr
left join trCourse course on tpld.trCourse_sCode = course.sCode
left join BASE b on sd.sCheckMan = b.NOBR

where tpld.OJT_sCode = @ojtCode">
        <SelectParameters>
            <asp:ControlParameter ControlID="gvEmp" DefaultValue="0" Name="nobr" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="cbxCard" DefaultValue="0" Name="ojtCode" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsCard" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select ojttpl.sCode,ojttpl.sName from trOJTStudentM ojtsm 
left join trOJTTemplate ojttpl on ojtsm.OJT_sCode = ojttpl.sCode
where ojtsm.sNobr =@nobr and ojttpl.IsValid = 1
group by ojttpl.sCode,ojttpl.sName">
        <SelectParameters>
            <asp:ControlParameter ControlID="gvEmp" DefaultValue="0" Name="nobr" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsNobr" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select b.NAME_C,b.NOBR from BASE b left join BASETTS tts on b.NOBR = tts.NOBR
where tts.TTSCODE in ('1','4','6') and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE">
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="lblKey" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblOjtCode" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCourseCode" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDept" runat="server" Visible="False"></asp:Label>    
        </telerik:RadAjaxPanel>

</asp:Content>
