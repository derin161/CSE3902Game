using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class ProjectilesGOFactory
    {

		private static ProjectilesGOFactory instance = new ProjectilesGOFactory();
		public static ProjectilesGOFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private ProjectilesGOFactory()
		{
		}

		public IProjectile CreateBomb(Vector2 Location)
		{

			return new Bomb(Location);
		}

		public IProjectile CreateMissileRocket(Vector2 loc, Vector2 dir)
		{

			return new MissileRocket(loc, dir);
		}

		public IProjectile CreateMissileRocketExplosion()
		{

			return new MissileRocketExplosion();
		}

		public IProjectile CreatePowerBeam(Vector2 loc, Vector2 dir, bool isLongBeam, bool isIceBeam)
		{
			return new PowerBeam(loc, dir, isLongBeam, isIceBeam);
		}

		public IProjectile CreateWaveBeam(Vector2 loc, Vector2 dir, bool isLongBeam)
		{
			return new WaveBeam(loc, dir, isLongBeam);
		}

		public IProjectile CreateKraidHorn(Vector2 loc, bool isMovingRight)
		{
			return new KraidHorn(loc, isMovingRight);
		}

		public IProjectile CreateKraidMissile(Vector2 loc, Vector2 dir)
		{
			return new KraidMissile(loc, dir);
		}


	}
}
