using Godot;
using System;

namespace escapetampere
{
	public partial class BackButton : TextureButton
	{
		[Export] private PackedScene confirmationScene = null;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			confirmationScene = (PackedScene)ResourceLoader.Load("res://Levels/Panels/ConfirmationPanel.tscn");
			this.Pressed += OnBackButtonPressed;
		}

		private void OnBackButtonPressed()
		{
			if (confirmationScene != null)
			{
				ConfirmationPanel confirmationInstance = (ConfirmationPanel)confirmationScene.Instantiate();
				GetTree().CurrentScene.AddChild(confirmationInstance);
			}

		}
	}
}