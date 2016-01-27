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
using System.IO;

namespace SCard.admin
{
	/// <summary>
	/// productImport ��ժҪ˵����
	/// </summary>
	public partial class productImport : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //Ȩ�޼��
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000>�Բ���,��û�㹻Ȩ�޷��ʴ�ҳ!!</font>");
                Response.Write("<a href=index.aspx>���µ�½</a>");
                Response.End();
                return;
            }

            if( !IsPostBack )
            {
                if( Request.QueryString["id"] == null)
                {
                    Response.Write("û�����������");
                    Response.End();
                }
                string strID = Request.QueryString["id"].ToString().Trim();
                if( strID == String.Empty )
                {
                    strID = "-1";
                }
                DBConn myDB1 = new DBConn();
                string sqlP="select PName from Products where PID=" + strID;
                SqlDataReader dr  = myDB1.getDataReader(sqlP);
            
                if( dr.Read() )
                {
                    lblName.Text = dr["PName"].ToString();
                }
                
                dr.Close();
                myDB1.Close();

                ViewState["PID"] = strID;
            }
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

       


        protected void Button1_Click(object sender, EventArgs e)
        {
            string strID = Request.QueryString["id"];
            string iNum;
            if (txtN.Text == String.Empty)
            {
                Response.Write("<script>");
                Response.Write("alert('����д�������!!!');");
                Response.Write("</script>");
                return;
            }
                iNum = this.txtN.Text;
                DBConn myDB2 = new DBConn();
                string mySql = "update Products set PStock=PStock+" + iNum + " where PID=" + strID;
                myDB2.ExecuteNonQuery( mySql );
              //  mySql = "Insert into tblLog(Pid,isN) values ( '" + strID + "', '" + iNum + "')";
                mySql = "update tblLog set isN=isN+" + iNum + "where PID=" + strID;
                myDB2.ExecuteNonQuery( mySql );
                myDB2.Close();
                Response.Write("<script>");
                Response.Write("alert('�ύ�ɹ�����!!!');location.href='productAlter.aspx';");
           
                Response.Write("</script>");

        }
}
}
