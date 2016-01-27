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

namespace SCard
{
	/// <summary>
	/// Select 的摘要说明。
	/// </summary>
	public partial class Select : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
			 if( !IsPostBack )
            {
                setSelectClass();//绑定类别
                
                if( Request.QueryString["class"] != null && Request.QueryString["text"] != null )//在主页传过来的搜索的类型和二手书名
                {
                    string strClass = Request.QueryString["class"].ToString();
                    string strText = Request.QueryString["text"].ToString();

                    strClass = CleanString.htmlInputText( strClass );
                    strText = CleanString.htmlInputText( Server.UrlDecode(strText) );
                    
                    CData();//分类列表绑定
                    getSelectResult(strClass, strText);//查询
                }    
            }
		}

        private void CData()//分类列表绑定
        {
            DBConn myDB = new DBConn();
            string sql = "select * from Category";
            CRepeater.DataSource = myDB.getDataReader( sql );
            CRepeater.DataBind();
            myDB.Close();
        }

        private void setSelectClass()//绑定 类别选框
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

        private void getSelectResult(string strClass, string strText)//查询
        {
            string mySql= "select * from Products order by PID desc";

            if( strClass.Equals("-1") )
            {
                mySql= "select * from Products where PName like '%" + strText + "%' order by PID desc";
            }
            else
            {
                mySql= "select * from Products where CID=" + strClass + " and PName like '%" + strText + "%' order by PID desc";
            }

            MySqlPager SqlPager = new MySqlPager();
			SqlPager.setAttribute( SqlPager1, "PDataList", mySql, "PID desc", 10);
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
            string strText = txtSelect.Text;

            strText = CleanString.htmlInputText( strText );
                    
            getSelectResult(strClass, strText);//查询
        }
	}
}
