using System;
using System.ComponentModel;
using System.Web;

namespace Cooperativeness.FileTransfer
{
	/// <summary>
	/// Global ��ժҪ˵����
	/// </summary>
	public class Global : HttpApplication
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

		protected void Application_Start(Object sender, EventArgs e)
		{
		}

		protected void Session_Start(Object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
		}

		protected void Session_End(Object sender, EventArgs e)
		{
		}

		protected void Application_End(Object sender, EventArgs e)
		{
		}

		#region Web ������������ɵĴ���

		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		#endregion
	}
}