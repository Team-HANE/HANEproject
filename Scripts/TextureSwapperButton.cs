using Godot;
using System;

namespace escapetampere
{
	public partial class TextureSwapperButton : TextureButton
	{
		Texture2D _originalTexture;
		[Export] Texture2D _secondTexture;
		GameManager manager;
		[Export] bool OrderMatters = false;
		[Export] int OrderNumber = 0;

		//Animation
		[Export] private PackedScene _isCorrectScene = null;
		private GpuParticles2D _correct = null;
		[Export] private PackedScene _isWrongScene = null;
		private GpuParticles2D _wrong = null;

		//Audio
		[Export] private AudioStream _correctSound;
		[Export] private AudioStream _wrongSound;
		private AudioStreamPlayer _audioPlayer;

		[Signal]
		public delegate void CorrectPressedEventHandler();
		public override void _Ready()
		{
			_originalTexture = TextureNormal;
			manager = GetNode<GameManager>("/root/GameManager");

			_audioPlayer = new AudioStreamPlayer();
			AddChild(_audioPlayer);
		}

		public override void _Pressed()
		{
			// Check for ordering and then whether the sprite has been swapped already or not
			// Could be made more readable and modular but I can't be arsed
			if ((TextureNormal == _originalTexture) && OrderMatters)
			{
				if (OrderNumber == manager.CurrentMistake)
				{
					TextureNormal = _secondTexture;
					manager.CurrentMistake = OrderNumber + 1;
					manager.RemoveMistake();
					IsCorrect();
				}
				else
				{
					manager.RemoveLife(1);
					IsWrong();
				}
			}
			else if ((TextureNormal == _originalTexture) && !OrderMatters)
			{
				TextureNormal = _secondTexture;
				manager.RemoveMistake();
				IsCorrect();
			}
			else
			{
				manager.RemoveLife(1);
				IsWrong();
			}
		}


		//Animation
		public async void IsCorrect()
		{
			EmitSignal("CorrectPressed");
			if (_correct == null && _isCorrectScene != null)
			{
				_correct = _isCorrectScene.Instantiate<GpuParticles2D>();
				AddChild(_correct);
			}
			_correct.Position = GetLocalMousePosition();
			_correct.Restart();
			_correct.OneShot = true;


			if (_correctSound != null)
			{
				_audioPlayer.Stream = _correctSound;
				_audioPlayer.Play();
			}

			await ToSignal(_correct, "finished");
			//Wait for animation and audio to finish, show the correct scene for a second
			double time = 0.5f;
			await ToSignal(GetTree().CreateTimer(time), "timeout");
			manager.AnimationFinished();
		}

		public void IsWrong()
		{
			if (_wrong == null && _isWrongScene != null)
			{
				_wrong = _isWrongScene.Instantiate<GpuParticles2D>();
				AddChild(_wrong);
			}
			_wrong.Position = GetLocalMousePosition();
			_wrong.Restart();
			_wrong.OneShot = true;

			if (_wrongSound != null)
			{
				_audioPlayer.Stream = _wrongSound;
				_audioPlayer.Play();
			}
		}
	}
}