<%@ Page language="c#" Inherits="SCard.myFav" ResponseEncoding="utf-8" CodeFile="LeaveWord.aspx.cs" %>

<%@ Register Src="pageFooter.ascx" TagName="pageFooter" TagPrefix="uc1" %>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="DevCenter" Assembly="WebPager" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ҵ��ղ�</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	 
		<LINK href="style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body style="text-align: center">
		<form id="Form1" method="post" runat="server">
			<div align="left" style="text-align: center">
                <uc2:pageHeader ID="PageHeader1" runat="server" />
                &nbsp;</div>
            ��Ը���Ʒ���е������������ı������~<br>
            &nbsp; &nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Height="163px" TextMode="MultiLine" Width="723px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="�ύ" OnClick="Button1_Click" />
            <a href="index.aspx">
                ������ҳ</a>&nbsp;
		</form>
	</body>
</HTML>
