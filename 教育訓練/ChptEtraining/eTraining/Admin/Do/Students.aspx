<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Students.aspx.cs" Inherits="eTraining_Admin_Do_Students" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript">
        //<![CDATA[

            //Standard Window.confirm
            function StandardConfirm(sender, args) {
                args.set_cancel(!window.confirm("確認是否增加學員?"));
            }

            //RadConfirm
            function RadConfirm(sender, args) {
                var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
                    if (shouldSubmit) {
                        this.click();
                    }
                });

                var text = "Are you sure you want to submit the page?";
                radconfirm(text, callBackFunction, 300, 100, null, "RadConfirm");
                args.set_cancel(true);
            }
        //]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            訓練名單<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </h2>
    </div>
    <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
    <br />
    <telerik:RadButton ID="btnAddStu" runat="server" Skin="Office2007" Text="加入學員"
        OnClick="btnAddStu_Click">
    </telerik:RadButton>
    &nbsp;
    <telerik:RadButton ID="btnClose" runat="server" OnClick="btnClose_Click" Skin="Office2007"
        Text="關閉加入學員" Visible="False">
    </telerik:RadButton>
    <br />
    <asp:Panel ID="pnlNobr" runat="server" Visible="False">
        <br />
        <div style="width: 450px; border: 1px solid #CCCCCC">
            <br />
            姓名|工號|部門<telerik:RadTextBox ID="txtName" runat="server">
            </telerik:RadTextBox>
            &nbsp;&nbsp;
            <telerik:RadButton ID="btnSearchNobr" runat="server" Text="查詢">
            </telerik:RadButton>
            <br />
            <br />
            <telerik:RadGrid ID="gvNobr" runat="server" AllowPaging="True" CellSpacing="0" Culture="zh-TW"
                DataSourceID="sdsNobr" GridLines="None" Skin="Outlook" AllowMultiRowSelection="True">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView AutoGenerateColumns="False" DataSourceID="sdsNobr" 
                    DataKeyNames="NOBR">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
                            UniqueName="column">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter NAME_C column" 
                            UniqueName="NAME_C" DataField="NAME_C" HeaderText="姓名" 
                            SortExpression="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                            HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                            HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                            HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME">
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
            <asp:SqlDataSource ID="sdsNobr" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select b.NAME_C,tts.NOBR,d.D_NAME,j.JOB_NAME from BASE b
join BASETTS tts on b.NOBR=tts.NOBR
join DEPT d on tts.DEPT=d.D_NO
join JOB j on tts.JOB=j.JOB
where (b.NAME_C like @txtName + '%' or b.NOBR like @txtName + '%' or  d.D_NAME like @txtName + '%')
and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and tts.TTSCODE in('1','4','6')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtName" DefaultValue="0" Name="txtName" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <telerik:RadButton ID="btnAdd" runat="server" Text="加入" onclick="btnAdd_Click" 
                onclientclicking="StandardConfirm">
            </telerik:RadButton>
            <br />
        </div>
    </asp:Panel>
    <br />
    &nbsp;
        <div>
    <asp:Panel ID="pnNote" runat="server" Visible="False">
        <asp:Label ID="lblStudentKey" runat="server" Visible="False"></asp:Label>
        <br />
        選擇矯正類別<telerik:RadComboBox ID="cbxStuError" runat="server" CheckBoxes="True" 
            DataSourceID="sdsCbx" DataTextField="sName" DataValueField="sCode" 
            ondatabound="cbxStuError_DataBound" Width="120px">
        </telerik:RadComboBox>
        <asp:SqlDataSource ID="sdsCbx" runat="server" 
            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
            SelectCommand="SELECT * FROM [trStudentError]"></asp:SqlDataSource>
        <br />
        TR註記：<telerik:RadTextBox ID="tbNote3" runat="server" Rows="5" TextMode="MultiLine"
            Width="140px">
        </telerik:RadTextBox>
        <br />
        <br />
        <telerik:RadButton ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="更新">
        </telerik:RadButton>
        <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消">
        </telerik:RadButton>
        <br />
    </asp:Panel>
    </div>
    <div style="float: left;width:95%">
    <telerik:RadGrid ID="gv" runat="server" AllowFilteringByColumn="True" AllowPaging="True"
        AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW"
        DataSourceID="sdsGv" GridLines="None" Skin="Outlook" OnSelectedIndexChanged="gv_SelectedIndexChanged"
        GroupingEnabled="False" Width="100%" OnExportCellFormatting="gv_ExportCellFormatting"
        OnItemCreated="gv_ItemCreated" onitemcommand="gv_ItemCommand" 
            onitemdatabound="gv_ItemDataBound">
<ClientSettings>
<Selecting CellSelectionMode="None"></Selecting>
</ClientSettings>

        <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsGv">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn AllowFiltering="False" 
                    FilterControlAltText="Filter Item column" ReadOnly="True" 
                    ShowFilterIcon="False" ShowSortIcon="False" UniqueName="Item" >                    
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" FilterControlAltText="Filter bPass column"
                    HeaderText="結訓" SortExpression="bPass" UniqueName="bPass">
                    <HeaderStyle Width="70px" Wrap="False" />
                    <ItemStyle Width="70px" />
                </telerik:GridCheckBoxColumn>
                <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                    HeaderText="工號" SortExpression="sNobr" UniqueName="sNobr" FilterControlWidth="80px"
                    AllowFiltering="False">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                    HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C" 
                    FilterControlWidth="50px">
                    <HeaderStyle Width="80px" />
                    <ItemStyle Width="80px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="trJoinType_sName" FilterControlAltText="Filter trJoinType_sName column"
                    HeaderText="加入方式" SortExpression="trJoinType_sName" UniqueName="trJoinType_sName"
                    AllowFiltering="False" ShowSortIcon="False">
                    <FooterStyle Width="80px" />
                    <HeaderStyle Width="85px" Wrap="False" />
                    <ItemStyle Width="85px" Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                    HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME" 
                    FilterControlWidth="70px">
                    <FooterStyle Width="90px" />
                    <HeaderStyle Width="90px" Wrap="False" />
                    <ItemStyle Width="90px" Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                    HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME" AllowFiltering="False">
<HeaderStyle Width="80px" Wrap="False"></HeaderStyle>

<ItemStyle Width="80px" Wrap="False"></ItemStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn AllowFiltering="False" DataField="dNote2KeyDate" DataFormatString="{0:d}"
                    EmptyDataText="" FilterControlAltText="Filter dNote2KeyDate column" HeaderText="心得填寫日"
                    UniqueName="dNote2KeyDate">
                    <HeaderStyle Width="80px" Wrap="False" />
                    <ItemStyle Width="80px" />
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="bAbsence" DataType="System.Boolean" FilterControlAltText="Filter bAbsence column"
                    HeaderText="bAbsence" SortExpression="bAbsence" UniqueName="bAbsence" Visible="False">
                </telerik:GridCheckBoxColumn>
                <telerik:GridBoundColumn DataField="sAbsenceNote" FilterControlAltText="Filter sAbsenceNote column"
                    HeaderText="sAbsenceNote" SortExpression="sAbsenceNote" UniqueName="sAbsenceNote"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="iScore" DataType="System.Decimal" FilterControlAltText="Filter iScore column"
                    HeaderText="iScore" SortExpression="iScore" UniqueName="iScore" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sPassNote" FilterControlAltText="Filter sPassNote column"
                    HeaderText="sPassNote" SortExpression="sPassNote" UniqueName="sPassNote" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sJoblCode" FilterControlAltText="Filter sJoblCode column"
                    HeaderText="sJoblCode" SortExpression="sJoblCode" UniqueName="sJoblCode" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sJobsCode" FilterControlAltText="Filter sJobsCode column"
                    HeaderText="sJobsCode" SortExpression="sJobsCode" UniqueName="sJobsCode" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sJobCode" FilterControlAltText="Filter sJobCode column"
                    HeaderText="sJobCode" SortExpression="sJobCode" UniqueName="sJobCode" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sDeptCode" FilterControlAltText="Filter sDeptCode column"
                    HeaderText="sDeptCode" SortExpression="sDeptCode" UniqueName="sDeptCode" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                    HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sNote1" FilterControlAltText="Filter sNote1 column"
                    HeaderText="sNote1" SortExpression="sNote1" UniqueName="sNote1" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sNote2" FilterControlAltText="Filter sNote2 column"
                    HeaderText="sNote2" SortExpression="sNote2" UniqueName="sNote2" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sNote3" FilterControlAltText="Filter sNote3 column"
                    HeaderText="TR註記" SortExpression="HR註記" UniqueName="sNote3" AllowFiltering="False">
                    <HeaderStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sNote4" FilterControlAltText="Filter sNote4 column"
                    HeaderText="sNote4" SortExpression="sNote4" UniqueName="sNote4" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sNote5" FilterControlAltText="Filter sNote5 column"
                    HeaderText="sNote5" SortExpression="sNote5" UniqueName="sNote5" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="trJoinType_sCode" FilterControlAltText="Filter trJoinType_sCode column"
                    HeaderText="trJoinType_sCode" SortExpression="trJoinType_sCode" UniqueName="trJoinType_sCode"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                    HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                    HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                    HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMAIL" 
                    FilterControlAltText="Filter EMAIL column" HeaderText="EMAIL" 
                    UniqueName="EMAIL">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                    Text="紀錄" UniqueName="Select">
                    <ItemStyle Width="80px" Wrap="False" />
                </telerik:GridButtonColumn>
                <telerik:GridButtonColumn ConfirmText="刪除學員後，資料無法回復，確認刪除?" ConfirmTitle="確認刪除?" 
                    FilterControlAltText="Filter Delete column" HeaderText="刪" 
                    UniqueName="Delete" Text="刪" CommandName="Delete">
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
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
    </div>

    <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        DeleteCommand="DELETE FROM [trTrainingStudentM] WHERE [iAutoKey] = @iAutoKey"
        InsertCommand="INSERT INTO [trTrainingStudentM] ([iClassAutoKey], [sJobCode], [sJobsCode], [sJoblCode], [sDeptCode], [sNobr], [trJoinType_sCode], [bAbsence], [sAbsenceNote], [sNote1], [iScore], [bPass], [sPassNote], [sNote2], [sNote3], [sNote4], [sNote5], [sKeyMan], [dKeyDate]) VALUES (@iClassAutoKey, @sJobCode, @sJobsCode, @sJoblCode, @sDeptCode, @sNobr, @trJoinType_sCode, @bAbsence, @sAbsenceNote, @sNote1, @iScore, @bPass, @sPassNote, @sNote2, @sNote3, @sNote4, @sNote5, @sKeyMan, @dKeyDate)"
        SelectCommand="select jt.trJoinType_sName,(DEPT.D_NO+' '+dept.D_NAME)as D_NAME,job.JOB_NAME,b.NAME_C,sm.* ,b.EMAIL from trTrainingStudentM sm 
left join BASE b on sm.sNobr = b.NOBR
left join BASETTS tts on sm.sNobr = tts.NOBR
left join JOB on JOB.JOB = sm.sJobCode
left join DEPT on DEPT.D_NO = sm.sDeptCode
left join trJoinType jt on sm.trJoinType_sCode = jt.trJoinType_sCode
where CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and sm.iClassAutoKey = @ID
" 
        
        UpdateCommand="UPDATE [trTrainingStudentM] SET [iClassAutoKey] = @iClassAutoKey, [sJobCode] = @sJobCode, [sJobsCode] = @sJobsCode, [sJoblCode] = @sJoblCode, [sDeptCode] = @sDeptCode, [sNobr] = @sNobr, [trJoinType_sCode] = @trJoinType_sCode, [bAbsence] = @bAbsence, [sAbsenceNote] = @sAbsenceNote, [sNote1] = @sNote1, [iScore] = @iScore, [bPass] = @bPass, [sPassNote] = @sPassNote, [sNote2] = @sNote2, [sNote3] = @sNote3, [sNote4] = @sNote4, [sNote5] = @sNote5, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="iClassAutoKey" Type="Int32" />
            <asp:Parameter Name="sJobCode" Type="String" />
            <asp:Parameter Name="sJobsCode" Type="String" />
            <asp:Parameter Name="sJoblCode" Type="String" />
            <asp:Parameter Name="sDeptCode" Type="String" />
            <asp:Parameter Name="sNobr" Type="String" />
            <asp:Parameter Name="trJoinType_sCode" Type="String" />
            <asp:Parameter Name="bAbsence" Type="Boolean" />
            <asp:Parameter Name="sAbsenceNote" Type="String" />
            <asp:Parameter Name="sNote1" Type="String" />
            <asp:Parameter Name="iScore" Type="Decimal" />
            <asp:Parameter Name="bPass" Type="Boolean" />
            <asp:Parameter Name="sPassNote" Type="String" />
            <asp:Parameter Name="sNote2" Type="String" />
            <asp:Parameter Name="sNote3" Type="String" />
            <asp:Parameter Name="sNote4" Type="String" />
            <asp:Parameter Name="sNote5" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="iClassAutoKey" Type="Int32" />
            <asp:Parameter Name="sJobCode" Type="String" />
            <asp:Parameter Name="sJobsCode" Type="String" />
            <asp:Parameter Name="sJoblCode" Type="String" />
            <asp:Parameter Name="sDeptCode" Type="String" />
            <asp:Parameter Name="sNobr" Type="String" />
            <asp:Parameter Name="trJoinType_sCode" Type="String" />
            <asp:Parameter Name="bAbsence" Type="Boolean" />
            <asp:Parameter Name="sAbsenceNote" Type="String" />
            <asp:Parameter Name="sNote1" Type="String" />
            <asp:Parameter Name="iScore" Type="Decimal" />
            <asp:Parameter Name="bPass" Type="Boolean" />
            <asp:Parameter Name="sPassNote" Type="String" />
            <asp:Parameter Name="sNote2" Type="String" />
            <asp:Parameter Name="sNote3" Type="String" />
            <asp:Parameter Name="sNote4" Type="String" />
            <asp:Parameter Name="sNote5" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsFv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        DeleteCommand="DELETE FROM [trTrainingStudentM] WHERE [iAutoKey] = @iAutoKey"
        InsertCommand="INSERT INTO [trTrainingStudentM] ([iClassAutoKey], [sJobCode], [sJobsCode], [sJoblCode], [sDeptCode], [sNobr], [trJoinType_sCode], [bAbsence], [sAbsenceNote], [sNote1], [iScore], [bPass], [sPassNote], [sNote2], [sNote3], [sNote4], [sNote5], [sKeyMan], [dKeyDate]) VALUES (@iClassAutoKey, @sJobCode, @sJobsCode, @sJoblCode, @sDeptCode, @sNobr, @trJoinType_sCode, @bAbsence, @sAbsenceNote, @sNote1, @iScore, @bPass, @sPassNote, @sNote2, @sNote3, @sNote4, @sNote5, @sKeyMan, @dKeyDate)"
        SelectCommand="SELECT * FROM [trTrainingStudentM] WHERE ([iAutoKey] = @iAutoKey)"
        UpdateCommand="UPDATE [trTrainingStudentM] SET [sNote3] = @sNote3 WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="iClassAutoKey" Type="Int32" />
            <asp:Parameter Name="sJobCode" Type="String" />
            <asp:Parameter Name="sJobsCode" Type="String" />
            <asp:Parameter Name="sJoblCode" Type="String" />
            <asp:Parameter Name="sDeptCode" Type="String" />
            <asp:Parameter Name="sNobr" Type="String" />
            <asp:Parameter Name="trJoinType_sCode" Type="String" />
            <asp:Parameter Name="bAbsence" Type="Boolean" />
            <asp:Parameter Name="sAbsenceNote" Type="String" />
            <asp:Parameter Name="sNote1" Type="String" />
            <asp:Parameter Name="iScore" Type="Decimal" />
            <asp:Parameter Name="bPass" Type="Boolean" />
            <asp:Parameter Name="sPassNote" Type="String" />
            <asp:Parameter Name="sNote2" Type="String" />
            <asp:Parameter Name="sNote3" Type="String" />
            <asp:Parameter Name="sNote4" Type="String" />
            <asp:Parameter Name="sNote5" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="gv" DefaultValue="-1" Name="iAutoKey" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="sNote3" Type="String" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    </form>
</body>
</html>
