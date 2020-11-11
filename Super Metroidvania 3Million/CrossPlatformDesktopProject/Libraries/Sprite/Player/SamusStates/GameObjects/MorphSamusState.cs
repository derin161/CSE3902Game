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
	public class MorphSamusState : IPlayerState 
	{
		private Samus samus;
		private ISprite sprite;
		private Vector2 missileLoc;
		private Vector2 direction;

		public MorphSamusState(Samus sam)
		{
			samus = sam;
			sprite = PlayerSpriteFactory.Instance.RightIdleSprite(samus);
			missileLoc = new Vector2(samus.x + 45, samus.y + 32);
			direction = new Vector2(10.0f, 0.0f);
		}

		public void Attack()
        {
			missileLoc = new Vector2(samus.x + 45, samus.y + 32);
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
			//Nothing right now
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
			samus.State = new AimUpSamusState(samus, true);
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
