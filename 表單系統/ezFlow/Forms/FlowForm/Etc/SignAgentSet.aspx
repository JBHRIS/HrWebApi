<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT20140325.master" AutoEventWireup="true"
    CodeFile="SignAgentSet.aspx.cs" Inherits="Etc_SignAgentSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="rwMT" runat="server" Title="" Height="500px" Width="700px"
                Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <asp:Panel ID="plContent" runat="server">
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                被代理人
                            </td>
                            <td colspan="5">
                                <telerik:RadComboBox ID="txtNobr" runat="server" AllowCustomText="True" AutoPostBack="True"
                                    Culture="zh-TW" EnableVirtualScrolling="True" Filter="Contains" ItemsPerRequest="10"
                                    LoadingMessage="載入中…" OnSelectedIndexChanged="txtNobr_SelectedIndexChanged">
                                </telerik:RadComboBox>
                                <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                角色
                            </td>
                            <td colspan="5">
                                <telerik:RadComboBox ID="txtRole" runat="server" AutoPostBack="True" Culture="zh-TW"
                                    EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…" OnSelectedIndexChanged="txtRole_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                代理人1
                            </td>
                            <td>
                                <telerik:RadComboBox ID="txtAgent1" runat="server" AllowCustomText="True" Culture="zh-TW"
                                    EnableVirtualScrolling="True" Filter="Contains" ItemsPerRequest="10" LoadingMessage="載入中…">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                代理人2
                            </td>
                            <td>
                                <telerik:RadComboBox ID="txtAgent2" runat="server" AllowCustomText="True" Culture="zh-TW"
                                    EnableVirtualScrolling="True" Filter="Contains" ItemsPerRequest="10" LoadingMessage="載入中…">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                代理人3
                            </td>
                            <td>
                                <telerik:RadComboBox ID="txtAgent3" runat="server" AllowCustomText="True" Culture="zh-TW"
                                    EnableVirtualScrolling="True" Filter="Contains" ItemsPerRequest="10" LoadingMessage="載入中…">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                代理日期
                            </td>
                            <td colspan="5">
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadDatePicker ID="txtDateB" runat="server" Width="100px">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" DisplayText="" LabelWidth="40%"
                                                    type="text" value="">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            到
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="txtDateE" runat="server" Width="100px">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" DisplayText="" LabelWidth="40%"
                                                    type="text" value="">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click">
                                </telerik:RadButton>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    目前代理設定
                </td>
            </tr>
            <tr>
                <td>
                    代理日期<asp:Label ID="lblDateBE" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="1px">
                        <tr>
                            <td>
                                代理人1
                            </td>
                            <td>
                                <asp:Label ID="lblAgent1" runat="server"></asp:Label>
                            </td>
                            <td>
                                代理人2
                            </td>
                            <td>
                                <asp:Label ID="lblAgent2" runat="server"></asp:Label>
                            </td>
                            <td>
                                代理人3
                            </td>
                            <td>
                                <asp:Label ID="lblAgent3" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
