<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyTax.ascx.cs" Inherits="Templet_MyTax" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
    Width="100%" HorizontalAlign="NotSet" meta:resourcekey="RadAjaxPanel1Resource1">
            <h3>
                <asp:Label ID="lblHeader" runat="server" Text="My Tax" 
                    meta:resourcekey="lblHeaderResource1"></asp:Label>
            </h3>
        <table width="70%">
            <tr>
                <td width="10%">
                    <asp:Label ID="lblRetRate" runat="server" Text="勞退自提：" 
                        meta:resourcekey="lblRetRateResource1"></asp:Label>
                </td>
                <td width="60%">
                    <asp:Label ID="lblPay" runat="server" meta:resourcekey="lblPayResource1"></asp:Label>
                    <asp:Label ID="Label1"
                        runat="server" Text="%" meta:resourcekey="Label1Resource1"></asp:Label>
                    <telerik:RadButton ID="btnPensionEdit" runat="server" 
                        onclick="btnPensionEdit_Click" Text="Edit" 
                        meta:resourcekey="btnPensionEditResource1">
                    </telerik:RadButton>
                    <asp:Panel ID="pnlPension" runat="server" Visible="False" Width="100%" 
                        meta:resourcekey="pnlPensionResource1">
                        <asp:Label ID="lblInputTax0" runat="server" Text="稅率值：" 
                            meta:resourcekey="lblInputTax0Resource1"></asp:Label>
                        <telerik:RadNumericTextBox ID="ntbInputPensionRate" runat="server" 
                            Culture="(Default)" DataType="System.Int32" MaxValue="6" MinValue="0" 
                            Width="60px" DisplayText="" LabelCssClass="" LabelWidth="64px" 
                            meta:resourcekey="ntbInputPensionRateResource1">
                            <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                        </telerik:RadNumericTextBox>
                        <telerik:RadButton ID="btnPensionSubmit" runat="server" 
                            onclick="btnPensionSubmit_Click" Text="Submit" 
                            meta:resourcekey="btnPensionSubmitResource1">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnPensionCancel" runat="server" 
                            onclick="btnPensionCancel_Click" Text="Cancel" 
                            meta:resourcekey="btnPensionCancelResource1">
                        </telerik:RadButton>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblIncomeTax" runat="server" Text="所得稅率：" 
                        meta:resourcekey="lblIncomeTaxResource1"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblIncomeTaxNum" runat="server" 
                        meta:resourcekey="lblIncomeTaxNumResource1"></asp:Label>
                    <asp:Label ID="lblTaxPostfix"
                        runat="server" Text="%" meta:resourcekey="lblTaxPostfixResource1"></asp:Label>
                    <telerik:RadButton ID="btnTaxEdit" runat="server" onclick="btnTaxEdit_Click" 
                        Text="Edit" meta:resourcekey="btnTaxEditResource1">
                    </telerik:RadButton>
                    <asp:Panel ID="pnlTaxForm" runat="server" Visible="False" Width="100%" 
                        meta:resourcekey="pnlTaxFormResource1">
                        <asp:CheckBox ID="cbFixRate" runat="server" Text="固定稅率" AutoPostBack="True" 
                            oncheckedchanged="cbFixRate_CheckedChanged" 
                            meta:resourcekey="cbFixRateResource1" />　　                        
                        <asp:Label ID="lblInputTax" runat="server" Text="稅率值：" 
                            meta:resourcekey="lblInputTaxResource1"></asp:Label>
                        <telerik:RadNumericTextBox ID="ntbInputTaxFixRate" runat="server" 
                            Culture="(Default)" MinValue="0" Width="60px" DataType="System.Int32" 
                            MaxValue="50" DisplayText="" LabelCssClass="" LabelWidth="64px" 
                            meta:resourcekey="ntbInputTaxFixRateResource1">
                            <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                        </telerik:RadNumericTextBox>
                        <telerik:RadButton ID="btnTaxSubmit" runat="server" 
                            onclick="btnTaxSubmit_Click" Text="Submit" 
                            meta:resourcekey="btnTaxSubmitResource1">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnTaxCancel" runat="server" 
                            onclick="btnTaxCancel_Click" Text="Cancel" 
                            meta:resourcekey="btnTaxCancelResource1">
                        </telerik:RadButton>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblNobr" runat="server" Visible="False" 
                meta:resourcekey="lblNobrResource1"></asp:Label>
</telerik:RadAjaxPanel>
