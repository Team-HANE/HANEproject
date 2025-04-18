using Godot;
using System;

namespace escapetampere
{
	public partial class LanguageSwitchPanel : Node2D
	{
		private Label popupLabel;
		private Label levelTwoPopup;
		private Label confirmationPop;
		private Label CSLabel;
		private LanguageData _languageData;
		public override void _Ready()
		{
			if (HasNode("PopupPanel/Label"))
				popupLabel = GetNode<Label>("PopupPanel/Label");

			if (HasNode("Level2PopupPanel/Label"))
				levelTwoPopup = GetNode<Label>("Level2PopupPanel/Label");

			if (HasNode("ConfirmationPopup/VBoxContainer/Label"))
				confirmationPop = GetNode<Label>("ConfirmationPopup/VBoxContainer/Label");

			if (HasNode("CSPanel/Label"))
				CSLabel = GetNode<Label>("CSPanel/Label");

			Translation fiTranslation = new Translation();
			Translation enTranslation = new Translation();

			TranslationServer.AddTranslation(fiTranslation);
			TranslationServer.AddTranslation(enTranslation);


			UpdateText();
		}

		private void UpdateText()
		{
			if (popupLabel != null)
			{
				popupLabel.Text = Tr("POPUP_MESSAGE");
			}
			if (levelTwoPopup != null)
			{
				levelTwoPopup.Text = Tr("LEVEL2_POPUP");
			}
			if (confirmationPop != null)
			{
				confirmationPop.Text = Tr("CONFIRMATION_POP");
			}
			if (CSLabel != null)
			{
				CSLabel.Text = Tr("COMING_SOON");
			}
		}
		private void ChangeLanguage(string locale)
		{
			_languageData.SetLanguage(locale);
			TranslationServer.SetLocale(locale);
			UpdateText();
		}
	}
}