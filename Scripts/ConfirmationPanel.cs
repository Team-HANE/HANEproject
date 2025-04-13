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

        }

		private void OnStayPressed()
		{
			QueueFree();
		}
	}
}
