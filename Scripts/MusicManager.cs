using Godot;

public partial class MusicManager : Node
{
    private static MusicManager _instance;
    private AudioStreamPlayer _musicPlayer;

    public override void _Ready()
    {
        if (_instance != null)
        {
            QueueFree();
            return;
        }

        _instance = this;
        _musicPlayer = new AudioStreamPlayer();
        AddChild(_musicPlayer);

        // Lataa MP3-tiedosto
        _musicPlayer.Stream = ResourceLoader.Load<AudioStream>("res://Audio/gamemusic.mp3");
        _musicPlayer.Play();
        _musicPlayer.Bus = "Music";

        // Lisää MusicManager juuritasolle
        GetTree().Root.AddChild(this);
    }

    public void ToggleMusic(bool play)
    {
        if (play)
        {
            _musicPlayer.Play();
        }
        else
        {
            _musicPlayer.Stop();
        }
    }
}
