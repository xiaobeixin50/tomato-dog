namespace SCard
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///	pageHeader ��ժҪ˵����
	/// </summary>
	public partial class pageHeader : System.Web.UI.UserControl
	{
        protected System.Web.UI.WebControls.Image imgLogo;
        protected System.Web.UI.WebControls.Label lblDataTime;
        protected System.Web.UI.WebControls.Image imgBanner;
        public string strLg = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
            
                   if (Session["User"] !=null)
             {
                 strLg = "<td width=98><a href=tuLogin.aspx>�˳���½</a></td>" +
 "        <td width=10><img src=images/line.gif></td>" +
 "               <td width=158>�û�" + Session["User"] + "�Ѿ���½ </a></td>" +
  "        <td width=10><img src=images/line.gif></td>" +
 "          <td width=98><a href=Edit.aspx?id=" + Session["User"] + " >�޸���Ϣ</a></td>" +
 "        <td width=10><img src=images/line.gif></td>"+
 "          <td width=98><a href=myBasket.aspx target=_blank>�ҵĹ��ﳵ</a></td>" +
 "        <td width=10><img src=images/line.gif></td>" +
  "        <td width=10><img src=images/line.gif></td>" +
 "          <td width=98><a href=admin/myorderlist.aspx target=_blank>�ҵĶ���</a></td>" +

 "          <td width=98><a href=myFav.aspx target=_blank>�ҵ��ղ�</a></td>" +
 "        <td width=10><img src=images/line.gif></td>";


             }else{
                 strLg = "<td width=98><a href=uLogin.aspx>�û���½</a></td>" +
"        <td width=10><img src=images/line.gif></td>" +
"               <td width=98><a href=Reg.aspx>�û�ע��</a></td>" +
"        <td width=10><img src=images/line.gif></td>" ;



                   }


               getDataTime();//��ȡϵͳʱ��
             
        }

        private void getDataTime()
        {
            DateTime myDate = DateTime.Now;
            string strDate = myDate.ToLongDateString();
            string strW = "";
            switch( myDate.DayOfWeek.ToString() )
            {
                case "Sunday":strW="������";break;
                case "Monday":strW="����һ";break;
                case "Tuesday":strW="���ڶ�";break;
                case "Wednesday":strW="������";break;
                case "Thursday":strW="������";break;
                case "Friday":strW="������";break;
                case "Saturday":strW="������";break;
            }

            lblDateTime.Text = strDate + "&nbsp;" + strW;

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
        ///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
        ///		�޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {

        }
		#endregion
	}
}
