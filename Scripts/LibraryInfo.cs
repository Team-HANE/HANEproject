using Godot;
using System.Text.Json;

namespace escapetampere
{

    public partial class LibraryInfo : Control
    {
        private JsonElement jsonData;
        private Label WhatIsIt;
        private Label NameLabel;
        private Label addressLabel;
        private Label schoolInfoLabel;
        private Label schoolNameLabel;
        private Label schoolAddressLabel;

        public override void _Ready()
        {
            schoolNameLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/SchoolNameLabel");
            schoolAddressLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/SchoolAddressLabel");
            WhatIsIt = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/Label");
            schoolInfoLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/SchoolInfoLabel");
            addressLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/AddressLabel");
            NameLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/NameLabel");


            jsonData = JsonDataLoader.Load("res://koulut.json") ?? default;

        }

        public void ShowLibraryInfo(int index)
        {
            WhatIsIt.Text = Tr("WHAT");
            NameLabel.Text = Tr("LIB");
            addressLabel.Text = Tr("ADDRESS") + "Pirkankatu 2";
            schoolInfoLabel.Text = Tr("NEAREST");
            if (jsonData.TryGetProperty("features", out JsonElement features) && features.GetArrayLength() > index)
            {
                JsonElement school = features[index];
                if (school.TryGetProperty("properties", out JsonElement properties))
                {
                    schoolNameLabel.Text = properties.GetProperty("NIMI").GetString();
                    schoolAddressLabel.Text = Tr("ADDRESS") + properties.GetProperty("OSOITE").GetString() + ", " + properties.GetProperty("POSTINUMERO").GetString();
                    //lkmLabel.Text = $"Student amount: {studentLkm}";
                }
            }
            else
            {
                GD.PrintErr("Invalid index or JSON structure.");
            }
        }
    }
}