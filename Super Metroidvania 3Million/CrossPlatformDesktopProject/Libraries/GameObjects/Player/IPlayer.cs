﻿using Microsoft.Xna.Framework;
using SuperMetroidvania5Million.Libraries.Sprite.Items;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
{
    public interface IPlayer : IGameObject
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
        public void Upgrade(IItem item);
        public void TakeDamage(int damage);
        public void CycleBeamMissile();
        public void Idle();
        public void UpdateLocation(Vector2 l);
        public Vector2 GetPlayerLocation();
        public Rectangle SpriteRectangle();

    }
}
