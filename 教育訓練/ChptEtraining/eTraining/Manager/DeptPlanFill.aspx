<%@ Page Title="填寫員工年度訓練需求強度" Language="C#" MasterPageFile="~/mpTraining.master"
    AutoEventWireup="true" CodeFile="DeptPlanFill.aspx.cs" Inherits="eTraining_Manager_PlanFill" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2 { text-align: center; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
        //<![CDATA[

        //Standard Window.confirm
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("送出後即無法修改，確認送出?"));
        }

        //RadConfirm
        function RadConfirm(sender, args) {
            var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
                if (shouldSubmit) {
                    this.click();
                }
            });

            var text = "Are you sure you want to submit the page?";
            radconfirm(text, callBackFunction, 300, 100, null, "RadConfirm");
            args.set_cancel(true);
        }
        //]]>    
    </script>
    <div>
        <div>
            <h2>
                填寫部門年度訓練需求強度</h2>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
                <div style="color: #0000FF">
                    請依照您的部屬所需增加的能力，填寫需求。 共分為四大項：一般管理技能、人際關係、主管人員管理發展訓練、創造力與自主管理。 如有未包含至以上四大類的課程，可自行新增。
                    所需強度最強的填寫5、所需強度最弱的填寫1、如尚未需要的即不需填寫。 最低填選一個選項，不限定填選幾項。
                </div>
                <br />
                <div>
                    年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" AutoPostBack="True"
                        OnLoad="cbxYear_Load" OnSelectedIndexChanged="cbxYear_SelectedIndexChanged">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" />
                            <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" />
                        </Items>
                    </telerik:RadComboBox>
                </div>
                <br />
                <div style="background-color: #CDE5FF; float: left; width: 18%" class="funcblock">
                    <br />
                    <br />
                </div>
                <div style="float: right; width: 80%; height: 264px;">
                    <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <telerik:RadGrid ID="gvQuest" runat="server" CellSpacing="0" GridLines="None" Skin="Outlook"
                        OnItemDataBound="gvQuest_ItemDataBound" AutoGenerateColumns="False" Culture="zh-TW"
                        OnNeedDataSource="gvQuest_NeedDataSource">
                        <MasterTableView DataKeyNames="Id">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="CatName" FilterControlAltText="Filter CatName column"
                                    HeaderText="類別" SortExpression="CatName" UniqueName="CatName">
                                    <HeaderStyle Width="170px" Wrap="False" />
                                    <ItemStyle Width="170px" Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataType="System.Int32" FilterControlAltText="Filter DemandIntensity column"
                                    HeaderText="需求(1-5)" SortExpression="DemandIntensity" UniqueName="tplDemandIntensity">
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="ntbDemandIntensity" runat="server" DataType="System.Int32"
                                        DbValue='<%# Bind("DemandIntensity") %>'  MaxValue="5" MinValue="0">
                                            <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="CatCode" FilterControlAltText="Filter CatCode column"
                                    HeaderText="類別代碼" UniqueName="CatCode" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" UniqueName="Id"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    <hr />
                    <div style="float: left; width: 31%">
                        <telerik:RadTextBox ID="tbCourseName" runat="server" Width="150px" Skin="Windows7">
                        </telerik:RadTextBox>
                        &nbsp;&nbsp;&nbsp;
                        <telerik:RadButton ID="rbtnAddCourse" runat="server" Text="新增項目" OnClick="rbtnAddCourse_Click"
                            Skin="Windows7">
                        </telerik:RadButton>
                    </div>
                    <div style="float: right; width: 50%">
                        <telerik:RadGrid ID="gvQuestCustom" runat="server" CellSpacing="0" GridLines="None"
                            OnItemDataBound="gvOtherQuest_ItemDataBound" AutoGenerateColumns="False" Culture="zh-TW"
                            OnNeedDataSource="gvQuestCustom_NeedDataSource" 
                            oninsertcommand="gvQuestCustom_InsertCommand" 
                            onitemcommand="gvQuestCustom_ItemCommand">
                            <MasterTableView DataKeyNames="Id">
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="CourseName" FilterControlAltText="Filter CourseName column"
                                        HeaderText="課程名稱" SortExpression="CourseName" UniqueName="CourseName">
                                        <ItemStyle Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataType="System.Int32" FilterControlAltText="Filter DemandIntensity column"
                                        HeaderText="需求分數" SortExpression="tplDemandIntensity" UniqueName="tplDemandIntensity">
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="ntbDemandIntensity" runat="server" MaxValue="5" MinValue="0" DbValue='<%# Bind("DemandIntensity") %>'> 
                                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridButtonColumn CommandName="CmdDel" ConfirmText="確認是否刪除?" 
                                        FilterControlAltText="Filter CmdDel column" Text="刪除" UniqueName="CmdDel">
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" 
                                        UniqueName="Id" Visible="False">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                    </div>
                    <br />
                    <hr />
                    <table style="width: 100%">
                        <tr>
                            <td class="style2">
                                <telerik:RadButton ID="btnSave" runat="server" Text="存檔" Skin="Windows7" OnClick="btnSave_Click">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadAjaxPanel>
        </div>
    </div>
</asp:Content>
