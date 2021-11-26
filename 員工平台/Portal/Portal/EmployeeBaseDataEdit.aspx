<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeBaseDataEdit.aspx.cs" Inherits="Portal.EmployeeBaseDataEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>資料修改</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="fullscreen-link">
                                <i class="fa fa-expand"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="panel blank-panel">
                            <div class="panel-heading">
                                <div class="panel-options">
                                    <ul class="nav nav-tabs">
                                        <li>
                                            <a class="nav-link active" href="#tabCommunication" data-toggle="tab">通訊資料</a>
                                        </li>
                                        <li>
                                            <a class="nav-link" href="#tabContact" data-toggle="tab">聯絡人資料1</a>
                                        </li>
                                        <li>
                                            <a class="nav-link" href="#tabContact2" data-toggle="tab">聯絡人資料2</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                
                                <div class="panel-body" >
                                    <div class="tab-content">
                                        
                                        <div class="tab-pane active" id="tabCommunication">
                                            <div class ="row">
                                                <div class="col-2 col-form-label">手機</div>
                                                <div class="col-10"><telerik:RadMaskedTextBox Mask="####-###-###" Skin="Bootstrap" Width="100%" runat="server" ID="txtCellphone" class="font-bold"/></div>
                                                <div class="col-2 col-form-label">戶籍電話</div>
                                                <div class="col-10"><telerik:RadTextBox Skin="Bootstrap" Width="100%" runat="server" ID="txtResidencePhone" class="font-bold" /></div>
                                                <div class="col-2 col-form-label">通訊電話</div>                      
                                                <div class="col-10"><telerik:RadTextBox Skin="Bootstrap" Width="100%" runat="server" ID="txtCommunicationPhone" class="font-bold"/></div>
                                                <div class="col-2 col-form-label">eMail</div>                          
                                                <div class="col-10"><telerik:RadTextBox Skin="Bootstrap" Width="100%" runat="server" ID="txtEMail" class="font-bold" /></div>
                                                <div class="col-2 col-form-label">通訊地址</div>                      
                                                <div class="col-10"><telerik:RadTextBox Skin="Bootstrap" Width="100%" runat="server" ID="txtCommunicationAddress" class="font-bold"/></div>
                                                <div class="col-2 col-form-label">戶籍地址</div>                       
                                                <div class="col-10"><telerik:RadTextBox Skin="Bootstrap" Width="100%" runat="server" ID="txtResidenceAddress" class="font-bold"/></div>
                                            </div>
                                                
                                        </div>
                                        <div class="tab-pane" id="tabContact">
                                            <div class ="row">
                                                <div class="col-2 col-form-label">聯絡人</div>
                                                <div class="col-10"><telerik:RadTextBox Skin="Bootstrap" Width="100%" runat="server" ID="txtContact" class="font-bold"/></div>
                                                <div class="col-2 col-form-label">聯絡人關係</div>
                                                <div class="col-10"><telerik:RadComboBox Skin="Bootstrap" Placeholder="請選擇..." AutoClose="false" TagMode="Single" Width="100%" runat="server" ID="ddlContactRelation" class="font-bold"/></div>
                                                <div class="col-2 col-form-label">聯絡人電話</div>
                                                <div class="col-10"><telerik:RadTextBox Skin="Bootstrap" Width="100%" runat="server" ID="txtContactTel" class="font-bold"/></div>
                                                <div class="col-2 col-form-label">聯絡人手機</div>
                                                <div class="col-10"><telerik:RadMaskedTextBox Mask="####-###-###" Skin="Bootstrap" Width="100%" runat="server" ID="txtContactPhone"/></div>
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="tabContact2">
                                            <div class ="row">
                                                <div class="col-2 col-form-label">聯絡人</div>
                                                <div class="col-10"><telerik:RadTextBox Skin="Bootstrap" Width="100%" runat="server" ID="txtContact1" class="font-bold"/></div>
                                                <div class="col-2 col-form-label">聯絡人關係</div>
                                                <div class="col-10"><telerik:RadComboBox Skin="Bootstrap" Placeholder="請選擇..." AutoClose="false" TagMode="Single" Width="100%" runat="server" ID="ddlContactRelation1" class="font-bold"/></div>
                                                <div class="col-2 col-form-label">聯絡人電話</div>
                                                <div class="col-10"><telerik:RadTextBox Skin="Bootstrap" Width="100%" runat="server" ID="txtContactTel1"/></div>
                                                <div class="col-2 col-form-label">聯絡人手機</div>
                                                <div class="col-10"><telerik:RadMaskedTextBox Mask="####-###-###" Skin="Bootstrap" Width="100%" runat="server" ID="txtContactPhone1"/></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </telerik:RadAjaxPanel>
                        </div>
                    </div>
                    <div class="ibox-footer">
                         <div class="animated fadeInRight">
                            <telerik:RadButton runat="server" OnClick="Update_Click" CssClass="btn-primary btn-sm" Text="更新"/>
                            <asp:Label Skin="Bootstrap" runat="server" ID="ResultText" CssClass="label-danger"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- FooTable -->
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>

</asp:Content>
