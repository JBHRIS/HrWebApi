<%@ Page Title="個人職能積分查詢" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="EmpOjtJobView.aspx.cs" Inherits="eTraining_Reports_Review_EmpOjtJobView" %>

<%@ Register src="../../../UC/UserQuickSearch.ascx" tagname="UserQuickSearch" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        個人職能積分查詢
    </h2>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Web20"
        IsSticky="True">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <div style="background-color: #CDE5FF; float: left; width: 24%" class="funcblock">
            <br />
            <telerik:RadComboBox ID="cbxCard" runat="server" AutoPostBack="True" 
                Culture="zh-TW" DataSourceID="sdsCard" DataTextField="sName" 
                DataValueField="sCode" 
                onselectedindexchanged="cbxCard_SelectedIndexChanged">
            </telerik:RadComboBox>
            <asp:SqlDataSource ID="sdsCard" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                SelectCommand="select sCode,sName from trOJTTemplate"></asp:SqlDataSource>
            <uc2:UserQuickSearch ID="UserQuickSearch1" runat="server" />
            <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
        </div>
        <div style="float: right; width: 75%">
                    <asp:Panel ID="pnlOJT" runat="server">
            <br />
            <table style="width:100%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="right">
                        <asp:Label ID="lblUserJobScore" runat="server" Font-Size="Large" 
                            ForeColor="#FF6600" Font-Bold="True"></asp:Label>
                        ｜<asp:Label ID="lblJobScoreAmt" runat="server" ForeColor="Gray"></asp:Label>
                    </td>
                </tr>
            </table>
                        <asp:Label ID="lblMsg" runat="server" Font-Size="X-Large" ForeColor="Red" 
                            Text="查無資料 !!" Visible="False"></asp:Label>
            <br />
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" GridLines="None" Skin="Windows7"
                Width="100%" AutoGenerateColumns="False" Culture="zh-TW" 
                onitemdatabound="gv_ItemDataBound" ondatabound="gv_DataBound" 
                            DataSourceID="sdsCardData" AllowSorting="True" >
                <MasterTableView DataKeyNames="iAutokey" 
                    nomasterrecordstext="未設定訓練卡" showheaderswhennorecords="False" 
                    DataSourceID="sdsCardData">
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
                            HeaderText="區主管通過" SortExpression="bPass" UniqueName="bPass">
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
                        <telerik:GridBoundColumn DataField="JobSkillName" 
                            FilterControlAltText="Filter JobSkillName column" HeaderText="熟練度" 
                            UniqueName="JobSkillName">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn FilterControlAltText="Filter trainned column" 
                            UniqueName="trainned" HeaderText="主管確認">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" 
                            FilterControlAltText="Filter NAME_C column" HeaderText="確認主管" 
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
                        <asp:SqlDataSource ID="sdsCardData" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select sd.*,tpld.trCourse_sCode as CourseCode,tpld.OJT_sCode,course.sName,course.iJobScore as CourseJobScore,b.NAME_C,js.sName as JobSkillName
 from trOJTTemplateDetail tpld 
left join trOJTStudentD sd on tpld.trCourse_sCode = sd.trCourse_sCode and sd.sNobr =@nobr
left join trCourse course on tpld.trCourse_sCode = course.sCode
left join BASE b on sd.sCheckMan = b.NOBR
left join JobSkill js on sd.iLevel = js.iAutoKey
where tpld.OJT_sCode = @ojtCode">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblNobr" DefaultValue="0" Name="nobr" 
                                    PropertyName="Text" />
                                <asp:ControlParameter ControlID="cbxCard" DefaultValue="0" Name="ojtCode" 
                                    PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
            <br />
        </asp:Panel>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
