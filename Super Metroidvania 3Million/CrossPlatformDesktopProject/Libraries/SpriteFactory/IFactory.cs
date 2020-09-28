using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.SpriteFactory
{
    interface IFactory
    {
        public void LoadAllTextures(ContentManager content);
    }
}
