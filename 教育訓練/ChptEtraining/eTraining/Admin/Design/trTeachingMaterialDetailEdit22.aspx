<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trTeachingMaterialDetailEdit22.aspx.cs" MasterPageFile="~/mpEdit.master"
    Inherits="eTraining_Admin_Design_trTeachingMaterialDetailEdit22" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
            GetRadWindow().close();
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

            return oWindow;
        }

        function CancelEdit() {
            GetRadWindow().close();
        }
    </script>
    <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" 
        DataSourceID="sdsFV" onitemcommand="fv_ItemCommand" 
        oniteminserting="fv_ItemInserting" onitemupdating="fv_ItemUpdating">
        <EditItemTemplate>
            <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' 
                Visible="False" />
            <br />            
           <table class="tableBlue">
                <tr>
                    <th>
                        教學方法</th>
                    <td>
                        <telerik:RadComboBox ID="RadComboBox1" Runat="server" CheckBoxes="true" 
                            DataSourceID="sdsTrainingMethod">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        教學資源</th>
                    <td>
                        <telerik:RadComboBox ID="RadComboBox2" Runat="server">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        時間</th>
                    <td>
                        <telerik:RadNumericTextBox ID="RadNumericTextBox1" Runat="server">
                        </telerik:RadNumericTextBox>
                        分鐘</td>
                </tr>
                <tr>
                    <th>
                        備註</th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox1" Runat="server">
                        </telerik:RadTextBox>
                    </td>
                </tr>
            </table>
            &nbsp;<telerik:RadButton ID="UpdateRbtn" runat="server" CommandName="Update" 
                Text="更新">
            </telerik:RadButton>
            <telerik:RadButton ID="UpdateCancelRbtn" runat="server" CommandName="Cancel" 
                Text="取消">
            </telerik:RadButton>
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="tableBlue">
                <tr>
                    <th>
                        教學方法</th>
                    <td>
                        <telerik:RadComboBox ID="RadComboBox1" Runat="server" CheckBoxes="true" 
                            DataSourceID="sdsTrainingMethod" DataTextField="sName" 
                            DataValueField="sCode">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        教學資源</th>
                    <td>
                        <telerik:RadComboBox ID="RadComboBox2" Runat="server" CheckBoxes="True">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        時間</th>
                    <td>
                        <telerik:RadNumericTextBox ID="RadNumericTextBox1" Runat="server">
                        </telerik:RadNumericTextBox>
                        分鐘</td>
                </tr>
                <tr>
                    <th>
                        備註</th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox1" Runat="server">
                        </telerik:RadTextBox>
                    </td>
                </tr>
            </table>
            <br />
&nbsp;<telerik:RadButton ID="InsertRbtn" runat="server" CommandName="Insert" Text="新增">
            </telerik:RadButton>
            <telerik:RadButton ID="InsertCancelRBtn" runat="server" CommandName="Cancel" 
                Text="取消">
            </telerik:RadButton>
        </InsertItemTemplate>
        <ItemTemplate>
            iAutoKey:
            <asp:Label ID="iAutoKeyLabel" runat="server" Text='<%# Eval("iAutoKey") %>' />
            <br />
            trCourse_sCode:
            <asp:Label ID="trCourse_sCodeLabel" runat="server" 
                Text='<%# Bind("trCourse_sCode") %>' />
            <br />
            sCode:
            <asp:Label ID="sCodeLabel" runat="server" Text='<%# Bind("sCode") %>' />
            <br />
            sCoursePolicy:
            <asp:Label ID="sCoursePolicyLabel" runat="server" 
                Text='<%# Bind("sCoursePolicy") %>' />
            <br />
            sCourseExpect:
            <asp:Label ID="sCourseExpectLabel" runat="server" 
                Text='<%# Bind("sCourseExpect") %>' />
            <br />
            sKeyMan:
            <asp:Label ID="sKeyManLabel" runat="server" Text='<%# Bind("sKeyMan") %>' />
            <br />
            dKeyDate:
            <asp:Label ID="dKeyDateLabel" runat="server" Text='<%# Bind("dKeyDate") %>' />
            <br />

        </ItemTemplate>
    </asp:FormView>
    <br />

    <br />
    <asp:SqlDataSource ID="sdsTrainingMethod" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="SELECT [sCode], [sName] FROM [trTeachingMethod]">
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        </style>
</asp:Content>

