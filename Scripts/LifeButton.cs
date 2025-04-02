using Godot;
using System;

namespace escapetampere
{
	public partial class LifeButton : TextureButton
	{
		GameManager manager;
		[Export] PackedScene _isWrongScene;
		GpuParticles2D _wrong;

		public override void _Ready()
		{
			manager = GetNode<GameManager>("/root/GameManager");
		}

		public override void _Pressed()
		{
			manager.RemoveLife(1);
			IsWrong();
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
		}
	}
}
