namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author: Will Floyd
    public class EnemyUtilities
    {
        //General enemy magic numbers
        public static int EnemyDamage = 25;
        public static int OffScreenLeft = 0;
        public static int OffScreenRight = 800;
        public static int EnemyHealth = 100;

        //Geega and Geega Sprite magic numbers
        public static int GeegaInitialVertSpeed = 4;
        public static int GeegaInitialHorizSpeed = 0;
        public static int GeegaAttackVertSpeed = 0;
        public static int GeegaAttackHorizSpeed = 3;
        public static int GeegaWidth = 32;
        public static int GeegaHeight = 32;
        public static int GeegaRespawnDelay = 1000;
        public static int GeegaSpriteRows = 2;
        public static int GeegaSpriteColumns = 2;
        public static int GeegaSpriteFrameSpeed = 3;
        public static int GeegaSpriteFrameReset = 2;

        //Kraid and KraidSprite magic numbers
        public static int KraidInitialVertSpeed = 0;
        public static int KraidInitialHorizSpeed = 1;
        public static int KraidDistanceBuffer = 72;
        public static int KraidHeight = 64;
        public static int KraidWidth = 48;
        public static int KraidMissileSpeed = 7;
        public static int KraidMissileXOffset = 23;
        public static int KraidMissileYOffset = 38;
        public static int KraidDamage = 25;
        public static int KraidAttackDelay = 500;
        public static int KraidSpriteRows = 2;
        public static int KraidSpriteColumns = 2;
        public static int KraidSpriteFrameSpeed = 4;
        public static int KraidSpriteFrameReset = 2;

        //SideHopper and reverseSideHopper magic numbers
        public static int SidehopperInitialVertSpeed = 0;
        public static int SidehopperInitialHorizSpeed = 3;
        public static int SidehopperHeight = 64;
        public static int SidehopperWidth = 64;
        public static float SidehopperJumpA = 1.0f / 48.0f;
        public static float SidehopperJumpB = 1.5f;
        public static float SidehopperJumpC = 5;
        public static int SidehopperSpriteRows = 2;
        public static int SidehopperSpriteColumns = 6;
        public static int SidehopperSpriteFrameSpeed = 64;
        public static int SidehopperSpriteFrameReset = 2;
        public static int ReverseSidehopperSpriteFrameReset = 6;

        //Skree and skree sprite magic numbers
        public static int SkreeInitialVertSpeed = 0;
        public static int SkreeInitialHorizSpeed = 0;
        public static int SkreeMaxAccel = 8;
        public static int SkreeHorizRange = 30;
        public static int SkreeFallingHorizSpeed = 1;
        public static int SkreeDeathTimer = 1500;
        public static int SkreeWidth = 32;
        public static int SkreeHeight = 48;
        public static int SkreeSpriteRows = 2;
        public static int SkreeSpriteColumns = 3;
        public static int SkreeSpriteFrameSpeed = 4;
        public static int SkreeSpriteFrameReset = 3;

        //Memu and memu sprite magic numbers
        public static int MemuVertSpeed = 0;
        public static int MemuHorizSpeed = 3;
        public static int MemuHeight = 32;
        public static int MemuWidth = 32;
        public static int MemuSpriteRows = 1;
        public static int MemuSpriteColumns = 2;
        public static int MemuSpriteFrameSpeed = 10;
        public static int MemuSpriteFrameReset = 2;

        //Ripper and ripper sprite magic numbers
        public static int RipperVertSpeed = 0;
        public static int RipperHorizSpeed = 3;
        public static int RipperHeight = 32;
        public static int RipperWidth = 32;
        public static int RipperSpriteRows = 2;
        public static int RipperSpriteColumns = 1;

        //Zeela magic numbers
        public static int ZeelaHorizSpeed = 1;
        public static int ZeelaVertSpeed = 0;
        public static int VerticalZeelaHorizSpeed = 1;
        public static int VerticalZeelaVertSpeed = 0;
        public static int ZeelaHorizDistance = 32;
        public static int ZeelaWidth = 32;
        public static int ZeelaHeight = 32;




        private static EnemyUtilities instance = new EnemyUtilities();

        public static EnemyUtilities Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemyUtilities() //private constructor for singleton
        {

        }
    }
}
