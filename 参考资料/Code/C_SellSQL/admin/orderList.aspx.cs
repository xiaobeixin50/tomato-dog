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
	/// orderList ��ժҪ˵����
	/// </summary>
	public partial class orderList : System.Web.UI.Page
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
                if (Request.QueryString["ac"]!= null)
                {
                    string mySql = "update  [Order] set OState=" + (string)(Request.QueryString["ac"]) + " where OID='" + (string)(Request.QueryString["oid"])+"'";
                    DBConn myDB = new DBConn();
                     myDB.ExecuteNonQuery(mySql);
                    myDB.Close();
            
                }

                getData();
            }
		}

        private void getData()//������
        {
            string sql="select * from [Order] order by OID desc";	
			MySqlPager SqlPager = new MySqlPager();
			SqlPager.setAttribute( SqlPager1, "OrderDataGrid", sql, "OID desc", 20);
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
			this.OrderDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.OrderDataGrid_ItemDataBound);

		}
		#endregion

        private void OrderDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
            {             
                string strOState = e.Item.Cells[3].Text;
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
                e.Item.Cells[3].Text = strOState; 
            } 
        }

        protected void btnSelect_Click(object sender, System.EventArgs e)
        {
            string strSelect = txtSelect.Text;
            string mySql="select * from [Order] order by OID desc";

            switch( ddlSelect.SelectedValue )
            {
                case "0":
                    mySql="select * from [Order] where OID like '%" + strSelect + "%' order by OID desc";
                    break;
                case "1":
                    mySql="select * from [Order] where TName like '%" + strSelect + "%' order by OID desc";
                    break;
                case "2":
                    mySql="select * from [Order] where Email like '%" + strSelect + "%' order by OID desc";
                    break;
            }
            MySqlPager SqlPager = new MySqlPager();
			SqlPager.setAttribute( SqlPager1, "OrderDataGrid", mySql, "OID desc", 20);
        }
	}
}
