﻿using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
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

		public IGameObject CreateMissileRocket(Vector2 location, Vector2 direction)
		{

			return new MissleRocket(missileRocketTex, location, direction);
		}

		public IGameObject CreatePowerBeam(Vector2 location, Vector2 direction, bool isLongBeam)
		{
			return new PowerBeam(powerBeamTex, location, direction, isLongBeam, false);
		}

		public IGameObject CreateIceBeam(Vector2 location, Vector2 direction, bool isLongBeam)
		{
			return new PowerBeam(iceBeamTex, location, direction, isLongBeam, true);
		}

		public IGameObject CreateWaveBeam(Vector2 location, Vector2 direction, bool isLongBeam, bool isIceBeam)
		{
			return new WaveBeam(waveBeamTex, location, direction, isLongBeam, isIceBeam);
		}

		public IGameObject CreateKraidHorn(Vector2 location, bool isMovingRight)
		{
			return new KraidHorn(kraidHornTex, location, isMovingRight);
		}

		public IGameObject CreateKraidMissile(Vector2 location, Vector2 direction)
		{
			return new KraidMissile(kraidMissileTex, location, direction);
		}
	}
}
