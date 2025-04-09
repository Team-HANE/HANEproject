using Godot;
using System;
using System.Text.Json;

namespace escapetampere
{
	public partial class NasiInfo : Control
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
			schoolNameLabel = GetNode<Label>("Node2D/NasiPanel/VBoxContainer/SchoolNameLabel");
			schoolAddressLabel = GetNode<Label>("Node2D/NasiPanel/VBoxContainer/SchoolAddressLabel");
			WhatIsIt = GetNode<Label>("Node2D/NasiPanel/VBoxContainer/Label");
			NameLabel = GetNode<Label>("Node2D/NasiPanel/VBoxContainer/NameLabel");
			schoolInfoLabel = GetNode<Label>("Node2D/NasiPanel/VBoxContainer/SchoolInfoLabel");
			addressLabel = GetNode<Label>("Node2D/NasiPanel/VBoxContainer/AddressLabel");

			jsonData = JsonDataLoader.Load("res://koulut.json") ?? default;
		}

		public void ShowNasiInfo(int index)
		{
			WhatIsIt.Text = Tr("WHAT");
			NameLabel.Text = Tr("NASI");
			addressLabel.Text = Tr("ADDRESS") + "Näsijärvenkatu 5";
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