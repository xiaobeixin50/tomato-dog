<%@ Page language="c#" Inherits="SCard.admin.orderTidy" ResponseEncoding="utf-8" CodeFile="orderTidy.aspx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="DevCenter" Assembly="WebPager" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>orderTidy</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <LINK href="style.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <div align=left>
                <asp:DropDownList id="ddlDelete" AutoPostBack=True runat="server" onselectedindexchanged="ddlDelete_SelectedIndexChanged">
                    <asp:ListItem Value="0" Selected="True">��� 1����ǰδ������</asp:ListItem>
                    <asp:ListItem Value="1">��� 1������ǰδ������</asp:ListItem>
                    <asp:ListItem Value="2">��� 1����ǰδ������</asp:ListItem>
                    <asp:ListItem Value="3">��� 1Сʱǰδ������</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:Button id="btnDelete" runat="server" Text="ɾ��" onclick="btnDelete_Click"></asp:Button>
                <font class='t1'>[ע��:Ҫ��ʱɾ����Ч����,Ϊ������������ν����Դ�˷�!!!!]</font>
            </div><br>
       

        <asp:DataGrid id="OrderDataGrid" runat="server" AutoGenerateColumns="False" Width="100%" cellpadding='4'
                cellspacing='1' CssClass='grid fixed'>
            <HeaderStyle HorizontalAlign="Center" CssClass="category"></HeaderStyle>
            <Columns>
                <asp:BoundColumn DataField="OID" HeaderText="�������">
                    <HeaderStyle ForeColor=#0F83EC Width=160px></HeaderStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="TName" HeaderText="����">
                    <HeaderStyle ForeColor=#0F83EC Width=150px></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Email" HeaderText="�����ʼ�">
                    <HeaderStyle ForeColor=#0F83EC Width=170px></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="OState" HeaderText="״̬">
                    <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Pubdate" HeaderText="ʱ��">
                    <HeaderStyle ForeColor=#0F83EC Width=140px></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
            </Columns>
        </asp:DataGrid>
        <cc1:SqlPager id="SqlPager1" runat="server" PagingMode="Cached" PagerStyle="NextPrev" CacheDuration="0"></cc1:SqlPager>
            &nbsp;
     </form>
    </body>
</HTML>
