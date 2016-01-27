﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uLogin.aspx.cs" Inherits="SCard.uLogin" %>

<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc1" %>
<%@ Register Src="pageFooter.ascx" TagName="pageFooter" TagPrefix="uc2" %>

 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
  
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
        <uc1:pageHeader ID="PageHeader1" runat="server" />
    <table border="0" align="center" cellpadding="1" bordercolor="#B2C2D7" class="webname">
      <tr>
        <td colspan="2" bgcolor="#B2C2D7" style="height: 40px">
            <span style="font-size: 14pt">普通用户登录</span></td>
      </tr>
      <tr>
        <td bgcolor="#F0F5F9" style="width: 46px; height: 43px">
            <span style="font-size: 12pt">用户</span></td>
        <td bgcolor="#F0F5F9" style="width: 193px; height: 43px">&nbsp;
        <asp:TextBox ID="tname" runat="server" Height="27px" Width="135px"></asp:TextBox></td>
      </tr>
        <tr>
        <td bgcolor="#F0F5F9" style="width: 46px; height: 45px">
            <span style="font-size: 12pt">密码</span></td>
        <td bgcolor="#F0F5F9" style="width: 193px; height: 45px">&nbsp;
        <asp:TextBox ID="tpass" runat="server" TextMode="Password" Height="27px" Width="135px"></asp:TextBox></td>
      </tr>
      <tr>
        <td  bgcolor="#F0F5F9" style="width: 46px; height: 38px"  >&nbsp;</td>
        <td bgcolor="#F0F5F9" style="width: 193px; height: 38px" >&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登录" Height="24px" Width="59px" />        </td>
      </tr>
    </table>
    </div>
        <uc2:pageFooter ID="PageFooter1" runat="server" />
    </form>
</body>
</html>
