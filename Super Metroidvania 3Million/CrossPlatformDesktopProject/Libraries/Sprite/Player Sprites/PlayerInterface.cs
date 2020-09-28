using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Sprite.Player_Sprites
{
    interface PlayerInterface : ISprite
    {
        public void Attack();
        public void Item1(); //edit based on Item interface
        public void Item2(); //~~
        public void Item3(); //~~
        public void MoveLeft();
        public void MoveRight();
        public void Jump();
        public void Crouch();


    }
}
