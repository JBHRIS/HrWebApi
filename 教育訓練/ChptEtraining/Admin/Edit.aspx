<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" MasterPageFile="~/mpEdit.master"
    Inherits="Admin_Edit" %>

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
    <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV"
        OnItemCommand="fv_ItemCommand" OnItemDeleted="fv_ItemDeleted" OnItemDeleting="fv_ItemDeleting"
        OnItemInserted="fv_ItemInserted" OnItemInserting="fv_ItemInserting" OnItemUpdated="fv_ItemUpdated"
        OnItemUpdating="fv_ItemUpdating" DefaultMode="Insert">
        <EditItemTemplate>
            <table class="tableOrange">
                <tr>
                    <th>
                        類別代碼
                    </th>
                    <th>
                        代碼
                    </th>
                    <th>
                        值
                    </th>
                    <th>
                        順序
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="sCategoryTextBox" runat="server" Text='<%# Bind("sCategory") %>'
                            CssClass="txtCode" />
                    </td>
                    <td>
                        <asp:TextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("sCode") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                       <telerik:RadMaskedTextBox ID="RadMaskedTextBox2" runat="server" Mask="##"
                    PromptChar=" "  Text='<%# Bind("iOrder") %>' CssClass="txtCode" LabelCssClass="" 
                            Width="100px" />

                 
                    </td>
                </tr>
                <tr>
                    <th>
                        備1
                    </th>
                    <th>
                        備2
                    </th>
                    <th>
                        備3
                    </th>
                    <th>
                        選項
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="s1TextBox" runat="server" Text='<%# Bind("s1") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="s2TextBox" runat="server" Text='<%# Bind("s2") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="s3TextBox" runat="server" Text='<%# Bind("s3") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:CheckBox ID="bDisplayCheckBox" runat="server" Checked='<%# Bind("bDisplay") %>'
                            Text="顯示" />
                        <asp:CheckBox ID="bSystemCheckBox" runat="server" Checked='<%# Bind("bSystem") %>'
                            Text="系統" />
                    </td>
                </tr>
                <tr>
                    <th colspan="4">
                        內容
                    </th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="sContentTextBox" runat="server" Text='<%# Bind("sContent") %>' CssClass="txtPath"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <telerik:RadButton ID="btnUpdate" runat="server" CommandName="Update" Text="更新" />
                        <telerik:RadButton ID="btnCancel" runat="server" CausesValidation="false" 
                            CommandName="Cancel" Text="取消" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' 
                Visible="False" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="tableOrange">
                <tr>
                    <th>
                        類別代碼
                    </th>
                    <th>
                        代碼
                    </th>
                    <th>
                        值
                    </th>
                    <th>
                        順序
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="sCategoryTextBox" runat="server" Text='<%# Bind("sCategory") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("sCode") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="iOrderTextBox" runat="server" Text='<%# Bind("iOrder") %>' CssClass="txtCode"/>
                    </td>
                </tr>
                <tr>
                    <th>
                        備1
                    </th>
                    <th>
                        備2
                    </th>
                    <th>
                        備3
                    </th>
                    <th>
                        選項
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="s1TextBox" runat="server" Text='<%# Bind("s1") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="s2TextBox" runat="server" Text='<%# Bind("s2") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="s3TextBox" runat="server" Text='<%# Bind("s3") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:CheckBox ID="bDisplayCheckBox" runat="server" Checked='<%# Bind("bDisplay") %>'
                            Text="顯示" />
                        <asp:CheckBox ID="bSystemCheckBox" runat="server" Checked='<%# Bind("bSystem") %>'
                            Text="系統" />
                    </td>
                </tr>
                <tr>
                    <th colspan="4">
                        內容
                    </th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="sContentTextBox" runat="server" Text='<%# Bind("sContent") %>' CssClass="txtPath"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <telerik:RadButton ID="btnInsert" runat="server" CommandName="Insert" Text="新增" />
                        <telerik:RadButton ID="btnCancel" runat="server" CausesValidation="false" 
                            CommandName="Cancel" Text="取消" />
               
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        DeleteCommand="DELETE FROM [mtCode] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [mtCode] ([sCategory], [sCode], [sName], [sContent], [s1], [s2], [s3], [iOrder], [bDisplay], [bSystem], [sKeyMan], [dKeyDate]) VALUES (@sCategory, @sCode, @sName, @sContent, @s1, @s2, @s3, @iOrder, @bDisplay, @bSystem, @sKeyMan, @dKeyDate)"
        SelectCommand="SELECT * FROM [mtCode] WHERE ([iAutoKey] = @iAutoKey)" UpdateCommand="UPDATE [mtCode] SET [sCategory] = @sCategory, [sCode] = @sCode, [sName] = @sName, [sContent] = @sContent, [s1] = @s1, [s2] = @s2, [s3] = @s3, [iOrder] = @iOrder, [bDisplay] = @bDisplay, [bSystem] = @bSystem, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sCategory" Type="String" />
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sContent" Type="String" />
            <asp:Parameter Name="s1" Type="String" />
            <asp:Parameter Name="s2" Type="String" />
            <asp:Parameter Name="s3" Type="String" />
            <asp:Parameter Name="iOrder" Type="Int32" />
            <asp:Parameter Name="bDisplay" Type="Boolean" />
            <asp:Parameter Name="bSystem" Type="Boolean" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="iAutoKey" QueryStringField="iAutoKey" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="sCategory" Type="String" />
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sContent" Type="String" />
            <asp:Parameter Name="s1" Type="String" />
            <asp:Parameter Name="s2" Type="String" />
            <asp:Parameter Name="s3" Type="String" />
            <asp:Parameter Name="iOrder" Type="Int32" />
            <asp:Parameter Name="bDisplay" Type="Boolean" />
            <asp:Parameter Name="bSystem" Type="Boolean" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    </asp:Content>

