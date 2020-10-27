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
    public interface IPlayerState
    {
        /*Author: Shyamal Shah*/
        /* I don't think we need any of these -Nyigel
        public void JumpAnimation(SpriteBatch spriteBatch);
        public void CrouchAnimation(SpriteBatch spriteBatch);
        public void MoveLeftAnimation(SpriteBatch spriteBatch);
        public void MoveRightAnimation(SpriteBatch spriteBatch);

        public void AttackAnimation(SpriteBatch spriteBatch);

        public void DamageAnimation(SpriteBatch spriteBatch);
        public void IdleAnimation(SpriteBatch spriteBatch);*/
        public void Attack(); //Shoots active beam missile device or places bomb.
        public void Jump();
        public void Morph();
        public void MoveRight();
        public void MoveLeft();
        public void AimUp();
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);

    }
}
