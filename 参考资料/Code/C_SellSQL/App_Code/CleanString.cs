using System;

//using System.Text;

namespace SCard
{
	/// <summary>
	/// CleanString ��ժҪ˵����
	/// </summary>
	public sealed class CleanString
	{

		public static string htmlInputText( string inputString )//HTML���������ַ���
		{
			if ((inputString != null) && (inputString != String.Empty ))
			{
				inputString = inputString.Trim();
				inputString = inputString.Replace("'","&quot;");
				inputString = inputString.Replace("<","&lt;");
				inputString = inputString.Replace(">","&gt;");
				inputString = inputString.Replace(" ","&nbsp;");
				inputString = inputString.Replace("\n","<br>");
				return inputString.ToString();
			}
			return "";
		}

		public static string htmlOutputText( string inputString )//HTML��ԭ�ַ���
		{
			if ((inputString != null) && (inputString != String.Empty ))
			{
				inputString = inputString.Trim();
				inputString = inputString.Replace("&quot;","'");
				inputString = inputString.Replace("&lt;","<");
				inputString = inputString.Replace("&gt;",">");
				inputString = inputString.Replace("&nbsp;"," ");
				inputString = inputString.Replace("<br>","\n");
				return inputString.ToString();
			}
			return "";
		}

	}
}
