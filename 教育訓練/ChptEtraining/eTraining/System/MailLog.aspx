<%@ Page Title="E-Mail更改" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="MailLog.aspx.cs" Inherits="eTraining_System_MailLog" %>

<%@ Register src="../../UC/UserQuickSearch.ascx" tagname="UserQuickSearch" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        MailLog
    </h2>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Web20"
        IsSticky="True">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" 
        Skin="Sunset" DecoratedControls="All" />
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <div>
        
            <table style="width:100%;">
                <tr>
                    <td>
                        起<telerik:RadDatePicker ID="rdpB" Runat="server">
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        迄<telerik:RadDatePicker ID="rdpE" Runat="server">
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        <telerik:RadButton ID="btnSearch" runat="server" Text="搜尋">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        
        </div>
        <div style="width: 100%">
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW"
                GridLines="None" Width="100%" AllowFilteringByColumn="True" 
                AllowPaging="True" AllowSorting="True" 
                onneeddatasource="gv_NeedDataSource" AutoGenerateColumns="False" Skin="Sunset">
                <MasterTableView DataKeyNames="iAutoKey">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="iAutoKey" 
                            FilterControlAltText="Filter iAutoKey column" UniqueName="iAutoKey" 
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MailSubject" 
                            FilterControlAltText="Filter MailSubject column" HeaderText="郵件標題" 
                            UniqueName="MailSubject">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MailContent" 
                            FilterControlAltText="Filter MailContent column" HeaderText="郵件內容" 
                            UniqueName="MailContent">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MailAddressee" 
                            FilterControlAltText="Filter MailAddressee column" HeaderText="寄發email" 
                            UniqueName="MailAddressee">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ErrorMsg" 
                            FilterControlAltText="Filter ErrorMsg column" HeaderText="錯誤訊息" 
                            UniqueName="ErrorMsg">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyDate" 
                            FilterControlAltText="Filter dKeyDate column" HeaderText="發送日期" 
                            UniqueName="dKeyDate">
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
            <br />
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
