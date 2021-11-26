<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="QCategory.aspx.cs" Inherits="eTraining_Questionary_QCategory" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
         width="100%">
     <asp:Panel ID="pnl1" runat="server">
         名稱：<telerik:RadTextBox ID="tbName" Runat="server" Width="200px">
         </telerik:RadTextBox>
         <telerik:RadButton ID="btnSave" runat="server" 
             Text="更新類別名稱" onclick="btnSave_Click">
         </telerik:RadButton>
         <telerik:RadButton ID="btnAdd" runat="server" onclick="btnAdd_Click" 
             Text="新增類別">
         </telerik:RadButton>
     </asp:Panel>
 
    <br />
    <br />
    <script type="text/javascript">
        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
            GetRadWindow().close();
        }

        function Rebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
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


        //Standard Window.confirm
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("您確定要儲存嗎？"));
        }

        //RadConfirm
        function RadConfirm(sender, args) {
            var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
                if (shouldSubmit) {
                    this.click();
                }
            });

            var text = "Are you sure you want to submit the page?";
            radconfirm(text, callBackFunction, 300, 100, null, "RadConfirm");
            args.set_cancel(true);
        }

    </script>

     
     <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" 
         CellSpacing="0" Culture="zh-TW" GridLines="None" onitemcommand="gv_ItemCommand" 
         onneeddatasource="gv_NeedDataSource" 
         onselectedindexchanged="gv_SelectedIndexChanged">
         <ClientSettings>
             <Selecting AllowRowSelect="True" />
         </ClientSettings>
<MasterTableView DataKeyNames="Code">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridButtonColumn CommandName="Select" 
            FilterControlAltText="Filter column column" Text="選擇" UniqueName="column">
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="Code" 
            FilterControlAltText="Filter Code column" HeaderText="代碼" UniqueName="Code" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Name" 
            FilterControlAltText="Filter Name column" HeaderText="名稱" UniqueName="Name">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn CommandName="Del" ConfirmText="確認是否刪除?" 
            FilterControlAltText="Filter CommandDel column" Text="刪除" 
            UniqueName="CommandDel">
        </telerik:GridButtonColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
     </telerik:RadGrid>
     </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">

</asp:Content>
