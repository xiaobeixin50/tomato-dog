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
	/// productAlter ��ժҪ˵����
	/// </summary>
	public partial class productAlter : System.Web.UI.Page
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
                getddlClassData();
            }
		}

        private void getData()
        {
            string sql = "select * from Products Left Outer join Category on  Products.CID = Category.CID order by PID desc";
            
            MySqlPager SqlPager = new MySqlPager();
			SqlPager.setAttribute( SqlPager1, "DataGrid1", sql, "PID desc", 20);
                
        }

        private void getddlClassData()
        {
            DBConn myDB = new DBConn();
            string sql="select * from Category order by CID desc";
            ddlClass.DataSource  = myDB.getDataReader(sql);
            ddlClass.DataTextField = "CName";
            ddlClass.DataValueField = "CID";
            ddlClass.DataBind();
            myDB.Close();
            
            ddlClass.Items.Insert(0,new ListItem("���з���","-1"));
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
            this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
            this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

        }
		#endregion

        private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
            { 
                //ɾ��ȷ��            
                LinkButton delBttn = (LinkButton) e.Item.Cells[8].Controls[0]; 
                delBttn.Attributes.Add("onclick","javascript:return confirm('ȷ��ɾ��[ " + CleanString.htmlOutputText(e.Item.Cells[1].Text) + " ]?\\n*�ֿ���Ķ����������һ��ɾ��*');"); 
            } 
        }

        private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string strid = e.Item.Cells[0].Text;
            DBConn myDB = new DBConn();
            string mySql= "Delete from Products where PID=" + strid;
            myDB.ExecuteNonQuery( mySql );
          
            myDB.Close();

            getData();
        }

        protected void btnSelect_Click(object sender, System.EventArgs e)
        {
			string strSelect = txtSelect.Text;
            string mySql="select * from Products Left Outer join Category on  Products.CID = Category.CID order by PID desc";

            string strClass = ddlClass.SelectedValue;//�����͵�������

            if( strClass.Equals("-1") )
            {
                switch( ddlSelect.SelectedValue )//��ţ����Ƶ�������
                {
                    case "0":
                        mySql="select * from Products Left Outer join Category on  Products.CID = Category.CID where PID like '%" + strSelect + "%' order by PID desc";
                        break;
                    case "1":
                        mySql="select * from Products Left Outer join Category on  Products.CID = Category.CID where PName like '%" + strSelect + "%' order by PID desc";
                        break;
                }
            }
            else
            {
                switch( ddlSelect.SelectedValue )
                {
                    case "0":
                        mySql="select * from Products Left Outer join Category on  Products.CID = Category.CID where Products.CID=" + strClass + " and PID like '%" + strSelect + "%' order by PID desc";
                        break;
                    case "1":
                        mySql="select * from Products Left Outer join Category on  Products.CID = Category.CID where Products.CID=" + strClass + " and PName like '%" + strSelect + "%' order by PID desc";
                        break;
                }
            }

           
            MySqlPager SqlPager = new MySqlPager();
			SqlPager.setAttribute( SqlPager1, "DataGrid1", mySql, "PID desc", 20);
        }

	}
}
