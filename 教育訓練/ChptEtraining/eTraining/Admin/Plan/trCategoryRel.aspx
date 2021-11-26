<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="trCategoryRel.aspx.cs" Inherits="eTraining_Admin_Plan_trCategoryRel" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        類別關聯設定</h2>
    <div>
        <div style="float: left; width: 25%; background-color: #CDE5FF" class="funcblock">
            <br />
            <telerik:RadButton ID="btnDel" runat="server" Text="刪除類別關聯" OnClick="btnDel_Click">
            </telerik:RadButton>
            <telerik:RadButton ID="btnExpand" runat="server" Text="展開" GroupName="expand" 
                onclick="btnExpand_Click">
            </telerik:RadButton>
            <telerik:RadTreeView ID="tvCatCou" runat="server" Skin="Office2007">
            </telerik:RadTreeView>
            <br />
        </div>
        <div style="float: right; width: 74%">
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" DataSourceID="sdsGv" GridLines="None"
                Skin="Windows7" Width="90%" AllowFilteringByColumn="True" AllowPaging="True"
                AllowSorting="True" AllowMultiRowSelection="True" AutoGenerateColumns="False">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Selecting AllowRowSelect="True"></Selecting>
                </ClientSettings>
                <MasterTableView DataSourceID="sdsGv" DataKeyNames="sCode">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                            HeaderText="父節點" SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                            HeaderText="類別代碼" SortExpression="sCode" UniqueName="sCode">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName1" FilterControlAltText="Filter sName1 column"
                            HeaderText="類別名稱" SortExpression="sName1" UniqueName="sName1">
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
                SelectCommand="SELECT b.sName,a.* FROM [trCategory] a left join [trCategory] b on a.sParentCode = b.sCode where a.sCode &lt;&gt;'ROOT'">
            </asp:SqlDataSource>
            <br />
            <telerik:RadButton ID="btnAddCourse" runat="server" Text="加入類別關聯" OnClick="btnAddCourse_Click">
            </telerik:RadButton>
            <telerik:RadButton ID="btnAddCatRoot" runat="server" OnClick="btnAddCatRoot_Click"
                Text="加入根節點關聯">
            </telerik:RadButton>
        </div>
    </div>
    <br />
</asp:Content>
