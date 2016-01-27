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

namespace SCard.admin
{
	/// <summary>
	/// adminList ��ժҪ˵����
	/// </summary>
	public partial class adminList : System.Web.UI.Page
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
                getData();
            }
		}

        private void getData()
        {
            DBConn myDB = new DBConn();
            string sql="select * from admin order by addtime";
            adminDataGrid.DataSource  = myDB.getDataReader(sql);
            adminDataGrid.DataBind();
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
            this.adminDataGrid.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.adminDataGrid_DeleteCommand);
            this.adminDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.adminDataGrid_ItemDataBound);

        }
		#endregion

        private void adminDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
            { 
                //ɾ��ȷ��            
                LinkButton delBttn = (LinkButton) e.Item.Cells[0].Controls[0]; 
                if( Session["adminName"].ToString().ToUpper() == e.Item.Cells[1].Text.ToUpper() )
                {
                    e.Item.Cells[0].Controls[0].Visible = false;//����ʾ��ɾ������ť
                }
                delBttn.Attributes.Add("onclick","javascript:return confirm('ȷ��ɾ��[ " + CleanString.htmlOutputText(e.Item.Cells[1].Text) + " ]?');"); 
            } 
        }

        private void adminDataGrid_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string strAdmin = e.Item.Cells[1].Text;
            DBConn myDB = new DBConn();
            string sql="Delete from admin where username='" + strAdmin +"'";
            myDB.ExecuteNonQuery(sql);
            myDB.Close();

            getData();
        }
	}
}
