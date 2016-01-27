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

namespace SCard
{
	/// <summary>
	/// orderSelect ��ժҪ˵����
	/// </summary>
	public partial class orderSelect : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
           
            if( !IsPostBack )
            {
                tableSelect.Visible = true;
                tableInfo.Visible = false;
            }
		}

        private void getOrderData( string strOID, string strName, string strEmail )//��ȡ������Ϣ
        {
            DBConn myDB = new DBConn();
            string sql="select * from [Order] where OID='" + strOID + "' and TName='" + strName + "' and Email='" + strEmail + "'";
            SqlDataReader dr  = myDB.getDataReader( sql );
            if( dr.Read() )
            {
                lblOrderID.Text = dr["OID"].ToString();

               if(dr["PID"].ToString()=="0")   lblDetailP.Text = "<a href='P_OderInfo.aspx?id=" + dr["OID"].ToString() + "' target='_blank'>�鿴��������Ĳ�Ʒ����</a>";
                lblTName.Text = dr["TName"].ToString();
                lblEmail.Text = dr["Email"].ToString();
                lblPhone.Text = dr["Phone"].ToString();
                lblPID.Text = dr["PID"].ToString();
                lblPName.Text = dr["PName"].ToString();
                lblPPrice.Text = double.Parse( dr["PPrice"].ToString() ).ToString("C");
                lblPNum.Text = dr["PNum"].ToString();
                lblTotalPrice.Text = double.Parse( dr["TotalPrice"].ToString() ).ToString("C");
                lblPubdate.Text = dr["Pubdate"].ToString();
                lblOState.Text = dr["OState"].ToString();

                string strOState = lblOState.Text;
                switch( strOState )
                {
                    case "0":
                        strOState = "δ����";
                        break;
                    case "1":
                        strOState = "���";
                        break;
                    case "2":
                        strOState = "�ȴ�";
                        break;
                    default:
                        strOState = "����";
                        break;
                }                                   
                lblOState.Text = strOState; 

                tableSelect.Visible = false;
                tableInfo.Visible = true;

            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('�Ҳ�����Ӧ�Ķ�������!!!');");
                Response.Write("</script>");
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
            this.ibtnSelect.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnSelect_Click);

        }
		#endregion


        private void ibtnSelect_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string strOrderid = txtOrderid.Text.Trim();
            string strName = txtName.Text.Trim();
            string strEmail = txtEmail.Text.Trim();

            if( strOrderid == String.Empty || strName == String.Empty || strEmail == String.Empty )
            {
                Response.Write("<script>");
                Response.Write("alert('������Ӧ���ϲ���Ϊ��!!!');");
                Response.Write("</script>");
                return;
            }

            strOrderid = CleanString.htmlInputText( strOrderid );
            strName = CleanString.htmlInputText( strName );
            strEmail = CleanString.htmlInputText( strEmail );

            getOrderData( strOrderid, strName, strEmail );//��ȡ������Ϣ
            
        }
       
}
}
