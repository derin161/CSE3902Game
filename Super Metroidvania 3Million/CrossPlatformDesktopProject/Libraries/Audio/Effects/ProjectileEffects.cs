using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace SuperMetroidvania5Million.Libraries.Audio
{
    //Author: Nyigel Spann
    public class ProjectileEffects
    {
        public ISound PowerBeamFireSound { get; private set; }
        public ISound IceBeamFireSound { get; private set; }
        public ISound WaveBeamFireSound { get; private set; }
        public ISound MissileRocketFireSound { get; private set; }
        public ISound ExplosionSound { get; private set; }
        public ISound PlaceBombSound { get; private set; }
        public ISound PowerBeamCollideSound { get; private set; }


        private static ProjectileEffects instance = new ProjectileEffects();
        public static ProjectileEffects Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private ProjectileEffects()
        {

        }
        public void LoadAllSounds(ContentManager content)
        {
            PowerBeamFireSound = new EffectInstance(content.Load<SoundEffect>("Sounds/PowerBeamSound"));
            IceBeamFireSound = new EffectInstance(content.Load<SoundEffect>("Sounds/IceBeamSound"));
            WaveBeamFireSound = new EffectInstance(content.Load<SoundEffect>("Sounds/WaveBeamSound"));
            MissileRocketFireSound = new EffectInstance(content.Load<SoundEffect>("Sounds/MissileRocketFireSound"));
            PlaceBombSound = new EffectInstance(content.Load<SoundEffect>("Sounds/PlaceBombSound"));
            ExplosionSound = new EffectInstance(content.Load<SoundEffect>("Sounds/ExplosionSound"));
            PowerBeamCollideSound = new EffectInstance(content.Load<SoundEffect>("Sounds/BeamCollideSound"));
        }
    }
}
