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

namespace SCard.admin
{
	/// <summary>
	/// otherDoesnotPicture ��ժҪ˵����
	/// </summary>
	public partial class otherDefaultPicture : System.Web.UI.Page
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

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            if(uploadFile.PostedFile.FileName.Trim() != String.Empty && (Path.GetExtension(uploadFile.PostedFile.FileName)!=".gif" && Path.GetExtension(uploadFile.PostedFile.FileName)!=".jpg"))
            {//Path.GetExtension����"ָ����·��"�ַ�������չ��
                Response.Write("<Script>alert('�ϴ���ͼƬ��ʽ����Ϊ.gif��.jpg!!')</Script>");
                return;
            }

            if ( uploadFile.PostedFile.FileName.Trim() != String.Empty )
            {
                
                Stream imagedatastream;//�ֽ���
                string DBPath = ConfigurationManager.AppSettings["DataBasePath"];
				string connStr = (DBPath);
				SqlConnection myConn=new SqlConnection(connStr);
                imagedatastream = Request.Files["uploadFile"].InputStream ;//�ļ�·��
                int imagedatalen = Request.Files["uploadFile"].ContentLength ;//�ϴ��ļ��Ĵ�С
                string imagedatatype = Request.Files["uploadFile"].ContentType;//�ϴ��ļ�������
                byte[] image = new byte[imagedatalen];//�����������ļ�---�ֽ���---ͼƬ
                imagedatastream.Read(image,0,imagedatalen);
                String Psql="update [append] set [image]=@imgdata where [id]='0'";

                SqlCommand Pcommand=new SqlCommand(Psql,myConn);
                SqlParameter imgdata = new SqlParameter("@imgdata",SqlDbType.Image);//ͼƬ������
                imgdata.Value=image;
                Pcommand.Parameters.Add (imgdata);
                myConn.Open();
                Pcommand.ExecuteReader();
                myConn.Close();
                Response.Write("<script>");
                Response.Write("alert('�޸����!!!');");
                Response.Write("</script>");
            }
        }
	}
}
