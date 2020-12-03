using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMetroidvania5Million.Libraries.SFactory;
using SuperMetroidvania5Million.Libraries.Container;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
{
    /*Author: Shyamal Shah*/
    public class LeftIdleSamusState : IPlayerState
    {
        public IPlayerSprite Sprite { get; set; }
        private Samus samus;
        private Vector2 missileLoc;
        private Vector2 direction;

        public LeftIdleSamusState(Samus sam)
        {
            samus = sam;
            Sprite = PlayerSpriteFactory.Instance.LeftIdleSprite(samus);
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
            samus.State = new MorphSamusState(samus, false);
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
            /*Updating Player Hit Box*/
            samus.UpdateLeftIdleHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Idle()
        {
            //Nothing Happens
        }
    }
}
