using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Tools.WizardLibrary
{
	public delegate void ControlActivated(object sender,EventArgs e);

	/// <summary>
	/// StepControlBase ��ժҪ˵����
	/// </summary>
	public class StepControlBase : System.Windows.Forms.UserControl, IUIWizard
	{
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StepControlBase()
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
			// 
			// StepControlBase
			// 
			this.Name = "StepControlBase";
			this.Size = new System.Drawing.Size(632, 472);

		}
		#endregion

		#region Interface Method

		

		public virtual bool GoPrevious()
		{
			if( (WizardObjects.MainCtler != null) && (this.ctlprev!=null) )
			{	
				WizardObjects.MainCtler.PanelAddControl(this.ctlprev);
			}
			else
			{
				this.IsPrevEnable = false;
				return false;
			}
			return true;
		}
		public virtual bool GoNext()
		{
			if( (WizardObjects.MainCtler != null) && (this.ctlnext!=null) )
			{	
				WizardObjects.MainCtler.PanelAddControl(this.ctlnext);
			}
			else
			{
				this.IsNextEnable = false;
				return false;
			}
			return true;
		}
		public virtual bool GoFinish()
		{
			return true;
		}
		public virtual bool GoCancel()
		{
			if(null == WizardObjects.MainCtler) return false;

			if(MessageBox.Show(this,"ȷ���˳���","��ʾ",
				MessageBoxButtons.YesNo,MessageBoxIcon.Information)
				==DialogResult.Yes)
			{
				WizardObjects.MainCtler.Form.Close();
				return true;
			}
			return false;
		}
		#endregion


		public virtual void ResetButtonEnable()
		{
			IsPrevEnable = true;
			IsNextEnable = true;
			IsCancelEnable = true;
			IsFinishEnable = true;
		}

		protected StepControlBase ctlnext = null;
		protected StepControlBase ctlprev = null;


		public bool IsCancelEnable = true;
		public bool IsPrevEnable = true;
		public bool IsNextEnable = true;
		public bool IsFinishEnable = true;

		/*
		[Category("CustomEvent"),Description("�ؼ���Activated�¼�,��Form Activated����ĵ���")]
		public event EventHandler CustomActivatedEvent;
		public virtual void OnCustomControlActivated(object sender,EventArgs e)
		{
			if(CustomActivatedEvent != null)
			{
				CustomActivatedEvent(sender,e);
			}
		}
		*/

		//������������ʾ��ʱ���Ƿ���Ҫ���µ���Form_Load; true��Ҫ���á�
		//public bool IsFormReload = false;

		public string HeaderText = string.Empty;

	}
}
