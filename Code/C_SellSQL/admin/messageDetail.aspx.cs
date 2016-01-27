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
	/// messageDetail ��ժҪ˵����
	/// </summary>
	public partial class messageDetail : System.Web.UI.Page
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

            if( !IsPostBack )
            {
                string strID = Request.QueryString["id"].ToString();//��messageelistת����ϸ��Ϣ��id
                alterState( strID ); //�ı���Ϣ ״̬
                getData( strID ); //��ȡ��Ϣ����
            }
		}

        private void alterState( string strID )
        {
            string mySql = "update message set MState=1 where MState<>1 and MID=" + strID;
            DBConn myDB = new DBConn();
            myDB.ExecuteNonQuery(mySql);
            myDB.Close();
        }

        private void getData( string strID )
        {
            string mySql = "select * from message where MID=" + strID;
            DBConn myDB = new DBConn(); 
            SqlDataReader mydr  = myDB.getDataReader( mySql );
            if( mydr.Read() )
            {
                lblUName.Text = mydr["UName"].ToString();
                lblUPhone.Text = mydr["UPhone"].ToString();
                string strUEmail = mydr["UEmail"].ToString();
                lblUEmail.Text = "<a href='mailto:" + strUEmail + "'>" + strUEmail + "</a>";
                lblMTitle.Text = mydr["MTitle"].ToString();
                txtMContent.Text = CleanString.htmlOutputText( mydr["MContent"].ToString() ); 
                lblDate.Text = mydr["Pubdate"].ToString();
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
	}
}
