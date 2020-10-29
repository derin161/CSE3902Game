using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class RightWalkSamusState : IPlayerState 
	{
		private Samus samus;
		private ISprite sprite;
		private Vector2 missileLoc;
		private Vector2 direction;

		public RightWalkSamusState(Samus sam)
		{
			samus = sam;
			sprite = PlayerSpriteFactory.Instance.RightWalkSprite(samus);
			missileLoc = new Vector2(samus.x + 60, samus.y + 32);
			direction = new Vector2(4.0f, 0.0f);
			samus.Jumping = false;
		}

		public void Attack()
		{
			missileLoc = new Vector2(samus.x + 60, samus.y + 8);
			if (samus.missile == 0)
			{
				GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreateMissileRocket(missileLoc, direction));
			}
			else if (samus.missile == 0)
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
			this.Update(samus.gameTime);
		}

		public void MoveLeft()
        {
			samus.state = new LeftIdleSamusState(samus);
		}

		public void AimUp()
        {
			samus.state = new AimUpSamusState(samus);
		}

		public void Update(GameTime gameTime)
		{
			sprite.Update(gameTime);
			samus.Physics.MoveRight();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch);
		}

		public void Idle () 
		{
			samus.state = new RightIdleSamusState(samus);
		}
	}
}
