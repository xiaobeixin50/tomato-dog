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
	/// categoryAlter ��ժҪ˵����
	/// </summary>
	public partial class categoryAlter : System.Web.UI.Page
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

		private void getData()//������
		{
			DBConn myDB = new DBConn();
			string sql="select * from Category order by CID desc";
			DataGrid1.DataSource  = myDB.getDataReader(sql);
			DataGrid1.DataBind();
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
            this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
            this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
            this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
            this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
            this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

        }
		#endregion

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        
		{
			DataGrid1.EditItemIndex = e.Item.ItemIndex;//��ȡ��������Դ�ؼ��Ķ�������������������ؼ���Ҫ�༭���������
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
				Response.Write("alert('�������������!!!');");
				Response.Write("</script>");
				return;
			}
			else if( strName.Length > 20 )
			{
				Response.Write("<script>");
				Response.Write("alert('�����������̫����!!!');");
				Response.Write("</script>");
				return;
			}

			DBConn myDB = new DBConn();
			string sql="update Category set CName='" + strName + "' where CID=" + strid;
			myDB.ExecuteNonQuery(sql);
			myDB.Close();

            Response.Write("<script>");
            Response.Write("alert('���³ɹ�!!!');");
            Response.Write("</script>");

			DataGrid1.EditItemIndex  = -1;//�˻ص��༭״̬
			getData();
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
                //��ȡ�����е�������ؼ��е���������Ƿ�ƥ�䣬��Ԫ���е���������Ƿ�ƥ��
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
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) //�ж��Ƿ����б��е���ж��б��е����Ƿ��������ݰ󶨵�
            { 
                //ɾ��ȷ��            
                LinkButton delBttn = (LinkButton) e.Item.Cells[3].Controls[0]; 
                delBttn.Attributes.Add("onclick","javascript:return confirm('ȷ��ɾ��[ " + CleanString.htmlOutputText(e.Item.Cells[1].Text) + " ]?');"); 
            } 

        }


}
}
