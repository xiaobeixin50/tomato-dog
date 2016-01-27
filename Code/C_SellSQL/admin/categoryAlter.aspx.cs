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
	/// categoryAlter 的摘要说明。
	/// </summary>
	public partial class categoryAlter : System.Web.UI.Page
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

		private void getData()//绑定数据
		{
			DBConn myDB = new DBConn();
			string sql="select * from Category order by CID desc";
			DataGrid1.DataSource  = myDB.getDataReader(sql);
			DataGrid1.DataBind();
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
            this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
            this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
            this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
            this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
            this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

        }
		#endregion

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        
		{
			DataGrid1.EditItemIndex = e.Item.ItemIndex;//获取来自数据源控件的对象的索引，将它赋给控件中要编辑的项的索引
			getData();
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            DataGrid1.EditItemIndex = -1;
			getData();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string strid = e.Item.Cells[0].Text;

            TextBox tb = (TextBox)(e.Item.Cells[1].Controls[0]);
           
            string strName =tb.Text.Trim();
			if( strName == String.Empty )
			{
				Response.Write("<script>");
				Response.Write("alert('请输入类别名称!!!');");
				Response.Write("</script>");
				return;
			}
			else if( strName.Length > 20 )
			{
				Response.Write("<script>");
				Response.Write("alert('输入类别名称太长了!!!');");
				Response.Write("</script>");
				return;
			}

			DBConn myDB = new DBConn();
			string sql="update Category set CName='" + strName + "' where CID=" + strid;
			myDB.ExecuteNonQuery(sql);
			myDB.Close();

            Response.Write("<script>");
            Response.Write("alert('更新成功!!!');");
            Response.Write("</script>");

			DataGrid1.EditItemIndex  = -1;//退回到编辑状态
			getData();
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
                //获取对象中的类型与控件中的项的类型是否匹配，单元格中的项的类型是否匹配
            { 
                string strid = e.Item.Cells[0].Text;
                DBConn myDB = new DBConn();
                string sql="Delete from Category where CID="+strid;
                myDB.ExecuteNonQuery(sql);
                myDB.Close();

                getData();
            }
		}

        private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) //判断是否是列表中的项，判断列表中的项是否是与数据绑定的
            { 
                //删除确认            
                LinkButton delBttn = (LinkButton) e.Item.Cells[3].Controls[0]; 
                delBttn.Attributes.Add("onclick","javascript:return confirm('确定删除[ " + CleanString.htmlOutputText(e.Item.Cells[1].Text) + " ]?');"); 
            } 

        }


}
}
