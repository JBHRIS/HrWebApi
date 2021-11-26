<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewsManage.aspx.cs" Inherits="Portal.NewsManage" %>

<%@ Register Src="~/UserControls/UC_FileManage.ascx" TagPrefix="uc" TagName="FileManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
    <link href="Templates/Inspinia/css/plugins/dropzone/basic.css" rel="stylesheet">
    <link href="Templates/Inspinia/css/plugins/dropzone/dropzone.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnUpload">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>新增或修改內容</h5>
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
                        <telerik:RadTextBox ID="txtIdNo" Enabled="false" Visible="false" runat="server" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label">
                                <label style="color: #FF0000;">※</label>生效日期</label>
                            <div class="col-sm-10 row">
                                <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="txtNewsPostDate" Skin="Bootstrap" DateInput-DateFormat="yyyy/MM/dd" DateInput-Width="80%" />
                                <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="txtNewsDeadLine" Skin="Bootstrap" DateInput-Label="到" DateInput-DateFormat="yyyy/MM/dd" />
                            </div>
                        </div>
                        <telerik:RadLabel ID="AutoKey" Enabled="false" runat="server" Skin="Bootstrap" Visible="false"></telerik:RadLabel>
                        <div class="form-group row ">
                            <label class="col-sm-2 col-form-label">
                                <label style="color: #FF0000;">※</label>標題</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" Skin="Bootstrap" ID="txtNewsTitle" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="form-group row ">
                            <label class="col-sm-2 col-form-label">是否發布:</label>
                            <div class="col-sm-10 row">
                                <telerik:RadCheckBox ID="cbIsOn" Skin="Bootstrap" AutoPostBack="false" runat="server" Checked="true" />
                            </div>
                        </div>

                        <div class="form-group row ">
                            <%--<label class="col-sm-2 col-form-label">對象:</label>--%>
                            <div class="col-sm-10 row">
                                <telerik:RadComboBox runat="server" ID="ddlTarget" Skin="Bootstrap" Width="100%" Visible="false"></telerik:RadComboBox>
                            </div>
                        </div>

                        <hr />
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">
                                <label style="color: #FF0000;">※</label>內容:</label>
                            <telerik:RadEditor runat="server" ID="txtNewsContent" SkinID="BasicSetOfTools" ContentAreaMode="Div"
                                OnClientCommandExecuting="OnClientCommandExecuting" Width="100%" Height="200px" CssClass="form-control"
                                ContentFilters="MakeUrlsAbsolute,FixEnclosingP" EditModes="Design" NewLineBr="true" Skin="Bootstrap">
                                <Tools>
                                    <telerik:EditorToolGroup>
                                        <telerik:EditorTool Name="Cut"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Copy"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Paste"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Undo"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Redo"></telerik:EditorTool>
                                    </telerik:EditorToolGroup>
                                </Tools>
                                <Content>
                                </Content>
                            </telerik:RadEditor>
                            <script type="text/javascript">
                                //<![CDATA[
                                function OnClientCommandExecuting(editor, args) {
                                    var name = args.get_name(); //The command name
                                    var val = args.get_value(); //The tool that initiated the command
                                    if (name == "Emoticons" || name == "Emoticons2") {
                                        //Set the background image to the head of the tool depending on the selected toolstrip item
                                        var tool = args.get_tool();
                                        var span = tool.get_element().getElementsByTagName("SPAN")[0];
                                        span.style.backgroundImage = "url(" + val + ")";
                                        //Paste the selected in the dropdown emoticon    
                                        editor.pasteHtml("<img src='" + val + "'>");
                                        //Cancel the further execution of the command
                                        args.set_cancel(true);
                                    }

                                    var elem = editor.getSelectedElement(); //Get a reference to the selected element                
                                    if (elem && (name == "OrderedListType" || name == "UnorderedListType")) {
                                        if (elem.tagName != "OL" && elem.tagName != "UL") {
                                            while (elem != null) {
                                                if (elem && elem.tagName == "OL" || elem.tagName == "UL") break;
                                                elem = elem.parentNode;
                                            }

                                            if (elem) elem.style.listStyleType = val; //apply the selected item shape
                                            else alert("No ordered list selected! Please select a list to modify");
                                        }
                                        args.set_cancel(true);
                                    }

                                    if (name == "DynamicDropdown" || name == "DynamicSplitButton") {
                                        editor.pasteHtml("<div style='width:100px;background-color:#fafafa;border:1px dashed #aaaaaa;'>" + val + "</div>");
                                        //Cancel the further execution of the command
                                        args.set_cancel(true);
                                    }

                                    if (name == "Columns") {
                                        editor.pasteHtml("<span style='display:inline-block;'>{" + val + "}</span>");
                                        //Cancel the further execution of the command
                                        args.set_cancel(true);
                                    }
                                }
                            </script>
                        </div>
                        <hr />
                        <telerik:RadAjaxPanel runat="server">
                            <telerik:RadButton runat="server" ID="btnUpload" CssClass="btn btn-sm btn-info" Visible="false" Text="上傳附件" OnClick="btnUpload_Click" data-toggle="modal" data-target="#myModal"></telerik:RadButton>
                        </telerik:RadAjaxPanel>
                        <%--<asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true"/>
                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                        <%--<form role="form" action="http://192.168.1.46/HrWebApi/api/Files/UploadSingleFile" enctype="multipart/form-data" method="post" class="dropzone" id="dropzoneForm">
                                <div class="fallback">
                                    <input name="file" type="file" multiple />
                                </div>
                            </form>
                            <input type="submit" value="上傳" id="submit" />
                            <telerik:RadButton runat="server" ID="btnSubmit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" Text="測試上傳" OnClientClicking="ExcuteConfirm" />--%>
                        <hr />
                        <%--<telerik:RadButton ID="btnDownload" runat="server" OnClick="btnDownload_Click" Text="下載"></telerik:RadButton>--%>
                        <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" ValidationGroup="Main" CssClass="btn btn-primary" />
                        <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
                        <telerik:RadLabel runat="server" CssClass="label-danger" Font-Size="Larger" ID="lblMsg"></telerik:RadLabel>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc:FileManage ID="ucFileManage" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

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
    <script>
        Dropzone.options.dropzoneForm = {
            paramName: "file", // The name that will be used to transfer the file
            maxFilesize: 2, // MB
            dictDefaultMessage: "<strong>點選上傳或將檔案移動到方塊中</strong>"
        };

        $(document).ready(function () {

            var editor_one = CodeMirror.fromTextArea(document.getElementById("code1"), {
                lineNumbers: true,
                matchBrackets: true
            });

            var editor_two = CodeMirror.fromTextArea(document.getElementById("code2"), {
                lineNumbers: true,
                matchBrackets: true
            });

            var editor_two = CodeMirror.fromTextArea(document.getElementById("code3"), {
                lineNumbers: true,
                matchBrackets: true
            });

            var editor_two = CodeMirror.fromTextArea(document.getElementById("code4"), {
                lineNumbers: true,
                matchBrackets: true
            });


            $('.custom-file-input').on('change', function () {
                let fileName = $(this).val().split('\\').pop();
                $(this).next('.custom-file-label').addClass("selected").html(fileName);
            });

        });
    </script>
</asp:Content>
