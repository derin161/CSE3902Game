using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.SpriteFactory
{
    class SpriteFactory
    {
		private Texture2D SpriteSheet;
		// More private Texture2Ds follow
		// ...

		private static SpriteFactory instance = new SpriteFactory();

		public static SpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private SpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			SpriteSheet = content.Load<Texture2D>("enemy");
			// More Content.Load calls follow
			//...
		}

		public ISprite CreatePlayerSprite()
		{
			//return new PlayerSprite(enemySpritesheet, 32, 32);
		}

		public ISprite CreateEnemySprite()
		{
			//return new EnemySprite(enemySpritesheet, 64, 64);
		}

		public ISprite CreateBlockSprite(ILevel level)
		{
			//return new EnemySprite(enemySpritesheet, level.ColorTheme);
		}

		public ISprite CreateItemSprite(ILevel level)
		{
			//return new EnemySprite(enemySpritesheet, level.ColorTheme);
		}

		public ISprite CreateProjectileSprite(ILevel level)
		{
			//return new EnemySprite(enemySpritesheet, level.ColorTheme);
		}

		// More public ISprite returning methods follow
		// ...
	}
}
