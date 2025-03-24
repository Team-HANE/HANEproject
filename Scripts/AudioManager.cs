using Godot;

public partial class AudioManager : Node
{
    private static AudioManager _instance;
    public static AudioManager Instance => _instance;

    private AudioStreamPlayer _audioPlayer;
    private bool _isSoundOn = true;

    public override void _Ready()
    {
        if (_instance == null)
        {
            _instance = this;
            _audioPlayer = new AudioStreamPlayer();
            AddChild(_audioPlayer);

            // Ladataan äänitiedosto
            _audioPlayer.Stream = GD.Load<AudioStream>("res://sounds/background_music.ogg");
            _audioPlayer.VolumeDb = -10; // Säädä voimakkuutta
            _audioPlayer.Play();

            // Jos ääni loppuu, käynnistä se uudelleen
            _audioPlayer.Finished += () => _audioPlayer.Play();

            GetTree().Root.CallDeferred("add_child", this);
        }
        else
        {
            QueueFree();
        }
    }

    public void ToggleSound(bool isOn)
    {
        _isSoundOn = isOn;
        _audioPlayer.VolumeDb = _isSoundOn ? -10 : -80; // -80dB mykistää äänen
    }

    public bool IsSoundOn()
    {
        return _isSoundOn;
    }
}
