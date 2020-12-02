using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMetroidvania5Million.Libraries.SFactory;
using SuperMetroidvania5Million.Libraries.Container;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
{
    /*Author: Shyamal Shah*/
    public class MorphSamusState : IPlayerState
    {
        private Samus samus;
        private ISprite sprite;
        private MorphDoneAnimationSamusSprite movingSprite;
        private Vector2 missileLoc;
        private Vector2 direction;
        private bool doneMorph;
        private bool facingRight;
        private bool spriteChange;

        public MorphSamusState(Samus sam, bool facingRight)
        {
            samus = sam;
            doneMorph = false;
            spriteChange = false;
            this.facingRight = facingRight;
            movingSprite = PlayerSpriteFactory.Instance.MorphMovingAnimationSprite(sam, this.facingRight);
            if (this.facingRight)
            {
                sprite = PlayerSpriteFactory.Instance.MorphRightAnimationSprite(samus, this);
            }
            else
            {
                sprite = PlayerSpriteFactory.Instance.MorphLeftAnimationSprite(samus, this);
            }
        }

        public void Attack()
        {
            GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreateBomb(new Vector2(samus.x, samus.y + 20)));
        }
        public void Jump()
        {
            if (spriteChange && doneMorph && !samus.Jumping)
            {
                samus.Physics.Jump();
                samus.Jumping = true;
                sprite.Update(samus.gameTime);
            }
        }

        public void Morph()
        {
            this.Update(samus.gameTime);
        }

        public void MoveRight()
        {
            if (spriteChange && doneMorph)
            {
                facingRight = true;
                samus.Physics.MoveRight();
                movingSprite.setDirection(facingRight);
                sprite.Update(samus.gameTime);
            }
        }

        public void MoveLeft()
        {
            if (spriteChange && doneMorph)
            {
                facingRight = false;
                samus.Physics.MoveLeft();
                movingSprite.setDirection(facingRight);
                sprite.Update(samus.gameTime);
            }
        }

        public void AimUp()
        {
            //Aim up not allowed during morph
        }

        public void Update(GameTime gameTime)
        {
            if (!spriteChange && doneMorph)
            {
                sprite = movingSprite;
                spriteChange = true;
            }

            if (samus.Physics.velocity.Y == 0)
            {
                samus.Jumping = false;
            }

            sprite.Update(gameTime);
            //Update player hitbox
            samus.UpdateRightIdleHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Idle()
        {
            if (samus.getMorph() && facingRight)
            {
                samus.State = new RightIdleSamusState(samus);
            }
            else if (samus.getMorph())
            {
                samus.State = new LeftIdleSamusState(samus);
            }
        }

        public void setDoneMorph()
        {
            doneMorph = true;
        }

    }
}
