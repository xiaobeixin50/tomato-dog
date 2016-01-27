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
	/// productDetail ��ժҪ˵����
	/// </summary>
	public partial class productDetail : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //Ȩ�޼��
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000 style='FONT-SIZE: 12px'>�Բ���,��û�㹻Ȩ�޷��ʴ�ҳ!!</font><br>");
                Response.Write("<a href=index.aspx target=_top style='FONT-SIZE: 12px'>���µ�½</a><br>");
                Response.End();
                return;
            }

            if( !IsPostBack )
            {
                getCategory();//����������б�
                

                 if( Request.QueryString["id"] == null)
                 {
                     Response.Write("û�����������");
                     Response.End();
                 }
                 string strID = Request.QueryString["id"].ToString().Trim();
                 
                 //��ȡID��Ӧ�Ķ�������Ϣ
                 DBConn myDB1 = new DBConn();
                 string sqlP="select * from Products where PID=" + strID;
                 SqlDataReader dr  = myDB1.getDataReader(sqlP);

                if ( dr.Read() )
                {
                    myimg.Src = "../showPP.aspx?id=" + dr["PID"].ToString();
                    ViewState["PID"] = dr["PID"].ToString();
                    txtName.Text = CleanString.htmlOutputText( dr["PName"].ToString() );
                    txtCPrice.Text = double.Parse( dr["PCPrice"].ToString() ).ToString("f2");//С��������λ��2λ
                    txtFPrice.Text = double.Parse( dr["PFPrice"].ToString() ).ToString("f2");
                    txtNPrice.Text = double.Parse( dr["PNPrice"].ToString() ).ToString("f2");
                    txtBewrite.Text = CleanString.htmlOutputText( dr["PBewrite"].ToString() );
                    txtUseMode.Text = CleanString.htmlOutputText( dr["PUseMode"].ToString() );
                    txtValidity.Text = CleanString.htmlOutputText( dr["PValidity"].ToString() );  
 
                    try//����
                    {
                        ddlCategory.SelectedValue = dr["CID"].ToString();
                    }
                    catch
                    {
                        ddlCategory.SelectedIndex = 0;
                    }

                }
                
                dr.Close();
                myDB1.Close();
            }

           
		}

        private void getCategory()//����������б�
        {
            DBConn myDB = new DBConn();
            string sql="select * from Category";
            ddlCategory.DataSource  = myDB.getDataReader(sql);
            ddlCategory.DataTextField = "CName";
            ddlCategory.DataValueField = "CID";
            ddlCategory.DataBind();
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


        protected void btnAlter_Click(object sender, System.EventArgs e)
        {
            if( ViewState["PID"] == null )
            {
                Response.Write("<script>");
                Response.Write("alert('����ʧ��!!!');");
                Response.Write("</script>");
                return;
            }
            string strID = ViewState["PID"].ToString();

            string strName = txtName.Text.Trim();
            string strCID = ddlCategory.SelectedValue;
            string strCPrice = txtCPrice.Text.Trim();
            string strFPrice = txtFPrice.Text.Trim();
            string strNPrice = txtNPrice.Text.Trim();
            string strBewrite = txtBewrite.Text.Trim();
            string strUseMode = txtUseMode.Text.Trim();
            string strValidity = txtValidity.Text.Trim();

            if( strName == String.Empty || strCPrice == String.Empty || strCID == String.Empty ||
                strFPrice == String.Empty || strNPrice == String.Empty)
            {
                Response.Write("<script>");
                Response.Write("alert('��ѡ���Ϊ��!!!');");
                Response.Write("</script>");
                return;
            }
            else if( strName.Length > 35 )
            {
                Response.Write("<script>");
                Response.Write("alert('�������������̫����!!!');");
                Response.Write("</script>");
                return;
            }

            try
            {
                double.Parse(strCPrice);
            }
            catch
            {
                Response.Write("<script>");
                Response.Write("alert('���� �ɱ��� �ĸ�ʽ!!!');");
                Response.Write("</script>");
                return;
            }
            try
            {
                double.Parse(strFPrice);
            }
            catch
            {
                Response.Write("<script>");
                Response.Write("alert('���� ԭ�� �ĸ�ʽ!!!');");
                Response.Write("</script>");
                return;
            }
            try
            {
                double.Parse(strNPrice);
            }
            catch
            {
                Response.Write("<script>");
                Response.Write("alert('���� �ּ� �ĸ�ʽ!!!');");
                Response.Write("</script>");
                return;
            }

            if(uploadFile.PostedFile.FileName.Trim()!=String.Empty && (Path.GetExtension(uploadFile.PostedFile.FileName)!=".gif" && Path.GetExtension(uploadFile.PostedFile.FileName)!=".jpg"))
            {
                Response.Write("<Script>alert('�ϴ���ͼƬ��ʽ����Ϊgif��jpg!!')</Script>");
                return;
            }

            strBewrite  = CleanString.htmlInputText( strBewrite );
            strUseMode  = CleanString.htmlInputText( strUseMode );
            strValidity = CleanString.htmlInputText( strValidity );

            string sql = "update Products set PName='" + strName + "',CID=" + strCID + ",PCPrice=" + strCPrice +
                        ",PFPrice=" + strFPrice + ",PNPrice=" + strNPrice + ",PBewrite='" + strBewrite +
                        "',PUseMode='" + strUseMode + "',PValidity='" + strValidity +"' where PID=" + strID;

            DBConn myDB = new DBConn();
            myDB.ExecuteNonQuery(sql);
            myDB.Close();

            if ( uploadFile.PostedFile.FileName.Trim() != String.Empty )
            {
                //----------- updateͼƬ
                Stream imagedatastream;
                string DBPath = ConfigurationManager.AppSettings["DataBasePath"];
				string connStr = (DBPath);
				SqlConnection myConn=new SqlConnection(connStr);
                imagedatastream = Request.Files["uploadFile"].InputStream ;
                int imagedatalen = Request.Files["uploadFile"].ContentLength ;
                string imagedatatype = Request.Files["uploadFile"].ContentType ;

                byte[] image = new byte[imagedatalen];
                imagedatastream.Read(image,0,imagedatalen);

                String Psql="update Products set PPicture=@imgdata where PID=" + strID;

                SqlCommand Pcommand=new SqlCommand(Psql,myConn);

                SqlParameter imgdata = new SqlParameter("@imgdata",SqlDbType.Image);
                imgdata.Value=image;
                Pcommand.Parameters.Add (imgdata);

                myConn.Open();
                Pcommand.ExecuteReader();
                myConn.Close();
            
            }

            Response.Write("<script>");
            Response.Write("alert('�ɹ�����!!!');");
            Response.Write("</script>");

        }
	}
}
