<%@ Page language="c#" Inherits="SCard.admin.productAdd" ResponseEncoding="utf-8" CodeFile="productAdd.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>productAdd</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="style.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <table align='center' width='100%' cellpadding='4' cellspacing='1' border='1' class='grid fixed'>
                <tr>
                    <td width='140' class='category'>��Ӷ�����</td>
                    <td class='category'>��<font class='t2'>*</font>Ϊ����</td>
                </tr>
                <tr>
                    <td>����������</td>
                    <td><asp:textbox id="txtName" Width="150" runat="server"></asp:textbox>
                        <font class='t2'>*</font></td>
                </tr>
                <tr>
                    <td>�������</td>
                    <td><asp:dropdownlist id="ddlCategory" Width="150" runat="server"></asp:dropdownlist>
                        <font class='t2'>*</font></td>
                </tr>
                
                <tr>
                    <td>�ɱ���</td>
                    <td><asp:textbox id="txtCPrice" Width="150" runat="server"></asp:textbox>
                        <font class='t2'>*</font></td>
                </tr>
                <tr>
                    <td>ԭ��</td>
                    <td><asp:textbox id="txtFPrice" Width="150" runat="server"></asp:textbox>
                        <font class='t2'>*</font></td>
                </tr>
                <tr>
                    <td>�ּ�</td>
                    <td><asp:textbox id="txtNPrice" Width="150" runat="server"></asp:textbox>
                        <font class='t2'>*</font></td>
                </tr>
                <tr>
                    <td valign="top">
                        ͼƬ<br>
                        <font class='t1'>(ͼƬ��ʽ����Ϊ.gif��.jpg,��С����:200*128)</font>
                    </td>
                    <td><INPUT id="uploadFile" onpropertychange="document.all.myimg.src='file:///'+this.value"
                            size="40" type="file" runat="server" NAME="uploadFile"><br>
                        <IMG id="myimg" src="..\images\showimg.gif" border="0">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        ��ұض�<br>
                    </td>
                    <td><asp:textbox id="txtBewrite" runat="server" Width="400" TextMode="MultiLine" Rows="10" Columns="30"></asp:textbox></td>
                </tr>
                <tr>
                    <td valign="top">
                        �������<br>
                    </td>
                    <td><asp:textbox id="txtUseMode" runat="server" Width="400" TextMode="MultiLine" Rows="7" Columns="30"></asp:textbox></td>
                </tr>
                <tr>
                    <td valign="top">
                        ��������<br>
                    </td>
                    <td><asp:textbox id="txtValidity" runat="server" Width="400" TextMode="MultiLine" Rows="3" Columns="30"></asp:textbox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAdd" Text="�� ��" Runat="server" onclick="btnAdd_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnReset" Text="�� ��" Runat="server" onclick="btnReset_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </form>
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
    </body>
</HTML>
