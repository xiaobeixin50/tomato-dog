<%@ Register TagPrefix="uc1" TagName="pageFooter" Src="pageFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="pageHeader" Src="pageHeader.ascx" %>
<%@ Page language="c#" Inherits="SCard.Select" CodeFile="Select.aspx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="DevCenter" Assembly="WebPager" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>���������� -- ���������罻��ƽ̨</title>


        <LINK href="style/style.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body>
        <uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader>
        <form id="Form" method="post" runat="server">
            <table width="760" class="LMubg" cellpadding=0 cellspacing=0>
                <tr><td colspan=3 height=0 bgcolor=#e9e9e9></td></tr>
                <tr>
                    <td width=10></td>
                    <td width="200">
                        <!-- ������ --><A href="index.aspx">��ҳ</A> &gt; ����������
                    </td>
                    <td>
                        <!-- ��������ʼ{ -->
                        <table width="100%">
                            <tr>
                                <td width="60" align="center"><IMG src="images/leibie.gif"></td>
                                <td width="45" align="center">������</td>
                                <td width="60" align="center"><asp:dropdownlist id="ddlClass" runat="server"></asp:dropdownlist></td>
                                <td width="45" align="center">�ؼ���</td>
                                <td width="100" align="center"><asp:textbox id="txtSelect" runat="server"></asp:textbox></td>
                                <td width="40" align="right"><asp:button id="btnSelect" style="WIDTH: 60px; COLOR:#ff0000" runat="server" Text="��&nbsp;&nbsp;ѯ" onclick="btnSelect_Click"></asp:button></td>
                                <td align=right><IMG src="images/index_dc_20.gif"></td>
                            </tr>
                        </table>
                        <!-- }���������� --> 
                    </td>
                </tr>
                <tr><td colspan=3 height=0 bgcolor=#e2e2e2></td></tr>
            </table>
            <table width="760" class="ZWenbg" cellpadding=2 cellspacing=2>
                <tr vAlign="top">
                    <td width="185">
                    <!-- ������߿�ʼ{ -->
                        <!-- �����б�ʼ{  -->
                        <table width="179" cellSpacing="0" cellPadding="0">
                            <tr>
                                <td width="179" colspan=3 background="images/fenlei.gif" height="24">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>���������</b></td>
                            </tr>
                            <tr>
                                <td class="LFramebg"></td>
                                <td align="center" height=100 class="LMubg" valign=top>
                                    <asp:repeater id="CRepeater" runat="server">
                                        <HeaderTemplate>
                                            <table width="177">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td width="12" align=center valign=top><img border="0" src="images/bullet.gif" width="10" height="10"></td>
                                                <td>
                                                    <A href='productsList.aspx?cid=<%#DataBinder.Eval(Container.DataItem,"CID")%>'>
                                                        <%#DataBinder.Eval(Container.DataItem,"CName")%>
                                                    </A>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate> 
                                    </asp:repeater> 
                                </td>
                                <td class="RFramebg"></td>
                            </tr>
                           <tr>
                            <td colspan=3 class="XFramebg"></td>
                        </tr>
                    </table>
                    <!-- }�����б����  -->
                    <table height=10><tr><td></td></tr></table>
                    <!-- �ͻ�����ʼ{  --> 
                    <table cellSpacing="0" cellPadding="0">
                        <tr>
                            <td width="179" colspan=3 height="24" background="images/fenlei.gif">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>�ͻ�����</b></td>
                        </tr>
                        <tr>
                            <td class="LFramebg"></td>
                            <td align="center" height=150 valign=top>  
                                <table cellspacing=5 width="177">
                                    <tr>
                                        <td><img src="images/myInfo/tel.gif"></td>
                                    </tr>
                                    <tr>
                                        <td align=center><img src="images/myInfo/line.gif"></td>
                                    </tr>
                                    <tr>
										<td align=center><font color="#754f75"><strong>1388888888</strong></font></td>
                                    </tr>
                                    <tr>
                                        <td><img src="images/myInfo/QQ.gif"></td>
                                    </tr>
                                    <tr>
                                        <td align=center><img src="images/myInfo/line.gif"></td>
                                    </tr>
                                    <tr>
                                        <td>
											<font color="#754f75"><strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 88888888</STRONG>
											</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><img src="images/myInfo/mail.gif"></td>
                                    </tr>
                                    <tr>
                                        <td align=center><img src="images/myInfo/line.gif"></td>
                                    </tr>
                                    <tr>
                                        <td align=center><font color="#754f75"><strong>888888@163.com</strong></font></td>
                                    </tr>
                                </table>
                            </td>
                            <td class="RFramebg"></td>
                        </tr>
                        <tr>
                            <td colspan=3><IMG src="images/fenleiD.gif" width="179"></td>
                        </tr>
                    </table>
                    <!-- }�ͻ��������  --> 
            <!-- }������߽��� --> 
            </TD>
            <TD width=100% align=right>
            <!-- �����ұ߿�ʼ{ -->
                <!-- �������б�ʼ{  -->
                <table width="98%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="22" width="135" background="images/xiangxiT.gif">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="COLOR: #ffffff"><B>[ 
                                    ������� ]</B></span></td>
                        <td background="images/xiangxiZ.gif">&nbsp;</td>
                        <td width="1"><img src="images/xiangxiW.gif"></td>
                    </tr>
                </table>
                <table width="98%" cellpadding="0" cellspacing="0">
                    <tr height="500" valign="top">
                        <td class="LFramebg"></td>
                        <td valign="top" class="LMubg">
                            <asp:DataList id="PDataList" Width="100%" runat="server" RepeatDirection="Horizontal" RepeatColumns="2"
                                ShowHeader="False" ShowFooter="False" CellPadding="10" CellSpacing="3">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="100" align="center">
                                                <a href='productDisplay.aspx?id=<%#DataBinder.Eval(Container.DataItem,"PID")%>'><img border=0 width=100 height=64 src='showPP.aspx?id=<%#DataBinder.Eval(Container.DataItem,"PID")%>'>
                                                </a>
                                            </td>
                                            <td width="140" align="left">
                                                <table>
                                                    <tr>
                                                        <td><%#DataBinder.Eval(Container.DataItem,"PName")%></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;&nbsp;ԭ��:
                                                            <del>
                                                                ��<%#String.Format("{0:f}",DataBinder.Eval(Container.DataItem,"PFPrice"))%></del></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;&nbsp;�ּ�: <font color="#CC0033">��<%#String.Format("{0:f}",DataBinder.Eval(Container.DataItem,"PNPrice"))%></font></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td>[ <A href='productDisplay.aspx?id=<%#DataBinder.Eval(Container.DataItem,"PID")%>'>�鿴����</A>
                                                ]</td>
                                            <td align="left">&nbsp;&nbsp;<img src="images/emoney.gif"> [<A target=_blank href='makeOrder.aspx?id=<%#DataBinder.Eval(Container.DataItem,"PID")%>'>���߹���</A>]
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                        <td class="RFramebg"></td>
                    </tr>
                    <tr>
                        <td class="LFramebg"></td>
                        <td class="LMubg">
                            <cc1:SqlPager id="SqlPager1" runat="server" PagingMode="Cached" PagerStyle="NextPrev" CacheDuration="0"></cc1:SqlPager>
                        </td>
                        <td class="RFramebg"></td>
                    </tr>
                <tr><td colspan=3 class="XFramebg"></td></tr>
                </table>
                <!-- }�������б����  -->
            <!-- }�����ұ߽��� -->
            </TD></TR></TABLE>
        </form>
        <uc1:pageFooter id="PageFooter1" runat="server"></uc1:pageFooter>
    </body>
</HTML>
