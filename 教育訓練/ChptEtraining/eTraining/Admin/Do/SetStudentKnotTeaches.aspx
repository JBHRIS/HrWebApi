<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetStudentKnotTeaches.aspx.cs"
    Inherits="eTraining_Admin_Do_SetStudentKnotTeaches" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowInsertForm() {
                window.radopen("helpStudentKnotTeach.aspx", "UserListDialog");
                return false;
            }
        </script>
    </telerik:RadCodeBlock>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: right">
            <telerik:RadButton ID="btnHelp" runat="server" Text="操作說明" 
                onclick="btnHelp_Click">
            </telerik:RadButton>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/eTraining/Admin/Do/helpStudentKnotTeach.aspx"
                Target="_blank" Visible="False">操作說明</asp:HyperLink>
        </div>
        <div class="field">
            <fieldset>
                <legend>結訓條件</legend>
                <asp:RadioButtonList ID="rblClassKnotTeaches" runat="server" AutoPostBack="True"
                    DataSourceID="sdsClassKnotTeachesRbl" DataTextField="KnotTeachesName" DataValueField="trKnotTeaches_sCode"
                    OnSelectedIndexChanged="rblClassKnotTeaches_SelectedIndexChanged" 
                    ondatabound="rblClassKnotTeaches_DataBound">
                </asp:RadioButtonList>
            </fieldset>
        </div>
        <br />
        <asp:SqlDataSource ID="sdsClassKnotTeachesRbl" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            SelectCommand="select distinct s.trKnotTeaches_sCode,k.KnotTeachesName from trTrainingStudentS s join trKnotTeaches k on s.trKnotTeaches_sCode = k.KnotTeachesCode where iClassAutoKey =@ID">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <telerik:RadGrid ID="gv" runat="server" Skin="Outlook" AllowMultiRowSelection="True"
                AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGv"
                GridLines="None" OnItemDataBound="gv_ItemDataBound" AllowFilteringByColumn="True"
                Width="85%">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsGv">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                            HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                            HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="KnotTeachesName" FilterControlAltText="Filter KnotTeachesName column"
                            HeaderText="必訓名稱" SortExpression="KnotTeachesName" UniqueName="KnotTeachesName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                            HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trKnotTeaches_sCode" FilterControlAltText="Filter trKnotTeaches_sCode column"
                            HeaderText="trKnotTeaches_sCode" SortExpression="trKnotTeaches_sCode" UniqueName="trKnotTeaches_sCode"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trTrainingStudentM_ID" DataType="System.Int32"
                            FilterControlAltText="Filter trTrainingStudentM_ID column" HeaderText="trTrainingStudentM_ID"
                            SortExpression="trTrainingStudentM_ID" UniqueName="trTrainingStudentM_ID" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                            HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" FilterControlAltText="Filter bPass column"
                            HeaderText="bPass" SortExpression="bPass" UniqueName="bPass" Visible="False">
                        </telerik:GridCheckBoxColumn>
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
            <telerik:RadButton ID="btnSave" runat="server" Text="存檔" OnClick="btnSave_Click">
            </telerik:RadButton>
            &nbsp;&nbsp;
            <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                DeleteCommand="DELETE FROM [trTrainingStudentS] WHERE [iAutoKey] = @iAutoKey"
                InsertCommand="INSERT INTO [trTrainingStudentS] ([trTrainingStudentM_ID], [iClassAutoKey], [trKnotTeaches_sCode], [bPass], [sKeyMan], [dKeyDate]) VALUES (@trTrainingStudentM_ID, @iClassAutoKey, @trKnotTeaches_sCode, @bPass, @sKeyMan, @dKeyDate)"
                SelectCommand="select s.*,base.NOBR,base.NAME_C,DEPT.D_NAME,kt.KnotTeachesName  from trTrainingStudentS s
join trTrainingStudentM m on s.trTrainingStudentM_ID = m.iAutoKey
join BASE on m.sNobr = base.NOBR
join BASETTS tts on m.sNobr = tts.NOBR 
join DEPT on tts.DEPT = DEPT.D_NO
join trKnotTeaches kt on s.trKnotTeaches_sCode = kt.KnotTeachesCode
where s.iClassAutoKey =@ClassID 
and trKnotTeaches_sCode = @KnotTeache
and tts.TTSCODE in ('1','4','6') and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and CONVERT(varchar(10), GETDATE(),111) between dept.ADATE and DEPT.DDATE" UpdateCommand="UPDATE [trTrainingStudentS] SET [trTrainingStudentM_ID] = @trTrainingStudentM_ID, [iClassAutoKey] = @iClassAutoKey, [trKnotTeaches_sCode] = @trKnotTeaches_sCode, [bPass] = @bPass, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                <DeleteParameters>
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="trTrainingStudentM_ID" Type="Int32" />
                    <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                    <asp:Parameter Name="trKnotTeaches_sCode" Type="String" />
                    <asp:Parameter Name="bPass" Type="Boolean" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                </InsertParameters>
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="ClassID" QueryStringField="ID" />
                    <asp:ControlParameter ControlID="rblClassKnotTeaches" DefaultValue="0" Name="KnotTeache"
                        PropertyName="SelectedValue" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="trTrainingStudentM_ID" Type="Int32" />
                    <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                    <asp:Parameter Name="trKnotTeaches_sCode" Type="String" />
                    <asp:Parameter Name="bPass" Type="Boolean" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <telerik:RadWindow ID="RadWindow1" runat="server" Height="100%" Modal="True" 
                Width="100%">
                <ContentTemplate>
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl="~/App_Themes/Formosa/Images/eTraining/helpDoStudentKnot.jpg" />
                </ContentTemplate>
            </telerik:RadWindow>
            <br />
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="True">
                <Windows>
                    <telerik:RadWindow ID="UserListDialog" runat="server" Height="550px" Left="10px"
                        Modal="true" ReloadOnShow="true" ShowContentDuringLoad="false" Title="Editing record"
                        Width="400px" InitialBehaviors="Maximize" />
                </Windows>
            </telerik:RadWindowManager>
        </asp:Panel>
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>
