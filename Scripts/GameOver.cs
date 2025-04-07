using Godot;
using System;

namespace escapetampere
{
	public partial class GameOver : Node2D
	{
		[Export] private AudioStream _wrongSound;
		private AudioStreamPlayer _player;

		public override void _Ready()
		{
			_player = new AudioStreamPlayer();
			AddChild(_player);

			if (_wrongSound != null)
			{
				_player.Stream = _wrongSound;
				_player.Play();
			}
		}
	}
}