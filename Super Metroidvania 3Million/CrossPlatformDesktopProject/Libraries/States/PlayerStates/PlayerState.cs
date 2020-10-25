using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.States.PlayerStates
{
    abstract class PlayerState : IPlayerState
    {
        public void Up() { }
        public void UpRelease() { }
        public void Down() { }
        public void DownRelease() { }
        public void Right() { }
        public void RightRelease() { }
        public void RightHeld() { }
        public void Left() { }
        public void LeftRelease() { }
        public void LeftHeld() { }
        public void Attack() { }
        public void AttackRelease() { }
        public void Item() { }
        public void ItemRelease() { }
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
    }
}
