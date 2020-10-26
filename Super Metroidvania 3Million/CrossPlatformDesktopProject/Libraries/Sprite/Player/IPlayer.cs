using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite
{
    public interface IPlayer : IGameObject
    {
        /* I don't think we need any of these -Nyigel
        public void JumpAnimation(SpriteBatch spriteBatch);
        public void CrouchAnimation(SpriteBatch spriteBatch);
        public void MoveLeftAnimation(SpriteBatch spriteBatch);
        public void MoveRightAnimation(SpriteBatch spriteBatch);

        public void AttackAnimation(SpriteBatch spriteBatch);

        public void DamageAnimation(SpriteBatch spriteBatch);
        public void IdleAnimation(SpriteBatch spriteBatch);*/
        public void Attack(); //Shoots active beam missile device or places bomb.
        public void CycleBeamMissile(); //Cycles between ice/power beam, wave beam, or missile rocket.
        public void Jump();
        public void CurlUp();
        public void MoveRight();
        public void MoveLeft();
        public void AimUp();
        public void TakeDamage(int damage);
        public void Upgrade(IItem item);

    }
}
