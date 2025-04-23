using Godot;
using System.Text.Json;

namespace escapetampere
{

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

            jsonData = JsonDataLoader.Load("res://koulut.json") ?? default;
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
}