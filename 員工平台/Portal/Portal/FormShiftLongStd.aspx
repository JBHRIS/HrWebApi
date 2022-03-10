<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.Master" AutoEventWireup="true" CodeBehind="FormShiftLongStd.aspx.cs" Inherits="Portal.FormShiftLongStd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">


    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvAppS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="ibox-content">
        <telerik:RadAjaxPanel ID="plInfo" runat="server">
            <telerik:RadListView ID="gvAppS" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="gvAppS_NeedDataSource" OnItemCommand="gvAppS_ItemCommand" OnDataBound="gvAppS_DataBound">
                <LayoutTemplate>
                    <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                        <thead>
                            <%-- <tr>
                                <td colspan="2" style="text-align: center">動作</td>
                                <th>工號</th>
                                <th>姓名</th>
                                <th>開始日期</th>
                                <th>結束日期</th>
                                <th>時間</th>
                                <th>假別</th>
                                <th>使用</th>
                                <th>單位</th>
                                <th>代理人</th>
                            </tr>--%>
                        </thead>
                        <tbody id="Container" runat="server">
                        </tbody>
                        <tfoot>
                            <div>總共新增：<strong><telerik:RadLabel ID="lblCount" runat="server"  /></strong> 筆資料</div>
                        </tfoot>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="keyin keyin-border">
                        <div class="row">
                            <div class="col-md-2">
                                <h3>
                                    <span class="label label-primary m-r-sm"><telerik:RadLabel ID="lblListNumber" runat="server"  /></span>
                                    <%# Eval("EmpName") %>,
                                    <%# Eval("EmpId") %>
                                </h3>
                            </div>
                            <div class="col-md-9">
                                <div class="row">
                                    <div class="col-lg-4">
                                        <telerik:RadLabel runat="server" ID="lblChangeWorkDateDic" Text="調班日期"></telerik:RadLabel>：<%#Eval("Date","{0:yyyy/MM/dd}") %>
                                    </div>
                                    <div class="col-lg-4">
                                        <telerik:RadLabel runat="server" ID="lblOriginalWorkClassDic" Text="原班別"></telerik:RadLabel>：<%#Eval("RotetNameOrigin") %>
                                    </div>
                                    <div class="col-lg-4">
                                        <telerik:RadLabel runat="server" ID="lblChangeWorkClassDic" Text="換班班別"></telerik:RadLabel>：<%#Eval("RotetName") %>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <telerik:RadLabel runat="server" ID="lblReasonDic" Text="原因" ></telerik:RadLabel>：<%# Eval("Note") %>
                                    </div>

                                </div>
                            </div>
                           
                            <div class="col-sm-1">
                                <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn btn-outline btn-danger" OnClientClicking="Clicking"
                                    CommandName="Del" Text="刪除">
                                </telerik:RadButton>
                                <%--<telerik:RadButton ID="btnUpload" runat="server" CssClass="btn btn-outline btn-warning" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Upload" data-toggle="modal" data-target="#myModal" Text="附件" OnClick="btnUpload_Click">
                                </telerik:RadButton>--%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    尚未新增調班資料
                </EmptyDataTemplate>
            </telerik:RadListView>
            <telerik:RadLabel ID="lblNotifyMsg" runat="server" CssClass="text-danger" Text=""></telerik:RadLabel>
        </telerik:RadAjaxPanel>
    </div>
    <div style="padding: 20px 0px 0px 0px">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox" style="margin-bottom: 0px">
                    <div class="ibox-title">
                        <h5><telerik:RadLabel runat="server" ID="lblApplicationInfoDic" Text="申請日期"></telerik:RadLabel></h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadAjaxPanel ID="plAppS" runat="server">
                            <div class="form-group row">
                                <div class="col-md-3">
                                    <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblRespondentNameDic" Text="被申請人姓名"></telerik:RadLabel></label>
                                    <telerik:RadComboBox ID="txtNameAppS" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap"
                                        AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                                        LoadingMessage="載入中…" Width="100%" OnDataBound="txtNameAppS_DataBound" OnTextChanged="txtNameAppS_TextChanged">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-md-3">
                                    <label class="col-form-label">調班日期</label>
                                    <telerik:RadDatePicker ID="txtDateA" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%" OnSelectedDateChanged="txtDateA_SelectedDateChanged">
                                    </telerik:RadDatePicker>
                                </div>
                                <div class="col-md-3">
                                    <label class="col-form-label">目前班型</label>
                                    <telerik:RadComboBox ID="ddlRotetOrigin" runat="server" Culture="zh-TW" AllowCustomText="True" Enabled="false"
                                        AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                                        LoadingMessage="載入中…" Skin="Bootstrap" Width="100%">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-md-3">
                                    <label class="col-form-label">調班班型</label>
                                    <telerik:RadComboBox ID="ddlRotet" runat="server" Culture="zh-TW" AllowCustomText="True"
                                        AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                                        LoadingMessage="載入中…" Skin="Bootstrap" Width="100%">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-md-6">
                                    <label class="col-form-label">原因</label>
                                    <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="請輸入您的原因..."
                                        TextMode="MultiLine" Width="100%" Rows="3" Skin="Bootstrap">
                                    </telerik:RadTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label class="col-form-label">備註事項：</label>
                                    <telerik:RadLabel ID="lblFormNoteStd" runat="server"></telerik:RadLabel>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>

                            <div class="row">
                                <div class="col-lg-1">
                                    <telerik:RadButton ID="btnAdd" runat="server" Text="新增" CssClass="btn btn-outline btn-primary" OnClick="btnAdd_Click" />
                                </div>
                                <div class="col-lg-8">
                                     <h3>
                                        <telerik:RadLabel ID="lblErrorMsg" runat="server" Text="" Style="color: red;"></telerik:RadLabel>
                                     </h3>
                               </div>
                            </div>

                            
                        </telerik:RadAjaxPanel>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <asp:Label ID="lblNobrAppS" runat="server" Skin="Bootstrap" Visible="false"></asp:Label>
    <asp:Label ID="lblNameAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblRoleAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDeptNameAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDeptCodeAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblJobNameAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblFlowTreeID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblRotetOrigin" runat="server" Visible="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
