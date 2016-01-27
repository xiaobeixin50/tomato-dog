<%@ Page language="c#" Inherits="SCard.admin.categoryAlter" ResponseEncoding="utf-8" CodeFile="categoryAlter.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>categoryAlter</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <LINK href="style.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Width="100%" cellpadding='4'
                cellspacing='1' CssClass='grid fixed'>
                <HeaderStyle CssClass="category"></HeaderStyle>
                <Columns>
                    <asp:BoundColumn Visible="False" DataField="CID" ReadOnly="True"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CName" HeaderText="�������">
                        <HeaderStyle Width="220px" ForeColor=#0F83EC></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:EditCommandColumn UpdateText="����" HeaderText="�޸�" CancelText="ȡ��" EditText="�༭">
                        <HeaderStyle Width="70px" ForeColor=#0F83EC></HeaderStyle>
                    </asp:EditCommandColumn>
                    <asp:ButtonColumn Text="ɾ��" HeaderText="ɾ��" CommandName="Delete">
                        <HeaderStyle ForeColor=#0F83EC></HeaderStyle>
                    </asp:ButtonColumn>
                </Columns>
            </asp:DataGrid>
        </form>
    </body>
</HTML>
