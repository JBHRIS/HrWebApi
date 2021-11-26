<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="QTplEdit.aspx.cs" Inherits="eTraining_Questionary_QTplEdit" %>

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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <asp:Panel ID="pnlAdd" runat="server">
        <table class="tableBlue">
            <tr>
                <th>
                    問卷名稱
                </th>
                <td>
                    <telerik:RadTextBox ID="sNameTextBox" runat="server" Text='<%# Bind("Name") %>' DisplayText=""
                        LabelWidth="64px" type="text" value="" Width="160px" />
                </td>
            </tr>
            <tr>
                <th>
                    填寫人種類
                </th>
                <td>
                    <telerik:RadComboBox ID="cbxFillerCategory" runat="server" SelectedValue='<%# Bind("FillerCategory") %>'
                        Culture="zh-TW">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="員工" Value="S" />
                            <%--                                <telerik:RadComboBoxItem runat="server" Text="講師" Value="T" />
                                <telerik:RadComboBoxItem runat="server" Text="主管" Value="Supervisor" />
                                <telerik:RadComboBoxItem runat="server" Text="組訓員" Value="M" />
                                <telerik:RadComboBoxItem runat="server" Text="自定使用者" Value="CU" />--%>
                        </Items>
                        <WebServiceSettings>
                            <ODataSettings InitialContainerName="">
                            </ODataSettings>
                        </WebServiceSettings>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <th>
                    表頭
                </th>
                <td>
                    <telerik:RadEditor ID="etHeaderText" runat="server" Content='<%# Bind("HeaderText") %>'
                        EditModes="Design, Preview" Height="250px" Language="zh-TW" ToolsFile="~/Editor/RadEditor/BasicTools.xml">
                    </telerik:RadEditor>
                </td>
            </tr>
            <tr>
                <th>
                    表身
                </th>
                <td>
                    <telerik:RadEditor ID="etFooterText" runat="server" Content='<%# Bind("FooterText") %>'
                        EditModes="Design, Preview" Height="250px" Language="zh-TW" ToolsFile="~/Editor/RadEditor/BasicTools.xml">
                    </telerik:RadEditor>
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="說明:填寫人種類只在新增新問卷時可被設定一次，請慎選填寫人種類"
            Visible="False"></asp:Label>
        <telerik:RadNumericTextBox ID="ntbFillFormSpan" runat="server" Culture="zh-TW" DbValue='<%# bind("FillFormSpan") %>'
            MinValue="0" Width="50px" Value="0" Visible="False">
            <NumberFormat DecimalDigits="0" />
        </telerik:RadNumericTextBox>
        <br />
        <telerik:RadButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
            Text="插入" OnClick="InsertButton_Click" />
        &nbsp;<telerik:RadButton ID="InsertCancelButton" runat="server" CausesValidation="False"
            CommandName="Cancel" Text="取消" OnClick="InsertCancelButton_Click" />
    </asp:Panel>
    <asp:Panel ID="pnlEdit" runat="server">
        <table class="tableBlue">
            <tr>
                <th>
                    問卷名稱
                </th>
                <td>
                    <telerik:RadTextBox ID="tbName_E" runat="server" Text='' />
                </td>
            </tr>
            <tr>
                <th>
                    表頭
                </th>
                <td>
                    <telerik:RadEditor ID="etHeader_E" runat="server" EditModes="Design, Preview" Height="250px"
                        Language="zh-TW" ToolsFile="~/Editor/RadEditor/BasicTools.xml">
                    </telerik:RadEditor>
                </td>
            </tr>
            <tr>
                <th>
                    表身
                </th>
                <td>
                    <telerik:RadEditor ID="etFooter_E" runat="server" EditModes="Design, Preview" Height="250px"
                        Language="zh-TW" ToolsFile="~/Editor/RadEditor/BasicTools.xml">
                    </telerik:RadEditor>
                </td>
            </tr>
        </table>
        <telerik:RadTextBox ID="sCodeTextBox" runat="server" Visible="False" Width="50px" />
        <br />
        <telerik:RadButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
            Text="更新" OnClick="UpdateButton_Click" />
        &nbsp;
        <telerik:RadButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
            CommandName="Cancel" Text="取消" OnClick="UpdateCancelButton_Click" />
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>