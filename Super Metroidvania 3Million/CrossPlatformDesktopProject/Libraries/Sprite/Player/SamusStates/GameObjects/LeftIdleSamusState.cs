using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Container;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class LeftIdleSamusState : IPlayerState 
	{
		private Samus samus;
		private ISprite sprite;
		private Vector2 missileLoc;
		private Vector2 direction;

		public LeftIdleSamusState(Samus sam)
		{
			samus = sam;
			sprite = PlayerSpriteFactory.Instance.LeftIdleSprite(samus);
			missileLoc = new Vector2(samus.x, samus.y + 16);
			direction = new Vector2(-10.0f, 0.0f);
			samus.Physics.HortizontalBreak();
			samus.Jumping = false;
		}

		public void Attack()
        {
			missileLoc = new Vector2(samus.x, samus.y + 16);
			if (samus.missile == 0)
            {
				GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreateMissileRocket(missileLoc, direction));
			}
			else if (samus.missile == 1)
            {
				GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreatePowerBeam(missileLoc, direction, samus.Inventory.HasLongBeam, samus.Inventory.HasIceBeam));
			}
			else
            {
				GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreateWaveBeam(missileLoc, direction, samus.Inventory.HasLongBeam));
			}

		}
		public void Jump()
        {
			samus.State = new JumpLeftSamusState(samus);
		}

		public void Morph()
        {
			samus.State = new MorphSamusState(samus);
		}

		public void MoveRight()
        {
			samus.State = new RightIdleSamusState(samus);
		}

		public void MoveLeft()
        {
			samus.State = new LeftWalkSamusState(samus);
		}

		public void AimUp()
        {
			samus.State = new AimUpSamusState(samus, false);
		}

		public void Update(GameTime gameTime)
		{
			//Nothing needs to be updated
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch);
		}

		public void Idle () 
		{
			//Nothing Happens
		}
	}
}
