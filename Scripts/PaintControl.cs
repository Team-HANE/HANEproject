using Godot;
using System;

namespace escapetampere
{
	public partial class PaintControl : Control
	{
		[Export] private PackedScene paintScene = null;
		private AnimatedSprite2D paintAnim;
		private TextureSwapperButton crossing;
		private bool isPaint = false;
		private GameManager manager;

		public override void _Ready()
		{
			paintScene = (PackedScene)ResourceLoader.Load("res://Levels/Animation/PaintScene.tscn");
			crossing = GetNode<TextureSwapperButton>("Vaarasuoja");
			crossing.Connect("CorrectPressed", new Callable(this, nameof(OnCorrect)));

			manager = GetNode<GameManager>("/root/GameManager");
			Connect(nameof(PaintFinished), new Callable(manager, nameof(GameManager.OnPaintFinished)));

			manager.SetWaitingForPaint(true);
		}

		[Signal] public delegate void PaintFinishedEventHandler();
		private async void PlayPaintAnimation()
		{
			Node2D paintInstance = paintScene.Instantiate<Node2D>();
			AddChild(paintInstance);

			paintAnim = paintInstance.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			paintInstance.GlobalPosition = crossing.GlobalPosition;


			paintAnim.Play("paint");


			await ToSignal (paintAnim, "animation_finished");
			 EmitSignal(nameof(PaintFinished));
		}
		private void OnCorrect()
		{
			if (!isPaint)
			{
				PlayPaintAnimation();
				isPaint = true;
			}
		}

	}
}
