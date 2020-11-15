using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using System;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author:
    public class ProjectileUtilities
    {
        //Bomb info
        public 


        private static ProjectileUtilities instance = new ProjectileUtilities();

        public static ProjectileUtilities Instance
        {
            get
            {
                return instance;
            }
        }

        private ProjectileUtilities() //private constructor for singleton
        {

        }

    }
}
