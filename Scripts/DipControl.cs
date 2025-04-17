using Godot;
using System;

namespace escapetampere
{
	public partial class DipControl : Control
	{
		[Export] private PackedScene dipScene = null;
		private AnimatedSprite2D dipAnim;
		private TextureSwapperButton bucket;
		private bool isDip = false;

		public override void _Ready()
		{
			dipScene = (PackedScene)ResourceLoader.Load("res://Levels/Animation/DipScene.tscn");
			bucket = GetNode<TextureSwapperButton>("Ampari");
			bucket.Connect("CorrectPressed", new Callable(this, nameof(OnCorrect)));
		}

		private void PlayDipAnimation()
		{
			Node2D digInstance = dipScene.Instantiate<Node2D>();
			AddChild(digInstance);

			dipAnim = digInstance.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			dipAnim.Play("dip");
		}
		private void OnCorrect()
		{
			if (!isDip)
			{
				PlayDipAnimation();
				isDip = true;
			}
		}

	}
}
