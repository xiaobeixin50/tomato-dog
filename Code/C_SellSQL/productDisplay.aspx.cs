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
    /// productDisplay 的摘要说明。
    /// </summary>
    public partial class productDisplay : System.Web.UI.Page
    {

        public string strPID = "-1";
        public string strPName = string.Empty;
        public string strPBewrite = "";//二手书简介  
        public string strPUseMode = "";//使用说明
        public string strPValidity = "";//注意
        public string strLeaveWord = "暂无评论";
        public string strBuy = "";//打印在线购买 或 没有存货


        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string strID = Request.QueryString["id"].ToString();
                    strID = CleanString.htmlInputText(strID);

                    DBConn myDB = new DBConn();
                    string sql = "select * from products where PID=" + strID;
                    SqlDataReader dr;
                    try
                    {
                        dr = myDB.getDataReader(sql);
                    }
                    catch
                    {
                        Response.Write("<script>");
                        Response.Write("alert('没有这个二手书!!!');");
                        Response.Write("</script>");
                        Response.Redirect("index.aspx");
                        return;
                    }

                    if (dr.Read())
                    {
                        ViewState["CID"] = dr["CID"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>");
                        Response.Write("alert('没有这个二手书!!!');");
                        Response.Write("</script>");
                        dr.Close();
                        myDB.Close();
                        Response.Redirect("index.aspx");
                        return;
                    }
                    dr.Close();
                    myDB.Close();

                    ViewState["ID"] = strID;


                }

                CData();
                HData();//分类对应的热销二手书列表绑定
                DHData();

                leaveWord();

                setSelectClass();//绑定 类别选框
            }
            PData();

        }

        private void setSelectClass()//绑定 类别选框
        {
            DBConn myDB = new DBConn();
            string mySql = "select CID,CName from Category order by CID desc";
            ddlClass.DataSource = myDB.getDataReader(mySql);
            ddlClass.DataTextField = "CName";
            ddlClass.DataValueField = "CID";
            ddlClass.DataBind();
            myDB.Close();

            ddlClass.Items.Insert(0, new ListItem("所有分类", "-1"));
        }

        private void PData()//显示相应二手书信息
        {
            string strID = ViewState["ID"].ToString();

            DBConn myDB = new DBConn();
            string sql = "select * from Products where PID=" + strID;
            SqlDataReader dr = myDB.getDataReader(sql);
            if (dr.Read())
            {
                strPID = dr["PID"].ToString();
                lblPName.Text = dr["PName"].ToString();
                strPName = lblPName.Text;
                lblPFPrice.Text = double.Parse(dr["PFPrice"].ToString()).ToString("f2");
                lblPNPrice.Text = double.Parse(dr["PNPrice"].ToString()).ToString("f2");
                strPBewrite = dr["PBewrite"].ToString();
                strPUseMode = dr["PUseMode"].ToString();
                strPValidity = dr["PValidity"].ToString();
                string strPStock = dr["PStock"].ToString();
                if (Int32.Parse(strPStock) > 0)
                {
                    strBuy = "<img src='images/car.gif'> [ <A target=_blank href='makeOrder.aspx?id=" + strPID + "'>在线购买</A> ]";
                }
                else
                {
                    strBuy = "[ 没有存货 ]";
                }
            }
            dr.Close();
            myDB.Close();
        }

        private void CData()//分类列表绑定
        {
            DBConn myDB = new DBConn();
            string sql = "select * from Category";
            CRepeater.DataSource = myDB.getDataReader(sql);
            CRepeater.DataBind();
            myDB.Close();
        }

        private void DHData()//导航条设置
        {
            string strCID = ViewState["CID"].ToString();

            if (ViewState["CID"] == null || ViewState["CID"].ToString() == String.Empty)
            {
                lblDaohang.Text = "所有二手书";
            }
            else
            {
                DBConn myDB = new DBConn();
                string sql = "select * from Category where CID=" + strCID;
                SqlDataReader dr = myDB.getDataReader(sql);
                if (dr.Read())
                {
                    lblDaohang.Text = dr["CName"].ToString();
                }
                dr.Close();
                myDB.Close();
            }
         
        }

        private void leaveWord()//评论
        {
            DBConn myDB = new DBConn();
            string sql = "select * from tblLeaveWord where PID=" + Request.QueryString["id"];
            strLeaveWord = "";
            DataSet ds1 = myDB.getDataSet(sql);
            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                strLeaveWord += "<br>用户id:" + row["UserName"].ToString() + "-----------";
                strLeaveWord += row["isDate"].ToString() + "<br>" ;

                strLeaveWord += row["isNote"].ToString() + "<br>" + "<br>";
            }
            myDB.Close();

        }
        private void HData()//分类对应的热销二手书列表绑定
        {
            if (ViewState["CID"] == null || ViewState["CID"].ToString() == String.Empty)
            {
                DBConn myDB = new DBConn();
                string sql = "SELECT TOP 5 * FROM Products WHERE PSellNum>0 ORDER BY PSellNum DESC,PID";
                HotRepeater.DataSource = myDB.getDataReader(sql);
                HotRepeater.DataBind();
                myDB.Close();
            }
            else
            {
                string strCID = ViewState["CID"].ToString();

                DBConn myDB = new DBConn();
                string sql = "select top 5 * from Products where PSellNum>0 and CID=" + strCID + " order by PSellNum desc,PID";
                HotRepeater.DataSource = myDB.getDataReader(sql);
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
            string strText = Server.UrlEncode(txtSelect.Text);

            Response.Redirect("Select.aspx?class=" + strClass + "&text=" + strText);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
         if (Session["User"] != null)
            {
                string Pid = Request.QueryString["id"].ToString();
                string tblUser = (String)Session["User"];
                DBConn myDB = new DBConn();

                if (myDB.LookUp("select id from tblFav  where tblUser='" + (string)Session["User"] + "' and Pid=" + Pid, "id") != "")
                 
              {    Response.Write("<script>alert('您已经收藏该产品了 ~');</script>");
              myDB.Close();

                  return;
              }
                string sql = "insert into [tblFav](tblUser,Pid) values ( '" + tblUser + "', '" + Pid + "')";

             
                myDB.ExecuteNonQuery(sql);
                myDB.Close();

                Response.Write("<script>alert('收藏成功 ~');</script>");
            }
            else
            {
                Response.Write("<script>alert('未登陆无法收藏~');</script>");
            }




        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveWord.aspx?id=" + Request.QueryString["id"].ToString());
        }
    }
}
