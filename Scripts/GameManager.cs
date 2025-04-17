using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace escapetampere
{
	public partial class GameManager : Node

	{
		private int _correctAnimation = 0;
		private bool _waitForPaint = false;
		#region Player Life Management
		private int _life = 5;

		public int Life
		{
			get
			{
				return _life;
			}

			// readonly
		}

		// Event UI:lle että elämät vaihtuu
		[Signal] public delegate void LifeChangeEventHandler(int life);

		public void AddLife(int amount)
		{
			if (amount > 0)
			{
				_life += amount;
				EmitSignal(SignalName.LifeChange, Life);
			}
		}

		public void RemoveLife(int amount)
		{
			if (amount > 0)
			{
				_life -= amount;
				EmitSignal(SignalName.LifeChange, Life);
			}
			if (Life == 0)
			{
				GameOver();
			}
		}

		public void SetLife(int amount)
		{
			if (amount >= 0)
			{
				_life = amount;
				EmitSignal(SignalName.LifeChange, Life);
			}
		}

		private void GameOver()
		{
			ChangeScene("res://Levels/GameOver.tscn");
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
			// tallennetaan skenen path progressiota varten
			_currentLevelPath = newScenePath;
			// resetoidaan elämät
			SetLife(5);
			// resetoidaan virhelaskuri (ei oo nätisti metodi get over it)
			CurrentMistake = 0;
			// lasketaan kentän virheet (optimointimahdollisuus)
			CountMistakes();
		}

		#endregion

		#region Mistake Management

		private int _mistakes;

		public int CurrentMistake = 0;

		public int Mistakes
		{
			get
			{
				return _mistakes;
			}

			//readonly
		}

		public void RemoveMistake()
		{
			_mistakes--;
			_correctAnimation++;
			CheckVictory();
		}


		void CountMistakes()
		{
			_mistakes = GetTree().GetNodeCountInGroup("Mistakes");
		}
		#endregion

		private void CheckVictory()
		{

			if (_mistakes == 0 && _correctAnimation == 0)
			{
				if (_waitForPaint)
				{
					return;
				}
				CompleteLevel();
				ChangeScene("res://Levels/NextLevel.tscn");
			}
		}

		public void AnimationFinished()
		{
			_correctAnimation--;
			CheckVictory();
		}
		public void SetWaitingForPaint(bool value)
		{
			_waitForPaint = value;
		}

		public void OnPaintFinished()
		{
			_waitForPaint = false;
			CompleteLevel();
			ChangeScene("res://Levels/NextLevel.tscn");
		}

		#region Level Progression

		int _levelsCompleted = 0;
		string _currentLevelPath;
		public List<string> _completedLevelPaths = new List<string>();
		[Export] public CompressedTexture2D CompletedLevelFlag;
		[Export] public CompressedTexture2D YouAreHereFlag;
		public int LevelsCompleted
		{
			get
			{
				return _levelsCompleted;
			}
			set
			{
				_levelsCompleted = value;
			}
		}

		public void CompleteLevel()
		{
			if (!_completedLevelPaths.Contains(_currentLevelPath))
			{
				_completedLevelPaths.Add(_currentLevelPath);
				_levelsCompleted++;
			}
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