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
	public class JumpRightSamusState : IPlayerState 
	{
		private Samus samus;
		private ISprite sprite;
		private Vector2 missileLoc;
		private Vector2 direction;

		public JumpRightSamusState(Samus sam, bool xShift, int frame, int y)
		{
			samus = sam;
			sprite = PlayerSpriteFactory.Instance.JumpRightSprite(samus, xShift, frame, y);
			missileLoc = new Vector2(samus.x + 45, samus.y + 32);
			direction = new Vector2(4.0, 0.0);
		}

		public void Attack()
		{
			if (samus.missile == 0)
			{
				GameObjectContainer.Instance.Add(new Missilerocket(missileLoc, direction));
			}
			else if (samus.missile == 0)
			{
				GameObjectContainer.Instance.Add(new PowerBeam(missileLoc, direction, samus.inventory.HasLongBeam, samus.inventory.HasIceBeam));
			}
			else
			{
				GameObjectContainer.Instance.Add(new WaveBeam(missileLoc, direction, samus.inventory.HasLongBeam));
			}

		}

		public void Jump()
        {
			this.Update(samus.gameTime);
		}

		public void Morph()
        {
			samus.state = new MorphSamusState(samus);
		}

		public void MoveRight()
        {
			sprite.xChange = 10;
			this.Update(samus.gameTime);
		}

		public void MoveLeft()
        {
			samus.state = new JumpLeftSamusState(samus, true, sprite.currentFrame, sprite.origY);
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
	}
}
