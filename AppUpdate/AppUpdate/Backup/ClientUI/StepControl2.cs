using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Tools.WizardLibrary;
using Tools.DownloadLibrary;
using updater.DataModels;
using updater.VersionCheck;
using System.Diagnostics;

namespace updater.ClientUI
{
	/// <summary>
	/// StepControl2 ��ժҪ˵����
	/// </summary>
	public class StepControl2 :Form
    {
		private System.Windows.Forms.RichTextBox richTextBox1;
        private Button button1;
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StepControl2()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();
 
		}

		/// <summary> 
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region �����������ɵĴ���
		/// <summary> 
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(56, 44);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(515, 224);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "��ʼ����";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StepControl2
            // 
            this.ClientSize = new System.Drawing.Size(535, 229);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "StepControl2";
            this.Load += new System.EventHandler(this.StepControl2_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void StepControl2_Load(object sender, System.EventArgs e)
		{
		 
		
			///////////////////////////////////			

		//	WizardObjects.MainCtler.SetHearderText("�ڶ������Ƚϰ汾��Ϣ");

			/*
			this.btnRedo.Left = WizardObjects.MainCtler.Form.ButtonCancel.Left - btnRedo.Width - 16;
			this.btnRedo.Top = WizardObjects.MainCtler.Form.ButtonCancel.Top;
			this.btnRedo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

			this.btnRedo.Height = WizardObjects.MainCtler.Form.ButtonCancel.Height;

			this.Controls.Remove(btnRedo);
			WizardObjects.MainCtler.Form.FootPanel.Controls.Add(btnRedo);
			*/

		 
			btnRedo_Click(sender,e);
		 

		}

		private bool hasnewver = true;
		private void btnRedo_Click(object sender, System.EventArgs e)
		{ 
			WizardObjects.MainCtler.SetButtonStates();

			 
			richTextBox1.Text = "";
			richTextBox1.Clear();

			richTextBox1.Text = "";
			
			richTextBox1.Text = "�������������ļ�...";
			Application.DoEvents();

			string dstdir = Application.StartupPath;
			string url1 = Path.Combine(ConfigurationValues.UpdateServerPath, ConfigurationValues.DataFileName);
			string url2 = Path.Combine(ConfigurationValues.UpdateServerPath, ConfigurationValues.ListFileName);
            
			string l1 = Path.Combine(dstdir, ConfigurationValues.DataFileName);
			string l2 = Path.Combine(dstdir, ConfigurationValues.ListFileName);

			if(File.Exists(l1)) File.Delete(l1);
			if(File.Exists(l2)) File.Delete(l2);

			bool bret = BatchDownload(new string[] {url1,url2}, dstdir);

			if(!bret)
			{
				richTextBox1.Text += "\n���������ļ�ʧ�ܣ����������Ƿ�������������·�������Ƿ���ȷ��";
                richTextBox1.Text += "\n��ǰ������·����" + ConfigurationValues.UpdateServerPath;
		 
				WizardObjects.MainCtler.SetButtonStates();
				return;
			}
			else
			{
				richTextBox1.Text += "\n���������ļ��ɹ�.���ڱȽϰ汾...";
			}
			Application.DoEvents();

			if(File.Exists(Path.Combine(dstdir,ConfigurationValues.DataFileName) ) )
			{
				GlobalObjects.ServerVerData.Clear();
				GlobalObjects.ServerVerData.ReadXml( Path.Combine(dstdir,ConfigurationValues.DataFileName), XmlReadMode.ReadSchema);
			}			
			VersionData serVersion = GlobalObjects.ServerVerData;

			if(File.Exists(Path.Combine(dstdir,ConfigurationValues.ListFileName)) )
			{
				GlobalObjects.ServerFileData.Clear();
				GlobalObjects.ServerFileData.ReadXml( Path.Combine(dstdir,ConfigurationValues.ListFileName), XmlReadMode.ReadSchema);
			}
			FileListData filelist = GlobalObjects.ServerFileData;			

			if( (serVersion == null) || (filelist == null) )
			{
				richTextBox1.Text += "\n�������ļ����������ԡ�";
				Application.DoEvents();
			 
				WizardObjects.MainCtler.SetButtonStates();
				return;
			}

			string outputversion = "";
			foreach(DataRow row in serVersion.Tables[VersionData.mTableName].Rows)
			{
				string exename = row[VersionData.mExeName].ToString();

				DirectoryInfo curdi = new DirectoryInfo(Application.StartupPath);
				DirectoryInfo parentdi = curdi.Parent;

				string exefullname = Path.Combine(parentdi.FullName, exename);
				string dircopyto = Path.Combine(curdi.FullName,GlobalObjects.C_Temp);
				string tmpexefullname = Path.Combine(dircopyto, exename + Guid.NewGuid().ToString());
				
				if(!Directory.Exists(dircopyto))
				{
					Directory.CreateDirectory(dircopyto);
				}
				
				outputversion += "�ļ�����" + exename + "\n";
				outputversion += "�������汾��" + row[VersionData.mFullVersion].ToString() + "\n";

                Application.DoEvents();

                try
                {
                    if (File.Exists(exefullname))
                    {
                        if (File.Exists(tmpexefullname))
                        {
                            File.Delete(tmpexefullname);
                        }

                        File.Copy(exefullname, tmpexefullname, true);

                        //Assembly assm = Assembly.LoadFrom(tmpexefullname);
                        //if (assm == null) continue;

                        //string cliver = assm.GetName().Version.ToString();
                        FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(tmpexefullname);
                        string cliver = myFileVersionInfo.FileVersion;
 
                        //assm = null;

                        outputversion += "�ͻ��˰汾��" + cliver + "\n";
                        outputversion += "\n";

                        this.hasnewver = false;
                        if (Helper.IsNewVersion(new Version(cliver),
                            new Version(row[VersionData.mFullVersion].ToString())))
                        {
                            hasnewver = true;
                        }
                    }
                    else
                    {
                        outputversion += "�ͻ��˰汾����\n";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("��������" + ex.Message, "��ʾ");
                }
			}

			if(hasnewver)
			{
				richTextBox1.Text += "\n\n�������°汾.";
			}
			else
			{
				richTextBox1.Text += "\n\n����û�з����°汾.";
			}

			richTextBox1.Text +=  "\n\n" + outputversion;
			
			Application.DoEvents();
	

			if(hasnewver)
			{
			 
				WizardObjects.MainCtler.SetButtonStates();
			}
			else
			{
			 
			 
				WizardObjects.MainCtler.SetButtonStates();
			}

		}

		private bool SingleDownload(string url, string dst)
		{
			try
			{
				using(HttpFileDownloader dl = new HttpFileDownloader())
				{
					dl.Download(url, dst, null);
				}
			}
			catch
			{
				return false;
			}
			return true;
		}

		private bool BatchDownload(string[] urls, string dstdir)
		{
			try
			{
				using(HttpBatchDownloader dl = new HttpBatchDownloader())
				{
					dl.Download(urls, dstdir, null);
				}
			}
			catch
			{
				return false;
			}
			return true;
		}
        private void button1_Click(object sender, EventArgs e)
        {
            btnRedo_Click(null, null);
        }


	}
}
