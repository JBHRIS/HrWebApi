<%@ Page Title="" Language="C#" MasterPageFile="~/mpCheck0990119.master" AutoEventWireup="true" CodeFile="Check.aspx.cs" Inherits="Return_Check" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblTitle" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblNobrSign" runat="server" Visible="False"></asp:Label>
            <table class="TableFullBorder" width="100%">
                <tr>
                    <td>
                        <asp:FormView ID="fvAppS" runat="server" DataKeyNames="iAutoKey" 
                            DataSourceID="sdsAppS" Width="100%">
                            <ItemTemplate>
                                <table align="center" class="TableFullBorder">
                                    <tr>
                                        <th align="center" colspan="2" nowrap="true" width="1%">
                                            被申請人資料 
                                        </th>
                                    </tr>
                                    <tr>
                                        <th align="right" nowrap="true" width="1%">
                                            返台目的 
                                        </th>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("sIntentionName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right" nowrap="true" width="1%">
                                            申請人姓名 / 工號 
                                        </th>
                                        <td>
                                            <asp:Label ID="lblNobr0" runat="server" Text='<%# Eval("sName") %>'></asp:Label>
                                            /<asp:Label ID="lblNobr" runat="server" Text='<%# Eval("sNobr") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right" nowrap="true" width="1%">
                                            申請人部門</th>
                                        <td>
                                            <asp:Label ID="lblDept" runat="server" Text='<%# Eval("sDeptName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right" nowrap="true" width="1%">
                                            申請人職稱</th>
                                        <td>
                                            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("sJobName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right" nowrap="true" width="1%">
                                            代理人姓名 / 工號 / 部門</th>
                                        <td>
                                            <asp:Label ID="lblJob1" runat="server" Text='<%# Eval("sName1") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right" nowrap="true" width="1%">
                                            今年已申請時數</th>
                                        <td>
                                            <asp:Label ID="lblJob0" runat="server" Text='<%# Eval("sReserve1") %>'></asp:Label>
                                            小時</td>
                                    </tr>
                                    <tr>
                                        <th align="right" nowrap="true" width="1%">
                                            預計回台停留期間 
                                        </th>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("dDateB", "{0:d}") %>'></asp:Label>
                                            &nbsp;至 
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("dDateE", "{0:d}") %>'></asp:Label>
                                            &nbsp;共<asp:Label ID="Label3" runat="server" Text='<%# Eval("iDay") %>'></asp:Label>
                                            天</td>
                                    </tr>
                                    <tr>
                                        <th align="right" nowrap="true" width="1%">
                                            預計回報到日期 
                                        </th>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("dDate", "{0:d}") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="center" colspan="2" nowrap="true" width="1%">
                                            原單位(海外廠)交待事項 
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="2" nowrap="true" width="1%">
                                            <asp:TextBox ID="txtOrginal" runat="server" Height="100px" TextMode="MultiLine"  ReadOnly="true"
                                                Width="100%" Text='<%# Eval("sOrginal") %>'
                                                ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="center" colspan="2" nowrap="true" width="1%">
                                            總公司交待事項 
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="2" nowrap="true" width="1%">
                                            <asp:TextBox ID="txtHeadquarters" runat="server" Height="100px"  ReadOnly="true"
                                                TextMode="MultiLine" Width="100%" Text='<%# Eval("sOrginal") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right" nowrap="true" width="1%">
                                            其它備註 
                                        </th>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("sNote") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:FormView>
                        <asp:SqlDataSource ID="sdsAppS" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT * FROM [wfAppReturn]
WHERE          (sProcessID = @sProcessID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
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
                    <td>
                        <asp:RadioButtonList ID="rblSign" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1">核准</asp:ListItem>
                            <asp:ListItem Value="0">駁回</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Button ID="btnSubmit" runat="server" Text="送出傳簽" OnClick="btnSubmit_Click" />
                        <asp:ConfirmButtonExtender ID="btnSubmit_ConfirmButtonExtender" runat="server" ConfirmText="您確定要送出傳簽嗎？"
                            Enabled="True" TargetControlID="btnSubmit">
                        </asp:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
