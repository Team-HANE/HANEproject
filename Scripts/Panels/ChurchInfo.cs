using Godot;
using System;
using System.Text.Json;

namespace escapetampere
{
	public partial class ChurchInfo : Control
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
			schoolNameLabel = GetNode<Label>("Node2D/ChurchPanel/VBoxContainer/SchoolNameLabel");
			schoolAddressLabel = GetNode<Label>("Node2D/ChurchPanel/VBoxContainer/SchoolAddressLabel");
			WhatIsIt = GetNode<Label>("Node2D/ChurchPanel/VBoxContainer/Label");
			NameLabel = GetNode<Label>("Node2D/ChurchPanel/VBoxContainer/NameLabel");
			schoolInfoLabel = GetNode<Label>("Node2D/ChurchPanel/VBoxContainer/SchoolInfoLabel");
			addressLabel = GetNode<Label>("Node2D/ChurchPanel/VBoxContainer/AddressLabel");

			jsonData = JsonDataLoader.Load("res://koulut.json") ?? default;
		}

		public void ShowChurchInfo(int index)
		{
			WhatIsIt.Text = Tr("WHAT");
			NameLabel.Text = Tr("CHURCH");
			addressLabel.Text = Tr("ADDRESS") + "Pyynikin kirkkopuisto";
			schoolInfoLabel.Text = Tr("NEAREST");
			if (jsonData.TryGetProperty("features", out JsonElement features) && features.GetArrayLength() > index)
			{
				JsonElement school = features[index];
				if (school.TryGetProperty("properties", out JsonElement properties))
				{

					schoolNameLabel.Text = properties.GetProperty("NIMI").GetString();
					schoolAddressLabel.Text = Tr("ADDRESS") + properties.GetProperty("OSOITE").GetString() + ", " + properties.GetProperty("POSTINUMERO").GetString();
				}
			}
			else
			{
				GD.PrintErr("Invalid index or JSON structure.");
			}
		}
	}
}