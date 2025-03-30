using Godot;
using System;

namespace escapetampere
{
	public partial class LanguageSwitchPanel : Node2D
	{
		private Label popupLabel;
		private Label levelTwoPopup;
		private Label confirmationPop;
		private LanguageData _languageData;
		public override void _Ready()
		{
			popupLabel = GetNode<Label>("PopupPanel/Label");
			levelTwoPopup = GetNode<Label>("Level2PopupPanel/Label");
			confirmationPop = GetNode<Label>("ConfirmationPopup/VBoxContainer/Label");

			_languageData = ResourceLoader.Load<LanguageData>("res://LanguageData.tres");

			Translation fiTranslation = new Translation();
			Translation enTranslation = new Translation();

			fiTranslation.AddMessage("POPUP_MESSAGE", "Tervetuloa peliin! \n Sinun täytyy selvittää, miten päästä tien yli turvallisesti. \n Klikkaa kohtia, jotka ovat väärin.");

			enTranslation.AddMessage("POPUP_MESSAGE", "Welcome to the game! \n You have to figure out, how to get to the other side safely. \n Click on the errors.");

			fiTranslation.AddMessage("LEVEL2_POPUP","Voi ei! Tiellä on kuoppa. \n Korjaa ongelma jatkaaksesi matkaa! \n Järjestyksellä on väliä.");
			enTranslation.AddMessage("LEVEL2_POPUP", "Oh no! The road is blocked by a pothole. \n Fix the problem to continue your journey. \n Order matters.");

			fiTranslation.AddMessage("CONFIRMATION_POP","Oletko varma, \n että haluat poistua? \n Poistu/Palaa takaisin peliin");
			enTranslation.AddMessage("CONFIRMATION_POP", "Are you sure you want to leave? \n Leave/Back to game");


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
		}
		private void ChangeLanguage(string locale)
		{
			_languageData.SetLanguage(locale);
			TranslationServer.SetLocale(locale);
			UpdateText();
		}
	}
}