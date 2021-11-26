<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="trTeachingMaterialDetailEdit.aspx.cs" Inherits="eTraining_Admin_trTeachingMaterialDetailEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            $('.funcblock').corner("15px");
            function ShowInsertForm() {
                window.radopen("trCategoryEdit.aspx", "UserListDialog");
                return false;
            }
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }
            function ShowInsertFormP(str) {
                window.radopen(str, "UserListDialog");
                return false;
            }


            function ShowInsertFormByParam(pid) {
                window.radopen("trCategoryEdit.aspx?pid=" + pid, "UserListDialog");
                return false;
            }
            function ShowEditFormByParam(pid) {
                window.radopen("trCategoryEdit.aspx?mode=e&pid=" + pid, "UserListDialog");
                return false;
            }
            function ShowCourseFormByParam(pid, mode) {
                window.radopen("trCourseEdit.aspx?pid=" + pid + "&m=" + mode, "UserListDialog2");
                return false;
            }


            function CancelEdit() {
                GetRadWindow().close();
            }


            function RowDblClick(sender, eventArgs) {
                window.radopen("trTeacherEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
    <h2>
        教案詳細內容<asp:Label ID="lblMaterialAutoKey" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblSelectedNode" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblPNode" runat="server" Visible="False"></asp:Label>
    </h2>
    <table style="width: 340px" class="style1">
        <tr>
            <td width="90px">
                <telerik:RadButton ID="btnAddRootNode" runat="server" Text="新增教學大綱" Width="90px"
                    OnClick="btnAddRootNode_Click">
                </telerik:RadButton>
            </td>
            <td width="90px">
                <telerik:RadButton ID="btnAddNode" runat="server" Text="新增重點內容" Width="90px" 
                    onclick="btnAddNode_Click" style="height: 21px">
                </telerik:RadButton>
            </td>
            <td width="80px">
                <telerik:RadButton ID="btnDelNode" runat="server" Text="刪除" OnClick="btnDelNode_Click"
                    Width="80px">
                </telerik:RadButton>
            </td>
            <td width="80px">
                <telerik:RadButton ID="btnEditNode" runat="server" Text="編輯" Width="80px" 
                    OnClick="btnEditNode_Click" Visible="False">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <br />
    <div style="background-color: #CDE5FF; width: 40%;float:left;scrollbar-face-color: #ffffff;
                scrollbar-highlight-color: #ffffff; overflow-x: scroll;overflow-y:scroll; scrollbar-shadow-color: #91C7FF;
                scrollbar-3dlight-color: #91C7FF; scrollbar-arrow-color: #91C7FF; scrollbar-darkshadow-color: #ffffff;
                height: 600px;overflow:-moz-scrollbars-vertical !important" class="funcblock">
        <br />
        <telerik:RadButton ID="btnExpand" runat="server" GroupName="expand" OnClick="RadButton1_Click"
            Text="展開">
        </telerik:RadButton>
        <br />
        <br />
        <telerik:RadTreeView ID="tv" runat="server" OnNodeClick="tv_NodeClick" 
            Skin="Office2007">
        </telerik:RadTreeView>
        <br />
    </div>
    <div style="float:right;width:57%">
        <asp:Panel ID="pnlNodes" runat="server" Visible="False">
            
        <table class="tableBlue">
        <tr><th>內容名稱</th><td width="300px"><telerik:RadTextBox ID="tbOutline" Runat="server" Rows="3" 
                TextMode="MultiLine" Width="100%">
            </telerik:RadTextBox></td></tr>
            <tr><th>順位</th><td>
                <telerik:RadNumericTextBox ID="ntbOrder" Runat="server" 
                Width="50px" DataType="System.Int32" MaxValue="100" MinValue="0" Value="1">
                    <numberformat decimaldigits="0" />
            </telerik:RadNumericTextBox></td></tr>
                <tr>
                    <th>
                        教學方法</th>
                    <td>
                        <telerik:RadComboBox ID="cbxMethod" Runat="server" CheckBoxes="true" 
                            DataSourceID="sdsTrainingMethod" DataTextField="sName" 
                            DataValueField="sCode">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        教學資源</th>
                    <td>
                        <telerik:RadComboBox ID="cbxResources" Runat="server" CheckBoxes="True" 
                            DataSourceID="sdsTeachingResources" DataTextField="ResourceName" 
                            DataValueField="ResourceCode">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        時間</th>
                    <td>
                        <telerik:RadNumericTextBox ID="ntbMinsTime" Runat="server" 
                            DataType="System.Int32" MinValue="0" Value="0">
                            <numberformat decimaldigits="0" />
                        </telerik:RadNumericTextBox>
                        分鐘</td>
                </tr>
                <tr>
                    <th>
                        備註</th>
                    <td>
                        <telerik:RadTextBox ID="tbNote" Runat="server" Rows="3" TextMode="MultiLine" 
                            Width="100%">
                        </telerik:RadTextBox>
                    </td>
                </tr>
            </table>
                    <telerik:RadButton ID="btnSave" runat="server" Text="存檔" 
                onclick="btnSave_Click">
        </telerik:RadButton>
            <telerik:RadButton ID="btnExit" runat="server" onclick="btnExit_Click" 
                Text="離開">
            </telerik:RadButton>
        </asp:Panel>
    </div>
    <br />
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="True">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Editing record" Height="450px"
                Width="400px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true" />
            <telerik:RadWindow ID="UserListDialog2" runat="server" EnableShadow="True" Modal="True"
                Style="display: none;" Height="550px" Width="650px">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <asp:SqlDataSource ID="sdsTrainingMethod" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="SELECT [sCode], [sName] FROM [trTeachingMethod]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsTeachingResources" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        SelectCommand="SELECT * FROM [trTeachingResource]"></asp:SqlDataSource>
</asp:Content>
