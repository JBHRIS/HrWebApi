<%@ Page Title="填寫個人年度訓練需求調查表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="PlanFillS.aspx.cs" Inherits="eTraining_Admin_PlanFillS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
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
    <div style="color: #0000FF">
        <h2>
            填寫個人年度訓練需求調查表</h2>
            <div style="color: #0000FF">
共分為四大項：一般管理技能、人際關係、主管人員管理發展訓練、創造力與自主管理。
如有未包含至以上四大類的課程，請自行新增。
請依照您的需求填寫，所需強度最強的填寫5、所需強度最弱的填寫1、如尚未需要的即不需填寫。
最低請填選一個選項，不限定填選幾項。  
</div>
                <br />
                    年度&nbsp;<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" OnSelectedIndexChanged="cbxYear_SelectedIndexChanged"
            AutoPostBack="True" OnLoad="cbxYear_Load">
            <Items>
                <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" Owner="cbxYear" />
                <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" Owner="cbxYear" />
            </Items>
        </telerik:RadComboBox>
        <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <br />
                        <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Skin="Vista"
            DataSourceID="sdsTrainingQuest" Width="70%" 
            OnItemDataBound="gv_ItemDataBound" Culture="zh-TW" GridLines="None">
            <MasterTableView AutoGenerateColumns="False" DataSourceID="sdsTrainingQuest" DataKeyNames="iAutoKey">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                        HeaderText="類別" SortExpression="sName" UniqueName="sName">
                        <HeaderStyle Width="180px" />
                        <ItemStyle Width="180px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                        HeaderText="課程編號" SortExpression="sCode" UniqueName="sCode" 
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sName1" FilterControlAltText="Filter sName1 column"
                        HeaderText="課程" SortExpression="sName1" UniqueName="sName1">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter COL_P column" HeaderText="個人強度(1-5)"
                        UniqueName="COL_P">
                        <ItemTemplate>
                            <telerik:RadNumericTextBox ID="ntbP" runat="server" Culture="zh-TW" DataType="System.Int16"
                                MaxValue="5" MinValue="0" Width="50px" 
                                DbValue='<%# Bind("iDemandIntensityP") %>'>
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" Wrap="False" />
                        <ItemStyle Width="80px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter COL_M column"
                        HeaderText="主管強度(1-5)" UniqueName="COL_M" Visible="False">
                        <ItemTemplate>
                            <telerik:RadNumericTextBox ID="ntbM" runat="server" Culture="zh-TW" DataType="System.Int16"
                                MaxValue="5" MinValue="0" Value="0" Width="30px" Enabled="False">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="catCode" 
                        FilterControlAltText="Filter catCode column" UniqueName="catCode" 
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
        <br />
        <div style="float: left; width:31%">
            <telerik:RadTextBox ID="tbCourseName" runat="server" Width="150px" 
                Skin="Windows7">
            </telerik:RadTextBox>
            &nbsp;&nbsp;&nbsp;
            <telerik:RadButton ID="rbtnAddCourse" runat="server" Text="新增課程" 
                onclick="rbtnAddCourse_Click" Skin="Windows7" >
            </telerik:RadButton>
        </div>
        <div style="float: right; width: 67%">
            <telerik:RadGrid ID="gvCustom" runat="server" AutoGenerateColumns="False" 
                CellSpacing="0" DataSourceID="sdsCustom" GridLines="None" Culture="zh-TW" 
                Width="55%" Skin="Windows7">
<MasterTableView datakeynames="iAutoKey" datasourceid="sdsCustom" allowautomaticdeletes="True">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="sCourseName" 
            FilterControlAltText="Filter sCourseName column" HeaderText="自訂課程名稱" 
            SortExpression="sCourseName" UniqueName="sCourseName">
            <ItemStyle Wrap="False" />
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn DataField="iDemandIntensityP" 
            DataType="System.Int32" FilterControlAltText="Filter iDemandIntensityP column" 
            HeaderText="個人強度(1-5)" SortExpression="iDemandIntensityP" 
            UniqueName="iDemandIntensityP">
            <EditItemTemplate>
                <asp:TextBox ID="iDemandIntensityPTextBox" runat="server" 
                    Text='<%# Bind("iDemandIntensityP") %>' Width="50px"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <telerik:RadNumericTextBox ID="ntbCP" runat="server" Culture="zh-TW" 
                    DataType="System.Int16" DbValue='<%# Bind("iDemandIntensityP") %>' MaxValue="5" 
                    MinValue="0" Width="50px">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </ItemTemplate>
            <HeaderStyle Width="80px" Wrap="False" />
            <ItemStyle Width="80px" />
        </telerik:GridTemplateColumn>
        <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Delete" 
            FilterControlAltText="Filter column column" Text="刪除" UniqueName="column">
            <HeaderStyle Width="40px" />
            <ItemStyle Width="40px" />
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="sNobr" 
            FilterControlAltText="Filter sNobr column" HeaderText="sNobr" 
            SortExpression="sNobr" UniqueName="sNobr" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iDemandIntensityPdate" 
            DataType="System.DateTime" 
            FilterControlAltText="Filter iDemandIntensityPdate column" 
            HeaderText="iDemandIntensityPdate" SortExpression="iDemandIntensityPdate" 
            UniqueName="iDemandIntensityPdate" Visible="False">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
            </telerik:RadGrid>
        </div>
        <br />
        &nbsp;<asp:SqlDataSource ID="sdsTrainingQuest" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            SelectCommand="select tq.iAutoKey ,cat.sName,cat.sCode catCode,co.sCode,co.sName,tq.iDemandIntensityP,tq.iDemandIntensityM from trTrainingQuest tq
join trRequirementTemplateCat  cat on tq.sKey=cat.sCode
join trCourse co on tq.trCourse_sCode=co.sCode
where tq.sNobr=@sNobr and tq.iYear=@Year
order by cat.sName">
            <SelectParameters>
                <asp:Parameter Name="sNobr" />
                <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="Year" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <asp:SqlDataSource ID="sdsCustom" runat="server" 
            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
            DeleteCommand="delete  [trTrainingQuestCustom] WHERE iAutoKey = @iAutoKey" 
            SelectCommand="SELECT * FROM [trTrainingQuestCustom] WHERE (([iYear] = @Year) AND ([sNobr] = @sNobr))">
            <DeleteParameters>
                <asp:Parameter Name="iAutoKey" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="Year" 
                    PropertyName="SelectedValue" />
                <asp:Parameter Name="sNobr" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <br />
        <br />
        <table class="style1">
        <tr><td></td></tr>
            <tr>
                <td class="style2">
            <telerik:RadButton ID="btnSave" runat="server" Text="存檔" OnClick="btnSave_Click"
                Skin="Windows7">
            </telerik:RadButton>
            &nbsp;&nbsp;&nbsp;
            <telerik:RadButton ID="btnCheck" runat="server" Text="確認送出" Skin="Windows7" 
                        OnClick="btnCheck_Click" onclientclicking="StandardConfirm">
            </telerik:RadButton>
                </td>
            </tr>
        </table>               
    </div>
</asp:Content>
