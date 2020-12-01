using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.Libraries.Sprite.Map;
namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class MapSpriteFactory
    {
        //Map
        private Texture2D map;

        private static MapSpriteFactory instance = new MapSpriteFactory();
        public static MapSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MapSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //Map
            map = content.Load<Texture2D>("ProjSprites/Map");
        }

        public ISprite CreateMapSprite()
        {
            return new MapSprite(map);
        }
    }
}
