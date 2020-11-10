using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace CrossPlatformDesktopProject.Libraries.Audio
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
        public ProjectileEffects()
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
