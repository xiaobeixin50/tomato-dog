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
    /// productData ��ժҪ˵����
    /// </summary>
    public partial class productData : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Button btnBack;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Ȩ�޼��
            if (Session["adminName"] == null || Session["adminName"].ToString() == String.Empty)
            {
                Response.Write("<font color=#ff0000>�Բ���,��û�㹻Ȩ�޷��ʴ�ҳ!!</font>");
                Response.Write("<a href=index.aspx>���µ�½</a>");
                Response.End();
                return;
            }

            if (!IsPostBack)
            {

                string strID = Request.QueryString["id"].ToString().Trim();


                ViewState["PID"] = strID;

                getPData();

            }
        }

        private void getPData()//��ȡID��Ӧ�Ķ�������Ϣ
        {

            string strID = ViewState["PID"].ToString();

            DBConn myDB1 = new DBConn();
            string sqlP = "select PName,PStock,PSellNum from Products where PID=" + strID;
            SqlDataReader dr = myDB1.getDataReader(sqlP);

            if (dr.Read())
            {
                lblPName.Text = dr["PName"].ToString();
                lblPStock.Text = dr["PStock"].ToString();
                lblPSellNum.Text = dr["PSellNum"].ToString();
            }

            dr.Close();
            myDB1.Close();
        }

        protected void btnResetPSellNum_Click(object sender, System.EventArgs e)
        {
            string strID = ViewState["PID"].ToString();

            DBConn myDB = new DBConn();

            string sql = "select sum(PNum) as [count] from [Order] where OState=1 and PID=" + strID;

            SqlDataReader myDR = myDB.getDataReader(sql);
            if (myDR.Read())
            {
                string myCount = myDR["count"].ToString();
                if (myCount == "")
                {
                    Response.Write("<script>");
                    Response.Write("alert('û�г��۸ö����飬�޷��ۻ�');");
                    Response.Write("</script>");
                    return;
                }
                sql = "update [Products] set [PSellNum]=[PSellNum]+" + myCount + "where  [PID]=" + strID;
                myDR.Close();
                myDB.ExecuteNonQuery(sql);
                sql = "Update [Products] set [PStock]=[PStock]-" + myCount + " where [PID]=" + strID;
                myDR.Close();
                myDB.ExecuteNonQuery(sql);

            }
            myDB.Close();

            getPData();


            Response.Write("<script>");
            Response.Write("alert('�����ۻ����!!!');");
            Response.Write("</script>");
        }


    }
}

