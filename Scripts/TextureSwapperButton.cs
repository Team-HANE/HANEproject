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
			}
			else
			{
				manager.RemoveLife(1);
			}
		}

		//Animation
		public void IsCorrect ()
		{
			if (IsCorrect == null && _isCorrectScene != null)
			{
				_correct = _isCorrectScene.Instantiate<GpuParticles2D>();
				AddChild(_correct);
			}

			_correct.Restart();
			_correct.OneShot = true;
		}
	}
}
