using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMetroidvania5Million.Libraries.Sprite.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMetroidvania5Million.Libraries.GameObjects.Player
{
    //Author: Nyigel Spann
    public abstract class AbstractPlayerStateDecorator : IPlayerState
    {
        protected IPlayerState DecoratedPlayerState { get; set; }
        public IPlayerSprite Sprite { get; set; }

        public AbstractPlayerStateDecorator(IPlayerState playerState) {
            DecoratedPlayerState = playerState;
            Sprite = playerState.Sprite;
        }

        public virtual void Attack()
        {
            DecoratedPlayerState.Attack();
        }

        public virtual void Jump()
        {
            DecoratedPlayerState.Jump();
        }

        public virtual void Morph()
        {
            DecoratedPlayerState.Morph();
        }

        public virtual void MoveRight()
        {
            DecoratedPlayerState.MoveRight();
        }

        public virtual void MoveLeft()
        {
            DecoratedPlayerState.MoveLeft();
        }

        public virtual void AimUp()
        {
            DecoratedPlayerState.AimUp();
        }

        public virtual void Update(GameTime gameTime)
        {
            DecoratedPlayerState.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            DecoratedPlayerState.Draw(spriteBatch);
        }

        public virtual void Idle()
        {
            DecoratedPlayerState.Idle();
        }
    }
}
