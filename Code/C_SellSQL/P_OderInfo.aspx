<%@ Page language="c#" Inherits="SCard.myFav" ResponseEncoding="utf-8" CodeFile="P_OderInfo.aspx.cs" %>

<%@ Register Src="pageFooter.ascx" TagName="pageFooter" TagPrefix="uc1" %>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="DevCenter" Assembly="WebPager" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�������򶩵���Ϣ�鿴</title>
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
                        &nbsp;<table cellpadding="5" cellspacing="5" width="750">
                                <tr>
                                    <td align="right" colspan="3" style="text-align: center; width: 738px;">
			<asp:DataGrid id="FavDataGrid" runat="server" AutoGenerateColumns="False" Width="94%" cellpadding='4'
				cellspacing='1' CssClass='grid fixed' >
				<HeaderStyle HorizontalAlign="Center" CssClass="category"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="OrderNo" HeaderText="�������">
						<HeaderStyle ForeColor="#0F83EC" Width="150px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="tblUser" HeaderText="�û�ID">
						<HeaderStyle ForeColor="#0F83EC" Width="120px"></HeaderStyle>
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
		 
				</Columns>
			</asp:DataGrid>
			<cc1:SqlPager id="SqlPager1" runat="server" PagingMode="Cached" PagerStyle="NextPrev" CacheDuration="0" Width="691px"></cc1:SqlPager>
            &nbsp;&nbsp;</td>
                                </tr>
                            </table>
                        <br />
                        <!-- }���Ľ��� -->
                    </td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;
		</form>
	</body>
</HTML>
