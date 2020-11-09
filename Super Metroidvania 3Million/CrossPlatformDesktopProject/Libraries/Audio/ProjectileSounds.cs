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
    public class ProjectileSounds
    {
        public ISound BeamSound { get; private set; }
        public ProjectileSounds()
        {
            
        }
        public void LoadAllSounds(ContentManager content)
        {
            BeamSound = new Sound(content.Load<SoundEffect>("Sounds/PowerBeamSound"));
        }
    }
}
