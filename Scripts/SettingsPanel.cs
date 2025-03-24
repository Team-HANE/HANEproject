using Godot;

public partial class SettingsPanel : Panel
{
    public override void _Ready()
    {
        // Hae napit Panelin alla olevalta CanvasLayer-solmulta
        Button soundOnButton = GetNode<Button>("CanvasLayer/SoundOnButton");
        Button soundOffButton = GetNode<Button>("CanvasLayer/SoundOffButton");

        // Liitä nappeihin signaalit koodissa
        soundOnButton.Pressed += OnSoundOnButtonPressed;
        soundOffButton.Pressed += OnSoundOffButtonPressed;
    }

    private void OnSoundOnButtonPressed()
    {
        GD.Print("Musiikki päälle!");
        MusicManager.Instance.ToggleMusic(true);
    }

    private void OnSoundOffButtonPressed()
    {
        GD.Print("Musiikki pois!");
        MusicManager.Instance.ToggleMusic(false);
    }
}
