using Godot;
using System;

namespace escapetampere
{
	public partial class DipControl : Control
	{
		[Export] private PackedScene dipScene = null;
		private AnimatedSprite2D dipAnim;
		private Texture

		public override void _Ready()
		{
			dipScene = (PackedScene)ResourceLoader.Load("res://Levels/Animation/DipScene.tscn");
		}

	}

}
