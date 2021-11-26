<%@ Page Title="課程類別設定" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="trCategory.aspx.cs" Inherits="eTraining_Admin_Plan_trCategory" %>

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
            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= tvCate.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("trCategoryEdit.aspx?iAutoKey=" + id, "UserListDialog");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("trCategoryEdit.aspx", "UserListDialog");
                return false;
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

            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
            function refreshFV(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindFV");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindFV");
                }
            }
            function refreshTV(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindTV");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindTV");
                }
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("trTeacherEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
    <h2>
        課程類別設定<asp:Label ID="lblCategory" runat="server" Visible="False"></asp:Label>
    </h2>
    <table style="width: 340px" class="style1">
        <tr>
            <td>
                <telerik:RadButton ID="btnAddRootNode" runat="server" Text="新增類別" Width="90px" >
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnAddNode" runat="server" Text="新增階層" Width="90px" >
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnDelNode" runat="server" Text="刪除" OnClick="btnDelNode_Click"
                    Width="80px">
                </telerik:RadButton>
            </td>
            <td style="width:80px">
                <telerik:RadButton ID="btnEditNode" runat="server" Text="編輯" Width="80px">
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnMustTraining" runat="server" Text="必訓人員" Width="80px" 
                    onclick="btnMustTraining_Click">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <br />
    <div style="background-color: #CDE5FF; width: 250px" class="funcblock">
        <br />
        <telerik:RadButton ID="btnExpand" runat="server" GroupName="expand" OnClick="RadButton1_Click"
            Text="展開">
        </telerik:RadButton>
        <br />
        <br />
        <telerik:RadTreeView ID="tvCate" runat="server" OnNodeClick="tvCate_NodeClick" Skin="Office2007">
        </telerik:RadTreeView>
        <br />
    </div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest"
        EnablePageHeadUpdate="False">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddRootNode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnAddRootNode" />
                    <telerik:AjaxUpdatedControl ControlID="btnExpand" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddNode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnAddNode" />
                    <telerik:AjaxUpdatedControl ControlID="btnExpand" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnEditNode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnEditNode" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnExpand">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnExpand" />
                    <telerik:AjaxUpdatedControl ControlID="tvCate" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="tvCate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblCategory" />
                    <telerik:AjaxUpdatedControl ControlID="btnAddRootNode" />
                    <telerik:AjaxUpdatedControl ControlID="btnAddNode" />
                    <telerik:AjaxUpdatedControl ControlID="btnEditNode" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnExpand" />
                    <telerik:AjaxUpdatedControl ControlID="tvCate" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadWindowManager1">
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
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
</asp:Content>
