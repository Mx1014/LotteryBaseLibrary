using System;

namespace updater.ServerUI
{
	/// <summary>
	/// Main ��ժҪ˵����
	/// </summary>
	public class MainEntry
	{
		private MainEntry()
		{
		}

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new MainForm());
		}

	}
}
