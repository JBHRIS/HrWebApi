<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.Master" AutoEventWireup="true" CodeBehind="FormAbnStd.aspx.cs" Inherits="Portal.FormAbnStd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plInfo" />
                    <telerik:AjaxUpdatedControl ControlID="plReason" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbSelectAll">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plInfo" />
                    <telerik:AjaxUpdatedControl ControlID="plReason" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="ibox-content">
        <telerik:RadAjaxPanel ID="plInfo" runat="server">
            <telerik:RadListView ID="gvAppS" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnDataBound="gvAppS_DataBound" OnItemCommand="gvAppS_ItemCommand">
                <LayoutTemplate>
                    <div class="row">
                        <tbody id="Container" runat="server">
                        </tbody>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-lg-3">
                        <div class="keyin keyin-border">
                            <div class="row col-lg-12 align-center">
                                <h3>
                                    <telerik:RadLabel runat="server" ID="lblDate" Text='<%#Eval("ADate","{0:yyyy/MM/dd}") %>'></telerik:RadLabel>
                                </h3>
                            </div>
                            <div class="row">
                                <div class="col col-xs-6">
                                    <div class="form-check abc-checkbox">
                                        <telerik:RadCheckBox runat="server" ID="isEarlyCheck"
                                            CommandArgument='<%#Eval("Code") %>' CommandName='<%#Eval("EarlyTime") %>'
                                            Width="100%" Skin="Bootstrap">
                                        </telerik:RadCheckBox>
                                    </div>
                                </div>

                                <div class="col col-xs-6">
                                    <div class="form-check abc-checkbox">
                                        <telerik:RadCheckBox runat="server" ID="isLateCheck"
                                            CommandArgument='<%#Eval("Code") %>' CommandName='<%#Eval("LateTime") %>'
                                            Width="100%" Skin="Bootstrap">
                                        </telerik:RadCheckBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <telerik:RadLabel runat="server" ID="lblEmptyAbnormalDic" Text="無異常資料"></telerik:RadLabel>
                </EmptyDataTemplate>
            </telerik:RadListView>
        </telerik:RadAjaxPanel>
        <asp:Panel runat="server" ID="plReason" Visible="false">
            <div class="form-group row">
                <div class="col-md-4">
                    <telerik:RadLabel runat="server" CssClass="col-form-label" ID="lblReasonDic" Text="申請原因"></telerik:RadLabel>
                    <telerik:RadComboBox runat="server" ID="ddlReason" Width="100%" Skin="Bootstrap"></telerik:RadComboBox>
                </div>
            </div>
        </asp:Panel>
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
                <h5><telerik:RadLabel runat="server" ID="lblConditionDic" Text="條件"></telerik:RadLabel></h5>
            </div>
            <div class="ibox-content">
                <div class="form-group row">
                    <div class="col-md-3">
                        <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblYearDic" Text="年份"></telerik:RadLabel></label>
                        <telerik:RadComboBox runat="server" ID="ddlYear" Width="100%" Skin="Bootstrap"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-3">
                        <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblMonthDic" Text="月份"></telerik:RadLabel></label>
                        <telerik:RadComboBox runat="server" ID="ddlMonth" Width="100%" Skin="Bootstrap"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-1">
                        <div class="form-check abc-checkbox cleckbox_sy">
                            <telerik:RadCheckBox runat="server" ID="isEarlyCome" Checked="true" Text="早到" Width="100%" Skin="Bootstrap"></telerik:RadCheckBox>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <div class="form-check abc-checkbox cleckbox_sy">
                            <telerik:RadCheckBox runat="server" ID="isLateOut" Checked="true" Text="晚退" Width="100%" Skin="Bootstrap"></telerik:RadCheckBox>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <div class="form-check abc-checkbox cleckbox_sy">
                            <telerik:RadCheckBox runat="server" ID="cbSelectAll" OnCheckedChanged="cbSelectAll_CheckedChanged" Text="全選" Width="100%" Skin="Bootstrap"></telerik:RadCheckBox>
                        </div>
                    </div>
                </div>

                <div class="hr-line-dashed"></div>

                <div class="row">
                    <div class="col-md-1">
                        <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" CssClass="btn btn-primary" OnClick="btnSearch_Click" />

                    </div>
                    <div class="col-md-8">
                        <h3>
                            <telerik:RadLabel ID="lblErrorMsg" runat="server" Text="" Style="color: red;"></telerik:RadLabel>
                        </h3>
                    </div>
                </div>
                
            </div>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
