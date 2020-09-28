using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Sprite.Projectiles
{
    interface IProjectile : ISprite
    {
        void Spawn();
    }
}
