<%@ Page language="c#" Inherits="SCard.makeOrder" ResponseEncoding="utf-8" CodeFile="makeOrder.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="pageHeader" Src="pageHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="pageFooter" Src="pageFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��д���� --</title>


		<LINK href="style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader>
		<table width="760" class="ZWenbg2" cellpadding="2" cellspacing="2">
			<tr>
				<td align="center" style="width: 756px">
					<!-- ���Ŀ�ʼ{ -->
					<form id="Form1" method="post" runat="server">
						<br>
						<img width="750" src="images/liucheng01.jpg">
						<br>
						<table width="750">
							<tr>
								<td height="31" background="images/chengse01.gif">&nbsp;&nbsp;&nbsp;&nbsp; <font style="FONT-SIZE: 14px">
										<B>����������</B></font>
								</td>
							</tr>
						</table>
						<table width="750" cellpadding="5" cellspacing="5">
							<tr>
								<td width="230" align="right">
									<IMG width="200" border="0" id="myImg" runat="server" style="height: 245px">
								</td>
								<td>
									<table width="60%">
										<tr>
											<td><asp:label Font-Bold="True" ForeColor="#CC0033" id="lblPName" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td height="5"><hr style="BORDER-TOP-STYLE:dashed;BORDER-RIGHT-STYLE:dashed;BORDER-LEFT-STYLE:dashed;BORDER-BOTTOM-STYLE:dashed"
													size="1">
											</td>
										</tr>
										<tr>
											<td align="left">&nbsp;<img src="images/emoney.gif">&nbsp;ԭ��:
												<del>
													��<asp:label id="lblPFPrice" Runat="server"></asp:label></del></td>
										</tr>
										<tr>
											<td align="left">&nbsp;<img src="images/emoney.gif">&nbsp;�ּ�: ��<asp:label id="lblPNPrice" ForeColor="#CC0033" Runat="server"></asp:label></td>
										</tr>
                                        <tr>
                                            <td>
                                                <asp:label id="lblIsStock" Runat="server"></asp:label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="DropDownList1" AutoPostBack="True" Runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                                                    <asp:ListItem Selected="True" Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                </asp:DropDownList>
                                                <FONT color="#cc0033">*</font> &nbsp;&nbsp; �ܼ۸�
                                                <asp:Label ID="lblCount" runat="server" Font-Bold="True" ForeColor="#FF0033"></asp:Label>Ԫ
                                            </td>
                                        </tr>
										<tr>
											<td style="height: 22px">
                                                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="���빺�ﳵ" /></td>
										</tr>
									</table>
								</td>
								<td></td>
							</tr>
						</table>
						<table width="750" cellpadding="0" cellspacing="0">
							<tr>
								<td colspan="2"><img src="images/tianxiedingdan.gif"></td>
							</tr>
							<tr>
								<td bgcolor="#f7941d" style="height: 1px"></td>
							</tr>
						</table>
						<table width="750" cellspacing="10">
							<tr>
								<td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ������������Ϣ����<FONT color="#cc0033">���Ǻ�Ϊ������Ŀ</FONT>��								</td>
							</tr>
							<tr>
								<td width="130" align="right">
                                    ��ԱID��
                                </td>
								<td>
									<asp:TextBox ID="txtName" MaxLength="20" Runat="server"></asp:TextBox>
									<FONT color="#cc0033">*</FONT>								</td>
								<td style="width: 355px">
									</td>
							</tr>
                            <tr>
                                <td align="right" style="height: 24px">
                                    ��ʵ���ƣ�</td>
                                <td style="height: 24px">
                                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="20"></asp:TextBox></td>
                                <td style="height: 24px; width: 355px;">
                                    <span style="color: #808080">��������ʵ�����͵����ʼ�,�Ա��Ժ��ʵ����</span>
                                </td>
                            </tr>
							<tr>
								<td align="right">
									�����ʼ���								</td>
								<td>
									<asp:TextBox ID="txtEmail" MaxLength="20" Runat="server"></asp:TextBox>
									<FONT color="#cc0033">*</FONT>								</td>
								<td style="width: 355px">
									<asp:RegularExpressionValidator id="REVEmail" runat="server" ErrorMessage="�����ʼ���ʽ����!!" ControlToValidate="txtEmail"
										ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>								</td>
							</tr>
							<tr>
								<td align="right" style="height: 24px">
									��ϵ�绰��								</td>
								<td style="height: 24px">
									<asp:TextBox ID="txtPhone" MaxLength="15" Runat="server" Width="195px"></asp:TextBox>								
                                    <span style="color: #cc0033">*</span>
                                </td>
								<td style="height: 24px; width: 355px;"></td>
							</tr>
							  <tr>
                                    <td align="right">
                                        �ʵݷ�ʽ:</td>
                                    <td>
                                        &nbsp;<asp:DropDownList ID="dplBm" runat="server">
                                        </asp:DropDownList></td>
                                    <td style="width: 355px">
                                        <span style="font-size: 10pt"><span style="color: #808080; font-family: ����">
                                            <p class="MsoNormal" style="margin: 0cm 0cm 0pt">
                                                <span style="font-size: 10pt"></span><span style="color: gray; font-family: ����;
                                                  "></span>ƽ��:<span lang="EN-US" style="color: gray;
                                                        font-family: Times New Roman">7-15</span><span style="color: gray; font-family: ����;
                                                           ">��</span><span
                                                                lang="EN-US" style="color: gray; font-family: Times New Roman">,</span><span style="color: gray;
                                                                    font-family: ����; ">�ʷ�</span><span
                                                                        lang="EN-US" style="color: gray; font-family: Times New Roman">7.0</span><span style="color: gray;
                                                                            font-family: ����; ">Ԫ;</span><span
                                                                                style="font-size: 10pt"><span style="color: gray; font-family: ����; 
                                                                                   ">����:</span><span lang="EN-US" style="color: gray;
                                                                                        font-family: Times New Roman">4</span><span style="color: gray; font-family: ����;
                                                                                           ">��</span><span
                                                                                                lang="EN-US" style="color: gray; font-family: Times New Roman">10</span><span style="color: gray;
                                                                                                    font-family: ����; ">��</span><span
                                                                                                        lang="EN-US" style="color: gray; font-family: Times New Roman">,</span><span style="color: gray;
                                                                                                            font-family: ����;">�ʷ�</span><span
                                                                                                                lang="EN-US" style="color: gray; font-family: Times New Roman">10.0</span><span style="color: gray;
                                                                                                                    font-family: ����; ">Ԫ</span></span></p>
                                            <p class="MsoNormal" style="margin: 0cm 0cm 0pt">
                                                <span style="font-size: 10pt"><span style="color: gray; font-family: ����; ">���:</span><span lang="EN-US" style="color: gray;
                                                        font-family: Times New Roman">2-4</span><span style="color: gray; font-family: ����;
                                                           ">��</span><span
                                                                lang="EN-US" style="color: gray; font-family: Times New Roman">,</span><span style="color: gray;
                                                                    font-family: ����;">�ʷ�</span><span
                                                                        lang="EN-US" style="color: gray; font-family: Times New Roman">15.0</span><span style="color: gray;
                                                                            font-family: ����;">Ԫ;</span></span><span
                                                                                lang="EN-US" style="font-size: 10.5pt; color: gray; font-family: 'Times New Roman';
                                                                               ">EMS</span><span
                                                                                    style="font-size: 10.5pt; color: gray; font-family: ����; ">:����<span lang="EN-US" style="font-size: 10pt;
                                                                                        color: gray; font-family: Times New Roman">,</span><span style="color: gray; font-family: ����;
                                                                                           "></span>�ʷ�</span><span
                                                                                                lang="EN-US" style="font-size: 10.5pt; color: gray; font-family: 'Times New Roman';
                                                                                               ">25.0</span><span
                                                                                                    style="font-size: 10.5pt; color: gray; font-family: ����; "></span>Ԫ�����ͻ����ţ�<b><span
                                                                                                        lang="EN-US" style="color: #ff6699; letter-spacing: -1pt"><?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                                                                                            prefix="o" ?></span></b><b><span lang="EN-US" style="color: #ff6699;
                                                                                                        letter-spacing: -1pt;"><?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                                                                                            prefix="o" ?></span></b></p>
                                        </span></span></td>
                                </tr>
							<tr>
								<td align="right">
									����������								</td>
								<td>
									<asp:DropDownList ID="ddlNum" AutoPostBack="True" Runat="server" onselectedindexchanged="ddlNum_SelectedIndexChanged">
										<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
									</asp:DropDownList>
									<FONT color="#cc0033">*</FONT>&nbsp;&nbsp;&nbsp;   �ܼ۸�
									<asp:Label Font-Bold="True" ForeColor="#ff0033" ID="lblTotalPric" Runat="server"></asp:Label>Ԫ								</td>
								<td style="width: 355px"></td>
							</tr>
							<tr>
								<td align="right">
									��֤�룺								</td>
								<td>
									<asp:TextBox ID="txtCheck" Width="50" Runat="server"></asp:TextBox>
									<FONT color="#cc0033">*</FONT>&nbsp;&nbsp; <img src="ValidateCode.aspx" name="imgCheck">&nbsp;&nbsp;
									<asp:LinkButton id="newCode" runat="server">������</asp:LinkButton>								</td>
								<td style="width: 355px">
									<font color="#808080">���ͼƬ��ʾ�����ֻ�����ĸ��������</font>								</td>
							</tr>
							<tr>
								<td colspan="3" height="1" bgcolor="#e2e2e2"></td>
							</tr>
							<tr align="right">
								<td colspan="2">
									<asp:Button ID="btnOK" style="COLOR:#0000ff" Text="��&nbsp;&nbsp;&nbsp;&nbsp;��" Runat="server"
										Width="120" Height="20" onclick="btnOK_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button ID="btnClear" Text="�� ��" Runat="server" onclick="btnClear_Click"></asp:Button>								</td>
								<td style="width: 355px"></td>
							</tr>
						</table>
					</form>
					<br>
					<br>
					<!-- }���Ľ��� -->
				</td>
			</tr>
		</table>
		<uc1:pageFooter id="PageFooter1" runat="server"></uc1:pageFooter>
	</body>
</HTML>
