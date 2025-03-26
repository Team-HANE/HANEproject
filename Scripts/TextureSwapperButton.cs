using Godot;
using System;

namespace escapetampere
{
	public partial class TextureSwapperButton : TextureButton
	{
		Texture2D _originalTexture;
		[Export] Texture2D _secondTexture;
		GameManager manager;

		//Animation
		[Export] private PackedScene _isCorrectScene = null;
		private GpuParticles2D _correct = null;
		[Export] private PackedScene _isWrongScene = null;
		private GpuParticles2D _wrong = null;

		public override void _Ready()
		{
			_originalTexture = TextureNormal;
			manager = GetNode<GameManager>("/root/GameManager");
		}

		public override void _Pressed()
		{
			if (TextureNormal == _originalTexture)
			{
				TextureNormal = _secondTexture;
				manager.RemoveMistake();
				IsCorrect();
			}
			else
			{
				manager.RemoveLife(1);
				//need to implement to the whole game-area
				IsWrong();
			}
		}


		//Animation
		public async void IsCorrect()
		{
			if (_correct == null && _isCorrectScene != null)
			{
				_correct = _isCorrectScene.Instantiate<GpuParticles2D>();
				AddChild(_correct);
			}

			_correct.Restart();
			_correct.OneShot = true;

			await ToSignal(_correct, "finished");
			manager.AnimationFinished();
		}

		public void IsWrong()
		{
			if (_wrong == null && _isWrongScene != null)
			{
				_wrong = _isWrongScene.Instantiate<GpuParticles2D>();
				AddChild(_wrong);
			}
			_wrong.Restart();
			_wrong.OneShot = true;
		}
	}
}