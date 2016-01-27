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
	/// orderTidy ��ժҪ˵����
	/// </summary>
	public partial class orderTidy : System.Web.UI.Page
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //Ȩ�޼��
            if( Session["adminName"]==null || Session["adminName"].ToString() == String.Empty )
            {
                Response.Write("<font color=#ff0000>�Բ���,��û�㹻Ȩ�޷��ʴ�ҳ!!</font>");
                Response.Write("<a href=index.aspx >���µ�½</a>");
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
            string sql="select * from [Order] where OState=0 order by OID";
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

        protected void delP(string sql)//�������
        {//ɾ��P����ID

            DBConn myDB = new DBConn(); 
            DataSet ds1 = myDB.getDataSet(sql);
            foreach (DataRow row in ds1.Tables[0].Rows)//�����е����ݴ�ͷ��β���ж�һ��
            {
                myDB.ExecuteNonQuery("delete from tblP_Order where OrderNo='" + row["OID"].ToString() + "'");
                //����ɾ������ɡ�ѡ�񡱣���ЩҪɾ���Ķ����������Ų�ͬ��������FOREACH�������ӵ�һ�п�ʼ�Ҷ�Ӧ�Ķ�������ɾ��
            }
         
            myDB.Close();

        }
        protected void btnDelete_Click(object sender, System.EventArgs e)
        {

            string mySql = "DELETE * FROM [Order] WHERE [OState]=0 AND [Pubdate]='1800-1-1'";//��ʼ��
            DBConn myDB = new DBConn(); 
            switch( ddlDelete.SelectedValue )
            {
				case "0":
                    mySql="DELETE FROM [Order] WHERE [OState]=0 AND [Pubdate]<=('" + DateTime.Now.AddMonths(-1) + "')";
                    break;
                case "1":
                    mySql="DELETE FROM [Order] WHERE [OState]=0 AND [Pubdate]<=('" + DateTime.Now.AddDays(-7) + "')";
                    break;
                case "2":
                    mySql="DELETE FROM [Order] WHERE [OState]=0 AND [Pubdate]<=('" + DateTime.Now.AddDays(-1) + "')";
                    break;
                case "3":
                    mySql="DELETE FROM [Order] WHERE [OState]=0 AND [Pubdate]<=('" + DateTime.Now.AddHours(-1) + "')";
                    break;
            }

            delP(mySql.Replace("DELETE", "Select * "));//��������
            myDB.ExecuteNonQuery( mySql );
            myDB.Close();

            Response.Write("<script>");
            Response.Write("alert('�ɹ�ɾ���ض���¼!!!');");
            Response.Write("</script>");

            getData();
        }

        protected void ddlDelete_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            btnDelete.Attributes.Add("onclick","javascript:return confirm('ȷ��ɾ��[ " + ddlDelete.Items[ddlDelete.SelectedIndex].Text + " ]?');"); 
        }
	}
}
