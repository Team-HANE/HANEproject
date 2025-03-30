using Godot;
using System.Text.Json;

public partial class SchoolInfo : Control
{
    private JsonElement jsonData;
    private Label nameLabel;
    private Label addressLabel;
    private Panel infoPanel;

    public override void _Ready()
    {
        nameLabel = GetNode<Label>("Node2D/InfoPanel/VBoxContainer/NameLabel");
        addressLabel = GetNode<Label>("Node2D/InfoPanel/VBoxContainer/AddressLabel");

        LoadJson("res://koulut.json");
    }

    private void LoadJson(string filePath)
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
        if (jsonData.TryGetProperty("features", out JsonElement features) && features.GetArrayLength() > index)
        {
            JsonElement school = features[index];
            if (school.TryGetProperty("properties", out JsonElement properties))
            {
                nameLabel.Text = Tr("Name: " + properties.GetProperty("NIMI").GetString());
                addressLabel.Text = "Address: " + properties.GetProperty("OSOITE").GetString();
            }
        }
    }
}