<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.master" AutoEventWireup="true" CodeBehind="FormWorkLog.aspx.cs" Inherits="Portal.FormWorkLog" %>

<%@ Register Src="~/UserControls/UC_FileManage.ascx" TagPrefix="uc" TagName="FileManage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Templates/Inspinia/css/plugins/dropzone/basic.css" rel="stylesheet">
    <link href="Templates/Inspinia/css/plugins/dropzone/dropzone.css" rel="stylesheet">

    <style>
        .form-control[type=file]:not(:disabled):not([readonly]) {
            cursor: pointer;
            padding: 0;
            height: 30px;
        }

        .form-control[type=file] {
            overflow: hidden;
        }

        .form-control:disabled, .form-control[readonly] {
            background-color: #e8f6f3;
            opacity: 1;
        }

        /*form_icon*/
        .form_icon {
            color: #1ab394;
        }

        /*Select2 */
        .select2-container--bootstrap4 .select2-selection {
            border-radius: 0;
            border: 1px solid #e5e6e7;
        }

        .select2-container--bootstrap4.select2-container--focus .select2-selection {
            -webkit-box-shadow: none;
            box-shadow: none;
            border-color: #1ab394;
        }

        .select2-container--bootstrap4 .select2-selection--single .select2-selection__arrow b {
            border-color: #1ab394 transparent transparent;
        }

        .select2-container--bootstrap4 .select2-results__option--highlighted, .select2-container--bootstrap4 .select2-results__option--highlighted.select2-results__option[aria-selected=true] {
            background-color: #1ab394;
        }

        .keyin {
            padding: .75rem 1.25rem;
            margin-bottom: 1rem;
            border: 1px solid transparent;
        }

        .keyin-border {
            color: #676A6C;
            background-color: #FFFFFF;
            border-color: #e7eaec;
            box-shadow: #e8f6f3 3px 3px 1px;
        }

        @media only screen and (min-width: 375px) and (max-width:480px) {
            .col {
                padding-right: 0 !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvAppS" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="ibox-content">
        <telerik:RadAjaxPanel ID="plInfo" runat="server">
            <telerik:RadListView ID="gvAppS" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="gvAppS_NeedDataSource" OnDataBound="gvAppS_DataBound" OnItemCommand="gvAppS_ItemCommand">
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
                            <tr>
                                <td colspan="5">
                                    <ul class="pagination float-right"></ul>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="keyin keyin-border">
                        <div class="row">
                            <div class="col-md-2">
                                <h3>
                                    <%# Eval("EmpName") %>,
                                    <%# Eval("EmpId") %>
                                </h3>
                            </div>
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-lg-4">日期：<%# Eval("DateB","{0:yyyy/MM/dd}") %></div>
                                    <div class="col-lg-4">開始時間：<%# Eval("TimeB") %></div>
                                    <div class="col-lg-4">結束時間：<%# Eval("TimeE") %></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12" style="word-break: break-all;">工作內容：<%# Eval("Note") %></div>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("GUID") %>' CssClass="btn btn-outline btn-danger"
                                    CommandName="Del" Text="刪除">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnUpload" runat="server" CssClass="btn btn-outline btn-warning" CommandArgument='<%# Eval("GUID") %>' CommandName="Upload" data-toggle="modal" data-target="#myModal" Text="附件" OnClick="btnUpload_Click">
                                </telerik:RadButton>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    尚未新增資料
                </EmptyDataTemplate>
            </telerik:RadListView>
            <telerik:RadLabel ID="lblNotifyMsg" runat="server" Style="color: red;" Text=""></telerik:RadLabel>
        </telerik:RadAjaxPanel>
    </div>
    <div class="ibox" style="padding: 20px 0px 0px 0px">
        <div class="ibox-title">
            <h5>申請資訊</h5>
            <div class="ibox-tools">
                <a class="collapse-link">
                    <i class="fa fa-chevron-up"></i>
                </a>
            </div>
        </div>
        <div class="ibox-content">
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                <div class="form-group row">
                    <%--<div class="col-md-3">
                        <label class=" col-form-label">申請原因</label>
                        <telerik:RadComboBox ID="ddlReason" runat="server" Skin="Bootstrap" Width="100%" Culture="zh-TW" EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…">
                        </telerik:RadComboBox>
                    </div>--%>
                    <div class="col-md-4" id="data_1">
                        <label class=" col-form-label">日期</label>
                        <telerik:RadDatePicker ID="txtDateB" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                        </telerik:RadDatePicker>
                    </div>
                    <div class="col-md-4">
                        <label class=" col-form-label">開始時間</label><br />
                        <telerik:RadMaskedTextBox ID="txtTimeB" runat="server" Mask="####" Width="100%" Skin="Bootstrap">
                        </telerik:RadMaskedTextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="col-form-label">結束時間</label>
                        <telerik:RadMaskedTextBox ID="txtTimeE" runat="server" Mask="####" Width="100%" Skin="Bootstrap">
                        </telerik:RadMaskedTextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-12">
                            <label class=" col-form-label">工作內容</label>
                            <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="請輸入您的說明..."
                                TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="4">
                            </telerik:RadTextBox>
                    </div>
                </div>
                <%--<div class="form-group row">
                    <div class="col-md-12">
                        <label class=" col-form-label">備註事項</label><br>
                        <telerik:RadLabel ID="lblFormNoteStd" runat="server"></telerik:RadLabel>
                    </div>
                </div>--%>
                <div class="hr-line-dashed"></div>
                <div class="col-sm-12 col-sm-offset-2">
                    <div class="row">
                        <div class="col-lg-1">
                            <telerik:RadButton ID="btnAdd" runat="server" Text="新增" CssClass="btn btn-outline btn-primary" OnClick="btnAdd_Click" />
                        </div>
                        <div class="col-lg-4">
                            <h3><telerik:RadLabel ID="lblErrorMsg" runat="server" Text="" CssClass="text-danger"></telerik:RadLabel></h3>
                        </div>
                    </div>
                    
                    
                        
                    
                </div>
            </telerik:RadAjaxPanel>
            <uc:FileManage ID="ucFileManage" runat="server" />
            <asp:Label ID="lblNobrAppS" runat="server" Skin="Bootstrap" Visible="false"></asp:Label>
            <asp:Label ID="lblNameAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblRoleAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblDeptNameAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblDeptCodeAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblJobNameAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblFlowTreeID" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblNobrAgent1" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.footable').footable();
            $('.footableTaken').footable();
        });
    </script>
    <script src="Templates/Inspinia/js/plugins/dropzone/dropzone.js"></script>
    <script type="text/javascript">
        DropzoneInit();
        function DropzoneInit(sender, eventArgs) {
            Dropzone.autoDiscover = false;
            //Simple Dropzonejs 
            $("#dZUpload").dropzone({
                //指定上传图片的路径
                url: "HandlerFileUploadDropzone.ashx",
                //method: "post",
                //添加上传取消和删除预览图片的链接，默认不添加
                addRemoveLinks: true,
                //关闭自动上传功能，默认会true会自动上传
                //也就是添加一张图片向服务器发送一次请求
                autoProcessQueue: true,
                //允许上传多个照片
                uploadMultiple: false,
                //每次上传的最多文件数，经测试默认为2，坑啊
                //记得修改web.config 限制上传文件大小的节
                parallelUploads: 1, //手动触发时一次最大可以上传多少个文件
                maxFiles: 1, //一次上传的量
                maxFilesize: 5,   //M为单位
                acceptedFiles: ".jpg,.jpeg,.doc,.docx,.ppt,.pptx,.txt,.avi,.pdf,.mp3,.zip,.pdf,.png",//可接受的上传类型
                dictDefaultMessage: "點擊或拖入要上傳的文件",      //上传框默认显示文字
                dictMaxFilesExceeded: "一次只能上傳1個檔案",
                dictResponseError: "上傳失敗",
                dictInvalidFileType: "此檔案類型不能上傳",
                dictFallbackMessage: "瀏覽器不支援",
                dictFileTooBig: "檔案大小超過限制(5MB)",
                success: function (file, response) {
                    var imgName = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgName);

                    //this.removeAllFiles();
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });
        }
    </script>
</asp:Content>
