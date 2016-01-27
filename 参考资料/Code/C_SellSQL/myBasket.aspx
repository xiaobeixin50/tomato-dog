<%@ Page language="c#" Inherits="SCard.myFav" ResponseEncoding="utf-8" CodeFile="myBasket.aspx.cs" %>

<%@ Register Src="pageFooter.ascx" TagName="pageFooter" TagPrefix="uc1" %>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="DevCenter" Assembly="WebPager" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ҵĹ��ﳵ</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body style="text-align: center">
		<form id="Form1" method="post" runat="server">
	            <table cellpadding="2" cellspacing="2" class="ZWenbg2" width="760">
                <tr>
                    <td align="center" style="width: 756px">
                        <!-- ���Ŀ�ʼ{ -->
                <uc2:pageHeader ID="PageHeader1" runat="server" />
                            <img src="images/liucheng01.jpg" width="750" />
                            <br />
                            <table width="750">
                                <tr>
                                    <td background="images/chengse01.gif" height="31">
                                        &nbsp; &nbsp;&nbsp; <font style="font-size: 14px"><b>����������</b></font>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="5" cellspacing="5" width="750">
                                <tr>
                                    <td align="right" colspan="3" style="text-align: center">
			<asp:DataGrid id="FavDataGrid" runat="server" AutoGenerateColumns="False" Width="92%" cellpadding='4'
				cellspacing='1' CssClass='grid fixed' >
				<HeaderStyle HorizontalAlign="Center" CssClass="category"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="ID" HeaderText="���">
						<HeaderStyle ForeColor="#0F83EC" Width="50px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="isDate" HeaderText="���빺�ﳵʱ��">
						<HeaderStyle ForeColor="#0F83EC" Width="150px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="PName" HeaderText="����������">
						<HeaderStyle ForeColor="#0F83EC" Width="170px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
                    <asp:BoundColumn DataField="isN" HeaderText="����"></asp:BoundColumn>
                    <asp:BoundColumn DataField="isMoney" HeaderText="���"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle ForeColor="#0F83EC" Width="70px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<a target=_blank href='productDisplay.aspx?id=<%#DataBinder.Eval(Container.DataItem,"PID")%>'>
								��ϸ��Ϣ</a>
						</ItemTemplate>
					</asp:TemplateColumn>
							<asp:TemplateColumn>
						<HeaderStyle ForeColor="#0F83EC" Width="70px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<a  href='?did=<%#DataBinder.Eval(Container.DataItem,"ID")%>'>
								ȡ������</a>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
			<cc1:SqlPager id="SqlPager1" runat="server" PagingMode="Cached" PagerStyle="NextPrev" CacheDuration="0" Width="691px"></cc1:SqlPager>
            &nbsp;&nbsp;</td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" width="750">
                                <tr>
                                    <td colspan="2">
                                        <img src="images/tianxiedingdan.gif" /></td>
                                </tr>
                                <tr>
                                    <td bgcolor="#f7941d" height="1">
                                    </td>
                                </tr>
                            </table>
                            <table cellspacing="10" width="750">
                                <tr>
                                    <td colspan="3">
                                        &nbsp; &nbsp; &nbsp;&nbsp; ������������Ϣ����<font color="#cc0033">���Ǻ�Ϊ������Ŀ</font>�� &nbsp;�˴ι����ܼ۸�
                                        <asp:Label ID="lblTotalPric" runat="server" Font-Bold="True" ForeColor="#ff0033"></asp:Label>Ԫ
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="130">
                                        �� ����
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" MaxLength="20"></asp:TextBox>
                                        <font color="#cc0033">*</font>
                                    </td>
                                    <td style="width: 355px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 24px">
                                        ��ʵ����</td>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="20"></asp:TextBox></td>
                                    <td style="width: 355px; height: 24px">
                                        <span style="color: #808080">��������ʵ�����͵����ʼ�,�Ա��Ժ��ʵ����</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        �����ʼ���
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="20"></asp:TextBox>
                                        <font color="#cc0033">*</font>
                                    </td>
                                    <td style="width: 355px">
                                        <asp:RegularExpressionValidator ID="REVEmail" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="�����ʼ���ʽ����!!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 24px">
                                        ��ϵ�绰��
                                    </td>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="15" Width="192px"></asp:TextBox>
                                        <span style="color: #cc0033">*</span>
                                    </td>
                                    <td style="width: 355px; height: 24px">
                                    </td>
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
                                                                                                    style="font-size: 10.5pt; color: gray; font-family: ����; "></span>Ԫ�����ͻ����ţ�<b><span lang="EN-US" style="color: #ff6699;
                                                                                                        letter-spacing: -1pt;"><?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                                                                                            prefix="o" ?></span></b></p>
                                        </span></span></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        ��֤�룺
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCheck" runat="server" Width="50"></asp:TextBox>
                                        <font color="#cc0033">*</font> &nbsp;
                                        <img name="imgCheck" src="ValidateCode.aspx" />
                                        &nbsp;
                                        <asp:LinkButton ID="newCode" runat="server">������</asp:LinkButton>
                                    </td>
                                    <td style="width: 355px">
                                        <font color="#808080">���ͼƬ��ʾ�����ֻ�����ĸ��������</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#e2e2e2" colspan="3" height="1">
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td colspan="2">
                                        <asp:Button ID="btnOK" runat="server" Height="20" OnClick="btnOK_Click" Style="color: #0000ff"
                                            Text="��&nbsp;&nbsp;&nbsp;&nbsp;��" Width="120" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="�� ��" />
                                    </td>
                                    <td style="width: 355px">
                                    </td>
                                </tr>
                            </table>
            <uc1:pageFooter ID="PageFooter1" runat="server" />
                        <br />
                        <!-- }���Ľ��� -->
                    </td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;
		</form>
	</body>
</HTML>
