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
    /// makeOrder ��ժҪ˵����
    /// </summary>
    public partial class makeOrder : System.Web.UI.Page
    {


        protected System.Web.UI.WebControls.Label lblScript;
        protected System.Web.UI.WebControls.LinkButton LinkButton1;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != String.Empty)
                {
                    if (Session["User"] != null)
                    {
                        txtName.Enabled = false;
                        txtName.Text = (string)Session["User"];
                        DBConn db1 = new DBConn();
                     TextBox1.Text = db1.LookUp("select ��ʵ���� from tblUser  where UserName='" + (string)Session["User"] + "'", "��ʵ����")  ;
             
                    }
                    else
                    {

                        Response.Write("<script>alert('δ��½��ֹ����');window.close();</script>");
                        Response.End();
                        return;
                    }
                    string strID = Request.QueryString["id"].ToString();
                    strID = CleanString.htmlInputText(strID);
                    ViewState["ID"] = strID;

                    PData();
                    string DBPath = ConfigurationSettings.AppSettings["DataBasePath"];
                    string connStr = (DBPath);

                    SqlConnection con = new SqlConnection(connStr);
                    con.Open();
                    string sql = "select * from tblMode";
                    SqlDataAdapter sda1 = new SqlDataAdapter(sql, con);

                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "tblMode");

                    foreach (DataRow row in ds1.Tables[0].Rows)
                    {
                        this.dplBm.Items.Add(row["����"].ToString());
                    }


                }
                else
                {
                    Response.Write("<script>");
                    Response.Write("alert('û�����������!!!');");
                    Response.Write("</script>");
                    Response.Redirect("index.aspx");
                    return;
                }
                double dblNum = Int32.Parse(DropDownList1.SelectedValue) * double.Parse(lblPNPrice.Text);
                lblCount.Text = dblNum.ToString("f2");
            }

        }

        private void PData()//��ʾ��Ӧ��������Ϣ
        {
            string strID = ViewState["ID"].ToString();

            DBConn myDB = new DBConn();
            string sql = "select * from Products where PID=" + strID;
            SqlDataReader dr;
            try
            {
                dr = myDB.getDataReader(sql);
            }
            catch
            {
                Response.Write("<script>");
                Response.Write("alert('û�����������!!!');");
                Response.Write("</script>");
                Response.Redirect("index.aspx");
                return;
            }
            if (dr.Read())
            {
                string strPID = "";
                strPID = dr["PID"].ToString();

                myImg.Src = "showPP.aspx?id=" + strPID;
                lblPName.Text = dr["PName"].ToString();
                lblPFPrice.Text = double.Parse(dr["PFPrice"].ToString()).ToString("f2");
                lblPNPrice.Text = double.Parse(dr["PNPrice"].ToString()).ToString("f2");
                lblTotalPric.Text = lblPNPrice.Text;

                ViewState["PCPrice"] = dr["PCPrice"].ToString();

                string strPStock = dr["PStock"].ToString();
                if (Int32.Parse(strPStock) > 0)
                {
                    lblIsStock.Text = "[�ֿ��л�]";
                }
                else
                {
                    lblIsStock.Text = "[û�д��]";
                    btnOK.Enabled = false;
                }
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('û�����������!!!');");
                Response.Write("</script>");
                dr.Close();
                myDB.Close();
                Response.Redirect("index.aspx");
                return;
            }
            dr.Close();
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

        protected void ddlNum_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            double dblNum = Int32.Parse(ddlNum.SelectedValue) * double.Parse(lblPNPrice.Text);
            lblTotalPric.Text = dblNum.ToString("f2");
        }

        protected void btnClear_Click(object sender, System.EventArgs e)
        {
       
            txtEmail.Text = "";
            txtPhone.Text = "";
            ddlNum.SelectedIndex = 0;
            lblTotalPric.Text = lblPNPrice.Text;

            txtCheck.Text = "";
        }

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            string strID = ViewState["ID"].ToString();
            string strName = txtName.Text.Trim();
            string strEmail = txtEmail.Text.Trim();
            string strPhone = txtPhone.Text.Trim();
            string strNum = ddlNum.SelectedValue;

            if (strName == String.Empty || strEmail == String.Empty || strPhone == String.Empty)
            {
                Response.Write("<script>");
                Response.Write("alert('��ѱ���������!!!');");
                Response.Write("</script>");
                return;
            }
         //   if (Session["CheckCode"] == null)
           // {
           //     Response.Redirect("index.aspx");
            //    return;
           // }
            if (Session["CheckCode"].ToString() != txtCheck.Text.Trim())
            {
                Response.Write("<script>");
                Response.Write("alert('�������֤���������������룡')");
                Response.Write("</script>");
                return;
            }

            //�����
            DBConn myDB = new DBConn();
            string mySql = "select PStock from Products where PID=" + strID;
            SqlDataReader mydr = myDB.getDataReader(mySql);
            if (mydr.Read())
            {
                int iPStock = Int32.Parse(mydr["PStock"].ToString());
                if (iPStock < int.Parse(strNum))
                {
                    Response.Write("<script>");
                    Response.Write("alert('��治��!!!���ڿ�滹��[ " + iPStock.ToString() + " ]');");
                    Response.Write("</script>");
                    return;
                }

            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('û�����������!!!');");
                Response.Write("</script>");
                mydr.Close();
                myDB.Close();
                Response.Redirect("index.aspx");
                return;
            }
            mydr.Close();
            myDB.Close();

            Order myOrder = new Order();
            
            myOrder.PID = strID;
            myOrder.PName = lblPName.Text;
            myOrder.PNum = strNum.ToString();
            myOrder.PPrice = lblPNPrice.Text;
            myOrder.TotalPrice = lblTotalPric.Text;
            myOrder.TName = CleanString.htmlInputText(strName);
            myOrder.Email = strEmail;
            myOrder.Phone = CleanString.htmlInputText(strPhone);
            if (ViewState["PCPrice"] != null)
            {
                myOrder.PCPrice = ViewState["PCPrice"].ToString();
            }


            Session["myOrder"] = myOrder;

            if (Session["SubmitCheck"] != null)
            {
                DateTime myDTime = (DateTime)Session["SubmitCheck"];
                if (myDTime.AddMilliseconds(30000) > DateTime.Now)
                {
                    Response.Write("<script>");
                    TimeSpan myTime = DateTime.Now - (DateTime)Session["SubmitCheck"];
                    Response.Write("alert('����Ƶ���ύ,����" + (30 - myTime.Seconds) + "������!!!');");
                    Response.Write("</script>");
                    return;
                }
            }
            Session["SubmitCheck"] = DateTime.Now;

            Response.Redirect("orderinfo.aspx?key=" + Server.UrlEncode("makeOrder.aspx?id=" + ViewState["ID"].ToString()));

        }

        private void btnNewCode_Click(object sender, System.EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                string Pid = Request.QueryString["id"].ToString();


  
                //�����

                string strNum = DropDownList1.SelectedValue;

                DBConn myDB = new DBConn();
                string mySql = "select PStock from Products where PID=" + Pid;
                SqlDataReader mydr = myDB.getDataReader(mySql);
                if (mydr.Read())
                {
                    int iPStock = Int32.Parse(mydr["PStock"].ToString());
                    if (iPStock < int.Parse(strNum))
                    {
                        Response.Write("<script>");
                        Response.Write("alert('��治��!!!���ڿ�滹��[ " + iPStock.ToString() + " ]');");
                        Response.Write("</script>");
                        return;
                    }

                }
                else
                {
                    Response.Write("<script>");
                    Response.Write("alert('û�����������!!!');");
                    Response.Write("</script>");
                    mydr.Close();
                    myDB.Close();
                    Response.Redirect("index.aspx");
                    return;
                }
                mydr.Close();
                myDB.Close();

                

                string tblUser = (String)Session["User"];
                string sql = "insert into [tblBasket](tblUser,Pid,isN,isMoney) values ( '" + tblUser + "', '" + Pid + "', '" + strNum + "', " + lblCount.Text +")";

                DBConn myDB1 = new DBConn();

                myDB1.ExecuteNonQuery(sql);
                myDB1.Close();

                Response.Write("<script>alert('���빺�ﳵ�ɹ� ~');</script>");
            }
            else
            {
                Response.Write("<script>alert('δ��½�޷��ղ�~');</script>");
            }
                  
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double dblNum = Int32.Parse(DropDownList1.SelectedValue) * double.Parse(lblPNPrice.Text);
            lblCount.Text = dblNum.ToString("f2");
        }
}
}
