using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using System;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author:
    public class SoundUtilities
    {
        private static SoundUtilities instance = new SoundUtilities();

        public static SoundUtilities Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundUtilities() //private constructor for singleton
        {

        }

    }
}
