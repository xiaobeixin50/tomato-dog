<%@ Page language="c#" Inherits="SCard.admin.adminSelf" CodeFile="adminSelf.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>adminSelf</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <LINK href="style.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <table align='center' width='100%' cellpadding='4' cellspacing='1' border='1' class='grid'>
                <tr>
                    <td width='140' class='category'></td>
                    <td class='category'>�޸��Լ��Ĺ����¼����</td>
                </tr>
                <tr>
                    <td>��¼��</td>
                    <td>
                        <asp:TextBox id="txtAdmin" ReadOnly=True Width=150 runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="HEIGHT: 31px">������</td>
                    <td style="HEIGHT: 31px"><asp:TextBox id="txtPassword" MaxLength="25" Width=150 runat="server" TextMode="Password"></asp:TextBox>
                        Ϊ�˱�֤�������ϵİ�ȫ�ԣ��뽫���볤������Ϊ6λ����</td>
                </tr>
                <tr>
                    <td>
                        ȷ������</td>
                    <td><asp:TextBox id="txtRPassword" MaxLength="25" Width=150 runat="server" TextMode="Password"></asp:TextBox>&nbsp;
                        <asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="������������벻һ��" Font-Bold="True"
                            ControlToCompare="txtPassword" ControlToValidate="txtRPassword"></asp:CompareValidator></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button id="btnOK" runat="server" Text="�� ��" onclick="btnOK_Click"></asp:Button></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
