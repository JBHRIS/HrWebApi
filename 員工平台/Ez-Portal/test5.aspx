<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test5.aspx.cs" Inherits="test5" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="Templet/SelectEmp2.ascx" TagName="SelectEmp2" TagPrefix="uc1" %>
<%@ Register Src="Templet/SelectEmp3.ascx" TagName="SelectEmp3" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
          //<![CDATA[
            function callcall() {
                var btn = $find("<%=Button10.ClientID %>");
                btn.click();
            }

            function onClientFileUploaded(sender, args) {
            }

            function updatePictureAndInfo() {
                var upload = $find("<%=RadAsyncUpload1.ClientID %>");

                if (upload.getUploadedFiles().length > 0) {// && (combo.get_selectedItem() != null)) {
                    __doPostBack('RadButton1', 'RadButton1Args');
                }
                else {
                    alert("Please select a picture/country");
                }
            }
          //]]>
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <div>
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="xml" />
        <telerik:RadTreeView ID="tv" runat="server">
        </telerik:RadTreeView>
        <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Button" />
        <br />
        <telerik:RadMenu ID="RadMenu1" runat="server">
        </telerik:RadMenu>
        <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Button" />
        <br />
        <telerik:RadDatePicker ID="RadDatePicker1" runat="server">
        </telerik:RadDatePicker>
    </div>
    <p>
    </p>
    <telerik:RadGrid ID="gv" runat="server" OnItemDataBound="gv_ItemDataBound" OnNeedDataSource="gv_NeedDataSource"
        OnPreRender="gv_PreRender">
    </telerik:RadGrid>
    <telerik:RadDateTimePicker ID="RadDateTimePicker1" runat="server" Culture="zh-TW">
        <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm">
        </TimeView>
        <TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>
        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
        </Calendar>
        <DateInput DisplayDateFormat="yyyy/M/d HH:mm" DateFormat="yyyy/M/d HH:mm" DisplayText=""
            LabelWidth="40%" type="text" value="">
        </DateInput>
        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
    </telerik:RadDateTimePicker>
    <telerik:RadDatePicker ID="RadDatePicker2" runat="server">
    </telerik:RadDatePicker>
    <div style="background-color: #A2C0FF; border-bottom-style: groove; border-bottom-width: thin;
        border-bottom-color: #A1A1A1;">
    </div>
    <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" PostbackTriggers="Button10,RadAsyncUpload1"
        OnFileUploaded="RadAsyncUpload1_FileUploaded">
    </telerik:RadAsyncUpload>
    <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Button" />
    <asp:ImageButton ID="Button10" runat="server" OnClick="Button10_Click" Text="Button" />
    <br />
    <asp:CheckBox ID="CheckBox1" runat="server" Text="testttttt" />
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>222</asp:ListItem>
    </asp:RadioButtonList>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" onFocus="this.select()"></asp:TextBox>
    </p>
    <uc2:SelectEmp3 ID="SelectEmp31" runat="server" />
    <p>
        <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Button" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC"
            BorderWidth="1px" CellPadding="1" DayNameFormat="Short" Font-Size="12pt" ForeColor="#003399"
            Height="600px" ShowGridLines="True" Width="600px">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCFF" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#FF9797" />
            <OtherMonthDayStyle ForeColor="#999999" Font-Size="X-Small" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <DayStyle BackColor="White" HorizontalAlign="Right" VerticalAlign="Top" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#339933" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="White" BorderColor="#C1CDD8" BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" ForeColor="Black" Height="25px" />
        </asp:Calendar>
        <asp:Calendar ID="Calendar2" runat="server" SkinID="Chpt">
            <OtherMonthDayStyle BackColor="#E0E0E0" />
        </asp:Calendar>
    </p>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>