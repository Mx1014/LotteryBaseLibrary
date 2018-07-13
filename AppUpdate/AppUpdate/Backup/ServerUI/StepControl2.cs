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
	/// StepControl2 ��ժҪ˵����
	/// </summary>
	public class StepControl2 : StepControlBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnFolder;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnRemoveAll;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Button btnDefault;
		private System.Windows.Forms.Label label2;
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StepControl2()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();

						
			this.ResetButtonEnable();
			this.IsFinishEnable = false;
			
			//this.CustomActivatedEvent += new EventHandler(this.Control2Activated);
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnFolder = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnRemoveAll = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnDefault = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(88, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(424, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "ѡ������Ŀ¼����Exe�ļ�";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 64);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(432, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// btnFolder
			// 
			this.btnFolder.Location = new System.Drawing.Point(528, 64);
			this.btnFolder.Name = "btnFolder";
			this.btnFolder.TabIndex = 2;
			this.btnFolder.Text = "ѡ��Ŀ¼";
			this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4});
			this.listView1.Location = new System.Drawing.Point(24, 112);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(416, 216);
			this.listView1.TabIndex = 3;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "�ļ���";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "�汾";
			this.columnHeader2.Width = 110;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "��С(KB)";
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "����·��";
			this.columnHeader4.Width = 200;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(480, 120);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 4;
			this.btnAdd.Text = "����";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(480, 168);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.TabIndex = 5;
			this.btnRemove.Text = "ɾ��";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnRemoveAll
			// 
			this.btnRemoveAll.Location = new System.Drawing.Point(480, 216);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.TabIndex = 6;
			this.btnRemoveAll.Text = "ɾ��ȫ��";
			this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "��ִ���ļ�(*.exe)|*.exe|�����ļ�|*.*";
			this.openFileDialog1.Multiselect = true;
			this.openFileDialog1.ShowReadOnly = true;
			this.openFileDialog1.Title = "��ѡ���°汾��Exe�ļ�";
			// 
			// btnDefault
			// 
			this.btnDefault.Location = new System.Drawing.Point(480, 264);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(72, 24);
			this.btnDefault.TabIndex = 7;
			this.btnDefault.Text = "Ĭ������";
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(64, 336);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(416, 24);
			this.label2.TabIndex = 8;
			this.label2.Text = "׼����ȫ�󣬵���һ�������汾�ļ����ɺ�ѹ��";
			// 
			// StepControl2
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnDefault);
			this.Controls.Add(this.btnRemoveAll);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.btnFolder);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "StepControl2";
			this.Size = new System.Drawing.Size(616, 376);
			this.Load += new System.EventHandler(this.StepControl2_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void StepControl2_Load(object sender, System.EventArgs e)
		{
			this.ctlprev = GlobalObjects.ctl1;
			this.ctlnext = GlobalObjects.ctl3;
		}
	
		private void Control2Activated(object sender,EventArgs e)
		{

		}

		private void btnFolder_Click(object sender, System.EventArgs e)
		{
			folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
			folderBrowserDialog1.SelectedPath = Application.StartupPath;

			if(folderBrowserDialog1.ShowDialog(this)==DialogResult.OK)
			{
				textBox1.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void AddFileImtes(string[] multifiles)
		{
			if(multifiles == null) return;

			for(int i=0;i<multifiles.Length;i++)
			{
				FileInfo fi = new FileInfo(multifiles[i]);
				if(fi.Exists)
				{
					string version = "";
					try
					{
						Assembly assm = Assembly.LoadFile(multifiles[i]);
						
						if(assm != null)
						{
							version = assm.GetName().Version.ToString();
							assm = null;
						}
					}
					catch
					{
						version = "Get Version Error";
					}

					ListViewItem lvi = new ListViewItem(
						new string[] {fi.Name, version, fi.Length.ToString("###,###,###"), multifiles[i]});
					listView1.Items.Add(lvi);
				}				

			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog(this)==DialogResult.OK)
			{
				AddFileImtes(openFileDialog1.FileNames);
			}
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			for(int i=listView1.SelectedItems.Count-1;i>=0 && i<listView1.SelectedItems.Count;i--)
			{
				listView1.Items.Remove(listView1.SelectedItems[i]);
			}
		}

		private void btnRemoveAll_Click(object sender, System.EventArgs e)
		{
			for(int i=listView1.Items.Count-1;i>=0 && i<listView1.Items.Count;i--)
			{
				listView1.Items.RemoveAt(i);
			}
		}

		public override bool GoNext()
		{
			if(textBox1.Text.Trim().Length == 0)
			{
				MessageBox.Show(this,"û��ѡ�����������Ŀ¼��","��ʾ",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;				
			}

			if(listView1.Items.Count == 0)
			{
				if(MessageBox.Show(this,"û��ѡ���ִ��Exe�ļ����Ƿ�ʹ��Ĭ�����ã�","��ʾ",
					MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					btnDefault_Click(null,null);
				}
				return false;
			}

			GlobalObjects.ctl3.verdata = new VersionData();

			foreach(ListViewItem lvi in listView1.Items)
			{
				DataRow row = GlobalObjects.ctl3.verdata.Tables[VersionData.mTableName].NewRow();
				row[VersionData.mExeName] = lvi.SubItems[0].Text;
				row[VersionData.mFullVersion] = lvi.SubItems[1].Text;

				Version sv = new Version(lvi.SubItems[1].Text);				
				row[VersionData.mFirst] = sv.Major.ToString();
				row[VersionData.mSecond] = sv.Minor.ToString();
				row[VersionData.mThird] = sv.Build.ToString();	
				row[VersionData.mForth] = sv.Revision.ToString();
				GlobalObjects.ctl3.verdata.Tables[VersionData.mTableName].Rows.Add(row);				
			}

			GlobalObjects.ctl3.FolderPath = textBox1.Text.Trim();

			return base.GoNext ();
		}

		private void btnDefault_Click(object sender, System.EventArgs e)
		{
			if(textBox1.Text.Trim().Length == 0)
			{
				MessageBox.Show(this,"ʹ��Ĭ���ļ��������������ļ�·����","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			string[] multifiles = new string[ConfigurationValues.ArrayExeFiles.Length];
			for(int i=0;i<ConfigurationValues.ArrayExeFiles.Length;i++)
			{
				string filepath = Path.Combine(textBox1.Text.Trim(), ConfigurationValues.ArrayExeFiles[i]);

				multifiles[i] = filepath;
			}

			btnRemoveAll_Click(sender,e);
			AddFileImtes(multifiles);

		}



	}
}
