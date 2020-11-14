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
    public class MiscEffects
    {
        public ISound GameOverSound { get; private set; }

        private static MiscEffects instance = new MiscEffects();
        public static MiscEffects Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private MiscEffects()
        {
            
        }
        public void LoadAllSounds(ContentManager content)
        {
            GameOverSound = new EffectInstance(content.Load<SoundEffect>("Sounds/GameOverSound"));
        }
    }
}
