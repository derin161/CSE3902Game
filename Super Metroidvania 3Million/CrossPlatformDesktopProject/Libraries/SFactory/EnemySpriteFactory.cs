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

		public ISprite GeegaSprite(Vector2 location)
        {
			return new GeegaSprite(geega, location);
		}

		public ISprite KraidSprite(Vector2 location, Game1 game)
		{
			return new KraidSprite(kraid, location, game);
		}

		public ISprite MemuSprite(Vector2 location)
		{
			return new MemuSprite(memu, location);
		}
		public ISprite SideHopperSprite(Vector2 location)
		{
			return new SideHopperSprite(sideHopper, location);
		}
		public ISprite SkreeSprite(Vector2 location)
		{
			return new SkreeSprite(skree, location);
		}
		public ISprite VerticalZeelaSprite(Vector2 location)
		{
			return new VerticalZeelaSprite(zeela, location);
		}
		public ISprite ZeelaSprite(Vector2 location)
		{
			return new ZeelaSprite(zeela, location);
		}
		public ISprite ReverseSideHopperSprite(Vector2 location)
		{
			return new ReverseSideHopperSprite(sideHopper, location);
		}
		public ISprite RipperSprite(Vector2 location)
		{
			return new RipperSprite(ripper, location);
		}
	}
}

