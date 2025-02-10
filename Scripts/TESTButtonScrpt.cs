using Godot;
using System;

public partial class TESTButtonScrpt : TextureButton
{
	[Export] Texture2D _initializedImage;
	RandomNumberGenerator rng = new RandomNumberGenerator();
	Sprite2D image;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

    public override void _Pressed()
    {
        image = new Sprite2D();
		AddChild(image);
		image.Position = new Vector2(rng.RandfRange(-500, 500), rng.RandfRange(-500, 500));
		float scale = rng.RandfRange(0.5f, 1.5f);
		image.Scale = new Vector2(scale, scale);
		image.Texture = _initializedImage;
    }
}
