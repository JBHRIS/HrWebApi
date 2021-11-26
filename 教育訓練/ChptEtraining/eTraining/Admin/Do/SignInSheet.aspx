<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignInSheet.aspx.cs" Inherits="eTraining_Admin_Do_SignInSheet" Culture="Auto" meta:resourcekey="PageResource1" uiculture="Auto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>教育中心確認出席名單<telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        </h2>
    </div>
    上課日期<telerik:RadComboBox ID="cbxAttendClassDate" Runat="server" 
        DataSourceID="sdsAttendClassDate" DataTextField="dClassDate" 
        DataTextFormatString="{0:d}" DataValueField="dClassDate" 
        AutoPostBack="True" 
        onselectedindexchanged="cbxAttendClassDate_SelectedIndexChanged" 
        Width="125px" Culture="zh-TW" 
        meta:resourcekey="cbxAttendClassDateResource1">
    </telerik:RadComboBox>
    <br />
    <br />
    <table width="100%">
    <tr>
    <td style="width:49%;" align="left" valign="top">
    <h2>簽到單</h2>
    <telerik:RadGrid ID="gvSignInSheet" runat="server" 
        AllowMultiRowSelection="True" AutoGenerateColumns="False" CellSpacing="0" 
        Culture="zh-TW" DataSourceID="sdsSignInSheet" GridLines="None" 
        onitemdatabound="gvSignInSheet_ItemDataBound" Skin="Outlook" Width="100%" 
            meta:resourcekey="gvSignInSheetResource1">
        <clientsettings>
            <selecting allowrowselect="True" />
        </clientsettings>
<MasterTableView datakeynames="iAutoKey" datasourceid="sdsSignInSheet">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataType="System.Int32" 
            FilterControlAltText="Filter Item column" UniqueName="Item">
        </telerik:GridBoundColumn>
        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
            UniqueName="column" meta:resourcekey="GridClientSelectColumnResource1">
        </telerik:GridClientSelectColumn>
        <telerik:GridBoundColumn DataField="dClassDate" DataFormatString="{0:d}" 
            DataType="System.DateTime" FilterControlAltText="Filter dClassDate column" 
            HeaderText="上課日期" SortExpression="dClassDate" UniqueName="dClassDate" 
            meta:resourcekey="GridBoundColumnResource9">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NOBR" 
            FilterControlAltText="Filter NOBR column" HeaderText="工號" SortExpression="NOBR" 
            UniqueName="NOBR" meta:resourcekey="GridBoundColumnResource10">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NAME_C" 
            FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
            SortExpression="NAME_C" UniqueName="NAME_C" 
            meta:resourcekey="GridBoundColumnResource11">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="D_NAME" 
            FilterControlAltText="Filter D_NAME column" HeaderText="部門" 
            SortExpression="D_NAME" UniqueName="D_NAME" 
            meta:resourcekey="GridBoundColumnResource12">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="bPresence" DataType="System.Boolean" 
            FilterControlAltText="Filter bPresence column" HeaderText="bPresence" 
            SortExpression="bPresence" UniqueName="bPresence" Visible="False" 
            meta:resourcekey="GridCheckBoxColumnResource2">
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="trTrainingStudentM_ID" 
            DataType="System.Int32" 
            FilterControlAltText="Filter trTrainingStudentM_ID column" 
            HeaderText="trTrainingStudentM_ID" SortExpression="trTrainingStudentM_ID" 
            UniqueName="trTrainingStudentM_ID" Visible="False" 
            meta:resourcekey="GridBoundColumnResource13">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="AttendClassDateID" DataType="System.Int32" 
            FilterControlAltText="Filter AttendClassDateID column" 
            HeaderText="AttendClassDateID" SortExpression="AttendClassDateID" 
            UniqueName="AttendClassDateID" Visible="False" 
            meta:resourcekey="GridBoundColumnResource14">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
            ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" 
            Visible="False" meta:resourcekey="GridBoundColumnResource15">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iClassAutoKey column" HeaderText="iClassAutoKey" 
            SortExpression="iClassAutoKey" UniqueName="iClassAutoKey" Visible="False" 
            meta:resourcekey="GridBoundColumnResource16">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
    </td>
    <td style="width:49%;" align="left" valign="top">
    <h2>離職人員</h2>
    <telerik:RadGrid ID="gvNonSignInSheet" runat="server" 
        AllowMultiRowSelection="True" AutoGenerateColumns="False" CellSpacing="0" 
        Culture="zh-TW" DataSourceID="sdsNonSignInSheet" GridLines="None" 
            Skin="Outlook" Width="100%" meta:resourcekey="gvNonSignInSheetResource1">
        <clientsettings>
            <selecting />
        </clientsettings>
<MasterTableView datakeynames="iAutoKey" datasourceid="sdsNonSignInSheet">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="dClassDate" DataFormatString="{0:d}" 
            DataType="System.DateTime" FilterControlAltText="Filter dClassDate column" 
            HeaderText="上課日期" SortExpression="dClassDate" UniqueName="dClassDate" 
            meta:resourcekey="GridBoundColumnResource1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NOBR" 
            FilterControlAltText="Filter NOBR column" HeaderText="工號" SortExpression="NOBR" 
            UniqueName="NOBR" meta:resourcekey="GridBoundColumnResource2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NAME_C" 
            FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
            SortExpression="NAME_C" UniqueName="NAME_C" 
            meta:resourcekey="GridBoundColumnResource3">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="D_NAME" 
            FilterControlAltText="Filter D_NAME column" HeaderText="部門" 
            SortExpression="D_NAME" UniqueName="D_NAME" 
            meta:resourcekey="GridBoundColumnResource4">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="bPresence" DataType="System.Boolean" 
            FilterControlAltText="Filter bPresence column" HeaderText="bPresence" 
            SortExpression="bPresence" UniqueName="bPresence" Visible="False" 
            meta:resourcekey="GridCheckBoxColumnResource1">
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="trTrainingStudentM_ID" 
            DataType="System.Int32" 
            FilterControlAltText="Filter trTrainingStudentM_ID column" 
            HeaderText="trTrainingStudentM_ID" SortExpression="trTrainingStudentM_ID" 
            UniqueName="trTrainingStudentM_ID" Visible="False" 
            meta:resourcekey="GridBoundColumnResource5">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="AttendClassDateID" DataType="System.Int32" 
            FilterControlAltText="Filter AttendClassDateID column" 
            HeaderText="AttendClassDateID" SortExpression="AttendClassDateID" 
            UniqueName="AttendClassDateID" Visible="False" 
            meta:resourcekey="GridBoundColumnResource6">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
            ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" 
            Visible="False" meta:resourcekey="GridBoundColumnResource7">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iClassAutoKey column" HeaderText="iClassAutoKey" 
            SortExpression="iClassAutoKey" UniqueName="iClassAutoKey" Visible="False" 
            meta:resourcekey="GridBoundColumnResource8">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
    
    </td>
    </tr>
    </table>
        <telerik:RadButton ID="btnSave" runat="server" Text="存檔" 
        onclick="btnSave_Click" meta:resourcekey="btnSaveResource1">
        </telerik:RadButton>
            <br />
    <br />
    <asp:SqlDataSource ID="sdsSignInSheet" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select p.*,d.dClassDate,b.NOBR,b.NAME_C,DEPT.D_NAME from trTrainingStudentPresence p
join trAttendClassDate d on p.AttendClassDateID = d.iAutoKey
join trTrainingStudentM sm on p.trTrainingStudentM_ID = sm.iAutoKey
join BASE b on sm.sNobr = b.NOBR
join BASETTS tts on tts.NOBR = b.NOBR
join DEPT on tts.DEPT = DEPT.D_NO
where p.iClassAutoKey = @ID
and d.dClassDate = @date
and tts.TTSCODE in ('1','4','6')
and @date between tts.ADATE and tts.DDATE


">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" 
                DbType="Int32" />
            <asp:ControlParameter ControlID="cbxAttendClassDate" DbType="Date" 
                DefaultValue="1900/01/01" Name="date" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsNonSignInSheet" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select p.*,d.dClassDate,b.NOBR,b.NAME_C,DEPT.D_NAME from trTrainingStudentPresence p
join trAttendClassDate d on p.AttendClassDateID = d.iAutoKey
join trTrainingStudentM sm on p.trTrainingStudentM_ID = sm.iAutoKey
join BASE b on sm.sNobr = b.NOBR
join BASETTS tts on tts.NOBR = b.NOBR
join DEPT on tts.DEPT = DEPT.D_NO
where p.iClassAutoKey = @ID
and d.dClassDate = @date
and tts.TTSCODE not in ('1','4','6')
and @date between tts.ADATE and tts.DDATE
and @date between DEPT.ADATE and DEPT.DDATE

">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" 
                DbType="Int32" />
            <asp:ControlParameter ControlID="cbxAttendClassDate" DbType="Date" 
                DefaultValue="1900/01/01" Name="date" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="sdsAttendClassDate" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        SelectCommand="SELECT * FROM [trAttendClassDate] WHERE ([iClassAutoKey] = @iClassAutoKey)">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="iClassAutoKey" 
                QueryStringField="ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
