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

namespace SCard.admin
{
	/// <summary>
	/// otherAnnounce ��ժҪ˵����
	/// </summary>
	public partial class otherAnnounce : System.Web.UI.Page
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

            if( !IsPostBack )
            {
                getAnnounce();//��ȡ������Ϣ
            }
		}

        private void getAnnounce()
        {
            string mySql="select * from append where id='3'";
            
            DBConn myDB = new DBConn();
            SqlDataReader mydr  = myDB.getDataReader( mySql );
            if( mydr.Read() )
            {
                txtAnnounce.Text = CleanString.htmlOutputText( mydr["text"].ToString() );
            }
            mydr.Close();
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

        protected void btnOk_Click(object sender, System.EventArgs e)
        {
            string strAnnounce = CleanString.htmlInputText( txtAnnounce.Text );
            string mySql="update [Append] set [text]='" + strAnnounce + "' where [id]='3'";
            DBConn myDB = new DBConn();
            int iNum = myDB.ExecuteNonQuery( mySql );
            myDB.Close();    
 
            if( iNum == 1 )
            {
                Response.Write("<script>");
                Response.Write("alert('[������] �޸ĳɹ�!!!');");
                Response.Write("</script>");
            }
        }
	}
}
