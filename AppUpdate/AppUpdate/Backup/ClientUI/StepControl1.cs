using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using updater.VersionCheck;

namespace updater.ClientUI
{
	/// <summary>
	/// StepControl1 ��ժҪ˵����
	/// </summary>
	public class StepControl1 : Tools.WizardLibrary.StepControlBase
	{
        private System.Windows.Forms.Panel panel1;
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StepControl1()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();

			this.ResetButtonEnable();
			this.IsPrevEnable = false;
			this.IsFinishEnable = false;

			this.HeaderText = "HHJT��������ֵ�������";
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 427);
            this.panel1.TabIndex = 1;
            // 
            // StepControl1
            // 
            this.BackgroundImage = global::updater.ClientUI.Properties.Resources.������ɫ;
            this.Controls.Add(this.panel1);
            this.Name = "StepControl1";
            this.Size = new System.Drawing.Size(588, 427);
            this.Load += new System.EventHandler(this.StepControl1_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void StepControl1_Load(object sender, System.EventArgs e)
		{
		 
			this.ctlprev = null;

			// ///////////////////////////////

			Tools.WizardLibrary.WizardObjects.MainCtler.SetHearderText(this.HeaderText);

		}

		public override bool GoNext()
		{
	 

			return base.GoNext ();
		}

       


	}
}
