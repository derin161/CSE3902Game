using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    //Author: Nyigel Spann
    public class ProjectilesSpriteFactory
    {
        //Projectiles
        private Texture2D bombTex;
        private Texture2D kraidHornTex;
        private Texture2D kraidMissileTex;
        private Texture2D missileRocketTex;
        private Texture2D powerBeamTex;
        private Texture2D waveBeamTex;
        private Texture2D iceBeamTex;

        private static ProjectilesSpriteFactory instance = new ProjectilesSpriteFactory();
        public static ProjectilesSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ProjectilesSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //Projectiles
            bombTex = content.Load<Texture2D>("ProjSprites/BombProj");
            kraidHornTex = content.Load<Texture2D>("ProjSprites/KraidHorn");
            kraidMissileTex = content.Load<Texture2D>("ProjSprites/KraidMissile");
            missileRocketTex = content.Load<Texture2D>("ProjSprites/MissileRocketProj");
            powerBeamTex = content.Load<Texture2D>("ProjSprites/PowerBeamProj");
            waveBeamTex = content.Load<Texture2D>("ProjSprites/WaveBeamProj");
            iceBeamTex = content.Load<Texture2D>("ProjSprites/IceBeamProj");
        }

        public ISprite CreatePreBoomBombSprite(Bomb b)
        {

            return new PreBoomBombSprite(bombTex, b);
        }

        public ISprite CreatePostBoomBombSprite(Bomb b)
        {

            return new PostBoomBombSprite(bombTex, b);
        }

        public ISprite CreateMissileRocketSprite(MissileRocket mr, bool isHorizontal)
        {

            return new MissileRocketSprite(missileRocketTex, mr, isHorizontal);
        }

        public ISprite CreateMissileRocketExplosionSprite(MissileRocketExplosion explosion)
        {

            return new MissileRocketExplosionSprite(missileRocketTex, explosion);
        }

        public ISprite CreatePowerBeamSprite(PowerBeam pb)
        {
            return new PowerBeamSprite(powerBeamTex, pb);
        }

        public ISprite CreateIceBeamSprite(PowerBeam pb)
        {
            return new PowerBeamSprite(iceBeamTex, pb);
        }

        public ISprite CreateWaveBeamSprite(WaveBeam wb)
        {
            return new WaveBeamSprite(waveBeamTex, wb);
        }

        public ISprite CreateKraidHornSprite(KraidHorn kh)
        {
            return new KraidHornSprite(kraidHornTex, kh);
        }

        public ISprite CreateKraidMissileSprite(KraidMissile km)
        {
            return new KraidMissileSprite(kraidMissileTex, km);
        }
    }
}
