<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="QSet.aspx.cs" Inherits="eTraining_Questionary_QSet" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server"
        DecoratedControls="All" Skin="Vista" />
      <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server"
        Skin="Default">
    </telerik:RadAjaxLoadingPanel>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%"
         width="100%" HorizontalAlign="NotSet"
        LoadingPanelID="RadAjaxLoadingPanel1">
     <asp:Panel ID="pnl1" runat="server">
         類別：<telerik:RadComboBox ID="cbbTplCat" Runat="server" AutoPostBack="True"
             DataTextField="Name" DataValueField="Id"
             onselectedindexchanged="cbbTplCat_SelectedIndexChanged">
         </telerik:RadComboBox>
         <telerik:RadButton ID="btnSave" runat="server"
             Text="儲存" onclick="btnSave_Click">
         </telerik:RadButton>
     </asp:Panel>

    <br />
          <telerik:RadGrid ID="gv" runat="server" AllowFilteringByColumn="True"
              AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW"
              GridLines="None" onitemdatabound="gv_ItemDataBound"
              OnNeedDataSource="gv_NeedDataSource" AllowMultiRowSelection="True">
              <ClientSettings>
                  <Selecting AllowRowSelect="True" UseClientSelectColumnOnly="True" />
                  <Scrolling UseStaticHeaders="True" />
              </ClientSettings>
              <MasterTableView DataKeyNames="Id">
                  <CommandItemSettings ExportToPdfText="Export to PDF" />
                  <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                      Visible="True">
                      <HeaderStyle Width="20px" />
                  </RowIndicatorColumn>
                  <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                      Visible="True">
                      <HeaderStyle Width="20px" />
                  </ExpandCollapseColumn>
                  <Columns>
                      <telerik:GridClientSelectColumn FilterControlAltText="Filter column column"
                          UniqueName="column">
                      </telerik:GridClientSelectColumn>
                      <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column"
                          HeaderText="Id" UniqueName="Id" Visible="False">
                      </telerik:GridBoundColumn>
                      <telerik:GridTemplateColumn AllowFiltering="False" DataField="IsRequired"
                          FilterControlAltText="Filter tplIsRequired column" HeaderText="必填"
                          ShowFilterIcon="False" ShowSortIcon="False" UniqueName="tplIsRequired"
                          Visible="False">
                          <ItemTemplate>
                              <asp:CheckBox ID="cbIsRequired" runat="server"
                                  Checked='<%# Bind("IsRequired") %>' />
                          </ItemTemplate>
                      </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn DataField="Sequence"
                          FilterControlAltText="Filter tplSequence column" HeaderText="順序"
                          UniqueName="tplSequence">
                          <ItemTemplate>
                              <telerik:RadNumericTextBox ID="ntbSequence" Runat="server" Width="30px">
                                  <NumberFormat AllowRounding="False" DecimalDigits="0" ZeroPattern="n" />
                              </telerik:RadNumericTextBox>
                          </ItemTemplate>
                      </telerik:GridTemplateColumn>
                      <telerik:GridBoundColumn DataField="QuestionText"
                          FilterControlAltText="Filter QuestionText column" HeaderText="問題"
                          UniqueName="QuestionText">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="TypeCode"
                          FilterControlAltText="Filter TypeCode column" HeaderText="TypeCode"
                          UniqueName="TypeCode" Visible="False">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="TypeName"
                          FilterControlAltText="Filter TypeName column" HeaderText="題型"
                          UniqueName="TypeName" FilterControlWidth="40px">
                          <ItemStyle Width="40px" />
                      </telerik:GridBoundColumn>
                      <telerik:GridCheckBoxColumn DataField="McqDisplayHorizontal"
                          FilterControlAltText="Filter McqDisplayHorizontal column" HeaderText="選擇題水平展開"
                          UniqueName="McqDisplayHorizontal">
                      </telerik:GridCheckBoxColumn>
                      <telerik:GridCheckBoxColumn DataField="IsValueInt"
                          FilterControlAltText="Filter IsValueInt column" HeaderText="選擇題採用數字值"
                          UniqueName="IsValueInt">
                      </telerik:GridCheckBoxColumn>
                      <telerik:GridTemplateColumn FilterControlAltText="Filter tpl1 column"
                          HeaderText="選項" UniqueName="tpl1">
                          <ItemTemplate>
                              <asp:Table ID="tbl" runat="server" BorderColor="Silver" BorderStyle="Groove"
                                  BorderWidth="1px" CaptionAlign="Top" GridLines="Both">
                              </asp:Table>
                          </ItemTemplate>
                      </telerik:GridTemplateColumn>
                      <telerik:GridBoundColumn DataField="McqId" EmptyDataText=""
                          FilterControlAltText="Filter McqId column" UniqueName="McqId" Visible="False">
                      </telerik:GridBoundColumn>
                      <telerik:GridCheckBoxColumn DataField="IsContain"
                          FilterControlAltText="Filter IsContain column" UniqueName="IsContain"
                          Visible="False">
                      </telerik:GridCheckBoxColumn>
                      <telerik:GridBoundColumn DataField="Sequence"
                          FilterControlAltText="Filter Sequence column" HeaderText="Sequence"
                          UniqueName="Sequence" Visible="False">
                      </telerik:GridBoundColumn>
                  </Columns>
                  <EditFormSettings>
                      <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                      </EditColumn>
                  </EditFormSettings>
              </MasterTableView>
              <FilterMenu EnableImageSprites="False">
              </FilterMenu>
          </telerik:RadGrid>
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
     </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">

    <style type="text/css">
.RadGrid_Default{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid_Default{border:1px solid #828282;background:#fff;color:#333}.RadGrid_Default .rgMasterTable{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgFilterRow{background:#eee}.RadGrid_Default .rgFilterBox{border-color:#8e8e8e #c9c9c9 #c9c9c9 #8e8e8e;font-family:"segoe ui",arial,sans-serif;color:#333}.RadGrid .rgFilterBox{border-width:1px;border-style:solid;margin:0;height:15px;padding:2px 1px 3px;font-size:12px;vertical-align:middle}.RadGrid_Default .rgFilter{background-position:0 -300px}.RadGrid_Default .rgFilter{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgFilter{width:22px;height:22px;margin:0 0 0 2px}.RadGrid .rgFilter{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}
        </style>
</asp:Content>