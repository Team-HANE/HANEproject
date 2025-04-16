using Godot;
using System;

namespace escapetampere
{
	public partial class AnimationControl : Control
	{
		[Export] private PackedScene digScene = null;
		private TextureSwapperButton pile;
		private AnimatedSprite2D animation;
		private bool isDig = false;
		public override void _Ready()
		{
			digScene = (PackedScene)ResourceLoader.Load("res://Levels/Animation/DigScene.tscn");

			pile = GetNode<TextureSwapperButton>("Maa2");
			pile.Connect("CorrectPressed", new Callable(this, nameof(OnCorrect)));

		}

		private void PlayDigAnimation()
		{
			Node2D digInstance = digScene.Instantiate<Node2D>();
			AddChild(digInstance);

			animation = digInstance.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			animation.Play("dig");
		}
		private void OnCorrect()
		{
			if (!isDig)
			{
				PlayDigAnimation();
				isDig = true;
			}
		}
	}
}