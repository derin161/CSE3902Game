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

		public JumpLeftSamusState(Samus sam, bool xShift, int frame, float y)
		{
			samus = sam;
			sprite = PlayerSpriteFactory.Instance.JumpLeftSprite(samus, xShift, frame, y);
			missileLoc = new Vector2(samus.position.X + 19, samus.position.Y + 32);
			direction = new Vector2(10.0f, 0.0f);
			samus.Physics.Jump();
		}

		public void Attack()
		{
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
			samus.state = new JumpRightSamusState(samus, true, sprite.currentFrame, sprite.origY);
		}

		public void MoveLeft()
        {
			samus.Physics.MoveLeft();
			this.Update(samus.gameTime);
		}

		public void AimUp()
        {
			samus.state = new AimUpSamusState(samus);
		}

		public void Update(GameTime gameTime)
		{
			sprite.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch);
		}

		public void Idle () 
		{
			//Nothing happens
		}
	}
}
