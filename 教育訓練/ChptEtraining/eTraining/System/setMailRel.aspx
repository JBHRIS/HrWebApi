<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="setMailRel.aspx.cs" Inherits="eTraining_System_setMailRel" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../../UC/MailVariables.ascx" tagname="MailVariables" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                需求訪談通知郵件範本：
            </td>
            <td>
                <telerik:RadComboBox ID="cbxQuestionNotify" runat="server" AppendDataBoundItems="True"
                    DataSourceID="sdsCbx" DataTextField="sName" DataValueField="iAutoKey">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="未設定" Value="0" />
                    </Items>
                </telerik:RadComboBox>
                <telerik:RadButton ID="btnQuestionSave" runat="server" OnClick="btnQuestionSave_Click"
                    Text="存檔">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td>
                需求訪談稽催郵件範本：
            </td>
            <td>
                <telerik:RadComboBox ID="cbxQuestionWakeNotify" runat="server" AppendDataBoundItems="True"
                    DataSourceID="sdsCbx" DataTextField="sName" DataValueField="iAutoKey">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Owner="cbxQuestionWakeNotify" Text="未設定"
                            Value="0" />
                    </Items>
                </telerik:RadComboBox>
                <telerik:RadButton ID="btnQuestionWakeSave" runat="server" OnClick="btnQuestionWakeSave_Click"
                    Text="存檔">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
        <td>
            學員心得被講師退件通知範本：
        </td>
        <td>
            <telerik:RadComboBox ID="cbxClassReportRejection" runat="server" 
                Culture="zh-TW" DataSourceID="sdsGv" DataTextField="sName" 
                DataValueField="iAutoKey">
            </telerik:RadComboBox>
            <telerik:RadButton ID="btnClassReportRejection" runat="server" Text="存檔" 
                onclick="btnClassReportRejection_Click">
            </telerik:RadButton>
        </td>
        </tr>        
    </table>
    <asp:Label runat="server" ID="lblAutoKey" Visible="False"></asp:Label>
    <asp:Label ID="lblMode" runat="server" Visible="False"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <asp:SqlDataSource ID="sdsCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select * from trMailTemplate"></asp:SqlDataSource>
    <br />
    <br />
    <asp:Panel ID="pnView" runat="server">
        <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" DataSourceID="sdsGv" GridLines="None"
            OnItemCommand="gv_ItemCommand" AllowPaging="True" Culture="zh-TW" Skin="Vista">
            <MasterTableView AllowAutomaticDeletes="True" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                DataSourceID="sdsGv">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                        HeaderText="iAutoKey" SortExpression="iAutoKey" UniqueName="iAutoKey" 
                        DataType="System.Int32" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                        HeaderText="sName" SortExpression="sName" UniqueName="sName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sMailSubject" FilterControlAltText="Filter sMailSubject column"
                        HeaderText="sMailSubject" SortExpression="sMailSubject" 
                        UniqueName="sMailSubject">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sMailContent" FilterControlAltText="Filter sMailContent column"
                        HeaderText="sMailContent" SortExpression="sMailContent" 
                        UniqueName="sMailContent">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dKeyMan" FilterControlAltText="Filter dKeyMan column"
                        HeaderText="dKeyMan" SortExpression="dKeyMan" UniqueName="dKeyMan">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
                        FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
                        SortExpression="dKeyDate" UniqueName="dKeyDate">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            DeleteCommand="delete  [trMailTemplate] where iAutoKey=@iAutoKey" SelectCommand="SELECT * FROM [trMailTemplate]">
            <DeleteParameters>
                <asp:Parameter Name="iAutoKey" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="pnEdit" runat="server">
        範本名稱<telerik:RadTextBox ID="tbName" runat="server" Enabled="False">
        </telerik:RadTextBox>
        <br />
        郵件標題<telerik:RadTextBox ID="tbSubject" runat="server" Width="400px" Enabled="False">
        </telerik:RadTextBox>
        <br />
        郵件內容<br />
         
        <telerik:RadEditor ID="edt" Runat="server" EditModes="Design, Preview">
        </telerik:RadEditor>
        <uc1:MailVariables ID="MailVariables1" runat="server" />
        <br />
    </asp:Panel>
    <br />
</asp:Content>
