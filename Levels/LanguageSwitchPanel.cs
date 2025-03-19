using Godot;
using System;

namespace escapetampere
{
	public partial class LanguageSwitchPanel : Node2D
	{
		private Label popupLabel;
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			popupLabel = GetNode<Label>("PopupPanel/Label");
			AddTranslation();
			UpdateText();
		}

		private void AddTranslation()
		{
			Translation fiTranslation = new Translation();
			Translation engTranslation = new Translation();

			fiTranslation.AddMessage("POPUP_MESSAGE", "Tervetuloa peliin! \n Sinun täytyy selvittää, miten päästä tien yli turvallisesti. \n Klikkaa kohtia, jotka ovat väärin.");

			engTranslation.AddMessage("POPUP_MESSAGE", "Welcome to the game! \n You have to figure out, how to get to the other side safely. \n Click on the errors.");


			TranslationServer.AddTranslation(fiTranslation);
			TranslationServer.AddTranslation(engTranslation);

		}

		private void UpdateText()
		{
			if (popupLabel !=null)
			{
				popupLabel.Text = Tr("POPUP_MESSAGE");
			}
		}
		private void ChangeLanguage(string locale)
		{
			// Set language
			TranslationServer.SetLocale(locale);
			GD.Print("Language switched to: " + locale);
			UpdateText();
		}
	}
}