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
	/// adminList 的摘要说明。
	/// </summary>
	public partial class adminList : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //权限检查
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000>对不起,您没足够权限访问此页!!</font>");
                Response.Write("<a href=index.aspx>重新登陆</a>");
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

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
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
                //删除确认            
                LinkButton delBttn = (LinkButton) e.Item.Cells[0].Controls[0]; 
                if( Session["adminName"].ToString().ToUpper() == e.Item.Cells[1].Text.ToUpper() )
                {
                    e.Item.Cells[0].Controls[0].Visible = false;//不显示“删除”按钮
                }
                delBttn.Attributes.Add("onclick","javascript:return confirm('确定删除[ " + CleanString.htmlOutputText(e.Item.Cells[1].Text) + " ]?');"); 
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
