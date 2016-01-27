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
	/// categoryAdd 的摘要说明。
	/// </summary>
	public partial class categoryAdd : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000>对不起,您没足够权限访问此页!!</font>");
                Response.Write("<a href=index.aspx>重新登陆</a>");
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

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
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
				Response.Write("alert('请输入类别名称!!!');");
				Response.Write("</script>");
				return;
			}
			else if( strName.Length > 35 )
			{
				Response.Write("<script>");
				Response.Write("alert('输入类别名称太长了!!!');");
				Response.Write("</script>");
				return;
			}
			
			DBConn myDB = new DBConn();
			string sql="insert into Category(CName) values('" + strName + "')";
			myDB.ExecuteNonQuery(sql);
			myDB.Close();
			
            Response.Write("<script>");
            Response.Write("alert('成功添加!!!');");
            Response.Write("</script>");

			TextBox1.Text="";
			getData();
		}
	}
}
