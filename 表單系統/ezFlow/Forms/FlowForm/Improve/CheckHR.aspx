<%@ Page Title="" Language="C#" MasterPageFile="~/mpCheck0990119.master" AutoEventWireup="true" CodeFile="CheckHR.aspx.cs" Inherits="Improve_CheckHR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:Label ID="lblTitle" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblNobrSign" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDept" runat="server" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <th>
                        被申請資料
                    </th>
                </tr>
                <tr>
                    <td>
                           <table class="TableFullBorder">
        <tr>
            <th>
                主旨</th>
            <td colspan="5">
                <asp:Label ID="lblTitle1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                類別</th>
            <td>
                <asp:Label ID="lblCat" runat="server"></asp:Label>
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
                <asp:CheckBox ID="cbName" runat="server" Checked="True" Text="匿名" 
                    Enabled="False" />
            </td>
        </tr>
        <tr>
            <th>
                附件</th>
            <td colspan="5">
                <asp:Button ID="btnFile" runat="server" Text="附件" onclick="btnFile_Click" />
            </td>
        </tr>
        <tr>
            <th colspan="6">
                意見</th>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Label ID="lblNote" runat="server"></asp:Label>
            </td>
        </tr>
    </table></td>
                </tr>
                <tr>
                    <th>
                        簽核者資料
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvSignM" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            DataSourceID="sdsSignM" Width="100%">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                <asp:BoundField DataField="sNote" HeaderText="意見" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="簽核日期" SortExpression="dKeyDate" />
                            </Columns>
                            <EmptyDataTemplate>
                                無簽核資料。
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsSignM" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT * FROM [wfFormSignM]
WHERE          (sProcessID = @sProcessID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <th>
                        主管意見
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNote" runat="server" Height="100px" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                                                            <asp:Label ID="lblDragNameUpload" runat="server"></asp:Label>
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
                                                                <asp:TemplateField HeaderText="下載">
                                                                    <ItemTemplate>
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
                                                            SelectCommand="SELECT iAutoKey, sFormCode, sFormName, sProcessID, idProcess, sNobr, sKey, sUpName, sServerName, sDescription, sType, iSize, dKeyDate FROM wfFormUploadFile WHERE (sKey = @sKey)"
                                                            
                                                            UpdateCommand="UPDATE [wfFormUploadFile] SET [sFormCode] = @sFormCode, [sFormName] = @sFormName, [sProcessID] = @sProcessID, [idProcess] = @idProcess, [sNobr] = @sNobr, [sKey] = @sKey, [sUpName] = @sUpName, [sServerName] = @sServerName, [sDescription] = @sDescription, [sType] = @sType, [iSize] = @iSize, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                                                            <SelectParameters>
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
                                                        <asp:Label ID="lblMsgUpload" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button ID="hiddenTargetControlForModalPopupUpload" runat="server" Style="display: none" />&nbsp;
                        <asp:ModalPopupExtender ID="mpePopupUpload" runat="server" BackgroundCssClass="modalBackground"
                            BehaviorID="programmaticModalPopupBehavior3" DropShadow="true" PopupControlID="plPopupUpload"
                            X="0" Y="0" PopupDragHandleControlID="plDragUpload" RepositionMode="RepositionOnWindowScroll"
                            TargetControlID="hiddenTargetControlForModalPopupUpload">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="updatePanel2" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="送出傳簽" OnClick="btnSubmit_Click" />
                        <asp:ConfirmButtonExtender ID="btnSubmit_ConfirmButtonExtender" runat="server" ConfirmText="您確定要送出傳簽嗎？"
                            Enabled="True" TargetControlID="btnSubmit">
                        </asp:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

