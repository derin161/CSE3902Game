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
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Map;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;

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

		private Texture2D damaged_rightIdle;
		private Texture2D damaged_leftIdle;
		private Texture2D healthBar;
		//Fonts
		private List<SpriteFont> playerFonts = new List<SpriteFont>();
		private SpriteFont healthFont;

		//Items
		private Texture2D bombItem;
		private Texture2D energyDropItem;
		private Texture2D energyTankItem;
		private Texture2D highJumpItem;
		private Texture2D iceBeamItem;
		private Texture2D longBeamItem;
		private Texture2D missleRocketItem;
		private Texture2D morphBallItem;
		private Texture2D rocketDropItem;
		private Texture2D screwAttackItem;
		private Texture2D variaItem;
		private Texture2D waveBeamItem;

		//Map
		private Texture2D map;

		//Blocks
		private Texture2D stockBlockBlue;
		private Texture2D bushBlockBlue;
		private Texture2D tubeBlockBlue;
		private Texture2D swirlBlockBlue;
		private Texture2D stockBlockOrange;
		private Texture2D bushBlockOrange;
		private Texture2D tubeBlockOrange;
		private Texture2D swirlBlockOrange;


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

			damaged_rightIdle = content.Load<Texture2D>("PlayerSprites/SamusRightIdleDamaged");
			playerTextures.Add(damaged_rightIdle);
			damaged_leftIdle = content.Load<Texture2D>("PlayerSprites/SamusLeftIdleDamaged");
			playerTextures.Add(damaged_leftIdle);
			healthBar = content.Load<Texture2D>("HealthBar");
            playerTextures.Add(healthBar);

			//Fonts
			healthFont = content.Load<SpriteFont>("PlayerHealth");
			playerFonts.Add(healthFont);

			//Items
			bombItem = content.Load<Texture2D>("Items/Bomb");
			energyDropItem = content.Load<Texture2D>("Items/EnergyDropItem");
			energyTankItem = content.Load<Texture2D>("Items/EnergyTank");
			highJumpItem = content.Load<Texture2D>("Items/HighJump");
			iceBeamItem = content.Load<Texture2D>("Items/IceBeam");
			longBeamItem = content.Load<Texture2D>("Items/LongBeam");
			missleRocketItem = content.Load<Texture2D>("Items/MissleRocket");
			morphBallItem = content.Load<Texture2D>("Items/MorphBall");
			rocketDropItem = content.Load<Texture2D>("Items/RocketDropItem");
			screwAttackItem = content.Load<Texture2D>("Items/ScrewAttack");
			variaItem = content.Load<Texture2D>("Items/Varia");
			waveBeamItem = content.Load<Texture2D>("Items/WaveBeam");

			//Map
			map = content.Load<Texture2D>("ProjSprites/Map");

			//Blocks
			stockBlockBlue = content.Load<Texture2D>("BlockSprites/StockBlueBlock");
			bushBlockBlue = content.Load<Texture2D>("BlockSprites/BushBlueBlock");
			tubeBlockBlue = content.Load<Texture2D>("BlockSprites/TubeBlueBlock");
			swirlBlockBlue = content.Load<Texture2D>("BlockSprites/SwirlBlueBlock");
			stockBlockOrange = content.Load<Texture2D>("BlockSprites/StockOrangeBlock");
			bushBlockOrange = content.Load<Texture2D>("BlockSprites/BushOrangeBlock");
			tubeBlockOrange = content.Load<Texture2D>("BlockSprites/TubeOrangeBlock");
			swirlBlockOrange = content.Load<Texture2D>("BlockSprites/SwirlOrangeBlock");

		// More Content.Load calls follow
		//...
	}

		public ISprite CreatePlayerSprite()
		{
			return (ISprite) new PlayerSprite(playerTextures, playerFonts);
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

		/*public ISprite CreateBlockSprite(ILevel level)
		{
			//return new EnemySprite(enemySpritesheet, level.ColorTheme);
		} */

		public List<ISprite> CreateItemSpriteList(Vector2 location)
		{
			List<ISprite> itemList = new List<ISprite>();
			itemList.Add(new BombItem(bombItem, location));
			itemList.Add(new EnergyDropItem(energyDropItem, location));
			itemList.Add(new EnergyTankItem(energyTankItem, location));
			itemList.Add(new HighJumpItem(highJumpItem, location));
			itemList.Add(new IceBeamItem(iceBeamItem, location));
			itemList.Add(new LongBeamItem(longBeamItem, location));
			itemList.Add(new MissleRocketItem(missleRocketItem, location));
			itemList.Add(new MorphBallItem(morphBallItem, location));
			itemList.Add(new RocketDropItem(rocketDropItem, location));
			itemList.Add(new ScrewAttackItem(screwAttackItem, location));
			itemList.Add(new VariaItem(variaItem, location));
			itemList.Add(new WaveBeamItem(waveBeamItem, location));

			return itemList;
		}

		public List<ISprite> CreateBlockSpriteList(Vector2 location)
		{
			List<ISprite> blockList = new List<ISprite>();
			blockList.Add(new BlockSprite(stockBlockBlue, location));
			blockList.Add(new BlockSprite(bushBlockBlue, location));
			blockList.Add(new BlockSprite(swirlBlockBlue, location));
			blockList.Add(new BlockSprite(tubeBlockBlue, location));
			blockList.Add(new BlockSprite(stockBlockOrange, location));
			blockList.Add(new BlockSprite(bushBlockOrange, location));
			blockList.Add(new BlockSprite(swirlBlockOrange, location));
			blockList.Add(new BlockSprite(tubeBlockOrange, location));

			return blockList;
		}

		public ISprite CreateMapSprite()
        {
			return new MapSprite(map);
        }

		public ISprite CreateBomb(Vector2 location)
		{

			return new Bomb(bombTex, location);
		}

		public ISprite CreateMissileRocket(Vector2 location, Vector2 direction)
		{

			return new MissleRocket(missileRocketTex, location, direction);
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
