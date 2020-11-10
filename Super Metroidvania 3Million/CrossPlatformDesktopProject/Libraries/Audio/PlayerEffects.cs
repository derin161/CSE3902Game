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
    public class PlayerEffects
    {
        public ISound JumpSound { get; private set; }
        public ISound PlayerDamageSound { get; private set; }
        public PlayerEffects()
        {
            
        }
        public void LoadAllSounds(ContentManager content)
        {
            JumpSound = new EffectInstance(content.Load<SoundEffect>("Sounds/JumpSound"));
            PlayerDamageSound = new EffectInstance(content.Load<SoundEffect>("Sounds/PlayerDamageSound"));
        }
    }
}
