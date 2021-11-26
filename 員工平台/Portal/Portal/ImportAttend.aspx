<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ImportAttend.aspx.cs" Inherits="Portal.ImportAttend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/dropzone/basic.css" rel="stylesheet">
    <link href="Templates/Inspinia/css/plugins/dropzone/dropzone.css" rel="stylesheet">
    <style>
        .dropzone {
            min-height: 140px;
            border: 1px dashed #1ab394;
            background: white;
            padding: 20px 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnRefreshSheetName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plSheet" />
                    <telerik:AjaxUpdatedControl ControlID="plSubmit" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSubmit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>匯入班表資料</h5>
                        <telerik:RadButton runat="server" ID="btnDownload" CssClass="btn btn-sm btn-primary btn-outline" Text="班表範本下載" OnClick="btnDownload_Click"></telerik:RadButton>

                    </div>
                    <div class="ibox-content">
                        <div id="wizard">
                            <div class="step-content">
                                <div class="text-left m-t-md">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="row form-group">
                                                <div class="col-lg-12">
                                                    <div id="dZUpload" class="dropzone">
                                                        <div class="dz-default dz-message">
                                                            <i class="fa fa-cloud-upload fa-2x"></i><br>請按這裡上傳檔案
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%--<h1>選擇匯入班表年月</h1>
                            <div class="step-content">
                                <div class="row m-t-md">
                                    <div class=" col-lg-6 form-group">
                                        <label>匯入班表年份</label>

                                        <select class="select2_demo_1 form-control">
                                            <option value="1">2018</option>
                                            <option value="2">People 2</option>
                                            <option value="3">People 3</option>
                                            <option value="4">People 4</option>
                                            <option value="5">People 5</option>
                                        </select>
                                    </div>
                                    <div class=" col-lg-6 form-group">
                                        <label>匯入班表月份</label>

                                        <select class="select2_demo_1 form-control">
                                            <option value="1">06</option>
                                            <option value="2">People 2</option>
                                            <option value="3">People 3</option>
                                            <option value="4">People 4</option>
                                            <option value="5">People 5</option>
                                        </select>
                                    </div>
                                </div>
                            </div>--%>
                            <telerik:RadAjaxPanel runat="server" CssClass="text-center">
                                <telerik:RadButton runat="server" ID="btnRefreshSheetName" Text="確認" OnClick="btnRefreshSheetName_Click" CssClass="btn btn-w-m btn-primary m-b-md col-4 col-sm-1"></telerik:RadButton>
                            </telerik:RadAjaxPanel>
                            <telerik:RadAjaxPanel ID="plSheet" runat="server" CssClass="col-12 row">
                                <telerik:RadLabel runat="server" Text="工作表名稱" CssClass="col-form-label offset-sm-2 col-4 col-sm-3 text-right"></telerik:RadLabel>
                                <telerik:RadComboBox runat="server" ID="ddlSheetName" Width="100%" CssClass="col-4 col-sm-3" Skin="Bootstrap"></telerik:RadComboBox>
                            </telerik:RadAjaxPanel>
                            
                            <asp:Panel runat="server" ID="plSubmit" class="step-content">
                                <div class="text-center">
                                    <telerik:RadButton CssClass="btn btn-w-m m-t-sm m-b-sm btn-primary" ID="btnSubmit" Text="開始匯入班表" OnClick="btnSubmit_Click" runat="server"></telerik:RadButton>
                                    <br>
                                    <span>按下開始匯入班表，完成員工班表匯入程序</span>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <p>
            <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge badge-danger animated shake"></telerik:RadLabel>
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Steps -->
    <script src="Templates/Inspinia/js/plugins/steps/jquery.steps.min.js"></script>

    <!-- Jquery Validate -->
    <script src="Templates/Inspinia/js/plugins/validate/jquery.validate.min.js"></script>

    <!-- Input Mask-->
    <script src="Templates/Inspinia/js/plugins/jasny/jasny-bootstrap.min.js"></script>

    <!-- Data picker -->
    <script src="Templates/Inspinia/js/plugins/datapicker/bootstrap-datepicker.js"></script>

    <!-- Tags Input -->
    <script src="Templates/Inspinia/js/plugins/bootstrap-tagsinput/bootstrap-tagsinput.js"></script>
    <script src="Templates/Inspinia/js/plugins/clockpicker/clockpicker.js"></script>
    <script src="Templates/Inspinia/js/plugins/colorpicker/bootstrap-colorpicker.min.js"></script>

    <!-- Select2 -->
    <script src="Templates/Inspinia/js/plugins/select2/select2.full.min.js"></script>


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
                acceptedFiles: ".xls,.xlsx",//可接受的上传类型
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
                removedfile: function () { window.location.reload(); },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });
        }
    </script>
    <%--<script>

        $(document).ready(function () {
            $("#wizard").steps();
            $("#form").steps({
                bodyTag: "fieldset",
                onStepChanging: function (event, currentIndex, newIndex) {
                    // Always allow going backward even if the current step contains invalid fields!
                    if (currentIndex > newIndex) {
                        return true;
                    }

                    // Forbid suppressing "Warning" step if the user is to young
                    if (newIndex === 3 && Number($("#age").val()) < 18) {
                        return false;
                    }

                    var form = $(this);

                    // Clean up if user went backward before
                    if (currentIndex < newIndex) {
                        // To remove error styles
                        $(".body:eq(" + newIndex + ") label.error", form).remove();
                        $(".body:eq(" + newIndex + ") .error", form).removeClass("error");
                    }

                    // Disable validation on fields that are disabled or hidden.
                    form.validate().settings.ignore = ":disabled,:hidden";

                    // Start validation; Prevent going forward if false
                    return form.valid();
                },
                onStepChanged: function (event, currentIndex, priorIndex) {
                    // Suppress (skip) "Warning" step if the user is old enough.
                    if (currentIndex === 2 && Number($("#age").val()) >= 18) {
                        $(this).steps("next");
                    }

                    // Suppress (skip) "Warning" step if the user is old enough and wants to the previous step.
                    if (currentIndex === 2 && priorIndex === 3) {
                        $(this).steps("previous");
                    }
                },
                onFinishing: function (event, currentIndex) {
                    var form = $(this);

                    // Disable validation on fields that are disabled.
                    // At this point it's recommended to do an overall check (mean ignoring only disabled fields)
                    form.validate().settings.ignore = ":disabled";

                    // Start validation; Prevent form submission if false
                    return form.valid();
                },
                onFinished: function (event, currentIndex) {
                    var form = $(this);

                    // Submit form input
                    form.submit();
                }
            }).validate({
                errorPlacement: function (error, element) {
                    element.before(error);
                },
                rules: {
                    confirm: {
                        equalTo: "#password"
                    }
                }
            });
        });
    </script>--%>
</asp:Content>
