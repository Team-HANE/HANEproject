using Godot;
using System;

namespace escapetampere
{
	public partial class NextLevel : Node2D
	{
		[Export] private AudioStream _correctSound;
		private AudioStreamPlayer _player;

		public override void _Ready()
		{
			_player = new AudioStreamPlayer();
			AddChild(_player);

			if (_correctSound != null)
			{
				_player.Stream = _correctSound;
				_player.Play();
			}
		}
	}
}