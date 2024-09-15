using Mindravel.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MergeFactory
{
	public class WelcomeBackScreen : MonoBehaviour
	{
		public delegate void ConfirmationActions();

		public Text coinText;

		public Text doubleCoinText;

		private WelcomeBackScreen.ConfirmationActions confirmedAction;

		private WelcomeBackScreen.ConfirmationActions cancelAction;

		public void ShowMessage(float earned, WelcomeBackScreen.ConfirmationActions _confirmedAction = null, WelcomeBackScreen.ConfirmationActions _cancelAction = null)
		{
			this.coinText.text = "YOU EARNED : " + earned.ToShortHandString();
			this.doubleCoinText.text = (earned * 2f).ToShortHandString();
			this.confirmedAction = _confirmedAction;
			this.cancelAction = _cancelAction;
		}

		public void Button_Confirm()
		{
			if (this.confirmedAction != null)
			{
				this.confirmedAction();
			}
			else
			{
				GUIManager.Instance.Back();
			}
		}

		public void Button_Cancel()
		{
			if (this.cancelAction != null)
			{
				this.cancelAction();
			}
			else
			{
				GUIManager.Instance.Back();
			}
		}
	}
}
