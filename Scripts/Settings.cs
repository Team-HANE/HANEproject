using Godot;

namespace escapetampere
{
    public partial class Settings : Control
    {
        private AudioStreamPlayer _audioPlayer;
        private Button _soundOnButton;
        private Button _soundOffButton;
        private bool _isSoundOn = true;

        public override void _Ready()
        {
            // Hae AudioStreamPlayer ja Button-solmut
            _audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
            _soundOnButton = GetNode<Button>("SoundOnButton");
            _soundOffButton = GetNode<Button>("SoundOffButton");

            // Yhdistä signaalit nappeihin
            _soundOnButton.Pressed += OnSoundOnButtonPressed;
            _soundOffButton.Pressed += OnSoundOffButtonPressed;

            // Aseta napit näkyviksi tai piilota niitä äänen tilan mukaan
            UpdateButtonVisibility();
        }

        // SoundOnButtonin painallus
        private void OnSoundOnButtonPressed()
        {
            _isSoundOn = true;
            _audioPlayer.Play();
            UpdateButtonVisibility();
        }

        // SoundOffButtonin painallus
        private void OnSoundOffButtonPressed()
        {
            _isSoundOn = false;
            _audioPlayer.Stop();
            UpdateButtonVisibility();
        }

        // Päivitä nappien näkyvyys äänen tilan mukaan
        private void UpdateButtonVisibility()
        {
            _soundOnButton.Visible = !_isSoundOn;
            _soundOffButton.Visible = _isSoundOn;
        }
    }
}
