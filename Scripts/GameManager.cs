using Godot;
using System;

namespace escapetampere
{
	public partial class GameManager : Node
	{
		#region Player Score Management
		private int _score = 3;

		public int Score
		{
			get
			{
				return _score;
			}

			// readonly
		}

		// Score event for UI
		[Signal] public delegate void ScoreChangeEventHandler(int score);

		public void AddScore(int amount)
		{
			if (amount > 0)
			{
				_score += amount;
				EmitSignal(SignalName.ScoreChange, Score);
			}
		}

		public void RemoveScore(int amount)
		{
			if (amount > 0)
			{
				_score -= amount;
				EmitSignal(SignalName.ScoreChange, Score);
			}
		}

		public void SetScore(int amount)
		{
			if (amount >= 0)
			{
				_score = amount;
				EmitSignal(SignalName.ScoreChange, Score);
			}
		}

		#endregion

		#region Scene Management

		public void ChangeScene(String newScenePath)
		{
			foreach (Node child in GetChildren())
			{
				child.QueueFree();
			}
			PackedScene scene = ResourceLoader.Load<PackedScene>(newScenePath);
			if (scene == null)
			{
				GD.PrintErr("Cannot find scene! Make sure the path is correct.");
				return;
			}
			Node instance = scene.Instantiate();
			AddChild(instance);
			EmitSignal(SignalName.ScoreChange, Score);
		}

		#endregion

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

	}
}
