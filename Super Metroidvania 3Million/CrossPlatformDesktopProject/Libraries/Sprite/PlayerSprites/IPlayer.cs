using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Sprite.Player_Sprites
{
    interface IPlayer : ISprite
    {
        public void Jump();
        public void Crouch();
        public void MoveLeft();
        public void MoveRight();

        public void Attack();

        public void PowerBeam();
        public void WaveBeam();
        public void IceBeam();
        public void MissleRocket();
        public void Bomb();

        public void Damage();

    }
}
