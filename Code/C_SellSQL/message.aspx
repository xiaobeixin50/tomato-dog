<%@ Register TagPrefix="uc1" TagName="pageHeader" Src="pageHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="pageFooter" Src="pageFooter.ascx" %>
<%@ Page language="c#" Inherits="SCard.message" CodeFile="message.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>���԰� --</title>


        <LINK href="style/style.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body>
        <uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader>
        <table width="760" class="ZWenbg" cellpadding="2" cellspacing="2">
            <tr>
                <td align="center">
                    
                    <form id="Form1" method="post" runat="server">
                        <br>
                        <table width="600">
                            <tr>
                                <td background="images/bgtiao03.gif" height="28">&nbsp;&nbsp;&nbsp;&nbsp; <B>���԰�</B>
                                </td>
                            </tr>
                        </table>
                        <table cellSpacing="0" cellPadding="5" width="600">
                            <tr>
                                <td>
                                    <img src=images/3DAS.gif>
                                    ����д������ϵ��Ϣ���������������ͽ��飬�һᾡ�������𸴡�
                                </td>
                            </tr>
                            <tr><td height=1 bgcolor=#e2e2e2></td></tr>
                            <tr>
                                <td align=center class="LMubg">
                                    <table width="90%">
                                        <tr>
                                            <td width="80">����</td>
                                            <td><asp:textbox id="txtUserName" Runat="server" Width="150" MaxLength="20"></asp:textbox></td>
                                        </tr>
                                        <tr>
                                            <td>��ϵ�绰</td>
                                            <td><asp:textbox id="txtUserPhone" Runat="server" Width="150" MaxLength="20"></asp:textbox></td>
                                        </tr>
                                        <tr>
                                            <td>E-mail<FONT color="#ff0000">*</FONT></td>
                                            <td><asp:textbox id="txtEmail" Runat="server" Width="150" MaxLength="30"></asp:textbox><asp:regularexpressionvalidator id="REVEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ControlToValidate="txtEmail" ErrorMessage="�����ʼ���ʽ����!!"></asp:regularexpressionvalidator></td>
                                        </tr>
                                        <tr>
                                            <td>����<FONT color="#ff0000">*</FONT></td>
                                            <td><asp:textbox id="txtTitle" Runat="server" Width="250" MaxLength="50"></asp:textbox></td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">����<FONT color="#ff0000">*</FONT></td>
                                            <td><asp:textbox id="txtContent" Runat="server" Width="450" TextMode="MultiLine" Rows="7"></asp:textbox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr><td height=1 bgcolor=#e2e2e2></td></tr>
                            <tr>
                                <td><FONT color="#ff0000">��</FONT><FONT color="#ff0000"> ע����*��Ϊ������</FONT>
                                </td>
                            </tr>
                            <tr><td height=1 bgcolor=#bec6d9></td></tr>
                            <tr>
                                <td align=center>
                                    <asp:button id="btnOK" Runat="server" Text="�ύ" onclick="btnOK_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:button id="btnReset" Runat="server" Text="����" onclick="btnReset_Click"></asp:button>
                                </td>
                            </tr>
                        </table> 
                    </form>
                    <br>
                    <br>
                    
                </td>
            </tr>
        </table>
        <uc1:pagefooter id="PageFooter1" runat="server"></uc1:pagefooter>
    </body>
</HTML>
