<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserFormAssign.aspx.cs" Inherits="Flow_UserFormAssign" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script language="javascript" type="text/javascript">
            function refreshGrid() {
                var masterTable = $find("<%=gv.ClientID%>").get_masterTableView();
                masterTable.rebind();
            }

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including classic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadGrid ID="gv" runat="server" OnNeedDataSource="gv_NeedDataSource" AutoGenerateColumns="False"
        CellSpacing="0" Culture="zh-TW" GridLines="None"
        OnItemCommand="gv_ItemCommand" AllowMultiRowSelection="True" AllowPaging="True"
        PageSize="20" AllowSorting="True">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
        <MasterTableView DataKeyNames="ProcessID">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridClientSelectColumn FilterControlAltText="Filter cmdSelect column"
                    UniqueName="cmdSelect" meta:resourcekey="GridClientSelectColumnResource1">
                    <ItemStyle Width="10px" />
                </telerik:GridClientSelectColumn>
                <telerik:GridButtonColumn CommandName="Confirm" FilterControlAltText="Filter cmdConfirm column"
                    Text="Detail" UniqueName="cmdConfirm"
                    meta:resourcekey="GridButtonColumnResource1">
                    <ItemStyle Width="30px" />
                </telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="AgentName" FilterControlAltText="Filter AgentName column"
                    UniqueName="AgentName" Visible="False" HeaderText="代理人"
                    meta:resourcekey="GridBoundColumnResource1">
                    <ItemStyle Width="30px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AgentState" FilterControlAltText="Filter AgentState column"
                    HeaderText="狀態" UniqueName="AgentState" Visible="False"
                    meta:resourcekey="GridBoundColumnResource2">
                    <ItemStyle Width="30px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ApParmID" FilterControlAltText="Filter ApParamId column"
                    HeaderText="ApParmID" UniqueName="ApParmID" Visible="False"
                    meta:resourcekey="GridBoundColumnResource3">
                    <ItemStyle Width="30px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AppName" FilterControlAltText="Filter AppName column"
                    HeaderText="Applicant" UniqueName="AppName"
                    meta:resourcekey="GridBoundColumnResource4">
                    <ItemStyle Width="70px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AppDate" FilterControlAltText="Filter AppDate column"
                    HeaderText="Date of application" UniqueName="AppDate"
                    DataFormatString="{0:d}" meta:resourcekey="GridBoundColumnResource5">
                    <ItemStyle Width="20px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FlowProgress" FilterControlAltText="Filter FlowProgress column"
                    HeaderText="FlowProgress" UniqueName="FlowProgress" Visible="False"
                    meta:resourcekey="GridBoundColumnResource6">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FormName" FilterControlAltText="Filter FormName column"
                    HeaderText="流程名稱" UniqueName="FormName"
                    meta:resourcekey="GridBoundColumnResource7">
                    <ItemStyle Width="50px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ParmUrl" FilterControlAltText="Filter ParamUrl column"
                    HeaderText="ParmUrl" UniqueName="ParmUrl" Visible="False"
                    meta:resourcekey="GridBoundColumnResource8">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ProcessCheckAuto" FilterControlAltText="Filter ProcessCheckAuto column"
                    HeaderText="ProcessCheckAuto" UniqueName="ProcessCheckAuto"
                    Visible="False" meta:resourcekey="GridBoundColumnResource9">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ProcessNodeAuto" FilterControlAltText="Filter ProcessNodeAuto column"
                    HeaderText="ProcessNodeAuto" UniqueName="ProcessNodeAuto" Visible="False"
                    meta:resourcekey="GridBoundColumnResource10">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Info"
                    FilterControlAltText="Filter Info column" HeaderText="Info"
                    UniqueName="Info" meta:resourcekey="GridBoundColumnResource11">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ProcessID" FilterControlAltText="Filter ProcessId column"
                    HeaderText="Process ID" UniqueName="ProcessID"
                    meta:resourcekey="GridBoundColumnResource12">
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
    </telerik:RadGrid>
    <div style="float: left; width: 200px" id="test">
        <%--    <div style="float: right; width: 790px">--%>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Style="z-index: 7001"
            Left="300px" Top="300px" meta:resourcekey="RadWindowManager1Resource1"
            OnClientClose="refreshGrid" ReloadOnShow="True" ShowContentDuringLoad="False">
            <Windows>
                <telerik:RadWindow ID="win" runat="server" EnableShadow="True" Height="700px" Modal="True"
                    VisibleStatusbar="True" Width="1000px" Left="300px" Top="300px"
                    meta:resourcekey="winResource1" ReloadOnShow="True"
                    ShowContentDuringLoad="False">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        <telerik:RadButton ID="btnSign" runat="server" onclientclicking="ExcuteConfirm"
            Text="Commit" onclick="btnSign_Click" meta:resourcekey="btnSignResource1">
        </telerik:RadButton>
        <asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsgResource1"></asp:Label>
    </div>
    <%--    </div>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>