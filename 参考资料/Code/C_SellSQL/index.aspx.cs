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
	/// Default 的摘要说明。
	/// </summary>
	public partial class index : System.Web.UI.Page
	{
        
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if( !IsPostBack )
            {
                CData();//分类列表绑定
                setSelectClass();//绑定类别
                getHotDataList();//热卖二手书
                getNewDataList();//最新上架
                getTJDataList();//精品推荐

                getAnnounce();//获取公告信息
            }
		}

        private void getAnnounce()//获取公告信息
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

        private void CData()//分类列表绑定
        {
            DBConn myDB = new DBConn();
            string sql = "select * from Category";
            CRepeater.DataSource = myDB.getDataReader( sql );
            CRepeater.DataBind();
            myDB.Close();
        }

        private void setSelectClass()//绑定类别
        {
            DBConn myDB = new DBConn();
            string mySql = "select CID,CName from Category order by CID desc";
            ddlClass.DataSource  = myDB.getDataReader( mySql );
            ddlClass.DataTextField = "CName";
            ddlClass.DataValueField = "CID";
            ddlClass.DataBind();
            myDB.Close();
            
            ddlClass.Items.Insert(0,new ListItem("所有分类","-1"));
        }

        private void getHotDataList()//热卖二手书
        {
            DBConn myDB = new DBConn();
            string sql = "select top 10 * from Products where PHot=1 order by PID desc";
            HDataList.DataSource = myDB.getDataReader( sql );
            HDataList.DataBind();
            myDB.Close();  
        }

        private void getNewDataList()//最新上架
        {
            DBConn myDB = new DBConn();
            string sql = "select top 6 * from Products order by PID desc";
            NDataList.DataSource = myDB.getDataReader( sql );
            NDataList.DataBind();
            myDB.Close();  
        }
        
        private void getTJDataList()//精品推荐
        {
            DBConn myDB = new DBConn();
            string sql = "select top 10 * from Products where PCommend=1 order by PID desc";
            JRepeater.DataSource = myDB.getDataReader( sql );
            JRepeater.DataBind();
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
