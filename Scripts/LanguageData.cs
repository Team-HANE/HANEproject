using Godot;
using System;

[GlobalClass]
public partial class LanguageData : Resource
{
    [Export] public string CurrentLocale = "fi";

    public void SetLanguage(string locale)
    {
        CurrentLocale = locale;
        TranslationServer.SetLocale(locale);
        GD.Print("Language switched to: " + locale);

        ResourceSaver.Save(this, "res://LanguageData.tres");
    }
}
