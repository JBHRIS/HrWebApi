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
    <asp:FormView ID="fv" runat="server" DataKeyNames="Code" DataSourceID="sdsFV"
        OnItemCommand="fv_ItemCommand" OnItemInserting="fv_ItemInserting" OnItemUpdating="fv_ItemUpdating"
        OnItemInserted="fv_ItemInserted" OnItemUpdated="fv_ItemUpdated" DefaultMode="Insert">
        <EditItemTemplate>
            <asp:Label ID="iAutokeyLabel1" runat="server" Text='<%# Eval("Code") %>' Visible="False" />
            <table class="tableBlue">
                <tr>
                    <th>
                        問卷名稱
                    </th>
                    <td>
                        <telerik:RadTextBox ID="sNameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                </tr>
                
                <tr>
                    <th>
                        填寫日限制
                    </th>
                    <td>
                        <telerik:RadNumericTextBox ID="ntbFillFormSpan" runat="server" Culture="zh-TW" DbValue='<%# bind("FillFormSpan") %>'
                            MinValue="0" Width="50px">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        天內
                    </td>
                </tr>
            </table>
            <telerik:RadTextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("Code") %>'
                Visible="False" Width="50px" />
            <asp:Label ID="lblIsTeacherGrade" runat="server" Text='<%# bind("IsTeacherGrade") %>'
                Visible="False"></asp:Label>
                <telerik:RadComboBox ID="cbxFillerCategory" runat="server" SelectedValue='<%# Bind("FillerCategory") %>'
                            Culture="zh-TW" Visible="False">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="學員" Value="S" />
                                <telerik:RadComboBoxItem runat="server" Text="講師" Value="T" />
                                <telerik:RadComboBoxItem runat="server" Text="組訓員" Value="M" />
                                <telerik:RadComboBoxItem runat="server" Text="自定使用者" Value="CU" />
                            </Items>
                            <WebServiceSettings>
                                <ODataSettings InitialContainerName="">
                                </ODataSettings>
                            </WebServiceSettings>
                        </telerik:RadComboBox>
            <br />
            <br />
            <telerik:RadButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="更新" />
            &nbsp;&nbsp;
            <telerik:RadButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="取消" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="tableBlue">
                <tr>
                    <th>
                        問卷名稱
                    </th>
                    <td>
                        <telerik:RadTextBox ID="sNameTextBox" runat="server" Text='<%# Bind("Name") %>' 
                            DisplayText="" LabelWidth="64px" type="text" value="" Width="160px" />
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
                                <telerik:RadComboBoxItem runat="server" Text="學員" Value="S" />
                                <telerik:RadComboBoxItem runat="server" Text="講師" Value="T" />
                                <telerik:RadComboBoxItem runat="server" Text="組訓員" Value="M" />
                                <telerik:RadComboBoxItem runat="server" Text="自定使用者" Value="CU" />
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
                        填寫日限制
                    </th>
                    <td>
                        <telerik:RadNumericTextBox ID="ntbFillFormSpan" runat="server" Culture="zh-TW" DbValue='<%# bind("FillFormSpan") %>'
                            MinValue="0" Width="50px">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        天內
                    </td>
                </tr>
            </table>
            <div style="color: Red">
                說明:填寫人種類只在新增新問卷時可被設定一次，請慎選填寫人種類</div>
            <br />
            <telerik:RadButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="插入" />
            &nbsp;<telerik:RadButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="取消" />
        </InsertItemTemplate>
    </asp:FormView>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <asp:SqlDataSource ID="sdsFv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        DeleteCommand="DELETE FROM [QTpl] WHERE [Code] = @Code" 
        InsertCommand="INSERT INTO [QTpl] ([Code], [Name], [FillerCategory], [IsTeacherGrade], [FillFormSpan], [KeyMan], [KeyDate]) VALUES (@Code, @Name, @FillerCategory, @IsTeacherGrade, @FillFormSpan, @KeyMan, @KeyDate)" 
        SelectCommand="SELECT * FROM [QTpl] WHERE [Code] = @Code" 
        
        UpdateCommand="UPDATE [QTpl] SET [Name] = @Name, [FillerCategory] = @FillerCategory, [IsTeacherGrade] = @IsTeacherGrade, [FillFormSpan] = @FillFormSpan, [KeyMan] = @KeyMan, [KeyDate] = @KeyDate WHERE [Code] = @Code">
        <DeleteParameters>
            <asp:Parameter Name="Code" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Code" Type="String" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="FillerCategory" Type="String" />
            <asp:Parameter Name="IsTeacherGrade" Type="Boolean" />
            <asp:Parameter Name="FillFormSpan" Type="Int32" />
            <asp:Parameter Name="KeyMan" Type="String" />
            <asp:Parameter Name="KeyDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue=" " Name="Code" QueryStringField="Id" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="FillerCategory" Type="String" />
            <asp:Parameter Name="IsTeacherGrade" Type="Boolean" />
            <asp:Parameter Name="FillFormSpan" Type="Int32" />
            <asp:Parameter Name="KeyMan" Type="String" />
            <asp:Parameter Name="KeyDate" Type="DateTime" />
            <asp:QueryStringParameter DefaultValue=" " Name="Code" QueryStringField="Id" 
                Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
