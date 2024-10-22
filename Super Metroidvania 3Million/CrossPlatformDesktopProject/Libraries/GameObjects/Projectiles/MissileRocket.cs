﻿using SuperMetroidvania5Million.Libraries.Audio;
using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class MissileRocket : IProjectile
    {
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }
        public Vector2 Direction { get; set; }

        private ISprite sprite;
        private bool isHorizontal;
        private bool isDead = false;
        private MissileRocketExplosion explosion;
        private ProjectileUtilities projInfo = InfoContainer.Instance.Projectiles;

        public MissileRocket(Vector2 initialLocation, Vector2 direction)
        {
            isHorizontal = (int)direction.Y == 0;
            Location = initialLocation;
            Direction = direction;
            Space = new Rectangle((int)Location.X, (int)Location.Y, projInfo.MissileRocketHorizontalSpaceWidth, projInfo.MissileRocketHorizontalSpaceHeight);
            if (!isHorizontal)
            {
                Space = new Rectangle((int)Location.X, (int)Location.Y, projInfo.MissileRocketHorizontalSpaceHeight, projInfo.MissileRocketHorizontalSpaceWidth);
            }
            sprite = ProjectilesSpriteFactory.Instance.CreateMissileRocketSprite(this, isHorizontal);
            explosion = (MissileRocketExplosion)ProjectilesGOFactory.Instance.CreateMissileRocketExplosion();
            GameObjectContainer.Instance.Add(explosion);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {

            //Update position
            Location = Vector2.Add(Location, Direction);
            Space = new Rectangle((int)Location.X, (int)Location.Y, Space.Width, Space.Height);
            sprite.Update(gameTime);
        }
        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public int GetDamage()
        {
            return projInfo.MissileRocketDamage;
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void Kill()
        {
            explosion.Activate(Location);
            SoundManager.Instance.Projectiles.ExplosionSound.PlaySound();
            isDead = true;
        }
    }
}
