<%@ Page language="c#" Inherits="SCard.productDisplay" ResponseEncoding="utf-8" CodeFile="productDisplay.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="pageFooter" Src="pageFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="pageHeader" Src="pageHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>二手书详细信息 -- 二手书网络交易平台</title>


		<LINK href="style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader>
		<form id="Form1" method="post" runat="server">
			<table width="760" class="LMubg" cellpadding="0" cellspacing="0">
				<tr>
					<td colspan="3" height="0" bgcolor="#e9e9e9"></td>
				</tr>
				<tr>
					<td width="10"></td>
					<td width="200">
						<!-- 导航条 --><A href="index.aspx">首页</A> &gt;
						<asp:label id="lblDaohang" Runat="server" Font-Bold="True"></asp:label>
					</td>
					<td>
						<!-- 搜索条开始{ -->
						<table width="100%">
							<tr>
								<td width="60" align="center"><IMG src="images/leibie.gif"></td>
								<td width="45" align="center">按分类</td>
								<td width="60" align="center"><asp:dropdownlist id="ddlClass" runat="server"></asp:dropdownlist></td>
								<td width="45" align="center">关键字</td>
								<td width="100" align="center"><asp:textbox id="txtSelect" runat="server"></asp:textbox></td>
								<td width="40" align="right"><asp:button id="btnSelect" style="COLOR: #ff0000" runat="server" Text="查&nbsp;&nbsp;询" Width="60" onclick="btnSelect_Click"></asp:button></td>
								<td align="right"><IMG src="images/index_dc_20.gif"></td>
							</tr>
						</table>
						<!-- }搜索条结束 -->
					</td>
				</tr>
				<tr>
					<td colspan="3" height="0" bgcolor="#e9e9e9"></td>
				</tr>
			</table>
		
		<table width="760" class="ZWenbg" cellpadding="2" cellspacing="2">
			<tr vAlign="top">
				<td width="185">
					<!-- 正文左边开始{ -->
					<!-- 分类列表开始{  -->
					<table width="179" cellSpacing="0" cellPadding="0">
						<TBODY>
							<tr>
								<td width="179" colspan="3" background="images/fenlei.gif" height="24">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>二手书分类</b></td>
							</tr>
							<tr>
								<td class="LFramebg"></td>
								<td align="center" height="100" class="LMubg" valign="top">
									<asp:repeater id="CRepeater" runat="server">
										<HeaderTemplate>
											<table width="177">
										</HeaderTemplate>
										<ItemTemplate>
											<tr>
												<td width="12" align="center" valign="top"><img border="0" src="images/bullet.gif" width="10" height="10"></td>
												<td>
													<A href='productsList.aspx?cid=<%#DataBinder.Eval(Container.DataItem,"CID")%>'>
														<%#DataBinder.Eval(Container.DataItem,"CName")%>
													</A>
												</td>
											</tr>
										</ItemTemplate>
										<FooterTemplate>
					</table>
					</FooterTemplate> </asp:repeater>
				</td>
				<td class="RFramebg"></td>
			</tr>
			<tr>
				<td colspan="3" class="XFramebg"></td>
			</tr>
		</table>
		<!-- }分类列表结束  -->
		<table height="10">
			<tr>
				<td></td>
			</tr>
		</table>
		<!-- 分类对应的热销二手书列表开始{  -->
		<table cellSpacing="0" cellPadding="0">
			<TBODY>
				<tr>
					<td width="179" colspan="3" background="images/fenlei.gif" height="24">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>热销排行榜</b></td>
				</tr>
				<tr>
					<td class="LFramebg"></td>
					<td align="center" height="200" valign="top">
						<asp:Repeater id="HotRepeater" runat="server">
							<HeaderTemplate>
								<table width="177">
							</HeaderTemplate>
							<ItemTemplate>
								<tr>
									<td width="12" align="center" valign="top"><img border="0" src="images/p_01.jpg" width="10" height="10"></td>
									<td>
										<A href='productDisplay.aspx?id=<%#DataBinder.Eval(Container.DataItem,"PID")%>'>
											<%#DataBinder.Eval(Container.DataItem,"PName")%>
										</A>
									</td>
								</tr>
							</ItemTemplate>
							<FooterTemplate>
		</table>
		</FooterTemplate> </asp:Repeater></TD>
		<td class="RFramebg"></td>
		</TR>
		<tr>
			<td colspan="3" class="XFramebg"></td>
		</tr>
		</TBODY></TABLE> 
		<!-- }分类对应的热销二手书列表结束  -->
		<table height="10">
			<tr>
				<td></td>
			</tr>
		</table>
		<!-- 客户服务开始{  -->
		<table cellSpacing="0" cellPadding="0">
			<tr>
				<td width="179" colspan="3" height="24" background="images/fenlei.gif">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>客户服务</b></td>
			</tr>
			<tr>
				<td class="LFramebg"></td>
				<td align="center" height="150" valign="top">
					<table cellspacing=5 width="177">
                        <tr>
                            <td><img src="images/myInfo/tel.gif"></td>
                        </tr>
                        <tr>
                            <td align=center><img src="images/myInfo/line.gif"></td>
                        </tr>
                        <tr>
							<td align=center><font color="#754f75"><strong>13888888888</strong></font></td>
                        </tr>
                        <tr>
                            <td><img src="images/myInfo/QQ.gif"></td>
                        </tr>
                        <tr>
                            <td align=center><img src="images/myInfo/line.gif"></td>
                        </tr>
                        <tr>
                            <td>
                                <strong><span style="color: #754f75">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 888888888</span></strong></td>
                        </tr>
                        <tr>
                            <td><img src="images/myInfo/mail.gif"></td>
                        </tr>
                        <tr>
                            <td align=center><img src="images/myInfo/line.gif"></td>
                        </tr>
                        <tr>
                            <td align=center><font color="#754f75"><strong>88888888888@163.com</strong></font></td>
                        </tr>
                    </table>
				</td>
				<td class="RFramebg"></td>
			</tr>
			<tr>
				<td colspan="3"><IMG src="images/fenleiD.gif" width="179"></td>
			</tr>
		</table>
		<!-- }客户服务结束  -->
		<!-- }正文左边结束 --> </TD>
		<TD width="100%" align="right">
			<!-- 正文右边开始{ -->
			<!-- 二手书信息开始{  -->
			<table width="98%" cellpadding="0" cellspacing="0">
				<tr>
					<td height="22" width="135" background="images/xiangxiT.gif">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="COLOR: #ffffff"><B>[ 
								二手书详情 ]</B></span></td>
					<td background="images/xiangxiZ.gif">&nbsp;</td>
					<td width="1"><img src="images/xiangxiW.gif"></td>
				</tr>
			</table>
			<table width="98%" cellpadding="5" cellspacing="5" class="LMubg">
				<tr>
					<td width="230" align="right">
						<IMG height=260 alt="<%=strPName%>" src="showPP.aspx?id=<%=strPID%>" width=173 border=0 >
					</td>
					<td>
						<table width="90%">
							<tr>
								<td><asp:label Font-Bold="True" ForeColor="#CC0033" id="lblPName" Runat="server"></asp:label></td>
							</tr>
							<tr>
								<td style="height: 5px"><hr style="BORDER-TOP-STYLE:dashed; BORDER-RIGHT-STYLE:dashed; BORDER-LEFT-STYLE:dashed; BORDER-BOTTOM-STYLE:dashed"
										size="1">
								</td>
							</tr>
							<tr>
								<td align="left">&nbsp;<img src="images/emoney.gif">&nbsp;原价:
									<del>
										￥<asp:label id="lblPFPrice" Runat="server"></asp:label></del></td>
							</tr>
							<tr>
								<td align="left">&nbsp;<img src="images/emoney.gif">&nbsp;现价: <font color="#cc0033">￥<asp:label id="lblPNPrice" Runat="server"></asp:label></font></td>
							</tr>
                            <tr>
                                <td style="height: 22px">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="收藏该二手书" /></td>
                            </tr>
							<tr>
								<td><!-- 在线购买 -->
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="评论该商品" /><%=strBuy%></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table width="98%" cellpadding="0" cellspacing="0">
				<tr>
					<td style="width: 13px"><img src="images/biaotiT.gif"></td>
					<td width="100%" valign="top" background="images/bgtiao2.gif">&nbsp;<b>买家必读</b></td>
				</tr>
				<tr class="LMubg">
					<td style="width: 13px"></td>
					<td height="170" valign="top"><%=strPBewrite%></td>
				</tr>
				<tr>
					<td height="10" style="width: 13px"></td>
				</tr>
				<tr>
					<td style="width: 13px"><img src="images/biaotiT.gif"></td>
					<td width="100%" background="images/bgtiao2.gif">&nbsp;<b>详情介绍</b></td>
				</tr>
				<tr class="LMubg">
					<td style="width: 13px"></td>
					<td height="100" valign="top"><%=strPUseMode%></td>
				</tr>
				<tr>
					<td height="10" style="width: 13px"></td>
				</tr>
				<tr>
					<td style="width: 13px"><img src="images/biaotiT.gif"></td>
					<td width="100%" background="images/bgtiao2.gif">&nbsp;<b>二手书简介</b></td>
				</tr>
				<tr class="LMubg">
					<td style="width: 13px"></td>
					<td height="50" valign="top"><%=strPValidity%></td>
				</tr>	<tr>
					<td height="10" style="width: 13px"></td>
				</tr>
				<tr>
					<td style="width: 13px"><img src="images/biaotiT.gif"></td>
					<td width="100%" background="images/bgtiao2.gif">&nbsp;<b>评论信息</b></td>
				</tr>
				<tr class="LMubg">
					<td style="width: 13px"></td>
					<td height="50" valign="top"><%=strLeaveWord%></td>
				</tr>
				<tr>
					<td height="10" style="width: 13px"></td>
				</tr>
			</table>
			<!-- }二手书信息结束  -->
			<!-- }正文右边结束 -->
		</TD>
		</TR></TABLE></form>
		<uc1:pageFooter id="PageFooter1" runat="server"></uc1:pageFooter>
	</body>
</HTML>
