using Godot;
using System.Text.Json;

public partial class SchoolInfo : Control
{
    private JsonElement jsonData;
    private Label WhatIsIt;
    private Label nameLabel;
    private Label addressLabel;
    private Label lkmLabel;
    private Panel infoPanel;

    public override void _Ready()
    {
        nameLabel = GetNode<Label>("Node2D/InfoPanel/VBoxContainer/NameLabel");
        addressLabel = GetNode<Label>("Node2D/InfoPanel/VBoxContainer/AddressLabel");
        lkmLabel = GetNode<Label>("Node2D/InfoPanel/VBoxContainer/lkmLabel");
        WhatIsIt = GetNode<Label>("Node2D/InfoPanel/VBoxContainer/Label");

        LoadJson("res://koulut.json");
    }

    public void LoadJson(string filePath)
    {
        if (!FileAccess.FileExists(filePath))
        {
            GD.PrintErr($"File not found: {filePath}");
            return;
        }

        using FileAccess file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);
        string jsonText = file.GetAsText();

        try
        {
            jsonData = JsonSerializer.Deserialize<JsonElement>(jsonText);
        }
        catch (System.Exception e)
        {
            GD.PrintErr("Failed to parse JSON: " + e.Message);
        }
    }

    public void ShowSchoolInfo(int index)
    {
        WhatIsIt.Text = Tr("WHAT");
        if (jsonData.TryGetProperty("features", out JsonElement features) && features.GetArrayLength() > index)
        {
            JsonElement school = features[index];
            if (school.TryGetProperty("properties", out JsonElement properties))
            {

                int studentLkm = properties.GetProperty("OPPILASMAARA").GetInt32();
                nameLabel.Text = Tr(properties.GetProperty("NIMI").GetString());
                addressLabel.Text = Tr("ADDRESS") + properties.GetProperty("OSOITE").GetString() + ", " + properties.GetProperty("POSTINUMERO").GetString();

                lkmLabel.Text = Tr("STUDENTAMT") + studentLkm;
            }

        }
    }
}