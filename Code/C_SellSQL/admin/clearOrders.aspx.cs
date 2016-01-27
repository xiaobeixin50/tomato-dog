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
	/// clearOrders 的摘要说明。
	/// </summary>
	public partial class clearOrders : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //权限检查
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000>对不起,您没足够权限访问此页!!</font>");
                Response.Write("<a href=index.aspx >重新登陆</a>");
                Response.End();
                return;
            }

            if( !IsPostBack )
            {
                txtName.Text = Session["adminName"].ToString();
            }
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
            string strName = txtName.Text;
            string strPassword = txtPassword.Text.Trim();

            if( strPassword == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('请输入管理员密码!!!');");
                Response.Write("</script>");
                return;
            }
           

            if( isAdmin( strName, strPassword ) )
            {
                DBConn myDB = new DBConn();
                string mySql = "delete from [Order]";
				myDB.ExecuteNonQuery( mySql );
                string sql = "delete from [tblP_Order]";
                myDB.ExecuteNonQuery(sql );
			
                myDB.Close();

                Response.Write("<script>");
                Response.Write("alert('清空所有订单记录 成功!!!');");
                Response.Write("</script>");
                   
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('请输入正确的 管理员密码!!!');");
                Response.Write("</script>");
            }


        }
	}
}
