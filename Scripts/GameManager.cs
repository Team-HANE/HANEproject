using Godot;
using System;

namespace escapetampere
{
	public partial class GameManager : Node
	{
		#region Player Score Management
		private int _score = 5;

		public int Score
		{
			get
			{
				return _score;
			}

			// readonly
		}

		// Event UI:lle että score vaihtuu
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
			// poistetaan vanha skene
			foreach (Node child in GetChildren())
			{
				child.QueueFree();
			}
			// ladataan uusi skene
			PackedScene scene = ResourceLoader.Load<PackedScene>(newScenePath);
			if (scene == null)
			{
				GD.PrintErr("Cannot find scene! Make sure the path is correct.");
				return;
			}
			// luodaan uusi skene maailmaan ja asetetaan managerin lapseksi
			Node instance = scene.Instantiate();
			AddChild(instance);
			// resetoidaan skore (elämät)
			SetScore(5);
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
