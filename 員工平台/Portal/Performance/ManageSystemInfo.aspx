<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageSystemInfo.aspx.cs" Inherits="Performance.ManageSystemInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>系統資訊</h5>
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
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">系統版本</label>
                                <div class="col-sm-12 ">
                                    <telerik:RadLabel ID="lblSystemRev" runat="server" Text="2020112601" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">系統介紹</label>
                                <div class="col-sm-12 ">
                                    <p>
                                        01.獨立系統，可界接各種有人員組織之系統。<br />
                                        02.可依期別、月、季、年無限產生考核名單。<br />
                                        03.關鍵指標可以依職等定義上限。<br />
                                        04.可評核關鍵指標。<br />
                                        05.可定義部門強迫分配的規則之百分比(各等第及等第群組) 。<br />
                                        06.可依據評核關鍵指標強迫分配等第。<br />
                                        07.依據等第及基礎獎金定義獎金上限及下限。<br />
                                        08.可調整獎金上下限互相挪用。<br />
                                        09.完整的簽核機制(可呈可退) 。<br />
                                        10.所有需輸入數據可匯入及匯出。<br />
                                        11.可重置還原資料。<br />
                                        12.有設定完整卡控(例如丙等必須輸入原因備註) 。<br />
                                        13.可設定獎金可視層級。<br />
                                    </p>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">系統還原</label>
                                <div class="col-sm-2 ">
                                    <telerik:RadTextBox ID="txtPassword" runat="server" EmptyMessage="密碼" Width="100%" CssClass="form-control" />
                                    <telerik:RadToolTip RenderMode="Lightweight" ID="ttPassword" runat="server" Width="400px" ShowEvent="OnClick"
                                        TargetControlID="txtPassword" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight" Skin="Bootstrap"
                                        ShowDelay="0" RelativeTo="Element" Text="請輸入[確定刪除]，還原後所有資料將會刪除" />
                                </div>
                                <div class="col-sm-1 ">
                                    <telerik:RadButton ID="btnSystemDefault" runat="server" Text="系統初始化" OnClick="btnSystemDefault_Click" OnClientClicking="ExcuteConfirm" CssClass="btn btn-w-m btn-danger" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <div class="col-sm-1">
                                    <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>

