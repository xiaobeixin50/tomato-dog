using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SCard.admin
{
	/// <summary>
	/// productHot ��ժҪ˵����
	/// </summary>
	public partial class productHot : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //Ȩ�޼��
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000>�Բ���,��û�㹻Ȩ�޷��ʴ�ҳ!!</font>");
                Response.Write("<a href=index.aspx>���µ�½</a>");
                Response.End();
                return;
            }

          
		}

        protected void Button1_Click(object sender, EventArgs e)
        {
         
            string ����,����;
            DBConn db1 = new DBConn();

            ���� = db1.LookUp("select sum(ismoney) as '1' from viwlog  where isDate between '" + TextBox1.Text + " 00:00:00' and '" + TextBox2.Text + " 23:59:00'", "1");
            ���� = db1.LookUp("select sum(totalprice) as '1' from [order]  where pubdate between '" + TextBox1.Text + " 00:00:00' and '" + TextBox2.Text + " 23:59:00'", "1");
            if (���� == "") ���� = "0";
            if (���� == "") ���� = "0";
            lblNote.Text = "����= " + (double.Parse(����) - double.Parse(����)); 
        }
}
}
