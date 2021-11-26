<%@ Page Title="E-Mail更改" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="EmailChange.aspx.cs" Inherits="eTraining_System_EmailChange" %>

<%@ Register src="../../UC/UserQuickSearch.ascx" tagname="UserQuickSearch" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        E-Mail更改
    </h2>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Web20"
        IsSticky="True">
    </telerik:RadAjaxLoadingPanel>
        <telerik:RadDatePicker ID="dp" Runat="server">
    </telerik:RadDatePicker>
    <br />
    <telerik:RadButton ID="btnSelectAllEmp" runat="server" 
        onclick="btnSelectAllEmp_Click" Text="匯出該時間員工資料">
    </telerik:RadButton>
    
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <div style="background-color: #CDE5FF; float: left; width: 24%" class="funcblock">
                        
            <uc1:UserQuickSearch ID="UserQuickSearch1" runat="server" />
            <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
            <br />
            <telerik:RadTreeView ID="tvDept" runat="server" OnNodeClick="tvDept_NodeClick">
            </telerik:RadTreeView>
            <br />
        </div>
        <div style="float: right; width: 75%">
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGV"
                GridLines="None" Skin="Outlook" Width="100%" 
                onupdatecommand="gv_UpdateCommand" AutoGenerateColumns="False" 
                AllowPaging="True" PageSize="20">
                <MasterTableView DataSourceID="sdsGV" DataKeyNames="NOBR">
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
                        <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                            HeaderText="工號" ReadOnly="True" UniqueName="NOBR">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" ReadOnly="True" SortExpression="NAME_C" UniqueName="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EMAIL" FilterControlAltText="Filter EMAIL column"
                            HeaderText="EMAIL" SortExpression="EMAIL" UniqueName="EMAIL">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TEL1" FilterControlAltText="Filter TEL1 column"
                            HeaderText="電話1" UniqueName="TEL1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TEL2" FilterControlAltText="Filter TEL2 column"
                            HeaderText="電話2" UniqueName="TEL2">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="GSM" FilterControlAltText="Filter GSM column"
                            HeaderText="手機" UniqueName="GSM">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BIRDT" DataFormatString="{0:d}" FilterControlAltText="Filter BIRDT column"
                            HeaderText="出生日期" ReadOnly="True" UniqueName="BIRDT">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDNO" FilterControlAltText="Filter IDNO column"
                            HeaderText="身份證" ReadOnly="True" UniqueName="IDNO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="INDT" DataFormatString="{0:d}" FilterControlAltText="Filter INDT column"
                            HeaderText="報到日" ReadOnly="True" UniqueName="INDT">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="Mang" 
                            FilterControlAltText="Filter Mang column" HeaderText="主管職" ReadOnly="True" 
                            UniqueName="Mang">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" 
                            FilterControlAltText="Filter column column" UniqueName="Edit">
                        </telerik:GridButtonColumn>
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
            <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:JBHRConnectionString %>"
                SelectCommand="select a.NAME_C,a.EMAIL,a.NOBR,a.TEL1,a.TEL2,a.GSM,a.BIRDT,a.IDNO,tts.INDT,tts.mang from BASE a
join BASETTS tts on a.NOBR=tts.NOBR
where tts.TTSCODE in ('1','4','6')
and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and tts.DEPT=@dept" ProviderName="<%$ ConnectionStrings:JBHRConnectionString.ProviderName %>" 
                
                
                InsertCommand="update BASE set EMAIL =@EMAIL,TEL1=@TEL1,TEL2=@TEL2,GSM=@GSM,NAME_C=@NAME_C where NOBR=@NOBR">
                <InsertParameters>
                    <asp:Parameter Name="EMAIL" />
                    <asp:Parameter Name="TEL1" />
                    <asp:Parameter Name="TEL2" />
                    <asp:Parameter Name="GSM" />
                    <asp:Parameter Name="NAME_C" />
                    <asp:Parameter Name="NOBR" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="tvDept" Name="dept" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsQuickSearch" runat="server" 
                ConnectionString="<%$ ConnectionStrings:JBHRConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:JBHRConnectionString.ProviderName %>" SelectCommand="select a.NAME_C,a.EMAIL,a.NOBR,a.TEL1,a.TEL2,a.GSM,a.BIRDT,a.IDNO,tts.INDT from BASE a
join BASETTS tts on a.NOBR=tts.NOBR
where tts.TTSCODE in ('1','4','6')
and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and (a.nobr = @nobr or a.name_c like '%'+@nobr+'%')" 
                UpdateCommand="update BASE set EMAIL =@EMAIL,TEL1=@TEL1,TEL2=@TEL2,GSM=@GSM where NOBR=@NOBR">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblNobr" DefaultValue=" " Name="nobr" 
                        PropertyName="Text" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="EMAIL" />
                    <asp:Parameter Name="TEL1" />
                    <asp:Parameter Name="TEL2" />
                    <asp:Parameter Name="GSM" />
                    <asp:Parameter Name="NOBR" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
