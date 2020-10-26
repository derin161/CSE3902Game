using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Skree : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite sprite;
        private bool isDead;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;


        public Skree(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.SkreeSprite(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = 3;
            vertSpeed = 0;
        }

        public void Update(GameTime gameTime)
        {
            stateMachine.Update(horizSpeed, vertSpeed);
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, 32, 32);
            sprite.Update(gameTime);
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public Boolean IsDead()
        {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
        }

        public void MoveLeft()
        {
            stateMachine.MoveLeft();
        }
        public void MoveRight()
        {
            stateMachine.MoveRight();
        }
        public void MoveUp()
        {
            stateMachine.MoveUp();
        }
        public void MoveDown()
        {
            stateMachine.MoveDown();
        }
    }
}
