<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="StudentScore.aspx.cs" Inherits="eTraining_Admin_Do_StudentScore" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableBlue" style="width: 100%">
        <tr>
            <th colspan="4">
                <h2>
                    學員表現評分表</h2>
            </th>
        </tr>
        <tr>
            <th>
                階層
            </th>
            <td>
                &nbsp;
                <asp:Label ID="lblCat" runat="server"></asp:Label>
            </td>
            <th>
                課程名稱
            </th>
            <td>
                &nbsp;
                <asp:Label ID="lblCourse" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                上課日期
            </th>
            <td>
                &nbsp;
                <asp:Label ID="lblClassDateA" runat="server"></asp:Label>
                ~<asp:Label ID="lblClassDateD" runat="server"></asp:Label>
            </td>
            <th>
                講師
            </th>
            <td>
                &nbsp;
                <asp:Label ID="lblTeacher" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <telerik:RadGrid ID="gvStudent" runat="server" CellSpacing="0" Culture="zh-TW" 
        DataSourceID="sdsGvStudent" GridLines="None" Skin="Office2007">
<MasterTableView autogeneratecolumns="False" datasourceid="sdsGvStudent">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="D_NAME" 
            FilterControlAltText="Filter D_NAME column" HeaderText="店別" 
            SortExpression="D_NAME" UniqueName="D_NAME">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NAME_C" 
            FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
            SortExpression="NAME_C" UniqueName="NAME_C">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
            HeaderText="上課表現(針對主動性、投入度、上課表現等描述上課情形)" UniqueName="TemplateColumn">
            <ItemTemplate>
                <telerik:RadTextBox ID="RadTextBox1" Runat="server" Width="100%">
                </telerik:RadTextBox>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
            HeaderText="成績" UniqueName="TemplateColumn1">
            <ItemTemplate>
                <telerik:RadTextBox ID="RadTextBox2" Runat="server" Width="50px">
                </telerik:RadTextBox>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="sdsGvStudent" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select dept.D_NAME,b.NAME_C from trTrainingStudentM sm 
left join BASE b on sm.sNobr = b.NOBR
left join BASETTS tts on sm.sNobr = tts.NOBR
left join DEPT on DEPT.D_NO = sm.sDeptCode
where tts.TTSCODE in ('1','4','6') and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and sm.iClassAutoKey = @ID">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblID" DefaultValue="0" Name="ID" 
                PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lblID" runat="server" Text="37" Visible="False"></asp:Label>
    <br />
</asp:Content>
