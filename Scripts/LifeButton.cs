using Godot;
using System;

namespace escapetampere
{
	public partial class LifeButton : TextureButton
	{
		GameManager manager;

		public override void _Ready()
		{
			manager = GetNode<GameManager>("/root/GameManager");
		}

		public override void _Pressed()
		{
			manager.RemoveLife(1);
		}
	}
}
