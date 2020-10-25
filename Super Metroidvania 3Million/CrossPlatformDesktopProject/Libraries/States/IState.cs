using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.States
{
    interface IState
    {
        ISprite Sprite { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
