<%@ Page Title="指定教案" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SetTeachingMaterial.aspx.cs" Inherits="eTraining_Teacher_SetTeachingMaterial" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowInsertForm() {
                window.radopen("trTeachingMaterialEdit.aspx", "UserListDialog");
                return false;
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("trTeachingMaterialEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
    <h2>
        指定教案<asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
    </h2>
    <telerik:RadGrid ID="gvCourselist" runat="server" CellSpacing="0" GridLines="None"
        Skin="Windows7" Width="80%" Culture="zh-TW" DataSourceID="sdsTeacherClass" 
        onitemdatabound="gvCourselist_ItemDataBound" 
        onselectedindexchanged="gvCourselist_SelectedIndexChanged" 
        onneeddatasource="gvCourselist_NeedDataSource">
        <MasterTableView autogeneratecolumns="False" datakeynames="iAutoKey" 
            datasourceid="sdsTeacherClass">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridButtonColumn CommandName="Select" 
                    FilterControlAltText="Filter Select column" Text="選擇" UniqueName="Select">
                </telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="iMaterialAutoKey" DataType="System.Int32" 
                    EmptyDataText="" FilterControlAltText="Filter iMaterialAutoKey column" 
                    HeaderText="教案" SortExpression="iMaterialAutoKey" UniqueName="iMaterialAutoKey">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
                    FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
                    ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="categoryName" 
                    FilterControlAltText="Filter categoryName column" HeaderText="階層別" 
                    SortExpression="categoryName" UniqueName="categoryName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="courseName" 
                    FilterControlAltText="Filter courseName column" HeaderText="課程名稱" 
                    SortExpression="courseName" UniqueName="courseName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dDateA" DataFormatString="{0:d}" 
                    DataType="System.DateTime" FilterControlAltText="Filter dDateA column" 
                    HeaderText="上課日期" SortExpression="dDateA" UniqueName="dDateA">
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
    <asp:Panel ID="pnlSelect" runat="server" Visible="False">
        <telerik:RadGrid ID="gv" runat="server" AllowFilteringByColumn="True" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGV" GridLines="None" 
            ondeletecommand="gv_DeleteCommand" onitemcommand="gv_ItemCommand" 
            onitemdatabound="gv_ItemDataBound" ShowFooter="True" 
            Skin="Windows7">
            <MasterTableView allowmulticolumnsorting="True" DataKeyNames="iAutoKey" 
                DataSourceID="sdsGV" showfooter="False">
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridButtonColumn CommandName="Select" 
                        FilterControlAltText="Filter Select column" Text="選擇" UniqueName="Select">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
                        ConfirmDialogType="RadWindow" ConfirmText="是否刪除?" 
                        FilterControlAltText="Filter Delete column" UniqueName="Delete" Visible="False">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="sName" 
                        FilterControlAltText="Filter trCourse_sName column" HeaderText="課程名稱" 
                        UniqueName="trCourse_sName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sVersion" 
                        FilterControlAltText="Filter sVersion column" HeaderText="版本" 
                        SortExpression="sVersion" UniqueName="sVersion">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sCoursePolicy" 
                        FilterControlAltText="Filter sCoursePolicy column" HeaderText="課程目標" 
                        SortExpression="sCoursePolicy" UniqueName="sCoursePolicy">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sCourseExpect" 
                        FilterControlAltText="Filter sCourseExpect column" HeaderText="具體目標" 
                        SortExpression="sCourseExpect" UniqueName="sCourseExpect" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                        UniqueName="TemplateColumn" Visible="False">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnEdit" runat="server" Text="編輯">
                            </telerik:RadButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter detail column" 
                        UniqueName="detail" Visible="False">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnDetail" runat="server" Text="詳細內容">
                            </telerik:RadButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn CommandName="View" 
                        FilterControlAltText="Filter View  column" Text="檢視教案" UniqueName="View">
                    </telerik:GridButtonColumn>
                    <telerik:GridCheckBoxColumn DataField="bSaved" DataType="System.Boolean" 
                        FilterControlAltText="Filter bSaved column" HeaderText="已存檔" 
                        UniqueName="bSaved">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter attachment column" 
                        HeaderText="附件" UniqueName="attachment">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="Upload">上傳</asp:LinkButton>
                            <br />
                            <asp:HyperLink ID="hl" runat="server" Text="下載"></asp:HyperLink>
                            <br />
                            <asp:LinkButton ID="lbtnDelAtt" runat="server" CommandName="DeleteAtt">刪除</asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="FileKey" EmptyDataText="" 
                        FilterControlAltText="Filter FileKey column" UniqueName="FileKey" 
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="trCourse_sCode" 
                        FilterControlAltText="Filter trCourse_sCode column" HeaderText="課程代碼" 
                        SortExpression="trCourse_sCode" UniqueName="trCourse_sCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="name_c" 
                        FilterControlAltText="Filter name_c column" HeaderText="輸入者" 
                        SortExpression="name_c" UniqueName="name_c" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dKeyDate" DataFormatString="{0:d}" 
                        DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column" 
                        HeaderText="輸入日期" SortExpression="dKeyDate" UniqueName="dKeyDate" 
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FileStoredName" 
                        FilterControlAltText="Filter FileStoredName column" UniqueName="FileStoredName" 
                        Visible="False">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column" 
                        uniquename="EditCommandColumn1">
                    </EditColumn>
                </EditFormSettings>
                <HeaderStyle Wrap="False" />
            </MasterTableView>
            <HeaderStyle Wrap="False" />
            <CommandItemStyle Wrap="True" />
            <CommandItemStyle Wrap="True" />
            <CommandItemStyle Wrap="True" />
            <ItemStyle Wrap="True" />
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="sdsGV" runat="server" 
            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
            DeleteCommand="DELETE FROM [trTeachingMaterial] WHERE [iAutoKey] = @iAutoKey" 
            InsertCommand="INSERT INTO [trTeachingMaterial] ([iAutoKey], [trCourse_sCode], [sCode], [sCoursePolicy], [sCourseExpect], [sKeyMan], [dKeyDate]) VALUES (@iAutoKey, @trCourse_sCode, @sCode, @sCoursePolicy, @sCourseExpect, @sKeyMan, @dKeyDate)" SelectCommand="SELECT tm.*,base.name_c,c.sName,ul.FileOriginName,ul.iAutoKey as FileKey FROM [trTeachingMaterial] tm join base  on 
tm.sKeyMan = base.nobr  left join trCourse c on tm.trCourse_sCode = c.sCode
left join UPLOAD ul on tm.iAutoKey = ul.FileCategoryKey and ul.FileDeleted =0" 
            UpdateCommand="UPDATE [trTeachingMaterial] SET [trCourse_sCode] = @trCourse_sCode, [sCode] = @sCode, [sCoursePolicy] = @sCoursePolicy, [sCourseExpect] = @sCourseExpect, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
            <DeleteParameters>
                <asp:Parameter Name="iAutoKey" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="iAutoKey" Type="Int32" />
                <asp:Parameter Name="trCourse_sCode" Type="String" />
                <asp:Parameter Name="sCode" Type="String" />
                <asp:Parameter Name="sCoursePolicy" Type="String" />
                <asp:Parameter Name="sCourseExpect" Type="String" />
                <asp:Parameter Name="sKeyMan" Type="String" />
                <asp:Parameter Name="dKeyDate" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="trCourse_sCode" Type="String" />
                <asp:Parameter Name="sCode" Type="String" />
                <asp:Parameter Name="sCoursePolicy" Type="String" />
                <asp:Parameter Name="sCourseExpect" Type="String" />
                <asp:Parameter Name="sKeyMan" Type="String" />
                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                <asp:Parameter Name="iAutoKey" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <telerik:RadButton ID="btnSave" runat="server" Text="確定" OnClick="btnSave_Click">
        </telerik:RadButton>
        <telerik:RadButton ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click">
        </telerik:RadButton>
    </asp:Panel>

    <br />
    <div style="text-align: center">
    </div>
    <asp:SqlDataSource ID="sdsTeacherClass" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        onselecting="sdsTeacherClass_Selecting" SelectCommand="select m.iAutoKey,ca.sName as categoryName,co.sName as courseName,m.iMaterialAutoKey,m.dDateA from trTrainingDetailM m
join trCategory ca on m.sKey=ca.sCode
join trCourse co on m.trCourse_sCode=co.sCode
where GETDATE() &lt; m.dDateD
and m.sMaterialSelector = 'T'
and m.iAutoKey in (select at.iClassAutoKey from trAttendClassTeacher at 
join trTeacher t on at.sTeacherCode = t.sCode where t.sNobr = @teacher)
order by m.dDateA">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblNobr" DefaultValue=" " Name="teacher" 
                PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    </asp:Content>
