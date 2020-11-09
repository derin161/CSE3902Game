using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    public class SongManager
    {
        private ISound brinTheme;
        private ISound getItemSong;
        private ISound loopSong;
        private ISound activeSong; //Song currently being played
        private int mstimer = 0;


        public SongManager()
        {
        }
        public void LoadAllSounds(ContentManager content)
        {
            brinTheme = new SongInstance(content.Load<Song>("Sounds/BrinstarThemeSong"));
            getItemSong = new SongInstance(content.Load<Song>("Sounds/ItemAcquisitionSong"));
            loopSong = brinTheme;
        }

        public void Update(GameTime gtime)
        {
            mstimer -= gtime.ElapsedGameTime.Milliseconds;
            if (mstimer < 0) {
                loop();
            }

        }

        public void PlayBrinstarTheme() {
            loopSong = brinTheme;
            loop();
        }

        public void PlayItemAcquisitionSong() {
            activeSong = getItemSong;
            play();
        }

        private void play() {
            mstimer = (int) activeSong.Duration() + 100;
            activeSong.PlaySound();
        }

        private void loop() {
            activeSong = loopSong;
            mstimer = (int) activeSong.Duration() + 100;
            activeSong.PlaySound();
        }


    }
}
