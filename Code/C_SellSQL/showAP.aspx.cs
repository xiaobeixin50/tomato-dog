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

namespace SCard
{
	/// <summary>
	/// showAP ��ժҪ˵����
	/// </summary>
	public partial class showAP : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            try
            { 
                String strID="-1";
                strID=Request.QueryString["id"].ToString ();

				string DBPath = ConfigurationSettings.AppSettings["DataBasePath"];
				string connStr = (DBPath);
				SqlConnection conn=new SqlConnection(connStr);
                String sql="SELECT * FROM append where id='" + strID + "'";
                SqlCommand command=new SqlCommand(sql,conn);
 
                conn.Open();
                SqlDataReader dr=command.ExecuteReader();
                dr.Read();
                byte[] imgdata = (byte[])dr["image"];
                Response.BinaryWrite(imgdata);
                dr.Close();
                conn.Close();
            }
            catch
            {   
                //��ӡ û��ͼƬ
				string DBPath = ConfigurationSettings.AppSettings["DataBasePath"];
				string connStr = (DBPath);
				SqlConnection conn2=new SqlConnection(connStr);
                String sql="SELECT * FROM append where id='0'";
                SqlCommand command=new SqlCommand(sql,conn2);
                conn2.Open();
                SqlDataReader dr=command.ExecuteReader();
                dr.Read();
                byte[] imgdata2 = (byte[])dr["image"];
                Response.BinaryWrite(imgdata2);
                dr.Close();
                conn2.Close();
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
	}
}
