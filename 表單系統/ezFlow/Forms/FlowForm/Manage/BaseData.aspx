<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT0990113.master" AutoEventWireup="true" CodeFile="BaseData.aspx.cs" Inherits="Manage_BaseData" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        �u���G<asp:TextBox ID="txtNobr" runat="server" CssClass="txtCode"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="�d��" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:FormView ID="fvBase" runat="server" DataSourceID="sdsBase" 
                            onitemupdated="fvBase_ItemUpdated" onitemupdating="fvBase_ItemUpdating">
                            <EditItemTemplate>
                                �m�W�G<asp:TextBox ID="NAME_CTextBox" runat="server" CssClass="txtName" 
                                    Text='<%# Bind("name") %>' />
                                <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="���" />
                                <asp:ConfirmButtonExtender ID="btnUpdate_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="�z�T�w�n���ܡH" Enabled="True" TargetControlID="btnUpdate">
                                </asp:ConfirmButtonExtender>
                                <br />
                                ���ȥi��J5�Ӥ���r<br />
                                <asp:Label ID="lblNobr" runat="server" Text='<%# Bind("id") %>' 
                                    Visible="False"></asp:Label>
                            </EditItemTemplate>
                            <EmptyDataTemplate>
                                �z�|���d�ߩҭn��諸�u���C
                            </EmptyDataTemplate>
                        </asp:FormView>
                        <asp:SqlDataSource ID="sdsBase" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Flow %>" 
                            SelectCommand="SELECT * FROM [Emp] where id = @id" 
                            UpdateCommand="UPDATE [Emp] SET  [name] = @name WHERE [id] = @id">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtNobr" Name="id" PropertyName="Text" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="name" Type="String" />
                                <asp:Parameter Name="id" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

