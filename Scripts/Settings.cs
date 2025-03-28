using Godot;

namespace escapetampere
{
    public partial class Settings : Control
    {
        [Export] private Texture2D soundOnIcon;
        [Export] private Texture2D soundOnPressed;
        [Export] private Texture2D soundOffIcon;
        [Export] private Texture2D soundOffPressed;


        private Button soundOnButton;
        private Button soundOffButton;

        public override void _Ready()
        {
            soundOnButton = GetNode<Button>("Panel/CanvasLayer/SoundOnButton");
            soundOffButton = GetNode<Button>("Panel/CanvasLayer/SoundOffButton");

            soundOnButton.Pressed += OnSoundOnButtonPressed;
            soundOffButton.Pressed += OnSoundOffButtonPressed;

           UpdateButtonIcon(MusicManager.Instance.IsMusicPlaying());
        }

        private void OnSoundOnButtonPressed()
        {
            GD.Print("Musiikki päälle!");
            MusicManager.Instance.ToggleMusic(true);

            UpdateButtonIcon(true);
        }

        private void OnSoundOffButtonPressed()
        {
            GD.Print("Musiikki pois!");
            MusicManager.Instance.ToggleMusic(false);

            UpdateButtonIcon(false);
        }

        private void UpdateButtonIcon(bool isMusicOn)
        {
            if (isMusicOn)
            {
                soundOnButton.Icon = soundOnPressed;
                soundOffButton.Icon = soundOffIcon;

            } else {
                soundOnButton.Icon = soundOnIcon;
                soundOffButton.Icon = soundOffPressed;
            }
    }
    }
}
