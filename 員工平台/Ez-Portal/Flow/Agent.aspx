<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Agent.aspx.cs" Inherits="Flow_Agent" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<span class="tag">請選擇欲設定的代理人：<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="WorkAgent.aspx">工作代理人</asp:LinkButton>｜<asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="CheckAgent.aspx">簽核代理人</asp:LinkButton></span>
<h5>一、工作代理人</h5>
目的：將您的表單流程，在您需要的時候，可以讓他人代替您完成申請的動作。<br />
應用：假設甲生病無法來上班，而乙是甲的工作代理人，則乙可以用乙自己的帳號登入後，在代理申請的項目中，會看到甲的姓名與可代理申請的流程，然後直接幫甲完成請假的動作。<br />
設定：
<ol style="color:#CC0000">
<li>指定一個成員。</li>
<li>指定該成員可以代替您申請的流程有那些？</li>
</ol>
<b>PS：如未指定流程則表示所有流程，工作代理人皆有權代理。</b>
<h5>二、簽核代理人</h5>
目的：您可以賦予某人一個權力，在您需要的時候代替您做出決策。<br />
應用：假設某甲外出，而甲的部屬送出一張假單，而乙是甲的簽核代理人，則乙可以代替甲決定這張假單是要核准或駁回。<br />
設定：
<ol style="color:#CC0000">
<li>順位簽核代理人
<ol style="list-style-type:upper-alpha;color:#333333">
<li>可以最多指定到三位代理人，分別為第一、第二、第三順位代理人。</li>
<li>順位代理人，唯獨在本人的狀態為啟動代理的模式下才會發生作用。</li>
<li>順位規則，是當代理人的狀態為啟動代理模式(視同不在)，才會順位給下一位代理人。</li>
</ol>
</li>
<li>常態簽核代理人
<ol style="list-style-type:upper-alpha;color:#333333">
<li>常態代理人是指，無論本人狀態是否為啟動代理模式，表單皆由常態代理人簽核。</li>
<li>常態代理人可以限制可簽核的流程與子部門。</li>
<li>常態代理人啟動代理模式時，則必須由本人處理。</li>
</ol>
</li>
</ol>
<b>PS：我們強烈建議您應做好常態代理人權限上的限制。</b>

</asp:Content>

