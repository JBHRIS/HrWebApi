<%@ Page Title="" Language="C#" MasterPageFile="~/mpLearningFront.master" AutoEventWireup="true" CodeFile="lnSug.aspx.cs" Inherits="eLearning_lnSug" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="news">
		<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>
		<h4>意見箱</h4>
		<select name="Select1" style="margin:20px 0 0 0; width: 100px;">
				<option>學員功能問題</option>
				<option>文章問題</option>
				<option>課程問題</option>
				<option>網站建議</option>
				<option>其他</option>
			</select>
			<table style="text-align:center">
			<tr>
			<td>
			<input name="Text1" type="text" style="height: 204px; width: 338px;" /></td>
			</tr>
			<tr>
			<td>
			<form method="post">
				<input name="Radio1" type="radio" checked="checked" />李大同<input name="Radio1" type="radio" />匿名</form>
			</td>
			</tr>
			<tr>
			<td>
			<form method="post">
				<input name="Button1" type="button" value="送出" /> <input name="Button2" type="button" value="取消" /></form>
			</td>
			</tr>
			</table>
		<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>
	</div>

</asp:Content>

