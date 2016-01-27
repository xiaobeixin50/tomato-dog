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
    /// orderList ��ժҪ˵������Աֱ�ӵ㡰�ҵĶ�����������ý���
	/// </summary>
	public partial class myorderList : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
          if( !IsPostBack )
            {
                getData();
            }
		}

        private void getData()
        {
          string sql="select * from [Order] where TName='"+(string)Session["User"]+"'order by OID desc";
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
 
	}
}
