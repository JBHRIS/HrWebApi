<%@ Page Title="E-Mail更改" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="mtCode.aspx.cs" Inherits="eTraining_System_mtCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        系統值設定</h2>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Web20"
        IsSticky="True">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <div style="width: 100%">
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGV"
                GridLines="None" Skin="Outlook" Width="100%" 
                onupdatecommand="gv_UpdateCommand" AutoGenerateColumns="False" 
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" 
                AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" 
                AutoGenerateEditColumn="True">
                <MasterTableView DataSourceID="sdsGV" DataKeyNames="iAutoKey">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <%--<telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                    </telerik:GridEditCommandColumn>--%>
                        <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                            HeaderText="iAutoKey" ReadOnly="True" UniqueName="iAutoKey" 
                            DataType="System.Int32" SortExpression="iAutoKey" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sCategory" FilterControlAltText="Filter sCategory column"
                            HeaderText="sCategory" SortExpression="sCategory" UniqueName="sCategory">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                            HeaderText="sCode" SortExpression="sCode" UniqueName="sCode">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                            HeaderText="sName" UniqueName="sName" SortExpression="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sContent" 
                            FilterControlAltText="Filter sContent column" HeaderText="sContent" 
                            SortExpression="sContent" UniqueName="sContent">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="s1" FilterControlAltText="Filter s1 column" 
                            HeaderText="s1" SortExpression="s1" UniqueName="s1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="s2" FilterControlAltText="Filter s2 column" 
                            HeaderText="s2" SortExpression="s2" UniqueName="s2">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="s3" FilterControlAltText="Filter s3 column" 
                            HeaderText="s3" SortExpression="s3" UniqueName="s3">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="i1" DataType="System.Int32" 
                            FilterControlAltText="Filter i1 column" HeaderText="i1" SortExpression="i1" 
                            UniqueName="i1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="i2" DataType="System.Int32" 
                            FilterControlAltText="Filter i2 column" HeaderText="i2" SortExpression="i2" 
                            UniqueName="i2">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="i3" DataType="System.Int32" 
                            FilterControlAltText="Filter i3 column" HeaderText="i3" SortExpression="i3" 
                            UniqueName="i3">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="d1" DataType="System.DateTime" 
                            FilterControlAltText="Filter d1 column" HeaderText="d1" SortExpression="d1" 
                            UniqueName="d1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="d2" DataType="System.DateTime" 
                            FilterControlAltText="Filter d2 column" HeaderText="d2" SortExpression="d2" 
                            UniqueName="d2">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="d3" DataType="System.DateTime" 
                            FilterControlAltText="Filter d3 column" HeaderText="d3" SortExpression="d3" 
                            UniqueName="d3">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="b1" DataType="System.Boolean" 
                            FilterControlAltText="Filter b1 column" HeaderText="b1" SortExpression="b1" 
                            UniqueName="b1">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridCheckBoxColumn DataField="b2" DataType="System.Boolean" 
                            FilterControlAltText="Filter b2 column" HeaderText="b2" SortExpression="b2" 
                            UniqueName="b2">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridCheckBoxColumn DataField="b3" DataType="System.Boolean" 
                            FilterControlAltText="Filter b3 column" HeaderText="b3" SortExpression="b3" 
                            UniqueName="b3">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="iOrder" FilterControlAltText="Filter iOrder column"
                            HeaderText="iOrder" UniqueName="iOrder" DataType="System.Int32" 
                            SortExpression="iOrder">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bDisplay" DataType="System.Boolean" 
                            FilterControlAltText="Filter bDisplay column" HeaderText="bDisplay" 
                            SortExpression="bDisplay" UniqueName="bDisplay">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridCheckBoxColumn DataField="bSystem" DataType="System.Boolean" 
                            FilterControlAltText="Filter bSystem column" HeaderText="bSystem" 
                            SortExpression="bSystem" UniqueName="bSystem">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                            HeaderText="sKeyMan" UniqueName="sKeyMan" SortExpression="sKeyMan">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyDate" FilterControlAltText="Filter dKeyDate column"
                            HeaderText="dKeyDate" UniqueName="dKeyDate" DataType="System.DateTime" 
                            SortExpression="dKeyDate">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn ButtonType="PushButton" FilterControlAltText="Filter EditCommandColumn column"
                            UpdateText="更新" CancelText="取消" >
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Outlook">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </HeaderContextMenu>
            </telerik:RadGrid>
            <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT * FROM [mtCode]" ProviderName="<%$ ConnectionStrings:JBHRConnectionString.ProviderName %>" 
                
                InsertCommand="INSERT INTO [mtCode] ([sCategory], [sCode], [sName], [sContent], [s1], [s2], [s3], [i1], [i2], [i3], [d1], [d2], [d3], [b1], [b2], [b3], [iOrder], [bDisplay], [bSystem], [sKeyMan], [dKeyDate]) VALUES (@sCategory, @sCode, @sName, @sContent, @s1, @s2, @s3, @i1, @i2, @i3, @d1, @d2, @d3, @b1, @b2, @b3, @iOrder, @bDisplay, @bSystem, @sKeyMan, @dKeyDate)" 
                DeleteCommand="DELETE FROM [mtCode] WHERE [iAutoKey] = @original_iAutoKey" 
                OldValuesParameterFormatString="original_{0}" 
                UpdateCommand="UPDATE [mtCode] SET [sCategory] = @sCategory, [sCode] = @sCode, [sName] = @sName, [sContent] = @sContent, [s1] = @s1, [s2] = @s2, [s3] = @s3, [i1] = @i1, [i2] = @i2, [i3] = @i3, [d1] = @d1, [d2] = @d2, [d3] = @d3, [b1] = @b1, [b2] = @b2, [b3] = @b3, [iOrder] = @iOrder, [bDisplay] = @bDisplay, [bSystem] = @bSystem, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @original_iAutoKey">
                <DeleteParameters>
                    <asp:Parameter Name="original_iAutoKey" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="sCategory" Type="String" />
                    <asp:Parameter Name="sCode" Type="String" />
                    <asp:Parameter Name="sName" Type="String" />
                    <asp:Parameter Name="sContent" Type="String" />
                    <asp:Parameter Name="s1" Type="String" />
                    <asp:Parameter Name="s2" Type="String" />
                    <asp:Parameter Name="s3" Type="String" />
                    <asp:Parameter Name="i1" Type="Int32" />
                    <asp:Parameter Name="i2" Type="Int32" />
                    <asp:Parameter Name="i3" Type="Int32" />
                    <asp:Parameter Name="d1" Type="DateTime" />
                    <asp:Parameter Name="d2" Type="DateTime" />
                    <asp:Parameter Name="d3" Type="DateTime" />
                    <asp:Parameter Name="b1" Type="Boolean" />
                    <asp:Parameter Name="b2" Type="Boolean" />
                    <asp:Parameter Name="b3" Type="Boolean" />
                    <asp:Parameter Name="iOrder" Type="Int32" />
                    <asp:Parameter Name="bDisplay" Type="Boolean" />
                    <asp:Parameter Name="bSystem" Type="Boolean" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="sCategory" Type="String" />
                    <asp:Parameter Name="sCode" Type="String" />
                    <asp:Parameter Name="sName" Type="String" />
                    <asp:Parameter Name="sContent" Type="String" />
                    <asp:Parameter Name="s1" Type="String" />
                    <asp:Parameter Name="s2" Type="String" />
                    <asp:Parameter Name="s3" Type="String" />
                    <asp:Parameter Name="i1" Type="Int32" />
                    <asp:Parameter Name="i2" Type="Int32" />
                    <asp:Parameter Name="i3" Type="Int32" />
                    <asp:Parameter Name="d1" Type="DateTime" />
                    <asp:Parameter Name="d2" Type="DateTime" />
                    <asp:Parameter Name="d3" Type="DateTime" />
                    <asp:Parameter Name="b1" Type="Boolean" />
                    <asp:Parameter Name="b2" Type="Boolean" />
                    <asp:Parameter Name="b3" Type="Boolean" />
                    <asp:Parameter Name="iOrder" Type="Int32" />
                    <asp:Parameter Name="bDisplay" Type="Boolean" />
                    <asp:Parameter Name="bSystem" Type="Boolean" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    <asp:Parameter Name="original_iAutoKey" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
