<%@ Reference Page="~/index.aspx" %>
<%@ Page language="c#" Inherits="SCard.admin.index" ResponseEncoding="utf-8" CodeFile="index.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��̨����ϵͳ��¼</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<form id="Form1" method="post" runat="server">
			<table align='center' width='280' cellpadding='4' cellspacing='1' border='1' class='grid fixed'>
				<tr>
					<td class='category'></td>
					<td width="200" class='category'>��̨����ϵͳ��¼</td>
				</tr>
				<tr>
					<td align="center">��¼����</td>
					<td>
						<asp:TextBox id="txtAdminname" MaxLength="25" runat="server" tabIndex="1" ></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="center">��¼����</td>
					<td>
						<asp:TextBox id="txtAdminPW" MaxLength="25" runat="server" TextMode="Password" tabIndex="2"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="center">��֤��</td>
					<td>
						<asp:TextBox ID="txtCheck" Width="50" Runat="server" tabIndex="3"></asp:TextBox>&nbsp;&nbsp;
						<img src="../ValidateCode.aspx" name="imgCheck">&nbsp;&nbsp;
						<asp:LinkButton id="newCode" runat="server">������</asp:LinkButton>
					</td>
				</tr>
				<tr>
					<td></td>
					<td>
						<asp:Button id="btnOK" runat="server" Text="�� ¼" tabIndex="4" onclick="btnOK_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
						<asp:Button ID="exit"  runat="server" Text="ȡ ��" tabIndex="5" OnClick="exit_Click"/></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
