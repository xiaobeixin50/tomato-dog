namespace SCard
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///	pageHeader 的摘要说明。
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
                 strLg = "<td width=98><a href=tuLogin.aspx>退出登陆</a></td>" +
 "        <td width=10><img src=images/line.gif></td>" +
 "               <td width=158>用户" + Session["User"] + "已经登陆 </a></td>" +
  "        <td width=10><img src=images/line.gif></td>" +
 "          <td width=98><a href=Edit.aspx?id=" + Session["User"] + " >修改信息</a></td>" +
 "        <td width=10><img src=images/line.gif></td>"+
 "          <td width=98><a href=myBasket.aspx target=_blank>我的购物车</a></td>" +
 "        <td width=10><img src=images/line.gif></td>" +
  "        <td width=10><img src=images/line.gif></td>" +
 "          <td width=98><a href=admin/myorderlist.aspx target=_blank>我的订单</a></td>" +

 "          <td width=98><a href=myFav.aspx target=_blank>我的收藏</a></td>" +
 "        <td width=10><img src=images/line.gif></td>";


             }else{
                 strLg = "<td width=98><a href=uLogin.aspx>用户登陆</a></td>" +
"        <td width=10><img src=images/line.gif></td>" +
"               <td width=98><a href=Reg.aspx>用户注册</a></td>" +
"        <td width=10><img src=images/line.gif></td>" ;



                   }


               getDataTime();//获取系统时间
             
        }

        private void getDataTime()
        {
            DateTime myDate = DateTime.Now;
            string strDate = myDate.ToLongDateString();
            string strW = "";
            switch( myDate.DayOfWeek.ToString() )
            {
                case "Sunday":strW="星期日";break;
                case "Monday":strW="星期一";break;
                case "Tuesday":strW="星期二";break;
                case "Wednesday":strW="星期三";break;
                case "Thursday":strW="星期四";break;
                case "Friday":strW="星期五";break;
                case "Saturday":strW="星期六";break;
            }

            lblDateTime.Text = strDate + "&nbsp;" + strW;

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
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
		#endregion
	}
}
