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
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace SCard.admin
{
	/// <summary>
	/// edit_tzs ��ժҪ˵����
	/// </summary>
    public partial class View_User : System.Web.UI.Page
    {
        public string sisState;
 
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
                sisState = Request.Params["id"];
				this.datanew();
			}

             
		}
		
		private void datanew()
		{

            string DBPath = ConfigurationManager.AppSettings["DataBasePath"];
            string connStr = (DBPath);
            SqlConnection con = new SqlConnection(connStr);
        
            string sql;

            sql = "select * from viwUser";
            con.Open();
           
			SqlDataAdapter sda=new SqlDataAdapter(sql ,con);
			DataSet ds=new DataSet();
            sda.Fill(ds, "viwUser");
            this.dgnew.DataKeyField = "Userid";//DataKeyField����Ƕ�λ�ļ�ֵ
            this.dgnew.DataSource = ds.Tables["viwUser"];
			this.dgnew.DataBind();
			
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
			this.dgnew.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgnew_PageIndexChanged);
			this.dgnew.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgnew_DeleteCommand);
			this.dgnew.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgnew_ItemDataBound);

		}
		#endregion

		private void dgnew_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgnew.CurrentPageIndex=e.NewPageIndex;
			this.datanew();
		}

		private void dgnew_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
			{
				e.Item.Attributes.Add("onmouseover","c=this.style.backgroundColor;this.style.backgroundColor='#eeeeff'");
				e.Item.Attributes.Add("onmouseout","this.style.backgroundColor=c;");
 				((LinkButton)(e.Item.Cells[4].Controls[0])).Attributes.Add("onclick","return confirm('���Ҫɾ����')");
			}
           
		}
       
		private void dgnew_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

			string id=this.dgnew.DataKeys[e.Item.ItemIndex].ToString();

            string DBPath = ConfigurationManager.AppSettings["DataBasePath"];
            string connStr = (DBPath);
            SqlConnection con = new SqlConnection(connStr);
           
            SqlCommand cmd = new SqlCommand("delete from tblUser where id='" + id + "'", con);
			con.Open();
			cmd.ExecuteNonQuery();
			try
			{
				this.datanew();
			}
			catch
			{
				if (this.dgnew.CurrentPageIndex>0)
				{
					this.dgnew.CurrentPageIndex-=1;
					this.datanew();
				}
			}
		}

    //try ���DataGrid��ɾ�����һҳ�ļ�¼ʱ����Ľ���취,���ص���һҳ

      
}
}
