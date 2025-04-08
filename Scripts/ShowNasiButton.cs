using Godot;
using System;

namespace escapetampere
{

	public partial class ShowNasiButton : Button
	{
		[Export] private PackedScene NasiInfoScene = null;

		public override void _Ready()
		{
			NasiInfoScene = (PackedScene)ResourceLoader.Load("res://Levels/Panels/NasiPanel.tscn");
			this.Pressed += OnShowNasiButton;
		}
		private void OnShowNasiButton()
		{
			int NasiIndex = 0;
			NasiInfo nasiInstance = (NasiInfo)NasiInfoScene.Instantiate();
			GetTree().CurrentScene.AddChild(nasiInstance);

			nasiInstance.ShowNasiInfo(NasiIndex);
		}
	}
}