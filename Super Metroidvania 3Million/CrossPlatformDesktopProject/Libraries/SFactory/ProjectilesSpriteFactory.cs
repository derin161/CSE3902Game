using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class ProjectilesSpriteFactory
    {
		//Projectiles
		private Texture2D bombTex;
		private Texture2D kraidHornTex;
		private Texture2D kraidMissileTex;
		private Texture2D missileRocketTex;
		private Texture2D powerBeamTex;
		private Texture2D waveBeamTex;
		private Texture2D iceBeamTex;

		private static ProjectilesSpriteFactory instance = new ProjectilesSpriteFactory();
		public static ProjectilesSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private ProjectilesSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			//Projectiles
			bombTex = content.Load<Texture2D>("ProjSprites/BombProj");
			kraidHornTex = content.Load<Texture2D>("ProjSprites/KraidHorn");
			kraidMissileTex = content.Load<Texture2D>("ProjSprites/KraidMissile");
			missileRocketTex = content.Load<Texture2D>("ProjSprites/MissileRocketProj");
			powerBeamTex = content.Load<Texture2D>("ProjSprites/PowerBeamProj");
			waveBeamTex = content.Load<Texture2D>("ProjSprites/WaveBeamProj");
			iceBeamTex = content.Load<Texture2D>("ProjSprites/IceBeamProj");
		}

		public ISprite CreatePreBoomBombSprite(Bomb b)
		{

			return new PreBoomBombSprite(bombTex, b);
		}

		public ISprite CreatePostBoomBombSprite(Bomb b)
		{

			return new PostBoomBombSprite(bombTex, b);
		}

		//These methods need to be fixed once the separation of game objects and sprites is finished.
		public ISprite CreateMissileRocket(MissileRocket mr, bool isHorizontal)
		{

			return new MissileRocketSprite(missileRocketTex, mr, isHorizontal);
		}
		/*
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
		}*/

		public ISprite CreateKraidHornSprite(KraidHorn kh)
		{
			return new KraidHornSprite(kraidHornTex, kh);
		}

		public ISprite CreateKraidMissileSprite(KraidMissile km)
		{
			return new KraidMissileSprite(kraidMissileTex, km);
		}
	}
}
