using CrossPlatformDesktopProject.Libraries.GameStates;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
	//Author: Nyigel Spann
    public class MenuSpriteFactory
    {
		//Projectiles
		private SpriteFont defaultFont;
		private SpriteFont selectedFont;
		private Texture2D inGameMenuBackgroundTexture;

		private static MenuSpriteFactory instance = new MenuSpriteFactory();
		public static MenuSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private MenuSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			//Projectiles
			defaultFont = content.Load<SpriteFont>("Fonts/defaultMenuButtonFont");
			selectedFont = content.Load<SpriteFont>("Fonts/selectedMenuButtonFont");
			inGameMenuBackgroundTexture = content.Load<Texture2D>("Misc/MenuBackgroundCropped");
		}

		public ISprite CreateSimpleButtonSprite(IMenuButton menuButton, string buttonText) {
			return new SimpleButtonSprite(menuButton, buttonText, defaultFont, selectedFont);
		}

		public ISprite CreateInGameMenuBackground(Rectangle space) {
			return new MenuBackgroundSprite(inGameMenuBackgroundTexture, space);
		}

	}
}
