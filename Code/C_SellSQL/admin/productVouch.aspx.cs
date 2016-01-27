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
	/// productVouch_aspx ��ժҪ˵����
	/// </summary>
	public partial class productVouch : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DropDownList ddlPName;
    
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
                getddlClassData();
                getPData();//�󶨶������б�
                getVData();//���Ƽ��б�
            }
		}

        private void getPData()
        {
            string mySql="select * from Products Left Outer join Category on  Products.CID = Category.CID where PCommend=0 order by PID desc";
          
            MySqlPager SqlPager = new MySqlPager();
			SqlPager.setAttribute( SqlPager1, "PDataGrid", mySql, "PID desc", 5);
                
        }


        private void getVData()
        {
            string sql="select * from Products Left Outer join Category on  Products.CID = Category.CID where PCommend=1 order by PID desc";

            DBConn myDB = new DBConn();
            DataGrid1.DataSource  = myDB.getDataReader(sql);
            DataGrid1.DataBind();
            myDB.Close();
                
        }

        private void getddlClassData()
        {
            DBConn myDB = new DBConn();
            string sql="select * from Category order by CID desc";
            ddlClass.DataSource  = myDB.getDataReader(sql);
            ddlClass.DataTextField = "CName";
           
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
            this.PDataGrid.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.PDataGrid_DeleteCommand);
            this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);

        }
		#endregion

        protected void btnSelect_Click(object sender, System.EventArgs e)
        {
            string mySql = "select * from Products Left Outer join Category on  Products.CID = Category.CID where PCommend=0 order by PID desc";            
 
            string strClass = ddlClass.SelectedValue; 

            if( !strClass.Equals("-1") )
            {
                mySql = "select * from Products Left Outer join Category on  Products.CID = Category.CID where PCommend=0 and Products.CID=" + strClass + " order by PID desc";            
            }  

            MySqlPager SqlPager = new MySqlPager();
			SqlPager.setAttribute( SqlPager1, "PDataGrid", mySql, "PID desc", 5);
        }

        private void PDataGrid_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string strid = e.Item.Cells[0].Text;
            DBConn myDB = new DBConn();
            string sql="update Products set PCommend=1 where PID="+strid;
            myDB.ExecuteNonQuery(sql);
            myDB.Close();

            getPData();//�󶨶������б�
            getVData();//���Ƽ��б�
        }

        private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string strid = e.Item.Cells[0].Text;
            DBConn myDB = new DBConn();
            string sql="update Products set PCommend=0 where PID="+strid;
            myDB.ExecuteNonQuery(sql);
            myDB.Close();

            getPData();
            getVData();
        }


       
	}
}
