using Godot;
using System;

namespace escapetampere
{


	public partial class ShowToriButton : Button
	{
		[Export] private PackedScene ToriInfoScene = null;
		public override void _Ready()
		{
			ToriInfoScene = (PackedScene)ResourceLoader.Load("res://Levels/Panels/ToriPanel.tscn");
			this.Pressed += OnShowToriButton;
		}

		private void OnShowToriButton()
		{
			int ToriIndex = 55;
			ToriInfo toriInstance = (ToriInfo)ToriInfoScene.Instantiate();
			GetTree().CurrentScene.AddChild(toriInstance);

			toriInstance.ShowToriInfo(ToriIndex);
		}
	}
}