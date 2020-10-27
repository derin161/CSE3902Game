using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Nyigel Spann
    public interface IEnemy : IGameObject
    {
        public void Freeze();
        public void TakeDamage(int damage);
        public void GetDamage();
    }
}
