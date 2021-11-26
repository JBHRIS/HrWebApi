<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_FileManage.ascx.cs" Inherits="Portal.UserControls.UC_FileManage" %>

<telerik:RadAjaxManagerProxy runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnUpload">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="plMain" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnDelete">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="plMain" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="gvAppS">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="plMain" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="modal inmodal" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content animated bounceInRight">


            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                <h4 class="modal-title">檔案管理</h4>
            </div>
            <div class="modal-body">
                <div class="wrapper wrapper-content animated fadeIn">
                    <div class="row">

                        <div class="col-lg-12">
                            <div class="ibox ">
                                <div class="ibox-title">
                                    <h5>檔案上傳</h5>
                                    <div class="ibox-tools">
                                        <a class="collapse-link">
                                            <i class="fa fa-chevron-up"></i>
                                        </a>
                                    </div>
                                </div>
                                <div class="ibox-content">
                                    <label class="alert alert-danger"><i class="fa fa-info-circle"></i>檔案大小限制為10MB</label>
                                    <label class="alert alert-danger"><i class="fa fa-info-circle"></i>檔案格式限制 jpg、jpeg、doc、docx、ppt、pptx、txt、pdf、mp3、zip、png、xls、xlsx</label>

                                    <div id="dZUpload" class="dropzone" style="border: 1px dashed #1ab394;">
                                        <div class="dz-default dz-message">
                                            請按這裡上傳檔案
                                        </div>
                                    </div>

                                    <div class="hr-line-dashed"></div>
                                    <div class="form-group row">
                                        <telerik:RadAjaxPanel ID="plUpload" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                            <div class="col-sm-2 col-sm-offset-2">
                                                <telerik:RadButton ID="btnUpload" runat="server" Text="上傳" OnClick="btnUpload_Click" CssClass="btn btn-primary btn-sm" />
                                            </div>
                                            <div>
                                                <telerik:RadLabel ID="lblMsg" runat="server" />
                                                <telerik:RadLabel ID="lblKey" runat="server" Visible="false" />
                                            </div>
                                        </telerik:RadAjaxPanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div id="iboxContent" class="ibox">
                                <div class="ibox-title">
                                    <h5>檔案列表</h5>
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
                                    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                        <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnItemDataBound="lvMain_ItemDataBound" OnItemCommand="lvMain_ItemCommand">
                                            <LayoutTemplate>
                                                <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                                    <thead>
                                                        <tr>
                                                            <th>檔名</th>
                                                            <th data-hide="phone,tablet">大小</th>
                                                            <th>動作</th>
                                                        </tr>
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
                                                <tr class="gradeX">
                                                    <td><%#Eval("FileName") %></td>
                                                    <td><%#Eval("FileSize") %></td>
                                                    <td>
                                                         <%--<asp:Button ID="btnDownload" runat="server" CommandArgument='<%#Eval("FileId") %>' OnClientClick='<%#"download(\""+Eval("FileId")+"\");" %>' CommandName="Download" Text="下載" CssClass="btn-white btn btn-xs" Style="padding: 4px 10px; min-width: 64px;" />--%>
                                                        <a href='<%#"download.ashx?openExternalBrowser=1&CompanyId=" + Eval("CompanyId") + "&index=" + Eval("FileId") + "&AccessToken=" + Eval("AccessToken") %>' target="_blank" Class="btn-white btn btn-xs" Style="padding: 4px 10px; min-width: 64px;">下載</a>
                                                         <%--<asp:Button ID="btnDownloadTEST" runat="server" CommandArgument='<%#Eval("FileId") %>' PostBackUrl='<%#"~\\download.ashx?index=" + Eval("FileId") %>' Text="下載(TEST)" CssClass="btn-white btn btn-xs" Style="padding: 4px 10px; min-width: 64px;" />--%>
                                                        <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("FileId") %>' CommandName="Delete" Text="刪除" CssClass="btn-white btn btn-xs">
                                                            <ConfirmSettings ConfirmText="確定刪除?" />
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                目前並無上傳任何檔案
                                            </EmptyDataTemplate>
                                        </telerik:RadListView>
                                    </telerik:RadAjaxPanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-white" data-dismiss="modal">關閉</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function download(FileId) {

        //檔案下載網址
        var url = "Download.ashx?openExternalBrowser=1";

        //產生 form
        var form = document.createElement("form");

        form.method = "GET";
        form.action = url;

        //如果想要另開視窗可加上target
        //form.target = "_blank";

        //index為要下載的檔案編號，存入hidden跟表單一起送出
        var input = document.createElement("input");
        input.type = "hidden";
        input.name = "index";
        input.value = FileId;
        form.appendChild(input);

        //送出表單並移除 form
        var body = document.getElementsByTagName("body")[0];
        body.appendChild(form);
        form.submit();
        form.remove();
    };
</script>
