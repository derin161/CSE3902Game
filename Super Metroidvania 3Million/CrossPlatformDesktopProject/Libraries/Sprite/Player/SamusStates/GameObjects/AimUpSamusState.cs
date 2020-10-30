using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;

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

		public AimUpSamusState(Samus sam, bool facingRight)
		{
			samus = sam;
			direction = new Vector2(0.0f, -4.0f);
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
				GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreatePowerBeam(missileLoc, direction, samus.inventory.HasLongBeam, samus.inventory.HasIceBeam));
			}
			else
			{
				GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreateWaveBeam(missileLoc, direction, samus.inventory.HasLongBeam));
			}

		}
		public void Jump()
        {
			samus.state = new JumpRightSamusState(samus);
        }

		public void Morph()
        {
			samus.state = new MorphSamusState(samus);
		}

		public void MoveRight()
        {
			samus.state = new RightWalkSamusState(samus);
		}

		public void MoveLeft()
        {
			samus.state = new LeftIdleSamusState(samus);
		}

		public void AimUp()
        {
			//Nothing
		}

		public void Update(GameTime gameTime)
		{
			//Nothing needs to be updated
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
