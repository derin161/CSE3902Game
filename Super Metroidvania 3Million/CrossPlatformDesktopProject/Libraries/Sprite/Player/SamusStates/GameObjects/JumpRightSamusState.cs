using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Container;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class JumpRightSamusState : IPlayerState 
	{
		private Samus samus;
		private ISprite sprite;
		private Vector2 missileLoc;
		private Vector2 direction;
		private Vector2 currentVelocity;

		public JumpRightSamusState(Samus sam)
		{
			samus = sam;
			sprite = PlayerSpriteFactory.Instance.JumpRightSprite(samus);
			missileLoc = new Vector2(samus.x + 45, samus.y + 32);
			direction = new Vector2(10.0f, 0.0f);
			if(!samus.Jumping){
				samus.Physics.Jump();
				samus.Jumping = true;
			}
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
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
			this.Update(samus.gameTime);
		}

		public void Morph()
        {
			samus.State = new MorphSamusState(samus);
		}

		public void MoveRight()
        {
			samus.Physics.velocity = new Vector2(currentVelocity.X, currentVelocity.Y);
			samus.Physics.MoveRight();
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);

		}

		public void MoveLeft()
        {
			samus.Physics.velocity = new Vector2(currentVelocity.X, currentVelocity.Y);
			samus.Physics.MoveLeft();
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
			samus.State = new JumpLeftSamusState(samus);
		}

		public void AimUp()
        {
			samus.State = new AimUpSamusState(samus, true);
		}

		public void Update(GameTime gameTime)
		{
			samus.Physics.velocity = new Vector2(currentVelocity.X, currentVelocity.Y);
			samus.Physics.Update();
			/*if (samus.Physics.velocity.Y > 0){
				this.Idle();
			}*/ 
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
			sprite.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			samus.Physics.velocity = new Vector2(currentVelocity.X, currentVelocity.Y);
			currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
			sprite.Draw(spriteBatch);
		}

		public void Idle()
		{
			if (!samus.Jumping){
				samus.Physics.velocity = new Vector2(currentVelocity.X, 0);
				currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
				samus.State = new RightIdleSamusState(samus);
			}else {
				samus.Physics.velocity = new Vector2(currentVelocity.X, 0);
				samus.Physics.HortizontalBreak();
				currentVelocity = new Vector2(samus.Physics.velocity.X, samus.Physics.velocity.Y);
			}
		}
	}
}
