using Godot;
using System;

namespace escapetampere
{
	public partial class SceneSwapper : Button
	{
		[Export] string _sceneToLoadPath;
		GameManager manager;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			manager = GetNode<GameManager>("/root/GameManager");
		}

        public override void _Pressed()
        {
			manager.ChangeScene(_sceneToLoadPath);
        }
    }
}
