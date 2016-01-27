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
using System.Configuration;
using System.IO;



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

                    string sql = "delete from  [tblBasket] where id=" + Pid;

                    DBConn myDB = new DBConn();

                    myDB.ExecuteNonQuery(sql);
                    myDB.Close();
                }

                if (Session["User"] != null)
                {
                    txtName.Enabled = false;
                    txtName.Text = (string)Session["User"];
                    DBConn db1 = new DBConn();
                    TextBox1.Text = db1.LookUp("select ��ʵ���� from tblUser  where UserName='" + (string)Session["User"] + "'", "��ʵ����");
                    lblTotalPric.Text = db1.LookUp("select sum(ismoney) as '1' from viwBasket  where tblUser='" + (string)Session["User"] + "'", "1");
                }
                else
                {

                    Response.Write("<script>alert('δ��½��ֹ����');window.close();</script>");
                    Response.End();
                    return;
                }

                getData();

                string DBPath = ConfigurationSettings.AppSettings["DataBasePath"];
                string connStr = (DBPath);
                SqlConnection con = new SqlConnection(connStr);
       
                con.Open();
               string  sql1 = "select * from tblMode";
                SqlDataAdapter sda1 = new SqlDataAdapter(sql1, con);

                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "tblMode");

                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    this.dplBm.Items.Add(row["����"].ToString());
                }

            }
        }

        private void getData()
        {
            string sql = "select * from [viwBasket] where tblUser='" + (string)Session["User"] + "'order by ID desc";
            MySqlPager SqlPager = new MySqlPager();
            SqlPager.setAttribute(SqlPager1, "FavDataGrid", sql, "ID desc", 20);
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


        protected void btnOK_Click(object sender, System.EventArgs e)
        {
 
            string strName = txtName.Text.Trim();
            string strEmail = txtEmail.Text.Trim();
            string strPhone = txtPhone.Text.Trim();


            if (strName == String.Empty || strEmail == String.Empty || strPhone == String.Empty)
            {
                Response.Write("<script>");
                Response.Write("alert('��ѱ���������!!!');");
                Response.Write("</script>");
                return;
            }


            if (lblTotalPric.Text == String.Empty || lblTotalPric.Text == "0")
            {
               
                Response.Write("<script>");
                Response.Write("alert('���ﳵ��,û�취���ɶ���!!!');");
                Response.Write("</script>");
                return;
            }
 
         
            if (Session["CheckCode"].ToString() != txtCheck.Text.Trim())
            {
                Response.Write("<script>");
                Response.Write("alert('�������֤���������������룡')");
                Response.Write("</script>");
                return;
            }

            Order myOrder = new Order();
            myOrder.PID = "0"; //�ض���������ı�ʶ
            myOrder.TotalPrice = lblTotalPric.Text;
            myOrder.TName = CleanString.htmlInputText(strName);
            myOrder.Email = strEmail;
            myOrder.Phone = CleanString.htmlInputText(strPhone);

          Session["myOrder"]=  myOrder;
            Response.Redirect("orderinfo.aspx?key=" + Server.UrlEncode("makeOrder.aspx?id=" ));

        }
        

        protected void btnClear_Click(object sender, System.EventArgs e)
        {
     
            txtEmail.Text = "";
            txtPhone.Text = "";
      

            txtCheck.Text = "";
        }

}
}
