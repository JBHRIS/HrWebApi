<%@ Page Title="查詢職能積分" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="ViewTrainingCard.aspx.cs" Inherits="eTraining_Staff_ViewTrainingCard" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>查詢職能積分</h2>
 
    <br />
    <table style="width:100%;">
        <tr>
            <td width="50%">
                   訓練卡<telerik:RadComboBox ID="cbxCard" Runat="server" AutoPostBack="True" 
        DataSourceID="sdsCard" DataTextField="sName" DataValueField="sCode">
    </telerik:RadComboBox></td>
            <td width="50%" align="right">
                            <asp:Panel ID="pnlUserScore" runat="server">
                                <asp:Label ID="lblUserJobScore" runat="server" Font-Bold="True" 
                                    Font-Size="Large" ForeColor="#FF6600"></asp:Label>
                                ｜<asp:Label ID="lblJobScoreAmt" runat="server"></asp:Label>
                            </asp:Panel>
                </td>
        </tr>
    </table>
<br />
    <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" GridLines="None" 
        Skin="WebBlue" Width="70%" AutoGenerateColumns="False" Culture="zh-TW" 
        DataSourceID="sdsCardData" ondatabound="gv_DataBound">
<MasterTableView datakeynames="iAutokey" datasourceid="sdsCardData">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="sName" 
            FilterControlAltText="Filter sName column" HeaderText="課程名稱" 
            SortExpression="sName" UniqueName="sName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAutokey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutokey column" HeaderText="iAutokey" 
            ReadOnly="True" SortExpression="iAutokey" UniqueName="iAutokey" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sNobr" 
            FilterControlAltText="Filter sNobr column" HeaderText="sNobr" 
            SortExpression="sNobr" UniqueName="sNobr" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="OJT_sCode" 
            FilterControlAltText="Filter OJT_sCode column" HeaderText="OJT_sCode" 
            SortExpression="OJT_sCode" UniqueName="OJT_sCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="trCourse_sCode" 
            FilterControlAltText="Filter trCourse_sCode column" HeaderText="trCourse_sCode" 
            SortExpression="trCourse_sCode" UniqueName="trCourse_sCode" Visible="False">
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
        <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" 
            FilterControlAltText="Filter bPass column" HeaderText="通過" 
            SortExpression="bPass" UniqueName="bPass">
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="jobSkillName" 
            FilterControlAltText="Filter jobSkillName column" HeaderText="熟練度" 
            UniqueName="jobSkillName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dOJT_Date" DataType="System.DateTime" 
            FilterControlAltText="Filter dOJT_Date column" HeaderText="上課日期" 
            SortExpression="dOJT_Date" UniqueName="dOJT_Date" DataFormatString="{0:d}" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dCheckDate" 
            FilterControlAltText="Filter dCheckDate column" HeaderText="主管確認日期" 
            UniqueName="dCheckDate">
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
<telerik:GridBoundColumn DataField="CourseJobScore" HeaderText="職能積分" 
            SortExpression="CourseJobScore" UniqueName="CourseJobScore" 
            FilterControlAltText="Filter iJobScore1 column" DataType="System.Int32"></telerik:GridBoundColumn>
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
    <asp:SqlDataSource ID="sdsCard" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        onselecting="sdsCard_Selecting" SelectCommand="select tpl.sCode,tpl.sName from trOJTStudentM sm left join trOJTTemplate tpl
on sm.OJT_sCode=tpl.sCode
where sm.sNobr = @nobr">
        <SelectParameters>
            <asp:Parameter Name="nobr" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsCardData" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        onselecting="sdsCardData_Selecting" SelectCommand="select sd.*,tpld.trCourse_sCode as CourseCode,tpld.OJT_sCode,course.sName,course.iJobScore,course.iJobScore as CourseJobScore,b.NAME_C,js.sName as jobSkillName
 from trOJTTemplateDetail tpld 
left join trOJTStudentD sd on tpld.trCourse_sCode = sd.trCourse_sCode and sd.sNobr =@nobr
left join trCourse course on tpld.trCourse_sCode = course.sCode
left join BASE b on sd.sTeacher = b.NOBR
left join JobSkill js on sd.iLevel = js.iAutoKey
where tpld.OJT_sCode = @ojtCode">
        <SelectParameters>
            <asp:Parameter Name="nobr" />
            <asp:ControlParameter ControlID="cbxCard" DefaultValue="0" Name="ojtCode" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
<br />
</asp:Content>

