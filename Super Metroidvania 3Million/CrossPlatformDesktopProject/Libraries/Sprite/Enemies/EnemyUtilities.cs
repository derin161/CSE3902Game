using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    public static class EnemyUtilities
    {
        //General enemy magic numbers
        public static int enemyDamage = 25;
        public static int offScreenLeft = 0;
        public static int offScreenRight = 800;


        //Geega magic numbers
        public static int geegaInitialHealth = 100;
        public static int geegaInitialVertSpeed = 4;
        public static int geegaInitialHorizSpeed = 0;
        public static int geegaAttackVertSpeed = 0;
        public static int geegaAttackHorizSpeed = 3;
        public static int geegaWidth = 32;
        public static int geegaHeight = 32;
        public static int geegaRespawnDelay = 1000;


    }
}
