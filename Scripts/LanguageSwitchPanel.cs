using Godot;
using System;

namespace escapetampere
{
	public partial class LanguageSwitchPanel : Node2D
	{
		private Label popupLabel;
		private LanguageData _languageData;
		public override void _Ready()
		{
			popupLabel = GetNode<Label>("PopupPanel/Label");

			_languageData = ResourceLoader.Load<LanguageData>("res://LanguageData.tres");

			Translation fiTranslation = new Translation();
			Translation engTranslation = new Translation();

			fiTranslation.AddMessage("POPUP_MESSAGE", "Tervetuloa peliin! \n Sinun täytyy selvittää, miten päästä tien yli turvallisesti. \n Klikkaa kohtia, jotka ovat väärin.");

			engTranslation.AddMessage("POPUP_MESSAGE", "Welcome to the game! \n You have to figure out, how to get to the other side safely. \n Click on the errors.");


			TranslationServer.AddTranslation(fiTranslation);
			TranslationServer.AddTranslation(engTranslation);


			//TranslationServer.SetLocale(_languageData.CurrentLocale);

			UpdateText();
		}

		private void UpdateText()
		{
			if (popupLabel != null)
			{
				popupLabel.Text = Tr("POPUP_MESSAGE");
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