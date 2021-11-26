<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormAgent.aspx.cs" Inherits="Portal.FormAgent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txtNameAppS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtJobAppS" />
                    <telerik:AjaxUpdatedControl ControlID="txtNameAgent" />
                    <telerik:AjaxUpdatedControl ControlID="lvAgent" />
                    <telerik:AjaxUpdatedControl ControlID="lvAgentDate" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lvAgent" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lvAgent">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cblForm" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>

    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <div>
                            <h5>代理設定</h5>
                        </div>
                    </div>

                    <div class="ibox-content">
                        <div class="form-group row">
                            <asp:Panel runat="server" ID="plAppS" Width="100%" CssClass="col-md-3 row">
                                <div class="col-md-12">
                                    <label class=" col-form-label">被代理人</label>
                                    <telerik:RadComboBox ID="txtNameAppS" runat="server" Skin="Bootstrap" OnSelectedIndexChanged="txtNameAppS_SelectedIndexChanged" Culture="zh-TW"
                                        Placeholder="請選擇..." AutoPostBack="true"
                                        AutoClose="false"
                                        TagMode="Single"
                                        Width="100%"
                                        AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…">
                                    </telerik:RadComboBox>
                                </div>
                            </asp:Panel>

                            <div class="col-md-3">
                                <label class=" col-form-label">被代理職務</label>
                                <telerik:RadComboBox ID="txtJobAppS" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap" Width="100%">
                                </telerik:RadComboBox>
                            </div>
                            <div class="col-md-3">
                                <label class="col-form-label">代理人</label>
                                <telerik:RadComboBox ID="txtNameAgent" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap" Width="100%" Filter="Contains">
                                </telerik:RadComboBox>
                            </div>

                            <div class="col-md-2">
                                <label class="col-form-label">順位</label>
                                <telerik:RadTextBox ID="txtNumberOrder" InputType="Number" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap" Width="100%">
                                </telerik:RadTextBox>
                            </div>

                            <div class="col-md-1 form-inline m-t-lg">
                                <telerik:RadButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增" CssClass="btn btn-primary" />
                                <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge badge-danger animated shaked"></telerik:RadLabel>
                            </div>
                        </div>
                        
                        <div class="row">
                            <ul>
                                <li>先前新增的代理人當中有相同的代理人的選項，被代理的順位可以修改。</li>
                                <li>如果沒有設定任何一張表單，代表全部表單都符合代理條件。</li>
                                <li>代理順位相同的情況下，會用亂數決定代理人的優先順序。</li>
                            </ul>
                        </div>

                        <h5 class="bg-muted p-xs">代理人資訊</h5>
                        <telerik:RadAjaxPanel runat="server">
                            <telerik:RadListView runat="server" ID="lvAgent" RenderMode="Lightweight" OnNeedDataSource="lvAgent_NeedDataSource" ItemPlaceholderID="Container" OnItemCommand="lvAgent_ItemCommand">
                                <ItemTemplate>
                                    <div class="keyin keyin-border">
                                        <div class="row">
                                            <div class="col-lg-10">
                                                <div class="row">
                                                    <div class="col-lg-3">被代理人部門：<%# Eval("DeptNameSource") %></div>
                                                    <div class="col-lg-3">被代理人職稱：<%# Eval("PosNameSource") %></div>
                                                    <div class="col-lg-3">代理人姓名：<%# Eval("EmpNameTarget") %></div>
                                                    <div class="col-lg-3">代理人部門：<%# Eval("DeptNameTarget") %></div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3">代理人職稱：<%# Eval("PosNameTarget") %></div>
                                                    <%--<div class="col-lg-3">代理表單：<%# Eval("Form") %></div>--%>
                                                    <div class="col-lg-3">順位：<%# Eval("Sort") %></div>
                                                    <div class="col-lg-3">登入日期：<%# Eval("KeyDate","{0:yyyy-MM-dd}") %></div>

                                                </div>
                                            </div>
                                            <div class="col-lg-2">
                                                <telerik:RadButton ID="btnAuthority" CommandName="Auth" CommandArgument='<%# Eval("Guid") %>' runat="server" Text="權限設定" CssClass="btn btn-outline btn-primary" data-toggle="modal" data-target="#AuthorityModal" />
                                                <telerik:RadButton ID="btnDelete" CommandName="Delete" CommandArgument='<%# Eval("Auto") %>' runat="server" Text="刪除" CssClass="btn btn-outline btn-danger" />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                
                                <EmptyItemTemplate>
                                    無代理人.資料
                                </EmptyItemTemplate>
                            </telerik:RadListView>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>


        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <div>
                            <h5>代理日期</h5>
                        </div>
                    </div>

                    <div class="ibox-content">
                        <telerik:RadAjaxPanel runat="server" ID="plAgentDate">
                            <div class="form-group row">
                                <div class="col-md-3" id="data_1">
                                    <label class=" col-form-label">開始日期</label>
                                    <telerik:RadDatePicker ID="txtDateB" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>

                                <div class="col-md-3" id="data_2">
                                    <label class=" col-form-label">結束日期</label>
                                    <telerik:RadDatePicker ID="txtDateE" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>

                                <div class="col-md-2">
                                    <label class=" col-form-label">開始時間</label>
                                    <telerik:RadMaskedTextBox ID="txtTimeB" runat="server" Mask="####" Width="100%" Skin="Bootstrap">
                                    </telerik:RadMaskedTextBox>
                                </div>

                                <div class="col-md-2">
                                    <label class=" col-form-label">結束時間</label>
                                    <telerik:RadMaskedTextBox ID="txtTimeE" runat="server" Mask="####" Width="100%" Skin="Bootstrap">
                                    </telerik:RadMaskedTextBox>
                                </div>


                                <div class="col-lg-1 form-inline m-t-lg">
                                    <telerik:RadButton ID="btnAgentAdd" runat="server" Text="新增" OnClick="btnAgentAdd_Click" CssClass="btn btn-primary" />
                                    <telerik:RadLabel runat="server" ID="lblDateMsg" CssClass="badge badge-danger animated shake"></telerik:RadLabel>
                                </div>
                                
                            </div>

                            <h5 class="bg-muted p-xs">代理人資訊</h5>
                            <telerik:RadListView runat="server" ID="lvAgentDate" OnNeedDataSource="lvAgentDate_NeedDataSource" OnItemCommand="lvAgentDate_ItemCommand" RenderMode="Lightweight">
                                <ItemTemplate>
                                    <div class="keyin keyin-border">

                                        <div class="row">
                                            <div class="col-lg-10">
                                                <div class="row">
                                                    <div class="col-lg-4">開始日期：<%# Eval("dateB") %></div>
                                                    <div class="col-lg-4">結束日期：<%# Eval("dateE") %></div>
                                                    <div class="col-lg-4">登入日期：<%# Eval("KeyDate") %></div>
                                                </div>
                                            </div>
                                            <div class="col-lg-2">
                                                <telerik:RadButton ID="btnAgentD" CommandName="Delete" runat="server" Text="刪除" CssClass="btn btn-outline btn-danger" />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <EmptyItemTemplate>
                                    無代理日期資料
                                </EmptyItemTemplate>
                            </telerik:RadListView>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>


    </div>
    <div class="modal inmodal" id="AuthorityModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content animated bounceInRight">

                <telerik:RadAjaxPanel ID="plAuthority" runat="server">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                       
                        <h4 class="modal-title">設定權限</h4>
                    </div>
                    <div class="modal-body">
                        <div class="wrapper wrapper-content animated fadeIn">
                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="ibox ">
                                        <div class="ibox-title">
                                            <h5>權限設定</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="alert alert-danger">
                                                 <i class="fa fa-info-circle"></i> 若無選擇表單則會代理全表單
                                            </div>
                                            
                                            <telerik:RadCheckBoxList runat="server" ID="cblForm">
                                            </telerik:RadCheckBoxList>

                                            <div class="form-group row">
                                                <div class="col-md-3">
                                                    <telerik:RadButton ID="btnConfirm" runat="server" Text="確認" CssClass="btn btn-w-m btn-primary" OnClick="btnConfirm_Click"></telerik:RadButton>
                                                    <telerik:RadLabel ID="lblGuid" runat="server" Visible="false"></telerik:RadLabel>
                                                    <telerik:RadLabel ID="lblErrorMsg" runat="server" Style="color: red;"></telerik:RadLabel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <label class=" col-form-label">修改完畢字樣出現後才可關閉視窗</label>
                        <button type="button" class="btn btn-white" data-dismiss="modal">關閉</button>
                    </div>
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
