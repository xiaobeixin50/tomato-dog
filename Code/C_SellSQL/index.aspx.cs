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

namespace SCard
{
	/// <summary>
	/// Default ��ժҪ˵����
	/// </summary>
	public partial class index : System.Web.UI.Page
	{
        
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if( !IsPostBack )
            {
                CData();//�����б��
                setSelectClass();//�����
                getHotDataList();//����������
                getNewDataList();//�����ϼ�
                getTJDataList();//��Ʒ�Ƽ�

                getAnnounce();//��ȡ������Ϣ
            }
		}

        private void getAnnounce()//��ȡ������Ϣ
        {
            string mySql="select * from append where id='3'";
            
            DBConn myDB = new DBConn();
            SqlDataReader mydr  = myDB.getDataReader( mySql );
            if( mydr.Read() )
            {
                lblAnnounce.Text = CleanString.htmlOutputText( mydr["text"].ToString() );
            }
            mydr.Close();
            myDB.Close();        
        }

        private void CData()//�����б��
        {
            DBConn myDB = new DBConn();
            string sql = "select * from Category";
            CRepeater.DataSource = myDB.getDataReader( sql );
            CRepeater.DataBind();
            myDB.Close();
        }

        private void setSelectClass()//�����
        {
            DBConn myDB = new DBConn();
            string mySql = "select CID,CName from Category order by CID desc";
            ddlClass.DataSource  = myDB.getDataReader( mySql );
            ddlClass.DataTextField = "CName";
            ddlClass.DataValueField = "CID";
            ddlClass.DataBind();
            myDB.Close();
            
            ddlClass.Items.Insert(0,new ListItem("���з���","-1"));
        }

        private void getHotDataList()//����������
        {
            DBConn myDB = new DBConn();
            string sql = "select top 10 * from Products where PHot=1 order by PID desc";
            HDataList.DataSource = myDB.getDataReader( sql );
            HDataList.DataBind();
            myDB.Close();  
        }

        private void getNewDataList()//�����ϼ�
        {
            DBConn myDB = new DBConn();
            string sql = "select top 6 * from Products order by PID desc";
            NDataList.DataSource = myDB.getDataReader( sql );
            NDataList.DataBind();
            myDB.Close();  
        }
        
        private void getTJDataList()//��Ʒ�Ƽ�
        {
            DBConn myDB = new DBConn();
            string sql = "select top 10 * from Products where PCommend=1 order by PID desc";
            JRepeater.DataSource = myDB.getDataReader( sql );
            JRepeater.DataBind();
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

        protected void btnSelect_Click(object sender, System.EventArgs e)
        {
            string strClass = ddlClass.SelectedValue;
            string strText = Server.UrlEncode( txtSelect.Text );

            Response.Redirect("Select.aspx?class=" + strClass + "&text=" + strText);
        }
        protected void PageFooter1_Load(object sender, EventArgs e)
        {

        }
}
}
