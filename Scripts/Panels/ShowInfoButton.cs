using Godot;
using System;

namespace escapetampere
{
	public partial class ShowInfoButton : Button
	{

		[Export] private PackedScene schoolInfoScene = null;

		private SchoolInfo schoolInfo;

		public override void _Ready()
		{
			schoolInfoScene = (PackedScene)ResourceLoader.Load("res://Levels/Panels/InfoPanel.tscn");
			this.Pressed += OnShowInfoButtonPressed;
		}

		private void OnShowInfoButtonPressed()
		{
			int FistaIndex = 42;
			SchoolInfo infoInstance = (SchoolInfo)schoolInfoScene.Instantiate();
			GetTree().CurrentScene.AddChild(infoInstance);

			infoInstance.ShowSchoolInfo(FistaIndex);
		}
	}
}