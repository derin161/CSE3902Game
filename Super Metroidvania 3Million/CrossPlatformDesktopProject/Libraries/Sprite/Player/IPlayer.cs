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

        public void SpecialAttack(); //Shoot beam or set bomb.
        public void ShootBeamMissile(); //Shoots active beam missile device.
        public void CycleBeamMissile(); //Cycles between ice/power beam, wave beam, or missile rocket.
        public void Jump();
        public void CurlUp();
        public void MoveRight();
        public void MoveLeft();
        public void AimUp();
        public void TakeDamage();

    }
}
