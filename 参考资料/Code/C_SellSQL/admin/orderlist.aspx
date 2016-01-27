<%@ Page language="c#" Inherits="SCard.admin.orderList" ResponseEncoding="utf-8" CodeFile="orderList.aspx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="DevCenter" Assembly="WebPager" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>orderList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align="left">
				<asp:TextBox id="txtSelect" Width="150px" runat="server"></asp:TextBox>
				<asp:DropDownList id="ddlSelect" runat="server">
					<asp:ListItem Value="0" Selected="True">�������</asp:ListItem>
					<asp:ListItem Value="1">����</asp:ListItem>
					<asp:ListItem Value="2">�����ʼ�</asp:ListItem>
				</asp:DropDownList>&nbsp;&nbsp;
				<asp:Button id="btnSelect" runat="server" Text="��ѯ" onclick="btnSelect_Click"></asp:Button>
			</div>
			<br>
			<asp:DataGrid id="OrderDataGrid" runat="server" AutoGenerateColumns="False" Width="100%" cellpadding='4'
				cellspacing='1' CssClass='grid fixed'>
				<HeaderStyle HorizontalAlign="Center" CssClass="category"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="OID" HeaderText="�������">
						<HeaderStyle ForeColor="#0F83EC" Width="160px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="TName" HeaderText="����">
						<HeaderStyle ForeColor="#0F83EC" Width="150px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Email" HeaderText="�����ʼ�">
						<HeaderStyle ForeColor="#0F83EC" Width="170px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="OState" HeaderText="״̬">
						<HeaderStyle ForeColor="#0F83EC" Width="70px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Pubdate" HeaderText="ʱ��">
						<HeaderStyle ForeColor="#0F83EC" Width="140px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle ForeColor="#0F83EC" Width="70px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<a target=_blank href='orderDetail.aspx?oid=<%#DataBinder.Eval(Container.DataItem,"OID")%>'>
								��ϸ��Ϣ</a>
								<a href='?ac=0&oid=<%#DataBinder.Eval(Container.DataItem,"OID")%>'>
								δ����</a>
									<a href='?ac=1&oid=<%#DataBinder.Eval(Container.DataItem,"OID")%>'>
								 ���</a>
									<a  href='?ac=2&oid=<%#DataBinder.Eval(Container.DataItem,"OID")%>'>
								�ȴ�</a>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>&nbsp;
            <cc1:SqlPager ID="SqlPager1" runat="server" CacheDuration="0" />
		</form>
	</body>
</HTML>
