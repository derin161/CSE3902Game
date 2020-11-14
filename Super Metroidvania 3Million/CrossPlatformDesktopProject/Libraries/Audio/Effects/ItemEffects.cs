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
    public class ItemEffects
    {
        public ISound EnergyPickupSound { get; private set; }


        private static ItemEffects instance = new ItemEffects();
        public static ItemEffects Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private ItemEffects()
        {
            
        }
        public void LoadAllSounds(ContentManager content)
        {
           EnergyPickupSound = new EffectInstance(content.Load<SoundEffect>("Sounds/EnergyPickupSound"));
        }
    }
}
