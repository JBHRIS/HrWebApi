<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppQRCode.aspx.cs" Inherits="Portal.AppQRCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="ibox-content">
        

         <div class="hr-line-dashed"></div>
        <div class="form-group  row">
            <label class="col-sm-2 col-form-label">QR Code : </label>
            <div class="col-sm-10 col-lg-4 row">
                <telerik:RadTextBox ID="txt_QRCode" runat="server" CssClass="form-control" Width="100%" />
            </div>
        </div>




        <div class="hr-line-dashed"></div>
        <div class="form-group  row">
            <label class="col-sm-2 col-form-label">QRCode 照片寬度 :</label>
            <div class="col-sm-10 col-lg-4 row">
                <telerik:RadTextBox ID="txt_SetWidth" runat="server" CssClass="form-control" Width="100%" InputType="Number" />
            </div>
        </div>

        <div class="hr-line-dashed"></div>
        <div class="form-group  row">
            <label class="col-sm-2 col-form-label">QRCode 照片高度 :</label>
            <div class="col-sm-10 col-lg-4 row">
                <telerik:RadTextBox ID="txt_SetHeight" runat="server" CssClass="form-control" Width="100%" InputType="Number" />
            </div>
        </div>



        <div class="hr-line-dashed"></div>
        <div class="form-group  row">
            <label class="col-sm-2 col-form-label">
                <telerik:RadButton ID="RadButton1" runat="server" Text="產生 QR Code" CssClass="btn btn-primary btn-sm" OnClick="btn_QRCode_Click" />
            </label>
            <div class="col-sm-10 row">
                 <telerik:RadLabel ID="lblMsg" runat="server"  />
            </div>
        </div>


        <div class="hr-line-dashed"></div>
        <div class="form-group  row">
          
            <div class="col-sm-12 row">
                <asp:Image ID="imgageQRCode" runat="server"
            Visible="false" />
            </div>
        </div>


        
         <div class="hr-line-dashed"></div>
        <div class="form-group  row">
          
           <label class="col-sm-2 col-lg-2  col-form-label">
                <telerik:RadButton ID="btn_QRCode_Decode" runat="server" Text="解析 QR Code" CssClass="btn btn-primary btn-sm" OnClick="btn_QRCode_Decode_Click" />
            </label>
            <div class="col-sm-10 col-lg-4 row">
                <telerik:RadTextBox ID="txt_QRCode_Decode" runat="server" CssClass="form-control" Width="100%"  Enabled ="false" />
            </div>
        </div>

    </div>






</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
