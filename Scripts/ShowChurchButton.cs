using Godot;
using System;


namespace escapetampere
{

	public partial class ShowChurchButton : Button
	{
		[Export] private PackedScene ChurchInfoScene = null;


		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			ChurchInfoScene = (PackedScene)ResourceLoader.Load("res://Levels/Panels/ChurchPanel.tscn");
			this.Pressed += OnShowChurchButton;
		}
		private void OnShowChurchButton()
		{
			int ChurchIndex = 38;
			ChurchInfo churchInstance = (ChurchInfo)ChurchInfoScene.Instantiate();
			GetTree().CurrentScene.AddChild(churchInstance);

			churchInstance.ShowChurchInfo(ChurchIndex);
		}
	}
}