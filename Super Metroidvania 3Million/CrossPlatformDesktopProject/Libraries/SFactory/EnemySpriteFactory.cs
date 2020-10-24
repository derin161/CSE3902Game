using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class EnemySpriteFactory
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

		public List<IGameObject> CreateEnemySpriteList(Vector2 location, Game1 game)
		{
			List<IGameObject> enemyList = new List<IGameObject>();
			enemyList.Add(new Zeela(location));
			enemyList.Add(new Skree(location));
			enemyList.Add(new SideHopper(location));
			enemyList.Add(new ReverseSideHopper(location));
			enemyList.Add(new Ripper(location));
			enemyList.Add(new Memu(location));
			enemyList.Add(new Geega(location));
			enemyList.Add(new VerticalZeela(location));
			enemyList.Add(new Kraid(location, game));

			return enemyList;
		}

		public ISprite GeegaSprite(Geega g)
        {
			return new GeegaSprite(geega, g);
		}

		public ISprite KraidSprite(Kraid k, Game1 game)
		{
			return new KraidSprite(kraid, k);
		}

		public ISprite MemuSprite(Memu m)
		{
			return new MemuSprite(memu, m);
		}
		public ISprite SideHopperSprite(SideHopper sh)
		{
			return new SideHopperSprite(sideHopper, sh);
		}
		public ISprite SkreeSprite(Skree s)
		{
			return new SkreeSprite(skree, s);
		}
		public ISprite VerticalZeelaSprite(VerticalZeela vz)
		{
			return new VerticalZeelaSprite(zeela, vz);
		}
		public ISprite ZeelaSprite(Zeela z)
		{
			return new ZeelaSprite(zeela, z);
		}
		public ISprite ReverseSideHopperSprite(ReverseSideHopper rsh)
		{
			return new ReverseSideHopperSprite(sideHopper, rsh);
		}
		public ISprite RipperSprite(Ripper r)
		{
			return new RipperSprite(ripper, r);
		}
	}
}

