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
        public static int enemyHealth = 100;

        //Geega and Geega Sprite magic numbers
        public static int geegaInitialVertSpeed = 4;
        public static int geegaInitialHorizSpeed = 0;
        public static int geegaAttackVertSpeed = 0;
        public static int geegaAttackHorizSpeed = 3;
        public static int geegaWidth = 32;
        public static int geegaHeight = 32;
        public static int geegaRespawnDelay = 1000;
        public static int geegaSpriteRows = 2;
        public static int geegaSpriteColumns = 2;
        public static int geegaSpriteFrameSpeed = 3;
        public static int geegaSpriteFrameReset = 2;

        //Kraid and KraidSprite magic numbers
        public static int kraidInitialVertSpeed = 0;
        public static int kraidInitialHorizSpeed = 1;
        public static int kraidDistanceBuffer = 72;
        public static int kraidHeight = 64;
        public static int kraidWidth = 48;
        public static int kraidMissileSpeed = 7;
        public static int kraidMissileXOffset = 23;
        public static int kraidMissileYOffset = 38;
        public static int kraidDamage = 25;
        public static int kraidAttackDelay = 500;
        public static int kraidSpriteRows = 2;
        public static int kraidSpriteColumns = 2;
        public static int kraidSpriteFrameSpeed = 4;
        public static int kraidSpriteFrameReset = 2;

        //Memu and memu sprite magic numbers
        public static int memuVertSpeed = 0;
        public static int memuHorizSpeed = 3;
        public static int memuHeight = 32;
        public static int memuWidth = 32;
        public static int memuSpriteRows = 1;
        public static int memuSpriteColumns = 2;
        public static int memuSpriteFrameSpeed = 10;
        public static int memuSpriteFrameReset = 2;


    }
}
