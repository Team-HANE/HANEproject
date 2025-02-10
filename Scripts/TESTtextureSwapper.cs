using Godot;
using System;

public partial class TESTtextureSwapper : TextureButton
{
	Texture2D _originalTexture;
	[Export] Texture2D _secondTexture;

    public override void _Ready()
    {
        _originalTexture = TextureNormal;
    }
    public override void _Pressed()
    {
		if (TextureNormal == _originalTexture)
		{
			TextureNormal = _secondTexture;
		}
        else
		{
			TextureNormal = _originalTexture;
		}
    }
}
