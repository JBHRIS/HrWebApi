<%@ Page Title="" Language="C#" MasterPageFile="~/mpStd0990111.master" AutoEventWireup="true" CodeFile="Std.aspx.cs" Inherits="Improve_Std" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function fillCell(row, cellNumber, text) {
            var cell = row.insertCell(cellNumber);
            cell.innerHTML = text;
            cell.style.borderBottom = cell.style.borderRight = "solid 1px #aaaaff";
        }
        function addToClientTable(name, text) {
            var table = document.getElementById("<%= clientSide.ClientID %>");
            var row = table.insertRow(0);
            fillCell(row, 0, name);
            fillCell(row, 1, text);
        }

        function uploadError(sender, args) {
            addToClientTable(args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>");
        }
        function uploadComplete(sender, args) {
            var contentType = args.get_contentType();
            var text = args.get_length() + " bytes";
            if (contentType.length > 0) {
                text += ", '" + contentType + "'";
            }
            //            addToClientTable(args.get_fileName(), text);
            //            document.getElementById("<%= lblDragNameUpload.ClientID %>").innerText = text;
            //            document.getElementById("<%= lblDragNameUpload.ClientID %>").value = text;
            //            __doPostBack('<%= hiddenTargetControlForModalPopupUpload.ClientID %>', '');
            //            this.mpePopupUpload.Show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblTitle" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDept" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblRoleAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblFlowTreeID" runat="server" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
        <tr>
            <th>
                主旨</th>
            <td colspan="5">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="txtDescription"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                類別</th>
            <td>
                <asp:DropDownList ID="ddlCat" runat="server" DataSourceID="sdsCat" 
                    DataTextField="sName" DataValueField="sCode">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sdsCat" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Flow %>" 
                    SelectCommand="SELECT sCode, sName FROM wfFormCode WHERE (sCategory = @sCategory) AND (iOrder &gt; 0) ORDER BY iOrder">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="ImproveCat" Name="sCategory" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <th>
                日期</th>
            <td>
                <asp:Label ID="lblDate" runat="server"></asp:Label>
            </td>
            <th>
                意見提案人</th>
            <td>
                <asp:Label ID="lblName" runat="server"></asp:Label>
                <asp:CheckBox ID="cbName" runat="server" Checked="True" Text="匿名" />
            </td>
        </tr>
        <tr>
            <th>
                附件</th>
            <td colspan="5">
                <asp:Button ID="btnFile" runat="server" Text="附件" onclick="btnFile_Click" />
                <asp:Button ID="btnFlow" runat="server" OnClick="btnFlow_Click" Text="進行中流程" 
                    UseSubmitBehavior="False" />
            </td>
        </tr>
        <tr>
            <th colspan="6">
                意見</th>
        </tr>
        <tr>
            <td colspan="6">
                <asp:TextBox ID="txtNote" runat="server" Height="200px" TextMode="MultiLine" 
                    Width="100%"></asp:TextBox>
            </td>
        </tr>
    </table>
                </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="送出傳簽"
                            OnClientClick="return confirm('您確定要送出嗎？');" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="plPopupFlow" runat="server" CssClass="modalPopup" Style="display: none;"
                            Width="600px">
                            <table cellpadding="0" cellspacing="0" width="100%" class="TableFullBorder">
                                <tr>
                                    <td>
                                        <asp:Panel ID="plDragFlow" runat="server" Style="border-right: gray 1px solid; border-top: gray 1px solid;
                                            border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid;
                                            background-color: #dddddd;">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td nowrap="nowrap">
                                                            <asp:Label ID="lblDragNameFlow" runat="server" Text="進行中流程"></asp:Label>
                                                        </td>
                                                        <th align="right" width="1%">
                                                            <asp:Button ID="btnExitFlow" runat="server" CssClass="ButtonExit" Text="×" OnClick="btnExitFlow_Click" />
                                                        </th>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Label ID="lblFlowID" runat="server" Visible="False"></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvFlow" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            DataKeyNames="iAutoKey" DataSourceID="sdsFlow" ForeColor="#333333" GridLines="None"
                                                            Width="100%">
                                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                                                <asp:BoundField DataField="sTitle" HeaderText="主旨"
                                                                    SortExpression="sTitle" />
                                                                <asp:BoundField DataField="sCatName" HeaderText="類別" 
                                                                    SortExpression="sCatName" />
                                                                <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="日期"
                                                                    SortExpression="dDate" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <EmptyDataTemplate>
                                                                無申請者資料。
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="sdsFlow" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                            SelectCommand="SELECT * FROM wfAppImprove
WHERE          (sState = '1') AND (idProcess &lt;&gt; 0) AND (sNobr = @sNobr)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="lblFlowID" DefaultValue="" Name="sNobr" PropertyName="Text" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMsgFlow" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button ID="hiddenTargetControlForModalPopupFlow" runat="server" Style="display: none" />&nbsp;
                        <asp:ModalPopupExtender ID="mpePopupFlow" runat="server" BackgroundCssClass="modalBackground"  X="0" Y="0"
                            BehaviorID="programmaticModalPopupBehavior2" DropShadow="true" PopupControlID="plPopupFlow"
                            PopupDragHandleControlID="plDragFlow" RepositionMode="RepositionOnWindowScroll"
                            TargetControlID="hiddenTargetControlForModalPopupFlow">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Panel ID="plPopupUpload" runat="server" CssClass="modalPopup" Style="display: none;"
                            Width="600px">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:Panel ID="plDragUpload" runat="server" Style="border-right: gray 1px solid;
                                            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
                                            border-bottom: gray 1px solid; background-color: #dddddd;">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td nowrap="nowrap">
                                                            <asp:Label ID="lblDragNameUpload" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="right" width="1%">
                                                            <asp:Button ID="btnExitUpload" runat="server" CssClass="ButtonExit" Text="×" OnClick="btnExitUpload_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Label ID="lblUploadID" runat="server" Visible="False"></asp:Label>
                                            <asp:Label ID="lblUploadKey" runat="server" Visible="False"></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvUpload" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            DataKeyNames="iAutoKey" DataSourceID="sdsUpload" ForeColor="#333333" GridLines="None"
                                                            Width="100%" OnRowCommand="gvUpload_RowCommand" OnRowDataBound="gvUpload_RowDataBound">
                                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Bind("iAutoKey") %>'
                                                                            CommandName="Del" Text="刪除" />
                                                                        <asp:ConfirmButtonExtender ID="btnDel_ConfirmButtonExtender" runat="server" ConfirmText="您確定要刪除嗎？"
                                                                            Enabled="True" TargetControlID="btnDelete">
                                                                        </asp:ConfirmButtonExtender>
                                                                        <asp:Button ID="btnDownload" runat="server" CommandArgument='<%# Bind("iAutoKey") %>'
                                                                            CommandName="Download" Text="下載" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="sUpName" HeaderText="上傳名稱" SortExpression="sUpName" />
                                                                <asp:BoundField DataField="sDescription" HeaderText="說明" SortExpression="sDescription" />
                                                                <asp:BoundField DataField="sType" HeaderText="檔案類型" SortExpression="sType" />
                                                                <asp:BoundField DataField="iSize" HeaderText="大小(KB)" SortExpression="iSize" />
                                                                <asp:BoundField DataField="dKeyDate" HeaderText="上傳日期" SortExpression="dKeyDate" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <EmptyDataTemplate>
                                                                無上傳任何檔案。
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:SqlDataSource ID="sdsUpload" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                            DeleteCommand="DELETE FROM [wfFormUploadFile] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [wfFormUploadFile] ([sFormCode], [sFormName], [sProcessID], [idProcess], [sNobr], [sKey], [sUpName], [sServerName], [sDescription], [sType], [iSize], [dKeyDate]) VALUES (@sFormCode, @sFormName, @sProcessID, @idProcess, @sNobr, @sKey, @sUpName, @sServerName, @sDescription, @sType, @iSize, @dKeyDate)"
                                                            SelectCommand="SELECT * FROM [wfFormUploadFile] WHERE (([sProcessID] = @sProcessID) AND ([sNobr] = @sNobr) AND ([sKey] = @sKey))"
                                                            UpdateCommand="UPDATE [wfFormUploadFile] SET [sFormCode] = @sFormCode, [sFormName] = @sFormName, [sProcessID] = @sProcessID, [idProcess] = @idProcess, [sNobr] = @sNobr, [sKey] = @sKey, [sUpName] = @sUpName, [sServerName] = @sServerName, [sDescription] = @sDescription, [sType] = @sType, [iSize] = @iSize, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="lblDragNameUpload" Name="sProcessID" PropertyName="Text"
                                                                    Type="String" />
                                                                <asp:ControlParameter ControlID="lblUploadID" Name="sNobr" PropertyName="Text" Type="String" />
                                                                <asp:ControlParameter ControlID="lblUploadKey" Name="sKey" PropertyName="Text" Type="String" />
                                                            </SelectParameters>
                                                            <DeleteParameters>
                                                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                                                            </DeleteParameters>
                                                            <UpdateParameters>
                                                                <asp:Parameter Name="sFormCode" Type="String" />
                                                                <asp:Parameter Name="sFormName" Type="String" />
                                                                <asp:Parameter Name="sProcessID" Type="String" />
                                                                <asp:Parameter Name="idProcess" Type="Int32" />
                                                                <asp:Parameter Name="sNobr" Type="String" />
                                                                <asp:Parameter Name="sKey" Type="String" />
                                                                <asp:Parameter Name="sUpName" Type="String" />
                                                                <asp:Parameter Name="sServerName" Type="String" />
                                                                <asp:Parameter Name="sDescription" Type="String" />
                                                                <asp:Parameter Name="sType" Type="String" />
                                                                <asp:Parameter Name="iSize" Type="Int32" />
                                                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                                                            </UpdateParameters>
                                                            <InsertParameters>
                                                                <asp:Parameter Name="sFormCode" Type="String" />
                                                                <asp:Parameter Name="sFormName" Type="String" />
                                                                <asp:Parameter Name="sProcessID" Type="String" />
                                                                <asp:Parameter Name="idProcess" Type="Int32" />
                                                                <asp:Parameter Name="sNobr" Type="String" />
                                                                <asp:Parameter Name="sKey" Type="String" />
                                                                <asp:Parameter Name="sUpName" Type="String" />
                                                                <asp:Parameter Name="sServerName" Type="String" />
                                                                <asp:Parameter Name="sDescription" Type="String" />
                                                                <asp:Parameter Name="sType" Type="String" />
                                                                <asp:Parameter Name="iSize" Type="Int32" />
                                                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                                            </InsertParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        說明：<asp:TextBox ID="txtUpload" runat="server" CssClass="txtDescription"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        檔案：<asp:AsyncFileUpload ID="fu" runat="server" OnUploadedComplete="fu_UploadedComplete"
                                                            OnUploadedFileError="fu_UploadedFileError" OnClientUploadError="uploadError"
                                                            OnClientUploadComplete="uploadComplete" ThrobberID="lblThrobber" />
                                                        <asp:Label ID="lblThrobber" runat="server" Style="display: none">
<img src="../img/uploading.gif" align="absmiddle" alt="loading" />
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnUpload" runat="server" Text="上傳檔案" 
                                                            OnClick="btnUpload_Click" />
                                                        <asp:Label ID="lblMsgUpload" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                        <table style="border-collapse: collapse; border-left: solid 1px #aaaaff; border-top: solid 1px #aaaaff;"
                                                            runat="server" cellpadding="3" id="clientSide" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button ID="hiddenTargetControlForModalPopupUpload" runat="server" Style="display: none" />&nbsp;
                        <asp:ModalPopupExtender ID="mpePopupUpload" runat="server" BackgroundCssClass="modalBackground" X="0" Y="0"
                            BehaviorID="programmaticModalPopupBehavior4" DropShadow="true" PopupControlID="plPopupUpload"
                            PopupDragHandleControlID="plDragUpload" RepositionMode="RepositionOnWindowScroll" 
                            TargetControlID="hiddenTargetControlForModalPopupUpload">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

