using System;

namespace Tools.DownloadLibrary
{
	/// <summary>
	/// DownloadInstructions ��ժҪ˵����
	/// </summary>
	public class DownloadInstructions
	{
		private string[] urls;
		private string destination;

		public DownloadInstructions(string[] urls, string destination)
		{
			this.urls = urls;
			this.destination = destination;
		}

		/// <summary>
		/// shallow copy
		/// </summary>
		public string[] URLs
		{
			get
			{
				return (string[]) this.urls.Clone();
			}
		}

		public string Destination
		{
			get
			{
				return this.destination;
			}
		}
	}
}
