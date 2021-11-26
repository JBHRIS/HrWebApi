<%@ Page Title="" Language="C#" MasterPageFile="~/mpCheck0990119.master" AutoEventWireup="true"
    CodeFile="Check.aspx.cs" Inherits="Form_Check" %>

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
                        �Q�ӽи��
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvAppS" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataKeyNames="iAutoKey" DataSourceID="sdsAppS" ForeColor="#333333" GridLines="None"
                            Width="100%" OnRowDataBound="gvAppS_RowDataBound">
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False" HeaderText="�֭�">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckSign" runat="server" Checked='<%# Bind("bSign") %>' ToolTip='<%# Eval("iAutoKey") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="dDateIn" DataFormatString="{0:d}" HeaderText="��¾��" SortExpression="dDateIn" />
                                <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                <asp:BoundField DataField="sNameF" HeaderText="�ҩ����" SortExpression="sNameF" />
                                <asp:BoundField DataField="iPage" HeaderText="�ݨD(��)" SortExpression="iPage" />
                                <asp:BoundField DataField="dDateD" DataFormatString="{0:d}" HeaderText="�ݨD���" SortExpression="dDateD" />
                                <asp:BoundField DataField="sNote" HeaderText="�ӽЭ�]" SortExpression="sNote" />
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                �L�ӽЪ̸�ơC
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsAppS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Flow %>" SelectCommand="SELECT * FROM [wfAppForm]
WHERE          (sProcessID = @sProcessID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <th>
                        ñ�̸֪��
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvSignM" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            DataSourceID="sdsSignM" Width="100%">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                <asp:BoundField DataField="sNote" HeaderText="�N��" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="ñ�֤��" SortExpression="dKeyDate" />
                            </Columns>
                            <EmptyDataTemplate>
                                �Lñ�ָ�ơC
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
                        �D�޷N��
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
        <td>            <asp:Button ID="btnSubmit" runat="server" Text="�e�X��ñ"
                OnClick="btnSubmit_Click" />
            <asp:ConfirmButtonExtender ID="btnSubmit_ConfirmButtonExtender" runat="server" 
                ConfirmText="�z�T�w�n�e�X��ñ�ܡH" Enabled="True" TargetControlID="btnSubmit">
            </asp:ConfirmButtonExtender>
        </td></tr></table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
