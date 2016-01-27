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
	/// categoryAdd ��ժҪ˵����
	/// </summary>
	public partial class categoryAdd : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000>�Բ���,��û�㹻Ȩ�޷��ʴ�ҳ!!</font>");
                Response.Write("<a href=index.aspx>���µ�½</a>");
                Response.End();
                return;
            }

			
		}

		private void getData()
		{
			DBConn myDB = new DBConn();
			string sql="select * from Category order by CID desc";
            Repeater1.DataSource = myDB.getDataReader(sql);
			Repeater1.DataBind();
            myDB.Close();
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			string strName = TextBox1.Text;
			if( strName.Trim() == String.Empty )
			{
				Response.Write("<script>");
				Response.Write("alert('�������������!!!');");
				Response.Write("</script>");
				return;
			}
			else if( strName.Length > 35 )
			{
				Response.Write("<script>");
				Response.Write("alert('�����������̫����!!!');");
				Response.Write("</script>");
				return;
			}
			
			DBConn myDB = new DBConn();
			string sql="insert into Category(CName) values('" + strName + "')";
			myDB.ExecuteNonQuery(sql);
			myDB.Close();
			
            Response.Write("<script>");
            Response.Write("alert('�ɹ����!!!');");
            Response.Write("</script>");

			TextBox1.Text="";
			getData();
		}
	}
}
