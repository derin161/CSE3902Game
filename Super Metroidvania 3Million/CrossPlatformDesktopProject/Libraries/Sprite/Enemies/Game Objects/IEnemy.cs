using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Nyigel Spann
    public interface IEnemy : IGameObject
    {
        public void MoveLeft();
        public void MoveRight();
        public void MoveUp();
        public void MoveDown();
        public void StopMoving();
        public void ChangeDirection();
        public void Freeze();
        public void TakeDamage(int damage);
        public int GetDamage();
    }
}
