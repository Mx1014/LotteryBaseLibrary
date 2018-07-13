using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Tools.WizardLibrary;

namespace updater.ClientUI
{
	/// <summary>
	/// MainForm ��ժҪ˵����
	/// </summary>
	public class MainForm : WizardFormBase
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Windows ���������֧���������
			//
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(656, 502);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�������³���";

		}
		#endregion


		protected override void MethodFormLoad(object sender, EventArgs e)
		{
			corectl = new Tools.WizardLibrary.Controller();
			corectl.Form = this;
			corectl.Control = GlobalObjects.ctl1;

			WizardObjects.MainCtler = corectl;

			base.MethodFormLoad (sender, e);

			corectl.SetButtonStates();
			corectl.PanelAddControl(corectl.Control);
		}


	}
}
