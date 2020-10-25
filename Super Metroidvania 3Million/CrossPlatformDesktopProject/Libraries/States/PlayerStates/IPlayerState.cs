using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.States.PlayerStates
{
    interface IPlayerState : ISprite
    {
        void Up();
        void UpRelease();
        void Down();
        void DownRelease();
        void Right();
        void RightRelease();
        void RightHeld();
        void Left();
        void LeftRelease();
        void LeftHeld();
        void Attack();
        void AttackRelease();
        void Item();
        void ItemRelease();

    }
}
