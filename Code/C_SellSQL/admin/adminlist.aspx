<%@ Page language="c#" Inherits="SCard.admin.adminList" CodeFile="adminList.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>adminList</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <LINK href="style.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <asp:DataGrid id="adminDataGrid" runat="server" AutoGenerateColumns="False" Width="100%" cellpadding='4'
                cellspacing='1' CssClass='grid fixed'>
                <HeaderStyle HorizontalAlign="Center" CssClass="category"></HeaderStyle>
                <ItemStyle HorizontalAlign=Center></ItemStyle>
                <Columns>
                    <asp:ButtonColumn Text="ɾ��" CommandName="Delete" HeaderText="ɾ��">
                        <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                    </asp:ButtonColumn>
                    <asp:BoundColumn DataField="username" HeaderText="������">
                        <HeaderStyle ForeColor=#0F83EC Width=150px></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="addtime" HeaderText="����ʱ��">
                        <HeaderStyle ForeColor=#0F83EC HorizontalAlign=Left></HeaderStyle>
                        <ItemStyle HorizontalAlign=Left></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </asp:DataGrid>
        </form>
    </body>
</HTML>
