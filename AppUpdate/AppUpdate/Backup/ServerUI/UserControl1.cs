using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace updater.ServerUI
{
	/// <summary>
	/// UserControl1 ��ժҪ˵����
	/// </summary>
	public class UserControl1 : Tools.WizardLibrary.StepControlBase
	{
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserControl1()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();

			// TODO: �� InitializeComponent ���ú�����κγ�ʼ��

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
			// 
			// UserControl1
			// 
			this.Name = "UserControl1";
			this.Size = new System.Drawing.Size(576, 464);

		}
		#endregion
	}
}
