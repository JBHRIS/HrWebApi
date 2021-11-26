<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Salary3.aspx.cs" Inherits="Salary_Salary3" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
      <asp:View ID="View1" runat="server">
       <asp:Panel ID="Panel1" runat="server">
    <table class="TableFullBorder">
                <tr>
                    <th align="right" colspan="2" style="text-align: center">
                        新增薪資密碼
                    </th>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="text-align: left">
                        <span style="color: red"><strong>※此密碼一經設定就無法變更，請謹慎設定您的密碼，並請不要告訴任何人。</strong></span>
                    </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" style="text-align: right" width="1%">
                        薪資密碼
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtPassWordNew" runat="server" CssClass="txtCode" MaxLength="10"
                            TextMode="Password" ValidationGroup="fv"></asp:TextBox>
                        <font color="red">※請輸入4~10位英文或數字的組合</font><asp:RequiredFieldValidator ID="rfvPassWordNew"
                            runat="server" ControlToValidate="txtPassWordNew" Display="None" ErrorMessage="不允許空白"
                            SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" style="text-align: right" width="1%">
                        確認薪資密碼
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtPassWordAgain" runat="server" CssClass="txtCode" MaxLength="10"
                            TextMode="Password" ValidationGroup="fv"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassWordAgain" runat="server" ControlToValidate="txtPassWordAgain"
                            Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" nowrap="true" width="1%">
                        &nbsp;
                    </td>
                    <td style="text-align: left">
                        <asp:Button ID="btnAddPassWord" runat="server" Text="新增" ValidationGroup="fv" OnClick="btnAddPassWord_Click" />
                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
    </asp:Panel>
      </asp:View>
       <asp:View ID="View2" runat="server"  ClientIDMode="Static">
       <asp:Panel ID="Panel2" runat="server">
   <table class="TableFullBorder">
                <tr>
                    <th align="right" colspan="2" style="text-align: center">
                        薪資資料查詢
                    </th>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        年/月/期別
                    </th>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" DataSourceID="sdsYear"
                            DataTextField="sText" DataValueField="sValue">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" DataSourceID="sdsMonth"
                            DataTextField="sText" DataValueField="sValue">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSeq" runat="server" DataSourceID="sdsSeq" DataTextField="sText"
                            DataValueField="sValue">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        身分證字號
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtID" runat="server" CssClass="txtCode" TextMode="Password" ValidationGroup="fvSalary"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvID" runat="server" ControlToValidate="txtID" Display="None"
                            ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fvSalary"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        薪資密碼
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtPassWord" runat="server" CssClass="txtCode" MaxLength="10" TextMode="Password"
                            ValidationGroup="fvSalary"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassWord" runat="server" ControlToValidate="txtPassWord"
                            Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fvSalary"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td style="text-align: left">
                        <asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" ValidationGroup="fvSalary"
                            ClientIDMode="Static" />
                        <asp:CheckBox ID="ckSalary" runat="server" Text="English version for foreign employee"
                            Visible="False" />
                        <asp:Label ID="lblPassCount" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2" style="text-align: left">
                        <span style="color: red">由於安全性嚴謹的考量，如果點「查詢」沒有反應，請重新登入此頁再進行查詢。<asp:SqlDataSource ID="sdsYear"
                            runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>" SelectCommand="SELECT DISTINCT SUBSTRING(RTRIM(A.YYMM), 0, 5) AS sValue, SUBSTRING(RTRIM(A.YYMM), 0, 5) + '年' AS sText FROM LOCK_WAGE A,WAGE B WHERE A.YYMM=B.YYMM AND A.SEQ=B.SEQ AND B.ADATE <=GETDATE() ORDER BY sValue DESC "
                            ProviderName="<%$ ConnectionStrings:HRSqlServer.ProviderName %>"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="sdsMonth" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                                SelectCommand="SELECT DISTINCT SUBSTRING(RTRIM(A.YYMM), 5, 2) AS sValue, SUBSTRING(RTRIM(A.YYMM), 5, 2) + '月' AS sText FROM LOCK_WAGE A,WAGE B WHERE (SUBSTRING(RTRIM(A.YYMM), 0, 5) = @YY) AND A.YYMM=B.YYMM AND A.SEQ=B.SEQ AND B.ADATE <=GETDATE()  ORDER BY sValue DESC "
                                ProviderName="<%$ ConnectionStrings:HRSqlServer.ProviderName %>">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlYear" DefaultValue="0" Name="YY" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="sdsSeq" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                                SelectCommand="SELECT DISTINCT RTRIM(A.SEQ) AS sValue, RTRIM(A.MENO) AS sText FROM LOCK_WAGE A,WAGE B  WHERE (A.YYMM = @YY + @MM) AND A.YYMM=B.YYMM AND A.SEQ=B.SEQ AND B.ADATE <=GETDATE()"
                                ProviderName="<%$ ConnectionStrings:HRSqlServer.ProviderName %>">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlYear" Name="YY" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlMonth" Name="MM" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                       
                        <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                       
                        </span>
                    </td>
                </tr>
            </table>      
                        </asp:Panel>
 <asp:Panel ID="Panel3" runat="server">
 <span style="color: red">
         <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
         </span>
         <rsweb:ReportViewer ID="RptViewer" runat="server" Height="600px" 
        Width="830px" Visible="False" ShowExportControls="False">
         </rsweb:ReportViewer>
    </asp:Panel>
                       
       </asp:View>
     <asp:View ID="View3" runat="server">
     
     </asp:View>
     </asp:MultiView>
</asp:Content>

