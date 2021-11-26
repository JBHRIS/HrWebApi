<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT0990113.master" AutoEventWireup="true"
    CodeFile="Agent.aspx.cs" Inherits="Manage_Agent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblTitle" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDate" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDept" runat="server" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <table >
                            <tr>
                                <th>
                                    工號或姓名
                                </th>
                                <th>
                                    信箱
                                </th>
                                <td rowspan="2">
                                    <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                                    <telerik:RadComboBox ID="cbName" Runat="server" Culture="zh-TW" 
                                        DataSourceID="odsName" DataTextField="sName" DataValueField="sNobr" 
                                        AllowCustomText="True" AutoPostBack="True" 
                                        EnableVirtualScrolling="True" ItemsPerRequest="10" 
                                        ondatabound="cbName_DataBound" 
                                        onselectedindexchanged="cbName_SelectedIndexChanged" 
                                        ontextchanged="cbName_TextChanged" Filter="Contains" LoadingMessage="載入中…">
                                    </telerik:RadComboBox>
                                    <br />
                                    ※可輸入工號或姓名
                                    <asp:ObjectDataSource ID="odsName" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="EmpBaseByNobrDeptmAll" TypeName="JBHR.Dll.Bas">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="0" Name="sNobr" Type="String" />
                                            <asp:Parameter DefaultValue="I" Name="sDI" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMail" runat="server" CssClass="txtDescription" 
                                        Width="200px"></asp:TextBox>
                                    <br />
                                    ※空白時儲存，會主動取得預設的信箱
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" AllowSorting="True" DataKeyNames="iAutoKey"
                            DataSourceID="ldsGV">
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" HeaderText="通知對象" />
                                <asp:BoundField DataField="sAgentNobr" HeaderText="工號" 
                                    SortExpression="sAgentNobr" />
                                <asp:BoundField DataField="sAgentName" HeaderText="姓名" 
                                    SortExpression="sAgentName" />
                                <asp:BoundField DataField="sAgentMail" HeaderText="信箱" 
                                    SortExpression="sAgentMail" />
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                目前無新增任何資料</EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinqDataSource ID="ldsGV" runat="server" ContextTypeName="dcFormDataContext"
                            EnableDelete="True" TableName="wfAppAgent" EntityTypeName="" 
                            Where="sNobr == @sNobr">
                            <WhereParameters>
                                <asp:ControlParameter ControlID="lblNobrAppM" Name="sNobr" PropertyName="Text" 
                                    Type="String" />
                            </WhereParameters>
                        </asp:LinqDataSource>
                    </td>
                </tr>
            </table>
            <br />
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
