using System;

namespace updater.ClientUI
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
		static void Main(string[] args) 
		{


            System.Windows.Forms.Application.Run(new StepControl2());
		}


	}
}
