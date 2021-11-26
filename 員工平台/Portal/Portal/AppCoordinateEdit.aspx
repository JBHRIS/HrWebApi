<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppCoordinateEdit.aspx.cs" Inherits="Portal.AppCoordinateEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="col-lg-12">
        <div class="ibox">
            <div class="ibox-title">
                <h5>地圖</h5>
                <div class="ibox-tools">
                    <a class="collapse-link">
                        <i class="fa fa-chevron-up"></i>
                    </a>
                </div>
            </div>
            <div class="ibox-content">
                <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <div id="map" style="height: 800px; width: 800px;"></div>
                    </div>
                
            </div>
        </div>
    </div>




    <div class="col-lg-12">
        <div class="ibox ">

            <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                <div class="ibox-title">
                    <h5>地圖座標</h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>
                    </div>
                </div>

                <div class="ibox-content">

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-2 col-form-label">經度 :</label>
                        <div class="col-sm-10 col-lg-4 row">
                            <telerik:RadTextBox ID="txt_latitude" runat="server" CssClass="form-control" Width="100%" Enabled="false" />
                        </div>
                    </div>

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-2 col-form-label">經度 :</label>
                        <div class="col-sm-10 col-lg-4 row">
                            <telerik:RadTextBox ID="txt_longitude" runat="server" CssClass="form-control" Width="100%" Enabled="false" />
                        </div>
                    </div>

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-2 col-form-label">公尺 :</label>
                        <div class="col-sm-10 col-lg-4 row">
                            <telerik:RadTextBox ID="txt_meter" runat="server" CssClass="form-control" Width="100%" InputType="Number"   />
                        </div>
                    </div>

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-2 col-form-label">說明 :</label>
                        <div class="col-sm-10 col-lg-6 row">
                            <telerik:RadTextBox ID="RadTextBox1" runat="server" CssClass="form-control" Width="100%" />
                        </div>
                    </div>

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-2 col-form-label">
                            <telerik:RadButton ID="btnSearch" runat="server" Text="儲存" CssClass="btn btn-primary btn-sm"   > </telerik:RadButton>   <%--OnClick ="btn_Save_Coordinate_Click" --%>
                        </label>
                        <div class="col-sm-10 row">
                        </div>
                    </div>
                </div>
            </telerik:RadAjaxPanel>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
