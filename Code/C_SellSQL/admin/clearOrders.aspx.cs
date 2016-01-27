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
	/// clearOrders ��ժҪ˵����
	/// </summary>
	public partial class clearOrders : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //Ȩ�޼��
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000>�Բ���,��û�㹻Ȩ�޷��ʴ�ҳ!!</font>");
                Response.Write("<a href=index.aspx >���µ�½</a>");
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
            string strName = txtName.Text;
            string strPassword = txtPassword.Text.Trim();

            if( strPassword == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('���������Ա����!!!');");
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
                Response.Write("alert('������ж�����¼ �ɹ�!!!');");
                Response.Write("</script>");
                   
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('��������ȷ�� ����Ա����!!!');");
                Response.Write("</script>");
            }


        }
	}
}