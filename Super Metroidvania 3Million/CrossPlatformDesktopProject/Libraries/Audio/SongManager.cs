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
    //Author: Nyigel Spann
    public class SongManager
    {
        private static SongManager instance = new SongManager();
        private ISound tourianTheme;
        private ISound endingTheme;
        private ISound escapeTheme;
        private ISound norfairTheme;
        private ISound titleTheme;
        private ISound ridleysHideoutTheme;
        private ISound secretAreaTheme;
        private ISound motherBrainBattleTheme;
        private ISound gameStartSong;
        private ISound brinTheme;
        private ISound getItemSong;
        private ISound darudeSand;
        private ISound activeSong; //Song currently being played

        private List<ISound> ThemeSongs = new List<ISound>();
        private int mstimer = 0; //Timer used for looping or playing next song
        private int songIndex = 0;
        private bool loopMode = false;

        public static SongManager Instance
        {
            get
            {
                return instance;
            }
        }

        //private constructor for singleton
        private SongManager()
        {
        }

        public void LoadAllSounds(ContentManager content)
        {
            brinTheme = new SongInstance(content.Load<Song>("Sounds/BrinstarThemeSong"));
            getItemSong = new SongInstance(content.Load<Song>("Sounds/ItemAcquisitionSong"));
            darudeSand = new SongInstance(content.Load<Song>("Sounds/DarudeSandstormSong"));
            tourianTheme = new SongInstance(content.Load<Song>("Sounds/TourianTheme"));
            endingTheme = new SongInstance(content.Load<Song>("Sounds/EndingTheme"));
            escapeTheme = new SongInstance(content.Load<Song>("Sounds/EscapeTheme"));
            norfairTheme = new SongInstance(content.Load<Song>("Sounds/NorfairTheme"));
            titleTheme = new SongInstance(content.Load<Song>("Sounds/TitleTheme"));
            ridleysHideoutTheme = new SongInstance(content.Load<Song>("Sounds/RidleysHideout"));
            secretAreaTheme = new SongInstance(content.Load<Song>("Sounds/SecretArea"));
            motherBrainBattleTheme = new SongInstance(content.Load<Song>("Sounds/MotherBrainBattle"));
            gameStartSong = new SongInstance(content.Load<Song>("Sounds/GameStart"));

            /* Add the Theme Songs */
            ThemeSongs.Add(brinTheme);
            ThemeSongs.Add(tourianTheme);
            ThemeSongs.Add(endingTheme);
            ThemeSongs.Add(escapeTheme);
            ThemeSongs.Add(norfairTheme);
            ThemeSongs.Add(ridleysHideoutTheme);
            ThemeSongs.Add(secretAreaTheme);
            ThemeSongs.Add(motherBrainBattleTheme);
            ThemeSongs.Add(titleTheme);
            ThemeSongs.Add(darudeSand);
        }

        public void Update(GameTime gtime)
        {
            mstimer -= gtime.ElapsedGameTime.Milliseconds;
            if (mstimer < 0) {
                if (loopMode) {
                    play();
                }
                else {
                    PlayNextTheme();
                }

            }

        }

        public void PlayBrinstarTheme() {
            activeSong = brinTheme;
            play();
        }

        public void PlayItemAcquisitionSong() {
            activeSong = getItemSong;
            play();
        }

        public void PlayDarudeSandstorm() {
            activeSong = darudeSand;
            play();
        }

        public void PlayTourianTheme()
        {
            activeSong = tourianTheme;
            play();
        }

        public void PlayEscapeTheme()
        {
            activeSong = escapeTheme;
            play();
        }

        public void PlayRidleysHidoutTheme()
        {
            activeSong = ridleysHideoutTheme;
            play();
        }

        public void PlayNorfairTheme()
        {
            activeSong = norfairTheme;
            play();
        }

        public void PlaySecretAreaTheme()
        {
            activeSong = secretAreaTheme;
            play();
        }

        public void PlayMotherBrainBattleTheme()
        {
            activeSong = motherBrainBattleTheme;
            play();
        }

        public void PlayTitleTheme()
        {
            activeSong = titleTheme;
            play();
        }

        public void PlayEndingTheme()
        {
            activeSong = endingTheme;
            play();
        }

        public void PlayGameStartSong()
        {
            activeSong = gameStartSong;
            play();
        }

        public void PlayPreviousTheme()
        {
            songIndex = (((songIndex - 1) % ThemeSongs.Count) + ThemeSongs.Count) % ThemeSongs.Count; //Mod that works for negative numbers

            activeSong = ThemeSongs[songIndex];
            loopMode = false;
            play();
        }

        public void PlayNextTheme() {
            songIndex = (songIndex + 1) % ThemeSongs.Count;
            activeSong = ThemeSongs[songIndex];
            loopMode = false;
            play();
        }

        private void play() {
            mstimer = (int) activeSong.Duration() + 50;
            activeSong.PlaySound();
        }

        /* Loops the currently active song. */
        public void loop() {
            loopMode = true;
        }




    }
}
