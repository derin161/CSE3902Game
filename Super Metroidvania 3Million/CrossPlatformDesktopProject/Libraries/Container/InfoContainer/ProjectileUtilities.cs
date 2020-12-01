namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author: Nyigel Spann
    public class ProjectileUtilities
    {
        //Bomb info
        public int BombDamage { get; set; }
        public int BombTimer { get; set; }
        public int PostBombSpaceWidth { get; set; }
        public int PostBombSpaceHeight { get; set; }

        //KraidHorn info
        public int KraidHornDamage { get; set; }
        public int KraidHornDx { get; set; }
        public double KraidHornArcA { get; set; }
        public double KraidHornArcB { get; set; }
        public int KraidHornSpaceHeight { get; set; }
        public int KraidHornSpaceWidth { get; set; }
        public int KraidHornSpriteMsPerFrame { get; set; }

        //KraidMissile info
        public int KraidMissileDamage { get; set; }
        public int KraidMissileSpaceHeight { get; set; }
        public int KraidMissileSpaceWidth { get; set; }

        //MissileRocket info
        public int MissileRocketDamage { get; set; }
        public int MissileRocketHorizontalSpaceHeight { get; set; }
        public int MissileRocketHorizontalSpaceWidth { get; set; }
        public int MissileRocketHorizontalSpriteX { get; set; }
        public int MissileRocketHorizontalSpriteY { get; set; }
        public int MissileRocketVerticalSpriteX { get; set; }
        public int MissileRocketVerticalSpriteY { get; set; }

        //MissileRocketExplosion info
        public int MissileRocketExplosionEndTime { get; set; }

        //PowerBeam Info
        public int PowerBeamDamage { get; set; }
        public int PowerBeamSpaceHeight { get; set; }
        public int PowerBeamSpaceWidth { get; set; }

        //waveBeam Info
        public int WaveBeamDamage { get; set; }
        public int WaveBeamSpaceHeight { get; set; }
        public int WaveBeamSpaceWidth { get; set; }
        public int WaveBeamDpos { get; set; }
        public int WaveBeamSinAmp { get; set; }
        public int WaveBeamSpriteDelay { get; set; }

        //Other Projectile Info
        public int ShortBeamBound { get; set; }


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
            //Bomb info
            BombDamage = 100;
            BombTimer = 1000; //ms
            PostBombSpaceHeight = 32;
            PostBombSpaceWidth = 32;

            //Kraid Horn info
            KraidHornDamage = 20;
            KraidHornDx = 3;
            KraidHornArcA = 0.01;
            KraidHornArcB = 2.0;
            KraidHornSpaceHeight = 16;
            KraidHornSpaceWidth = 16;
            KraidHornSpriteMsPerFrame = 50;

            //KraidMissileInfo
            KraidMissileDamage = 20;
            KraidMissileSpaceHeight = 16;
            KraidMissileSpaceWidth = 16;

            //MissileRocketInfo
            MissileRocketDamage = 50;
            MissileRocketHorizontalSpaceHeight = 8;
            MissileRocketHorizontalSpaceWidth = 16;
            MissileRocketHorizontalSpriteX = 0;
            MissileRocketHorizontalSpriteY = 4;
            MissileRocketVerticalSpriteX = 17;
            MissileRocketVerticalSpriteY = 0;


            //MissileRocketExplosion info
            MissileRocketExplosionEndTime = 100; //ms

            //PowerBeam info
            PowerBeamDamage = 20;
            PowerBeamSpaceHeight = 8;
            PowerBeamSpaceWidth = 8;

            //WaveBeam info
            WaveBeamDamage = 30;
            WaveBeamSpaceHeight = 8;
            WaveBeamSpaceWidth = 8;
            WaveBeamDpos = 3;
            WaveBeamSinAmp = 20;
            WaveBeamSpriteDelay = 150;

            //Other Projectile Info
            ShortBeamBound = 100;
        }

    }
}
