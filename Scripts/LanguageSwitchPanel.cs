using Godot;
using System;

namespace escapetampere
{
	public partial class LanguageSwitchPanel : Node2D
	{
		private Label popupLabel;
		private Label levelTwoPopup;
		private LanguageData _languageData;
		public override void _Ready()
		{
			popupLabel = GetNode<Label>("PopupPanel/Label");
			levelTwoPopup = GetNode<Label>("Level2PopupPanel/Label");

			_languageData = ResourceLoader.Load<LanguageData>("res://LanguageData.tres");

			Translation fiTranslation = new Translation();
			Translation enTranslation = new Translation();

			fiTranslation.AddMessage("POPUP_MESSAGE", "Tervetuloa peliin! \n Sinun täytyy selvittää, miten päästä tien yli turvallisesti. \n Klikkaa kohtia, jotka ovat väärin.");

			enTranslation.AddMessage("POPUP_MESSAGE", "Welcome to the game! \n You have to figure out, how to get to the other side safely. \n Click on the errors.");

			fiTranslation.AddMessage("LEVEL2_POPUP", "Järjestyksellä on merkitystä.");
			enTranslation.AddMessage("LEVEL2_POPUP", "Order matters.");


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
		}
		private void ChangeLanguage(string locale)
		{
			_languageData.SetLanguage(locale);
			TranslationServer.SetLocale(locale);
			UpdateText();
		}
	}
}