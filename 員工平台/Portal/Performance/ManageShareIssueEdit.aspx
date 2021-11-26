<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageShareIssueEdit.aspx.cs" Inherits="Performance.ManageShareIssueEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
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
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadLabel ID="lblAutoKey" runat="server" Visible="false" />
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">類型</label>
                                <div class="col-sm-10">
                                    <telerik:RadDropDownList ID="ddlIssueType" runat="server" AutoPostBack="false" Skin="Bootstrap" ValidationGroup="Main" />
                                    <asp:RequiredFieldValidator ID="rfvIssueType" ForeColor="Red" runat="server" ControlToValidate="ddlIssueType" ErrorMessage="分類為必填欄位" Display="Dynamic" ValidationGroup="Main">必填欄位</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">編號</label>
                                <div class="col-sm-10">
                                    <telerik:RadTextBox ID="txtSerial" runat="server" EmptyMessage="" Width="100%" CssClass="form-control" ValidationGroup="Main" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">內容</label>
                                <div class="col-sm-12">
                                    <telerik:RadEditor runat="server" ID="txtIssueContent" SkinID="BasicSetOfTools" ContentAreaMode="Div"
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
            //]]>
                                    </script>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">備註</label>
                                <div class="col-sm-12">
                                    <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="備註" Height="100px" Skin="Bootstrap" TextMode="MultiLine" Width="100%" />
                                </div>
                            </div>
                            <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" ValidationGroup="Main" CssClass="btn btn-primary" />
                            <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
                            <telerik:RadLabel ID="lblMsg" runat="server" CssClass="badge badge-danger" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
