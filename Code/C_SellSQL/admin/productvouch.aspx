<%@ Register TagPrefix="cc1" Namespace="DevCenter" Assembly="WebPager" %>
<%@ Page language="c#" Inherits="SCard.admin.productVouch" ResponseEncoding="utf-8" CodeFile="productVouch.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>productVouch</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="style.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <table align='center' width='100%' cellpadding='4' cellspacing='1' border='1' class='grid fixed'>
		        <tr>
			        <td class='category'>�Ƽ��������б� - <font class='t1'>(������ʾ10��)</font></td>
		        </tr>
		    </table>
            <asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Width="100%" cellpadding='4'
                cellspacing='1' CssClass='grid fixed'>
                <HeaderStyle HorizontalAlign="Center" CssClass="category"></HeaderStyle>
                <Columns>
                    <asp:BoundColumn DataField="PID" HeaderText="���">
                        <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PName" HeaderText="����">
                        <HeaderStyle ForeColor=#0F83EC></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CName" HeaderText="���">
                        <HeaderStyle ForeColor=#0F83EC></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PStock" HeaderText="���">
                        <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PSellNum" HeaderText="�ۻ��۳�">
                        <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:ButtonColumn Text="ɾ��" CommandName="Delete" HeaderText="�޸�">
                        <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:ButtonColumn>
                </Columns>
            </asp:DataGrid>
                       
            <br>
            
            <table align='center' width='100%' cellpadding='4' cellspacing='1' border='1' class='grid fixed'>
		        <tr>
			        <td class='category'>��ѡ��������б�</td>
			        <td width=210 class='category' align=right>
			            <asp:DropDownList id="ddlClass" AutoPostBack="True" Width=150 runat="server"></asp:DropDownList>&nbsp;&nbsp;
                        <asp:Button id="btnSelect" runat="server" Text="��ѯ" onclick="btnSelect_Click"></asp:Button>&nbsp;&nbsp;
			        </td>
		        </tr>
		    </table>
            <asp:DataGrid id="PDataGrid" runat="server" AutoGenerateColumns="False" Width="100%" cellpadding='4'
                cellspacing='1' CssClass='grid fixed'>
                <HeaderStyle HorizontalAlign="Center" CssClass="category"></HeaderStyle>
                <Columns>
                    <asp:BoundColumn DataField="PID" HeaderText="���">
                        <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PName" HeaderText="����">
                        <HeaderStyle ForeColor=#0F83EC></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CName" HeaderText="���">
                        <HeaderStyle ForeColor=#0F83EC></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PStock" HeaderText="���">
                        <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PSellNum" HeaderText="�ۻ��۳�">
                        <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:ButtonColumn Text="���" CommandName="Delete" HeaderText="�޸�">
                        <HeaderStyle ForeColor=#0F83EC Width=70px></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:ButtonColumn>
                </Columns>
            </asp:DataGrid>
            <cc1:SqlPager id="SqlPager1" runat="server" PagingMode="Cached" PagerStyle="NextPrev" CacheDuration="0"></cc1:SqlPager>
        </form>
            
        <br><br><br><br>
    </body>
</HTML>
