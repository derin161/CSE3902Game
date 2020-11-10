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
    public class BlockEffects
    {
        public ISound DoorSound { get; private set; }

        private static BlockEffects instance = new BlockEffects();
        public static BlockEffects Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private BlockEffects()
        {
            
        }
        public void LoadAllSounds(ContentManager content)
        {
            DoorSound = new EffectInstance(content.Load<SoundEffect>("Sounds/DoorSound"));
        }
    }
}
