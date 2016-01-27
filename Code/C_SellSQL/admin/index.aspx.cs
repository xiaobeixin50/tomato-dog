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

using System.Data.SqlClient;
using System.Web.Security;

namespace SCard.admin
{
	/// <summary>
	/// Default 的摘要说明。
	/// </summary>
	public partial class index : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            
            Session["adminName"]=null;

            //--直接登录代码
           // Session["adminName"] = "admin";
           // Response.Redirect("adminManage.aspx");
		}

        private bool isAdmin( string strAdmin, string strPassword )
        {
            bool bTemp = false;
            
            strPassword = FormsAuthentication.HashPasswordForStoringInConfigFile( strPassword ,"MD5"); 

            DBConn myDB = new DBConn();
            string mySql = "select * from admin where username='" + strAdmin + "' and password='" + strPassword + "'";
            SqlDataReader mydr = myDB.getDataReader( mySql );
            if( mydr.Read() )
            {
                bTemp = true;
            }
            else
            {
                bTemp = false;
            }

            mydr.Close();
            myDB.Close();

            return bTemp;
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

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            string strAdminname = txtAdminname.Text;
            string strAdminPW = txtAdminPW.Text;

            if( strAdminname == String.Empty || strAdminPW == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('管理名/密码 不能为空!!!');");
                Response.Write("</script>");
                return;
            }

            if( Session["CheckCode"] == null )
            {
                Response.Redirect("index.aspx");
                return;
            }
            if( Session["CheckCode"].ToString() != txtCheck.Text.Trim() )
            {
                Response.Write("<script>");
                Response.Write ("alert('输入的验证码有误！请重新输入！')");
                Response.Write ("</script>");
                return;
            }

            if( isAdmin( strAdminname, strAdminPW ) )
            {
                Session["adminName"] = strAdminname;
                Response.Redirect("adminManage.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('管理名/密码 不正确!!!');");
                Response.Write("</script>");
            }
        }



        protected void exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }
}
}
