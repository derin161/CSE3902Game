using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using System;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author:
    public class BlockUtilities
    {
        private static BlockUtilities instance = new BlockUtilities();

        public static BlockUtilities Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockUtilities() //private constructor for singleton
        {

        }

    }
}
