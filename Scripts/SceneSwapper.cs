using Godot;
using System;

namespace escapetampere
{
	public partial class SceneSwapper : Button
	{
		[Export] string _sceneToLoadPath;
		GameManager manager;
		[Export] int levelNumber = 0;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			manager = GetNode<GameManager>("/root/GameManager");
			// voi valita vain oikean kentän
			if (manager.LevelsCompleted < levelNumber)
			{
				Disabled = true;
			}
		}

        public override void _Pressed()
        {
			manager.ChangeScene(_sceneToLoadPath);
        }
    }
}
