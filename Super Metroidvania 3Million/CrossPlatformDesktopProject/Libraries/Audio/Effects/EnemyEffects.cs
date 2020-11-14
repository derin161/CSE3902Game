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
    public class EnemyEffects
    {
        private static EnemyEffects instance = new EnemyEffects();
        public static EnemyEffects Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private EnemyEffects()
        {
            
        }
        public void LoadAllSounds(ContentManager content)
        {

        }
    }
}
