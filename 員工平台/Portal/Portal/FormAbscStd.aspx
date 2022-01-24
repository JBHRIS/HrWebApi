<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.Master" AutoEventWireup="true" CodeBehind="FormAbscStd.aspx.cs" Inherits="Portal.FormAbscStd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="ibox-content">
        <telerik:RadAjaxPanel ID="plInfo" runat="server">
            <telerik:RadListView ID="gvAppS" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnDataBound="gvAppS_DataBound" OnItemCommand="gvAppS_ItemCommand">
                <LayoutTemplate>
                    <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                        <tbody id="Container" runat="server">
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="keyin keyin-border">
                        <div class="row">
                            <div class="col-sm-1 m-t-xs">
                                <label class="p-xs">
                                    <telerik:RadCheckBox runat="server" Skin="Bootstrap" ID="isSelected" CommandArgument='<%# Eval("Guid") %>'></telerik:RadCheckBox>
                                </label>
                            </div>
                            <div class="col-sm-11 m-t-xs">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col col-xs-6">
                                                <span>開始日期：<%# Eval("DateTimeB","{0:yyyy/MM/dd}") %></span><%--<span>開始日期：<%# Eval("AbscDateB","{0:yyyy/MM/dd}") %></span>--%>
                                                <br>
                                                <span>開始時間：<%# Eval("DateTimeB","{0:HH:mm}") %></span><%--<span>開始時間：<%# Eval("AbscTimeB") %></span>--%>
                                            </div>

                                            <div class="col col-xs-6">
                                                <span>結束日期：<%# Eval("DateTimeE","{0:yyyy/MM/dd}") %></span><%--<span>結束日期：<%# Eval("AbscDateE","{0:yyyy/MM/dd}") %></span>--%>
                                                <br>
                                                <span>結束時間：<%# Eval("DateTimeE","{0:HH:mm}") %></span><%--<span>結束時間：<%# Eval("AbscTimeE") %></span>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col col-xs-6">
                                                <span>假別：<%# Eval("HcodeName") %></span><%--<span>假別：<%# Eval("HolidayName") %></span>--%>
                                                <br>
                                                <span>單號：<%# Eval("Serno") %></span><%--<span>單號：<%# Eval("ProcessId") %></span>--%>
                                            </div>

                                            <div class="col col-xs-6">
                                                <span>請假時數：<%# Eval("Use") %></span><%--<span>請假時數：<%# Eval("AbscTotalTime") %></span>--%>
                                                <br>
                                                <span>單位：<%# Eval("HcodeUnitName") %></span><%--<span>單位：<%# Eval("Unit") %></span>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    尚未新增請假資料
                </EmptyDataTemplate>
            </telerik:RadListView>
            <telerik:RadLabel ID="lblNotifyMsg" CssClass="animated shake" runat="server" Style="color: red;" Text=""></telerik:RadLabel>
        </telerik:RadAjaxPanel>
    </div>
    <asp:Label ID="lblNobrAppS" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblNameAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblRoleAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDeptNameAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDeptCodeAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblJobNameAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblJobCodeAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblFlowTreeID" runat="server" Visible="False"></asp:Label>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphCondition" runat="server">
    <telerik:RadAjaxPanel ID="plAppS" runat="server">
        <div class="ibox">
            <div class="ibox-title">
                <h5>條件</h5>
            </div>
            <div class="ibox-content">
                <div class="form-group row">
                    <div class="col-md-4">
                        <label class=" col-form-label">被申請人姓名</label>
                        <telerik:RadComboBox ID="txtNameAppS" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap"
                            AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                            LoadingMessage="載入中…" Width="100%">
                        </telerik:RadComboBox>
                    </div>
                    <div class="col-md-2 form-inline m-t-lg">
                        <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                    <h3>
                        <telerik:RadLabel ID="lblErrorMsg" runat="server" Text="" CssClass="text-danger"></telerik:RadLabel>
                    </h3>
                    </div>
                    <%--<div class="col-md-4" id="data_1">
                        <label class=" col-form-label">開始日期</label>
                        <telerik:RadDatePicker ID="txtDateB" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%"
                            OnSelectedDateChanged="txtDateB_SelectedDateChanged">
                        </telerik:RadDatePicker>
                    </div>
                    <div class="col-md-4" id="data_2">
                        <label class=" col-form-label">結束日期</label>
                        <telerik:RadDatePicker ID="txtDateE" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                        </telerik:RadDatePicker>
                    </div>--%>
                </div>
                

                <div class="hr-line-dashed"></div>

                <div class="row">
                    <div class="col-md-12">
                        <label class=" col-form-label">備註事項：</label>
                        <telerik:RadLabel ID="lblFormNoteStd" runat="server"></telerik:RadLabel>
                    </div>
                </div>
            </div>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
