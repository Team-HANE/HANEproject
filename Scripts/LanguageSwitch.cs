using Godot;
using System;

public partial class LanguageSwitch : CanvasLayer
{
	private LanguageData _languageData;

	public override void _Ready()
	{
		_languageData = ResourceLoader.Load<LanguageData>("res://LanguageData.tres");
		GetNode<Button>("Fi").Pressed += () => ChangeLanguage("fi");
		GetNode<Button>("Eng").Pressed += () => ChangeLanguage("en");
	}
	private void ChangeLanguage(string locale)
	{
		_languageData.SetLanguage(locale);
	}
}
