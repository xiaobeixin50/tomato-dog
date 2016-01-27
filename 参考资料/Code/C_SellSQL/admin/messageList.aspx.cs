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
    /// ���԰� ��Ϣ (0δ��   1�Ѷ���menuԴ�����趨��)
	/// </summary>
	public partial class messageList : System.Web.UI.Page
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
                ViewState["MState"] = Request.QueryString["State"].ToString();
                //menu�����趨��Stateֵ

                if (ViewState["MState"].ToString().Equals("0"))
                {
                    lblState.Text = "δ����Ϣ";
                }
                else
                {
                    lblState.Text = "�Ѷ���Ϣ";
                }

                getDataCount();//��ȡ��¼����
                getData();
            }
		}

        private void getDataCount()
        {
            string mySql="select count(*) as [num] from [message] where MState=" + ViewState["MState"].ToString();
            DBConn myDB = new DBConn();
            SqlDataReader mydr = myDB.getDataReader( mySql );
            if( mydr.Read() )
            {
                lblNum.Text = mydr["num"].ToString();
            }
            mydr.Close();
            myDB.Close();      
        }

        private void getData()
        {
            string sql="select * from [message] where MState=" + ViewState["MState"].ToString() + " order by MID desc";
			MySqlPager SqlPager = new MySqlPager();
            SqlPager.setAttribute( SqlPager1, "messageDataGrid", sql, "MID desc", 20);
                
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
            this.messageDataGrid.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.messageDataGrid_DeleteCommand);
            this.messageDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.messageDataGrid_ItemDataBound);

        }
		#endregion

        private void messageDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
            { 
                //ɾ��ȷ��            
                LinkButton delBttn = (LinkButton) e.Item.Cells[5].Controls[0]; 
                delBttn.Attributes.Add("onclick","javascript:return confirm('ȷ��ɾ��[ " + CleanString.htmlOutputText(e.Item.Cells[2].Text) + " ]?');"); 
            } 
        }

        private void messageDataGrid_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string strid = e.Item.Cells[0].Text;
            DBConn myDB = new DBConn();
            string sql="Delete from [message] where MID="+strid;
            myDB.ExecuteNonQuery(sql);
            myDB.Close();

            getData();
        }
	}
}
