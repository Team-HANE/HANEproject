using Godot;
using System;


namespace escapetampere {

	public partial class TESTScoreUI : RichTextLabel
	{
		GameManager manager;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			manager = GetNode<GameManager>("/root/GameManager");
			manager.ScoreChange += ChangeScoreText;
		}

        public override void _ExitTree()
        {
            manager.ScoreChange -= ChangeScoreText;
        }

        public void ChangeScoreText(int score)
		{
			Text = $"Score: {score}";
		}
	}
}
