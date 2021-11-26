<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="SurveyTemplates4.aspx.cs" Inherits="eTraining_Admin_Plan_SurveyTemplates4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        調查範本設定
    </h2>
    <%--RadAjaxLoadingPanel--%>
    <telerik:RadAjaxLoadingPanel ID="AjaxLP_Loading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <%--RadAjaxPanel--%>
    <telerik:RadAjaxPanel ID="AjaxP_Main" runat="server" LoadingPanelID="AjaxLP_Loading">
        <%--RadGrid--%>
        <telerik:RadGrid ID="Gv_Main" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Skin="Windows7" Culture="zh-TW" OnItemCommand="Gv_Main_ItemCommand" OnNeedDataSource="Gv_Main_NeedDataSource">
            <MasterTableView DataKeyNames="sName,sCode">
                <Columns>
                    <telerik:GridTemplateColumn>
                        <HeaderTemplate>
                            範本名稱
                            <telerik:RadButton ID="Btn_Add" runat="server" Text="新增" CommandName="AddData" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "sName")%>
                        </ItemTemplate>
                        <ItemStyle Width="100px" Wrap="False" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <telerik:RadButton ID="Btn_Link" runat="server" Text="編輯課程" CommandName="LinkData" />
                            <telerik:RadButton ID="Btn_Edit" runat="server" Text="檢視範本" CommandName="EditData" />
                        </ItemTemplate>
                        <ItemStyle Width="100px" Wrap="False" />
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <%--RadWindow--%>
        <telerik:RadWindow runat="server" ID="Wd_AddData" Modal="true" Title="新增範本" Height="200">
            <Shortcuts>
                <telerik:WindowShortcut CommandName="Close" Shortcut="Esc" />
            </Shortcuts>
            <ContentTemplate>
                <table style="width: 100%; height: 100%;">
                    <tr style="height: 80%;">
                        <td>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="TB_AddData_Name">範本名稱</asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="TB_AddData_Name" runat="server" />
                        </td>
                        <td>
                            <telerik:RadButton ID="Btn_AddData_Save" runat="server" Text="儲存" OnClick="Btn_AddData_Save_Click" />
                        </td>
                    </tr>
                    <tr style="height: 20%;">
                        <td colspan="3" style="text-align: center;">
                            <asp:Label ID="Lbl_AddData_Msg" runat="server" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </telerik:RadWindow>
        <%--RadWindow--%>
        <telerik:RadWindow runat="server" ID="Wd_LinkData" Modal="true" Width="800" Height="650">
            <Shortcuts>
                <telerik:WindowShortcut CommandName="Close" Shortcut="Esc" />
            </Shortcuts>
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="left" valign="top">
                            <telerik:RadTreeView ID="TV_Course" runat="server" MultipleSelect="True" Width="350" Height="550" />
                        </td>
                        <td align="center" valign="middle">
                            <asp:Button ID="Btn_LinkData_Add" runat="server" Text="新增=>" CommandArgument="" OnCommand="Btn_LinkData_Add_Command" />
                        </td>
                        <td align="left" valign="top">
                            <table>
                                <tr>
                                    <td>
                                        <telerik:RadListBox ID="LB_LinkData_Course" runat="server" AllowReorder="True" AllowDelete="True" Width="350" Height="500" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadButton ID="Btn_LinkData_Save" runat="server" Text="儲存" CommandArgument="" OnCommand="Btn_LinkData_Save_Command" />
                                        <telerik:RadButton ID="Btn_LinkData_Cancel" runat="server" Text="取消" CommandArgument="" OnCommand="Btn_LinkData_Cancel_Command" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </telerik:RadWindow>
        <%--RadWindow--%>
        <telerik:RadWindow runat="server" ID="Wd_EditData" Modal="true" Width="700" Height="650">
            <Shortcuts>
                <telerik:WindowShortcut CommandName="Close" Shortcut="Esc" />
            </Shortcuts>
            <ContentTemplate>
                <asp:HiddenField runat="server" ID="HidFld_sCode" Visible="false" Value="" />
                <telerik:RadGrid ID="Gv_LinkCourse" runat="server" AutoGenerateColumns="False" OnItemCommand="Gv_LinkCourse_ItemCommand" Width="680">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <AlternatingItemStyle HorizontalAlign="Left"></AlternatingItemStyle>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <MasterTableView EditMode="InPlace" DataKeyNames="ID">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="課程名稱">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "CourseName")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "CourseName")%>
                                </EditItemTemplate>
                                <ItemStyle Width="60%" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="外訓課程預估費用/位">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Budget")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadNumericTextBox ID="Btn_TempBudget" runat="server" Skin="Web20" Width="100px" DataType="Int32" DbValue='<%# Bind("Budget")%>' MinValue="0" NumberFormat-DecimalDigits="0" />
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="Btn_TempBudget" />
                                    <%--<asp:RegularExpressionValidator runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="Btn_TempBudget" ValidationExpression="^(0|[1-9][0-9]*)$" />--%>
                                </EditItemTemplate>
                                <ItemStyle Width="20%" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridEditCommandColumn ButtonType="PushButton" UpdateText="儲存" CancelText="取消" EditText="編輯">
                                <ItemStyle Width="20%" />
                            </telerik:GridEditCommandColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </ContentTemplate>
        </telerik:RadWindow>
    </telerik:RadAjaxPanel>
</asp:Content>
