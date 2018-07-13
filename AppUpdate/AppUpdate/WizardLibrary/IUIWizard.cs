using System;

namespace Tools.WizardLibrary
{
	/// <summary>
	/// IWizard ��ժҪ˵����
	/// </summary>
	public interface IUIWizard
	{
		bool GoPrevious();
		bool GoNext();
		bool GoFinish();
		bool GoCancel();		
	}
}
