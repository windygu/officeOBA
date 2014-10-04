using System;
using System.IO;
using System.Web;
using System.Web.UI;
using Cooperativeness.FileTransfer.Core;

namespace Cooperativeness.FileTransfer
{
	/// <summary>
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public partial class WebUploaderPages : Page
	{
        private static readonly Logger Log = new Logger(typeof(WebUploaderPages));

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
			    string filepath = Request.Params["filedirectory"];
			    filepath = (string.IsNullOrEmpty(filepath)) ? "Accessories/" : filepath + "/";

                string path = Server.MapPath(filepath);
                FileUtil.CreateDirectory(path);
                ////if (Directory.Exists(path) == false)
                ////{
                ////    Directory.CreateDirectory(path);
                ////}
				foreach (string f in Request.Files.AllKeys)
				{
					HttpPostedFile file = Request.Files[f];
					long offset = long.Parse(Request.Params["offset"]);
					long length = long.Parse(Request.Params["length"]);
//					byte [] temp = Encoding.GetEncoding("gb2312").GetBytes(file.FileName);
					if (offset == length)
					{
						file.SaveAs(path + file.FileName);
						int len = file.ContentLength;
						Response.Write("OK " + len + " " + len + "\r\n");
					}
					else
					{
						string tempName = path + file.FileName + offset;
						file.SaveAs(tempName);
					    byte[] content = null;
                        using (var tempfs = new FileStream(tempName, FileMode.Open, FileAccess.ReadWrite))
                        {
                            content = new byte[tempfs.Length];
                            tempfs.Read(content, 0, content.Length);
                            tempfs.Close();
                        }

						file.SaveAs(tempName);
                        using (var fs = new FileStream(path + file.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
						    fs.SetLength(length);
						    fs.Position = offset;
						    fs.Write(content, 0, content.Length);
						    fs.Close();                        
                        }
                        FileUtil.DeleteFile(tempName);
						//File.Delete(tempName);
						Response.Write("OK " + offset + " " + (offset + content.Length).ToString() + "\r\n");
					}
				}
				if (Request.Params["testKey"] != null)
				{
					Response.Write(Request.Params["testKey"]);
				}
			}
			catch (Exception ex)
			{
				Log.Warn(ex);
			}
		}

		#region Web ������������ɵĴ���

		protected override void OnInit(EventArgs e)
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
			this.Load += new EventHandler(this.Page_Load);
		}

		#endregion
	}
}