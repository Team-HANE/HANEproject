using Godot;
using System.Text.Json;

public partial class LibraryInfo : Control
{
    private Label nameLabel;
    private Label addressLabel;
    private JsonElement jsonData;
    private Label schoolNameLabel;
    private Label schoolAddressLabel;
    //private Label lkmLabel;
    //private Label schoolInfoLabel;


    public override void _Ready()
    {
        nameLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/NameLabel");
        addressLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/AddressLabel");
        schoolNameLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/SchoolNameLabel");
        schoolAddressLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/SchoolAddressLabel");
        //schoolInfoLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/SchoolInfoLabel");

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

    public void ShowLibraryInfo(int index)
    {
        if (jsonData.TryGetProperty("features", out JsonElement features) && features.GetArrayLength() > index)
        {
            JsonElement school = features[index]; // Selecting another school from the JSON
            if (school.TryGetProperty("properties", out JsonElement properties))
            {
                //int studentLkm = properties.GetProperty("OPPILASMAARA").GetInt32();
                schoolNameLabel.Text = (properties.GetProperty("NIMI").GetString());
               schoolAddressLabel.Text = "Address: " + properties.GetProperty("OSOITE").GetString() + ", " + properties.GetProperty("POSTINUMERO").GetString();
                //lkmLabel.Text = $"Student amount: {studentLkm}";
            }
        }
        else
        {
            GD.PrintErr("Invalid index or JSON structure.");
        }
    }
}