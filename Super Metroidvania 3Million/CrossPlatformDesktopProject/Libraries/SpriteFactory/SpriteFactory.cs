using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
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

		//enemies
		private Texture2D geega;
		private Texture2D kraid;
		private Texture2D memu;
		private Texture2D ripper;
		private Texture2D sideHopper;
		private Texture2D skree;
		private Texture2D zeela;

		//Projectiles
		private Texture2D bombTex;
		private Texture2D kraidHornTex;
		private Texture2D kraidMissileTex;
		private Texture2D missileRocketTex;
		private Texture2D powerBeamTex;
		private Texture2D waveBeamTex;
		private Texture2D iceBeamTex;


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

			//enemies
			geega = content.Load<Texture2D>("enemies/geega");
			kraid = content.Load<Texture2D>("enemies/Kraid");
			memu = content.Load<Texture2D>("enemies/Memu");
			ripper = content.Load<Texture2D>("enemies/Ripper");
			sideHopper = content.Load<Texture2D>("enemies/SideHopper");
			skree = content.Load<Texture2D>("enemies/Skree");
			zeela = content.Load<Texture2D>("enemies/Zeela");

			//Projectiles
			bombTex = content.Load<Texture2D>("ProjSprites/BombProj");
			kraidHornTex = content.Load<Texture2D>("ProjSprites/KraidHorn");
			kraidMissileTex = content.Load<Texture2D>("ProjSprites/KraidMissile");
			missileRocketTex = content.Load<Texture2D>("ProjSprites/MissileRocketProj");
			powerBeamTex = content.Load<Texture2D>("ProjSprites/PowerBeamProj");
			waveBeamTex = content.Load<Texture2D>("ProjSprites/WaveBeamProj");
			iceBeamTex = content.Load<Texture2D>("ProjSprites/IceBeamProj");

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

		public ISprite CreateBomb()
		{

			return new Bomb(bombTex, new Vector2(200, 200));
		}

		public ISprite CreateMissileRocket(Vector2 location)
		{

			return new Bomb(bombTex, location);
		}

		public ISprite CreatePowerBeam(Vector2 location, Vector2 direction, bool isLongBeam)
		{
			return new PowerBeam(powerBeamTex, location, direction, isLongBeam, false);
		}

		public ISprite CreateIceBeam(Vector2 location, Vector2 direction, bool isLongBeam)
		{
			return new PowerBeam(iceBeamTex, location, direction, isLongBeam, true);
		}

		public ISprite CreateWaveBeam(Vector2 location, Vector2 direction, bool isLongBeam, bool isIceBeam)
		{
			return new WaveBeam(waveBeamTex, location, direction, isLongBeam, isIceBeam);
		}

		public ISprite CreateKraidHorn(Vector2 location, bool isMovingRight)
		{
			return new KraidHorn(kraidHornTex, location, isMovingRight);
		}

		public ISprite CreateKraidMissile(Vector2 location, Vector2 direction)
		{
			return new KraidMissile(kraidMissileTex, location, direction);
		}

		// More public ISprite returning methods follow
		// ...
	}
}
