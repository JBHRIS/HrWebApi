<%@ Page Title="課程類別關聯設定" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="trCatCou.aspx.cs" Inherits="eTraining_Admin_Plan_trCatCou" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    </telerik:RadCodeBlock>
    <h2>
        課程類別關聯設定</h2>
    <div>
        <div style="float: left; width: 27%; background-color: #CDE5FF" class="funcblock">
            <table class="style1">
                <tr>
                    <td style="color: #33CC33">
                        一般課程</td>
                    <td style="color: #FF0000">
                        套裝課程</td>
                </tr>
            </table>
            <telerik:RadButton ID="btnDel" runat="server" Text="刪除課程關聯" 
                OnClick="btnDel_Click">
            </telerik:RadButton>
            <telerik:RadButton ID="btnExpand" runat="server" GroupName="expand" OnClick="btnExpand_Click"
                Text="展開">
            </telerik:RadButton>
            <telerik:RadTreeView ID="tvCatCou" runat="server" Style="margin-right: 0px" 
                Skin="Office2007" onprerender="tvCatCou_PreRender">
            </telerik:RadTreeView>
            <br />
        </div>
        <div style="float: right; width: 72%">
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" DataSourceID="sdsGv" GridLines="None"
                Skin="Windows7" Width="90%" AllowFilteringByColumn="True" AllowPaging="True"
                AllowSorting="True" AllowMultiRowSelection="True" 
                AutoGenerateColumns="False" Culture="zh-TW">
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
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter Select column" 
                            UniqueName="Select">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                            HeaderText="階層" SortExpression="sName" UniqueName="sName" 
                            FilterControlWidth="110px">
                            <HeaderStyle Width="110px" />
                            <ItemStyle Width="110px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                            HeaderText="課程代碼" SortExpression="sCode" UniqueName="sCode" 
                            FilterControlWidth="50px">
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName1" FilterControlAltText="Filter sName1 column"
                            HeaderText="課程名稱" SortExpression="sName1" UniqueName="sName1" 
                            FilterControlWidth="140px">
                            <HeaderStyle Width="140px" />
                            <ItemStyle Width="140px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trTrainingType_sCode" FilterControlAltText="Filter trTrainingType_sCode column"
                            HeaderText="trTrainingType_sCode" SortExpression="trTrainingType_sCode" 
                            UniqueName="trTrainingType_sCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iJobScore" DataType="System.Int32" 
                            FilterControlAltText="Filter iJobScore column" FilterControlWidth="30px" 
                            HeaderText="職能積分" SortExpression="iJobScore" UniqueName="iJobScore">
                            <HeaderStyle Width="30px" />
                            <ItemStyle Width="30px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Column1" DataType="System.Int32" 
                            FilterControlAltText="Filter Column1 column" FilterControlWidth="30px" 
                            HeaderText="授課時數" ReadOnly="True" SortExpression="Column1" UniqueName="Column1">
                            <HeaderStyle Width="30px" />
                            <ItemStyle Width="30px" />
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
                SelectCommand="select b.sName,c.sCode,c.sName,c.trTrainingType_sCode,c.iJobScore,c.iCourseTime/60 from  trCourse c
left join trCategoryCourse a on a.sCourseCode=c.sCode
left join trCategory b on a.sCateCode=b.sCode"></asp:SqlDataSource>
            <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
            <br />
            <telerik:RadButton ID="btnAddCourse" runat="server" Text="加入課程" OnClick="btnAddCourse_Click">
            </telerik:RadButton>
        </div>
    </div>
    <br />
</asp:Content>
