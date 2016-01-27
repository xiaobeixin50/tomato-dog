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
	/// Default ��ժҪ˵����
	/// </summary>
	public partial class index : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            
            Session["adminName"]=null;

            //--ֱ�ӵ�¼����
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

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            string strAdminname = txtAdminname.Text;
            string strAdminPW = txtAdminPW.Text;

            if( strAdminname == String.Empty || strAdminPW == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('������/���� ����Ϊ��!!!');");
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
                Response.Write ("alert('�������֤���������������룡')");
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
                Response.Write("alert('������/���� ����ȷ!!!');");
                Response.Write("</script>");
            }
        }



        protected void exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }
}
}
