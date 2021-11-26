<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trTeachingMaterialEdit.aspx.cs"
    MasterPageFile="~/mpEdit.master" Inherits="Admin_Desing_trTeachingMaterialEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
            GetRadWindow().close();
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

            return oWindow;
        }

        function CancelEdit() {
            GetRadWindow().close();
        }
    </script>
    <div style="float: left; width: 40%">
        <telerik:RadGrid ID="gvCourse" runat="server" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsCourse"
            GridLines="None" AutoGenerateColumns="False" AllowFilteringByColumn="True" AllowSorting="True"
            OnSelectedIndexChanged="gvCourse_SelectedIndexChanged">
            <MasterTableView DataSourceID="sdsCourse" AllowPaging="True" 
                datakeynames="sCode">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter column column"
                        Text="選擇" UniqueName="column">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="catName" FilterControlAltText="Filter catName column"
                        HeaderText="階層別" UniqueName="catName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="courseName" FilterControlAltText="Filter courseName column"
                        HeaderText="課程名稱" SortExpression="courseName" UniqueName="courseName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                        HeaderText="課程代碼" SortExpression="sCode" UniqueName="sCode" 
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
    </div>
    <div style="float: right; width: 57%">
        <table style="width: 85%;" class="tableBlue">
            <tr>
                <th>
                    課程名稱
                </th>
                <th width="70px">
                    版本區分
                </th>
                <th>
                    教學時間
                </th>
                <th>
                    存檔
                </th>
            </tr>
            <tr>
                <td>
                    <telerik:RadTextBox ID="tbCourseName" runat="server" 
                        Text='<%# Bind("trCourse_sCode") %>' Enabled="False" Width="100%" />
                    <asp:RequiredFieldValidator ID="rfvCourse" runat="server" 
                        ControlToValidate="tbCourseName" Display="Dynamic" ErrorMessage="需選擇課程" 
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <telerik:RadTextBox ID="tbVersion" runat="server" Text='<%# Bind("sCode") %>' 
                        Width="100%" />
                    <asp:RequiredFieldValidator ID="rfvVersion" runat="server" 
                        ControlToValidate="tbVersion" Display="Dynamic" ErrorMessage="需輸入版本" 
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <telerik:RadNumericTextBox ID="ntbTeachTimeMins" Runat="server" MinValue="0" 
                        Width="100%" DataType="System.Int32">
                        <numberformat decimaldigits="0" />
                    </telerik:RadNumericTextBox>
                </td>
                <td>

                    <asp:CheckBox ID="cb_bSaved" runat="server" Text="存檔" />

                </td>
            </tr>
            <tr>
                <th colspan="4">
                    課程內容
                </th>
            </tr>
            <tr>
                <td colspan="4">
                    <telerik:RadTextBox ID="tbScontent" runat="server" Width="99%">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">
                    課程目標
                </th>
            </tr>
            <tr>
                <td colspan="4">
                    <telerik:RadTextBox ID="tbPolicy" runat="server" Text='<%# Bind("sCoursePolicy") %>'
                        TextMode="MultiLine" Width="99%" Rows="5" />
                </td>
            </tr>
            <tr>
                <th class="style1" colspan="4">
                    具體目標
                </th>
            </tr>
            <tr>
                <td colspan="4">
                    <telerik:RadTextBox ID="tbExpect" runat="server" Text='<%# Bind("sCourseExpect") %>'
                        TextMode="MultiLine" Width="99%" Rows="5" />
                </td>
            </tr>
        </table>
        <telerik:RadButton ID="UpdateRbtn" runat="server" CommandName="Update" 
            Text="更新" onclick="UpdateRbtn_Click">
        </telerik:RadButton>
        <telerik:RadButton ID="UpdateCancelRbtn" runat="server" CommandName="Cancel" 
            Text="取消" onclick="UpdateCancelRbtn_Click">
        </telerik:RadButton>
    </div>
    <br />
    <asp:SqlDataSource ID="sdsCourse" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select ca.sName as catName,co.sCode,co.sName as courseName from trCourse co
join trCategoryCourse caco on co.sCode=caco.sCourseCode
join trCategory ca on caco.sCateCode=ca.sCode"></asp:SqlDataSource>
    <asp:Label ID="lblSelectedCourseCode" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lblAutoKey" runat="server" Visible="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
    </style>
</asp:Content>
