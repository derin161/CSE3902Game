using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Container;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class AimUpSamusState : IPlayerState 
	{
		private Samus samus;
		private ISprite sprite;
		private Vector2 missileLoc;
		private Vector2 direction;
		private bool rightFacing;
		private int width = 32;
		private int height = 64;

		public AimUpSamusState(Samus sam, bool facingRight)
		{
			samus = sam;
			direction = new Vector2(0.0f, -10.0f);
			samus.Jumping = false;
			rightFacing = facingRight;
			if (rightFacing) {
				sprite = PlayerSpriteFactory.Instance.RightAimUpSprite(samus);
			}else {
				sprite = PlayerSpriteFactory.Instance.LeftAimUpSprite(samus);
			}
		}

		public void Attack()
        {
			missileLoc = new Vector2(samus.x + 12, samus.y);
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
			samus.State = new JumpRightSamusState(samus);
        }

		public void Morph()
        {
			samus.State = new MorphSamusState(samus);
		}

		public void MoveRight()
        {
			samus.State = new RightWalkSamusState(samus);
		}

		public void MoveLeft()
        {
			samus.State = new LeftIdleSamusState(samus);
		}

		public void AimUp()
        {
			//Nothing
		}

		public void Update(GameTime gameTime)
		{
			/*Updating Hit Box based on position*/
			samus.space = new Rectangle(samus.space.X, samus.space.Y, width, height);
			samus.UpdateAimHitBox();
			samus.space = new Rectangle(samus.space.X, samus.space.Y, 64, 64);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch);
		}

		public void Idle()
		{
			//Nothing
		}
	}
}
