using Godot;
using System;
using System.Threading;

namespace escapetampere
{
	public partial class GameManager : Node

	{
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
			// resetoidaan elämät
			SetLife(5);
			// lasketaan kentän virheet (optimointimahdollisuus)
			CountMistakes();
		}

		#endregion

		#region Mistake Management

		private int _mistakes;

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
			CheckVictory();
		}


		void CountMistakes()
		{
			_mistakes = GetTree().GetNodeCountInGroup("Mistakes");
		}

		private void CheckVictory()
		{
			if (_mistakes == 0)
			{
				LevelsCompleted++;

				ChangeScene("res://Levels/NextLevel.tscn");
			}
		}

		#endregion

		#region Level Progression

		int _levelsCompleted = 0;

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
			_levelsCompleted++;
		}

		#endregion

		#region Audio

		public enum SoundEffects
		{
			None = 0,
			Options,
			Music,
		}

		//[Export] private AudioStreamPlayer2D _optionSound = null;
		[Export] private AudioStreamPlayer2D _music = null;

		public void PlayAudio(SoundEffects soundType)
		{
			switch(soundType)
			{
				case SoundEffects.Music:
					if(_music != null)
					{
						_music.Play();
					}
					break;
				default:
				break;
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
