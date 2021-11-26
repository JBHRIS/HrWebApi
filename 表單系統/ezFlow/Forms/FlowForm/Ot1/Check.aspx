<%@ Page Title="" Language="C#" MasterPageFile="~/mpCheck0990119.master" AutoEventWireup="true" CodeFile="Check.aspx.cs" Inherits="Ot1_Check" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:Label ID="lblTitle" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblNobrSign" runat="server" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <th>
                        被申請資料
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvAppS" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataKeyNames="iAutoKey" DataSourceID="sdsAppS" ForeColor="#333333" GridLines="None"
                            Width="100%" OnRowDataBound="gvAppS_RowDataBound">
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False" HeaderText="核准">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckSign" runat="server" Checked='<%# Bind("bSign") %>' ToolTip='<%# Eval("iAutoKey") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                            <asp:BoundField DataField="sOtcatName" HeaderText="給付方式" 
                                                SortExpression="sOtcatName" Visible="False" />
                                <asp:BoundField DataField="dDateB" HeaderText="加班日期" 
                                    SortExpression="dDateB" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="sTimeB" HeaderText="開始時間" 
                                    SortExpression="sTimeB" >
                                </asp:BoundField>
                                            <asp:BoundField DataField="sTimeE" HeaderText="結束時間" 
                                    SortExpression="sTimeE" >
                                </asp:BoundField>
                                            <asp:BoundField DataField="sRoteName" HeaderText="加班班別" 
                                                SortExpression="sRoteName" />
                                            <asp:BoundField DataField="iTotalHour" HeaderText="總時數" 
                                                SortExpression="iTotalHour" />
                                            <asp:BoundField DataField="sReserve1" HeaderText="本月加班時數" 
                                    SortExpression="sReserve1" />
                                <asp:BoundField DataField="sReserve2" HeaderText="本月補休時數" 
                                    SortExpression="sReserve2" />
                                            <asp:BoundField DataField="sOtrcdName" HeaderText="加班原因" 
                                                SortExpression="sOtrcdName" />
                                            <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                無申請者資料
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsAppS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Flow %>" SelectCommand="SELECT * FROM [wfAppOt1]
WHERE          (sProcessID = @sProcessID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    <span  style="color: #FF0000;  font-weight: bold;" >※若要駁回，請取消核准勾</span></td>
                </tr>
                <tr>
                    <th>
                        簽核者資料
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvSignM" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            DataSourceID="sdsSignM" Width="100%">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                <asp:BoundField DataField="sNote" HeaderText="意見" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="簽核日期" SortExpression="dKeyDate" />
                            </Columns>
                            <EmptyDataTemplate>
                                無簽核資料。
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsSignM" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT * FROM [wfFormSignM]
WHERE          (sProcessID = @sProcessID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <th>
                        主管意見
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNote" runat="server" Height="100px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="updatePanel2" runat="server">
        <ContentTemplate>
        <table class="TableFullBorder">
        <tr>
        <td>            <asp:Button ID="btnSubmit" runat="server" Text="送出傳簽"
                OnClick="btnSubmit_Click" />
            <asp:ConfirmButtonExtender ID="btnSubmit_ConfirmButtonExtender" runat="server" 
                ConfirmText="您確定要送出傳簽嗎？" Enabled="True" TargetControlID="btnSubmit">
            </asp:ConfirmButtonExtender>
        </td></tr></table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
