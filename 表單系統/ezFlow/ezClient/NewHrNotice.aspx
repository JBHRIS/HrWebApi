<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewHrNotice.aspx.cs" Inherits="NewHrNotice" ValidateRequest="false"  %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body class="none" STYLE="OVERFLOW:SCROLL;OVERFLOW-X:HIDDEN" scroll="auto">
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="iAutoKey" DataSourceID="odsNotice" Width="100%" OnRowCommand="gv_RowCommand">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="SelectNotice"
                                    Text="修改" CommandArgument='<%# Eval("iAutoKey") %>'></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandArgument='<%# Eval("iAutoKey") %>'
                                    CommandName="SelectFiles" Text="檔案管理"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("iAutoKey") %>'
                                    CommandName="Delete" OnClientClick="return confirm('您確定要刪除嗎？');" Text="刪除"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="View"
                                    Text="預覽" CommandArgument='<%# Eval("iAutoKey") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:Button ID="btnAdd" runat="server" CommandName="NewNotice" Text="新增公告" />
                            </HeaderTemplate>
                            <ItemStyle Width="1%" Wrap="False" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="iAutoKey" HeaderText="iAutoKey" InsertVisible="False"
                            ReadOnly="True" SortExpression="iAutoKey" Visible="False" />
                        <asp:BoundField DataField="sCaption" HeaderText="標題" SortExpression="sCaption" />
                        <asp:BoundField DataField="sContent" HeaderText="sContent" SortExpression="sContent"
                            Visible="False" />
                        <asp:BoundField DataField="dDateA" DataFormatString="{0:d}" HeaderText="生效日" HtmlEncode="False"
                            SortExpression="dDateA" />
                        <asp:BoundField DataField="dDateD" DataFormatString="{0:d}" HeaderText="失效日" HtmlEncode="False"
                            SortExpression="dDateD" />
                        <asp:BoundField DataField="sKeyMan" HeaderText="登錄者" SortExpression="sKeyMan" />
                        <asp:BoundField DataField="FilesCount" HeaderText="上傳檔案數" SortExpression="FilesCount" />
                    </Columns>
                    <EmptyDataTemplate>
                        目前並沒有任何公告。 請<asp:LinkButton ID="lbtnAdd" runat="server" CommandName="NewNotice">按我</asp:LinkButton>來新增公告。
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsNotice" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="ezClientDSTableAdapters.HrNoticeTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_iAutoKey" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="sCaption" Type="String" />
                        <asp:Parameter Name="sContent" Type="String" />
                        <asp:Parameter Name="dDateA" Type="DateTime" />
                        <asp:Parameter Name="dDateD" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="Original_iAutoKey" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="sCaption" Type="String" />
                        <asp:Parameter Name="sContent" Type="String" />
                        <asp:Parameter Name="dDateA" Type="DateTime" />
                        <asp:Parameter Name="dDateD" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:Label ID="lblAutoKey" runat="server" Visible="False">0</asp:Label></asp:View>
            <asp:View ID="View2" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td nowrap="nowrap" style="text-align: right" width="1%">
                            主旨</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtCaption" runat="server" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="text-align: right" width="1%">
                            內容</td>
                        <td colspan="3">
                            <fckeditorv2:fckeditor id="txtContent" runat="server" basepath="./FCKeditor/" height="300px"
                                width="100%"></fckeditorv2:fckeditor>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="text-align: right" width="1%">
                            生效日</td>
                        <td>
                            <asp:TextBox ID="txtDateA" runat="server">1900/1/1</asp:TextBox>
                        </td>
                        <td nowrap="nowrap" style="text-align: right" width="1%">
                            失效日</td>
                        <td>
                            <asp:TextBox ID="txtDateD" runat="server">9999/12/31</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="text-align: right" width="1%">
                            登錄者</td>
                        <td>
                            <asp:Label ID="lblMan" runat="server"></asp:Label></td>
                        <td nowrap="nowrap" style="text-align: right" width="1%">
                            登錄日期</td>
                        <td>
                            <asp:Label ID="lblDate" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" nowrap="nowrap" width="1%">
                            <asp:Button ID="btnSend" runat="server" Text="新增" CommandName="Add" Width="50%" OnClick="btnSend_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="取消" Width="50%" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td nowrap="nowrap" style="text-align: right" width="1%">
                            上傳檔案名稱</td>
                        <td>
                            <asp:FileUpload ID="fuNotice" runat="server" />
                            ※提醒您，要上傳的檔案請先壓縮後再行上傳。</td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="text-align: right" width="1%">
                            檔案說明</td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" nowrap="nowrap" style="text-align: left">
                            <asp:Button ID="btnUpload" runat="server" Text="上傳" Width="50%" OnClick="btnUpload_Click" />
                            <asp:Button ID="btnCal" runat="server" Text="返回" Width="50%" OnClick="btnCancel_Click" /></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="text-align: right" width="1%">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" nowrap="nowrap" style="text-align: left">
                            <asp:GridView ID="gvFiles" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="odsFiles" Width="100%" OnRowCommand="gvFiles_RowCommand">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemStyle Width="1%" Wrap="False" />
                                        <HeaderStyle Wrap="True" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("iAutoKey") %>'
                                                CommandName="Download" Text="下載"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('您確定要刪除嗎？');" Text="刪除" CommandArgument='<%# Eval("iAutoKey") %>'></asp:LinkButton>
                                        </ItemTemplate>
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
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByHrNotice_iAutoKey" TypeName="ezClientDSTableAdapters.HrNoticeFilesTableAdapter"
                    UpdateMethod="Update">
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
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
