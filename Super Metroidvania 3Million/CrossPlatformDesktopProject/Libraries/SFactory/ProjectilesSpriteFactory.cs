﻿using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite;
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
    class ProjectilesSpriteFactory : IFactory
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
	}
}
