using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Tools.WizardLibrary;

namespace updater.ServerUI
{
	/// <summary>
	/// StepForm1 ��ժҪ˵����
	/// </summary>
	public class StepControl1 : StepControlBase
	{
		private System.Windows.Forms.Label label1;
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StepControl1()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();

			//add in contructor
			

			this.ResetButtonEnable();
			this.IsPrevEnable = false;
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
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(256, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(352, 192);
			this.label1.TabIndex = 0;
			this.label1.Text = "˵����POS��������";
			// 
			// StepControl1
			// 
			this.Controls.Add(this.label1);
			this.Name = "StepControl1";
			this.Size = new System.Drawing.Size(648, 448);
			this.Load += new System.EventHandler(this.StepControl1_Load);
			this.ResumeLayout(false);

		}
		#endregion

			

		private void StepControl1_Load(object sender, System.EventArgs e)
		{
			this.ctlnext = GlobalObjects.ctl2;
			this.ctlprev = null;
		}


	}
}
