using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Kraid : IEnemy
    {

        private ISprite sprite;
        private int msBetweenAttack = 500;
        private int msUntilAttack = 500;
        private float x, y;
        public Rectangle Space;
        private bool isDead;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;

        public Kraid(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.KraidSprite(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = 1;
            vertSpeed = 0;
        }

        public void Update(GameTime gameTime)
        {
            //Wait between attacks
            msUntilAttack -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            //Perform attacks
            if (msUntilAttack < 0)
            {
                if (new Random().Next(0, 2) == 0)
                {
                    throwHorns();
                }
                else
                {
                    shootMissiles();
                }
                msUntilAttack = msBetweenAttack;
            }

            //Update location
            Space = new Rectangle((int)x, (int)y, 48, 64);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
        public Rectangle SpaceRectangle()
        {
            return Space;
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

        private void throwHorns()
        {
            GameObjectContainer.Instance.Add(new KraidHorn(new Vector2(x, y), true));
        }

        private void shootMissiles()
        {
            int speed = 7;
            GameObjectContainer.Instance.Add(new KraidMissile(new Vector2(x+23, y+38), new Vector2(speed, 0)));
        }


    }
}
