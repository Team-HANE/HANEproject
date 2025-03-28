using Godot;
using System;

namespace escapetampere
{
	public partial class ConfirmationPanel : Control
	{
		[Export] private Button backToLevel;
		[Export] private Button goHome;

        public override void _Ready()
        {
            if (backToLevel != null)
			{
				backToLevel.Pressed += OnStayPressed;
			}
			if (goHome != null)
			{
				goHome.Pressed += OnHomePressed;
			}
        }

		private void OnStayPressed()
		{
			QueueFree();
		}
		private void OnHomePressed()
		{
			GetTree().ChangeSceneToFile("res://Levels/mainmenu.tscn");
		}
	}
}
