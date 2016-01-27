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

using System.Web.Security;

namespace SCard.admin
{
	/// <summary>
	/// adminSelf 的摘要说明。
	/// </summary>
	public partial class adminSelf : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //权限检查
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000>对不起,您没足够权限访问此页!!</font>");
                Response.Write("<a href=index.aspx>重新登陆</a>");
                Response.End();
                return;
            }

			txtAdmin.Text = Session["adminName"].ToString();
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
            string strName = txtAdmin.Text;
            string strPassword = txtPassword.Text;
            string strRPassword = txtRPassword.Text;
            
            if( strName == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('请输入管理名!!!');");
                Response.Write("</script>");
                return;
            }
            if( strPassword == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('请输入密码!!!');");
                Response.Write("</script>");
                return;
            }
            if( strRPassword == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('请输入确认密码!!!');");
                Response.Write("</script>");
                return;
            }

            if( txtPassword.Text.Length < 6 )
            {
                Response.Write("<script>");
                Response.Write("alert('密码长度至少6位!!!');");
                Response.Write("</script>");
                return;
            }
            
            strPassword = FormsAuthentication.HashPasswordForStoringInConfigFile( strPassword ,"MD5"); 

            DBConn myDB = new DBConn();
            string mySql = "UPDATE [admin] SET [password]='" + strPassword + "' WHERE [username]='" + strName + "'";
            int iTemp = myDB.ExecuteNonQuery( mySql );
            myDB.Close();

            if( iTemp != 0 )
            {
                Response.Write("<script>");
                Response.Write("alert('您的密码修改成功!!!');");
                Response.Write("</script>");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('密码修改失败!!!');");
                Response.Write("</script>");
            }
        }
	}
}
