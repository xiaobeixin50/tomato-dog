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
    /// orderList ��ժҪ˵����
    /// </summary>
    public partial class myFav : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Request.QueryString["did"] != null)
                {
                    string Pid = Request.QueryString["did"].ToString();

                    string sql = "delete from  [tblFav] where id=" + Pid;

                    DBConn myDB = new DBConn();

                    myDB.ExecuteNonQuery(sql);
                    myDB.Close();
                }

                getData();
            }
        }

        private void getData()//������
        {


            string sql = "select * from [viwFav] where tblUser='" + (string)Session["User"] + "'order by ID desc";
            /*
            DBConn myDB = new DBConn();
            OrderDataGrid.DataSource  = myDB.getDataReader( sql );
            OrderDataGrid.DataBind();
            myDB.Close();
            */

            //��ҳ
            //MySqlPager SqlPager = new MySqlPager();
            //SqlPager.setAttribute( SqlPager1, "OrderDataGrid", sql, "'3000-1-1'-Pubdate", 20);
            MySqlPager SqlPager = new MySqlPager();
            SqlPager.setAttribute(SqlPager1, "FavDataGrid", sql, "3000000-ID", 20);
        }

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //

            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>

        #endregion



        protected void OrderDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
