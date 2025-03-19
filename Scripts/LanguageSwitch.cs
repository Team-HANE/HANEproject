using Godot;
using System;

public partial class LanguageSwitch : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		GetNode<Button>("Fi").Pressed += () => ChangeLanguage("fi");
		GetNode<Button>("Eng").Pressed += () => ChangeLanguage("en");
	}
	private void ChangeLanguage(string locale)
	{
		// Set language
		TranslationServer.SetLocale(locale);
		GD.Print("Language switched to: " + locale);

	}
}
