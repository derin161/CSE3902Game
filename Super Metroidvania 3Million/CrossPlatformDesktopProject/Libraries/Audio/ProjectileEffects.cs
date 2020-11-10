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
    public class ProjectileEffects
    {
        public ISound PowerBeamFireSound { get; private set; }
        public ProjectileEffects()
        {
            
        }
        public void LoadAllSounds(ContentManager content)
        {
            PowerBeamFireSound = new EffectInstance(content.Load<SoundEffect>("Sounds/PowerBeamSound"));
        }
    }
}
