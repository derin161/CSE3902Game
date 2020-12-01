using CrossPlatformDesktopProject.Libraries.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    //Author: Nyigel Spann
    public class MenuSpriteFactory
    {
        public SpriteFont LargeDefaultFont { get; private set; }
        public SpriteFont LargeSelectedFont { get; private set; }
        public SpriteFont SmallDefaultFont { get; private set; }


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
            LargeDefaultFont = content.Load<SpriteFont>("Fonts/defaultMenuButtonFont");
            LargeSelectedFont = content.Load<SpriteFont>("Fonts/selectedMenuButtonFont");
            SmallDefaultFont = content.Load<SpriteFont>("Fonts/smallMenuButtonFont");

            //From: https://www.behance.net/gallery/9655183/Game-UI-Background-and-Menu
            inGameMenuBackgroundTexture = content.Load<Texture2D>("Misc/MenuBackgroundBordered");

            //From: http://sfwallpaper.com/categories/background-gaming.html
            simpleBackgroundTexture = content.Load<Texture2D>("Misc/SimpleBackground");
        }

        public ISprite CreateSimpleButtonSprite(IMenuButton menuButton, string buttonText)
        {
            return new SimpleButtonSprite(menuButton, buttonText, LargeDefaultFont, LargeSelectedFont);
        }

        public ISprite CreateLeftRightButtonSprite(LeftRightMenuButton lRMenuButton, string buttonText)
        {
            return new LeftRightButtonSprite(lRMenuButton, buttonText, SmallDefaultFont, SmallDefaultFont);
        }

        public ISprite CreateInGameMenuBackgroundSprite(Rectangle space)
        {
            return new MenuBackgroundSprite(inGameMenuBackgroundTexture, space);
        }

        public ISprite CreateSimpleBackgroundSprite(Rectangle space)
        {
            return new MenuBackgroundSprite(simpleBackgroundTexture, space);
        }


    }
}
