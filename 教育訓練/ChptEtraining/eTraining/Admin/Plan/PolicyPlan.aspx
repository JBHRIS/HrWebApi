<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="PolicyPlan.aspx.cs" Inherits="eTraining_Admin_Plan_PolicyPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        年度計劃與目標</h2>
    年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="100px" AutoPostBack="True"
        OnSelectedIndexChanged="cbxYear_SelectedIndexChanged">
    </telerik:RadComboBox>
    <br />
    <br />
    <div style="background-color: #EEF5FC;">
        <table width="100%">
            <tr>
                <td style="width: 130px; vertical-align: text-top">
                    <asp:Label ID="Label1" runat="server" Text="經營願景(成立宗旨)" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <telerik:RadEditor ID="edtProspect" runat="server" Skin="Office2007" Width="100%"
                        ContentAreaMode="Div" EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                        Height="150px" ToolbarMode="ShowOnFocus">
                        <Content>
                        </Content>
                    </telerik:RadEditor>
                </td>
            </tr>
            <tr>
                <td style="width: 130px; vertical-align: text-top">
                    <asp:Label ID="Label2" runat="server" Text="經營目標(發展方向)" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <telerik:RadEditor ID="edtGoal" runat="server" Skin="Office2007" Width="100%" ContentAreaMode="Div"
                        EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml" Height="150px"
                        ToolbarMode="ShowOnFocus">
                        <Content>
                        </Content>
                    </telerik:RadEditor>
                </td>
            </tr>
            <tr>
                <td style="width: 130px; vertical-align: text-top">
                    <asp:Label ID="Label3" runat="server" Text="訓練政策(培育方針)" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <telerik:RadEditor ID="edtPolicy" runat="server" Skin="Office2007" Width="100%" ContentAreaMode="Div"
                        EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml" Height="150px"
                        ToolbarMode="ShowOnFocus">
                        <Content>
                        </Content>
                    </telerik:RadEditor>
                </td>
            </tr>
            <tr>
                <td style="width: 130px; vertical-align: text-top">
                    <asp:Label ID="Label4" runat="server" Text="備註說明" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <telerik:RadEditor ID="edtNote" runat="server" Skin="Office2007" Width="100%" ContentAreaMode="Div"
                        EditModes="Design" ToolsFile="~/Editor/RadEditor/BasicTools.xml" Height="150px"
                        ToolbarMode="ShowOnFocus">
                        <Content>
                        </Content>
                    </telerik:RadEditor>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <asp:CheckBox ID="cbEditable" runat="server" Text="可修改" OnCheckedChanged="cbEditable_CheckedChanged"
        AutoPostBack="True" />
    <br />
    <br />
    <telerik:RadButton ID="btnSave" runat="server" Text="存檔" ValidationGroup="g" OnClick="btnSave_Click">
    </telerik:RadButton>
    <br />
    
</asp:Content>
