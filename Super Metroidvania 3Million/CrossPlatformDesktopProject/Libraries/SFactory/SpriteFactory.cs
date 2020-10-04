using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
	public class SpriteFactory : IFactory
	{
		//Enemies
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

        //Player
        private List<Texture2D> playerTextures = new List<Texture2D>();
        private Texture2D rightIdle;
        private Texture2D leftIdle;
        private Texture2D rightWalk;
        private Texture2D leftWalk;
        private Texture2D rightCrouch;
        private Texture2D leftCrouch;
        private Texture2D jump;

		//Fonts
		private List<SpriteFont> playerFonts = new List<SpriteFont>();
		private SpriteFont healthFont;

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
			//Enemies
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

            //Player 
            rightIdle = content.Load<Texture2D>("PlayerSprites/SamusRightIdle");
            playerTextures.Add(rightIdle);
            leftIdle = content.Load<Texture2D>("PlayerSprites/SamusLeftIdle");
            playerTextures.Add(leftIdle);
            rightWalk = content.Load<Texture2D>("PlayerSprites/SamusRightWalk");
            playerTextures.Add(rightWalk);
            leftWalk = content.Load<Texture2D>("PlayerSprites/SamusLeftWalk");
            playerTextures.Add(leftWalk);
            rightCrouch = content.Load<Texture2D>("PlayerSprites/RightMorph");
            playerTextures.Add(rightCrouch);
            leftCrouch = content.Load<Texture2D>("PlayerSprites/LeftMorph");
            playerTextures.Add(leftCrouch);
            jump = content.Load<Texture2D>("PlayerSprites/Jump");
            playerTextures.Add(jump);

			//Fonts
			healthFont = content.Load<SpriteFont>("PlayerHealth");
			playerFonts.Add(healthFont);

			// More Content.Load calls follow
			//...
		}

		public ISprite CreatePlayerSprite()
		{
			return (ISprite) new PlayerSprite(playerTextures, playerFonts);
		}

		public List<ISprite> CreateEnemySpriteList(Vector2 location)
		{
			List<ISprite> enemyList = new List<ISprite>();
			enemyList.Add(new Zeela(zeela, location));
			enemyList.Add(new Skree(skree, location));
			enemyList.Add(new SideHopper(sideHopper, location));
			enemyList.Add(new Ripper(ripper, location));
			enemyList.Add(new Memu(memu, location));
			enemyList.Add(new Geega(geega, location));
			enemyList.Add(new Kraid(kraid, location));

			return enemyList;
		}

		/*public ISprite CreateBlockSprite(ILevel level)
		{
			//return new EnemySprite(enemySpritesheet, level.ColorTheme);
		}

		public ISprite CreateItemSprite(ILevel level)
		{
			//return new EnemySprite(enemySpritesheet, level.ColorTheme);
		}*/

		public ISprite CreateBomb(Vector2 location)
		{

			return new Bomb(bombTex, location);
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
