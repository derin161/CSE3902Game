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
		private Texture2D simpleBackgroundTexture;

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

			//From: https://www.behance.net/gallery/9655183/Game-UI-Background-and-Menu
			inGameMenuBackgroundTexture = content.Load<Texture2D>("Misc/MenuBackgroundBordered");

			//From: http://sfwallpaper.com/categories/background-gaming.html
			simpleBackgroundTexture = content.Load<Texture2D>("Misc/SimpleBackground");
		}

		public ISprite CreateSimpleButtonSprite(IMenuButton menuButton, string buttonText) {
			return new SimpleButtonSprite(menuButton, buttonText, defaultFont, selectedFont);
		}

		public ISprite CreateInGameMenuBackgroundSprite(Rectangle space) {
			return new MenuBackgroundSprite(inGameMenuBackgroundTexture, space);
		}

		public ISprite CreateSimpleBackgroundSprite(Rectangle space)
		{
			return new MenuBackgroundSprite(simpleBackgroundTexture, space);
		}

	}
}
