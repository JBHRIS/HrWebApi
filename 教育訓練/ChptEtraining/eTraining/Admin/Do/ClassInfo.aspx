<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassInfo.aspx.cs" Inherits="eTraining_Admin_Do_ClassInfo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
        }
        
        .RadGrid .rgHeader
        {
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
        }
        
        .RadGrid .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }
        
        .RadGrid .rgHeader
        {
            cursor: default;
        }
        
        .RadGrid .rgFilterBox
        {
            border-width: 1px;
            border-style: solid;
            margin: 0;
            padding: 2px 1px 3px;
            font-size: 12px;
            vertical-align: middle;
        }
        
        .RadGrid .rgFilter
        {
            width: 22px;
            height: 22px;
            margin: 0 0 0 2px;
        }
        
        .RadGrid .rgFilter
        {
            width: 16px;
            height: 16px;
            border: 0;
            margin: 0;
            padding: 0;
            background-color: transparent;
            background-repeat: no-repeat;
            vertical-align: middle;
            font-size: 1px;
            cursor: pointer;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
        
        .RadGrid_Outlook
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Outlook
        {
            border: 1px solid #002d96;
            background: #fff;
            color: #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <div style="float: left; width: 15%">
            <telerik:RadTabStrip ID="RadTabStrip2" runat="server" Orientation="VerticalLeft"
                SelectedIndex="0" MultiPageID="RadMultiPage2" Skin="Office2007">
                <Tabs>
                    <telerik:RadTab runat="server" PageViewID="pvClassInfo" Text="上課資訊" 
                        Selected="True">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="課程前中後查檢" PageViewID="pvNotify">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
        </div>
        <div style="float: right; width: 85%;">
            <telerik:RadMultiPage ID="RadMultiPage2" runat="server" SelectedIndex="0" Width="550px">
                <telerik:RadPageView ID="pvClassInfo" runat="server">
                    <h2>
                        上課資訊</h2>
                    <telerik:RadGrid ID="gvClassList" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                        Culture="zh-TW" DataSourceID="sdsClassGv" GridLines="None" HorizontalAlign="Center"
                        Skin="Outlook" Width="100%">
                        <MasterTableView AllowMultiColumnSorting="True" AllowPaging="True" AllowSorting="True"
                            DataKeyNames="iAutoKey" DataSourceID="sdsClassGv">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
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
                                <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                    HeaderText="開課代碼" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" FilterControlAltText="Filter iYear column"
                                    HeaderText="年度" SortExpression="iYear" UniqueName="iYear" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sTimeA" FilterControlAltText="Filter sTimeA column"
                                    HeaderText="sTimeA" SortExpression="sTimeA" UniqueName="sTimeA" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sTimeD" FilterControlAltText="Filter sTimeD column"
                                    HeaderText="sTimeD" SortExpression="sTimeD" UniqueName="sTimeD" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" FilterControlAltText="Filter iSession column"
                                    HeaderText="梯次" SortExpression="iSession" UniqueName="iSession">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="category_sname" FilterControlAltText="Filter category_sname column"
                                    HeaderText="階層" SortExpression="category_sname" UniqueName="category_sname">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="course_sname" FilterControlAltText="Filter course_sname column"
                                    HeaderText="課程名稱" SortExpression="course_sname" UniqueName="course_sname">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                                    HeaderText="課程代碼" SortExpression="trCourse_sCode" UniqueName="trCourse_sCode">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sKey" FilterControlAltText="Filter sKey column"
                                    HeaderText="sKey" SortExpression="sKey" UniqueName="sKey" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dDateA" DataFormatString="{0:d}" DataType="System.DateTime"
                                    FilterControlAltText="Filter dDateA column" HeaderText="開課日" SortExpression="dDateA"
                                    UniqueName="dDateA">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dDateD" DataFormatString="{0:d}" DataType="System.DateTime"
                                    FilterControlAltText="Filter dDateD column" HeaderText="結束日" SortExpression="dDateD"
                                    UniqueName="dDateD" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iEstimateAMT" FilterControlAltText="Filter iEstimateAMT column"
                                    HeaderText="預估費用" UniqueName="iEstimateAMT">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="trTeacher_sCode" FilterControlAltText="Filter trTeacher_sCode column"
                                    HeaderText="trTeacher_sCode" SortExpression="trTeacher_sCode" UniqueName="trTeacher_sCode"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="trClassroom_sCode" FilterControlAltText="Filter trClassroom_sCode column"
                                    HeaderText="trClassroom_sCode" SortExpression="trClassroom_sCode" UniqueName="trClassroom_sCode"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridCheckBoxColumn DataField="bWebJoin" DataType="System.Boolean" FilterControlAltText="Filter bWebJoin column"
                                    HeaderText="網路報名" SortExpression="bWebJoin" UniqueName="bWebJoin" Visible="False">
                                </telerik:GridCheckBoxColumn>
                                <telerik:GridBoundColumn DataField="dWebJoinDateB" DataType="System.DateTime" FilterControlAltText="Filter dWebJoinDateB column"
                                    HeaderText="dWebJoinDateB" SortExpression="dWebJoinDateB" UniqueName="dWebJoinDateB"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dWebJoinDateE" DataType="System.DateTime" FilterControlAltText="Filter dWebJoinDateE column"
                                    HeaderText="dWebJoinDateE" SortExpression="dWebJoinDateE" UniqueName="dWebJoinDateE"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                    HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                    HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iUpLimitP" DataType="System.Int32" FilterControlAltText="Filter iUpLimitP column"
                                    HeaderText="iUpLimitP" SortExpression="iUpLimitP" UniqueName="iUpLimitP" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iLowLimitP" DataType="System.Int32" FilterControlAltText="Filter iLowLimitP column"
                                    HeaderText="iLowLimitP" SortExpression="iLowLimitP" UniqueName="iLowLimitP" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridCheckBoxColumn DataField="bIsPublished" DataType="System.Boolean" FilterControlAltText="Filter bIsPublished column"
                                    HeaderText="發佈" SortExpression="bIsPublished" UniqueName="bIsPublished" Visible="False">
                                </telerik:GridCheckBoxColumn>
                                <telerik:GridBoundColumn DataField="iYearPlanAutoKey" DataType="System.Int32" FilterControlAltText="Filter iYearPlanAutoKey column"
                                    HeaderText="計畫編號" SortExpression="iYearPlanAutoKey" UniqueName="iYearPlanAutoKey"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dDateTimeA" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeA column"
                                    HeaderText="dDateTimeA" SortExpression="dDateTimeA" UniqueName="dDateTimeA" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dDateTimeD" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeD column"
                                    HeaderText="dDateTimeD" SortExpression="dDateTimeD" UniqueName="dDateTimeD" Visible="False">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Vista">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    <br />
                    <br />
                    <asp:SqlDataSource ID="sdsClassGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                        SelectCommand="SELECT class.*,c.sName as course_sname,cat.sName as category_sname  FROM [trTrainingDetailM] class join trCourse c on class.trCourse_sCode = c.sCode  join trCategory cat on class.sKey = cat.sCode  where class.iAutoKey = @ID">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <h2>
                        上課日期</h2>
                    <br />
                    <telerik:RadGrid ID="gvAttendClass" runat="server" CellSpacing="0" Culture="zh-TW"
                        DataSourceID="sdsAttendClass" GridLines="None" Skin="Outlook" AutoGenerateColumns="False"
                        OnItemDataBound="gvAttendClass_ItemDataBound">
                        <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsAttendClass">
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
                                <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                    HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                    HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dClassDate" DataFormatString="{0:d}" DataType="System.DateTime"
                                    FilterControlAltText="Filter dClassDate column" HeaderText="上課日" SortExpression="dClassDate"
                                    UniqueName="dClassDate">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dClassDateA" DataFormatString="{0:t}" DataType="System.DateTime"
                                    FilterControlAltText="Filter dClassDateA column" HeaderText="時間起" SortExpression="dClassDateA"
                                    UniqueName="dClassDateA">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dClassDateD" DataFormatString="{0:t}" DataType="System.DateTime"
                                    FilterControlAltText="Filter dClassDateD column" HeaderText="時間迄" SortExpression="dClassDateD"
                                    UniqueName="dClassDateD">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="iAttendMins" DataType="System.Double" FilterControlAltText="Filter iAttendMins column"
                                    HeaderText="上課時數" SortExpression="iAttendMins" UniqueName="iAttendMins">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                    HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                    HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="roomName" FilterControlAltText="Filter roomName column"
                                    HeaderText="地點" SortExpression="roomName" UniqueName="roomName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TeacherName" FilterControlAltText="Filter TeacherName column"
                                    HeaderText="講師" SortExpression="TeacherName" UniqueName="TeacherName">
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
                    <asp:SqlDataSource ID="sdsAttendClass" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                        SelectCommand="select clsD.*,room.sName as roomName,t.sName as TeacherName from trAttendClassDate clsD 
left join trAttendClassPlace clsP on clsd.iClassAutoKey = clsP.iClassAutoKey and clsD.dClassDate = clsP.dClassDate 
left join trClassroom room on clsp.sPlaceCode = room.sCode
left join trAttendClassTeacher clsT on clsD.iClassAutoKey = clst.iClassAutoKey and clsD.dClassDate = clsT.dClassDate
left join trTeacher t on clsT.sTeacherCode = t.sCode 
 where clsD.iClassAutoKey = @ID
order by clsD.dClassDate">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <br />
                    <h2>
                        學員心得填寫期限日：<asp:Label ID="lblClassRptDeadLine" runat="server"></asp:Label>
                        <br />
                        學員表現評分期限日：<asp:Label ID="lblStudentScoreDeadLine" runat="server"></asp:Label>
                        </h2>
                    <p>
                        &nbsp;</p>
                </telerik:RadPageView>
                <telerik:RadPageView ID="pvNotify" runat="server">
                    <h2>
                        課程前中後查檢<telerik:RadGrid ID="gvClassNotify" runat="server" AutoGenerateColumns="False"
                            CellSpacing="0" Culture="zh-TW" DataSourceID="sdsClassNotifyGV" GridLines="None"
                            Skin="Outlook">
                            <MasterTableView AllowAutomaticDeletes="True" DataKeyNames="iAutoKey" DataSourceID="sdsClassNotifyGV">
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
                                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                        HeaderText="名稱" SortExpression="sName" UniqueName="sName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iTimespan" FilterControlAltText="Filter iTimespan column"
                                        HeaderText="間距" UniqueName="iTimespan">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="dNotifyDate" DataFormatString="{0:d}" FilterControlAltText="Filter dNotifyDate column"
                                        HeaderText="通知日期" UniqueName="dNotifyDate">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iNotifyItemAutoKey" DataType="System.Int32" FilterControlAltText="Filter iNotifyItemAutoKey column"
                                        HeaderText="iNotifyItemAutoKey" SortExpression="iNotifyItemAutoKey" UniqueName="iNotifyItemAutoKey"
                                        Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                        HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                        Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                        HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
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
                        <asp:SqlDataSource ID="sdsClassNotifyGV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            DeleteCommand="DELETE FROM [trClassNotify] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [trClassNotify] ([iClassAutoKey], [iNotifyItemAutoKey], [iTimespan], [sKeyMan], [dKeyDate]) VALUES (@iClassAutoKey, @iNotifyItemAutoKey, @iTimespan, @sKeyMan, @dKeyDate)"
                            SelectCommand="SELECT cn.*,item.sName FROM [trClassNotify] cn join trNotifyItem item on cn.iNotifyItemAutoKey = item.iAutoKey WHERE ([iClassAutoKey] = @ID) 
order by cn.iTimespan" UpdateCommand="UPDATE [trClassNotify] SET [iClassAutoKey] = @iClassAutoKey, [iNotifyItemAutoKey] = @iNotifyItemAutoKey, [iTimespan] = @iTimespan, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                            <DeleteParameters>
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                                <asp:Parameter Name="iNotifyItemAutoKey" Type="Int32" />
                                <asp:Parameter Name="iTimespan" Type="Int32" />
                                <asp:Parameter Name="sKeyMan" Type="String" />
                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                                <asp:Parameter Name="iNotifyItemAutoKey" Type="Int32" />
                                <asp:Parameter Name="iTimespan" Type="Int32" />
                                <asp:Parameter Name="sKeyMan" Type="String" />
                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </h2>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    </form>
</body>
</html>
