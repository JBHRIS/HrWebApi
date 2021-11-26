<%@ Page Title="填寫課後資料" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ManagerWrite.aspx.cs" Inherits="eTraining_Manager_ManagerWrite" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        填寫課後心得</h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        width="100%" onajaxrequest="RadAjaxPanel1_AjaxRequest">    
    年度
     <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
//            function ShowEditForm(id, rowIndex) {
//                var grid = $find("<%= gv.ClientID %>");

//                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
//                grid.get_masterTableView().selectItem(rowControl, true);

//                window.radopen("EditFormcs.aspx?EmployeeID=" + id, "UserListDialog");
//                return false;
//            }
//            function ShowInsertForm() {
//                window.radopen("EditFormcs.aspx", "UserListDialog");
//                return false;
//            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
//            function RowDblClick(sender, eventArgs) {
//                window.radopen("EditFormcs.aspx?EmployeeID=" + eventArgs.getDataKeyValue("EmployeeID"), "UserListDialog");
//            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" 
        AutoPostBack="True" onselectedindexchanged="cbxYear_SelectedIndexChanged">
    </telerik:RadComboBox>
    <br />
   
        <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemCommand="gv_ItemCommand" 
            onneeddatasource="gv_NeedDataSource" 
            Skin="Vista" Width="90%">
            <MasterTableView AllowPaging="True" DataKeyNames="iAutoKey">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="categoryName" 
                        FilterControlAltText="Filter categoryName column" HeaderText="階層" 
                        SortExpression="categoryName" UniqueName="categoryName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="courseName" 
                        FilterControlAltText="Filter courseName column" HeaderText="課程名稱" 
                        SortExpression="courseName" UniqueName="courseName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dDateA" DataFormatString="{0:d}" 
                        DataType="System.DateTime" FilterControlAltText="Filter dDateA column" 
                        HeaderText="上課日期" SortExpression="dDateA" UniqueName="dDateA">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Nobr" 
                        FilterControlAltText="Filter Nobr column" HeaderText="工號" UniqueName="Nobr">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NameC" 
                        FilterControlAltText="Filter NameC column" HeaderText="姓名" UniqueName="NameC">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DeptName" 
                        FilterControlAltText="Filter DeptName column" HeaderText="部門" 
                        UniqueName="DeptName">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn CommandName="ScoreForReport" 
                        FilterControlAltText="Filter ScoreForReport column" HeaderText="心得評分" 
                        Text="心得評分" UniqueName="ScoreForReport">
                    </telerik:GridButtonColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
                <WebServiceSettings>
                    <ODataSettings InitialContainerName="">
                    </ODataSettings>
                </WebServiceSettings>
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                <WebServiceSettings>
                    <ODataSettings InitialContainerName="">
                    </ODataSettings>
                </WebServiceSettings>
            </HeaderContextMenu>
        </telerik:RadGrid>
        <telerik:RadWindow ID="win" runat="server" Height="550px" Modal="True" 
            VisibleStatusbar="False" Width="800px">
        </telerik:RadWindow>
    </telerik:RadAjaxPanel>
    <br />
    <br />
</asp:Content>
