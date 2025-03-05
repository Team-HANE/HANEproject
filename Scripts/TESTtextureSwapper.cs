using Godot;
using System;

namespace escapetampere
{
	public partial class TESTtextureSwapper : TextureButton
	{
		Texture2D _originalTexture;
		[Export] Texture2D _secondTexture;
		GameManager manager;

		public override void _Ready()
		{
			_originalTexture = TextureNormal;
			manager = GetNode<GameManager>("/root/GameManager");
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
			manager.RemoveLife(1);
		}
	}
}
