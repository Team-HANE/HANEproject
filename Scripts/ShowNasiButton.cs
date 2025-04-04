using Godot;
using System;

namespace escapetampere
{

	public partial class ShowNasiButton : Button
	{
		[Export] private PackedScene NasiInfoScene = null;


		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			NasiInfoScene = (PackedScene)ResourceLoader.Load("res://Levels/Panels/NasiPanel.tscn");
			this.Pressed += OnShowNasiButton;
		}
		private void OnShowNasiButton()
		{
			NasiInfo nasiInstance = (NasiInfo)NasiInfoScene.Instantiate();
			GetTree().CurrentScene.AddChild(nasiInstance);

			nasiInstance.ShowNasiInfo(0);
		}
	}
}