using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Tools.WizardLibrary;
using updater.DataModels;

namespace updater.ServerUI
{
	/// <summary>
	/// StepControl3 ��ժҪ˵����
	/// </summary>
	public class StepControl3 : StepControlBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblmsg;
		private System.Windows.Forms.Button btnRedo;
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StepControl3()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();

			this.ResetButtonEnable();
			this.IsFinishEnable = false;
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
			this.label1 = new System.Windows.Forms.Label();
			this.lblmsg = new System.Windows.Forms.Label();
			this.btnRedo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(96, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(424, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "ˢ�°汾��Ϣ";
			// 
			// lblmsg
			// 
			this.lblmsg.Location = new System.Drawing.Point(96, 104);
			this.lblmsg.Name = "lblmsg";
			this.lblmsg.Size = new System.Drawing.Size(440, 192);
			this.lblmsg.TabIndex = 2;
			// 
			// btnRedo
			// 
			this.btnRedo.Location = new System.Drawing.Point(96, 312);
			this.btnRedo.Name = "btnRedo";
			this.btnRedo.Size = new System.Drawing.Size(112, 32);
			this.btnRedo.TabIndex = 3;
			this.btnRedo.Text = "����ѹ��";
			this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
			// 
			// StepControl3
			// 
			this.Controls.Add(this.btnRedo);
			this.Controls.Add(this.lblmsg);
			this.Controls.Add(this.label1);
			this.Name = "StepControl3";
			this.Size = new System.Drawing.Size(624, 480);
			this.Load += new System.EventHandler(this.StepControl3_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public VersionData verdata = null;
		public string FolderPath = string.Empty;

		private void StepControl3_Load(object sender, System.EventArgs e)
		{
			this.ctlnext = GlobalObjects.ctl4;
			this.ctlprev = GlobalObjects.ctl2;

			//////////////////////////////		

			btnRedo_Click(sender,e);

		}

		private void btnRedo_Click(object sender, System.EventArgs e)
		{
			if(verdata == null)
			{
				lblmsg.Text = "ˢ�°汾��Ϣ���������ԣ�";
				return;
			}
            
            DirectoryInfo di = new DirectoryInfo(FolderPath);

			string tofile = Path.Combine(
                    Path.Combine(di.Parent.FullName , ConfigurationValues.DownDir),
					ConfigurationValues.DataFileName);
			verdata.WriteXml(tofile, XmlWriteMode.WriteSchema);

			lblmsg.Text = "д�汾��Ϣ�ɹ���\n";
			lblmsg.Text += "����ѹ��...\n";
			Application.DoEvents();

			
			if(!di.Exists)
			{
				lblmsg.Text += "ѹ��ʧ�ܣ�";
				return;
			}

            string zipedfile = Path.Combine(di.Parent.FullName + "\\" + ConfigurationValues.DownDir, di.Name + ".zip");
			bool bret = Tools.ZipLibrary.ZipHelper.ZipDirectory(FolderPath,zipedfile);

			if(!bret)
			{
				lblmsg.Text += "ѹ��ʧ��.������.";
				return;
			}
			FileInfo fi = new FileInfo(zipedfile);
			if(fi.Exists)
			{
				lblmsg.Text += "ѹ���ɹ�.ѹ���ļ�Ϊ��\n" + zipedfile;

				FileListData fld = new FileListData();
				DataRow  row = fld.Tables[FileListData.mTableName].NewRow();
				row[FileListData.mFileName] = fi.Name;
				row[FileListData.mFileLength] = fi.Length;
				fld.Tables[FileListData.mTableName].Rows.Add(row);

				tofile = Path.Combine(
                    Path.Combine(di.Parent.FullName, ConfigurationValues.DownDir),					
					ConfigurationValues.ListFileName);

				fld.WriteXml(tofile, XmlWriteMode.WriteSchema);

				lblmsg.Text += "���������б��ļ��ɹ���\n";
			}	
		}


	}
}
