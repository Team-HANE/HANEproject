using Godot;
using System;

namespace escapetampere
{

	public partial class ShowLibraryInfo : Button
	{
		[Export] private PackedScene libraryInfoScene = null;


		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			libraryInfoScene = (PackedScene)ResourceLoader.Load("res://Levels/Panels/LibraryPanel.tscn");
			this.Pressed += OnShowLibraryButton;
		}
		private void OnShowLibraryButton()
		{
			LibraryInfo libraryInstance = (LibraryInfo)libraryInfoScene.Instantiate();
			GetTree().CurrentScene.AddChild(libraryInstance);

			libraryInstance.ShowLibraryInfo(34);
		}
	}
}