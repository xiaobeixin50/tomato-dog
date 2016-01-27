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
	/// message ��ժҪ˵����
	/// </summary>
	public partial class message : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{

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
            string strUName = txtUserName.Text.Trim();
            string strUPhone = txtUserPhone.Text.Trim();
            string strUEmail = txtEmail.Text.Trim();
            string strMTitle = txtTitle.Text.Trim();
            string strMContent = txtContent.Text.Trim();

            if( strUEmail == String.Empty || strMTitle == String.Empty || strMContent == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('��ѱ���������!!!');");
                Response.Write("</script>");
                return;
            }
            if( strMContent.Length > 300 )
            {
                Response.Write("<script>");
                Response.Write("alert('����̫����..(300������)!!!');");
                Response.Write("</script>");
                return;
            }
            
            //��ֹ����ˢ��Ϣ
            if( Session["messageCheck"] != null )
            {
                DateTime myDTime = (DateTime)Session["messageCheck"];
                if( myDTime.AddMilliseconds(30000) > DateTime.Now )
                {
                    Response.Write("<script>");
                    TimeSpan myTime = DateTime.Now - (DateTime)Session["messageCheck"];
                    Response.Write("alert('����Ƶ���ύ,����" + (30-myTime.Seconds) + "������!!!');");
                    Response.Write("</script>");
                    return;
                } 
            }

            //���������ַ���
            strUName    = CleanString.htmlInputText( strUName );
            strUPhone   = CleanString.htmlInputText( strUPhone );
            strUEmail   = CleanString.htmlInputText( strUEmail );
            strMTitle   = CleanString.htmlInputText( strMTitle );
            strMContent = CleanString.htmlInputText( strMContent );

            string mySql = "insert into [message](UName,UPhone,UEmail,MTitle,MContent,Pubdate) values('" +
                           strUName + "','" + strUPhone + "','" + strUEmail + "','" + strMTitle
                            + "','" + strMContent + "','" + DateTime.Now + "')";
            DBConn myDB = new DBConn();
            myDB.ExecuteNonQuery( mySql );
            myDB.Close();

            Session["messageCheck"] = DateTime.Now; //��ֹ����ˢ��Ϣ ��¼�ύʱ��
            
            Response.Write("<script>");
            Response.Write ("alert('�ɹ��ύ��')");
            Response.Write ("</script>");
            txtUserName.Text = "";
            txtUserPhone.Text = "";
            txtEmail.Text = "";
            txtTitle.Text = "";
            txtContent.Text = "";

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtUserPhone.Text = "";
            txtEmail.Text = "";
            txtTitle.Text = "";
            txtContent.Text = "";
        }
}
}
