<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="LicenseUpLoad.aspx.cs" Inherits="eTraining_Teacher_LicenseUpLoad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <div>
        <h2>證照上傳</h2><asp:SqlDataSource ID="sdsTeacher" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            SelectCommand="select * from trTeacher"></asp:SqlDataSource>
        <telerik:RadGrid ID="gvTeacher" runat="server" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsTeacher"
            GridLines="None" Visible="False">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsTeacher">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                        Text="選擇" UniqueName="Select">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                        HeaderText="sCode" SortExpression="sCode" UniqueName="sCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                        HeaderText="名稱" SortExpression="sName" UniqueName="sName">
                    </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn DataField="bEntTeacherType" DataType="System.Boolean"
                        FilterControlAltText="Filter bEntTeacherType column" HeaderText="內部講師" SortExpression="bEntTeacherType"
                        UniqueName="bEntTeacherType">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridBoundColumn DataField="sTeacherID" FilterControlAltText="Filter sTeacherID column"
                        HeaderText="sTeacherID" SortExpression="sTeacherID" UniqueName="sTeacherID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sSex" FilterControlAltText="Filter sSex column"
                        HeaderText="sSex" SortExpression="sSex" UniqueName="sSex" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sEmail" FilterControlAltText="Filter sEmail column"
                        HeaderText="sEmail" SortExpression="sEmail" UniqueName="sEmail" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sTel" FilterControlAltText="Filter sTel column"
                        HeaderText="sTel" SortExpression="sTel" UniqueName="sTel" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sFax" FilterControlAltText="Filter sFax column"
                        HeaderText="sFax" SortExpression="sFax" UniqueName="sFax" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sCallPhone" FilterControlAltText="Filter sCallPhone column"
                        HeaderText="sCallPhone" SortExpression="sCallPhone" UniqueName="sCallPhone" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sAddr" FilterControlAltText="Filter sAddr column"
                        HeaderText="sAddr" SortExpression="sAddr" UniqueName="sAddr" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sNote1" FilterControlAltText="Filter sNote1 column"
                        HeaderText="sNote1" SortExpression="sNote1" UniqueName="sNote1" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sNote2" FilterControlAltText="Filter sNote2 column"
                        HeaderText="sNote2" SortExpression="sNote2" UniqueName="sNote2" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sNote3" FilterControlAltText="Filter sNote3 column"
                        HeaderText="sNote3" SortExpression="sNote3" UniqueName="sNote3" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sNote4" FilterControlAltText="Filter sNote4 column"
                        HeaderText="sNote4" SortExpression="sNote4" UniqueName="sNote4" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sNote5" FilterControlAltText="Filter sNote5 column"
                        HeaderText="sNote5" SortExpression="sNote5" UniqueName="sNote5" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                        HeaderText="sNobr" SortExpression="sNobr" UniqueName="sNobr">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                        HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                        HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sCompanyID" FilterControlAltText="Filter sCompanyID column"
                        HeaderText="sCompanyID" SortExpression="sCompanyID" UniqueName="sCompanyID" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sWorkExp" FilterControlAltText="Filter sWorkExp column"
                        HeaderText="sWorkExp" SortExpression="sWorkExp" UniqueName="sWorkExp" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iWorkYear" DataType="System.Decimal" FilterControlAltText="Filter iWorkYear column"
                        HeaderText="iWorkYear" SortExpression="iWorkYear" UniqueName="iWorkYear">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sTeachExp" FilterControlAltText="Filter sTeachExp column"
                        HeaderText="sTeachExp" SortExpression="sTeachExp" UniqueName="sTeachExp">
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
        <br />
        <br />
        <div style="background-color: #CDE5FF;width:400px" class="funcblock">
        <br />
            <table style="width: 100%;">
                <tr>
                    <td width="200px">
                        檔案名稱：<telerik:RadTextBox ID="tbNote" runat="server">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <telerik:RadAsyncUpload ID="ul" runat="server" 
                            MultipleFileSelection="Automatic" Skin="Windows7">
                            <Localization Remove="移除" Select="選擇" />
                        </telerik:RadAsyncUpload>
                    </td>

                </tr>
            </table>
            <br />
        </div>
        <br />
        <telerik:RadGrid ID="gvLicenseFile" runat="server" AutoGenerateColumns="False" CellSpacing="0"
            Culture="zh-TW" DataSourceID="sdsLicenseFile" GridLines="None" Skin="Outlook"
            Width="85%" OnItemDataBound="gv_ItemDataBound" OnDeleteCommand="gv_DeleteCommand">
            <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsLicenseFile">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="FileOriginName" FilterControlAltText="Filter FileOriginName column"
                        HeaderText="檔案名稱" SortExpression="FileOriginName" UniqueName="FileOriginName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FileNote" FilterControlAltText="Filter FileNote column"
                        HeaderText="備註" SortExpression="FileNote" UniqueName="FileNote">
                    </telerik:GridBoundColumn>
                    <telerik:GridHyperLinkColumn FilterControlAltText="Filter Download column" Text="下載"
                        UniqueName="Download" DataNavigateUrlFields="FileStoredName" DataNavigateUrlFormatString="~/eTraining/Admin/download.ashx?ID={0}">
                    </telerik:GridHyperLinkColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmText="是否刪除?"
                        FilterControlAltText="Filter Delete column" UniqueName="Delete">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="FileCategoryKey" FilterControlAltText="Filter FileCategoryKey column"
                        UniqueName="FileCategoryKey" Visible="False">
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
        <telerik:RadButton ID="btnUpload" runat="server" Text="上傳檔案" OnClick="btnUpload_Click"
            Skin="Office2007">
        </telerik:RadButton>
        &nbsp;
        <telerik:RadButton ID="btnBack" runat="server" Text="返回" Skin="Office2007" 
            onclick="btnBack_Click">
        </telerik:RadButton>
        <asp:SqlDataSource ID="sdsLicenseFile" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            SelectCommand="SELECT * FROM [UPLOAD] WHERE ([FileCategoryKey] = @FileCategoryKey) AND FileCategory = 'TeacherLicense' and FileDeleted=0">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="FileCategoryKey" QueryStringField="ID"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
