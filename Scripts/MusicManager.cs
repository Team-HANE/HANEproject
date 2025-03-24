using Godot;

public partial class MusicManager : Node
{
    public static MusicManager Instance { get; private set; }
    private AudioStreamPlayer _musicPlayer;

    public override void _Ready()
{
    if (Instance != null && Instance != this)
    {
        QueueFree();
        return;
    }

    Instance = this;
    _musicPlayer = new AudioStreamPlayer();
    AddChild(_musicPlayer);

    _musicPlayer.Stream = ResourceLoader.Load<AudioStream>("res://Audio/gamemusic.mp3");
    _musicPlayer.Autoplay = true; // Lisää tämä rivi
    _musicPlayer.Play();
    _musicPlayer.Bus = "Music";
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
