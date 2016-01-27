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
	/// productsList 的摘要说明。
	/// </summary>
	public partial class productsList : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if( !IsPostBack )
			{
                ViewState["CID"] = null;

                if(Request.QueryString["cid"] != null)
                {
                    string strCID = Request.QueryString["cid"].ToString();
                    ViewState["CID"] = CleanString.htmlInputText( strCID );
                }

                CData();//分类列表绑定
                PData();//二手书列表绑定
                HData();//分类对应的热销二手书列表绑定

                setSelectClass();//绑定类别
			}
		}

        private void setSelectClass()
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

        private void CData()//分类列表绑定
        {
            DBConn myDB = new DBConn();
            string sql = "select * from Category";
            CRepeater.DataSource = myDB.getDataReader( sql );
            CRepeater.DataBind();
            myDB.Close();
        }

        private void PData()//二手书列表绑定
        {
            if( ViewState["CID"] == null )
            {
                MySqlPager SqlPager = new MySqlPager();
				SqlPager.setAttribute( SqlPager1, "PDataList", "select * from Products order by PID desc", "PID desc", 12);
                
                lblDaohang.Text = "所有二手书";
            }
            else
            {
                string strCID = ViewState["CID"].ToString();
                DBConn myDB = new DBConn();
                string sql="select * from Products where CID=" + strCID + " order by PID desc";
                try
                {
                    MySqlPager SqlPager = new MySqlPager();
					SqlPager.setAttribute( SqlPager1, "PDataList", sql, "PID desc", 12);
                }
                catch
                {
                    Response.Write("<script>");
                    Response.Write("alert('没有记录!!!');");
                    Response.Write("</script>");
                    myDB.Close();
                    Response.Redirect("index.aspx");
                    return;
                }
                myDB.Close();

                DBConn DB = new DBConn();
                string mySql = "select * from Category where CID=" + strCID;
                SqlDataReader dr = DB.getDataReader( mySql );
                if( dr.Read() )
                {
                    lblDaohang.Text = dr["CName"].ToString();
                }
                else
                {
                    Response.Write("<script>");
                    Response.Write("alert('没有这个类别!!!');");
                    Response.Write("</script>");
                    dr.Close();
                    DB.Close();
                    Response.Redirect("index.aspx");
                    return;
                }
                dr.Close();
                DB.Close();
            }
        }

        private void HData()//分类对应的热销二手书列表绑定
        {
            if( ViewState["CID"] == null )
            {
                DBConn myDB = new DBConn();
				string sql = "SELECT TOP 5 * FROM Products WHERE PSellNum>0 ORDER BY PSellNum DESC,PID";
                HotRepeater.DataSource = myDB.getDataReader( sql );
                HotRepeater.DataBind();
                myDB.Close();
            }
            else
            {
                string strCID = ViewState["CID"].ToString();

                DBConn myDB = new DBConn();
                string sql = "SELECT top 5 * From Products Where PSellNum>0 and CID=" + strCID + " order by PSellNum desc,PID";
                HotRepeater.DataSource = myDB.getDataReader( sql );
                HotRepeater.DataBind();
                myDB.Close();
            }
            
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
	}
}
