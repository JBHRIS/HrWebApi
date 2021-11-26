<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="NewPeople.aspx.cs" Inherits="NewPeople" Title="ezClient v1.0" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td rowspan="2">
                <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                        <asp:Button ID="btnEdit" runat="server" Text="編輯新人專區" OnClick="btnEdit_Click" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblContent" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gv" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        DataKeyNames="iAutoKey" DataSourceID="odsFiles" OnRowCommand="gvFiles_RowCommand"
                                        Width="100%">
                                        <RowStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("iAutoKey") %>'
                                                        CommandName="Download" Text="下載"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="True" />
                                                <ItemStyle Width="1%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="sServerName" HeaderText="加密檔名" SortExpression="sServerName"
                                                Visible="False" />
                                            <asp:BoundField DataField="sUploadName" HeaderText="上傳檔名" SortExpression="sUploadName" />
                                            <asp:BoundField DataField="sType" HeaderText="檔案型態" SortExpression="sType" Visible="False" />
                                            <asp:BoundField DataField="iSize" HeaderText="檔案大小(KB)" SortExpression="iSize">
                                                <HeaderStyle Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="上傳日期" HtmlEncode="False"
                                                SortExpression="dDate" />
                                            <asp:BoundField DataField="sDescription" HeaderText="檔案說明" SortExpression="sDescription" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            目前無任何附件。
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="text-align: center">
                                    編輯內容</td>
                            </tr>
                            <tr>
                                <td>
                        <FCKeditorV2:FCKeditor ID="txtContent" runat="server" BasePath="./FCKeditor/" Height="400px">
                        </FCKeditorV2:FCKeditor>
                                </td>
                            </tr>
                            <tr>
                                <td>
                        <asp:Button ID="btnY" runat="server" Text="儲存" OnClick="btnY_Click" OnClientClick="return confirm('您確定要儲存嗎？');" />
                        <asp:Button ID="btnN" runat="server" Text="放棄或返回" OnClick="btnN_Click" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    上傳檔案</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvFiles" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="odsFiles" OnRowCommand="gvFiles_RowCommand"
                                        Width="100%">
                                        <RowStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("iAutoKey") %>'
                                                        CommandName="Download" Text="下載"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("iAutoKey") %>'
                                                        CommandName="Delete" OnClientClick="return confirm('您確定要刪除嗎？');" Text="刪除"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="True" />
                                                <ItemStyle Width="1%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="iAutoKey" HeaderText="iAutoKey" InsertVisible="False"
                                                ReadOnly="True" SortExpression="iAutoKey" Visible="False" />
                                            <asp:BoundField DataField="HrNotice_iAutoKey" HeaderText="HrNotice_iAutoKey" SortExpression="HrNotice_iAutoKey"
                                                Visible="False" />
                                            <asp:BoundField DataField="sServerName" HeaderText="加密檔名" SortExpression="sServerName" />
                                            <asp:BoundField DataField="sUploadName" HeaderText="上傳檔名" SortExpression="sUploadName" />
                                            <asp:BoundField DataField="sType" HeaderText="檔案型態" SortExpression="sType" />
                                            <asp:BoundField DataField="iSize" HeaderText="檔案大小(KB)" SortExpression="iSize" />
                                            <asp:BoundField DataField="dDate" HeaderText="上傳日期" SortExpression="dDate" />
                                            <asp:BoundField DataField="sDescription" HeaderText="檔案說明" SortExpression="sDescription" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            目前無任何上傳檔案。
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="odsFiles" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByHrNotice_iAutoKey"
                                        TypeName="ezClientDSTableAdapters.HrNoticeFilesTableAdapter" UpdateMethod="Update">
                                        <DeleteParameters>
                                            <asp:Parameter Name="Original_iAutoKey" Type="Int32" />
                                        </DeleteParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="HrNotice_iAutoKey" Type="Int32" />
                                            <asp:Parameter Name="sServerName" Type="String" />
                                            <asp:Parameter Name="sUploadName" Type="String" />
                                            <asp:Parameter Name="sType" Type="String" />
                                            <asp:Parameter Name="iSize" Type="Int32" />
                                            <asp:Parameter Name="dDate" Type="DateTime" />
                                            <asp:Parameter Name="sDescription" Type="String" />
                                            <asp:Parameter Name="Original_iAutoKey" Type="Int32" />
                                        </UpdateParameters>
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="lblAutoKey" Name="HrNotice_iAutoKey" PropertyName="Text"
                                                Type="Int32" />
                                        </SelectParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="HrNotice_iAutoKey" Type="Int32" />
                                            <asp:Parameter Name="sServerName" Type="String" />
                                            <asp:Parameter Name="sUploadName" Type="String" />
                                            <asp:Parameter Name="sType" Type="String" />
                                            <asp:Parameter Name="iSize" Type="Int32" />
                                            <asp:Parameter Name="dDate" Type="DateTime" />
                                            <asp:Parameter Name="sDescription" Type="String" />
                                        </InsertParameters>
                                    </asp:ObjectDataSource>
                                    <asp:Label ID="lblAutoKey" runat="server" Visible="False">-1</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td nowrap="nowrap" style="text-align: right" width="1%">
                                                檔案名稱</td>
                                            <td>
                                                <asp:FileUpload ID="fuP" runat="server" />
                                                ※提醒您，要上傳的檔案請先壓縮後再行上傳。</td>
                                            <td rowspan="2" style="width: 5px">
                                                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上傳" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" style="text-align: right" width="1%">
                                                檔案說明</td>
                                            <td>
                                                <asp:TextBox ID="txtDesc" runat="server" Width="100%"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView></td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td rowspan="1">
                <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

