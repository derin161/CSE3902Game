using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMetroidvania5Million.Libraries.SFactory;
using SuperMetroidvania5Million.Libraries.Container;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
{
    /*Author: Shyamal Shah*/
    public class RightWalkSamusState : IPlayerState
    {
        public IPlayerSprite Sprite { get; set; }
        private Samus samus;
        private Vector2 missileLoc;
        private Vector2 direction;

        public RightWalkSamusState(Samus sam)
        {
            samus = sam;
            Sprite = PlayerSpriteFactory.Instance.RightWalkSprite(samus);
            missileLoc = new Vector2(samus.x + 60, samus.y + 32);
            direction = new Vector2(10.0f, 0.0f);
            samus.Jumping = false;
        }

        public void Attack()
        {
            missileLoc = new Vector2(samus.x + 60, samus.y + 8);
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
            samus.State = new MorphSamusState(samus, true);
        }

        public void MoveRight()
        {
            this.Update(samus.gameTime);
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
            Sprite.Update(gameTime);
            samus.Physics.MoveRight();
            /*Updating Player Hit Box*/
            samus.UpdateRightWalkHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Idle()
        {
            samus.State = new RightIdleSamusState(samus);
        }
    }
}
