using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    //Author: Nyigel Spann
    public class SoundManager
    {
        private static SoundManager instance = new SoundManager();
        public ProjectileEffects Projectiles { get; private set; }
        public PlayerEffects Player { get; private set; }
        public SongManager Songs { get; private set; }
        private float volume;
        private float maxVolume = 1f;
        private float minVolume = 0f;
        private float volumeChange = 0.1f;

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
            Player = new PlayerEffects();
            Songs = new SongManager();
            volume = maxVolume;
        }
        public void LoadAllSounds(ContentManager content) {
            Projectiles.LoadAllSounds(content);
            Songs.LoadAllSounds(content);
            Player.LoadAllSounds(content);
        }

        public void Update(GameTime gtime) {
            Songs.Update(gtime);
            MediaPlayer.Volume = volume;
        }

        public void RaiseVolume() {
            volume += volumeChange;
            if (volume > maxVolume) {
                volume = maxVolume;
            }
        }

        public void LowerVolume()
        {
            volume -= volumeChange;
            if (volume < minVolume)
            {
                volume = minVolume;
            }
        }

        public void SilenceVolume()
        {
            volume = minVolume;
        }

        public void MaxVolume()
        {
            volume = maxVolume;
        }

    }
}
