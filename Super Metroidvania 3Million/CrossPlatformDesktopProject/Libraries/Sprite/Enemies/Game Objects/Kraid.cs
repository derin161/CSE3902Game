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
        private Game1 game;
        private float x, y;
        public Rectangle Space;
        private bool isDead;

        public Kraid(Vector2 l, Game1 g)
        {
            sprite = EnemySpriteFactory.Instance.KraidSprite(this, game);
            game = g;
            x = l.X;
            y = l.Y;
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
