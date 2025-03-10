using Godot;
using System;

namespace escapetampere
{
	public partial class GameManager : Node
	{
		private PackedScene _settingsScene = null;
		private Control _settings;

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
		}

		public void SetLife(int amount)
		{
			if (amount >= 0)
			{
				_life = amount;
				EmitSignal(SignalName.LifeChange, Life);
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
			// resetoidaan elämät
			SetLife(5);
		}

		#endregion

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_settingsScene = (PackedScene)ResourceLoader.Load("res://Levels/Settings.tscn");
			_settings = (Control)_settingsScene.Instantiate();
			AddChild(_settings);
			_settings.Visible = false;

		}

		private void OnSettingsButtonPressed()
		{
			_settings.Visible = true;
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

	}
}
