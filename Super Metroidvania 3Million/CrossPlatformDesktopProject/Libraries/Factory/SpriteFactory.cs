using CrossPlatformDesktopProject.Libraries.Sprite.Map;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Sprite.Player_Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Factory
{
    public class SpriteFactory : IFactory
    {
		private Texture2D SpriteSheet;
		private Texture2D Map;
		private Texture2D[] Enemies;

		private static SpriteFactory instance = new SpriteFactory();

		public static SpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		public SpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			//SpriteSheet = content.Load<Texture2D>("enemy");
			Map = content.Load<Texture2D>("ProjSprites/Map");
			// More Content.Load calls follow
			//...
		}

		public ISprite CreatePlayerSprite()
		{
			return new PlayerSprite(SpriteSheet);
		}

		public ISprite CreateEnemySprite()
		{
			return new EnemySprite(Enemies);
		}

		//public ISprite CreateBlockSprite(ILevel level)
		//{
			//return new EnemySprite(enemySpritesheet, level.ColorTheme);
		//}

		//public ISprite CreateItemSprite(ILevel level)
		//{
			//return new EnemySprite(enemySpritesheet, level.ColorTheme);
		//}

		public ISprite CreatePowerBeamSprite()
		{
			return new PowerBeam(SpriteSheet);
		}

		public ISprite CreateMapSprite()
        {
			return new MapSprite(Map);
        }

    }
}
