using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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

		public IGameObject CreateBomb(Vector2 Location)
		{

			return new Bomb(Location);
		}

		public IGameObject CreateMissileRocket(Vector2 loc, Vector2 dir)
		{

			return new MissileRocket(loc, dir);
		}
		
		public IGameObject CreatePowerBeam(Vector2 loc, Vector2 dir, bool isLongBeam, bool isIceBeam)
		{
			return new PowerBeam(loc, dir, isLongBeam, isIceBeam);
		}

		public IGameObject CreateWaveBeam(Vector2 loc, Vector2 dir, bool isLongBeam)
		{
			return new WaveBeam(loc, dir, isLongBeam);
		}

		public IGameObject CreateKraidHorn(Vector2 loc, bool isMovingRight)
		{
			return new KraidHorn(loc, isMovingRight);
		}

		public IGameObject CreateKraidMissile(Vector2 loc, Vector2 dir)
		{
			return new KraidMissile(loc, dir);
		}
	}
}
