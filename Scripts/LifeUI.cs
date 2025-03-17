using Godot;
using System;


namespace escapetampere {

	public partial class LifeUI : Sprite2D
	{
		GameManager manager;
		[Export] Texture2D lives4;
		[Export] Texture2D lives3;
		[Export] Texture2D lives2;
		[Export] Texture2D lives1;
		[Export] Texture2D lives0;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			manager = GetNode<GameManager>("/root/GameManager");
			manager.LifeChange += ChangeLives;
		}

        public override void _ExitTree()
        {
            manager.LifeChange -= ChangeLives;
        }

        public void ChangeLives(int lives)
		{
			if (lives == 4)
			{
				Texture = lives4;
			}
			if (lives == 3)
			{
				Texture = lives3;
			}
			if (lives == 2)
			{
				Texture = lives2;
			}
			if (lives == 1)
			{
				Texture = lives1;
			}
			if (lives == 0)
			{
				Texture = lives0;
			}
		}
	}
}
