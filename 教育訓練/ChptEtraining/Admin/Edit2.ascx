<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Edit2.ascx.cs" Inherits="Admin_Edit2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Label ID="lblScript" runat="server"    Text=""></asp:Label>



<asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(DataItem,"iAutoKey") %>'
    Visible="False"></asp:Label>
<asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV"
    OnItemDeleted="fv_ItemDeleted" OnItemDeleting="fv_ItemDeleting" OnItemInserted="fv_ItemInserted"
    OnItemInserting="fv_ItemInserting" OnItemUpdated="fv_ItemUpdated" OnItemUpdating="fv_ItemUpdating"
    DefaultMode="Insert" onitemcommand="fv_ItemCommand">
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
                    <asp:TextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("sCode") %>' CssClass="txtCode" />
                </td>
                <td>
                    <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>' CssClass="txtCode" />
                </td>
                <td>
                    <telerik:RadMaskedTextBox ID="RadMaskedTextBox2" runat="server" Mask="##" PromptChar=" "
                        Text='<%# Bind("iOrder") %>' CssClass="txtCode" LabelCssClass="" Width="100px" />
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
                    <asp:TextBox ID="s1TextBox" runat="server" Text='<%# Bind("s1") %>' CssClass="txtCode" />
                </td>
                <td>
                    <asp:TextBox ID="s2TextBox" runat="server" Text='<%# Bind("s2") %>' CssClass="txtCode" />
                </td>
                <td>
                    <asp:TextBox ID="s3TextBox" runat="server" Text='<%# Bind("s3") %>' CssClass="txtCode" />
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
                    <asp:TextBox ID="sContentTextBox" runat="server" Text='<%# Bind("sContent") %>' CssClass="txtPath" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:ImageButton ID="ibtnUpdate" AlternateText="更新" ToolTip="更新" runat="server" CommandName="Update"
                        ImageUrl='<%# RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Grid.Update.gif") %>'/>
                    <asp:ImageButton ID="ibtnCancel" ToolTip="取消" AlternateText="取消" runat="server" CausesValidation="False"
                        CommandName="Cancel" ImageUrl='<%# RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Grid.Cancel.gif") %>'     />
                    <asp:ImageButton ID="ibtnCancel0" runat="server" AlternateText="取消" 
                        CausesValidation="False" CommandName="Cancel1" 
                        ImageUrl='<%# RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Grid.Cancel.gif") %>' 
                        ToolTip="取消" />
                </td>
            </tr>
        </table>
        <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' Visible="False" />
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
                    <asp:TextBox ID="sCategoryTextBox" runat="server" Text='<%# Bind("sCategory") %>'
                        CssClass="txtCode" />
                </td>
                <td>
                    <asp:TextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("sCode") %>' CssClass="txtCode" />
                </td>
                <td>
                    <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>' CssClass="txtCode" />
                </td>
                <td>
                    <asp:TextBox ID="iOrderTextBox" runat="server" Text='<%# Bind("iOrder") %>' CssClass="txtCode" />
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
                    <asp:TextBox ID="s1TextBox" runat="server" Text='<%# Bind("s1") %>' CssClass="txtCode" />
                </td>
                <td>
                    <asp:TextBox ID="s2TextBox" runat="server" Text='<%# Bind("s2") %>' CssClass="txtCode" />
                </td>
                <td>
                    <asp:TextBox ID="s3TextBox" runat="server" Text='<%# Bind("s3") %>' CssClass="txtCode" />
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
                    <asp:TextBox ID="sContentTextBox" runat="server" Text='<%# Bind("sContent") %>' CssClass="txtPath" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:ImageButton ID="ibtnInsert" AlternateText="新增" ToolTip="新增" runat="server" CommandName="PerformInsert"
                        ImageUrl='<%# RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Grid.Update.gif") %>'  />
                    <asp:ImageButton ID="ibtnCancel" ToolTip="取消" AlternateText="取消" runat="server" CausesValidation="False"
                        CommandName="Cancel" ImageUrl='<%# RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Grid.Cancel.gif") %>' />
                </td>
            </tr>
        </table>
    </InsertItemTemplate>
</asp:FormView>
<asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
    InsertCommand="INSERT INTO [mtCode] ([sCategory], [sCode], [sName], [sContent], [s1], [s2], [s3], [iOrder], [bDisplay], [bSystem], [sKeyMan], [dKeyDate]) VALUES (@sCategory, @sCode, @sName, @sContent, @s1, @s2, @s3, @iOrder, @bDisplay, @bSystem, @sKeyMan, @dKeyDate)"
    SelectCommand="SELECT * FROM [mtCode] WHERE ([iAutoKey] = @iAutoKey)" UpdateCommand="UPDATE [mtCode] SET [sCategory] = @sCategory, [sCode] = @sCode, [sName] = @sName, [sContent] = @sContent, [s1] = @s1, [s2] = @s2, [s3] = @s3, [iOrder] = @iOrder, [bDisplay] = @bDisplay, [bSystem] = @bSystem, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
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
        <asp:ControlParameter ControlID="lblID" Name="iAutoKey" PropertyName="Text" Type="Int32" />
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
