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
	/// Select ��ժҪ˵����
	/// </summary>
	public partial class Select : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
			 if( !IsPostBack )
            {
                setSelectClass();//�����
                
                if( Request.QueryString["class"] != null && Request.QueryString["text"] != null )//����ҳ�����������������ͺͶ�������
                {
                    string strClass = Request.QueryString["class"].ToString();
                    string strText = Request.QueryString["text"].ToString();

                    strClass = CleanString.htmlInputText( strClass );
                    strText = CleanString.htmlInputText( Server.UrlDecode(strText) );
                    
                    CData();//�����б��
                    getSelectResult(strClass, strText);//��ѯ
                }    
            }
		}

        private void CData()//�����б��
        {
            DBConn myDB = new DBConn();
            string sql = "select * from Category";
            CRepeater.DataSource = myDB.getDataReader( sql );
            CRepeater.DataBind();
            myDB.Close();
        }

        private void setSelectClass()//�� ���ѡ��
        {
            DBConn myDB = new DBConn();
            string mySql = "select CID,CName from Category order by CID desc";
            ddlClass.DataSource  = myDB.getDataReader( mySql );
            ddlClass.DataTextField = "CName";
            ddlClass.DataValueField = "CID";
            ddlClass.DataBind();
            myDB.Close();
            
            ddlClass.Items.Insert(0,new ListItem("���з���","-1"));
        }

        private void getSelectResult(string strClass, string strText)//��ѯ
        {
            string mySql= "select * from Products order by PID desc";

            if( strClass.Equals("-1") )
            {
                mySql= "select * from Products where PName like '%" + strText + "%' order by PID desc";
            }
            else
            {
                mySql= "select * from Products where CID=" + strClass + " and PName like '%" + strText + "%' order by PID desc";
            }

            MySqlPager SqlPager = new MySqlPager();
			SqlPager.setAttribute( SqlPager1, "PDataList", mySql, "PID desc", 10);
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

        protected void btnSelect_Click(object sender, System.EventArgs e)
        {
            string strClass = ddlClass.SelectedValue;
            string strText = txtSelect.Text;

            strText = CleanString.htmlInputText( strText );
                    
            getSelectResult(strClass, strText);//��ѯ
        }
	}
}
