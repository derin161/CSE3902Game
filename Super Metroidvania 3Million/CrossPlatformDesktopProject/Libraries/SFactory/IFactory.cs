using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Sprite;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    public interface IFactory
    {
        //Constructor
        public void LoadAllTextures(ContentManager content);
	}
}
