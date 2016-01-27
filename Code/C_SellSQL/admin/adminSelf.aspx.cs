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

using System.Web.Security;

namespace SCard.admin
{
	/// <summary>
	/// adminSelf ��ժҪ˵����
	/// </summary>
	public partial class adminSelf : System.Web.UI.Page
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

			txtAdmin.Text = Session["adminName"].ToString();
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
            string strName = txtAdmin.Text;
            string strPassword = txtPassword.Text;
            string strRPassword = txtRPassword.Text;
            
            if( strName == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('�����������!!!');");
                Response.Write("</script>");
                return;
            }
            if( strPassword == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('����������!!!');");
                Response.Write("</script>");
                return;
            }
            if( strRPassword == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('������ȷ������!!!');");
                Response.Write("</script>");
                return;
            }

            if( txtPassword.Text.Length < 6 )
            {
                Response.Write("<script>");
                Response.Write("alert('���볤������6λ!!!');");
                Response.Write("</script>");
                return;
            }
            
            strPassword = FormsAuthentication.HashPasswordForStoringInConfigFile( strPassword ,"MD5"); 

            DBConn myDB = new DBConn();
            string mySql = "UPDATE [admin] SET [password]='" + strPassword + "' WHERE [username]='" + strName + "'";
            int iTemp = myDB.ExecuteNonQuery( mySql );
            myDB.Close();

            if( iTemp != 0 )
            {
                Response.Write("<script>");
                Response.Write("alert('���������޸ĳɹ�!!!');");
                Response.Write("</script>");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('�����޸�ʧ��!!!');");
                Response.Write("</script>");
            }
        }
	}
}
