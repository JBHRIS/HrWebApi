<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT0990113.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Batch_List" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            color: #FF0000;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="重新整理" OnClick="btnReset_Click" />
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataSourceID="sdsList"
                            DataKeyNames="id" OnRowCommand="gvList_RowCommand" OnRowDataBound="gvList_RowDataBound"
                            OnDataBound="gvList_DataBound">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="FlowTree_name" HeaderText="表單名稱" SortExpression="FlowTree_name" />
                                <asp:BoundField DataField="iCount" HeaderText="待審表單數" ReadOnly="True" SortExpression="iCount" />
                                <asp:TemplateField HeaderText="實際資料數">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCount" runat="server" Text="0" ToolTip='<%# Eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="處理">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSelect" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Select"
                                            Text="批次處理" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsList" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT FlowTree.id, FlowTree.name AS FlowTree_name, COUNT(*) AS iCount FROM ProcessCheck INNER JOIN ProcessNode ON ProcessCheck.ProcessNode_auto = ProcessNode.auto INNER JOIN ProcessFlow ON ProcessNode.ProcessFlow_id = ProcessFlow.id INNER JOIN FlowTree ON ProcessFlow.FlowTree_id = FlowTree.id WHERE (ProcessNode.isFinish = 0) AND (ProcessFlow.isFinish = 0) AND (ProcessFlow.isError = 0) AND (ProcessFlow.isCancel = 0) AND (ProcessCheck.Emp_idDefault = @Emp_id) OR (ProcessNode.isFinish = 0) AND (ProcessFlow.isFinish = 0) AND (ProcessFlow.isError = 0) AND (ProcessFlow.isCancel = 0) AND (ProcessCheck.Emp_idAgent = @Emp_id) GROUP BY FlowTree.name, FlowTree.id ORDER BY FlowTree.id">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblNobr" Name="Emp_id" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <th>
                        待審核資料
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="傳送" OnClientClick="return confirm('您確定要傳送嗎？');" />
                        <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSelectAll" runat="server" CommandName="1" OnClick="btnSelectAll_Click"
                            Text="傳送全選" />
                        <asp:Button ID="btnSelectCancel" runat="server" CommandName="0" OnClick="btnSelectAll_Click"
                            Text="傳送全部取消選取" />
                        <span class="style1">※若要駁回，請取消核准勾</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:MultiView ID="mv" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:GridView ID="gvAbs" runat="server" AutoGenerateColumns="False" DataKeyNames="ProcessFlow_id,ProcessNode_auto,ProcessCheck_auto,iAutoKey"
                                    DataSourceID="sdsAbs" OnRowDataBound="gvData_RowDataBound" AllowPaging="True"
                                    Width="100%">
                                    <RowStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="編號" InsertVisible="False" SortExpression="iAutoKey"
                                            Visible="False">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("iAutoKey") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAutoKey" runat="server" Text='<%# Bind("iAutoKey") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="傳送">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ckSend" runat="server" AutoPostBack="True" OnCheckedChanged="ckSend_CheckedChanged"
                                                    ToolTip='<%# Eval("ProcessFlow_id") %>' ValidationGroup="gvAbs" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="核准" SortExpression="bSign">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ckSign" runat="server" Checked='<%# Bind("bSign") %>' ToolTip='<%# Eval("ProcessApParm_auto") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="流程序號" SortExpression="ProcessFlow_id">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProcessFlow_id") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProcessID" runat="server" Text='<%# Bind("ProcessFlow_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="adate" HeaderText="送件日期" SortExpression="adate" />
                                        <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                        <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                        <asp:BoundField DataField="sDeptName" HeaderText="簽核部門" SortExpression="sDeptName" />
                                        <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                        <asp:BoundField DataField="dDateB" HeaderText="開始日期" SortExpression="dDateB" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="sTimeB" HeaderText="時間" SortExpression="sTimeB" />
                                        <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="結束日期" SortExpression="dDateE" />
                                        <asp:BoundField DataField="sTimeE" HeaderText="時間" SortExpression="sTimeE" />
                                        <asp:BoundField DataField="sHname" HeaderText="假別" SortExpression="sHname" />
                                        <asp:BoundField DataField="iDay" HeaderText="天數" SortExpression="iDay" />
                                        <asp:BoundField DataField="iHour" HeaderText="時數" SortExpression="iHour" />
                                        <asp:BoundField DataField="sAgentName" HeaderText="代理人" SortExpression="sAgentName" />
                                        <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="sdsAbs" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                    SelectCommand="SELECT ProcessFlow.id AS ProcessFlow_id, ProcessNode.auto AS ProcessNode_auto, ProcessCheck.auto AS ProcessCheck_auto, ProcessFlow.FlowTree_id, ProcessNode.FlowNode_id, ProcessFlow.Role_id AS Role_idStart, ProcessFlow.Emp_id AS Emp_idStart, ProcessCheck.Role_idDefault, ProcessCheck.Emp_idDefault, ProcessCheck.Role_idAgent, ProcessCheck.Emp_idAgent, ProcessNode.adate, ProcessApParm.auto AS ProcessApParm_auto, ProcessApView.auto AS ProcessApView_auto, wfAppAbs.iAutoKey, wfAppAbs.sFormCode, wfAppAbs.sProcessID, wfAppAbs.idProcess, wfAppAbs.sNobr, wfAppAbs.sName, wfAppAbs.sDept, wfAppAbs.sDeptName, wfAppAbs.sJob, wfAppAbs.sJobName, wfAppAbs.sJobl, wfAppAbs.sJoblName, wfAppAbs.sEmpcd, wfAppAbs.sEmpcdName, wfAppAbs.sRole, wfAppAbs.sDI, wfAppAbs.sRote, wfAppAbs.dDateTimeB, wfAppAbs.dDateTimeE, wfAppAbs.dDateB, wfAppAbs.dDateE, wfAppAbs.sTimeB, wfAppAbs.sTimeE, wfAppAbs.sHcode, wfAppAbs.sHname, wfAppAbs.iDay, wfAppAbs.iHour, wfAppAbs.iTotalDay, wfAppAbs.iTotalHour, wfAppAbs.bExceptionHour, wfAppAbs.iExceptionHour, wfAppAbs.sReserve1, wfAppAbs.sReserve2, wfAppAbs.sReserve3, wfAppAbs.sReserve4, wfAppAbs.sSalYYMM, wfAppAbs.bSign, wfAppAbs.sState, wfAppAbs.sAgentNobr, wfAppAbs.sAgentName, wfAppAbs.sAgentNote, wfAppAbs.bAuth, wfAppAbs.sNote, wfAppAbs.dKeyDate FROM ProcessCheck INNER JOIN ProcessNode ON ProcessCheck.ProcessNode_auto = ProcessNode.auto INNER JOIN ProcessFlow ON ProcessNode.ProcessFlow_id = ProcessFlow.id INNER JOIN ProcessApParm ON ProcessFlow.id = ProcessApParm.ProcessFlow_id AND ProcessNode.auto = ProcessApParm.ProcessNode_auto AND ProcessCheck.auto = ProcessApParm.ProcessCheck_auto INNER JOIN ProcessApView ON ProcessFlow.id = ProcessApView.ProcessFlow_id INNER JOIN wfAppAbs ON ProcessFlow.id = wfAppAbs.idProcess WHERE (ProcessNode.isFinish = 0) AND (ProcessFlow.isFinish = 0) AND (ProcessFlow.isError = 0) AND (ProcessFlow.isCancel = 0) AND (ProcessCheck.Emp_idDefault = @Emp_id) AND (ProcessFlow.FlowTree_id = @FlowTree_id) AND (ProcessFlow.id &gt;= 0) AND (wfAppAbs.bSign = 1) OR (ProcessNode.isFinish = 0) AND (ProcessFlow.isFinish = 0) AND (ProcessFlow.isError = 0) AND (ProcessFlow.isCancel = 0) AND (ProcessFlow.FlowTree_id = @FlowTree_id) AND (ProcessFlow.id &gt;= 0) AND (ProcessCheck.Emp_idAgent = @Emp_id) AND (wfAppAbs.bSign = 1) ORDER BY ProcessNode.adate, ProcessNode.ProcessFlow_id">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="Emp_id" QueryStringField="idEmp_Start" />
                                        <asp:ControlParameter ControlID="gvList" Name="FlowTree_id" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:GridView ID="gvOt" runat="server" AutoGenerateColumns="False" DataKeyNames="ProcessFlow_id,ProcessNode_auto,ProcessCheck_auto,iAutoKey"
                                    DataSourceID="sdsOt" OnRowDataBound="gvData_RowDataBound" AllowPaging="True"
                                    Width="100%" EnableModelValidation="True">
                                    <RowStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="編號" InsertVisible="False" SortExpression="iAutoKey"
                                            Visible="False">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("iAutoKey") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAutoKey" runat="server" Text='<%# Bind("iAutoKey") %>' ToolTip='<%# Eval("sJobl") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="傳送">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ckSend" runat="server" AutoPostBack="True" OnCheckedChanged="ckSend_CheckedChanged"
                                                    ToolTip='<%# Eval("ProcessFlow_id") %>' ValidationGroup="gvOt" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="核准" SortExpression="bSign">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ckSign" runat="server" Checked='<%# Bind("bSign") %>' ToolTip='<%# Eval("ProcessApParm_auto") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="流程序號" SortExpression="ProcessFlow_id">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProcessFlow_id") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProcessID" runat="server" Text='<%# Bind("ProcessFlow_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="adate" HeaderText="送件日期" SortExpression="adate" />
                                        <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                        <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                        <asp:BoundField DataField="dDateB" HeaderText="加班日期" SortExpression="dDateB" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="sTimeB" HeaderText="開始時間" SortExpression="sTimeB" />
                                        <asp:BoundField DataField="sTimeE" HeaderText="結束時間" SortExpression="sTimeE" />
                                        <asp:BoundField DataField="iTotalHour" HeaderText="總時數" SortExpression="iTotalHour" />
                                        <asp:BoundField DataField="sReserve1" HeaderText="本月加班時數" 
                                            SortExpression="sReserve1" />
                                        <asp:BoundField DataField="sReserve2" HeaderText="本月補休時數" 
                                            SortExpression="sReserve2" />
                                        <asp:BoundField DataField="sRoteName" HeaderText="加班班別" SortExpression="sRoteName" />
                                        <asp:BoundField DataField="sOtcatName" HeaderText="給付方式" SortExpression="sOtcatName" />
                                        <asp:BoundField DataField="sOtrcdName" HeaderText="加班原因" SortExpression="sOtrcdName"
                                            Visible="False" />
                                        <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="sdsOt" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                    SelectCommand="SELECT ProcessFlow.id AS ProcessFlow_id, ProcessNode.auto AS ProcessNode_auto, ProcessCheck.auto AS ProcessCheck_auto, ProcessFlow.FlowTree_id, ProcessNode.FlowNode_id, ProcessFlow.Role_id AS Role_idStart, ProcessFlow.Emp_id AS Emp_idStart, ProcessCheck.Role_idDefault, ProcessCheck.Emp_idDefault, ProcessCheck.Role_idAgent, ProcessCheck.Emp_idAgent, ProcessNode.adate, ProcessApParm.auto AS ProcessApParm_auto, ProcessApView.auto AS ProcessApView_auto, wfAppOt.* FROM ProcessCheck INNER JOIN ProcessNode ON ProcessCheck.ProcessNode_auto = ProcessNode.auto INNER JOIN ProcessFlow ON ProcessNode.ProcessFlow_id = ProcessFlow.id INNER JOIN ProcessApParm ON ProcessFlow.id = ProcessApParm.ProcessFlow_id AND ProcessNode.auto = ProcessApParm.ProcessNode_auto AND ProcessCheck.auto = ProcessApParm.ProcessCheck_auto INNER JOIN ProcessApView ON ProcessFlow.id = ProcessApView.ProcessFlow_id INNER JOIN wfAppOt ON ProcessFlow.id = wfAppOt.idProcess WHERE (ProcessNode.isFinish = 0) AND (ProcessFlow.isFinish = 0) AND (ProcessFlow.isError = 0) AND (ProcessFlow.isCancel = 0) AND (ProcessCheck.Emp_idDefault = @Emp_id) AND (ProcessFlow.FlowTree_id = @FlowTree_id) AND (ProcessFlow.id &gt;= 0) AND (wfAppOt.bSign = 1) OR (ProcessNode.isFinish = 0) AND (ProcessFlow.isFinish = 0) AND (ProcessFlow.isError = 0) AND (ProcessFlow.isCancel = 0) AND (ProcessFlow.FlowTree_id = @FlowTree_id) AND (ProcessFlow.id &gt;= 0) AND (ProcessCheck.Emp_idAgent = @Emp_id) AND (wfAppOt.bSign = 1) ORDER BY ProcessNode.adate, ProcessNode.ProcessFlow_id">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="Emp_id" QueryStringField="idEmp_Start" />
                                        <asp:ControlParameter ControlID="gvList" Name="FlowTree_id" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
