using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class EnemySpriteFactory : IFactory
    {
		//Enemies
		private Texture2D geega;
		private Texture2D kraid;
		private Texture2D memu;
		private Texture2D ripper;
		private Texture2D sideHopper;
		private Texture2D skree;
		private Texture2D zeela;

		private static EnemySpriteFactory instance = new EnemySpriteFactory();
		public static EnemySpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private EnemySpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			//Enemies
			geega = content.Load<Texture2D>("enemies/geega");
			kraid = content.Load<Texture2D>("enemies/Kraid");
			memu = content.Load<Texture2D>("enemies/Memu");
			ripper = content.Load<Texture2D>("enemies/Ripper");
			sideHopper = content.Load<Texture2D>("enemies/SideHopper");
			skree = content.Load<Texture2D>("enemies/Skree");
			zeela = content.Load<Texture2D>("enemies/Zeela");
		}

		public List<ISprite> CreateEnemySpriteList(Vector2 location, Game1 game)
		{
			List<ISprite> enemyList = new List<ISprite>();
			enemyList.Add(new Zeela(zeela, location));
			enemyList.Add(new Skree(skree, location));
			enemyList.Add(new SideHopper(sideHopper, location));
			enemyList.Add(new ReverseSideHopper(sideHopper, location));
			enemyList.Add(new Ripper(ripper, location));
			enemyList.Add(new Memu(memu, location));
			enemyList.Add(new Geega(geega, location));
			enemyList.Add(new VerticalZeela(zeela, location));
			enemyList.Add(new Kraid(kraid, location, game));

			return enemyList;
		}
	}
}
