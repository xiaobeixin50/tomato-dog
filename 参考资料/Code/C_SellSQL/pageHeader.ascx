<%@ Control Language="c#" Inherits="SCard.pageHeader" CodeFile="pageHeader.ascx.cs" %>
<!-- ҳͷ��ʼ -->

<table width=760 height=22 background=images/sh.gif>
    <tr>
        <td style="text-align: center; font-size: 120%; color: gold; font-family: Arial;" >
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
            <em><span style="font-family: @���Ĳ���"><strong style="font-size: large; color: orange; font-family: ����"><span style="color: #ffcc00; font-family: ���Ĳ���">���������罻��ƽ̨</span></strong> 
            </span></em>&nbsp;<asp:Label  id="lblDateTime" runat="server" style="font-size: small; font-family: Monospace" Font-Names="@����"></asp:Label><br />
            <br />
        </td>
    </tr>
</table>

<table height="17" cellpadding=0 cellspacing=0 background=images/indexbg.gif style="width: 757px">
    <tr align=center height=27>
        <td height="13" background=images/index_1.gif style="width: 5px"></td>
        <td style="width: 26px"></td>
        <td width="62"><a href=index.aspx>�� ҳ</a></td>
        <td width=10><img src=images/line.gif></td>
        <td style="width: 80px" ><a href=productsList.aspx>�������б�</a></td>
        <td width=10><img src=images/line.gif></td>
        <%=strLg %>
          <td style="width: 83px"><a href=orderSelect.aspx>������ѯ</a></td>
        <td width=10><img src=images/line.gif></td>
          <td style="width: 92px"><a href=message.aspx>�û�����</a></td>
        <td style="width: 16px"><img src=images/line.gif></td>       
       
        <td background=images/index_2.gif style="width: 5px"></td>
    </tr>
</table>
<table width=760 class="ZWenbg" ><tr><td></td></tr></table>
<!-- ҳͷ���� -->
