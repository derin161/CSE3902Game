using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    public class SoundManager
    {
        private static SoundManager instance = new SoundManager();
        public ProjectileEffects Projectiles { get; private set; }
        public SongManager Songs { get; private set; }
        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private SoundManager() {
            Projectiles = new ProjectileEffects();
            Songs = new SongManager();
        }
        public void LoadAllSounds(ContentManager content) {
            Projectiles.LoadAllSounds(content);
            Songs.LoadAllSounds(content);
        }

        public void Update(GameTime gtime) {
            Songs.Update(gtime);
        }
    }
}
