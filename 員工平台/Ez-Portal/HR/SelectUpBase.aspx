<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="SelectUpBase.aspx.cs" Inherits="HR_SelectUpBase" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
    <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <legend>
            <asp:Label ID="lblSearch" runat="server" Text="查詢條件" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
        <asp:Label ID="Label1" runat="server" Text="修改日期：" meta:resourcekey="Label1Resource1"></asp:Label>
        <telerik:raddatepicker id="adate" runat="server" culture="Chinese (Taiwan)" meta:resourcekey="adateResource1">
                                <DateInput Skin="">
                                </DateInput></telerik:raddatepicker>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
            ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ControlToValidate="adate" ValidationGroup="group_date"
            meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
        <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
        <telerik:raddatepicker id="ddate" runat="server" culture="Chinese (Taiwan)" meta:resourcekey="ddateResource1">
                                <DateInput Skin="">
                                </DateInput></telerik:raddatepicker>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
            Display="Dynamic" Font-Size="X-Small" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date"
            meta:resourcekey="RequiredFieldValidator2Resource1">日期格式錯誤！</asp:RequiredFieldValidator>&nbsp;<br />
        <asp:Label ID="lblNobrHeader" runat="server" Text="工號：" meta:resourcekey="lblNobrHeaderResource1"></asp:Label>
        <asp:TextBox ID="tbSerchKey" runat="server" meta:resourcekey="tbSerchKeyResource1"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
            meta:resourcekey="Button1Resource1" />
    </fieldset>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="id" DataSourceID="ObjectDataSource1" SkinID="Yahoo" meta:resourcekey="GridView1Resource1">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                SortExpression="id" Visible="False" meta:resourcekey="BoundFieldResource1" />
            <asp:BoundField DataField="key_date" HeaderText="修改日期" SortExpression="key_date"
                meta:resourcekey="BoundFieldResource2" />
            <asp:BoundField DataField="nobr" HeaderText="修改人工號" SortExpression="nobr" meta:resourcekey="BoundFieldResource3" />
            <asp:BoundField DataField="name_c" HeaderText="修改人姓名" SortExpression="name_c" meta:resourcekey="BoundFieldResource4" />
            <asp:BoundField DataField="updescr" HeaderText="修改內容" SortExpression="updescr" HtmlEncode="False"
                meta:resourcekey="BoundFieldResource5" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBy_upbase"
        TypeName="HRDsTableAdapters.UpBaseRecordTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="nobr" Type="String" />
            <asp:Parameter Name="name_c" Type="String" />
            <asp:Parameter Name="updescr" Type="String" />
            <asp:Parameter Name="key_date" Type="DateTime" />
            <asp:Parameter Name="Original_id" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="nobr" Type="String" />
            <asp:Parameter Name="name_c" Type="String" />
            <asp:Parameter Name="updescr" Type="String" />
            <asp:Parameter Name="key_date" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="adate" Name="date_b" PropertyName="SelectedDate"
                Type="DateTime" />
            <asp:ControlParameter ControlID="ddate" Name="date_e" PropertyName="SelectedDate"
                Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete"
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBy_upbase"
        TypeName="HRDsTableAdapters.UpBaseRecordTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="nobr" Type="String" />
            <asp:Parameter Name="name_c" Type="String" />
            <asp:Parameter Name="updescr" Type="String" />
            <asp:Parameter Name="key_date" Type="DateTime" />
            <asp:Parameter Name="Original_id" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="nobr" Type="String" />
            <asp:Parameter Name="name_c" Type="String" />
            <asp:Parameter Name="updescr" Type="String" />
            <asp:Parameter Name="key_date" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="adate" Name="date_b" PropertyName="SelectedDate"
                Type="DateTime" />
            <asp:ControlParameter ControlID="ddate" Name="date_e" PropertyName="SelectedDate"
                Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
