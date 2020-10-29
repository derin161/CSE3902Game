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
	public class JumpLeftSamusState : IPlayerState 
	{
		private Samus samus;
		private JumpLeftSamusSprite sprite;
		private Vector2 missileLoc;
		private Vector2 direction;
		private Vector2 currentVelocity;

		public JumpLeftSamusState(Samus sam)
		{
			samus = sam;
			sprite = PlayerSpriteFactory.Instance.JumpLeftSprite(samus);
			missileLoc = new Vector2(samus.x + 19, samus.y + 32);
			direction = new Vector2(-10.0f, 0.0f);
			samus.Physics.Jump();
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
			samus.Jumping = true;
		}

		public void Attack()
		{
			missileLoc = new Vector2(samus.x + 19, samus.y + 32);
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
			//Does Nothing
		}

		public void Morph()
        {
			samus.state = new MorphSamusState(samus);
		}

		public void MoveRight()
        {
			samus.Physics.velocity = new Vector2(currentVelocity.X, currentVelocity.Y);
			samus.Physics.MoveRight();
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
			samus.state = new JumpRightSamusState(samus);
		}

		public void MoveLeft()
        {
			samus.Physics.velocity = new Vector2(currentVelocity.X, currentVelocity.Y);
			samus.Physics.MoveLeft();
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
		}

		public void AimUp()
        {
			samus.state = new AimUpSamusState(samus);
		}

		public void Update(GameTime gameTime)
		{
			samus.Physics.velocity = new Vector2(currentVelocity.X, currentVelocity.Y);
			samus.Physics.Update();
			if ( (int) samus.Physics.velocity.Y == 0){
				this.Idle();
			}
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
			sprite.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch);
		}

		public void Idle () 
		{
			samus.Physics.velocity = new Vector2(currentVelocity.X, 0);
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
			samus.state = new LeftIdleSamusState(samus);
		}
	}
}
