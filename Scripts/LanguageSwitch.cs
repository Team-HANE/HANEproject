using Godot;
using System;

public partial class LanguageSwitch : CanvasLayer
{
	private LanguageData _languageData;

	[Export] private Texture2D fiActive;
	[Export] private Texture2D fiInactive;
	[Export] private Texture2D engActive;
	[Export] private Texture2D engInactive;

	private Button fi;
	private Button en;

	public override void _Ready()
	{
		_languageData = ResourceLoader.Load<LanguageData>("res://LanguageData.tres");
		fi = GetNode<Button>("Fi");
		en = GetNode<Button>("Eng");
		fi.Pressed += () => ChangeLanguage("fi");
		en.Pressed += () => ChangeLanguage("en");

		UpdateButtonIcons (_languageData.CurrentLocale);
	}
	private void ChangeLanguage(string locale)
	{
		_languageData.SetLanguage(locale);
		UpdateButtonIcons(locale);
	}

	private void UpdateButtonIcons(string activeLocale)
	{
		// When Finnish is active, show its active texture and the inactive texture for English
		if (activeLocale == "fi")
		{
			fi.Icon = fiActive;
			en.Icon = engInactive;
		}
		// When English is active, show its active texture and the inactive texture for Finnish
		else if (activeLocale == "en")
		{
			fi.Icon = fiInactive;
			en.Icon = engActive;
		}
	}
}
