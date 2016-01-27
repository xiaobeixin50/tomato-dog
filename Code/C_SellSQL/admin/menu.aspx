<%@ Page language="c#" Inherits="SCard.admin.menu" ResponseEncoding="utf-8" CodeFile="menu.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
    <head>
        <title>menu</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <LINK href="style.css" type="text/css" rel="stylesheet">
        <style rel='stylesheet'>
       div	{
			width:			100%;
			text-align:		left;
		    }
		ul	{
			width:			90%;
			text-align:		left;
            margin:			0px;
			display:		inline;
		    }
        </style>
        <script language='javascript'>
		function over(obj)
		{
			obj.style.color = '#ff6600';
			obj.style.backgroundColor = '#f7f7f7';
		}
		function out(obj)
		{
			obj.style.color = '';
			obj.style.backgroundColor = '';
		}
		function shift(id)
		{
			var obj = document.getElementById(id);
			if (obj.style.display == 'none')
			{
				obj.style.display = 'inline';
			}
			else
			{
				obj.style.display = 'none';
			}
		}
        </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
        </form>
        <base target='right' />
        <div class='grid'>
            <div class='category cursor' onmouseover='over(this)' onmouseout='out(this)' onclick="shift('system')">ϵͳ</div>
            <ul id='system'>
                <li>
                
                    <a href='../index.aspx' target='_blank'>�򿪵�����ҳ</a></li>
                <li>
                    <a href='adminOutlogin.aspx' target='_top'>�˳���¼</a></li>
            </ul>
        </div>
        <br />
        <div class='grid'>
            <div class='category cursor' onmouseover='over(this)' onmouseout='out(this)' onclick="shift('board')">�������</div>
            <ul id='board' style='display:none'>
                <li>
                    <a href='categoryAdd.aspx'>��������</a></li>
                <li>
                    <a href='categoryAlter.aspx'>�޸�/ɾ��</a></li>
            </ul>
        </div>
        <br />
        <div class='grid'>
            <div class='category cursor' onmouseover='over(this)' onmouseout='out(this)' onclick="shift('product')">���������</div>
            <ul id='product' style='display:none'>
                <li>
                    <a href='productAdd.aspx'>��Ӷ�����</a></li>
                <li>
                    <a href='productAlter.aspx'>��ϸ����</a></li>  
                     <li>
                    <a href='productTJ.aspx'>ӯ������</a></li>       
                <li>
                    <a href='productVouch.aspx'>�Ƽ�������</a></li>
                 <li>
                    <a href='productHot.aspx'>����������</a></li>
            </ul>
        </div>
        <br />
        <div class='grid'>
            <div class='category cursor' onmouseover='over(this)' onmouseout='out(this)' onclick="shift('order')">��������</div>
            <ul id='order'>
                <li>
                    <a href='orderList.aspx'>�鿴����</a></li>
                    
                <li>
                    <a href='orderTidy.aspx'>������</a></li>
                    <li>
                    <a href='clearOrders.aspx'>��ն�����¼</a></li>
                
            </ul>
        </div>
        <br />
        <div class='grid'>
            <div class='category cursor' onmouseover='over(this)' onmouseout='out(this)' onclick="shift('message')">���԰���Ϣ����</div>
            <ul id='message'>
                <li>
                    <a href='messageList.aspx?State=0'>δ����Ϣ</a></li>
                <li><a href='messageList.aspx?State=1'>�Ѷ���Ϣ</a></li>
                <li>
                    <a href='../myleavwWord.aspx'>������Ʒ����</a></li>
            </ul>
        </div>
        <br />
        <div class='grid'>
            <div class='category cursor' onmouseover='over(this)' onmouseout='out(this)' onclick="shift('admin')">����Ա����</div>
            <ul id='admin' style='display:none'>
            <li><a href='View_User.aspx'>��Ա����</a></li>
                <li>
                    <a href='adminAdd.aspx'>��������Ա</a></li>
                <li>
                    <a href='adminList.aspx'>���й���Ա</a></li>
                <li>
                    <a href='adminSelf.aspx'>�޸��ҵĵ�½����</a></li>
            </ul>
        </div>
        <br /> 
        <div class='grid'>
            <div class='category cursor' onmouseover='over(this)' onmouseout='out(this)' onclick="shift('other')">ϵͳ����</div>
            <ul id='other' style='display:none'>
                <li>
                    <a href='otherAnnounce.aspx'>�޸Ĺ���</a></li>
               
                <li>
                    <a href='otherDefaultPicture.aspx'>�޸�Ĭ��ͼƬ</a></li>
                
                <li>
                    <a href='initialize.aspx'>ϵͳ��ʼ��</a></li>
            </ul>
        </div>
        <br/>
        <div class='grid'>
            <div class='category cursor' onmouseover='over(this)' onmouseout='out(this)' onclick="shift('wangguan')">
                �ʵݷ�ʽ����</div>
            <ul id='wangguan' style='display:none'>
                <li>
                    <a href='Info_Bm.aspx'>�ʵݷ�ʽ����</a> </li></ul>
        </div>
        <br /> 
        <br>
        <div align='left'>
           
        </div>
    </body>
</html>
